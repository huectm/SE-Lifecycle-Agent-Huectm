/**
 * Design revision 2026-11-02: AuditLog
 * Ownership: FreshFood.Reposistory.Entities
 * + LogId: EntityId {private set}
 * + StaffId: number? {private set}
 * + ActionType: string {private set}
 * + EntityName: string {private set}
 * + RecordIdentifier: string {private set}
 * + OldValues: string {private set}
 * + NewValues: string {private set}
 * + IpAddress: string {private set}
 * + Timestamp: Date {private set}
 * + CustomerId: EntityId? {private set}
 * + ActorType: string {derived; read only}
 */
// Authorized storage amendment: CustomerId nullable; ActorType database-derived.
import { initializeEntity, patchEntity } from './EntityState.js';
export class AuditLog {
  constructor(values={}){initializeEntity(this,values,["LogId", "StaffId", "CustomerId", "ActorType", "ActionType", "EntityName", "RecordIdentifier", "OldValues", "NewValues", "IpAddress", "Timestamp"]);}
}
