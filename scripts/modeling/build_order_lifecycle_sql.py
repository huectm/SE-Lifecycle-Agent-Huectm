from pathlib import Path
import json
ROOT=Path(__file__).resolve().parents[2];m=json.loads((ROOT/'artifacts/design/order-lifecycle-model.json').read_text())
parts=['-- FreshFood order lifecycle design delta. PostgreSQL 16+ syntax.\n-- REVIEW ONLY: not a production migration. Existing modeled base tables are prerequisites.\n-- Inspect live constraints/legacy data before deployment; do not auto-map ambiguous historical records.\nBEGIN;']
for t in m['tables']:
 lines=[f"  {c['name']} {c['type']} {c['constraint']}".rstrip() for c in t['columns']]
 lines += [f'  CHECK ({s})' for s in t['checks']]
 if t['name']=='order_payments':lines.append('  UNIQUE (payment_channel, provider_transaction_id)')
 if t['name']=='return_receipts':lines.append('  UNIQUE (return_receipt_id, order_id)')
 if t['name']=='return_receipt_items':
  lines += ['  UNIQUE (return_receipt_id, order_detail_id)','  FOREIGN KEY (return_receipt_id,order_id) REFERENCES return_receipts(return_receipt_id,order_id)','  FOREIGN KEY (order_detail_id,order_id) REFERENCES order_details(order_detail_id,order_id)']
 if t['name']=='refunds':lines.append('  FOREIGN KEY (return_receipt_id,order_id) REFERENCES return_receipts(return_receipt_id,order_id)')
 # Cross-order line ownership is enforced before dependent receipt tables are created.
 if t['name']=='return_receipt_items':parts.append('ALTER TABLE order_details ADD CONSTRAINT uq_order_detail_order UNIQUE (order_detail_id,order_id);')
 parts.append('CREATE TABLE '+t['name']+' (\n'+',\n'.join(lines)+'\n);')
 if t['name']=='delivery_agents':
  parts += ['ALTER TABLE orders ADD COLUMN '+c['name']+' '+c['type']+' '+c['constraint']+';' for c in m['order_additions']]
