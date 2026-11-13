/**
 * Design revision 2026-11-02: CheckoutRepository
 * Ownership: FreshFood.Reposistory.Repository.Implements
 * - session: IRepositorySession
 * - fefo: IFefoBatchSpecification
 * + CheckoutRepository(session: IRepositorySession, fefo: IFefoBatchSpecification)
 * + GetCheckoutCartAsync(customerId: EntityId, signal: AbortSignal): Promise<Cart>
 * + GetOwnedAddressAsync(customerId: EntityId, addressId: EntityId, signal: AbortSignal): Promise<CustomerAddress>
 * + LockFefoBatchesAsync(productIds: ReadonlyArray<EntityId>, signal: AbortSignal): Promise<ReadonlyArray<BatchInventory>>
 * + SaveOrderAsync(order: Order, signal: AbortSignal): Promise<void>
 * + SavePaymentOnceAsync(payment: OrderPayment, signal: AbortSignal): Promise<boolean>
 * + ClearCartAsync(cartId: EntityId, signal: AbortSignal): Promise<void>
 * + ClaimCheckoutAsync(customerId: EntityId, reference: string, key: string, requestHash: string, signal: AbortSignal): Promise<object>
 * + CompleteCheckoutAsync(customerId: EntityId, reference: string, key: string, response: object, signal: AbortSignal): Promise<void>
 */
import { encode, rows, one, lock, cart as loadCart, saveCart, batches as loadBatches, orders, gap } from './sql.js';
export class CheckoutRepository {
  constructor(session, fefo) {this.session=session;this.fefo=fefo;}
  async GetCheckoutCartAsync(customerId, signal) { return loadCart(this.session,customerId,null,signal); }
  async GetOwnedAddressAsync(customerId, addressId, signal) { return one(this.session,'SELECT * FROM customer_addresses WHERE customer_id=$1 AND address_id=$2'+lock(this.session),[customerId,addressId],signal); }
  async LockFefoBatchesAsync(productIds, signal) { this.fefo.Criteria(new Date());return loadBatches(this.session,productIds,signal,true); }
  async SaveOrderAsync(order, signal) { if(!this.session.active)throw new Error('Order persistence requires transaction');
await rows(this.session,'SELECT customer_id FROM customers WHERE customer_id=$1 FOR UPDATE',[order.CustomerId],signal);
const prior=await rows(this.session,'SELECT order_id FROM orders WHERE customer_id=$1 LIMIT 1',[order.CustomerId],signal);order.IsFirstOrder=prior.length===0;order.PhoneConfirmationStatus='NOT_CONTACTED';
for(const l of order.Details){const updated=await rows(this.session,'UPDATE batch_inventory SET reserved_stock=reserved_stock+$1 WHERE batch_id=$2 AND current_stock-reserved_stock >= $1 RETURNING batch_id',[l.Quantity,l.BatchId],signal);if(!updated.length)throw Object.assign(new Error('Stock changed'),{code:'INSUFFICIENT_STOCK',status:409});}
const saved=await one(this.session,'INSERT INTO orders(order_number,customer_id,delivery_address_id,order_date,sub_total,delivery_distance,shipping_fee,total_amount,payment_method,payment_status,order_status,is_first_order,phone_confirmation_status) VALUES($1,$2,$3,$4,$5,$6,$7,$8,$9,$10,$11,$12,$13) RETURNING order_id',[order.OrderNumber,order.CustomerId,order.DeliveryAddressId,order.OrderDate,order.SubTotal,order.DeliveryDistance,order.ShippingFee,order.TotalAmount,encode(order.PaymentMethod),encode(order.PaymentStatus),encode(order.OrderStatus),order.IsFirstOrder,order.PhoneConfirmationStatus],signal);order.OrderId=saved.OrderId;
for(const l of order.Details)await rows(this.session,'INSERT INTO order_details(order_id,batch_id,quantity,unit_price,discount_amount,line_total) VALUES($1,$2,$3,$4,$5,$6)',[order.OrderId,l.BatchId,l.Quantity,l.UnitPrice,l.DiscountAmount,l.LineTotal],signal); }
  async SavePaymentOnceAsync(payment, signal) { gap('PAYMENT_CAPTURE_STORAGE_REVIEW_REQUIRED'); }
  async ClearCartAsync(cartId, signal) { await rows(this.session,'DELETE FROM cart_items WHERE cart_id=$1',[cartId],signal); }
  async ClaimCheckoutAsync(customerId, reference, key, requestHash, signal) {
    if (!this.session.active) throw new Error('Idempotency claim requires current transaction');
    const inserted = await rows(this.session, `INSERT INTO checkout_idempotency
      (customer_id, operation, idempotency_key, checkout_reference, request_hash)
      VALUES ($1, 'PlaceOrder', $2, $3, $4) ON CONFLICT DO NOTHING RETURNING idempotency_key`,
      [customerId, key, reference, requestHash], signal);
    const saved = await one(this.session, `SELECT * FROM checkout_idempotency
      WHERE customer_id=$1 AND operation='PlaceOrder' AND idempotency_key=$2 FOR UPDATE`, [customerId,key], signal);
    if (!saved) throw Object.assign(new Error('CHECKOUT_REFERENCE_REUSED'), {code:'CHECKOUT_REFERENCE_REUSED',status:409});
    if (saved.RequestHash !== requestHash || saved.CheckoutReference !== reference)
      throw Object.assign(new Error('IDEMPOTENCY_KEY_REUSED'), {code:'IDEMPOTENCY_KEY_REUSED',status:409});
    if (saved.Response != null) return { Replay:true, Response:saved.Response };
    if (!inserted.length) throw Object.assign(new Error('INCOMPLETE_IDEMPOTENCY_RECORD'), {code:'INCOMPLETE_IDEMPOTENCY_RECORD',status:503});
    return {Replay:false};
  }
  async CompleteCheckoutAsync(customerId, reference, key, response, signal) {
    if (!this.session.active) throw new Error('Idempotency completion requires current transaction');
    const updated = await rows(this.session, `UPDATE checkout_idempotency SET order_id=$1,response=$2::jsonb,completed_at=CURRENT_TIMESTAMP
      WHERE customer_id=$3 AND operation='PlaceOrder' AND idempotency_key=$4 AND checkout_reference=$5 AND response IS NULL AND EXISTS(SELECT 1 FROM orders o WHERE o.order_id=$1 AND o.customer_id=$3)
      RETURNING order_id`, [response.OrderId,JSON.stringify(response),customerId,key,reference], signal);
    if (updated.length !== 1) throw new Error('IDEMPOTENCY_COMPLETION_CONFLICT');
    await rows(this.session, `UPDATE order_transition_events SET order_id=$1
      WHERE aggregate_key=$2 AND event_id=$3 AND order_id IS NULL`, [response.OrderId,'checkout:'+customerId+':'+reference,key],signal);
  }
}
