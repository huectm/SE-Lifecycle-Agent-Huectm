/**
 * Approved design classifier: CompleteCancelledFulfillmentTransition
 * Ownership: FreshFood-API.Services.Implements
 * + Id: string = F_cancelled
 * + Source: string = cancelled
 * + Target: string = final_cancelled
 * - repository: IOrderLifecycleRepository
 * + CompleteCancelledFulfillmentTransition(orderLifecycleRepository: IOrderLifecycleRepository)
 * + CanExecute(snapshot: TransitionSnapshot, command: TransitionCommand): boolean
 * + ExecuteAsync(snapshot: TransitionSnapshot, command: TransitionCommand, signal: AbortSignal): Promise<TransitionResult>
 */
import { TransitionHandler } from './TransitionHandler.js';
export class CompleteCancelledFulfillmentTransition extends TransitionHandler {
  constructor(...dependencies) { super("F_cancelled", dependencies); }
}
