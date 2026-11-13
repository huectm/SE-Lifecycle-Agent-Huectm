/**
 * Approved design classifier: DeliverOrderTransition
 * Ownership: FreshFood-API.Services.Implements
 * + Id: string = T05
 * + Source: string = shipping
 * + Target: string = delivered
 * - repository: IOrderLifecycleRepository
 * + DeliverOrderTransition(orderLifecycleRepository: IOrderLifecycleRepository)
 * + CanExecute(snapshot: TransitionSnapshot, command: TransitionCommand): boolean
 * + ExecuteAsync(snapshot: TransitionSnapshot, command: TransitionCommand, signal: AbortSignal): Promise<TransitionResult>
 */
import { TransitionHandler } from './TransitionHandler.js';
export class DeliverOrderTransition extends TransitionHandler {
  constructor(...dependencies) { super("T05", dependencies); }
}
