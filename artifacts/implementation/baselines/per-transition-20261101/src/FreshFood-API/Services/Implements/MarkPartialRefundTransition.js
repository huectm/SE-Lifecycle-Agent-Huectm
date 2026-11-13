/**
 * Approved design classifier: MarkPartialRefundTransition
 * Ownership: FreshFood-API.Services.Implements
 * + Id: string = P03
 * + Source: string = paid
 * + Target: string = partially_refunded
 * - repository: IOrderLifecycleRepository
 * + MarkPartialRefundTransition(orderLifecycleRepository: IOrderLifecycleRepository)
 * + CanExecute(snapshot: TransitionSnapshot, command: TransitionCommand): boolean
 * + ExecuteAsync(snapshot: TransitionSnapshot, command: TransitionCommand, signal: AbortSignal): Promise<TransitionResult>
 */
import { TransitionHandler } from './TransitionHandler.js';
export class MarkPartialRefundTransition extends TransitionHandler {
  constructor(...dependencies) { super("P03", dependencies); }
}
