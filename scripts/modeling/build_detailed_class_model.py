raise SystemExit('Historical Node.js generator retired after the explicit ASP.NET Core C# selection. Maintain the current C# source and detailed-class-model.json; do not regenerate the former backend.')
from pathlib import Path
import json,csv,re,hashlib
R=Path.cwd();OUT=R/'artifacts/design/detailed';OUT.mkdir(exist_ok=True)
API='FreshFood-API';REPO='FreshFood.Reposistory';classes={};pages=[];ucs={}
def C(name,pkg,role,attrs,ops,basis,scope='shared'):
 rec={'name':name,'package':pkg,'role':role,'attributes':attrs,'operations':ops,'basis':basis,'scope':scope,'status':'Proposed technical design - review required'}
 if name in classes:
  assert classes[name]['package']==pkg,(name,pkg)
 else:classes[name]=rec
 return name
def dep(a,b,label='holds reference',kind='association'):return {'source':a,'target':b,'label':label,'kind':kind}
def page(owner,title,names,edges):pages.append({'owner':owner,'title':title,'classes':list(dict.fromkeys(names)),'edges':edges})
ct='ct: CancellationToken';task=lambda t:f'Task<{t}>'
C('IUnitOfWork',REPO+'.Repository','interface',[],['+ ExecuteAsync(work: TransactionWork, '+ct+'): Task'], 'UC-C06 atomic checkout; UC-C07 atomic cancellation')
C('UnitOfWork',REPO+'.Repository.Implements','class',['- session: IRepositorySession'],['+ UnitOfWork(session: IRepositorySession)','+ ExecuteAsync(work: TransactionWork, '+ct+'): Task'],'Proposed transaction adapter')
C('IRepositorySession',REPO+'.Repository','interface',[],['+ BeginAsync('+ct+'): Task','+ CommitAsync('+ct+'): Task','+ RollbackAsync('+ct+'): Task'],'Shared scoped transaction; no provider choice imposed')
C('PostgreSqlSession',REPO+'.Repository.Implements','class',['- connection: DbConnection','- transaction: DbTransaction?'],['+ PostgreSqlSession(connection: DbConnection)','+ BeginAsync('+ct+'): Task','+ CommitAsync('+ct+'): Task','+ RollbackAsync('+ct+'): Task'],'Existing PostgreSQL; provider factory configured at startup')
C('ICurrentCustomer',API+'.Services','interface',[],['+ RequireCustomerId(): long','+ GetCartIdentity(): CartIdentityDto'],'BR-AUTH-01; guest session variant UC-C03')
C('CurrentCustomer',API+'.Services.Implements','class',['- principal: ClaimsPrincipal'],['+ CurrentCustomer(principal: ClaimsPrincipal)','+ RequireCustomerId(): long','+ GetCartIdentity(): CartIdentityDto'],'Server-authenticated principal; session ownership, not request customerId')
# Each operation tuple maps a documented responsibility to a typed application contract.
specs=[
('UC-C01','browse-search','Catalog','Browse and Search Products','CatalogView',
 [('GetCatalog','query: CatalogQueryDto','CatalogResultDto'),('Search','query: CatalogQueryDto','CatalogResultDto'),('GetProductDetails','productId: long','ProductDetailsDto'),('GetClearance','query: CatalogQueryDto','CatalogResultDto')],
 ['product_categories','products','batch_inventory'],
 ['+ FindActiveAsync(keyword: string?, categoryId: int?, clearanceOnly: bool, '+ct+'): Task<IReadOnlyList<Product>>','+ GetCategoriesAsync('+ct+'): Task<IReadOnlyList<ProductCategory>>','+ GetProductAsync(productId: long, '+ct+'): Task<Product?>','+ GetSellableBatchesAsync(productIds: IReadOnlyList<long>, '+ct+'): Task<IReadOnlyList<BatchInventory>>','+ GetPopularAsync(limit: int, '+ct+'): Task<IReadOnlyList<Product>>'],
 [('CatalogQueryDto',['+ Keyword: string?','+ CategoryId: int?','+ ClearanceOnly: bool']),('CatalogResultDto',['+ Items: IReadOnlyList<ProductSummaryDto>','+ Categories: IReadOnlyList<CategoryDto>','+ Alternatives: IReadOnlyList<ProductSummaryDto>']),('ProductDetailsDto',['+ Product: ProductSummaryDto','+ Description: string?','+ AvailableBatches: IReadOnlyList<BatchOfferDto>']),('ProductSummaryDto',['+ ProductId: long','+ Name: string','+ Unit: string','+ AvailableQuantity: int','+ CurrentPrice: decimal']),('CategoryDto',['+ CategoryId: int','+ Name: string']),('BatchOfferDto',['+ BatchId: long','+ ExpiryDate: DateOnly','+ Price: decimal','+ Clearance: bool'])],[]),
('UC-C03','manage-cart','Cart','Manage Shopping Cart','CartView',
 [('GetCart','identity: CartIdentityDto','CartResultDto'),('ChangeQuantity','request: CartChangeDto','CartResultDto'),('RemoveItem','productId: long','CartResultDto')],
 ['carts','cart_items','products','batch_inventory'],
 ['+ GetAsync(customerId: long?, sessionId: string?, '+ct+'): Task<Cart>','+ GetProductsAsync(ids: IReadOnlyList<long>, '+ct+'): Task<IReadOnlyList<Product>>','+ GetSellableBatchesAsync(ids: IReadOnlyList<long>, '+ct+'): Task<IReadOnlyList<BatchInventory>>','+ SaveAsync(cart: Cart, '+ct+'): Task'],
 [('CartIdentityDto',['+ CustomerId: long? {server resolved}','+ SessionId: string? {server resolved}']),('CartChangeDto',['+ ProductId: long','+ Quantity: int']),('CartResultDto',['+ Lines: IReadOnlyList<CartLineDto>','+ SubTotal: decimal','+ CanCheckout: bool','+ Warnings: IReadOnlyList<string>']),('CartLineDto',['+ ProductId: long','+ Quantity: int','+ AvailableQuantity: int','+ CurrentPrice: decimal','+ LineTotal: decimal'])],[]),
('UC-C05','profile-addresses','Profile','Manage Profile and Addresses','ProfileAddressView',
 [('GetProfile','','ProfileResultDto'),('UpdateProfile','request: ProfileUpdateDto','ProfileResultDto'),('SaveAddress','request: AddressInputDto','AddressDto'),('SetDefaultAddress','addressId: long','ProfileResultDto'),('DeleteAddress','addressId: long','OperationResultDto')],
 ['customers','customer_addresses','orders'],
 ['+ GetCustomerAsync(customerId: long, '+ct+'): Task<Customer>','+ GetAddressesAsync(customerId: long, '+ct+'): Task<IReadOnlyList<CustomerAddress>>','+ HasActiveOrderAsync(customerId: long, addressId: long, '+ct+'): Task<bool>','+ SaveCustomerAsync(customer: Customer, '+ct+'): Task','+ SaveAddressAsync(address: CustomerAddress, '+ct+'): Task','+ DeleteAddressAsync(customerId: long, addressId: long, '+ct+'): Task'],
 [('ProfileResultDto',['+ CustomerId: long','+ FullName: string','+ Phone: string','+ Email: string?','+ Addresses: IReadOnlyList<AddressDto>']),('ProfileUpdateDto',['+ FullName: string','+ Email: string?']),('AddressInputDto',['+ AddressId: long?','+ RecipientName: string','+ RecipientPhone: string','+ StreetAddress: string','+ IsDefault: bool']),('AddressDto',['+ AddressId: long','+ RecipientName: string','+ RecipientPhone: string','+ StreetAddress: string','+ Latitude: decimal','+ Longitude: decimal','+ IsDefault: bool']),('GeoPointDto',['+ Latitude: decimal','+ Longitude: decimal'])],['geocoding']),
('UC-C06','checkout','Checkout','Checkout and Place Order','CheckoutView',
 [('PrepareCheckout','request: CheckoutInputDto','CheckoutSummaryDto'),('PlaceOrder','request: PlaceOrderDto','OrderConfirmationDto'),('CreatePaymentQr','request: PaymentQrRequestDto','PaymentQrDto'),('HandleVerifiedPayment','request: PaymentNoticeDto','PaymentResultDto')],
 ['customers','customer_addresses','carts','cart_items','products','batch_inventory','orders','order_details','order_payments'],
 ['+ GetCheckoutCartAsync(customerId: long, '+ct+'): Task<Cart>','+ GetOwnedAddressAsync(customerId: long, addressId: long, '+ct+'): Task<CustomerAddress>','+ LockFefoBatchesAsync(productIds: IReadOnlyList<long>, '+ct+'): Task<IReadOnlyList<BatchInventory>>','+ SaveOrderAsync(order: Order, '+ct+'): Task','+ SavePaymentOnceAsync(payment: OrderPayment, '+ct+'): Task<bool>','+ ClearCartAsync(cartId: long, '+ct+'): Task'],
 [('CheckoutInputDto',['+ AddressId: long']),('CheckoutSummaryDto',['+ SubTotal: decimal','+ ShippingFee: decimal','+ DistanceKm: decimal','+ Total: decimal','+ Lines: IReadOnlyList<CheckoutLineDto>']),('CheckoutLineDto',['+ ProductId: long','+ BatchId: long','+ Quantity: int','+ UnitPrice: decimal','+ Discount: decimal']),('PlaceOrderDto',['+ AddressId: long','+ PaymentMethod: PaymentMethod','+ CheckoutReference: string','+ IdempotencyKey: string']),('OrderConfirmationDto',['+ OrderId: long','+ OrderNumber: string','+ Status: OrderStatus','+ PaymentStatus: PaymentStatus','+ Total: decimal']),('PaymentQrRequestDto',['+ CheckoutReference: string']),('PaymentQrDto',['+ QrPayload: string','+ ExpiresAt: DateTimeOffset']),('PaymentNoticeDto',['+ RawBody: string','+ Signature: string','+ ProviderReference: string']),('PaymentResultDto',['+ Accepted: bool','+ Duplicate: bool','+ PaymentStatus: PaymentStatus'])],['distance','payment','notification']),
('UC-C07','my-orders','MyOrders','Manage My Orders','MyOrdersView',
 [('GetOrders','','OrderListDto'),('GetOrderDetails','orderId: long','OrderDetailsDto'),('CancelOrder','request: CancelOrderDto','OperationResultDto'),('Reorder','orderId: long','CartResultDto'),('SubmitReview','request: OrderReviewDto','OperationResultDto')],
 ['customers','orders','order_details','customer_addresses','batch_inventory','products','carts','cart_items','order_reviews','audit_logs','delivery_failures','return_receipts','return_receipt_items','return_inspections','refunds','shipping_fee_settlements'],
 ['+ FindOwnedAsync(customerId: long, '+ct+'): Task<IReadOnlyList<Order>>','+ LockOwnedAsync(customerId: long, orderId: long, '+ct+'): Task<Order>','+ GetCurrentBatchesAsync(productIds: IReadOnlyList<long>, '+ct+'): Task<IReadOnlyList<BatchInventory>>','+ SaveCartAsync(cart: Cart, '+ct+'): Task','+ SaveReviewOnceAsync(review: OrderReview, '+ct+'): Task<bool>','+ GetReturnReceiptAsync(orderId: long, '+ct+'): Task<ReturnReceipt?>','+ GetRefundAsync(orderId: long, '+ct+'): Task<Refund?>'],
 [('OrderListDto',['+ Orders: IReadOnlyList<OrderSummaryDto>']),('OrderSummaryDto',['+ OrderId: long','+ OrderNumber: string','+ OrderDate: DateTimeOffset','+ Status: OrderStatus','+ Total: decimal']),('OrderDetailsDto',['+ Order: OrderSummaryDto','+ Address: AddressDto','+ PaymentStatus: PaymentStatus','+ Lines: IReadOnlyList<OrderLineDto>','+ Return: ReturnSummaryDto?']),('OrderLineDto',['+ ProductName: string','+ Quantity: int','+ UnitPrice: decimal','+ LineTotal: decimal']),('CancelOrderDto',['+ OrderId: long','+ Reason: string']),('OrderReviewDto',['+ OrderId: long','+ Rating: int','+ Comment: string?']),('ReturnSummaryDto',['+ FailureReason: string?','+ ReceiptStatus: string?','+ RefundStatus: string?','+ GoodsRefunded: decimal','+ ShippingRefunded: decimal','+ InventoryDisposition: string?'])],['notification'])]
