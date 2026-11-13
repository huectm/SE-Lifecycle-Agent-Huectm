/**
 * Design revision 2026-11-02: IOrderLifecycleRepository
 * Ownership: FreshFood.Reposistory.Repository
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
/** IOrderLifecycleRepository — FreshFood.Reposistory.Repository; approved design source: detailed-class-model.json. */
export class IOrderLifecycleRepository {
  async LockOrderAsync(orderId, signal) { throw Object.assign(new Error("IOrderLifecycleRepository.LockOrderAsync: implementation or external port required"), { code: "DESIGN_PORT_UNCONFIGURED", status: 503 }); }
  async LoadLifecycleAsync(orderId, signal) { throw Object.assign(new Error("IOrderLifecycleRepository.LoadLifecycleAsync: implementation or external port required"), { code: "DESIGN_PORT_UNCONFIGURED", status: 503 }); }
  async SaveAsync(order, signal) { throw Object.assign(new Error("IOrderLifecycleRepository.SaveAsync: implementation or external port required"), { code: "DESIGN_PORT_UNCONFIGURED", status: 503 }); }
  async RecordEventOnceAsync(aggregateId, eventId, transitionId, signal) { throw Object.assign(new Error("IOrderLifecycleRepository.RecordEventOnceAsync: implementation or external port required"), { code: "DESIGN_PORT_UNCONFIGURED", status: 503 }); }
  async SaveOrderLinesAsync(order, lines, signal) { throw Object.assign(new Error("IOrderLifecycleRepository.SaveOrderLinesAsync: implementation or external port required"), { code: "DESIGN_PORT_UNCONFIGURED", status: 503 }); }
  async SavePaymentOnceAsync(payment, signal) { throw Object.assign(new Error("IOrderLifecycleRepository.SavePaymentOnceAsync: implementation or external port required"), { code: "DESIGN_PORT_UNCONFIGURED", status: 503 }); }
  async SaveFailureAsync(failure, signal) { throw Object.assign(new Error("IOrderLifecycleRepository.SaveFailureAsync: implementation or external port required"), { code: "DESIGN_PORT_UNCONFIGURED", status: 503 }); }
  async SaveReceiptAsync(receipt, items, signal) { throw Object.assign(new Error("IOrderLifecycleRepository.SaveReceiptAsync: implementation or external port required"), { code: "DESIGN_PORT_UNCONFIGURED", status: 503 }); }
  async SaveRefundOnceAsync(refund, signal) { throw Object.assign(new Error("IOrderLifecycleRepository.SaveRefundOnceAsync: implementation or external port required"), { code: "DESIGN_PORT_UNCONFIGURED", status: 503 }); }
  async SaveShippingSettlementAsync(settlement, signal) { throw Object.assign(new Error("IOrderLifecycleRepository.SaveShippingSettlementAsync: implementation or external port required"), { code: "DESIGN_PORT_UNCONFIGURED", status: 503 }); }
  async LockReservedBatchesAsync(orderId, signal) { throw Object.assign(new Error("IOrderLifecycleRepository.LockReservedBatchesAsync: implementation or external port required"), { code: "DESIGN_PORT_UNCONFIGURED", status: 503 }); }
  async SaveBatchesAsync(batches, signal) { throw Object.assign(new Error("IOrderLifecycleRepository.SaveBatchesAsync: implementation or external port required"), { code: "DESIGN_PORT_UNCONFIGURED", status: 503 }); }
  async AppendAuditAsync(audit, signal) { throw Object.assign(new Error("IOrderLifecycleRepository.AppendAuditAsync: implementation or external port required"), { code: "DESIGN_PORT_UNCONFIGURED", status: 503 }); }
}
