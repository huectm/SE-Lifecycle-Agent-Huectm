/**
 * Design revision 2026-11-02: BatchInventory
 * Ownership: FreshFood.Reposistory.Entities
 * + BatchId: EntityId {private set}
 * + ProductId: EntityId {private set}
 * + ReceiptId: EntityId {private set}
 * + BatchNumber: string {private set}
 * + ManufactureDate: LocalDate {private set}
 * + ExpiryDate: LocalDate {private set}
 * + ImportQuantity: number {private set}
 * + CurrentStock: number {private set}
 * + ReservedStock: number {private set}
 * + ImportPrice: VndAmount {private set}
 * + RetailPrice: VndAmount {private set}
 * + DiscountRate: number {private set}
 * + SaleStatus: string {private set}
 * + Reserve(quantity: number): void
 * + ReleaseReservation(quantity: number): void
 */
import { initializeEntity, patchEntity } from './EntityState.js';
export class BatchInventory {
  constructor(values={}){initializeEntity(this,values,["BatchId", "ProductId", "ReceiptId", "BatchNumber", "ManufactureDate", "ExpiryDate", "ImportQuantity", "CurrentStock", "ReservedStock", "ImportPrice", "RetailPrice", "DiscountRate", "SaleStatus"]);}
  Reserve(quantity){if(!Number.isSafeInteger(quantity)||quantity<=0||quantity>this.CurrentStock-this.ReservedStock)throw new RangeError('INSUFFICIENT_STOCK');patchEntity(this,{ReservedStock:this.ReservedStock+quantity});}
  ReleaseReservation(quantity){if(!Number.isSafeInteger(quantity)||quantity<=0||quantity>this.ReservedStock)throw new RangeError('INVALID_RELEASE');patchEntity(this,{ReservedStock:this.ReservedStock-quantity});}
}
