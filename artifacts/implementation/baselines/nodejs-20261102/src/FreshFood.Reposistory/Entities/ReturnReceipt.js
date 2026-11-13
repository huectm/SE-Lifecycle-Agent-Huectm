/**
 * Design revision 2026-11-02: ReturnReceipt
 * Ownership: FreshFood.Reposistory.Entities
 * + ReturnReceiptId: EntityId {private set}
 * + OrderId: EntityId {private set}
 * + ReceiptStatus: string {private set}
 * + CreatedByStaffId: number {private set}
 * + CreatedAt: Date {private set}
 * + ConfirmedByStaffId: number {private set}
 * + ConfirmedAt: Date {private set}
 * + Items: ReadonlyArray<ReturnReceiptItem> {read only; materialized navigation}
 */
import { initializeEntity, patchEntity } from './EntityState.js';
export class ReturnReceipt {
  constructor(values={}){initializeEntity(this,values,["ReturnReceiptId", "OrderId", "ReceiptStatus", "CreatedByStaffId", "CreatedAt", "ConfirmedByStaffId", "ConfirmedAt", "Items"]);}
}
