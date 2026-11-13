/**
 * Design revision 2026-11-02: MyOrdersService
 * Ownership: FreshFood-API.Services.Implements
 * - myOrdersRepository: IMyOrdersRepository
 * - currentCustomer: ICurrentCustomer
 * - unitOfWork: IUnitOfWork
 * - notificationGateway: INotificationGateway
 * - orderStateMachine: IOrderStateMachine
 * - pricing: IBatchPricingPolicy
 * + MyOrdersService(myOrdersRepository: IMyOrdersRepository, currentCustomer: ICurrentCustomer, unitOfWork: IUnitOfWork, notificationGateway: INotificationGateway, orderStateMachine: IOrderStateMachine, pricing: IBatchPricingPolicy)
 * + GetOrdersAsync(signal: AbortSignal): Promise<OrderListDto>
 * + GetOrderDetailsAsync(orderId: EntityId, signal: AbortSignal): Promise<OrderDetailsDto>
 * + CancelOrderAsync(request: CancelOrderDto, signal: AbortSignal): Promise<OperationResultDto>
 * + ReorderAsync(orderId: EntityId, signal: AbortSignal): Promise<CartResultDto>
 * + SubmitReviewAsync(request: OrderReviewDto, signal: AbortSignal): Promise<OperationResultDto>
 */
import { id, owned, text, requireValue, orderSummary, addressDto, fefo, sellable, ApiError } from './shared.js';
import { trustedSnapshot, publishAfterCommit } from './transitionRuntime.js';
export class MyOrdersService {
  constructor(myOrdersRepository,currentCustomer,unitOfWork,notificationGateway,orderStateMachine,pricing) {Object.assign(this,{myOrdersRepository,currentCustomer,unitOfWork,notificationGateway,orderStateMachine,pricing});}
  async GetOrdersAsync(signal) {const customerId=this.currentCustomer.RequireCustomerId();return {Orders:(await this.myOrdersRepository.FindOwnedAsync(customerId,signal)).map(orderSummary)};}
  async GetOrderDetailsAsync(orderId,signal) {const customerId=this.currentCustomer.RequireCustomerId();id(orderId);const o=owned((await this.myOrdersRepository.FindOwnedAsync(customerId,signal)).find(o=>o.OrderId===orderId));const receipt=await this.myOrdersRepository.GetReturnReceiptAsync(orderId,signal);const refund=await this.myOrdersRepository.GetRefundAsync(orderId,signal);return {Order:orderSummary(o),Address:addressDto(o.DeliveryAddress),PaymentStatus:o.PaymentStatus,Lines:o.Details.map(l=>({ProductName:l.ProductName,Quantity:l.Quantity,UnitPrice:String(l.UnitPrice),LineTotal:String(l.LineTotal)})),Return:receipt||refund?{FailureReason:o.Failure?.ReasonCode,ReceiptStatus:receipt?.ReceiptStatus,RefundStatus:refund?.RefundStatus,GoodsRefunded:String(refund?.GoodsRefundAmount??'0'),ShippingRefunded:String(refund?.ShippingRefundAmount??'0'),InventoryDisposition:receipt?.InventoryDisposition}:null};}
  async CancelOrderAsync(request,signal) {const customerId=this.currentCustomer.RequireCustomerId();id(request.OrderId);const reason=text(request.Reason,'CANCELLATION_REASON_REQUIRED');
    const applied=await this.unitOfWork.ExecuteAsync(async()=>{
      const o=owned(await this.myOrdersRepository.LockOwnedAsync(customerId,request.OrderId,signal));
      if(o.OrderStatus==='Cancelled')return false;
      const snapshot=trustedSnapshot({AggregateId:o.OrderId,CustomerId:customerId,FulfillmentState:o.OrderStatus,PaymentState:o.PaymentStatus,ActorId:customerId,GuardFacts:{}},{order:o});
      let effect;
      try { effect=await this.orderStateMachine.processEvent(snapshot,{Event:'cancelOrder',AggregateId:o.OrderId,EventId:'cancel:'+o.OrderId,Reason:reason},signal); }
      catch(error){if(['STATE_EVENT_NOT_ALLOWED','STATE_GUARD_REJECTED'].includes(error.code))throw new ApiError('CANCELLATION_NOT_ALLOWED',409);throw error;}
      return effect.Applied;
    },signal);
    if(applied)await publishAfterCommit(this.notificationGateway,{OrderId:request.OrderId,EventCode:'ORDER_CANCELLED'},signal);
    return {Success:true,MessageCode:applied?'ORDER_CANCELLED':'ORDER_ALREADY_CANCELLED'};
  }
  async ReorderAsync(orderId,signal) {const customerId=this.currentCustomer.RequireCustomerId();id(orderId);return this.unitOfWork.ExecuteAsync(async()=>{const o=owned(await this.myOrdersRepository.LockOwnedAsync(customerId,orderId,signal));const all=await this.myOrdersRepository.GetCurrentBatchesAsync(o.Details.map(l=>l.ProductId),signal);const grouped=new Map();for(const l of o.Details)grouped.set(l.ProductId,(grouped.get(l.ProductId)??0)+l.Quantity);const lines=[];const warnings=[];let subtotal=0n;
    for(const [productId,qty] of grouped){const stock=fefo(all.filter(b=>b.ProductId===productId&&sellable(b)));const available=stock.reduce((s,b)=>s+b.CurrentStock-b.ReservedStock,0);if(!available){warnings.push('UNAVAILABLE:'+productId);continue;}const actual=Math.min(qty,available);const price=BigInt(this.pricing.Quote(stock[0],new Date()).ToWire());lines.push({ProductId:productId,Quantity:actual,AvailableQuantity:available,CurrentPrice:price.toString(),LineTotal:(price*BigInt(actual)).toString()});subtotal+=price*BigInt(actual);if(actual<qty)warnings.push('QUANTITY_CLAMPED:'+productId);}
    await this.myOrdersRepository.SaveCartAsync({CustomerId:customerId,Items:lines},signal);return {Lines:lines,SubTotal:subtotal.toString(),CanCheckout:lines.length>0,Warnings:warnings};},signal);}
  async SubmitReviewAsync(request,signal) {const customerId=this.currentCustomer.RequireCustomerId();id(request.OrderId);requireValue(Number.isInteger(request.Rating)&&request.Rating>=1&&request.Rating<=5,'RATING_OUT_OF_RANGE');requireValue(request.Comment==null||typeof request.Comment==='string','INVALID_COMMENT');return this.unitOfWork.ExecuteAsync(async()=>{const order=owned(await this.myOrdersRepository.LockOwnedAsync(customerId,request.OrderId,signal));requireValue(order.OrderStatus==='Delivered','REVIEW_REQUIRES_DELIVERED',409);requireValue(await this.myOrdersRepository.SaveReviewOnceAsync({...request,CustomerId:customerId},signal),'REVIEW_ALREADY_EXISTS',409);return {Success:true,MessageCode:'REVIEW_SAVED'};},signal);}
}
