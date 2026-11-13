/**
 * Design revision 2026-11-02: CheckoutService
 * Ownership: FreshFood-API.Services.Implements
 * - checkoutRepository: ICheckoutRepository
 * - currentCustomer: ICurrentCustomer
 * - unitOfWork: IUnitOfWork
 * - distanceCalculator: IDistanceCalculator
 * - paymentGateway: IPaymentGateway
 * - notificationGateway: INotificationGateway
 * - orderStateMachine: IOrderStateMachine
 * - pricing: IBatchPricingPolicy
 * - deliveryFeePolicy: IDeliveryFeePolicy
 * + CheckoutService(checkoutRepository: ICheckoutRepository, currentCustomer: ICurrentCustomer, unitOfWork: IUnitOfWork, distanceCalculator: IDistanceCalculator, paymentGateway: IPaymentGateway, notificationGateway: INotificationGateway, orderStateMachine: IOrderStateMachine, pricing: IBatchPricingPolicy, deliveryFeePolicy: IDeliveryFeePolicy)
 * + PrepareCheckoutAsync(request: CheckoutInputDto, signal: AbortSignal): Promise<CheckoutSummaryDto>
 * + PlaceOrderAsync(request: PlaceOrderDto, signal: AbortSignal): Promise<OrderConfirmationDto>
 * + CreatePaymentQrAsync(request: PaymentQrRequestDto, signal: AbortSignal): Promise<PaymentQrDto>
 * + HandleVerifiedPaymentAsync(request: PaymentNoticeDto, signal: AbortSignal): Promise<PaymentResultDto>
 */
