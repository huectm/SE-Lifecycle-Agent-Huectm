/**
 * Design revision 2026-11-02: Product
 * Ownership: FreshFood.Reposistory.Entities
 * + ProductId: EntityId {private set}
 * + CategoryId: number {private set}
 * + Sku: string {private set}
 * + ProductName: string {private set}
 * + UnitOfMeasure: string {private set}
 * + Description: string {private set}
 * + ImageUrl: string {private set}
 * + IsActive: boolean {private set}
 * + CreatedAt: Date {private set}
 * + Batches: ReadonlyArray<BatchInventory> {read only; materialized navigation}
 */
import { initializeEntity, patchEntity } from './EntityState.js';
export class Product {
  constructor(values={}){initializeEntity(this,values,["ProductId", "CategoryId", "Sku", "ProductName", "UnitOfMeasure", "Description", "ImageUrl", "IsActive", "CreatedAt", "Batches"]);}
}
