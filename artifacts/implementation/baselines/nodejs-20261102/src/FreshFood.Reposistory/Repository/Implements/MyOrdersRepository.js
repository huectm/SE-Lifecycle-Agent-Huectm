/**
 * Design revision 2026-11-02: MyOrdersRepository
 * Ownership: FreshFood.Reposistory.Repository.Implements
 * - session: IRepositorySession
 * + MyOrdersRepository(session: IRepositorySession)
 * + FindOwnedAsync(customerId: EntityId, signal: AbortSignal): Promise<ReadonlyArray<Order>>
 * + LockOwnedAsync(customerId: EntityId, orderId: EntityId, signal: AbortSignal): Promise<Order>
 * + GetCurrentBatchesAsync(productIds: ReadonlyArray<EntityId>, signal: AbortSignal): Promise<ReadonlyArray<BatchInventory>>
 * + SaveCartAsync(cart: Cart, signal: AbortSignal): Promise<void>
 * + SaveReviewOnceAsync(review: OrderReview, signal: AbortSignal): Promise<boolean>
 * + GetReturnReceiptAsync(orderId: EntityId, signal: AbortSignal): Promise<ReturnReceipt?>
 * + GetRefundAsync(orderId: EntityId, signal: AbortSignal): Promise<Refund?>
 */
import { rows, one, lock, cart as loadCart, saveCart, batches as loadBatches, orders, gap } from './sql.js';
export class MyOrdersRepository {
  constructor(session) {this.session=session;}
  async FindOwnedAsync(customerId, signal) { return orders(this.session,customerId,signal); }
  async LockOwnedAsync(customerId, orderId, signal) { const owned=await one(this.session,'SELECT order_id FROM orders WHERE customer_id=$1 AND order_id=$2 FOR UPDATE',[customerId,orderId],signal);if(!owned)return null;return (await orders(this.session,customerId,signal)).find(o=>o.OrderId===orderId); }
  async GetCurrentBatchesAsync(productIds, signal) { return loadBatches(this.session,productIds,signal); }
  async SaveCartAsync(cart, signal) { const current=await loadCart(this.session,cart.CustomerId,null,signal);for(const i of cart.Items)current.ChangeQuantity(i.ProductId,i.Quantity);return saveCart(this.session,current,signal); }
  async SaveReviewOnceAsync(review, signal) { return (await rows(this.session,'INSERT INTO order_reviews(order_id,customer_id,rating,comment) VALUES($1,$2,$3,$4) ON CONFLICT (order_id) DO NOTHING RETURNING review_id',[review.OrderId,review.CustomerId,review.Rating,review.Comment??null],signal)).length>0; }
  async GetReturnReceiptAsync(orderId, signal) { return one(this.session,'SELECT * FROM return_receipts WHERE order_id=$1',[orderId],signal); }
  async GetRefundAsync(orderId, signal) { return one(this.session,'SELECT * FROM refunds WHERE order_id=$1 ORDER BY refund_id DESC LIMIT 1',[orderId],signal); }
}
