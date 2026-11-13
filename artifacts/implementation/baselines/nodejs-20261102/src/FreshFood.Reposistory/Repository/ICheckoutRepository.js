/**
 * Design revision 2026-11-02: ICheckoutRepository
 * Ownership: FreshFood.Reposistory.Repository
 * + GetCheckoutCartAsync(customerId: EntityId, signal: AbortSignal): Promise<Cart>
 * + GetOwnedAddressAsync(customerId: EntityId, addressId: EntityId, signal: AbortSignal): Promise<CustomerAddress>
 * + LockFefoBatchesAsync(productIds: ReadonlyArray<EntityId>, signal: AbortSignal): Promise<ReadonlyArray<BatchInventory>>
 * + SaveOrderAsync(order: Order, signal: AbortSignal): Promise<void>
 * + SavePaymentOnceAsync(payment: OrderPayment, signal: AbortSignal): Promise<boolean>
 * + ClearCartAsync(cartId: EntityId, signal: AbortSignal): Promise<void>
 * + ClaimCheckoutAsync(customerId: EntityId, reference: string, key: string, requestHash: string, signal: AbortSignal): Promise<object>
 * + CompleteCheckoutAsync(customerId: EntityId, reference: string, key: string, response: object, signal: AbortSignal): Promise<void>
 */
/** ICheckoutRepository — FreshFood.Reposistory.Repository; approved design source: detailed-class-model.json. */
export class ICheckoutRepository {
  async GetCheckoutCartAsync(customerId, signal) { throw Object.assign(new Error("ICheckoutRepository.GetCheckoutCartAsync: implementation or external port required"), { code: "DESIGN_PORT_UNCONFIGURED", status: 503 }); }
  async GetOwnedAddressAsync(customerId, addressId, signal) { throw Object.assign(new Error("ICheckoutRepository.GetOwnedAddressAsync: implementation or external port required"), { code: "DESIGN_PORT_UNCONFIGURED", status: 503 }); }
  async LockFefoBatchesAsync(productIds, signal) { throw Object.assign(new Error("ICheckoutRepository.LockFefoBatchesAsync: implementation or external port required"), { code: "DESIGN_PORT_UNCONFIGURED", status: 503 }); }
  async SaveOrderAsync(order, signal) { throw Object.assign(new Error("ICheckoutRepository.SaveOrderAsync: implementation or external port required"), { code: "DESIGN_PORT_UNCONFIGURED", status: 503 }); }
  async SavePaymentOnceAsync(payment, signal) { throw Object.assign(new Error("ICheckoutRepository.SavePaymentOnceAsync: implementation or external port required"), { code: "DESIGN_PORT_UNCONFIGURED", status: 503 }); }
  async ClearCartAsync(cartId, signal) { throw Object.assign(new Error("ICheckoutRepository.ClearCartAsync: implementation or external port required"), { code: "DESIGN_PORT_UNCONFIGURED", status: 503 }); }
  async ClaimCheckoutAsync(customerId, reference, key, requestHash, signal) { throw new Error('Abstract storage amendment contract'); }
  async CompleteCheckoutAsync(customerId, reference, key, response, signal) { throw new Error('Abstract storage amendment contract'); }
}
