/**
 * Approved design classifier: MarkFullRefundTransition
 * Ownership: FreshFood-API.Services.Implements
 * + Id: string = P04
 * + Source: string = paid
 * + Target: string = refunded
 * - repository: IOrderLifecycleRepository
 * + MarkFullRefundTransition(orderLifecycleRepository: IOrderLifecycleRepository)
 * + CanExecute(snapshot: TransitionSnapshot, command: TransitionCommand): boolean
 * + ExecuteAsync(snapshot: TransitionSnapshot, command: TransitionCommand, signal: AbortSignal): Promise<TransitionResult>
 */
import { TransitionHandler } from './TransitionHandler.js';
export class MarkFullRefundTransition extends TransitionHandler {
  constructor(...dependencies) { super("P04", dependencies); }
}
