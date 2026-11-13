/**
 * Design revision 2026-11-02: OrderPayment
 * Ownership: FreshFood.Reposistory.Entities
 * + PaymentId: EntityId {private set}
 * + OrderId: EntityId {private set}
 * + PaymentChannel: string {private set}
 * + ProviderTransactionId: string {private set}
 * + GoodsAmount: VndAmount {private set}
 * + ShippingAmount: VndAmount {private set}
 * + UnallocatedAmount: VndAmount {private set}
 * + CapturedAmount: VndAmount {private set}
 * + ReceivedAt: Date {private set}
 * + RecordedByStaffId: number {private set}
 * + CollectedByDeliveryAgentId: EntityId {private set}
 */
import { initializeEntity, patchEntity } from './EntityState.js';
export class OrderPayment {
  constructor(values={}){initializeEntity(this,values,["PaymentId", "OrderId", "PaymentChannel", "ProviderTransactionId", "GoodsAmount", "ShippingAmount", "UnallocatedAmount", "CapturedAmount", "ReceivedAt", "RecordedByStaffId", "CollectedByDeliveryAgentId"]);}
}
