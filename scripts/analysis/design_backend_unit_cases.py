"""Unit-test design only; no generated xUnit scripts and no execution."""
from pathlib import Path
import json,csv,re,itertools,collections
OUT=Path('artifacts/testing/test-design/backend-unit');OUT.mkdir(parents=True,exist_ok=True)
source=json.loads(Path('artifacts/testing/test-design/backend-unit-method-inventory.json').read_text())
UCS=['UC-C01','UC-C03','UC-C05','UC-C06','UC-C07']
FR={'UC-C01':['FR-BRW-01','FR-BRW-02','FR-BRW-03'],'UC-C03':['FR-CRT-01','FR-CRT-02'],'UC-C05':['FR-PRF-01','FR-PRF-02'],'UC-C06':['FR-PAY-01','FR-ORD-01','FR-ORD-02','FR-ORD-03','FR-PAY-02'],'UC-C07':['FR-MYO-01','FR-MYO-02','FR-MYO-03','FR-MYO-04']}
FIX={
'CUSTOMER':{'CustomerId':'7','Authenticated':True,'claim':'customer_id=7','untrustedHeader':'X-Customer-Id=99 grants no identity'},
'CATALOG':{'ProductId':'1','ProductName':'Greens','IsActive':True,'CategoryId':1,'BatchId':'1','RetailPrice':'10000','DiscountRate':0,'SaleStatus':'ACTIVE','ExpiryDate':'2099-01-01','CurrentStock':10,'ReservedStock':3},
'CART':{'CartId':'1','CustomerId':'7','Items':[{'ProductId':'1','Quantity':2}]},
'ADDRESS':{'AddressId':'2','CustomerId':'7','RecipientName':'Tester','RecipientPhone':'0912345678','StreetAddress':'Test street','Latitude':10,'Longitude':105,'IsDefault':False},
'CHECKOUT':{'AddressId':'2','PaymentMethod':'Cod','CheckoutReference':'ref-001','IdempotencyKey':'key-001','DistanceKm':1,'SubTotal':'20000','ShippingFee':'20000','Total':'40000'},
'ORDER':{'OrderId':'1','CustomerId':'7','OrderStatus':'PendingUnpaid','PaymentStatus':'Unpaid','SubTotal':'20000','TotalAmount':'40000','ShippingFee':'20000','Details':[{'ProductId':'1','BatchId':'1','Quantity':2,'UnitPrice':'10000','LineTotal':'20000'}]},
'FEFO':{'batches':[{'BatchId':'2','ExpiryDate':'2099-01-03','CurrentStock':3,'ReservedStock':1},{'BatchId':'1','ExpiryDate':'2099-01-01','CurrentStock':5,'ReservedStock':0}],'Quantity':6,'expectedLines':'batch 1:5 units, then batch 2:1 unit; SubTotal=60000'},
'SESSION':{'Active':True,'QueryResult':'typed sentinel rows arranged per method','calls':'Capture parameterized SQL, ordered arguments, token and call order. No live DB.'},
'NOTICE':{'RawBody':'{ "amount" : 100,\n "description":"Thanh toÃƒÆ’Ã†â€™Ãƒâ€ Ã¢â‚¬â„¢ÃƒÆ’Ã¢â‚¬Å¡Ãƒâ€šÃ‚Â¡n" }\n','Signature':'Apikey test-signature','ProviderReference':'provider-123'},
'CLOCK':{'today':'Capture UTC date at Arrange for before/on/after expiry cases; detect UTC-day rollover. Explicit asOf when accepted. No assumed clock injection seam.'}}
manual=collections.defaultdict(list)
def add(key,title,data,expected,t='N',error='',effects='',technique='Equivalence partitioning',gap=''):
 manual[key].append(dict(title=title,data=data,expected=expected,inputType=t,exception=error,sideEffects=effects,technique=technique,gap=gap,targets=[]))
# Domain-specific, independently calculated expected values.
for distance,result in [(-.001,'OUTSIDE_DELIVERY_AREA'),(0,'10000'),(.999,'10000'),(1,'20000'),(2.999,'20000'),(3,'30000'),(10,'30000'),(10.001,'OUTSIDE_DELIVERY_AREA')]:
 add('DeliveryFeePolicy.Quote','Distance '+str(distance),{'distanceKm':distance},'VndAmount='+result if result.isdigit() else 'Reject outside service area','B','' if result.isdigit() else result,'No mutation','Boundary value analysis')
for rate,result in [(0,'10000'),(9.99,'INVALID_DISCOUNT'),(10,'9000'),(50,'5000'),(50.01,'INVALID_DISCOUNT'),(10.001,'INVALID_DISCOUNT')]:
 add('BatchPricingPolicy.Quote','Discount '+str(rate),{'RetailPrice':'10000','DiscountRate':rate},'VndAmount='+result if result.isdigit() else 'Reject invalid discount','B','' if result.isdigit() else result,'Batch unchanged','Boundary value analysis')
add('BatchPricingPolicy.Quote','Fractional VND has no approved rounding',{'RetailPrice':'101','DiscountRate':10},'Reject; no invented rounding','A','ROUNDING_POLICY_TBD / 503',technique='Error guessing')
for key in ['VndAmount..ctor','VndAmount.FromUnits']:
 for value,ok in [('0',True),('1',True),('999999999999999999',True),('-1',False),('1000000000000000000',False),('0.5',False)]:
  add(key,'Amount '+value,{'units':value},'Units='+value if ok else 'Reject invalid amount','B','' if ok else 'INVALID_VND_AMOUNT',technique='Boundary value analysis')
