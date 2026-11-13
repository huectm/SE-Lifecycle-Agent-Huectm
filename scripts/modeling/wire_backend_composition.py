raise SystemExit('Historical Node.js generator retired after the explicit ASP.NET Core C# selection. Maintain the current C# source and detailed-class-model.json; do not regenerate the former backend.')
﻿from pathlib import Path
import json,re,csv,os
P=json.loads(Path('scratch/backend-mapping-paths.json').read_text());m=json.loads(Path('artifacts/design/detailed/detailed-class-model.json').read_text(encoding='utf-8-sig'))
def put(n,s):Path(P[n]).write_text(s.strip()+'\n',encoding='utf-8')
# Correct physical enum codecs at the repository boundary; keep PascalCase domain enums.
p=Path('src/FreshFood.Reposistory/Repository/Implements/sql.js');s=p.read_text();s=s.replace("export function record(row)","const decode={PENDING_UNPAID:'PendingUnpaid',PENDING_PAID:'PendingPaid',CONFIRMED:'Confirmed',PACKING:'Packing',SHIPPING:'Shipping',DELIVERED:'Delivered',CANCELLED:'Cancelled',DELIVERY_FAILED:'DeliveryFailed',RETURNED:'Returned',UNPAID:'Unpaid',PAID:'Paid',PARTIALLY_REFUNDED:'PartiallyRefunded',REFUNDED:'Refunded',COD:'Cod',VIETQR:'VietQr'};\nexport function encode(value) {return Object.entries(decode).find(([,v])=>v===value)?.[0]??value;}\nexport function record(row)")
s=s.replace("return [key,k.endsWith", "if(['order_status','payment_status','payment_method'].includes(k))v=decode[v]??v;return [key,k.endsWith")
s=s.replace("b.sale_status=$2","b.sale_status IN ('ACTIVE','DISCOUNTED')").replace("[ids,'Available']","[ids]")
p.write_text(s,encoding='utf-8')
for n in ['CatalogRepository','ProfileRepository','CheckoutRepository','OrderLifecycleRepository']:
 p=Path(P[n]);s=p.read_text().replace("import { rows,", "import { encode, rows,")
 s=s.replace("b.sale_status='Available'", "b.sale_status IN ('ACTIVE','DISCOUNTED')").replace("('Delivered','Cancelled','Returned')","('DELIVERED','CANCELLED','RETURNED')")
 s=s.replace("order.PhoneConfirmationStatus=order.IsFirstOrder&&order.PaymentStatus==='Unpaid'?'Pending':'NotRequired'", "order.PhoneConfirmationStatus='NOT_CONTACTED'")
 s=s.replace('order.PaymentMethod,order.PaymentStatus,order.OrderStatus','encode(order.PaymentMethod),encode(order.PaymentStatus),encode(order.OrderStatus)')
 s=s.replace('[order.OrderStatus,order.PaymentStatus,','[encode(order.OrderStatus),encode(order.PaymentStatus),')
 p.write_text(s,encoding='utf-8')