C('OperationResultDto',API+'.DTOs','DTO',['+ Success: bool','+ MessageCode: string'],[],'Existing success/error boundary responses')
ports={
 'geocoding':('IGeocodingGateway','GoogleMapsGeocodingAdapter',['+ ResolveAsync(address: string, '+ct+'): Task<GeoPointDto>'],'GeocodingBoundary; UC-C05'),
 'distance':('IDistanceGateway','GoogleMapsDistanceAdapter',['+ DrivingDistanceAsync(addressId: long, '+ct+'): Task<decimal>'],'DistanceBoundary; BR-DEL-01/02'),
 'payment':('IPaymentGateway','SePayPaymentAdapter',['+ CreateQrAsync(reference: string, amount: decimal, '+ct+'): Task<PaymentQrDto>','+ VerifyNoticeAsync(notice: PaymentNoticeDto, '+ct+'): Task<VerifiedPaymentDto>'],'PaymentBoundary; incoming payments only, no invented refund API'),
 'notification':('INotificationGateway','NotificationAdapter',['+ PublishAsync(message: NotificationDto, '+ct+'): Task'],'NotificationBoundary; channel adapter provider stays configurable')}
for key,(i,impl,ops,basis) in ports.items():
 C(i,API+'.Services','interface',[],ops,basis)
 C(impl,API+'.Services.Implements','adapter',['- http: HttpClient'] if key!='notification' else ['- publisher: INotificationPublisher'],['+ '+impl+'('+('http: HttpClient' if key!='notification' else 'publisher: INotificationPublisher')+')']+ops,basis)
