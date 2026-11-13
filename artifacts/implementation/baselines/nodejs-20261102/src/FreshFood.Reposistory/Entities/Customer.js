/**
 * Design revision 2026-11-02: Customer
 * Ownership: FreshFood.Reposistory.Entities
 * + CustomerId: EntityId {private set}
 * + FullName: string {private set}
 * + Phone: string {private set}
 * + Email: string {private set}
 * + AuthProvider: string {private set}
 * + ProviderUserId: string {private set}
 * + IsPhoneVerified: boolean {private set}
 * + CreatedAt: Date {private set}
 * + Addresses: ReadonlyArray<CustomerAddress> {read only; materialized navigation}
 */
import { initializeEntity, patchEntity } from './EntityState.js';
export class Customer {
  constructor(values={}){initializeEntity(this,values,["CustomerId", "FullName", "Phone", "Email", "AuthProvider", "ProviderUserId", "IsPhoneVerified", "CreatedAt", "Addresses"]);}
}
