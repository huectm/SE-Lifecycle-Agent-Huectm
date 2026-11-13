/**
 * Approved design classifier: CancelPendingPaidTransition
 * Ownership: FreshFood-API.Services.Implements
 * + Id: string = T08p
 * + Source: string = pending_paid
 * + Target: string = cancelled
 * - repository: IOrderLifecycleRepository
 * + CancelPendingPaidTransition(orderLifecycleRepository: IOrderLifecycleRepository)
 * + CanExecute(snapshot: TransitionSnapshot, command: TransitionCommand): boolean
 * + ExecuteAsync(snapshot: TransitionSnapshot, command: TransitionCommand, signal: AbortSignal): Promise<TransitionResult>
 */
import { TransitionHandler } from './TransitionHandler.js';
export class CancelPendingPaidTransition extends TransitionHandler {
  constructor(...dependencies) { super("T08p", dependencies); }
}
