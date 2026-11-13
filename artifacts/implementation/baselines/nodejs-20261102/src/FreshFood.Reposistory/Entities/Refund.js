/**
 * Design revision 2026-11-02: Refund
 * Ownership: FreshFood.Reposistory.Entities
 * + RefundId: EntityId {private set}
 * + OrderId: EntityId {private set}
 * + ReturnReceiptId: EntityId {private set}
 * + GoodsAmount: VndAmount {private set}
 * + ShippingAmount: VndAmount {private set}
 * + RefundStatus: string {private set}
 * + IdempotencyKey: string {private set}
 * + RequestedAt: Date {private set}
 * + SettledAt: Date {private set}
 * + ProviderRefundReference: string {private set}
 */
import { initializeEntity, patchEntity } from './EntityState.js';
export class Refund {
  constructor(values={}){initializeEntity(this,values,["RefundId", "OrderId", "ReturnReceiptId", "GoodsAmount", "ShippingAmount", "RefundStatus", "IdempotencyKey", "RequestedAt", "SettledAt", "ProviderRefundReference"]);}
}
