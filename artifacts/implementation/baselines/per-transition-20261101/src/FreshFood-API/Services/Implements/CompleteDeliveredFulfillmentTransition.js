/**
 * Approved design classifier: CompleteDeliveredFulfillmentTransition
 * Ownership: FreshFood-API.Services.Implements
 * + Id: string = F_delivered
 * + Source: string = delivered
 * + Target: string = final_delivered
 * - repository: IOrderLifecycleRepository
 * + CompleteDeliveredFulfillmentTransition(orderLifecycleRepository: IOrderLifecycleRepository)
 * + CanExecute(snapshot: TransitionSnapshot, command: TransitionCommand): boolean
 * + ExecuteAsync(snapshot: TransitionSnapshot, command: TransitionCommand, signal: AbortSignal): Promise<TransitionResult>
 */
import { TransitionHandler } from './TransitionHandler.js';
export class CompleteDeliveredFulfillmentTransition extends TransitionHandler {
  constructor(...dependencies) { super("F_delivered", dependencies); }
}
