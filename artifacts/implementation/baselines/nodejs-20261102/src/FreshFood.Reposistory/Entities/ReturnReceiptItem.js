/**
 * Design revision 2026-11-02: ReturnReceiptItem
 * Ownership: FreshFood.Reposistory.Entities
 * + ReturnReceiptItemId: EntityId {private set}
 * + ReturnReceiptId: EntityId {private set}
 * + OrderId: EntityId {private set}
 * + OrderDetailId: EntityId {private set}
 * + QuantityReceived: number {private set}
 * + Inspections: ReadonlyArray<ReturnInspection> {read only; materialized navigation}
 */
import { initializeEntity, patchEntity } from './EntityState.js';
export class ReturnReceiptItem {
  constructor(values={}){initializeEntity(this,values,["ReturnReceiptItemId", "ReturnReceiptId", "OrderId", "OrderDetailId", "QuantityReceived", "Inspections"]);}
}
