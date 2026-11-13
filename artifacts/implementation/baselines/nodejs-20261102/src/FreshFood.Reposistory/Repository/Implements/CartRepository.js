/**
 * Design revision 2026-11-02: CartRepository
 * Ownership: FreshFood.Reposistory.Repository.Implements
 * - session: IRepositorySession
 * + CartRepository(session: IRepositorySession)
 * + GetAsync(customerId: EntityId?, sessionId: string?, signal: AbortSignal): Promise<Cart>
 * + GetProductsAsync(ids: ReadonlyArray<EntityId>, signal: AbortSignal): Promise<ReadonlyArray<Product>>
 * + GetSellableBatchesAsync(ids: ReadonlyArray<EntityId>, signal: AbortSignal): Promise<ReadonlyArray<BatchInventory>>
 * + SaveAsync(cart: Cart, signal: AbortSignal): Promise<void>
 */
import { rows, one, lock, cart as loadCart, saveCart, batches as loadBatches, orders, gap } from './sql.js';
export class CartRepository {
  constructor(session) {this.session=session;}
  async GetAsync(customerId, sessionId, signal) { return loadCart(this.session,customerId,sessionId,signal); }
  async GetProductsAsync(ids, signal) { return rows(this.session,'SELECT * FROM products WHERE product_id=ANY($1::bigint[])',[ids],signal); }
  async GetSellableBatchesAsync(ids, signal) { return loadBatches(this.session,ids,signal); }
  async SaveAsync(cart, signal) { return saveCart(this.session,cart,signal); }
}