for key in ['VndAmount.ToWire','VndAmount.ToString']:
 for v in ['0','10000','999999999999999999']:add(key,'Exact wire '+v,{'Units':v},'Exactly "'+v+'" in every culture','B',technique='Precision error guessing')
for a,b,result in [('0','0','0'),('10000','20000','30000'),('999999999999999999','1','INVALID_VND_AMOUNT')]:
 add('VndAmount.Add','Add '+a+' + '+b,{'left':a,'right':b},'Units='+result if result.isdigit() else 'Reject invalid amount','B','' if result.isdigit() else result)
for key,error in [('BatchInventory.Reserve','INSUFFICIENT_STOCK'),('BatchInventory.ReleaseReservation','RESERVATION_INCONSISTENT')]:
 for q in [-1,0,1,3,7,8]:
  good=q>0 and q<=(7 if key.endswith('.Reserve') else 3)
  add(key,'Quantity '+str(q),{'CurrentStock':10,'ReservedStock':3,'quantity':q},'ReservedStock='+str(3+q if key.endswith('.Reserve') else 3-q) if good else 'Reject; ReservedStock stays 3','B','' if good else error,technique='Boundary / invariant')
for key in ['ServiceRules.Id','SqlRepository.Id']:
 for v,ok in [('1',True),('9223372036854775807',True),('0',False),('-1',False),('9223372036854775808',False),('abc',False),('',False)]:
  add(key,'Identifier '+repr(v),{'value':v},('Return original string' if key.startswith('Service') else 'Return parsed long') if ok else 'Reject ID','B','' if ok else 'INVALID_ID')
for v,ok in [('',False),(' ',False),('k',True),('k'*128,True),('k'*129,False)]:
 add('ServiceRules.Key','Key length '+str(len(v)),{'value':v},'Return unchanged key' if ok else 'Reject reference','B','' if ok else 'INVALID_REFERENCE')
for rating in [0,1,5,6]:
 add('MyOrdersService.SubmitReviewAsync','Rating '+str(rating),{'OrderStatus':'Delivered','Rating':rating,'SaveReviewOnce':True},'REVIEW_SAVED' if 1<=rating<=5 else 'Reject before write','B','' if 1<=rating<=5 else 'RATING_OUT_OF_RANGE')
add('MyOrdersService.SubmitReviewAsync','Duplicate review',{'OrderStatus':'Delivered','Rating':5,'SaveReviewOnce':False},'Reject duplicate','A','REVIEW_ALREADY_EXISTS / 409','No second review','Error guessing')
add('MyOrdersService.SubmitReviewAsync','Not delivered',{'OrderStatus':'Shipping','Rating':5},'Reject review','A','REVIEW_REQUIRES_DELIVERED / 409','No review write')
for key in ['CheckoutService.Allocate','CheckoutService.PrepareCheckoutAsync']:
 add(key,'FEFO split across batches',{'fixture':'FEFO','ProductId':'1','RetailPrice':'10000','SaleStatus':'ACTIVE'},'Batch1 qty5 then batch2 qty1; SubTotal="60000"','N',effects='No accepted order or partial stock commit',technique='Decision table')
 add(key,'Insufficient all-line stock',{'Quantity':8,'Available':7},'Reject all lines','A','INSUFFICIENT_STOCK / 409','No partial commit','Error guessing')
add('CheckoutService.PrepareCheckoutAsync','Summary calculation',{'fixture':'CHECKOUT','Quantity':2,'Price':'10000'},'SubTotal="20000", ShippingFee="20000", Total="40000"')
add('CheckoutService.PlaceOrderAsync','COD acceptance',{'fixture':'CHECKOUT','ClaimReplay':False},'PendingUnpaid/Unpaid; Total="40000"','N',effects='Claim -> lock/revalidate -> FEFO -> acceptOrder -> save/clear/complete -> commit -> notify once',technique='Transaction / state transition')
add('CheckoutService.PlaceOrderAsync','Replay despite stale preparation failure',{'ClaimReplay':True,'StoredResponse':'existing confirmation','PlanError':'EMPTY_CART'},'Exactly stored confirmation','N',effects='No new order, stock mutation, clear or notification',technique='Experience / idempotency')
add('CheckoutService.PlaceOrderAsync','Address changed after preparation',{'originalStreet':'A','lockedStreet':'B'},'Reject checkout','A','CHECKOUT_ADDRESS_CHANGED / 409','Rollback claim and writes')
add('CheckoutService.PlaceOrderAsync','Notification fails after commit',{'Publish':'throws sentinel'},'Committed confirmation returned','A',effects='Warning logged; committed order not rolled back',technique='Failure injection')
add('CheckoutService.PlaceOrderAsync','Prepaid flow still deferred',{'PaymentMethod':'VietQr'},'No acceptance','A','PRE_ACCEPTANCE_PAYMENT_CORRELATION_TBD / 503','No claim or write')
for state,result in [('PendingUnpaid','ORDER_CANCELLED'),('PendingPaid','ORDER_CANCELLED'),('Confirmed','ORDER_CANCELLED'),('Cancelled','ORDER_ALREADY_CANCELLED'),('Packing','CANCELLATION_NOT_ALLOWED'),('Shipping','CANCELLATION_NOT_ALLOWED')]:
 add('MyOrdersService.CancelOrderAsync','Cancel '+state,{'OrderStatus':state,'Reason':'Changed mind'},result,'A' if state in ['Packing','Shipping'] else 'N','CANCELLATION_NOT_ALLOWED / 409' if state in ['Packing','Shipping'] else '', 'Allowed cancellation releases/audits once; replay does not notify; payment status retained','State transition')
