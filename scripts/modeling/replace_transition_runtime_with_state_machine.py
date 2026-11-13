from pathlib import Path
import json
m=json.loads(Path('artifacts/design/detailed/detailed-class-model.json').read_text(encoding='utf-8-sig'))
triggers={'I00':['acceptOrder'],'T01u':['__completion'],'T01p':['__completion'],'T02u':['approveOrder'],'T02p':['approveOrder'],'T03':['startPacking'],'T04':['dispatchOrder'],'T05':['deliverySuccess'],'T06':['deliveryFailure'],'T07':['confirmReturnReceipt'],'T08u':['cancelOrder'],'T08p':['cancelOrder'],'T09':['cancelOrder'],'F_delivered':['__completion'],'F_returned':['__completion'],'F_cancelled':['__completion'],'R01':['observeRefundCandidate'],'R02':['receiptAndCauseConfirmed'],'R03':['refundSettlementConfirmed'],'R04':['refundRejected','settlementUncertain'],'P01':['createOrder'],'P02':['verifiedSePayNotification'],'P03':['refundSettlementConfirmed'],'P04':['refundSettlementConfirmed']}
core={'I00':('plannedStock','accept'),'T01u':('unpaid','enterInitial'),'T01p':('paid','enterInitial'),'P01':('initialPayment','initializePayment'),'T08u':('ownedCustomer','cancel'),'T08p':('ownedCustomer','cancel'),'T09':('ownedCustomer','cancel'),'F_delivered':('always','completeFulfillment'),'F_returned':('always','completeFulfillment'),'F_cancelled':('always','completeFulfillment')}
rows=[]
for r in m['transitions']:
 tid=r['id'];region='payment' if tid.startswith('P') else 'refund' if tid.startswith('R') else 'fulfillment';guard,action=core.get(tid,('deferred','deferred'))
 follow=[]
 if tid in ['I00','T05','T07','T08u','T08p','T09']:follow=[{'Event':'__completion','Region':'fulfillment'}]
 if tid in ['T01u','T01p']:follow=[{'Event':'createOrder','Region':'payment'}]+([{'Event':'verifiedSePayNotification','Region':'payment'}] if tid=='T01p' else [])
 rows.append({'Id':tid,'Region':region,'Source':r['source'],'Events':triggers[tid],'Guard':guard,'Action':action,'Target':r['target'],'FollowUps':follow,'Specification':r['label'],'Basis':r['basis']})
