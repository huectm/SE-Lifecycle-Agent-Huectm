/**
 * Approved design classifier: CancelConfirmedOrderTransition
 * Ownership: FreshFood-API.Services.Implements
 * + Id: string = T09
 * + Source: string = confirmed
 * + Target: string = cancelled
 * - repository: IOrderLifecycleRepository
 * + CancelConfirmedOrderTransition(orderLifecycleRepository: IOrderLifecycleRepository)
 * + CanExecute(snapshot: TransitionSnapshot, command: TransitionCommand): boolean
 * + ExecuteAsync(snapshot: TransitionSnapshot, command: TransitionCommand, signal: AbortSignal): Promise<TransitionResult>
 */
import { TransitionHandler } from './TransitionHandler.js';
export class CancelConfirmedOrderTransition extends TransitionHandler {
  constructor(...dependencies) { super("T09", dependencies); }
}