for receipt,refund in itertools.product([False,True],repeat=2):
 add('MyOrdersService.GetOrderDetailsAsync','Return projection '+str((receipt,refund)),{'Receipt':receipt,'Refund':refund,'GoodsAmount':'20000','ShippingAmount':'10000'},'Return=null' if not receipt and not refund else 'Return projection present; absent amounts="0"; recorded amounts preserved','B',effects='Read only; no refund/disposition inferred',technique='Decision table')
add('MyOrdersService.ReorderAsync','Stock/price changed',{'Wanted':10,'Available':3,'Price':'12000'},'Qty=3, LineTotal="36000", QUANTITY_CLAMPED:1','B',effects='Old order unchanged',technique='Error guessing')
add('MyOrdersService.ReorderAsync','Unavailable line',{'Wanted':2,'Available':0},'UNAVAILABLE:1; no unavailable line','B',effects='Old order unchanged')
for email,ok in [(None,True),('',True),('tester@example.com',True),('bad',False),('tester@ + 65000 dots + @',False)]:
 add('ProfileService.UpdateProfileAsync','Email '+repr(email),{'Email':email},'Save email; empty becomes null' if ok else 'Reject before transaction','N' if ok else 'A','' if ok else 'INVALID_EMAIL','No write on rejection','Equivalence / experience')
for phone,ok in [('12345678',False),('123456789',True),('+123456789012345',True),('1234567890123456',False),('12345abc9',False)]:
 add('ProfileService.SaveAddressAsync','Phone '+phone,{'Phone':phone,'AddressId':None,'IsDefault':None},'Save resolved address; default=false' if ok else 'Reject before geocoding','B','' if ok else 'INVALID_PHONE','No external call/write if invalid','Boundary')
add('ProfileService.DeleteAddressAsync','Active-order address',{'Owned':True,'HasActiveOrder':True},'Reject deletion','A','ADDRESS_USED_BY_ACTIVE_ORDER / 409','No delete')
add('ProfileService.SaveAddressAsync','Foreign address edit',{'AddressId':'99','OwnedAddresses':['2']},'Reject ownership','A','NOT_FOUND / 404','No write','Security error guessing')
add('CurrentCustomer.RequireCustomerId','Forged header',{'Authenticated':False,'X-Customer-Id':'7'},'Reject identity','A','AUTHENTICATION_REQUIRED / 401','Header grants no authority','Security error guessing')
add('CurrentCustomer.GetCartIdentity','Tampered cookie',{'Cookie':'invalid-token','Scheme':'http'},'Fresh session; Secure, HttpOnly, SameSite.Strict','A',effects='Never use cookie text as identity',technique='Security error guessing')
add('CurrentCustomer.GetCartIdentity','Valid guest cookie',{'Cookie':'protect(existing-session)'},'Same session; no replacement cookie')
add('PaymentNoticeModelBinder.BindModelAsync','Signature-sensitive raw body',FIX['NOTICE'],'RawBody, Signature and ProviderReference exactly preserved','N',effects='No JSON normalization; request stream left open',technique='Experience / trust boundary')
for failure in ['Begin','Work','Commit']:
 add('UnitOfWork.ExecuteAsync',failure+' fails',{'FailAt':failure,'Error':'sentinel exception'},'Sentinel propagates if cleanup succeeds','A','Sentinel exception','Begin failure: no work. Work/commit failure: rollback with CancellationToken.None; no success','Failure injection')
for key in ['CheckoutService.RequestHash','CheckoutService.LegacyJsonString']:
 add(key,'Persisted fingerprint compatibility',{'Fixture':'src/Tests/Backend/FreshFood-API.Tests/Fixtures/checkout-hash-vectors.json','Variants':'quote, backslash, control, Unicode, paired and lone surrogates'},'Exact JSON.stringify-compatible output / fixture SHA256; no normalization','B',technique='Compatibility error guessing')
add('OrderStateMachine.ProcessEventAsync','Initial unpaid acceptance',{'ActorId':'7','CustomerId':'7','Quantity':2,'Available':7,'Initial':True,'Event':'acceptOrder'},'Transition IDs I00,T01u,P01; PendingUnpaid/Unpaid','N',effects='Event evidence once; same transaction',technique='State transition')
add('OrderStateMachine.ProcessEventAsync','Duplicate event evidence',{'RecordEventOnce':False},'Reject inconsistent evidence','A','INCONSISTENT_TRANSITION_EVIDENCE / 409','Previous snapshot restored; caller rolls back','Error guessing')
add('OrderStateMachine.LoadTable','Duplicate embedded row',{'TestResourceVariant':'duplicate I00, isolated test-only build'},'Reject duplicate transition IDs','A','InvalidOperationException: Duplicate transition row.','Do not mutate production resource','Fault injection','Approved isolated resource-build harness required; not claimed covered.')

add('OrderStateMachine.ProcessEventAsync','Verified-paid initial branch must preserve payment truth',{'Initial':True,'VerifiedPayment':True,'Order.PaymentStatus':'Paid','CustomerId':'7','ActorId':'7','Quantity':2,'Available':7,'Event':'acceptOrder'},'Fulfillment PendingPaid AND PaymentStatus Paid, consistent with approved initial-paid decision. Do not silently accept PendingPaid/Unpaid.','N',effects='No duplicate capture; preserve verified payment evidence',technique='State transition / experience',gap='Static review concern: follow-up P01 currently initializes PaymentStatus.Unpaid. Requires technical review and later execution; no runtime defect claimed.')
for key,field,route in [('CartController.ChangeQuantityAsync','ProductId','1'),('MyOrdersController.CancelOrderAsync','OrderId','1'),('MyOrdersController.SubmitReviewAsync','OrderId','1'),('ProfileController.UpdateAddressAsync','AddressId','2')]:
 add(key,'Conflicting body identifier cannot override route',{'routeId':route,'body':{field:'99','Quantity':2,'Rating':5,'Reason':'Changed mind'}},'Injected service receives '+field+'='+route+'; return exact service sentinel','A',effects='No use of attacker-supplied body identifier 99 as selected target',technique='Experience-based route/ownership regression')
