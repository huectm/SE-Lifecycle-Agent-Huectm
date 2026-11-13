/**
 * Approved design classifier: ReceiveReturnedOrderTransition
 * Ownership: FreshFood-API.Services.Implements
 * + Id: string = T07
 * + Source: string = delivery_failed
 * + Target: string = returned
 * - repository: IOrderLifecycleRepository
 * + ReceiveReturnedOrderTransition(orderLifecycleRepository: IOrderLifecycleRepository)
 * + CanExecute(snapshot: TransitionSnapshot, command: TransitionCommand): boolean
 * + ExecuteAsync(snapshot: TransitionSnapshot, command: TransitionCommand, signal: AbortSignal): Promise<TransitionResult>
 */
import { TransitionHandler } from './TransitionHandler.js';
export class ReceiveReturnedOrderTransition extends TransitionHandler {
  constructor(...dependencies) { super("T07", dependencies); }
}
