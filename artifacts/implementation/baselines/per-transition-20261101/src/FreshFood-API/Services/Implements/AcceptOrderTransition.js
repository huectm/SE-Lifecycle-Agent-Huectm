/**
 * Approved design classifier: AcceptOrderTransition
 * Ownership: FreshFood-API.Services.Implements
 * + Id: string = I00
 * + Source: string = initial
 * + Target: string = payment_choice
 * - repository: IOrderLifecycleRepository
 * - checkoutRepository: ICheckoutRepository
 * + AcceptOrderTransition(orderLifecycleRepository: IOrderLifecycleRepository, checkoutRepository: ICheckoutRepository)
 * + CanExecute(snapshot: TransitionSnapshot, command: TransitionCommand): boolean
 * + ExecuteAsync(snapshot: TransitionSnapshot, command: TransitionCommand, signal: AbortSignal): Promise<TransitionResult>
 */
import { TransitionHandler } from './TransitionHandler.js';
export class AcceptOrderTransition extends TransitionHandler {
  constructor(...dependencies) { super("I00", dependencies); }
}