C('INotificationPublisher',API+'.Services','interface',[],['+ SendAsync(message: NotificationDto, '+ct+'): Task'],'Proposed channel seam; no delivery guarantee invented')
C('NotificationDto',API+'.DTOs','DTO',['+ OrderId: long','+ EventCode: string'],[],'Existing customer/staff notification; transaction commits before publish')
C('VerifiedPaymentDto',API+'.DTOs','DTO',['+ ProviderReference: string','+ CheckoutReference: string','+ GoodsAmount: decimal','+ ShippingAmount: decimal','+ VerifiedAt: DateTimeOffset'],[],'Server verified immutable allocation evidence')
# Entities are generated from the existing physical catalog; no new columns.
cat=json.loads((R/'artifacts/design/database/physical-schema-catalog.json').read_text())
entities={'product_categories':'ProductCategory','products':'Product','batch_inventory':'BatchInventory','carts':'Cart','cart_items':'CartItem','customers':'Customer','customer_addresses':'CustomerAddress','orders':'Order','order_details':'OrderDetail','order_reviews':'OrderReview','audit_logs':'AuditLog','order_payments':'OrderPayment','delivery_failures':'DeliveryFailure','return_receipts':'ReturnReceipt','return_receipt_items':'ReturnReceiptItem','return_inspections':'ReturnInspection','refunds':'Refund','shipping_fee_settlements':'ShippingFeeSettlement','delivery_agents':'DeliveryAgent'}
def pascal(s):return ''.join(x.capitalize() for x in s.split('_'))
def typ(t):
 if any(x in t for x in ['DECIMAL','NUMERIC']):return 'decimal'
 if 'BIG' in t:return 'long'
 if any(x in t for x in ['SERIAL','INT']):return 'int'
 if 'BOOL' in t:return 'bool'
 if 'TIMESTAMP' in t:return 'DateTimeOffset'
 if t=='DATE':return 'DateOnly'
 return 'string'
