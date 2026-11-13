/**
 * Design revision 2026-11-02: StateMachineEvent
 * Ownership: FreshFood-API.DTOs
 * + Event: string
 * + AggregateId: EntityId
 * + EventId: string
 * + Reason: string?
 */
export class StateMachineEvent { constructor(values={}) { this.Event=values.Event;this.AggregateId=values.AggregateId;this.EventId=values.EventId;this.Reason=values.Reason; } }
