/**
 * Design revision 2026-11-02: CustomerAddress
 * Ownership: FreshFood.Reposistory.Entities
 * + AddressId: EntityId {private set}
 * + CustomerId: EntityId {private set}
 * + RecipientName: string {private set}
 * + RecipientPhone: string {private set}
 * + StreetAddress: string {private set}
 * + Latitude: number {private set}
 * + Longitude: number {private set}
 * + IsDefault: boolean {private set}
 */
import { initializeEntity, patchEntity } from './EntityState.js';
export class CustomerAddress {
  constructor(values={}){initializeEntity(this,values,["AddressId", "CustomerId", "RecipientName", "RecipientPhone", "StreetAddress", "Latitude", "Longitude", "IsDefault"]);}
}
