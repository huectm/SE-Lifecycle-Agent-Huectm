/**
 * Design revision 2026-11-02: OrderLifecycleRepository
 * Ownership: FreshFood.Reposistory.Repository.Implements
 * - session: IRepositorySession
 * + OrderLifecycleRepository(session: IRepositorySession)
 * + LockOrderAsync(orderId: EntityId, signal: AbortSignal): Promise<Order>
 * + LoadLifecycleAsync(orderId: EntityId, signal: AbortSignal): Promise<OrderLifecycleRecords>
 * + SaveAsync(order: Order, signal: AbortSignal): Promise<void>
 * + RecordEventOnceAsync(aggregateId: EntityId, eventId: string, transitionId: string, signal: AbortSignal): Promise<boolean>
 * + SaveOrderLinesAsync(order: Order, lines: ReadonlyArray<OrderDetail>, signal: AbortSignal): Promise<void>
 * + SavePaymentOnceAsync(payment: OrderPayment, signal: AbortSignal): Promise<boolean>
 * + SaveFailureAsync(failure: DeliveryFailure, signal: AbortSignal): Promise<void>
 * + SaveReceiptAsync(receipt: ReturnReceipt, items: ReadonlyArray<ReturnReceiptItem>, signal: AbortSignal): Promise<void>
 * + SaveRefundOnceAsync(refund: Refund, signal: AbortSignal): Promise<boolean>
 * + SaveShippingSettlementAsync(settlement: ShippingFeeSettlement, signal: AbortSignal): Promise<void>
 * + LockReservedBatchesAsync(orderId: EntityId, signal: AbortSignal): Promise<ReadonlyArray<BatchInventory>>
 * + SaveBatchesAsync(batches: ReadonlyArray<BatchInventory>, signal: AbortSignal): Promise<void>
 * + AppendAuditAsync(audit: AuditLog, signal: AbortSignal): Promise<void>
 */
import { encode, rows, one, lock, cart as loadCart, saveCart, batches as loadBatches, orders, gap } from './sql.js';
export class OrderLifecycleRepository {
  constructor(session) {this.session=session;}
  async LockOrderAsync(orderId, signal) { return one(this.session,'SELECT * FROM orders WHERE order_id=$1 FOR UPDATE',[orderId],signal); }
  async LoadLifecycleAsync(orderId, signal) { gap('TRUSTED_STANDALONE_LIFECYCLE_SNAPSHOT_TBD'); }
  async SaveAsync(order, signal) { await rows(this.session,'UPDATE orders SET order_status=$1,payment_status=$2,cancellation_reason=$3 WHERE order_id=$4',[encode(order.OrderStatus),encode(order.PaymentStatus),order.CancellationReason??null,order.OrderId],signal); }
  async RecordEventOnceAsync(aggregateId, eventId, transitionId, signal) { if (!this.session.active) throw new Error('Transition evidence requires current transaction');
    const orderId=/^[1-9][0-9]*$/.test(aggregateId)?aggregateId:null;
    return (await rows(this.session,`INSERT INTO order_transition_events(aggregate_key,event_id,transition_id,order_id)
      VALUES($1,$2,$3,$4) ON CONFLICT(aggregate_key,event_id,transition_id) DO NOTHING RETURNING transition_event_id`,
      [aggregateId,eventId,transitionId,orderId],signal)).length===1; }
  async SaveOrderLinesAsync(order, lines, signal) { gap('SHARED_ORDER_LINE_EFFECTS_REQUIRE_REVIEW'); }
  async SavePaymentOnceAsync(payment, signal) { gap('PAYMENT_CAPTURE_STORAGE_REVIEW_REQUIRED'); }
  async SaveFailureAsync(failure, signal) { gap('STAFF_DELIVERY_FAILURE_NOT_IN_CUSTOMER_INCREMENT'); }
  async SaveReceiptAsync(receipt, items, signal) { gap('STAFF_RETURN_RECEIPT_NOT_IN_CUSTOMER_INCREMENT'); }
  async SaveRefundOnceAsync(refund, signal) { gap('REFUND_PROVIDER_AND_STORAGE_REVIEW_REQUIRED'); }
  async SaveShippingSettlementAsync(settlement, signal) { gap('SHIPPING_SETTLEMENT_NOT_IN_CUSTOMER_INCREMENT'); }
  async LockReservedBatchesAsync(orderId, signal) { return rows(this.session,'SELECT DISTINCT b.* FROM batch_inventory b JOIN order_details d ON d.batch_id=b.batch_id WHERE d.order_id=$1 ORDER BY b.batch_id',[orderId],signal).then(async bs=>{for(const b of bs)Object.assign(b,await one(this.session,'SELECT * FROM batch_inventory WHERE batch_id=$1 FOR UPDATE',[b.BatchId],signal));return bs;}); }
  async SaveBatchesAsync(batches, signal) { for(const b of batches)await rows(this.session,'UPDATE batch_inventory SET reserved_stock=$1 WHERE batch_id=$2',[b.ReservedStock,b.BatchId],signal); }
  async AppendAuditAsync(audit, signal) { if (!this.session.active) throw new Error('Customer audit requires current transaction');
    if (!audit.ActorCustomerId || !audit.OrderId) throw new Error('Customer audit identity required');
    const result=await rows(this.session,`INSERT INTO audit_logs(staff_id,customer_id,action_type,entity_name,record_identifier,old_values,new_values)
      SELECT NULL,$1,'UPDATE','orders',order_id::text,$2::jsonb,$3::jsonb FROM orders WHERE order_id=$4 AND customer_id=$1 RETURNING log_id`,
      [audit.ActorCustomerId,JSON.stringify({order_status:encode(audit.PreviousStatus)}),JSON.stringify({order_status:'CANCELLED',cancellation_reason:audit.Reason}),audit.OrderId],signal);
    if(result.length!==1)throw Object.assign(new Error('AUDIT_ORDER_NOT_OWNED'),{code:'AUDIT_ORDER_NOT_OWNED',status:403}); }
}
