/**
 * Design revision 2026-11-02: IMyOrdersRepository
 * Ownership: FreshFood.Reposistory.Repository
 * + FindOwnedAsync(customerId: EntityId, signal: AbortSignal): Promise<ReadonlyArray<Order>>
 * + LockOwnedAsync(customerId: EntityId, orderId: EntityId, signal: AbortSignal): Promise<Order>
 * + GetCurrentBatchesAsync(productIds: ReadonlyArray<EntityId>, signal: AbortSignal): Promise<ReadonlyArray<BatchInventory>>
 * + SaveCartAsync(cart: Cart, signal: AbortSignal): Promise<void>
 * + SaveReviewOnceAsync(review: OrderReview, signal: AbortSignal): Promise<boolean>
 * + GetReturnReceiptAsync(orderId: EntityId, signal: AbortSignal): Promise<ReturnReceipt?>
 * + GetRefundAsync(orderId: EntityId, signal: AbortSignal): Promise<Refund?>
 */
/** IMyOrdersRepository — FreshFood.Reposistory.Repository; approved design source: detailed-class-model.json. */
export class IMyOrdersRepository {
  async FindOwnedAsync(customerId, signal) { throw Object.assign(new Error("IMyOrdersRepository.FindOwnedAsync: implementation or external port required"), { code: "DESIGN_PORT_UNCONFIGURED", status: 503 }); }
  async LockOwnedAsync(customerId, orderId, signal) { throw Object.assign(new Error("IMyOrdersRepository.LockOwnedAsync: implementation or external port required"), { code: "DESIGN_PORT_UNCONFIGURED", status: 503 }); }
  async GetCurrentBatchesAsync(productIds, signal) { throw Object.assign(new Error("IMyOrdersRepository.GetCurrentBatchesAsync: implementation or external port required"), { code: "DESIGN_PORT_UNCONFIGURED", status: 503 }); }
  async SaveCartAsync(cart, signal) { throw Object.assign(new Error("IMyOrdersRepository.SaveCartAsync: implementation or external port required"), { code: "DESIGN_PORT_UNCONFIGURED", status: 503 }); }
  async SaveReviewOnceAsync(review, signal) { throw Object.assign(new Error("IMyOrdersRepository.SaveReviewOnceAsync: implementation or external port required"), { code: "DESIGN_PORT_UNCONFIGURED", status: 503 }); }
  async GetReturnReceiptAsync(orderId, signal) { throw Object.assign(new Error("IMyOrdersRepository.GetReturnReceiptAsync: implementation or external port required"), { code: "DESIGN_PORT_UNCONFIGURED", status: 503 }); }
  async GetRefundAsync(orderId, signal) { throw Object.assign(new Error("IMyOrdersRepository.GetRefundAsync: implementation or external port required"), { code: "DESIGN_PORT_UNCONFIGURED", status: 503 }); }
}
