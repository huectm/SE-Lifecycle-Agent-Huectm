/**
 * Approved design classifier: StartEligibleRefundTransition
 * Ownership: FreshFood-API.Services.Implements
 * + Id: string = R02
 * + Source: string = awaiting
 * + Target: string = processing
 * - repository: IOrderLifecycleRepository
 * - payout: IPayoutPort
 * + StartEligibleRefundTransition(orderLifecycleRepository: IOrderLifecycleRepository, payoutPort: IPayoutPort)
 * + CanExecute(snapshot: TransitionSnapshot, command: TransitionCommand): boolean
 * + ExecuteAsync(snapshot: TransitionSnapshot, command: TransitionCommand, signal: AbortSignal): Promise<TransitionResult>
 */
import { TransitionHandler } from './TransitionHandler.js';
export class StartEligibleRefundTransition extends TransitionHandler {
  constructor(...dependencies) { super("R02", dependencies); }
}
