/**
 * Design revision 2026-11-02: ICartRepository
 * Ownership: FreshFood.Reposistory.Repository
 * + GetAsync(customerId: EntityId?, sessionId: string?, signal: AbortSignal): Promise<Cart>
 * + GetProductsAsync(ids: ReadonlyArray<EntityId>, signal: AbortSignal): Promise<ReadonlyArray<Product>>
 * + GetSellableBatchesAsync(ids: ReadonlyArray<EntityId>, signal: AbortSignal): Promise<ReadonlyArray<BatchInventory>>
 * + SaveAsync(cart: Cart, signal: AbortSignal): Promise<void>
 */
/** ICartRepository — FreshFood.Reposistory.Repository; approved design source: detailed-class-model.json. */
export class ICartRepository {
  async GetAsync(customerId, sessionId, signal) { throw Object.assign(new Error("ICartRepository.GetAsync: implementation or external port required"), { code: "DESIGN_PORT_UNCONFIGURED", status: 503 }); }
  async GetProductsAsync(ids, signal) { throw Object.assign(new Error("ICartRepository.GetProductsAsync: implementation or external port required"), { code: "DESIGN_PORT_UNCONFIGURED", status: 503 }); }
  async GetSellableBatchesAsync(ids, signal) { throw Object.assign(new Error("ICartRepository.GetSellableBatchesAsync: implementation or external port required"), { code: "DESIGN_PORT_UNCONFIGURED", status: 503 }); }
  async SaveAsync(cart, signal) { throw Object.assign(new Error("ICartRepository.SaveAsync: implementation or external port required"), { code: "DESIGN_PORT_UNCONFIGURED", status: 503 }); }
}