D=Path('artifacts/design/detailed');(D/'order-state-transition-table.json').write_text(json.dumps(rows,indent=2),encoding='utf-8')
base=Path('src/FreshFood-API/Services/Implements')
code='''import {transitionContext} from './transitionRuntime.js';
import {requireValue,ApiError} from './shared.js';
// The table is module-private and is never accepted from an API request.
const TABLE = __TABLE__;
for(const row of TABLE){Object.freeze(row.Events);Object.freeze(row.FollowUps);Object.freeze(row);}Object.freeze(TABLE);
const domainState={pending_unpaid:'PendingUnpaid',pending_paid:'PendingPaid',confirmed:'Confirmed',packing:'Packing',shipping:'Shipping',delivered:'Delivered',cancelled:'Cancelled',delivery_failed:'DeliveryFailed',returned:'Returned'};
const canonical=value=>value?.replace(/([a-z])([A-Z])/g,'$1_$2').replaceAll(' ','_').toLowerCase();
export class OrderStateMachine {
  #repository;#snapshot;#table=TABLE;
  constructor(repository){this.#repository=repository;requireValue(new Set(TABLE.map(r=>r.Id)).size===TABLE.length,'DUPLICATE_TRANSITION_ROW');}
  currentState(){
    if(!this.#snapshot)return null;const context=transitionContext(this.#snapshot),order=context.order;
    return {FulfillmentState:order?.OrderStatus??this.#snapshot.FulfillmentState??null,PaymentState:order?.PaymentStatus??this.#snapshot.PaymentState??null,RefundState:context.refund?.RefundStatus??this.#snapshot.RefundState??null,WorkflowNode:context.stage??this.#snapshot.WorkflowNode??null,FulfillmentCompleted:context.fulfillmentFinal===true};
  }
  #state(region,snapshot,context){
    if(region==='fulfillment')return context.fulfillmentFinal?'final_'+canonical(context.order.OrderStatus):(canonical(context.order?.OrderStatus)??context.stage??snapshot.WorkflowNode??canonical(snapshot.FulfillmentState));
    if(region==='payment')return !context.paymentInitialized&&snapshot.WorkflowNode==='initial'?'pay_initial':canonical(context.order?.PaymentStatus??snapshot.PaymentState);
    return canonical(context.refund?.RefundStatus??snapshot.RefundState)??'refund_initial';
  }
  #guard(name,snapshot,context){
    const guards={always:()=>true,unpaid:()=>snapshot.GuardFacts.VerifiedPayment!==true,paid:()=>snapshot.GuardFacts.VerifiedPayment===true,
      initialPayment:()=>['PendingUnpaid','PendingPaid'].includes(context.order?.OrderStatus),
      ownedCustomer:()=>snapshot.ActorId===snapshot.CustomerId&&context.order?.CustomerId===snapshot.CustomerId,
      plannedStock:()=>{if(!context.lines?.length||snapshot.ActorId!==snapshot.CustomerId)return false;const quantities=new Map();for(const line of context.lines){if(!Number.isSafeInteger(line.Quantity)||line.Quantity<=0)return false;quantities.set(line.BatchId,(quantities.get(line.BatchId)??0)+line.Quantity);}return [...quantities].every(([id,q])=>{const b=context.batches.find(b=>b.BatchId===id);return b&&q<=b.CurrentStock-b.ReservedStock;});}};
    return guards[name]?.()??false;
  }
  async #action(rule,snapshot,context,event,signal){
    const actions={
      accept:async()=>{context.stage=rule.Target;},
      enterInitial:async()=>{context.order.OrderStatus=domainState[rule.Target];},
      initializePayment:async()=>{context.order.PaymentStatus='Unpaid';context.paymentInitialized=true;},
      completeFulfillment:async()=>{context.fulfillmentFinal=true;},
      cancel:async()=>{
        const order=context.order;const batches=await this.#repository.LockReservedBatchesAsync(order.OrderId,signal);
        for(const line of order.Details){const batch=batches.find(b=>b.BatchId===line.BatchId);requireValue(batch&&batch.ReservedStock>=line.Quantity,'RESERVATION_INCONSISTENT',409);batch.ReservedStock-=line.Quantity;}
        const previousStatus=order.OrderStatus;order.OrderStatus=domainState[rule.Target];order.CancellationReason=event.Reason;
        await this.#repository.SaveBatchesAsync(batches,signal);await this.#repository.SaveAsync(order,signal);
        await this.#repository.AppendAuditAsync({ActorCustomerId:snapshot.CustomerId,OrderId:order.OrderId,ActionType:'UPDATE',PreviousStatus:previousStatus,Reason:event.Reason},signal);
      }
    };
    const action=actions[rule.Action];if(!action)throw new ApiError('STATE_EVENT_NOT_IMPLEMENTED',503);await action();
  }
  async #process(snapshot,context,event,region,visited,applied,signal){
    signal?.throwIfAborted();const candidates=this.#table.filter(r=>(!region||r.Region===region)&&r.Source===this.#state(r.Region,snapshot,context)&&r.Events.includes(event.Event));
    if(!candidates.length)throw new ApiError('STATE_EVENT_NOT_ALLOWED',409);
    if(candidates.some(r=>r.Action==='deferred'))throw new ApiError('STATE_EVENT_NOT_IMPLEMENTED',503);
    const selected=candidates.filter(r=>this.#guard(r.Guard,snapshot,context));requireValue(selected.length>0,'STATE_GUARD_REJECTED',409);
    for(const r of selected)requireValue(selected.filter(x=>x.Region===r.Region).length===1,'AMBIGUOUS_STATE_TRANSITION',500);
    for(const rule of selected){
      const occurrence=rule.Region+':'+rule.Source+':'+event.Event;requireValue(!visited.has(occurrence),'STATE_MACHINE_COMPLETION_CYCLE',500);visited.add(occurrence);
      const first=await this.#repository.RecordEventOnceAsync(event.AggregateId,event.EventId,rule.Id,signal);
      requireValue(first,'INCONSISTENT_TRANSITION_EVIDENCE',409);
      await this.#action(rule,snapshot,context,event,signal);applied.push(rule.Id);
      for(const next of rule.FollowUps)await this.#process(snapshot,context,{...event,Event:next.Event},next.Region,visited,applied,signal);
    }
  }
  async processEvent(snapshot,event,signal){
    const context=transitionContext(snapshot);requireValue(snapshot.AggregateId===event.AggregateId,'AGGREGATE_MISMATCH',403);
    requireValue(typeof event.Event==='string'&&!event.Event.startsWith('__'),'INVALID_STATE_EVENT');
    if(this.#snapshot)requireValue(this.#snapshot.AggregateId===snapshot.AggregateId&&this.#snapshot.CustomerId===snapshot.CustomerId,'STATE_MACHINE_AGGREGATE_MISMATCH',403);
    const previous=this.#snapshot;this.#snapshot=snapshot;const applied=[];
    try{await this.#process(snapshot,context,event,undefined,new Set(),applied,signal);return {Applied:applied.length>0,Duplicate:false,TransitionIds:applied,State:this.currentState()};}
    catch(error){this.#snapshot=previous;throw error;}
  }
}
'''.replace('__TABLE__',json.dumps(rows,indent=2))
(base/'OrderStateMachine.js').write_text(code,encoding='utf-8')
Path('src/FreshFood-API/Services/IOrderStateMachine.js').write_text('''export class IOrderStateMachine {
  async processEvent(snapshot,event,signal){throw new Error('Abstract state-machine contract');}
  currentState(){throw new Error('Abstract state-machine contract');}
}
''',encoding='utf-8')
for name in ['CheckoutService','MyOrdersService']:
 p=base/(name+'.js');s=p.read_text(encoding='utf-8').replace('ITransitionExecutor','IOrderStateMachine').replace('transitionExecutor','orderStateMachine')
 if name=='CheckoutService':
  a=s.index("      for(const transitionId of ['I00'");b=s.index('\n      await this.checkoutRepository.SaveOrderAsync',a)
  s=s[:a]+"      await this.orderStateMachine.processEvent(snapshot,{Event:'acceptOrder',AggregateId:'checkout:'+customerId+':'+reference,EventId:eventId},signal);"+s[b:]
 else:s=s.replace("const transitions={PendingUnpaid:'T08u',PendingPaid:'T08p',Confirmed:'T09'};", "const cancellable=['PendingUnpaid','PendingPaid','Confirmed'];").replace("requireValue(transitions[o.OrderStatus]", "requireValue(cancellable.includes(o.OrderStatus)").replace("this.orderStateMachine.ExecuteInCurrentTransactionAsync(snapshot,{TransitionId:transitions[o.OrderStatus]", "this.orderStateMachine.processEvent(snapshot,{Event:'cancelOrder'")
 p.write_text(s,encoding='utf-8')
print('Created one table-driven OrderStateMachine for all 24 rows; services now submit events')
