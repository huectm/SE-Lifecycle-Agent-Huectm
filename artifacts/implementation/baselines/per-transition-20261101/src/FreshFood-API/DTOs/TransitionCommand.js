/**
 * Approved design classifier: TransitionCommand
 * Ownership: FreshFood-API.DTOs
 * + TransitionId: string
 * + AggregateId: EntityId
 * + EventId: string
 * + ExpectedVersion: string?
 * + Reason: string?
 */
/** TransitionCommand — FreshFood-API.DTOs; approved design source: detailed-class-model.json. */
export class TransitionCommand {
  constructor(values = {}) {
    this.TransitionId = values.TransitionId;
    this.AggregateId = values.AggregateId;
    this.EventId = values.EventId;
    this.ExpectedVersion = values.ExpectedVersion;
    this.Reason = values.Reason;
  }
}
