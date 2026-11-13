/**
 * Design revision 2026-11-02: CartItem
 * Ownership: FreshFood.Reposistory.Entities
 * + CartItemId: EntityId {private set}
 * + CartId: EntityId {private set}
 * + ProductId: EntityId {private set}
 * + Quantity: number {private set}
 * + AddedAt: Date {private set}
 * + Product: Product {read only; materialized navigation}
 */
import { initializeEntity, patchEntity } from './EntityState.js';
export class CartItem {
  constructor(values={}){initializeEntity(this,values,["CartItemId", "CartId", "ProductId", "Quantity", "AddedAt", "Product"]);}
}
