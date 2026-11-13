/**
 * Design revision 2026-11-02: TransitionSnapshot
 * Ownership: FreshFood-API.DTOs
 * + WorkflowNode: string {transient UML position}
 * + AggregateId: EntityId
 * + CheckoutReference: string?
 * + CustomerId: EntityId {server resolved}
 * + AddressId: EntityId?
 * + PaymentMethod: PaymentMethod?
 * + PlannedLines: ReadonlyArray<CheckoutLineDto>
 * + FulfillmentState: string
 * + PaymentState: string
 * + RefundState: string?
 * + ActorId: string {trusted server value}
 * + GuardFacts: GuardFactsDto {trusted server value}
 */
/** TransitionSnapshot — FreshFood-API.DTOs; approved design source: detailed-class-model.json. */
export class TransitionSnapshot {
  constructor(values = {}) {
    this.WorkflowNode = values.WorkflowNode;
    this.AggregateId = values.AggregateId;
    this.CheckoutReference = values.CheckoutReference;
    this.CustomerId = values.CustomerId;
    this.AddressId = values.AddressId;
    this.PaymentMethod = values.PaymentMethod;
    this.PlannedLines = values.PlannedLines;
    this.FulfillmentState = values.FulfillmentState;
    this.PaymentState = values.PaymentState;
    this.RefundState = values.RefundState;
    this.ActorId = values.ActorId;
    this.GuardFacts = values.GuardFacts;
  }
}
