/**
 * Approved design classifier: CompleteReturnedFulfillmentTransition
 * Ownership: FreshFood-API.Services.Implements
 * + Id: string = F_returned
 * + Source: string = returned
 * + Target: string = final_returned
 * - repository: IOrderLifecycleRepository
 * + CompleteReturnedFulfillmentTransition(orderLifecycleRepository: IOrderLifecycleRepository)
 * + CanExecute(snapshot: TransitionSnapshot, command: TransitionCommand): boolean
 * + ExecuteAsync(snapshot: TransitionSnapshot, command: TransitionCommand, signal: AbortSignal): Promise<TransitionResult>
 */
import { TransitionHandler } from './TransitionHandler.js';
export class CompleteReturnedFulfillmentTransition extends TransitionHandler {
  constructor(...dependencies) { super("F_returned", dependencies); }
}