# Additional experience and transport contract oracles.
for enum_value,wire in [('PaymentMethod.VietQr','VIETQR'),('PaymentMethod.Cod','COD'),('OrderStatus.PendingPaid','PENDING_PAID'),('OrderStatus.DeliveryFailed','DELIVERY_FAILED')]:
 add('SqlRepository.Encode','Enum wire '+enum_value,{'value':enum_value},'Exactly '+wire,'N',technique='Compatibility / error guessing')
for dto,body in [('CartChangeDto','{}'),('OrderReviewDto','{}'),('PlaceOrderDto','{"AddressId":"2","CheckoutReference":"r","IdempotencyKey":"k"}')]:
 add('ApiJson.Create','Missing required member '+dto,{'DTO':dto,'JSON':body},'JsonException for omitted Quantity, Rating or PaymentMethod; no defaulting to a valid operation','A','JsonException',technique='Under-posting error guessing')
add('CatalogRepository.FindActiveAsync','SQL-like keyword is data',{'keyword':"x' OR 1=1 --",'categoryId':None,'clearanceOnly':False},'Keyword stays in a bound parameter; SQL structure unchanged; no injected predicate','A',effects='No write',technique='Security error guessing')
# Concrete fixture records for input DTOs, derived from current declared property names.
symbols=json.loads(Path('artifacts/design/detailed/source-consistency-symbols.json').read_text())
for cls in symbols['classes']:
 if not cls['name'].endswith('Dto'):continue
 record={}
 for prop in cls['properties']:
  name=prop['name'];typ=prop['type']
  if name=='CustomerId':v='7'
  elif name in ['AddressId','DeliveryAddressId']:v='2'
  elif name.endswith('Id'):v='1'
  elif name=='Rating':v=5
  elif name=='Quantity':v=2
  elif name=='PaymentMethod':v='Cod'
  elif name=='RawBody':v=FIX['NOTICE']['RawBody']
  elif name=='Signature':v=FIX['NOTICE']['Signature']
  elif name in ['CheckoutReference','IdempotencyKey','ProviderReference']:v=name+'-001'
  elif name=='Email':v='tester@example.com'
  elif 'Phone' in name:v='0912345678'
  elif name in ['StreetAddress','RecipientName','FullName','Reason','Comment']:v={'StreetAddress':'Test street','RecipientName':'Tester','FullName':'Tester','Reason':'Changed mind','Comment':'Fresh produce'}[name]
  elif name=='Event':v='acceptOrder'
  elif name=='Latitude':v=10
  elif name=='Longitude':v=105
  elif typ.rstrip('?')=='bool':v=False
  elif typ.rstrip('?') in ['int','long','decimal']:v=1
  elif 'List<' in typ:v=[]
  elif typ=='string' or typ=='string?':v='Sample'
  else:v='Typed '+typ+' value arranged by the case'
  record[name]=v
 FIX[cls['name']]=record

def scope(m):
 t=m['type']
 if 'Catalog' in t:return ['UC-C01']
 if 'Profile' in t or 'Geocod' in t:return ['UC-C05']
 if 'Cart' in t:return ['UC-C03','UC-C06','UC-C07']
 if 'MyOrders' in t:return ['UC-C07']
 if any(x in t for x in ['Checkout','Payment','Distance','DeliveryFee','Preparation','Allocation','Order','Refund','Return','Shipping','Guard','Rule','FollowUp']):return ['UC-C06','UC-C07']
 return UCS
def value(name,typ):
 n=name.lower()
 short=typ.split('.')[-1]
 if short in FIX:return {'fixture':short}
 if name in ['region','guard']:return 'fulfillment' if name=='region' else 'always'
 if 'CancellationToken' in typ:return 'CancellationToken.None; use distinct token in forwarding variants'
 if n=='customerid':return '7'
 if n=='addressid':return '2'
 if n.endswith('id'):return '1'
 if 'string' in typ:
  if n=='code':return 'POLICY_TBD'
  if n=='sql':return 'SELECT product_id FROM products WHERE product_id=$1'
  if 'reason' in n:return 'Changed mind'
  if 'hash' in n:return 'a'*64
  return 'Sample'
 if typ in ['int','long','decimal','System.Decimal']:return 1 if n=='distancekm' else 2 if n in ['quantity','limit'] else 10000
 if typ in ['bool','bool?']:return False
 if 'List<' in typ or 'IEnumerable<' in typ:return 'Typed two-item fixture collection; see fixtures.json'
 if typ.startswith('I') or 'NpgsqlDataSource' in typ:return 'Strict fake '+typ+'; capture calls, no external IO'
 if 'OrderStatus' in typ:return 'Confirmed' if n=='target' else 'PendingUnpaid'
 if 'PaymentStatus' in typ:return 'Paid' if n=='target' else 'Unpaid'
 if 'PaymentMethod' in typ:return 'Cod'
 if 'VndAmount' in typ:return '10000'
 if 'Date' in typ:return '2099-01-01T00:00:00Z'
 if 'Func<' in typ:return 'Callback returns typed sentinel; record token'
 for token,f in [('PlaceOrder','CHECKOUT'),('PaymentNotice','NOTICE'),('Order','ORDER'),('Cart','CART'),('Address','ADDRESS'),('Batch','CATALOG')]:
  if token in typ:return f
 return 'Typed '+typ+' fixture from fixtures.json'
