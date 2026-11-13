/**
 * Design revision 2026-11-02: DeliveryFailure
 * Ownership: FreshFood.Reposistory.Entities
 * + FailureId: EntityId {private set}
 * + OrderId: EntityId {private set}
 * + FailureCause: string {private set}
 * + Reason: string {private set}
 * + ReportedByStaffId: number {private set}
 * + ReportedAt: Date {private set}
 * + CauseConfirmedByStaffId: number {private set}
 * + CauseConfirmedAt: Date {private set}
 * + CauseEvidence: string {private set}
 */
import { initializeEntity, patchEntity } from './EntityState.js';
export class DeliveryFailure {
  constructor(values={}){initializeEntity(this,values,["FailureId", "OrderId", "FailureCause", "Reason", "ReportedByStaffId", "ReportedAt", "CauseConfirmedByStaffId", "CauseConfirmedAt", "CauseEvidence"]);}
}
