raise SystemExit('Historical Node.js generator retired after the explicit ASP.NET Core C# selection. Maintain the current C# source and detailed-class-model.json; do not regenerate the former backend.')
﻿from pathlib import Path
import json
P=json.loads(Path('scratch/backend-mapping-paths.json').read_text())
def put(n,s):Path(P[n]).write_text(s.strip()+'\n',encoding='utf-8')
base=Path('src/FreshFood-API/Services/Implements')
(base/'transitionRuntime.js').write_text('''const trusted = new WeakMap();
export function trustedSnapshot(fields, context) { const snapshot=Object.freeze({...fields,GuardFacts:Object.freeze({...fields.GuardFacts})}); trusted.set(snapshot,context); return snapshot; }
export function transitionContext(snapshot) { const context=trusted.get(snapshot);if(!context)throw Object.assign(new Error('Untrusted transition snapshot'),{code:'UNTRUSTED_TRANSITION',status:403});return context; }
export async function publishAfterCommit(gateway,message,signal) { try { await gateway.PublishAsync(message,signal); } catch { console.warn('NOTIFICATION_DELIVERY_FAILED',message.EventCode); } }
''',encoding='utf-8')
put('CheckoutService','''import { randomUUID } from 'node:crypto';
import { id, owned, quantity, requireValue, amount, sellable, fefo, ApiError } from './shared.js';
import { trustedSnapshot, publishAfterCommit } from './transitionRuntime.js';
export class CheckoutService {
  constructor(checkoutRepository,currentCustomer,unitOfWork,distanceCalculator,paymentGateway,notificationGateway,transitionExecutor,pricing,deliveryFeePolicy) { Object.assign(this,{checkoutRepository,currentCustomer,unitOfWork,distanceCalculator,paymentGateway,notificationGateway,transitionExecutor,pricing,deliveryFeePolicy}); }
  async plan(request,signal) {
    const customerId=this.currentCustomer.RequireCustomerId();id(request.AddressId);
    const cart=owned(await this.checkoutRepository.GetCheckoutCartAsync(customerId,signal));requireValue(cart.Items.length>0,'EMPTY_CART',422);
    const address=owned(await this.checkoutRepository.GetOwnedAddressAsync(customerId,request.AddressId,signal));const distance=await this.distanceCalculator.CalculateAsync(address.AddressId,signal);const fee=this.deliveryFeePolicy.Quote(distance);
    return {customerId,cart,address,distance,fee};
  }
  async allocate(cart,signal) {
    const batches=fefo(await this.checkoutRepository.LockFefoBatchesAsync(cart.Items.map(i=>i.ProductId),signal));const lines=[];let total=0n;const now=new Date();
    for(const item of cart.Items) { quantity(item.Quantity);let remaining=item.Quantity;
      for(const b of batches.filter(b=>b.ProductId===item.ProductId&&sellable(b,now))) {const qty=Math.min(remaining,b.CurrentStock-b.ReservedStock);if(!qty)continue;const price=this.pricing.Quote(b,now).units;lines.push({ProductId:item.ProductId,BatchId:b.BatchId,Quantity:qty,UnitPrice:price.toString(),Discount:'0'});total+=price*BigInt(qty);remaining-=qty;if(!remaining)break;}
      requireValue(remaining===0,'INSUFFICIENT_STOCK',409);
    }
    return {lines,batches,total};
  }
  async PrepareCheckoutAsync(request,signal) {const p=await this.plan(request,signal);const a=await this.allocate(p.cart,signal);return {SubTotal:a.total.toString(),ShippingFee:p.fee.toString(),DistanceKm:p.distance,Total:(a.total+p.fee.units).toString(),Lines:a.lines};}
  async PlaceOrderAsync(request,signal) {
    requireValue(['Cod','VietQr'].includes(request.PaymentMethod),'INVALID_PAYMENT_METHOD');const customerId=this.currentCustomer.RequireCustomerId();
    const reference=id(request.CheckoutReference);const eventId=id(request.IdempotencyKey);
    if(request.PaymentMethod==='VietQr')throw new ApiError('PRE_ACCEPTANCE_PAYMENT_CORRELATION_TBD',503);
    const p=await this.plan(request,signal);
    const result=await this.unitOfWork.ExecuteAsync(async()=>{
      const allocation=await this.allocate(p.cart,signal);const order={OrderId:undefined,OrderNumber:randomUUID(),CustomerId:customerId,DeliveryAddressId:p.address.AddressId,OrderDate:new Date(),SubTotal:allocation.total.toString(),DeliveryDistance:p.distance,ShippingFee:p.fee.toString(),TotalAmount:(allocation.total+p.fee.units).toString(),PaymentMethod:request.PaymentMethod,PaymentStatus:'Unpaid',OrderStatus:undefined,PhoneConfirmationStatus:'NotRequired',Details:allocation.lines.map(l=>({...l,LineTotal:(BigInt(l.UnitPrice)*BigInt(l.Quantity)).toString(),DiscountAmount:'0'}))};
      const context={order,batches:allocation.batches,cart:p.cart,lines:allocation.lines};
      const snapshot=trustedSnapshot({WorkflowNode:'initial',AggregateId:reference,CheckoutReference:reference,CustomerId:customerId,AddressId:request.AddressId,PaymentMethod:request.PaymentMethod,PlannedLines:allocation.lines,ActorId:customerId,GuardFacts:{VerifiedPayment:false}},context);
      for(const transitionId of ['I00','T01u','P01'])await this.transitionExecutor.ExecuteInCurrentTransactionAsync(snapshot,{TransitionId:transitionId,AggregateId:reference,EventId:eventId},signal);
      await this.checkoutRepository.SaveOrderAsync(order,signal);await this.checkoutRepository.ClearCartAsync(p.cart.CartId,signal);
      return {OrderId:order.OrderId,OrderNumber:order.OrderNumber,Status:order.OrderStatus,PaymentStatus:order.PaymentStatus,Total:order.TotalAmount};
    },signal);
    await publishAfterCommit(this.notificationGateway,{OrderId:result.OrderId,EventCode:'ORDER_ACCEPTED'},signal);return result;
  }
  async CreatePaymentQrAsync(request,signal) {this.currentCustomer.RequireCustomerId();id(request.CheckoutReference);throw new ApiError('PRE_ACCEPTANCE_PAYMENT_CORRELATION_TBD',503);}
  async HandleVerifiedPaymentAsync(request,signal) {const verified=await this.paymentGateway.VerifyNoticeAsync(request,signal);requireValue(verified?.ProviderReference&&verified?.CheckoutReference,'UNVERIFIED_PAYMENT',403);amount(verified.GoodsAmount);amount(verified.ShippingAmount);throw new ApiError('PAYMENT_CORRELATION_AND_LATE_PAYMENT_POLICY_TBD',503);}
}''')
put('PaymentNoticeHandler','''export class PaymentNoticeHandler {
  constructor(checkout,payment) {Object.assign(this,{checkout,payment});}
  async HandleAsync(notice,signal) { await this.payment.VerifyNoticeAsync(notice,signal);return this.checkout.HandleVerifiedPaymentAsync(notice,signal); }
}''')
put('MyOrdersService','''import { id, owned, text, requireValue, orderSummary, addressDto, fefo, sellable } from './shared.js';
import { trustedSnapshot, publishAfterCommit } from './transitionRuntime.js';
export class MyOrdersService {
  constructor(myOrdersRepository,currentCustomer,unitOfWork,notificationGateway,transitionExecutor,pricing) {Object.assign(this,{myOrdersRepository,currentCustomer,unitOfWork,notificationGateway,transitionExecutor,pricing});}
  async GetOrdersAsync(signal) {const customerId=this.currentCustomer.RequireCustomerId();return {Orders:(await this.myOrdersRepository.FindOwnedAsync(customerId,signal)).map(orderSummary)};}
  async GetOrderDetailsAsync(orderId,signal) {const customerId=this.currentCustomer.RequireCustomerId();id(orderId);const o=owned((await this.myOrdersRepository.FindOwnedAsync(customerId,signal)).find(o=>o.OrderId===orderId));const receipt=await this.myOrdersRepository.GetReturnReceiptAsync(orderId,signal);const refund=await this.myOrdersRepository.GetRefundAsync(orderId,signal);return {Order:orderSummary(o),Address:addressDto(o.DeliveryAddress),PaymentStatus:o.PaymentStatus,Lines:o.Details.map(l=>({ProductName:l.ProductName,Quantity:l.Quantity,UnitPrice:String(l.UnitPrice),LineTotal:String(l.LineTotal)})),Return:receipt||refund?{FailureReason:o.Failure?.ReasonCode,ReceiptStatus:receipt?.ReceiptStatus,RefundStatus:refund?.RefundStatus,GoodsRefunded:String(refund?.GoodsRefundAmount??'0'),ShippingRefunded:String(refund?.ShippingRefundAmount??'0'),InventoryDisposition:receipt?.InventoryDisposition}:null};}
  async CancelOrderAsync(request,signal) {const customerId=this.currentCustomer.RequireCustomerId();id(request.OrderId);const reason=text(request.Reason,'CANCELLATION_REASON_REQUIRED');
    await this.unitOfWork.ExecuteAsync(async()=>{const o=owned(await this.myOrdersRepository.LockOwnedAsync(customerId,request.OrderId,signal));const transitions={PendingUnpaid:'T08u',PendingPaid:'T08p',Confirmed:'T09'};requireValue(transitions[o.OrderStatus],'CANCELLATION_NOT_ALLOWED',409);const snapshot=trustedSnapshot({AggregateId:o.OrderId,CustomerId:customerId,FulfillmentState:o.OrderStatus,PaymentState:o.PaymentStatus,ActorId:customerId,GuardFacts:{}},{order:o});await this.transitionExecutor.ExecuteInCurrentTransactionAsync(snapshot,{TransitionId:transitions[o.OrderStatus],AggregateId:o.OrderId,EventId:'cancel:'+o.OrderId,Reason:reason},signal);},signal);
    await publishAfterCommit(this.notificationGateway,{OrderId:request.OrderId,EventCode:'ORDER_CANCELLED'},signal);return {Success:true,MessageCode:'ORDER_CANCELLED'};
  }
  async ReorderAsync(orderId,signal) {const customerId=this.currentCustomer.RequireCustomerId();id(orderId);return this.unitOfWork.ExecuteAsync(async()=>{const o=owned(await this.myOrdersRepository.LockOwnedAsync(customerId,orderId,signal));const all=await this.myOrdersRepository.GetCurrentBatchesAsync(o.Details.map(l=>l.ProductId),signal);const grouped=new Map();for(const l of o.Details)grouped.set(l.ProductId,(grouped.get(l.ProductId)??0)+l.Quantity);const lines=[];const warnings=[];let subtotal=0n;
    for(const [productId,qty] of grouped){const stock=fefo(all.filter(b=>b.ProductId===productId&&sellable(b)));const available=stock.reduce((s,b)=>s+b.CurrentStock-b.ReservedStock,0);if(!available){warnings.push('UNAVAILABLE:'+productId);continue;}const actual=Math.min(qty,available);const price=this.pricing.Quote(stock[0],new Date()).units;lines.push({ProductId:productId,Quantity:actual,AvailableQuantity:available,CurrentPrice:price.toString(),LineTotal:(price*BigInt(actual)).toString()});subtotal+=price*BigInt(actual);if(actual<qty)warnings.push('QUANTITY_CLAMPED:'+productId);}
    await this.myOrdersRepository.SaveCartAsync({CustomerId:customerId,Items:lines},signal);return {Lines:lines,SubTotal:subtotal.toString(),CanCheckout:lines.length>0,Warnings:warnings};},signal);}
  async SubmitReviewAsync(request,signal) {const customerId=this.currentCustomer.RequireCustomerId();id(request.OrderId);requireValue(Number.isInteger(request.Rating)&&request.Rating>=1&&request.Rating<=5,'RATING_OUT_OF_RANGE');requireValue(request.Comment==null||typeof request.Comment==='string','INVALID_COMMENT');return this.unitOfWork.ExecuteAsync(async()=>{const order=owned(await this.myOrdersRepository.LockOwnedAsync(customerId,request.OrderId,signal));requireValue(order.OrderStatus==='Delivered','REVIEW_REQUIRES_DELIVERED',409);requireValue(await this.myOrdersRepository.SaveReviewOnceAsync({...request,CustomerId:customerId},signal),'REVIEW_ALREADY_EXISTS',409);return {Success:true,MessageCode:'REVIEW_SAVED'};},signal);}
}''')
# Exact one-class-per-transition dispatch; unsupported financial/staff effects fail closed.
m=json.loads(Path('artifacts/design/detailed/detailed-class-model.json').read_text(encoding='utf-8-sig'))
transitions={r['id']:r for r in m['transitions']}
for tid,r in transitions.items():
 name=r['class'];Path(P[name]).write_text(f'''import {{ TransitionHandler }} from './TransitionHandler.js';
export class {name} extends TransitionHandler {{
  constructor(...dependencies) {{ super({json.dumps(tid)}, dependencies); }}
}}
''',encoding='utf-8')
(base/'TransitionHandler.js').write_text('''import { transitionContext } from './transitionRuntime.js';
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
    return cancelSources[this.Id]===c.order?.OrderStatus;
  }
  async ExecuteAsync(snapshot,command,signal) {
    const c=transitionContext(snapshot);requireValue(this.CanExecute(snapshot,command),'TRANSITION_GUARD_REJECTED',409);
    if(this.Id==='I00'){c.stage='accepted';return {Applied:true,Code:'ACCEPTED'};}
    if(this.Id==='T01u'||this.Id==='T01p'){c.order.OrderStatus=this.Id==='T01u'?'PendingUnpaid':'PendingPaid';return {Applied:true,Code:c.order.OrderStatus};}
    if(this.Id==='P01'){c.order.PaymentStatus='Unpaid';return {Applied:true,Code:'Unpaid'};}
    if(this.Id==='P02')throw new ApiError('PAYMENT_CORRELATION_TBD',503);
    if(cancelSources[this.Id]){
      const lifecycle=this.dependencies[0];const batches=await lifecycle.LockReservedBatchesAsync(c.order.OrderId,signal);
      for(const l of c.order.Details){const b=batches.find(b=>b.BatchId===l.BatchId);requireValue(b&&b.ReservedStock>=l.Quantity,'RESERVATION_INCONSISTENT',409);b.ReservedStock-=l.Quantity;}
      c.order.OrderStatus='Cancelled';c.order.CancellationReason=command.Reason;await lifecycle.SaveBatchesAsync(batches,signal);await lifecycle.SaveAsync(c.order,signal);await lifecycle.AppendAuditAsync({ActorCustomerId:snapshot.CustomerId,OrderId:c.order.OrderId,ActionType:'Cancel',Reason:command.Reason},signal);return {Applied:true,Code:'Cancelled'};
    }
    throw new ApiError('STAFF_RETURN_REFUND_IMPLEMENTATION_TBD',503);
  }
}''',encoding='utf-8')
put('TransitionExecutor','''import { transitionContext, trustedSnapshot } from './transitionRuntime.js';
import { requireValue } from './shared.js';
export class TransitionExecutor {
  constructor(transitions,unitOfWork,orderLifecycleRepository) {this.transitions=new Map(transitions.map(t=>[t.Id,t]));requireValue(this.transitions.size===transitions.length,'DUPLICATE_TRANSITION_ID');this.unitOfWork=unitOfWork;this.repository=orderLifecycleRepository;}
  async ExecuteAsync(command,signal) {return this.unitOfWork.ExecuteAsync(async()=>{const records=await this.repository.LoadLifecycleAsync(command.AggregateId,signal);const snapshot=trustedSnapshot(records.Snapshot,records.Context);return this.ExecuteInCurrentTransactionAsync(snapshot,command,signal);},signal);}
  async ExecuteInCurrentTransactionAsync(snapshot,command,signal) {transitionContext(snapshot);requireValue(snapshot.AggregateId===command.AggregateId,'AGGREGATE_MISMATCH',403);const handler=this.transitions.get(command.TransitionId);requireValue(handler,'UNKNOWN_TRANSITION');requireValue(handler.CanExecute(snapshot,command),'TRANSITION_GUARD_REJECTED',409);const first=await this.repository.RecordEventOnceAsync(command.AggregateId,command.EventId,command.TransitionId,signal);if(!first)return {Applied:false,Code:'DUPLICATE_EVENT'};return handler.ExecuteAsync(snapshot,command,signal);}
}''')
print('Implemented Checkout/MyOrders services and',len(transitions),'individual transition classes; unresolved paths fail closed')
