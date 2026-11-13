/**
 * Approved design classifier: EnterPendingPaidTransition
 * Ownership: FreshFood-API.Services.Implements
 * + Id: string = T01p
 * + Source: string = payment_choice
 * + Target: string = pending_paid
 * - repository: IOrderLifecycleRepository
 * + EnterPendingPaidTransition(orderLifecycleRepository: IOrderLifecycleRepository)
 * + CanExecute(snapshot: TransitionSnapshot, command: TransitionCommand): boolean
 * + ExecuteAsync(snapshot: TransitionSnapshot, command: TransitionCommand, signal: AbortSignal): Promise<TransitionResult>
 */
import { TransitionHandler } from './TransitionHandler.js';
export class EnterPendingPaidTransition extends TransitionHandler {
  constructor(...dependencies) { super("T01p", dependencies); }
}
