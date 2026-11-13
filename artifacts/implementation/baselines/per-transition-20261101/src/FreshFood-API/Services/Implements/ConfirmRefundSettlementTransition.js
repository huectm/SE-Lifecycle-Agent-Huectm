/**
 * Approved design classifier: ConfirmRefundSettlementTransition
 * Ownership: FreshFood-API.Services.Implements
 * + Id: string = R03
 * + Source: string = processing
 * + Target: string = completed
 * - repository: IOrderLifecycleRepository
 * + ConfirmRefundSettlementTransition(orderLifecycleRepository: IOrderLifecycleRepository)
 * + CanExecute(snapshot: TransitionSnapshot, command: TransitionCommand): boolean
 * + ExecuteAsync(snapshot: TransitionSnapshot, command: TransitionCommand, signal: AbortSignal): Promise<TransitionResult>
 */
import { TransitionHandler } from './TransitionHandler.js';
export class ConfirmRefundSettlementTransition extends TransitionHandler {
  constructor(...dependencies) { super("R03", dependencies); }
}
