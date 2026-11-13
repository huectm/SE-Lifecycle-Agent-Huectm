/**
 * Design revision 2026-11-02: OrderStateMachine
 * Ownership: FreshFood-API.Services.Implements
 * - repository: IOrderLifecycleRepository
 * - transitionTable: ReadonlyArray<object> {private; read only}
 * - snapshot: TransitionSnapshot? {server trusted; request scoped}
 * + OrderStateMachine(repository: IOrderLifecycleRepository)
 * + processEvent(snapshot: TransitionSnapshot, event: StateMachineEvent, signal: AbortSignal): Promise<StateMachineResult>
 * + currentState(): OrderStateSnapshot?
 */
import {transitionContext} from './transitionRuntime.js';
import {requireValue,ApiError} from './shared.js';
// The table is module-private and is never accepted from an API request.
const TABLE = [
  {
    "Id": "I00",
    "Region": "fulfillment",
    "Source": "initial",
    "Events": [
      "acceptOrder"
    ],
    "Guard": "plannedStock",
    "Action": "accept",
    "Target": "payment_choice",
    "FollowUps": [
      {
        "Event": "__completion",
        "Region": "fulfillment"
      }
    ],
    "Specification": "acceptOrder / reserve stock atomically",
    "Basis": "FR-ORD-03; BR-ORD-01"
  },
  {
    "Id": "T01u",
    "Region": "fulfillment",
    "Source": "payment_choice",
    "Events": [
      "__completion"
    ],
    "Guard": "unpaid",
    "Action": "enterInitial",
    "Target": "pending_unpaid",
    "FollowUps": [
      {
        "Event": "createOrder",
        "Region": "payment"
      }
    ],
    "Specification": "[not paid at checkout]",
    "Basis": "Stakeholder: independent initial unpaid state"
  },
  {
    "Id": "T01p",
    "Region": "fulfillment",
    "Source": "payment_choice",
    "Events": [
      "__completion"
    ],
    "Guard": "paid",
    "Action": "enterInitial",
    "Target": "pending_paid",
    "FollowUps": [
      {
        "Event": "createOrder",
        "Region": "payment"
      },
      {
        "Event": "verifiedSePayNotification",
        "Region": "payment"
      }
    ],
    "Specification": "[verified paid at checkout]",
    "Basis": "Stakeholder: independent initial paid state"
  },
  {
    "Id": "T02u",
    "Region": "fulfillment",
    "Source": "pending_unpaid",
    "Events": [
      "approveOrder"
    ],
    "Guard": "deferred",
    "Action": "deferred",
    "Target": "confirmed",
    "FollowUps": [],
    "Specification": "approveOrder\n[not first order OR phone confirmed]",
    "Basis": "BR-FUL-01; FR-FUL-02"
  },
  {
    "Id": "T02p",
    "Region": "fulfillment",
    "Source": "pending_paid",
    "Events": [
      "approveOrder"
    ],
    "Guard": "deferred",
    "Action": "deferred",
    "Target": "confirmed",
    "FollowUps": [],
    "Specification": "approveOrder\n[staff approval]",
    "Basis": "FR-FUL-02; no mandatory call for paid first order"
  },
  {
    "Id": "T03",
    "Region": "fulfillment",
    "Source": "confirmed",
    "Events": [
      "startPacking"
    ],
    "Guard": "deferred",
    "Action": "deferred",
    "Target": "packing",
    "FollowUps": [],
    "Specification": "startPacking",
    "Basis": "UC-C07"
  },
  {
    "Id": "T04",
    "Region": "fulfillment",
    "Source": "packing",
    "Events": [
      "dispatchOrder"
    ],
    "Guard": "deferred",
    "Action": "deferred",
    "Target": "shipping",
    "FollowUps": [],
    "Specification": "dispatchOrder\n[documents and assigned agent]",
    "Basis": "BR-FUL-02; FR-DEL-01"
  },
  {
    "Id": "T05",
    "Region": "fulfillment",
    "Source": "shipping",
    "Events": [
      "deliverySuccess"
    ],
    "Guard": "deferred",
    "Action": "deferred",
    "Target": "delivered",
    "FollowUps": [
      {
        "Event": "__completion",
        "Region": "fulfillment"
      }
    ],
    "Specification": "deliverySuccess",
    "Basis": "FR-DEL-02"
  },
  {
    "Id": "T06",
    "Region": "fulfillment",
    "Source": "shipping",
    "Events": [
      "deliveryFailure"
    ],
    "Guard": "deferred",
    "Action": "deferred",
    "Target": "delivery_failed",
    "FollowUps": [],
    "Specification": "deliveryFailure\n[reason recorded]",
    "Basis": "FR-DEL-03"
  },
  {
    "Id": "T07",
    "Region": "fulfillment",
    "Source": "delivery_failed",
    "Events": [
      "confirmReturnReceipt"
    ],
    "Guard": "deferred",
    "Action": "deferred",
    "Target": "returned",
    "FollowUps": [
      {
        "Event": "__completion",
        "Region": "fulfillment"
      }
    ],
    "Specification": "confirmReturnReceipt\n[all goods received]",
    "Basis": "FR-DEL-04"
  },
  {
    "Id": "T08u",
    "Region": "fulfillment",
    "Source": "pending_unpaid",
    "Events": [
      "cancelOrder"
    ],
    "Guard": "ownedCustomer",
    "Action": "cancel",
    "Target": "cancelled",
    "FollowUps": [
      {
        "Event": "__completion",
        "Region": "fulfillment"
      }
    ],
    "Specification": "cancelOrder\n[customer OR staff cancels\nunconfirmed first unpaid order]",
    "Basis": "UC-C07; BR-FUL-01"
  },
  {
    "Id": "T08p",
    "Region": "fulfillment",
    "Source": "pending_paid",
    "Events": [
      "cancelOrder"
    ],
    "Guard": "ownedCustomer",
    "Action": "cancel",
    "Target": "cancelled",
    "FollowUps": [
      {
        "Event": "__completion",
        "Region": "fulfillment"
      }
    ],
    "Specification": "cancelOrder [customer confirms]",
    "Basis": "UC-C07; paid cancellation refund policy TBD"
  },
  {
    "Id": "T09",
    "Region": "fulfillment",
    "Source": "confirmed",
    "Events": [
      "cancelOrder"
    ],
    "Guard": "ownedCustomer",
    "Action": "cancel",
    "Target": "cancelled",
    "FollowUps": [
      {
        "Event": "__completion",
        "Region": "fulfillment"
      }
    ],
    "Specification": "cancelOrder [customer confirms]",
    "Basis": "UC-C07"
  },
  {
    "Id": "F_delivered",
    "Region": "fulfillment",
    "Source": "delivered",
    "Events": [
      "__completion"
    ],
    "Guard": "always",
    "Action": "completeFulfillment",
    "Target": "final_delivered",
    "FollowUps": [],
    "Specification": "",
    "Basis": "Stakeholder request: explicit UML final node for fulfillment completion"
  },
  {
    "Id": "F_returned",
    "Region": "fulfillment",
    "Source": "returned",
    "Events": [
      "__completion"
    ],
    "Guard": "always",
    "Action": "completeFulfillment",
    "Target": "final_returned",
    "FollowUps": [],
    "Specification": "",
    "Basis": "Stakeholder request: explicit UML final node for fulfillment completion"
  },
  {
    "Id": "F_cancelled",
    "Region": "fulfillment",
    "Source": "cancelled",
    "Events": [
      "__completion"
    ],
    "Guard": "always",
    "Action": "completeFulfillment",
    "Target": "final_cancelled",
    "FollowUps": [],
    "Specification": "",
    "Basis": "Stakeholder request: explicit UML final node for fulfillment completion"
  },
  {
    "Id": "R01",
    "Region": "refund",
    "Source": "refund_initial",
    "Events": [
      "observeRefundCandidate"
    ],
    "Guard": "deferred",
    "Action": "deferred",
    "Target": "awaiting",
    "FollowUps": [],
    "Specification": "observe refund candidate",
    "Basis": "Stakeholder automatic-refund policy; proposed workflow milestone"
  },
  {
    "Id": "R02",
    "Region": "refund",
    "Source": "awaiting",
    "Events": [
      "receiptAndCauseConfirmed"
    ],
    "Guard": "deferred",
    "Action": "deferred",
    "Target": "processing",
    "FollowUps": [],
    "Specification": "receiptAndCauseConfirmed\n[paid goods AND complete return\nAND cause confirmed; no duplicate]\n/ refund original allocations by policy",
    "Basis": "Stakeholder confirmed eligibility and amount 2026-10-29; proposed duplicate-safety control"
  },
  {
    "Id": "R03",
    "Region": "refund",
    "Source": "processing",
    "Events": [
      "refundSettlementConfirmed"
    ],
    "Guard": "deferred",
    "Action": "deferred",
    "Target": "completed",
    "FollowUps": [],
    "Specification": "refundSettlementConfirmed\n/ record actual completed refund",
    "Basis": "Derived settlement integrity; provider integration TBD"
  },
  {
    "Id": "R04",
    "Region": "refund",
    "Source": "processing",
    "Events": [
      "refundRejected",
      "settlementUncertain"
    ],
    "Guard": "deferred",
    "Action": "deferred",
    "Target": "unresolved",
    "FollowUps": [],
    "Specification": "refundRejected OR\nsettlementUncertain\n/ do not mark refund completed",
    "Basis": "Exception representation proposed; retry/reconciliation policy TBD"
  },
  {
    "Id": "P01",
    "Region": "payment",
    "Source": "pay_initial",
    "Events": [
      "createOrder"
    ],
    "Guard": "initialPayment",
    "Action": "initializePayment",
    "Target": "unpaid",
    "FollowUps": [],
    "Specification": "createOrder",
    "Basis": "UC-C06 COD/VietQR initial payment state"
  },
  {
    "Id": "P02",
    "Region": "payment",
    "Source": "unpaid",
    "Events": [
      "verifiedSePayNotification"
    ],
    "Guard": "deferred",
    "Action": "deferred",
    "Target": "paid",
    "FollowUps": [],
    "Specification": "verifiedSePayNotification\n[order matches AND amount >= total]\n/ record captured payment",
    "Basis": "BR-ORD-03; FR-PAY-02; UC-C06 A6.1"
  },
  {
    "Id": "P03",
    "Region": "payment",
    "Source": "paid",
    "Events": [
      "refundSettlementConfirmed"
    ],
    "Guard": "deferred",
    "Action": "deferred",
    "Target": "partially_refunded",
    "FollowUps": [],
    "Specification": "refundSettlementConfirmed\n[0 < cumulative refund < captured]\n/ record retained fee and goods refund",
    "Basis": "Confirmed goods-only refund with retained delivery fee; proposed financial enum"
  },
  {
    "Id": "P04",
    "Region": "payment",
    "Source": "paid",
    "Events": [
      "refundSettlementConfirmed"
    ],
    "Guard": "deferred",
    "Action": "deferred",
    "Target": "refunded",
    "FollowUps": [],
    "Specification": "refundSettlementConfirmed\n[cumulative refund = captured]\n/ record full refunded amount",
    "Basis": "BR-FUL-05; confirmed product-fault full refund"
  }
];
for(const row of TABLE){Object.freeze(row.Events);Object.freeze(row.FollowUps);Object.freeze(row);}Object.freeze(TABLE);
const domainState={pending_unpaid:'PendingUnpaid',pending_paid:'PendingPaid',confirmed:'Confirmed',packing:'Packing',shipping:'Shipping',delivered:'Delivered',cancelled:'Cancelled',delivery_failed:'DeliveryFailed',returned:'Returned'};
const canonical=value=>value?.replace(/([a-z])([A-Z])/g,'$1_$2').replaceAll(' ','_').toLowerCase();
export class OrderStateMachine {
  #repository;#snapshot;#transitionTable=TABLE;
  constructor(repository){this.#repository=repository;requireValue(new Set(TABLE.map(r=>r.Id)).size===TABLE.length,'DUPLICATE_TRANSITION_ROW');}
  currentState(){
    if(!this.#snapshot)return null;const context=transitionContext(this.#snapshot),order=context.order;
    return {FulfillmentState:order?.OrderStatus??this.#snapshot.FulfillmentState??null,PaymentState:order?.PaymentStatus??this.#snapshot.PaymentState??null,RefundState:context.refund?.RefundStatus??this.#snapshot.RefundState??null,WorkflowNode:context.stage??this.#snapshot.WorkflowNode??null,FulfillmentCompleted:context.fulfillmentFinal===true||['Delivered','Cancelled','Returned'].includes(order?.OrderStatus)};
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
      plannedStock:()=>{if(!context.lines?.length||snapshot.ActorId!==snapshot.CustomerId)return false;const quantities=new Map();for(const line of context.lines){if(!Number.isSafeInteger(line.Quantity)||line.Quantity<=0)return false;quantities.set(line.BatchId,(quantities.get(line.BatchId)??0)+line.Quantity);}return [...quantities].every(([id,q])=>{const b=context.batches?.find(b=>b.BatchId===id);return b&&q<=b.CurrentStock-b.ReservedStock;});}};
    return guards[name]?.()??false;
  }
  async #action(rule,snapshot,context,event,signal){
    const actions={
      accept:async()=>{context.stage=rule.Target;},
      enterInitial:async()=>{context.order.OrderStatus=domainState[rule.Target];context.stage=rule.Target;},
      initializePayment:async()=>{context.order.PaymentStatus='Unpaid';context.paymentInitialized=true;},
      completeFulfillment:async()=>{context.fulfillmentFinal=true;context.stage=rule.Target;},
      cancel:async()=>{
        requireValue(typeof event.Reason==='string'&&event.Reason.trim().length>0,'CANCELLATION_REASON_REQUIRED');const order=context.order;const batches=await this.#repository.LockReservedBatchesAsync(order.OrderId,signal);
        for(const line of order.Details){const batch=batches.find(b=>b.BatchId===line.BatchId);requireValue(batch&&batch.ReservedStock>=line.Quantity,'RESERVATION_INCONSISTENT',409);if(typeof batch.ReleaseReservation==='function')batch.ReleaseReservation(line.Quantity);else batch.ReservedStock-=line.Quantity;}
        const previousStatus=order.OrderStatus;if(typeof order.Cancel==='function')order.Cancel(previousStatus,event.Reason);else{order.OrderStatus=domainState[rule.Target];order.CancellationReason=event.Reason;}
        await this.#repository.SaveBatchesAsync(batches,signal);await this.#repository.SaveAsync(order,signal);
        await this.#repository.AppendAuditAsync({ActorCustomerId:snapshot.CustomerId,OrderId:order.OrderId,ActionType:'UPDATE',PreviousStatus:previousStatus,Reason:event.Reason},signal);
      }
    };
    const action=actions[rule.Action];if(!action)throw new ApiError('STATE_EVENT_NOT_IMPLEMENTED',503);await action();
  }
  async #process(snapshot,context,event,region,visited,applied,signal){
    signal?.throwIfAborted();const candidates=this.#transitionTable.filter(r=>(!region||r.Region===region)&&r.Source===this.#state(r.Region,snapshot,context)&&r.Events.includes(event.Event));
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
    try{await this.#process(snapshot,context,event,undefined,new Set(),applied,signal);return {Applied:applied.length>0,Duplicate:false,TransitionIds:applied,Actions:applied.map(id=>this.#transitionTable.find(row=>row.Id===id).Action),State:this.currentState()};}
    catch(error){this.#snapshot=previous;throw error;}
  }
}
