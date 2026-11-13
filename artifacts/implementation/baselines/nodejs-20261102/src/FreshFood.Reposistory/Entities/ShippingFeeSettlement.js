/**
 * Design revision 2026-11-02: ShippingFeeSettlement
 * Ownership: FreshFood.Reposistory.Entities
 * + ShippingSettlementId: EntityId {private set}
 * + OrderId: EntityId {private set}
 * + DeliveryAgentId: EntityId {private set}
 * + CustomerFeeDue: VndAmount {private set}
 * + CollectionPaymentId: EntityId {private set}
 * + CompensationDueAmount: VndAmount {private set}
 * + CompensationPaidAmount: VndAmount {private set}
 * + CompensatedAt: Date {private set}
 * + SettlementReference: string {private set}
 */
import { initializeEntity, patchEntity } from './EntityState.js';
export class ShippingFeeSettlement {
  constructor(values={}){initializeEntity(this,values,["ShippingSettlementId", "OrderId", "DeliveryAgentId", "CustomerFeeDue", "CollectionPaymentId", "CompensationDueAmount", "CompensationPaidAmount", "CompensatedAt", "SettlementReference"]);}
}