def leaves(tree):
 if not tree:return []
 return [tree['text']] if tree['kind']=='Atom' else leaves(tree['left'])+leaves(tree['right'])
def evaluate(tree,values,trace):
 if tree['kind']=='Atom':
  v=values[tree['text']];trace[tree['text']]=v;return v
 left=evaluate(tree['left'],values,trace)
 return (left and evaluate(tree['right'],values,trace)) if tree['kind']=='And' else (left or evaluate(tree['right'],values,trace))
def witness(atom,truth):
 if 'OperationCanceledException' in atom:return {'injectedException':'TimeoutException' if truth else 'OperationCanceledException'}
 if 'TryParse' in atom:return {'value':'1' if truth else 'abc'}
 if 'IsDefined' in atom:return {'PaymentMethod':'Cod' if truth else 999}
 if 'IsNullOrWhiteSpace' in atom or 'IsNullOrEmpty' in atom:
  match=re.search(r'\(([^()]*)\)',atom);return {(match[1] if match else 'text'):'' if truth else 'valid'}
 if 'IsAuthenticated' in atom:return {'User.Identity.IsAuthenticated':truth}
 if 'Length' in atom and '<= 128' in atom:return {'reference':'k'*(128 if truth else 129)}
 if '.Count' in atom:
  field=atom.split('.Count')[0].strip();positive=('> 0' in atom or '!= 0' in atom)
  return {field:[] if (not truth if positive else truth) else ['typed fixture item']}
 if ' is null' in atom or ' is not null' in atom:return {atom.split(' is ')[0]:None if (truth if ' is null' in atom else not truth) else 'typed fixture'}
 hit=re.fullmatch(r'([\w.]+)\s*(<=|>=|<|>|==|!=)\s*(-?\d+(?:\.\d+)?)',atom)
 if hit:
  field,op,raw=hit.groups();n=float(raw);v={'<':n-1 if truth else n,'<=':n if truth else n+1,'>':n+1 if truth else n,'>=':n if truth else n-1,'==':n if truth else n+1,'!=':n+1 if truth else n}[op]
  return {field:int(v) if v.is_integer() else v}
 for state in ['PendingUnpaid','PendingPaid','Delivered','Cancelled','Returned']:
  if state in atom:return {'OrderStatus':state if truth else 'Shipping'}
 if any(x in atom for x in ['StreetAddress','Latitude','Longitude']):return {'lockedAddressField':'same as preparation' if truth else 'changed after preparation'}
 return {'review constraint':atom+' = '+str(truth)+'; arrange matching entity/mock state and verify reachability'}
def concrete_witness(atom,truth):
 a=atom.strip()
 if a in ['s.ActorId == s.CustomerId','s.ActorId != s.CustomerId']:
  if truth==(a=='s.ActorId != s.CustomerId'):return {'review constraint':'ActorId is server-created/read-only and equals CustomerId for valid contexts. False ownership fact needs structural justification or approved private harness.'}
  return {'s.ActorId':'7','s.CustomerId':'7'}
 if 'OperationCanceledException' in a:return {'injectedException':'TimeoutException' if truth else 'OperationCanceledException'}
 if 'Regex.IsMatch' in a:
  return {'phone':'0912345678' if truth else 'bad'} if 'phone' in a.lower() else {'request.Email':'tester@example.com' if truth else 'bad'}
 if 'char.IsHighSurrogate' in a:return {'text code points':['U+D800','U+DC00'] if truth else ['U+0041'],'index':0}
 if 'char.IsLowSurrogate' in a:return {'text code points':['U+D800','U+DC00'] if truth else ['U+D800','U+0041'],'index':0}
 if 'char.IsSurrogate' in a:return {'text code points':['U+D800'] if truth else ['U+0041']}
 if a=='c < 32':return {'text code points':['U+0000'] if truth else ['U+0041']}
 if 'i + 1 < text.Length' in a:return {'text':'ab' if truth else 'a','i':0}
 if a=='i < text.Length':return {'text':'a' if truth else '', 'i':0}
 if 'reader.IsDBNull' in a:return {'reader row column':None if truth else 'typed non-null fixture value'}
 if 'props.TryGetValue' in a:return {'reader column':'unmapped_column' if truth and a.startswith('!') or not truth and not a.startswith('!') else 'ProductId','resultType':'Fixture with ProductId writable property'}
 if 'prop.CanWrite' in a:return {'result property':'read-only getter' if truth==a.startswith('!') else 'public writable property','column':'matching property name'}
 if 'typeof(' in a:
  hit=re.search(r'typeof\(([^)]*)\)',a);return {'result property type':hit[1] if truth else 'int','reader value':'value convertible to arranged property type'}
 if a=='t.IsEnum':return {'result property type':'OrderStatus' if truth else 'int','reader value':'PENDING_UNPAID' if truth else 1}
 if 'value is DateTime dt' in a:return {'reader value type':'DateTime (UTC)' if truth else 'DateTimeOffset'}
 if 'value is DateOnly date' in a:return {'reader value type':'DateOnly' if truth else 'DateTime'}
 if 'r.Source == State' in a:return {'rule.Source':'pending_unpaid' if truth else 'shipping','state region':'fulfillment','order.OrderStatus':'PendingUnpaid'}
 if 'r.Events.Contains' in a:return {'rule.Events':['cancelOrder'] if truth else ['acceptOrder'],'message.Event':'cancelOrder'}
 if '.All(' in a:return {'collection predicate values':[True,True] if truth else [True,False],'case setup':'Use two concrete matching lines; set one Quantity=0 or insufficient stock for the false element, according to referenced predicate.'}
 if '.Any(' in a:
  if 'IsActive' in a:return {'products':[{'ProductId':'1','IsActive':True}] if truth else [],'item.ProductId':'1'}
  return {'collection':'one matching fixture item' if truth else 'empty collection','match criterion':a}
 pattern=re.fullmatch(r'([\w.]+)\s+is\s+"([^"]+)"',a)
 if pattern:return {pattern[1]:pattern[2] if truth else 'OTHER'}
 relation=re.fullmatch(r'([\w.]+)\s+is\s+(>=|<=|>|<)\s+(\d+)',a)
 if relation:return witness(relation[1]+' '+relation[2]+' '+relation[3],truth)
 numeric=re.fullmatch(r'([\w.]+)\s*(<=|>=|<|>|==|!=)\s*(-?\d+(?:\.\d+)?)m?',a)
 if numeric:
  from decimal import Decimal
  field,op,raw=numeric.groups();n=Decimal(raw)
  v={'<':n-1 if truth else n,'<=':n if truth else n+1,'>':n+1 if truth else n,'>=':n if truth else n-1,'==':n if truth else n+1,'!=':n+1 if truth else n}[op]
  return {field:str(v) if abs(v)>9007199254740991 else int(v) if v==int(v) else str(v)}
 relation=re.fullmatch(r'([\w.]+)\s*(==|!=)\s*([\w.]+)',a)
 if relation:
  left,op,right=relation.groups();same=truth if op=='==' else not truth
  if 'OrderStatus' in left or 'PaymentMethod' in left:return {left:right.split('.')[-1] if same else 'Shipping' if 'OrderStatus' in left else 'Cod'}
  if 'Region' in left or right=='region':return {left:'fulfillment' if same else 'payment',right:'fulfillment'}
  return {left:'1' if same else '99',right:'1'}
 if 'CurrentStock >' in a:return {'CurrentStock':10 if truth else 3,'ReservedStock':3}
 if a in ['p.IsActive','!p.IsActive','applied','initial','s.Initial','s.PaymentInitialized','s.VerifiedPayment','s.FulfillmentCompleted','leased','claim.Replay','session.Active','!Session.Active','valid']:
  return {a.lstrip('!'):not truth if a.startswith('!') else truth}
 if 'string.IsNullOr' in a or 'TryParse' in a or ' is null' in a or ' is not null' in a or '.Count' in a:return witness(a,truth)
 return witness(a,truth)

