/**
 * Approved design classifier: CancelPendingUnpaidTransition
 * Ownership: FreshFood-API.Services.Implements
 * + Id: string = T08u
 * + Source: string = pending_unpaid
 * + Target: string = cancelled
 * - repository: IOrderLifecycleRepository
 * + CancelPendingUnpaidTransition(orderLifecycleRepository: IOrderLifecycleRepository)
 * + CanExecute(snapshot: TransitionSnapshot, command: TransitionCommand): boolean
 * + ExecuteAsync(snapshot: TransitionSnapshot, command: TransitionCommand, signal: AbortSignal): Promise<TransitionResult>
 */
import { TransitionHandler } from './TransitionHandler.js';
export class CancelPendingUnpaidTransition extends TransitionHandler {
  constructor(...dependencies) { super("T08u", dependencies); }
}