for t in cat:
 if t['name'] not in entities:continue
 attrs=[]
 for c in t['columns']:
  ty={'order_status':'OrderStatus','payment_status':'PaymentStatus','payment_method':'PaymentMethod'}.get(c['name'],typ(c['type']))
  attrs.append('+ '+pascal(c['name'])+': '+ty+' {private set}')
 ops=[]
 if t['name']=='orders':ops=['+ ApplyFulfillment(expected: OrderStatus, target: OrderStatus): void','+ RecordPayment(expected: PaymentStatus, target: PaymentStatus): void']
 if t['name']=='batch_inventory':ops=['+ Reserve(quantity: int): void','+ ReleaseReservation(quantity: int): void']
 if t['name']=='carts':ops=['+ ChangeQuantity(productId: long, quantity: int): void','+ RemoveItem(productId: long): void']
 C(entities[t['name']],REPO+'.Entities','entity',attrs,ops,'Existing data requirements / '+t['name'])
for name,attrs in [('OrderStatus',['PendingUnpaid','PendingPaid','Confirmed','Packing','Shipping','Delivered','Cancelled','DeliveryFailed','Returned']),('PaymentStatus',['Unpaid','Paid','PartiallyRefunded','Refunded']),('PaymentMethod',['Cod','VietQr'])]:C(name,REPO+'.Entities','enumeration',attrs,[],'Stakeholder-confirmed lifecycle / payment revision')
for uc,slug,feat,title,view,ops,table_names,repo_ops,dtos,external in specs:
 basis=f'{uc}; VOPC and analysis sequence scenario pages';ic='I'+feat+'Service';sv=feat+'Service';ctrl=feat+'Controller';ir='I'+feat+'Repository';impl=feat+'Repository'
 sigs=['+ '+n+'Async('+(', '.join(x for x in [args,ct] if x))+'): '+task(ret) for n,args,ret in ops]
 C(ic,API+'.Services','interface',[],sigs,basis,uc)
 deps=[ir]+(['ICurrentCustomer'] if uc!='UC-C01' else [])+(['IUnitOfWork'] if uc!='UC-C01' else [])+([ports[x][0] for x in external])+(['ITransitionExecutor'] if uc in ['UC-C06','UC-C07'] else [])
 C(sv,API+'.Services.Implements','service',['- '+d[1:2].lower()+d[2:]+': '+d for d in deps],['+ '+sv+'('+', '.join(d[1:2].lower()+d[2:]+': '+d for d in deps)+')']+sigs,basis,uc)
 C(ctrl,API+'.Controllers','controller',['- service: '+ic],['+ '+ctrl+'(service: '+ic+')']+[x.replace('Async(','Async(') for x in sigs if 'HandleVerifiedPayment' not in x],basis,uc)
 C(ir,REPO+'.Repository','interface',[],repo_ops,basis,uc)
 C(impl,REPO+'.Repository.Implements','repository',['- session: IRepositorySession'],['+ '+impl+'(session: IRepositorySession)']+repo_ops,basis,uc)
 for name,attrs in dtos:C(name,API+'.DTOs','DTO',attrs,[],basis,uc)
 names=[ctrl,ic,sv,ir,impl]+(['ICurrentCustomer'] if uc!='UC-C01' else [])+(['IUnitOfWork'] if uc!='UC-C01' else [])+[ports[x][0] for x in external]+(['ITransitionExecutor'] if uc in ['UC-C06','UC-C07'] else [])
 edges=[dep(ctrl,ic),dep(sv,ic,'implements','realization'),dep(impl,ir,'implements','realization')]+[dep(sv,d) for d in deps]
 page(uc,'Application Services and Constructor Injection',names,edges)
 ent=[entities[t] for t in table_names]
 for ix in range(0,len(ent),4):
  group=ent[ix:ix+4];links=[]
  pairs=[('Cart','CartItem','1 : 0..*'),('Order','OrderDetail','1 : 1..*'),('Order','DeliveryFailure','1 : 0..1'),('ReturnReceipt','ReturnReceiptItem','1 : 0..*'),('ReturnReceiptItem','ReturnInspection','1 : 0..*'),('Order','Refund','1 : 0..1'),('Customer','CustomerAddress','1 : 0..*'),('ProductCategory','Product','1 : 0..*'),('Product','BatchInventory','1 : 0..*')]
  for a,b,label in pairs:
   if a in group and b in group:links.append(dep(a,b,label,'association'))
  page(uc,'Participating Entities '+str(ix//4+1),group,links)
 for ix in range(0,len(dtos),6):page(uc,'Request and Response Contracts '+str(ix//6+1),[x[0] for x in dtos[ix:ix+6]],[])
 # Frontend uses ordinary concrete references; dependency injection is backend-only.
 web=feat+'Page';wc=feat+'ApiClient';mv=feat+'ViewModel';mc=feat+'ApiModel'
 def client_sig(sig,mobile=False):
  sig=sig.replace(', ct: CancellationToken','').replace('ct: CancellationToken','')
  sig=sig.replace('Task<','Future<' if mobile else 'Promise<')
  return re.sub(r'\blong\b','int',sig) if mobile else re.sub(r'\b(long|int)\b','number',sig)
 exposed=[(n,args,ret) for n,args,ret in ops if n!='HandleVerifiedPayment']
 web_sigs=[client_sig(x) for x in sigs if 'HandleVerifiedPayment' not in x]
 mobile_sigs=[client_sig(x,True) for x in sigs if 'HandleVerifiedPayment' not in x]
 state_type={'UC-C01':'CatalogResultDto','UC-C03':'CartResultDto','UC-C05':'ProfileResultDto','UC-C06':'CheckoutSummaryDto','UC-C07':'OrderListDto'}[uc]
 web_events=['+ On'+n+'Async('+re.sub(r'\b(long|int)\b','number',args)+'): Promise<void>' for n,args,ret in exposed]
 mobile_events=['+ On'+n+'('+re.sub(r'\blong\b','int',args)+'): Future<void>' for n,args,ret in exposed]
 if uc=='UC-C06':
  web_events+=['+ OnPaymentStateChanged(result: PaymentResultDto): void']
  mobile_events+=['+ OnPaymentStateChanged(result: PaymentResultDto): void']
 if uc=='UC-C07':
  web_events+=['+ ShowCancellationConfirmation(orderId: number): void']
  mobile_events+=['+ ShowCancellationConfirmation(orderId: int): void']
 C(web,'FreshFood-Customer-Web.Pages','boundary',['- api: '+wc,'- state: '+state_type+'?','- isBusy: boolean','- errorCode: string?'],['+ Render(): ReactNode']+web_events,view+' Web rendering/events; ordinary reference to concrete CallService class; no DI',uc)
 C(wc,'FreshFood-Customer-Web.CallService','adapter',['- http: HttpClient'],web_sigs,'Authenticated HTTPS/JSON and boundary serialization; ordinary frontend object/module lifecycle, no DI',uc)
 C(view,'FreshFood-App.Views','boundary',['- model: '+mv],['+ Build(): Widget']+mobile_events,view+' Mobile rendering/events through ordinary ViewModel association; no DI',uc)
 C(mv,'FreshFood-App.ViewModels','viewmodel',['- api: '+mc,'- state: '+state_type+'?','- isBusy: bool','- errorCode: string?'],mobile_sigs,'MVVM state and orchestration; ordinary association to concrete API model; no DI',uc)
 C(mc,'FreshFood-App.Models','adapter',['- http: HttpClient'],mobile_sigs,'Authenticated HTTPS/JSON; ordinary frontend lifecycle; no DI or backend type imports',uc)
 page(uc,'Web View Classes',[web,ctrl,wc,ic],[dep(web,wc,'api'),dep(wc,ctrl,'HTTPS / JSON','remote'),dep(ctrl,ic,'service')])
 page(uc,'Mobile View Classes',[view,mv,mc,ctrl],[dep(view,mv,'model'),dep(mv,mc,'api'),dep(mc,ctrl,'HTTPS / JSON','remote')])
 ucs[uc]={'slug':slug,'feature':feat,'title':title,'analysis_view':view,'operations':ops,'service':sv,'controller':ctrl,'entities':ent,'ports':external}
# State transition contracts carry trusted server-created snapshots, not request-bound authorization facts.
C('TransitionCommand',API+'.DTOs','DTO',['+ TransitionId: string','+ AggregateId: long','+ EventId: string','+ ExpectedVersion: string?','+ Reason: string?'],[],'Proposed server command envelope; event IDs deduplicate')
C('TransitionSnapshot',API+'.DTOs','DTO',['+ WorkflowNode: string {transient UML position}','+ AggregateId: long','+ CheckoutReference: string?','+ CustomerId: long {server resolved}','+ AddressId: long?','+ PaymentMethod: PaymentMethod?','+ PlannedLines: IReadOnlyList<CheckoutLineDto>','+ FulfillmentState: string','+ PaymentState: string','+ RefundState: string?','+ ActorId: string {trusted server value}','+ GuardFacts: GuardFactsDto {trusted server value}'],[],'Built under lock from authoritative records; never client-bound')
C('GuardFactsDto',API+'.DTOs','DTO',['+ FirstOrder: bool','+ PhoneConfirmed: bool','+ VerifiedPayment: bool','+ CompleteReceipt: bool','+ ConfirmedCause: string?','+ CapturedGoods: decimal','+ CapturedShipping: decimal','+ SettledRefund: decimal'],[],'Projection of existing authoritative facts')
C('TransitionResult',API+'.DTOs','DTO',['+ TransitionId: string','+ Target: string','+ Applied: bool','+ Duplicate: bool','+ FailureCode: string?'],[],'No false completion for an unverified payout')
C('IStateTransition',API+'.Services','interface',[],['+ Id: string {get}','+ CanExecute(snapshot: TransitionSnapshot, command: TransitionCommand): bool','+ ExecuteAsync(snapshot: TransitionSnapshot, command: TransitionCommand, '+ct+'): Task<TransitionResult>'],'User: one class per state transition')
C('ITransitionExecutor',API+'.Services','interface',[],['+ ExecuteAsync(command: TransitionCommand, '+ct+'): Task<TransitionResult>','+ ExecuteInCurrentTransactionAsync(snapshot: TransitionSnapshot, command: TransitionCommand, '+ct+'): Task<TransitionResult>'],'Stable dispatch by transition ID; constructor injection')
C('TransitionExecutor',API+'.Services.Implements','class',['- transitions: IReadOnlyDictionary<string, IStateTransition>','- unitOfWork: IUnitOfWork','- repository: IOrderLifecycleRepository'],['+ TransitionExecutor(transitions: IEnumerable<IStateTransition>, unitOfWork: IUnitOfWork, repository: IOrderLifecycleRepository)','+ ExecuteAsync(command: TransitionCommand, '+ct+'): Task<TransitionResult>','+ ExecuteInCurrentTransactionAsync(snapshot: TransitionSnapshot, command: TransitionCommand, '+ct+'): Task<TransitionResult>'],'Lock authoritative aggregate; validate guards; apply once atomically')
lifeops=['+ LockOrderAsync(orderId: long, '+ct+'): Task<Order>','+ LoadSnapshotAsync(orderId: long, '+ct+'): Task<TransitionSnapshot>','+ SaveAsync(order: Order, '+ct+'): Task','+ RecordEventOnceAsync(aggregateId: long, eventId: string, transitionId: string, '+ct+'): Task<bool>']
lifeops += ['+ SaveOrderLinesAsync(order: Order, lines: IReadOnlyList<OrderDetail>, '+ct+'): Task',
 '+ SavePaymentOnceAsync(payment: OrderPayment, '+ct+'): Task<bool>',
 '+ SaveFailureAsync(failure: DeliveryFailure, '+ct+'): Task',
 '+ SaveReceiptAsync(receipt: ReturnReceipt, items: IReadOnlyList<ReturnReceiptItem>, '+ct+'): Task',
 '+ SaveRefundOnceAsync(refund: Refund, '+ct+'): Task<bool>',
 '+ SaveShippingSettlementAsync(settlement: ShippingFeeSettlement, '+ct+'): Task',
 '+ LockReservedBatchesAsync(orderId: long, '+ct+'): Task<IReadOnlyList<BatchInventory>>',
 '+ SaveBatchesAsync(batches: IReadOnlyList<BatchInventory>, '+ct+'): Task',
 '+ AppendAuditAsync(audit: AuditLog, '+ct+'): Task']
# Repository cannot return API DTOs. Snapshot construction belongs in executor.
lifeops[1]='+ LoadLifecycleAsync(orderId: long, '+ct+'): Task<OrderLifecycleRecords>'
C('OrderLifecycleRecords',REPO+'.Repository','record',['+ Order: Order','+ Failure: DeliveryFailure?','+ Receipt: ReturnReceipt?','+ Refund: Refund?','+ Payments: IReadOnlyList<OrderPayment>'],[],'Repository-owned entity bundle, not API DTO')
C('IOrderLifecycleRepository',REPO+'.Repository','interface',[],lifeops,'Existing order/payment/return/refund records')
C('OrderLifecycleRepository',REPO+'.Repository.Implements','repository',['- session: IRepositorySession'],['+ OrderLifecycleRepository(session: IRepositorySession)']+lifeops,'Proposed persistence seam; event-dedup storage choice pending review')
C('IPayoutPort',API+'.Services','interface',[],['+ RequestAsync(refundId: long, '+ct+'): Task<PayoutOutcomeDto>'],'Unresolved outbound provider. Fail closed when not configured.')
C('PayoutOutcomeDto',API+'.DTOs','DTO',['+ Outcome: string','+ ProviderReference: string?','+ SettledAmount: decimal?'],[],'Provider result does not imply settlement unless verified')
C('PaymentNoticeHandler',API+'.Services.Implements','adapter',['- checkout: ICheckoutService','- payment: IPaymentGateway'],['+ PaymentNoticeHandler(checkout: ICheckoutService, payment: IPaymentGateway)','+ HandleAsync(notice: PaymentNoticeDto, '+ct+'): Task<PaymentResultDto>'],'PaymentBoundary callback to CheckoutService through injected interface; no CheckoutController relation')
page('shared','Transaction and Gateway Adapters',['IUnitOfWork','UnitOfWork','IRepositorySession','PostgreSqlSession','ICurrentCustomer','CurrentCustomer'],[dep('UnitOfWork','IUnitOfWork','implements','realization'),dep('UnitOfWork','IRepositorySession'),dep('PostgreSqlSession','IRepositorySession','implements','realization'),dep('CurrentCustomer','ICurrentCustomer','implements','realization')])
for key,(iface,impl,_,_) in ports.items():page('shared','External Adapter '+key,[iface,impl]+(['PaymentNoticeHandler','ICheckoutService'] if key=='payment' else []),[dep(impl,iface,'implements','realization')]+([dep('PaymentNoticeHandler','ICheckoutService'),dep('PaymentNoticeHandler',iface)] if key=='payment' else []))
page('shared','State Transition Dispatch',['IStateTransition','ITransitionExecutor','TransitionExecutor','IOrderLifecycleRepository','OrderLifecycleRepository','OrderLifecycleRecords','IUnitOfWork'],[dep('TransitionExecutor','ITransitionExecutor','implements','realization'),dep('TransitionExecutor','IStateTransition','injected collection'),dep('TransitionExecutor','IUnitOfWork'),dep('TransitionExecutor','IOrderLifecycleRepository'),dep('OrderLifecycleRepository','IOrderLifecycleRepository','implements','realization')])
page('shared','Transition Command and Trusted Snapshot',['TransitionCommand','TransitionSnapshot','GuardFactsDto','TransitionResult','IPayoutPort','PayoutOutcomeDto'],[])
transitions=list(csv.DictReader((R/'artifacts/analysis/order-state-traceability.csv').open(encoding='utf-8-sig')))
names=['AcceptOrderTransition','EnterPendingUnpaidTransition','EnterPendingPaidTransition','ApprovePendingUnpaidTransition','ApprovePendingPaidTransition','StartPackingTransition','DispatchOrderTransition','DeliverOrderTransition','FailDeliveryTransition','ReceiveReturnedOrderTransition','CancelPendingUnpaidTransition','CancelPendingPaidTransition','CancelConfirmedOrderTransition','CompleteDeliveredFulfillmentTransition','CompleteReturnedFulfillmentTransition','CompleteCancelledFulfillmentTransition','ObserveRefundCandidateTransition','StartEligibleRefundTransition','ConfirmRefundSettlementTransition','RecordUncertainRefundTransition','InitializeUnpaidPaymentTransition','CaptureVerifiedPaymentTransition','MarkPartialRefundTransition','MarkFullRefundTransition']
assert len(names)==len(transitions)==24
for r,name in zip(transitions,names):
 r['class']=name;r['scope']='UC-C06' if r['id'] in ['I00','T01u','T01p','P01','P02'] else 'UC-C07' if r['id'] in ['T08u','T08p','T09'] else 'shared staff / return / financial lifecycle'
 attrs=['+ Id: string = '+r['id'],'+ Source: string = '+r['source'],'+ Target: string = '+r['target'],'- repository: IOrderLifecycleRepository']
 deps=['IOrderLifecycleRepository']+(['ICheckoutRepository'] if r['id']=='I00' else [])+(['IPayoutPort'] if r['id']=='R02' else [])
 if r['id']=='I00':attrs.append('- checkoutRepository: ICheckoutRepository')
 if r['id']=='R02':attrs.append('- payout: IPayoutPort')
 C(name,API+'.Services.Implements','transition',attrs,['+ '+name+'('+', '.join(d[1:2].lower()+d[2:]+': '+d for d in deps)+')','+ CanExecute(snapshot: TransitionSnapshot, command: TransitionCommand): bool','+ ExecuteAsync(snapshot: TransitionSnapshot, command: TransitionCommand, '+ct+'): Task<TransitionResult>'],r['basis']+'; '+r['label'],r['scope'])
for ix in range(0,len(transitions),3):
 group=transitions[ix:ix+3];ns=[x['class'] for x in group];page('transitions','One Class per Transition '+str(ix//3+1),['IStateTransition']+ns+[ 'IOrderLifecycleRepository'],[dep(n,'IStateTransition','implements','realization') for n in ns]+[dep(n,'IOrderLifecycleRepository') for n in ns])
C('TransactionWork',REPO+'.Repository','delegate',[],['+ InvokeAsync(ct: CancellationToken): Task'],'Proposed async transaction callback; repository-owned type')
C('ConfiguredNotificationPublisher',API+'.Services.Implements','adapter',['- http: HttpClient'],['+ ConfiguredNotificationPublisher(http: HttpClient)','+ SendAsync(message: NotificationDto, '+ct+'): Task'],'Configured notification channel; failures surfaced, no guarantee of delivery')
C('UnconfiguredPayoutAdapter',API+'.Services.Implements','adapter',[],['+ RequestAsync(refundId: long, '+ct+'): Task<PayoutOutcomeDto>'],'Blocks outgoing payout while provider/contract remains TBD; never marks settlement succeeded')
page('shared','Unresolved Provider and Notification Seams',['IPayoutPort','UnconfiguredPayoutAdapter','INotificationPublisher','ConfiguredNotificationPublisher','TransactionWork'],[dep('UnconfiguredPayoutAdapter','IPayoutPort','implements','realization'),dep('ConfiguredNotificationPublisher','INotificationPublisher','implements','realization')])
for uc in ['UC-C06','UC-C07']:
 handlers=[x['class'] for x in transitions if x['scope']==uc]
 for ix in range(0,len(handlers),3):
  group=handlers[ix:ix+3];service=ucs[uc]['service'];ns=[service,'ITransitionExecutor','TransitionExecutor','IStateTransition']+group
  page(uc,'State Transition Realizations '+str(ix//3+1),ns,[dep(service,'ITransitionExecutor'),dep('TransitionExecutor','ITransitionExecutor','implements','realization'),dep('TransitionExecutor','IStateTransition','transitions')]+[dep(n,'IStateTransition','implements','realization') for n in group])
page('shared','Shared Results and Delivery Agent',['DeliveryAgent','NotificationDto','OperationResultDto','VerifiedPaymentDto'],[])
# Explicit composition root: constructor injection and lifetimes, no service locator in consumers.
C('ApiCompositionRoot',API,'composition root',[],['+ ConfigureServices(services: IServiceCollection): void','+ RegisterTransitionHandlers(services: IServiceCollection): void'],'Application startup owns all concrete choices; scoped business/repository/UoW objects')
page('shared','Composition Root and Domain Enumerations',['ApiCompositionRoot','OrderStatus','PaymentStatus','PaymentMethod'],[])
# Surface View realizations first so opening a use-case master shows the package split immediately.
ordered=[]
for uc in ucs:
 own=[p for p in pages if p['owner']==uc]
 ordered += [p for p in own if p['title'].startswith('Web View')] + [p for p in own if p['title'].startswith('Mobile View')] + [p for p in own if not p['title'].startswith(('Web View','Mobile View'))]
pages=ordered+[p for p in pages if p['owner'] not in ucs]
from refine_vopc_realization import refine
architecture_alignment=refine(classes,pages,ucs,C,dep,page)
from refine_dto_entity_usage import refine_usage
usage_notation=refine_usage(classes,pages,ucs)
model={'version':'0.3','date':'2026-10-31','status':'Draft for Design Review - not implementation baseline','scope':ucs,'classes':classes,'pages':pages,'transitions':transitions,'architecture_alignment':architecture_alignment,'presentation_rules':{'di_scope':'backend only','show_packages':False,'stored_reference_notation':'association','dto_entity_usage':usage_notation,'implementation_notation':'realization','frontend_lifecycle':'ordinary concrete references; no constructor injection'}}
(OUT/'detailed-class-model.json').write_text(json.dumps(model,indent=2),encoding='utf-8')
print('Prepared',len(classes),'classes,',len(pages),'diagram pages,',len(transitions),'transition handlers')

# Preserve the explicitly selected project pattern on future model rebuilds.
import subprocess as _subprocess, sys as _sys
_selection=Path('artifacts/design/detailed/selected-design-solutions.json')
if _selection.exists() and json.loads(_selection.read_text(encoding='utf-8')).get('state_machine')=='table-driven':
 _subprocess.run([_sys.executable,'scripts/modeling/revise_state_machine_design_model.py'],check=True)