def default_cases(m):
 data={p['name']:value(p['name'],p['type']) for p in m['parameters']}
 if m['type'] in ['ServiceRules','SqlRepository'] and m['name'] in ['Id','OptionalId']:data['value']='1'
 if m['type']=='SqlRepository' and m['name']=='Encode':data['value']='PaymentMethod.Cod'
 if m['type']=='OrderStateMachine' and 'rule' in data:data['rule']='I00 row from artifacts/design/detailed/order-state-transition-table.json'
 if m['kind']=='Constructor' and m['primaryConstructor']:
  return [
   dict(title='Valid construction',data=data,expected='Instance retains supplied dependency/data identities; no business IO during construction',inputType='N',exception='',sideEffects='No collaborator calls',technique='Constructor contract',gap='',targets=[]),
   dict(title='Constructor default / lifecycle boundary',data={**data,'variant':'Omit optional arguments; otherwise use distinct valid instances and empty collections'},expected='Declared defaults and fresh-instance isolation preserved',inputType='B',exception='',sideEffects='No IO',technique='Boundary',gap='',targets=[]),
   dict(title='Abnormal caller contract review',data={**data,'variant':'Missing non-nullable dependency is outside declared caller contract'},expected='No invented runtime rejection. Review-only until abnormal constructor behavior is agreed; DI registration failures are verified at composition root.',inputType='A',exception='N/A - no constructor guard specified',sideEffects='No execution claim',technique='Experience-based contract review',gap='No abnormal constructor guard contract; review-only category is not execution coverage.',targets=[])]
 deferred=('Gap(' in m['code'] or 'Gap<' in m['code'] or 'Task.FromException' in m['code'] or m['name'] in ['CreatePaymentQrAsync','HandleVerifiedPaymentAsync'] and m['type']=='CheckoutService')
 errors=re.findall(r'"([A-Z_]+(?:TBD|REQUIRED|CONFIGURED|INCREMENT))"',m['code'])
 if deferred:
  code=errors[-1] if errors else 'POLICY_TBD from caller'
  normal='Fail closed: DomainException '+code+' / 503 where specified; no successful payment/refund effect.'
 else:
  normal='Return the typed sentinel/declared projection; preserve arguments, ownership and cancellation token.'
  if m['type'].endswith('Controller'):normal='Injected service called once with arranged DTO; route identifier overrides conflicting body identifier where implemented; return exact sentinel.'
  elif m['type'].endswith('Repository') or m['type']=='SqlRepository':normal='Capture parameterized SQL and ordered arguments from the source reference. Return configured typed rows/projection; mutators require Active=true. No real DB for unit cases.'
  elif m['type']=='VndAmount':normal={'ToWire':'Exactly string \"10000\" for fixture Units=10000','ToString':'Exactly string \"10000\"','Add':'Units=20000 when this=10000 and other=10000','FromUnits':'Units=10000 without rounding','.ctor':'Construct Units=10000'}.get(m['name'],'Preserve integer VND invariant')
  elif m['type']=='DeliveryFeePolicy':normal='distanceKm=1 returns VndAmount(20000)'
  elif m['type']=='BatchPricingPolicy':normal='RetailPrice=10000 and DiscountRate=0 returns VndAmount(10000)'
  elif m['name'].startswith('get_'):normal='Return the value determined by arranged state without mutation.'
 has_collaborator=any(re.search(r'(?:[Rr]epository|[Gg]ateway|service|publisher|checkout|Session|session|unitOfWork|currentCustomer|pricing|distanceCalculator)\.',c['target']) for c in m['calls'])
 return [
  dict(title='Normal operational input',data=data,expected=normal,inputType='N',exception=errors[-1] if deferred and errors else '',sideEffects='Verify declared call count/order; no unrelated mutation',technique='Equivalence partitioning',gap='',targets=[]),
  dict(title='Boundary / empty result',data={**data,'boundary':'Empty then single-item collection where relevant; identifier=1; minimum allowed state. Branch-free forwarding: empty optional field unchanged.'},expected='Declared empty/default outcome or existing boundary guard; no invented maximum or rejection.',inputType='B',exception='',sideEffects='No duplicate entity or unnecessary call',technique='Boundary value analysis',gap='',targets=[]),
  dict(title='Dependency failure / abnormal contract',data={**data,'failure':'First collaborator throws TimeoutException sentinel; for pure methods use a declared invalid-input guard instead.'},expected='Declared error propagation/catch behavior; no unauthorized write. Pure methods with no abnormal-input contract require review, not an invented assertion.',inputType='A',exception='Sentinel TimeoutException or source-defined error/catch',sideEffects='No downstream mutation after failure; rollback only where this method owns transaction',technique='Experience / failure injection',gap='' if has_collaborator else 'No injectable collaborator here; bind abnormal cases to the declared guard, or review N/A instead of inventing a fault injection seam.',targets=[])]