p=Path('src/FreshFood-API/Services/Implements/shared.js');s=p.read_text().replace("batch.SaleStatus === 'Available'","['ACTIVE','DISCOUNTED'].includes(batch.SaleStatus)");p.write_text(s)
p=Path(P['DistanceCalculator']);s=p.read_text().replace('GetDrivingDistanceKmAsync','DrivingDistanceAsync');p.write_text(s)
put('FefoBatchSpecification','''export class FefoBatchSpecification { Criteria(asOf) { if(!(asOf instanceof Date)||Number.isNaN(+asOf))throw new TypeError('Valid asOf required');return {ActiveProductsOnly:true,AsOf:asOf,MinimumAvailable:1,SortKeys:['expiry_date ASC','batch_id ASC'],LockForUpdate:true}; } }''')
put('ConfiguredNotificationPublisher','''export class ConfiguredNotificationPublisher { constructor(transport) {this.transport=transport;} async SendAsync(message,signal) {return this.transport.SendAsync('notifications:publish',message,signal);} }''')
put('NotificationAdapter','''export class NotificationAdapter { constructor(publisher) {this.publisher=publisher;} async PublishAsync(message,signal) {return this.publisher.SendAsync(message,signal);} }''')
put('UnconfiguredPayoutAdapter','''export class UnconfiguredPayoutAdapter { async RequestAsync(refundId,signal) {signal?.throwIfAborted();throw Object.assign(new Error('Outgoing payout provider requires approval'),{code:'PAYOUT_PROVIDER_TBD',status:503});} }''')
put('GoogleMapsGeocodingAdapter','''export class GoogleMapsGeocodingAdapter {constructor(transport){this.transport=transport;}async ResolveAsync(address,signal){return this.transport.SendAsync('maps:geocode',{Address:address},signal);} }''')
put('GoogleMapsDistanceAdapter','''export class GoogleMapsDistanceAdapter {constructor(transport){this.transport=transport;}async DrivingDistanceAsync(addressId,signal){return this.transport.SendAsync('maps:distance',{AddressId:addressId},signal);} }''')
put('SePayPaymentAdapter','''export class SePayPaymentAdapter {constructor(transport){this.transport=transport;}async CreateQrAsync(reference,amount,signal){return this.transport.SendAsync('sepay:create-qr',{Reference:reference,Amount:amount.toString()},signal);}async VerifyNoticeAsync(notice,signal){return this.transport.SendAsync('sepay:verify-notice',notice,signal);} }''')
put('RegistrationMap','''export class RegistrationMap {
  constructor(){this.bindings=new Map();this.many=new Map();this.cache=new Map();this.resolving=new Set();}
  Bind(token,factory){if(this.bindings.has(token))throw new Error('Duplicate binding: '+token);this.bindings.set(token,factory);}
  BindMany(token,factories){if(this.many.has(token))throw new Error('Duplicate collection: '+token);this.many.set(token,factories);}
  Resolve(token){if(this.cache.has(token))return this.cache.get(token);const f=this.bindings.get(token);if(!f)throw new Error('Missing binding: '+token);if(this.resolving.has(token))throw new Error('Circular binding: '+token);this.resolving.add(token);try{const value=f();this.cache.set(token,value);return value;}finally{this.resolving.delete(token);}}
  ResolveMany(token){return (this.many.get(token)??[]).map(f=>f());}
}''')
# Compile binding factories directly from approved constructor contracts and DI registry.
api=Path('src/FreshFood-API');catalog=[]
for n,p in P.items():
 path=os.path.relpath(p,api).replace('\\','/');path=path if path.startswith('.') else './'+path
 catalog.append(f"import {{ {n} }} from {json.dumps(path)};")
catalog.append('export const classes = {'+', '.join(P)+'};')
(api/'class-catalog.js').write_text('\n'.join(catalog)+'\n',encoding='utf-8')
bindings=list(csv.DictReader(Path('artifacts/design/detailed/dependency-injection-registrations.csv').open(encoding='utf-8-sig')))
constructors={}
for n,c in m['classes'].items():
 ctor=next((o for o in c['operations'] if o.startswith('+ '+n+'(')),None)
 if ctor:constructors[n]=[x.split(':',1)[1].strip() for x in re.search(r'\((.*?)\)',ctor)[1].split(',') if x.strip()]
(api/'bindings.js').write_text('export const bindings = '+json.dumps(bindings,indent=2)+';\nexport const constructors = '+json.dumps(constructors,indent=2)+';\n',encoding='utf-8')
put('ApiCompositionRoot','''import { classes } from './class-catalog.js';
import { bindings, constructors } from './bindings.js';
export class ApiCompositionRoot {
  ConfigureServices(services) {
    const construct=name=>new classes[name](...(constructors[name]??[]).map(type=>type==='ReadonlyArray<IStateTransition>'?services.ResolveMany('IStateTransition'):services.Resolve(type)));
    for(const b of bindings.filter(b=>b.Contract!=='IStateTransition'))services.Bind(b.Contract,()=>construct(b.Implementation));
    for(const name of ['CatalogController','CartController','ProfileController','CheckoutController','MyOrdersController','PaymentNoticeHandler'])services.Bind(name,()=>construct(name));
    this.RegisterTransitionHandlers(services);
  }
  RegisterTransitionHandlers(services) {
    services.BindMany('IStateTransition',bindings.filter(b=>b.Contract==='IStateTransition').map(b=>()=>new classes[b.Implementation](...(constructors[b.Implementation]??[]).map(type=>services.Resolve(type)))));
  }
}''')
print('Wired DI from approved registry; fixed physical enum translation and gateway signatures')
