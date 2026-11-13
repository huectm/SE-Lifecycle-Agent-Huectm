/**
 * Approved design classifier: TransitionExecutor
 * Ownership: FreshFood-API.Services.Implements
 * - transitions: ReadonlyMap<string, IStateTransition>
 * - unitOfWork: IUnitOfWork
 * - repository: IOrderLifecycleRepository
 * + TransitionExecutor(transitions: ReadonlyArray<IStateTransition>, unitOfWork: IUnitOfWork, repository: IOrderLifecycleRepository)
 * + ExecuteAsync(command: TransitionCommand, signal: AbortSignal): Promise<TransitionResult>
 * + ExecuteInCurrentTransactionAsync(snapshot: TransitionSnapshot, command: TransitionCommand, signal: AbortSignal): Promise<TransitionResult>
 */
import { transitionContext, trustedSnapshot } from './transitionRuntime.js';
import { requireValue } from './shared.js';
export class TransitionExecutor {
  constructor(transitions,unitOfWork,orderLifecycleRepository) {this.transitions=new Map(transitions.map(t=>[t.Id,t]));requireValue(this.transitions.size===transitions.length,'DUPLICATE_TRANSITION_ID');this.unitOfWork=unitOfWork;this.repository=orderLifecycleRepository;}
  async ExecuteAsync(command,signal) {return this.unitOfWork.ExecuteAsync(async()=>{const records=await this.repository.LoadLifecycleAsync(command.AggregateId,signal);const snapshot=trustedSnapshot(records.Snapshot,records.Context);return this.ExecuteInCurrentTransactionAsync(snapshot,command,signal);},signal);}
  async ExecuteInCurrentTransactionAsync(snapshot,command,signal) {transitionContext(snapshot);requireValue(snapshot.AggregateId===command.AggregateId,'AGGREGATE_MISMATCH',403);const handler=this.transitions.get(command.TransitionId);requireValue(handler,'UNKNOWN_TRANSITION');requireValue(handler.CanExecute(snapshot,command),'TRANSITION_GUARD_REJECTED',409);const first=await this.repository.RecordEventOnceAsync(command.AggregateId,command.EventId,command.TransitionId,signal);if(!first)return {TransitionId:command.TransitionId,Target:snapshot.FulfillmentState??snapshot.WorkflowNode,Applied:false,Duplicate:true};return handler.ExecuteAsync(snapshot,command,signal);}
}