methods=[];contracts=[];coverage=[]
for original in sorted(source['methods'],key=lambda m:(m['file'],m['line'],m['signature'])):
 if original['contractOnly']:contracts.append(original);continue
 m=dict(original);m['id']='UTM-'+str(len(methods)+1).zfill(3);m['sheet']='Function'+str(len(methods)+1) if len(methods)<3 else 'UT'+str(len(methods)+1).zfill(3)
 m['useCases']=scope(m);m['requirements']=sorted({f for u in m['useCases'] for f in FR[u]})
 m['testLevel']='Unit' if m['type']!='PostgreSqlSession' else 'Component / testability review'
 m['testability']='Strict interface fakes; no live DB or provider; independent arrange-act-assert fixtures.'
 if m['type']=='PostgreSqlSession':m['testability']='Concrete Npgsql connection/command/reader cannot currently be substituted through a project interface. Approval of an isolated transport seam or separately tagged component fixture required; real DB checks are not unit coverage.'
 elif m['indirect']:m['testability']='Reach through public owning method where feasible; reviewed internal/reflection harness for private/protected guards. Do not change production visibility silently.'
 key=m['type']+'.'+m['name'];m['cases']=[dict(c) for c in manual.get(key,[])]+default_cases(m)
 for di,d in enumerate(m['decisions'],1):
  did=m['id']+'-D'+str(di).zfill(2);tree=d.get('Tree');atoms=list(dict.fromkeys(leaves(tree)));vectors=[]
  if d['Outcomes']==['True','False'] and tree:
   seen=set()
   for bits in itertools.product([False,True],repeat=len(atoms)):
    trace={};result=evaluate(tree,dict(zip(atoms,bits)),trace);mark=tuple(trace.get(a,'NE') for a in atoms)
    if mark not in seen:seen.add(mark);vectors.append((str(result),trace))
  else:vectors=[(outcome,{}) for outcome in d['Outcomes']]
  offsets=[]
  for outcome,trace in vectors:
   overrides={}
   for atom,truth in trace.items():overrides.update(concrete_witness(atom,truth))
   if not trace:overrides={'scenario':outcome,'expression':d['Expression']}
   targets=[did+':'+outcome]+[did+':C'+str(atoms.index(a)+1)+':'+str(v) for a,v in trace.items()]
   c=dict(title=d['Kind']+' L'+str(d['Line'])+' -> '+outcome,data={'arguments':{p['name']:value(p['name'],p['type']) for p in m['parameters']},'baseFixtures':['CUSTOMER','CATALOG','CART','ADDRESS','CHECKOUT','ORDER','SESSION'],'overrides':overrides},expected=' | '.join([effect for effect in d.get('Effects',[]) if not effect.startswith(('True:', 'False:')) or effect.startswith(outcome+':')])+' | Assert selected outcome '+outcome+' at '+m['file']+':'+str(d['Line'])+'. Untaken branch must not execute.',inputType='A' if d['Kind'].startswith('catch') or d['Kind']=='guard' and outcome=='False' else 'B' if d['Kind'] in ['foreach','for','while','coalesce','null-access'] else 'N',exception='Only source-defined exception/catch; candidate throws: '+'; '.join(m['throws']),sideEffects='Observe declared state/transaction effects; no unauthorized write.',technique='Branch / evaluated atomic-condition coverage',gap='Concrete witness / reachability review required.' if 'review constraint' in overrides else '',targets=targets,decision=did,conditionTrace={a:str(trace[a]) if a in trace else 'NE: short-circuited' for a in atoms})
   if d['Kind']=='catch':c['data']['fault']='Throw '+outcome+' from the dependency protected by this catch; exercise filter true and false when present.'
   if m['type']=='ProfileService' and m['name']=='SaveAddressAsync' and d['Kind']=='catch':c['gap']='Static bounded phone regex has no deterministic timeout injection seam. Proposed validator seam or justified unreachable defense branch; do not use flaky timing.'
   if m['type']=='OrderStateMachine' and ('AMBIGUOUS_STATE_TRANSITION' in c['expected'] or 'STATE_MACHINE_COMPLETION_CYCLE' in c['expected']):c['gap']='Approved immutable table has no ambiguity/cycle. Requires isolated resource variant or reviewed structural-unreachability justification.'
   m['cases'].append(c);offsets.append(len(m['cases']))
  coverage.append(dict(method=m['id'],decision=did,kind=d['Kind'],line=d['Line'],expression=d['Expression'],atoms=atoms,outcomes=d['Outcomes'],caseOffsets=offsets,status='Planned; feasibility review required',testLevel=m['testLevel']))
 for i,c in enumerate(m['cases'],1):
  c['id']=m['id']+'-TC'+str(i).zfill(3);c['method']=m['id'];c['status']='Not executed - awaiting approval'
  c['preconditions']=m['testability']+' Prerequisite guards before the target pass; reset all state per case.'
  c['steps']='Arrange fixtures and overrides; invoke '+m['signature']+'; assert result, exception and captured calls/effects.'
 for d in [d for d in coverage if d['method']==m['id']]:d['caseIds']=[m['cases'][n-1]['id'] for n in d.pop('caseOffsets')]
 methods.append(m)
