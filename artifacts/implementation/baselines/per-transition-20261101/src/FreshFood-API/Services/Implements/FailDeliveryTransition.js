/**
 * Approved design classifier: FailDeliveryTransition
 * Ownership: FreshFood-API.Services.Implements
 * + Id: string = T06
 * + Source: string = shipping
 * + Target: string = delivery_failed
 * - repository: IOrderLifecycleRepository
 * + FailDeliveryTransition(orderLifecycleRepository: IOrderLifecycleRepository)
 * + CanExecute(snapshot: TransitionSnapshot, command: TransitionCommand): boolean
 * + ExecuteAsync(snapshot: TransitionSnapshot, command: TransitionCommand, signal: AbortSignal): Promise<TransitionResult>
 */
import { TransitionHandler } from './TransitionHandler.js';
export class FailDeliveryTransition extends TransitionHandler {
  constructor(...dependencies) { super("T06", dependencies); }
}
