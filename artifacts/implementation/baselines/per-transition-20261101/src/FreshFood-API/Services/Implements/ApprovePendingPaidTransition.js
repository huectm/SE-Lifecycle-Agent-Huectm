/**
 * Approved design classifier: ApprovePendingPaidTransition
 * Ownership: FreshFood-API.Services.Implements
 * + Id: string = T02p
 * + Source: string = pending_paid
 * + Target: string = confirmed
 * - repository: IOrderLifecycleRepository
 * + ApprovePendingPaidTransition(orderLifecycleRepository: IOrderLifecycleRepository)
 * + CanExecute(snapshot: TransitionSnapshot, command: TransitionCommand): boolean
 * + ExecuteAsync(snapshot: TransitionSnapshot, command: TransitionCommand, signal: AbortSignal): Promise<TransitionResult>
 */
import { TransitionHandler } from './TransitionHandler.js';
export class ApprovePendingPaidTransition extends TransitionHandler {
  constructor(...dependencies) { super("T02p", dependencies); }
}