import { randomUUID, createHash } from 'node:crypto';
import { id, owned, quantity, requireValue, amount, sellable, fefo, ApiError } from './shared.js';
import { trustedSnapshot, publishAfterCommit } from './transitionRuntime.js';
export class CheckoutService {
  constructor(checkoutRepository,currentCustomer,unitOfWork,distanceCalculator,paymentGateway,notificationGateway,orderStateMachine,pricing,deliveryFeePolicy) { Object.assign(this,{checkoutRepository,currentCustomer,unitOfWork,distanceCalculator,paymentGateway,notificationGateway,orderStateMachine,pricing,deliveryFeePolicy}); }
  async plan(request,signal) {
    const customerId=this.currentCustomer.RequireCustomerId();id(request.AddressId);
    const cart=owned(await this.checkoutRepository.GetCheckoutCartAsync(customerId,signal));requireValue(cart.Items.length>0,'EMPTY_CART',422);
    const address=owned(await this.checkoutRepository.GetOwnedAddressAsync(customerId,request.AddressId,signal));const distance=await this.distanceCalculator.CalculateAsync(address.AddressId,signal);const fee=this.deliveryFeePolicy.Quote(distance);
    return {customerId,cart,address,distance,fee};
  }
  async allocate(cart,signal) {
    const batches=fefo(await this.checkoutRepository.LockFefoBatchesAsync(cart.Items.map(i=>i.ProductId),signal));const lines=[];let total=0n;const now=new Date();
    for(const item of cart.Items) { quantity(item.Quantity);let remaining=item.Quantity;
      for(const b of batches.filter(b=>b.ProductId===item.ProductId&&sellable(b,now))) {const qty=Math.min(remaining,b.CurrentStock-b.ReservedStock);if(!qty)continue;const price=BigInt(this.pricing.Quote(b,now).ToWire());lines.push({ProductId:item.ProductId,BatchId:b.BatchId,Quantity:qty,UnitPrice:price.toString(),Discount:'0'});total+=price*BigInt(qty);remaining-=qty;if(!remaining)break;}
      requireValue(remaining===0,'INSUFFICIENT_STOCK',409);
    }
    return {lines,batches,total};
  }
  async PrepareCheckoutAsync(request,signal) {const p=await this.plan(request,signal);const a=await this.allocate(p.cart,signal);return {SubTotal:a.total.toString(),ShippingFee:p.fee.toString(),DistanceKm:p.distance,Total:(a.total+BigInt(p.fee.ToWire())).toString(),Lines:a.lines};}
  async PlaceOrderAsync(request,signal) {
    requireValue(['Cod','VietQr'].includes(request.PaymentMethod),'INVALID_PAYMENT_METHOD');const customerId=this.currentCustomer.RequireCustomerId();
    const reference=id(request.CheckoutReference);const eventId=id(request.IdempotencyKey);
    if(request.PaymentMethod==='VietQr')throw new ApiError('PRE_ACCEPTANCE_PAYMENT_CORRELATION_TBD',503);
    const requestHash=createHash('sha256').update(JSON.stringify({AddressId:request.AddressId,PaymentMethod:request.PaymentMethod,CheckoutReference:reference})).digest('hex');
    // Maps calls stay outside the transaction. A retry may replay even if its cart is now empty.
    let preparation, preparationError;
    try { preparation=await this.plan(request,signal); } catch(error) { preparationError=error; }
    const result=await this.unitOfWork.ExecuteAsync(async()=>{
      const claim=await this.checkoutRepository.ClaimCheckoutAsync(customerId,reference,eventId,requestHash,signal);
      if(claim.Replay)return {confirmation:claim.Response,replay:true};
      if(preparationError)throw preparationError;
      const p={...preparation,cart:await this.checkoutRepository.GetCheckoutCartAsync(customerId,signal)};
      requireValue(p.cart?.Items.length>0,'EMPTY_CART',422);
      const address=owned(await this.checkoutRepository.GetOwnedAddressAsync(customerId,request.AddressId,signal));
      for(const field of ['StreetAddress','Latitude','Longitude'])requireValue(address[field]===preparation.address[field],'CHECKOUT_ADDRESS_CHANGED',409);
      const allocation=await this.allocate(p.cart,signal);const order={OrderId:undefined,OrderNumber:randomUUID(),CustomerId:customerId,DeliveryAddressId:p.address.AddressId,OrderDate:new Date(),SubTotal:allocation.total.toString(),DeliveryDistance:p.distance,ShippingFee:p.fee.toString(),TotalAmount:(allocation.total+BigInt(p.fee.ToWire())).toString(),PaymentMethod:request.PaymentMethod,PaymentStatus:'Unpaid',OrderStatus:undefined,PhoneConfirmationStatus:'NOT_CONTACTED',Details:allocation.lines.map(l=>({...l,LineTotal:(BigInt(l.UnitPrice)*BigInt(l.Quantity)).toString(),DiscountAmount:'0'}))};
      const context={order,batches:allocation.batches,cart:p.cart,lines:allocation.lines};
      const snapshot=trustedSnapshot({WorkflowNode:'initial',AggregateId:'checkout:'+customerId+':'+reference,CheckoutReference:reference,CustomerId:customerId,AddressId:request.AddressId,PaymentMethod:request.PaymentMethod,PlannedLines:allocation.lines,ActorId:customerId,GuardFacts:{VerifiedPayment:false}},context);
      await this.orderStateMachine.processEvent(snapshot,{Event:'acceptOrder',AggregateId:'checkout:'+customerId+':'+reference,EventId:eventId},signal);
      await this.checkoutRepository.SaveOrderAsync(order,signal);await this.checkoutRepository.ClearCartAsync(p.cart.CartId,signal);
      const confirmation={OrderId:order.OrderId,OrderNumber:order.OrderNumber,Status:order.OrderStatus,PaymentStatus:order.PaymentStatus,Total:order.TotalAmount};
      await this.checkoutRepository.CompleteCheckoutAsync(customerId,reference,eventId,confirmation,signal);
      return {confirmation,replay:false};
    },signal);
    if(!result.replay)await publishAfterCommit(this.notificationGateway,{OrderId:result.confirmation.OrderId,EventCode:'ORDER_ACCEPTED'},signal);return result.confirmation;
  }
  async CreatePaymentQrAsync(request,signal) {this.currentCustomer.RequireCustomerId();id(request.CheckoutReference);throw new ApiError('PRE_ACCEPTANCE_PAYMENT_CORRELATION_TBD',503);}
  async HandleVerifiedPaymentAsync(request,signal) {const verified=await this.paymentGateway.VerifyNoticeAsync(request,signal);requireValue(verified?.ProviderReference&&verified?.CheckoutReference,'UNVERIFIED_PAYMENT',403);amount(verified.GoodsAmount);amount(verified.ShippingAmount);throw new ApiError('PAYMENT_CORRELATION_AND_LATE_PAYMENT_POLICY_TBD',503);}
}
