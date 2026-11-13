/**
 * Design revision 2026-11-02: ProductCategory
 * Ownership: FreshFood.Reposistory.Entities
 * + CategoryId: number {private set}
 * + CategoryCode: string {private set}
 * + CategoryName: string {private set}
 * + Description: string {private set}
 * + IsActive: boolean {private set}
 * + Products: ReadonlyArray<Product> {read only; materialized navigation}
 */
import { initializeEntity, patchEntity } from './EntityState.js';
export class ProductCategory {
  constructor(values={}){initializeEntity(this,values,["CategoryId", "CategoryCode", "CategoryName", "Description", "IsActive", "Products"]);}
}
