/**
 * Design revision 2026-11-02: StateMachineResult
 * Ownership: FreshFood-API.DTOs
 * + Applied: boolean
 * + Duplicate: boolean
 * + TransitionIds: ReadonlyArray<string>
 * + State: OrderStateSnapshot
 */
export class StateMachineResult { constructor(values={}) { this.Applied=values.Applied;this.Duplicate=values.Duplicate;this.TransitionIds=values.TransitionIds;this.State=values.State;this.Actions=values.Actions; } }
