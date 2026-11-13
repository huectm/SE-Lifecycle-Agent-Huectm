/**
 * Design revision 2026-11-02: OrderReview
 * Ownership: FreshFood.Reposistory.Entities
 * + ReviewId: EntityId {private set}
 * + OrderId: EntityId {private set}
 * + CustomerId: EntityId {private set}
 * + Rating: number {private set}
 * + Comment: string {private set}
 * + CreatedAt: Date {private set}
 */
import { initializeEntity, patchEntity } from './EntityState.js';
export class OrderReview {
  constructor(values={}){initializeEntity(this,values,["ReviewId", "OrderId", "CustomerId", "Rating", "Comment", "CreatedAt"]);}
}
