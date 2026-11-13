/**
 * Design revision 2026-11-02: IOrderStateMachine
 * Ownership: FreshFood-API.Services
 * + processEvent(snapshot: TransitionSnapshot, event: StateMachineEvent, signal: AbortSignal): Promise<StateMachineResult>
 * + currentState(): OrderStateSnapshot?
 */
export class IOrderStateMachine {
  async processEvent(snapshot,event,signal){throw new Error('Abstract state-machine contract');}
  currentState(){throw new Error('Abstract state-machine contract');}
}
