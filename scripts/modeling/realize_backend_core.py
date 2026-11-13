raise SystemExit('Historical Node.js generator retired after the explicit ASP.NET Core C# selection. Maintain the current C# source and detailed-class-model.json; do not regenerate the former backend.')
﻿from pathlib import Path
import json
P=json.loads(Path('scratch/backend-mapping-paths.json').read_text())
def put(n,s):Path(P[n]).write_text(s.strip()+'\n',encoding='utf-8')
shared=Path('src/FreshFood-API/Services/Implements/shared.js')
shared.write_text('''export class ApiError extends Error {
  constructor(code, status = 400) { super(code); this.code = code; this.status = status; }
}
export function requireValue(ok, code, status = 400) { if (!ok) throw new ApiError(code, status); }
export function checkSignal(signal) { signal?.throwIfAborted(); }
export function id(value) { requireValue(typeof value === 'string' && value.length > 0 && value.length <= 128, 'INVALID_ID'); return value; }
export function quantity(value) { requireValue(Number.isSafeInteger(value) && value > 0, 'INVALID_QUANTITY'); return value; }
export function amount(value) { const s = value?.units ?? value; requireValue(typeof s === 'bigint' || (typeof s === 'string' && /^\\d+$/.test(s)), 'INVALID_AMOUNT'); return BigInt(s); }
export function owned(value) { requireValue(value, 'NOT_FOUND', 404); return value; }
export function text(value, code = 'INVALID_TEXT') { requireValue(typeof value === 'string' && value.trim().length > 0, code); return value.trim(); }
export function sellable(batch, now = new Date()) { return batch.SaleStatus === 'Available' && batch.ExpiryDate >= now.toISOString().slice(0, 10) && batch.CurrentStock > batch.ReservedStock; }
export function fefo(batches) { return [...batches].sort((a,b) => a.ExpiryDate.localeCompare(b.ExpiryDate) || String(a.BatchId).localeCompare(String(b.BatchId), 'en', {numeric:true})); }
export function orderSummary(o) { return { OrderId:o.OrderId, OrderNumber:o.OrderNumber, OrderDate:new Date(o.OrderDate).toISOString(), Status:o.OrderStatus, Total:amount(o.TotalAmount).toString() }; }
export function addressDto(a) { return Object.fromEntries(['AddressId','RecipientName','RecipientPhone','StreetAddress','Latitude','Longitude','IsDefault'].map(k => [k,a[k]])); }
''',encoding='utf-8')
put('VndAmount','''export class VndAmount {
  constructor(units) { if (typeof units !== 'bigint' || units < 0n) throw new RangeError('VND requires nonnegative bigint units'); this.units = units; Object.freeze(this); }
  toString() { return this.units.toString(); }
  toJSON() { return this.toString(); }
}''')
put('BatchPricingPolicy','''import { VndAmount } from './VndAmount.js';
export class BatchPricingPolicy {
  Quote(batch, asOf) {
    if (!asOf || batch.ExpiryDate < asOf.toISOString().slice(0,10)) throw new RangeError('BATCH_EXPIRED');
    const raw = String(batch.DiscountRate ?? 0);
    if (!/^\\d+(\\.\\d{1,2})?$/.test(raw)) throw new RangeError('INVALID_DISCOUNT');
    const [a,b=''] = raw.split('.'); const rate = BigInt(a)*100n + BigInt(b.padEnd(2,'0'));
    if (rate !== 0n && (rate < 1000n || rate > 5000n)) throw new RangeError('CLEARANCE_RATE_OUT_OF_RANGE');
    const retail = BigInt(batch.RetailPrice?.units ?? batch.RetailPrice); if (retail < 0n) throw new RangeError('INVALID_PRICE');
    const numerator = retail * (10000n-rate);
    if (numerator % 10000n) throw Object.assign(new Error('Fractional VND rounding policy requires confirmation'), {code:'ROUNDING_POLICY_TBD',status:503});
    return new VndAmount(numerator/10000n);
  }
}''')
put('DeliveryFeePolicy','''import { VndAmount } from './VndAmount.js';
export class DeliveryFeePolicy {
  Quote(distanceKm) {
    if (typeof distanceKm !== 'number' || !Number.isFinite(distanceKm) || distanceKm < 0) throw new RangeError('INVALID_DISTANCE');
    if (distanceKm > 10) throw Object.assign(new RangeError('OUTSIDE_DELIVERY_AREA'),{code:'OUTSIDE_DELIVERY_AREA',status:422});
    return new VndAmount(distanceKm < 1 ? 10000n : distanceKm < 3 ? 20000n : 30000n);
  }
}''')
put('CurrentCustomer','''import { ApiError } from './shared.js';
export class CurrentCustomer {
  constructor(principal) { this.principal = principal; }
  RequireCustomerId() { if (!this.principal?.CustomerId) throw new ApiError('AUTHENTICATION_REQUIRED',401); return this.principal.CustomerId; }
  GetCartIdentity() { if (!this.principal?.CustomerId && !this.principal?.SessionId) throw new ApiError('SESSION_REQUIRED',401); return {CustomerId:this.principal.CustomerId,SessionId:this.principal.SessionId}; }
}''')
put('UnitOfWork','''export class UnitOfWork {
  constructor(session) { this.session = session; }
  async ExecuteAsync(work, signal) {
    signal?.throwIfAborted(); await this.session.BeginAsync(signal);
    try { const result = await work(signal); signal?.throwIfAborted(); await this.session.CommitAsync(signal); return result; }
    catch (error) { await this.session.RollbackAsync().catch(() => {}); throw error; }
  }
}''')
put('PostgreSqlSession','''export class PostgreSqlSession {
  constructor(connection) { this.connection = connection; this.active = false; }
  async BeginAsync(signal) { if (this.active) throw new Error('Nested transaction prohibited'); await this.connection.QueryAsync('BEGIN',[],signal); this.active=true; }
  async CommitAsync(signal) { if (!this.active) throw new Error('No active transaction'); await this.connection.QueryAsync('COMMIT',[],signal); this.active=false; }
  async RollbackAsync(signal) { if(this.active) { try { await this.connection.QueryAsync('ROLLBACK',[],signal); } finally { this.active=false; } } }
}''')
put('DistanceCalculator','''export class DistanceCalculator { constructor(distanceGateway) { this.distanceGateway=distanceGateway; } async CalculateAsync(addressId, signal) { return this.distanceGateway.GetDrivingDistanceKmAsync(addressId, signal); } }''')
put('ConfiguredNotificationPublisher','''export class ConfiguredNotificationPublisher {
  constructor(transport) { this.transport=transport; }
  async PublishAsync(message, signal) { if (!this.transport) throw Object.assign(new Error('Notification transport not configured'),{code:'NOTIFICATION_UNCONFIGURED',status:503}); return this.transport.SendAsync(message,signal); }
}''')
put('NotificationAdapter','''export class NotificationAdapter { constructor(publisher) { this.publisher=publisher; } async PublishAsync(message,signal) { return this.publisher.PublishAsync(message,signal); } }''')
put('UnconfiguredPayoutAdapter','''export class UnconfiguredPayoutAdapter { async PayAsync() { throw Object.assign(new Error('Outgoing payout provider requires approval'), {code:'PAYOUT_PROVIDER_TBD',status:503}); } }''')
# Catalog uses active stock, per-batch prices, categories and the six popular alternatives.
put('CatalogService','''import { checkSignal, owned, sellable, fefo, id } from './shared.js';
export class CatalogService {
  constructor(catalogRepository, pricing) { this.catalogRepository=catalogRepository; this.pricing=pricing; }
  async summaries(products, signal) {
    const now=new Date(); const batches=await this.catalogRepository.GetSellableBatchesAsync(products.map(p=>p.ProductId),signal);
    return products.filter(p=>p.IsActive).map(p=>{ const stock=fefo(batches.filter(b=>b.ProductId===p.ProductId && sellable(b,now))); return {ProductId:p.ProductId,Name:p.ProductName,Unit:p.UnitOfMeasure,AvailableQuantity:stock.reduce((s,b)=>s+b.CurrentStock-b.ReservedStock,0),CurrentPrice:stock.length?this.pricing.Quote(stock[0],now).toString():'0'}; });
  }
  async GetCatalogAsync(query={},signal) {
    checkSignal(signal); const products=await this.catalogRepository.FindActiveAsync(query.Keyword??null,query.CategoryId??null,query.ClearanceOnly===true,signal);
    return {Items:await this.summaries(products,signal),Categories:(await this.catalogRepository.GetCategoriesAsync(signal)).map(c=>({CategoryId:String(c.CategoryId),Name:c.CategoryName})),Alternatives:products.length?[]:await this.summaries(await this.catalogRepository.GetPopularAsync(6,signal),signal)};
  }
  async SearchAsync(query,signal) { return this.GetCatalogAsync(query,signal); }
  async GetClearanceAsync(query,signal) { return this.GetCatalogAsync({...query,ClearanceOnly:true},signal); }
  async GetProductDetailsAsync(productId,signal) {
    id(productId);const product=owned(await this.catalogRepository.GetProductAsync(productId,signal));owned(product.IsActive);
    const batches=await this.catalogRepository.GetSellableBatchesAsync([productId],signal);const now=new Date();
    return {Product:(await this.summaries([product],signal))[0],Description:product.Description,AvailableBatches:fefo(batches.filter(b=>sellable(b,now))).map(b=>({BatchId:b.BatchId,ExpiryDate:b.ExpiryDate,Price:this.pricing.Quote(b,now).toString(),Clearance:Number(b.DiscountRate)>0}))};
  }
}''')
put('CartService','''import { checkSignal, quantity, id, requireValue, sellable, fefo } from './shared.js';
export class CartService {
  constructor(cartRepository,currentCustomer,unitOfWork,pricing) { Object.assign(this,{cartRepository,currentCustomer,unitOfWork,pricing}); }
  async load(signal) { const identity=this.currentCustomer.GetCartIdentity();return this.cartRepository.GetAsync(identity.CustomerId??null,identity.SessionId??null,signal); }
  async result(cart,signal) {
    const ids=cart.Items.map(i=>i.ProductId);const products=await this.cartRepository.GetProductsAsync(ids,signal);const batches=await this.cartRepository.GetSellableBatchesAsync(ids,signal);const now=new Date();let subtotal=0n;const warnings=[];
    const lines=cart.Items.map(i=>{ const p=products.find(p=>p.ProductId===i.ProductId);const stock=fefo(batches.filter(b=>b.ProductId===i.ProductId&&sellable(b,now)));const available=p?.IsActive?stock.reduce((s,b)=>s+b.CurrentStock-b.ReservedStock,0):0;const price=stock.length?this.pricing.Quote(stock[0],now).units:0n;const line=price*BigInt(i.Quantity);subtotal+=line;if(i.Quantity>available)warnings.push('UNAVAILABLE:'+i.ProductId);return {ProductId:i.ProductId,Quantity:i.Quantity,AvailableQuantity:available,CurrentPrice:price.toString(),LineTotal:line.toString()}; });
    return {Lines:lines,SubTotal:subtotal.toString(),CanCheckout:lines.length>0&&!warnings.length,Warnings:warnings};
  }
  async GetCartAsync(_identity,signal) { checkSignal(signal);return this.result(await this.load(signal),signal); }
  async ChangeQuantityAsync(request,signal) {
    id(request.ProductId);quantity(request.Quantity);
    return this.unitOfWork.ExecuteAsync(async()=>{const cart=await this.load(signal);const products=await this.cartRepository.GetProductsAsync([request.ProductId],signal);requireValue(products.some(p=>p.IsActive),'PRODUCT_UNAVAILABLE',422);const batches=await this.cartRepository.GetSellableBatchesAsync([request.ProductId],signal);const available=batches.filter(b=>sellable(b)).reduce((s,b)=>s+b.CurrentStock-b.ReservedStock,0);requireValue(available>0,'OUT_OF_STOCK',422);
      const desired=request.Quantity;const actual=Math.min(desired,available);cart.ChangeQuantity(request.ProductId,actual);await this.cartRepository.SaveAsync(cart,signal);const result=await this.result(cart,signal);if(actual<desired)result.Warnings.push('QUANTITY_CLAMPED:'+request.ProductId);return result;},signal);
  }
  async RemoveItemAsync(productId,signal) { id(productId);return this.unitOfWork.ExecuteAsync(async()=>{const cart=await this.load(signal);cart.RemoveItem(productId);await this.cartRepository.SaveAsync(cart,signal);return this.result(cart,signal);},signal); }
}''')
put('ProfileService','''import { id, owned, text, requireValue, addressDto } from './shared.js';
export class ProfileService {
  constructor(profileRepository,currentCustomer,unitOfWork,geocodingGateway) { Object.assign(this,{profileRepository,currentCustomer,unitOfWork,geocodingGateway}); }
  async GetProfileAsync(signal) { const customerId=this.currentCustomer.RequireCustomerId();const c=owned(await this.profileRepository.GetCustomerAsync(customerId,signal));return {CustomerId:c.CustomerId,FullName:c.FullName,Phone:c.Phone,Email:c.Email,Addresses:(await this.profileRepository.GetAddressesAsync(customerId,signal)).map(addressDto)}; }
  async UpdateProfileAsync(request,signal) {
    const customerId=this.currentCustomer.RequireCustomerId();const name=text(request.FullName);requireValue(request.Email==null||request.Email===''||/^[^\\s@]+@[^\\s@]+\\.[^\\s@]+$/.test(request.Email),'INVALID_EMAIL');
    await this.unitOfWork.ExecuteAsync(async()=>{const customer=owned(await this.profileRepository.GetCustomerAsync(customerId,signal));await this.profileRepository.SaveCustomerAsync({...customer,FullName:name,Email:request.Email||null},signal);},signal);return this.GetProfileAsync(signal);
  }
  async SaveAddressAsync(request,signal) {
    const customerId=this.currentCustomer.RequireCustomerId();const input={...request,CustomerId:customerId,RecipientName:text(request.RecipientName),RecipientPhone:text(request.RecipientPhone),StreetAddress:text(request.StreetAddress),IsDefault:request.IsDefault===true};
    requireValue(/^\\+?[0-9]{9,15}$/.test(input.RecipientPhone),'INVALID_PHONE');
    const geo=await this.geocodingGateway.ResolveAsync(input.StreetAddress,signal);requireValue(Number.isFinite(geo?.Latitude)&&Math.abs(geo.Latitude)<=90&&Number.isFinite(geo?.Longitude)&&Math.abs(geo.Longitude)<=180,'INVALID_ADDRESS_COORDINATES',422);
    return this.unitOfWork.ExecuteAsync(async()=>{const addresses=await this.profileRepository.GetAddressesAsync(customerId,signal);if(input.AddressId)owned(addresses.find(a=>a.AddressId===id(input.AddressId)));const entity={...input,...geo};await this.profileRepository.SaveAddressAsync(entity,signal);return addressDto(entity);},signal);
  }
  async SetDefaultAddressAsync(addressId,signal) { const customerId=this.currentCustomer.RequireCustomerId();id(addressId);await this.unitOfWork.ExecuteAsync(async()=>{const a=owned((await this.profileRepository.GetAddressesAsync(customerId,signal)).find(a=>a.AddressId===addressId));await this.profileRepository.SaveAddressAsync({...a,IsDefault:true},signal);},signal);return this.GetProfileAsync(signal); }
  async DeleteAddressAsync(addressId,signal) { const customerId=this.currentCustomer.RequireCustomerId();id(addressId);await this.unitOfWork.ExecuteAsync(async()=>{owned((await this.profileRepository.GetAddressesAsync(customerId,signal)).find(a=>a.AddressId===addressId));requireValue(!await this.profileRepository.HasActiveOrderAsync(customerId,addressId,signal),'ADDRESS_USED_BY_ACTIVE_ORDER',409);await this.profileRepository.DeleteAddressAsync(customerId,addressId,signal);},signal);return {Success:true,MessageCode:'ADDRESS_DELETED'}; }
}''')
# Entity behavior selected in the detailed design; records remain transport-neutral.
put('Cart','''export class Cart {
  constructor(values={}) { Object.assign(this,values);this.Items=[...(values.Items??[])]; }
  ChangeQuantity(productId,quantity) { if(!Number.isSafeInteger(quantity)||quantity<=0)throw new RangeError('INVALID_QUANTITY');const item=this.Items.find(i=>i.ProductId===productId);if(item)item.Quantity=quantity;else this.Items.push({ProductId:productId,Quantity:quantity}); }
  RemoveItem(productId) { this.Items=this.Items.filter(i=>i.ProductId!==productId); }
}''')
put('BatchInventory','''export class BatchInventory {
  constructor(values={}) {Object.assign(this,values);}
  Reserve(quantity) { if(!Number.isSafeInteger(quantity)||quantity<=0||quantity>this.CurrentStock-this.ReservedStock)throw new RangeError('INSUFFICIENT_STOCK');this.ReservedStock+=quantity; }
  ReleaseReservation(quantity) { if(!Number.isSafeInteger(quantity)||quantity<=0||quantity>this.ReservedStock)throw new RangeError('INVALID_RELEASE');this.ReservedStock-=quantity; }
}''')
put('Order','''export class Order {
  constructor(values={}) {Object.assign(this,values);}
  ApplyFulfillment(expected,target) { if(this.OrderStatus!==expected)throw new Error('STALE_ORDER_STATE');this.OrderStatus=target; }
  RecordPayment(expected,target) { if(this.PaymentStatus!==expected)throw new Error('STALE_PAYMENT_STATE');this.PaymentStatus=target; }
}''')
print('Implemented domain policies, controller delegates and Catalog/Cart/Profile services')
