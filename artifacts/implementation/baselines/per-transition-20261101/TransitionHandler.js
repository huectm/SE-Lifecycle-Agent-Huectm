import { transitionContext } from './transitionRuntime.js';
import { requireValue, ApiError } from './shared.js';
const cancelSources={T08u:'PendingUnpaid',T08p:'PendingPaid',T09:'Confirmed'};
export class TransitionHandler {
  constructor(id,dependencies) {this.Id=id;this.dependencies=dependencies;}
  CanExecute(snapshot,command) {
    const c=transitionContext(snapshot);if(command.TransitionId!==this.Id)return false;
    if(this.Id==='I00')return c.stage==null&&c.lines?.length>0;
    if(this.Id==='T01u')return c.stage==='accepted'&&!snapshot.GuardFacts.VerifiedPayment;
    if(this.Id==='T01p')return c.stage==='accepted'&&snapshot.GuardFacts.VerifiedPayment===true;
    if(this.Id==='P01')return c.order?.OrderStatus==='PendingUnpaid'&&!snapshot.GuardFacts.VerifiedPayment;
    if(this.Id==='P02')return snapshot.GuardFacts.VerifiedPayment===true;
    return Object.hasOwn(cancelSources,this.Id)&&cancelSources[this.Id]===c.order?.OrderStatus;
  }
  async ExecuteAsync(snapshot,command,signal) {
    const c=transitionContext(snapshot);requireValue(this.CanExecute(snapshot,command),'TRANSITION_GUARD_REJECTED',409);
    if(this.Id==='I00'){c.stage='accepted';return {TransitionId:this.Id,Target:'accepted',Applied:true,Duplicate:false};}
    if(this.Id==='T01u'||this.Id==='T01p'){c.order.OrderStatus=this.Id==='T01u'?'PendingUnpaid':'PendingPaid';return {TransitionId:this.Id,Target:c.order.OrderStatus,Applied:true,Duplicate:false};}
    if(this.Id==='P01'){c.order.PaymentStatus='Unpaid';return {TransitionId:this.Id,Target:'Unpaid',Applied:true,Duplicate:false};}
    if(this.Id==='P02')throw new ApiError('PAYMENT_CORRELATION_TBD',503);
    if(cancelSources[this.Id]){
      const lifecycle=this.dependencies[0];const batches=await lifecycle.LockReservedBatchesAsync(c.order.OrderId,signal);
      for(const l of c.order.Details){const b=batches.find(b=>b.BatchId===l.BatchId);requireValue(b&&b.ReservedStock>=l.Quantity,'RESERVATION_INCONSISTENT',409);b.ReservedStock-=l.Quantity;}
      const previousStatus=c.order.OrderStatus;
      c.order.OrderStatus='Cancelled';c.order.CancellationReason=command.Reason;await lifecycle.SaveBatchesAsync(batches,signal);await lifecycle.SaveAsync(c.order,signal);await lifecycle.AppendAuditAsync({ActorCustomerId:snapshot.CustomerId,OrderId:c.order.OrderId,ActionType:'UPDATE',PreviousStatus:previousStatus,Reason:command.Reason},signal);return {TransitionId:this.Id,Target:'Cancelled',Applied:true,Duplicate:false};
    }
    throw new ApiError('STAFF_RETURN_REFUND_IMPLEMENTATION_TBD',503);
  }
}