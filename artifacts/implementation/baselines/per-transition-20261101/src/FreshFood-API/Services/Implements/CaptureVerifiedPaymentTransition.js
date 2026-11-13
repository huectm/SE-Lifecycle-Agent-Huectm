/**
 * Approved design classifier: CaptureVerifiedPaymentTransition
 * Ownership: FreshFood-API.Services.Implements
 * + Id: string = P02
 * + Source: string = unpaid
 * + Target: string = paid
 * - repository: IOrderLifecycleRepository
 * + CaptureVerifiedPaymentTransition(orderLifecycleRepository: IOrderLifecycleRepository)
 * + CanExecute(snapshot: TransitionSnapshot, command: TransitionCommand): boolean
 * + ExecuteAsync(snapshot: TransitionSnapshot, command: TransitionCommand, signal: AbortSignal): Promise<TransitionResult>
 */
import { TransitionHandler } from './TransitionHandler.js';
export class CaptureVerifiedPaymentTransition extends TransitionHandler {
  constructor(...dependencies) { super("P02", dependencies); }
}
