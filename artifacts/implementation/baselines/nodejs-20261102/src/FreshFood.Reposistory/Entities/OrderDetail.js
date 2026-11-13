/**
 * Design revision 2026-11-02: OrderDetail
 * Ownership: FreshFood.Reposistory.Entities
 * + OrderDetailId: EntityId {private set}
 * + OrderId: EntityId {private set}
 * + BatchId: EntityId {private set}
 * + Quantity: number {private set}
 * + UnitPrice: VndAmount {private set}
 * + DiscountAmount: VndAmount {private set}
 * + LineTotal: VndAmount {private set}
 * + Batch: BatchInventory {read only; materialized navigation}
 */
import { initializeEntity, patchEntity } from './EntityState.js';
export class OrderDetail {
  constructor(values={}){initializeEntity(this,values,["OrderDetailId", "OrderId", "BatchId", "Quantity", "UnitPrice", "DiscountAmount", "LineTotal", "Batch"]);}
}