parts+=['''ALTER TABLE orders
 ADD CONSTRAINT ck_order_status_revision CHECK(order_status IN ('PENDING_UNPAID','PENDING_PAID','CONFIRMED','PACKING','SHIPPING','DELIVERED','CANCELLED','DELIVERY_FAILED','RETURNED')),
 ADD CONSTRAINT ck_payment_status_revision CHECK(payment_status IN ('UNPAID','PAID','PARTIALLY_REFUNDED','REFUNDED')),
 ADD CONSTRAINT ck_payment_method_revision CHECK(payment_method IN ('COD','VIETQR')),
 ADD CONSTRAINT ck_pending_payment_revision CHECK(order_status <> 'PENDING_PAID' OR payment_status='PAID'),
 ADD CONSTRAINT ck_phone_result CHECK(phone_confirmation_status IN ('NOT_CONTACTED','CONFIRMED','UNCONFIRMED')),
 ADD CONSTRAINT ck_phone_evidence CHECK(phone_confirmation_status='NOT_CONTACTED' OR (phone_contacted_by_staff_id IS NOT NULL AND phone_contacted_at IS NOT NULL));

CREATE INDEX ix_payment_order ON order_payments(order_id);
CREATE INDEX ix_return_line_order ON return_receipt_items(order_id,order_detail_id);
CREATE INDEX ix_refund_dispatch ON refunds(refund_status,requested_at) WHERE refund_status IN ('PENDING','FAILED','UNKNOWN');
CREATE INDEX ix_inspection_receipt_line ON return_inspections(return_receipt_item_id);

CREATE VIEW order_pending_states AS
 SELECT o.order_id,
  o.order_status AS displayed_state,
  (o.is_first_order AND o.payment_status='UNPAID') AS telephone_confirmation_required
 FROM orders o;

CREATE FUNCTION guard_order_approval() RETURNS trigger LANGUAGE plpgsql AS $$
DECLARE g numeric; s numeric;
BEGIN
 IF TG_OP='UPDATE' AND OLD.order_status IN ('PENDING_UNPAID','PENDING_PAID') AND NEW.order_status IN ('PENDING_UNPAID','PENDING_PAID') AND OLD.order_status<>NEW.order_status THEN
  RAISE EXCEPTION 'No transition between independent pending states' USING ERRCODE='23514';
 END IF;
 IF TG_OP='INSERT' AND NEW.order_status='PENDING_UNPAID' AND NEW.payment_status<>'UNPAID' THEN
  RAISE EXCEPTION 'Initial unpaid branch requires unpaid payment evidence' USING ERRCODE='23514';
 END IF;
 IF TG_OP='UPDATE' AND NEW.payment_status='PAID' AND OLD.payment_status IS DISTINCT FROM NEW.payment_status THEN
  SELECT coalesce(sum(goods_amount),0),coalesce(sum(shipping_amount),0) INTO g,s FROM order_payments WHERE order_id=NEW.order_id;
  IF g < NEW.sub_total OR s < NEW.shipping_fee THEN
   RAISE EXCEPTION 'Full goods/shipping payment evidence is required for PAID' USING ERRCODE='23514';
  END IF;
 END IF;
 IF NEW.order_status='CONFIRMED' AND (TG_OP='INSERT' OR OLD.order_status IS DISTINCT FROM NEW.order_status)
   AND NEW.is_first_order AND NEW.payment_status='UNPAID' AND NEW.phone_confirmation_status<>'CONFIRMED' THEN
  RAISE EXCEPTION 'First unpaid order requires successful phone confirmation' USING ERRCODE='23514';
 END IF;
 RETURN NEW;
END $$;
CREATE TRIGGER order_approval_guard BEFORE INSERT OR UPDATE ON orders FOR EACH ROW EXECUTE FUNCTION guard_order_approval();

ALTER TABLE orders ALTER COLUMN order_status SET DEFAULT 'PENDING_UNPAID';
CREATE FUNCTION guard_initial_paid_evidence() RETURNS trigger LANGUAGE plpgsql AS $$
BEGIN
 IF NEW.order_status='PENDING_PAID' AND NOT EXISTS (
 SELECT 1 FROM order_payments WHERE order_id=NEW.order_id GROUP BY order_id
 HAVING sum(goods_amount)>=NEW.sub_total AND sum(shipping_amount)>=NEW.shipping_fee) THEN
 RAISE EXCEPTION 'Paid initial branch requires verified goods and shipping evidence' USING ERRCODE='23514';
 END IF;
 RETURN NEW;
END $$;
CREATE CONSTRAINT TRIGGER initial_paid_evidence AFTER INSERT ON orders DEFERRABLE INITIALLY DEFERRED FOR EACH ROW EXECUTE FUNCTION guard_initial_paid_evidence();

CREATE FUNCTION guard_complete_return() RETURNS trigger LANGUAGE plpgsql AS $$
BEGIN
 IF NEW.receipt_status='COMPLETE' AND (TG_OP='INSERT' OR OLD.receipt_status IS DISTINCT FROM NEW.receipt_status) THEN
  PERFORM 1 FROM orders WHERE order_id=NEW.order_id AND order_status='DELIVERY_FAILED' FOR UPDATE;
  IF NOT FOUND THEN RAISE EXCEPTION 'Complete receiving requires a failed-delivery order' USING ERRCODE='23514'; END IF;
  IF NOT EXISTS(SELECT 1 FROM order_details WHERE order_id=NEW.order_id) OR EXISTS(
    SELECT 1 FROM order_details d LEFT JOIN return_receipt_items i ON i.order_detail_id=d.order_detail_id AND i.return_receipt_id=NEW.return_receipt_id
    WHERE d.order_id=NEW.order_id AND coalesce(i.quantity_received,0)<>d.quantity) THEN
   RAISE EXCEPTION 'Every original order line must be received in full' USING ERRCODE='23514';
  END IF;
 END IF;
 RETURN NEW;
END $$;
CREATE TRIGGER complete_return_guard BEFORE INSERT OR UPDATE ON return_receipts FOR EACH ROW EXECUTE FUNCTION guard_complete_return();

CREATE FUNCTION guard_received_line() RETURNS trigger LANGUAGE plpgsql AS $$
DECLARE status_value text; expected integer;
BEGIN
 SELECT receipt_status INTO status_value FROM return_receipts WHERE return_receipt_id=coalesce(NEW.return_receipt_id,OLD.return_receipt_id) FOR UPDATE;
 IF status_value='COMPLETE' THEN RAISE EXCEPTION 'Completed receiving lines are immutable; use a reviewed correction procedure' USING ERRCODE='23514'; END IF;
 IF TG_OP<>'DELETE' THEN
  SELECT quantity INTO expected FROM order_details WHERE order_detail_id=NEW.order_detail_id AND order_id=NEW.order_id;
  IF expected IS NOT NULL AND NEW.quantity_received>expected THEN RAISE EXCEPTION 'Received quantity exceeds original line quantity' USING ERRCODE='23514'; END IF;
  RETURN NEW;
 END IF;
 RETURN OLD;
END $$;
CREATE TRIGGER received_line_guard BEFORE INSERT OR UPDATE OR DELETE ON return_receipt_items FOR EACH ROW EXECUTE FUNCTION guard_received_line();

CREATE FUNCTION queue_failed_delivery_refund(p_order_id bigint) RETURNS bigint LANGUAGE plpgsql AS $$
DECLARE o orders%ROWTYPE; r return_receipts%ROWTYPE; f delivery_failures%ROWTYPE; g numeric; s numeric; excess numeric; id_result bigint;
BEGIN
 SELECT * INTO o FROM orders WHERE order_id=p_order_id FOR UPDATE;
 IF NOT FOUND THEN RAISE EXCEPTION 'Order not found'; END IF;
 SELECT * INTO r FROM return_receipts WHERE order_id=p_order_id AND receipt_status='COMPLETE';
 IF NOT FOUND THEN RETURN NULL; END IF;
 SELECT * INTO f FROM delivery_failures WHERE order_id=p_order_id AND cause_confirmed_at IS NOT NULL;
 IF NOT FOUND OR f.failure_cause NOT IN ('PRODUCT_FAULT','CUSTOMER_INTENTIONAL_REFUSAL') THEN RETURN NULL; END IF;
 SELECT coalesce(sum(goods_amount),0),coalesce(sum(shipping_amount),0),coalesce(sum(unallocated_amount),0) INTO g,s,excess FROM order_payments WHERE order_id=p_order_id;
 IF excess>0 THEN RETURN NULL; END IF; -- overpayment disposition is not yet approved
 -- Shipping-only collection is not a paid-goods refund. Partial goods-payment policy remains outside this flow.
 IF g<=0 OR g<o.sub_total THEN RETURN NULL; END IF;
 IF f.failure_cause='CUSTOMER_INTENTIONAL_REFUSAL' THEN s:=0; END IF;
 INSERT INTO refunds(order_id,return_receipt_id,goods_amount,shipping_amount,idempotency_key)
  VALUES(p_order_id,r.return_receipt_id,g,s,'failed-return:'||p_order_id)
  ON CONFLICT(order_id) DO NOTHING RETURNING refund_id INTO id_result;
 IF id_result IS NULL THEN SELECT refund_id INTO id_result FROM refunds WHERE order_id=p_order_id; END IF;
 RETURN id_result;
END $$;
REVOKE ALL ON FUNCTION queue_failed_delivery_refund(bigint) FROM PUBLIC;

-- Application transaction: lock order -> confirm full receipt -> set order_status RETURNED -> call queue_failed_delivery_refund.
-- Also re-evaluate after final cause confirmation or verified payment arrival; do not infer late-payment eligibility policy.
-- Staff-only inspection does not appear in refund eligibility. External payout execution and final cause authority remain TBD.
-- REFUNDED/PARTIALLY_REFUNDED must be synchronized from confirmed refund settlements, never from request submission.
COMMIT;''']
(ROOT/'artifacts/design/database/order-lifecycle-extension.sql').write_text('\n\n'.join(parts),encoding='utf-8')
print('Wrote review-only PostgreSQL design delta and receipt/refund/approval integrity functions.')
