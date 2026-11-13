/**
 * Design revision 2026-11-02: Cart
 * Ownership: FreshFood.Reposistory.Entities
 * + CartId: EntityId {private set}
 * + CustomerId: EntityId {private set}
 * + SessionId: string {private set}
 * + CreatedAt: Date {private set}
 * + UpdatedAt: Date {private set}
 * + Items: ReadonlyArray<CartItem> {read only; materialized navigation}
 * + ChangeQuantity(productId: EntityId, quantity: number): void
 * + RemoveItem(productId: EntityId): void
 */
import { initializeEntity, patchEntity } from './EntityState.js';
export class Cart {
  constructor(values={}){initializeEntity(this,{...values,Items:values.Items??[]},["CartId", "CustomerId", "SessionId", "CreatedAt", "UpdatedAt", "Items"]);}
  ChangeQuantity(productId,quantity){if(!Number.isSafeInteger(quantity)||quantity<=0)throw new RangeError('INVALID_QUANTITY');const items=this.Items??[];const exists=items.some(i=>i.ProductId===productId);patchEntity(this,{Items:exists?items.map(i=>i.ProductId===productId?{...i,Quantity:quantity}:i):[...items,{ProductId:productId,Quantity:quantity}]});}
  RemoveItem(productId){patchEntity(this,{Items:(this.Items??[]).filter(i=>i.ProductId!==productId)});}
}
