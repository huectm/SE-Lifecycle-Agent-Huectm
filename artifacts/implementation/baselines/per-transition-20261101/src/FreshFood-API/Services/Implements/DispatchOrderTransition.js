/**
 * Approved design classifier: DispatchOrderTransition
 * Ownership: FreshFood-API.Services.Implements
 * + Id: string = T04
 * + Source: string = packing
 * + Target: string = shipping
 * - repository: IOrderLifecycleRepository
 * + DispatchOrderTransition(orderLifecycleRepository: IOrderLifecycleRepository)
 * + CanExecute(snapshot: TransitionSnapshot, command: TransitionCommand): boolean
 * + ExecuteAsync(snapshot: TransitionSnapshot, command: TransitionCommand, signal: AbortSignal): Promise<TransitionResult>
 */
import { TransitionHandler } from './TransitionHandler.js';
export class DispatchOrderTransition extends TransitionHandler {
  constructor(...dependencies) { super("T04", dependencies); }
}
