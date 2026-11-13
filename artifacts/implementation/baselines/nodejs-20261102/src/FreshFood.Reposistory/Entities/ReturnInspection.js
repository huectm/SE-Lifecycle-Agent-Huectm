/**
 * Design revision 2026-11-02: ReturnInspection
 * Ownership: FreshFood.Reposistory.Entities
 * + InspectionId: EntityId {private set}
 * + ReturnReceiptItemId: EntityId {private set}
 * + InspectedByStaffId: number {private set}
 * + InspectedAt: Date {private set}
 * + Quantity: number {private set}
 * + Disposition: string {private set}
 * + ConditionNotes: string {private set}
 * + InventoryAppliedAt: Date {private set}
 */
import { initializeEntity, patchEntity } from './EntityState.js';
export class ReturnInspection {
  constructor(values={}){initializeEntity(this,values,["InspectionId", "ReturnReceiptItemId", "InspectedByStaffId", "InspectedAt", "Quantity", "Disposition", "ConditionNotes", "InventoryAppliedAt"]);}
}