for c in contracts:
 candidates=[m for m in methods if m['name']==c['name'] and (m['type']==c['type'].removeprefix('I') or c['type']=='IRepositorySession' and m['type']=='PostgreSqlSession' or c['type']=='INotificationPublisher' and m['type']=='ConfiguredNotificationPublisher' or c['type']=='IPayoutPort' and m['type']=='UnconfiguredPayoutAdapter' or c['type']=='IPaymentGateway' and m['type']=='SePayPaymentAdapter' or c['type']=='INotificationGateway' and m['type']=='NotificationAdapter' or c['type']=='IGeocodingGateway' and m['type']=='GoogleMapsGeocodingAdapter' or c['type']=='IDistanceGateway' and m['type']=='GoogleMapsDistanceAdapter')]
 c['realizations']=[m['id'] for m in candidates];c['status']='Interface contract; checked through concrete realization; no executable body' if candidates else 'Realization mapping needs review'
cases=[c for m in methods for c in m['cases']]
summary=dict(date='2026-11-04',status='Draft - awaiting stakeholder / Technical Lead / QA approval',executableMethods=len(methods),interfaceContracts=len(contracts),testCases=len(cases),decisions=len(coverage),inputGroups=dict(collections.Counter(c['inputType'] for c in cases)),testLevels=dict(collections.Counter(m['testLevel'] for m in methods)),measurement='Design only. Actual statement/branch/condition coverage NOT MEASURED. Existing 67 tests and Sonar percentages are not execution results for this plan.',targets={'methodInventory':'100% of explicit executable backend declarations in snapshot','branch':'100% feasible outcomes planned; project minimum >=80% measured after execution','condition':'Each atomic condition True and False when evaluated; NE is not False','statement':'>=90% core business logic after execution','basisPaths':'100% critical computation/validation paths after feasibility review'},template='templates/Test Documents/Template_Unit Test Case.xls',defectTemplate='templates/Test Documents/Template_Defect_log.xls',approvalGate='No new unit-test project or test scripts; no execution, fabricated results or runtime defect records before approval.')
limits=['PostgreSqlSession needs a reviewed transport seam or component fixture; real DB checks cannot be claimed isolated unit tests.','Immutable embedded-table corruption and ambiguity/cycle defenses require isolated test-resource builds or a reviewed private harness.','Constructors and pure methods without abnormal-input contracts have explicit review-only cases; they are not executed coverage.','Generated truth-vector constraints require concrete fixture/reachability review; structurally unreachable safety branches must be justified rather than marked covered.','Deferred payment/provider/refund methods have fail-closed tests; desired success paths remain blocked by existing TBDs.','Compiler-generated methods, trivial auto-property accessors, framework internals and frontend code excluded; explicit getter logic included.']
report=dict(summary=summary,fixtures=FIX,methods=methods,contracts=contracts,coverage=coverage,knownLimits=limits)
(OUT/'backend-unit-test-design.json').write_text(json.dumps(report,ensure_ascii=False,indent=2)+'\n')
(OUT/'fixtures.json').write_text(json.dumps(FIX,ensure_ascii=False,indent=2)+'\n')
with (OUT/'method-coverage.csv').open('w',newline='',encoding='utf-8-sig') as f:
 w=csv.writer(f);w.writerow(['Method ID','Class','Signature','Use cases','FR basis','Source','Access','Test level','Cases','Sheet','State'])
 for m in methods:w.writerow([m['id'],m['type'],m['signature'],';'.join(m['useCases']),';'.join(m['requirements']),m['file']+':'+str(m['line']),m['accessibility'],m['testLevel'],len(m['cases']),m['sheet'],'Planned; not executed'])
with (OUT/'branch-condition-coverage.csv').open('w',newline='',encoding='utf-8-sig') as f:
 w=csv.writer(f);w.writerow(['Method','Decision','Kind','Line','Expression','Atomic conditions','Required outcomes','Planned test cases','State'])
 for d in coverage:w.writerow([d['method'],d['decision'],d['kind'],d['line'],d['expression'],'; '.join(d['atoms']),'; '.join(d['outcomes']),'; '.join(d['caseIds']),d['status']])
print(json.dumps(summary,indent=2))


