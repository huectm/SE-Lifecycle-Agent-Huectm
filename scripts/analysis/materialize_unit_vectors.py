"""Resolve concrete witnesses for simple structural cases without changing the design."""
from pathlib import Path
import json
D=Path('artifacts/testing/test-design/backend-unit');j=json.loads((D/'backend-unit-test-design.json').read_text(encoding='utf-8'));out={}
for m in j['methods']:
 for c in m['cases']:
  if not c.get('targets'):continue
  t=m['type'];name=m['name'];trace=c.get('conditionTrace',{});title=c['title'];data={};error='';supported=False
  if t=='BatchInventory':
   data={'quantity':1,'CurrentStock':10,'ReservedStock':3};supported=True
   if trace.get('quantity <= 0')=='True':data['quantity']=0
   if trace.get('CurrentStock - ReservedStock < quantity')=='True':data['quantity']=8
   if trace.get('ReservedStock < quantity')=='True':data['quantity']=4
   if data['quantity']<=0 or data['quantity']>(7 if name=='Reserve' else 3):error='INSUFFICIENT_STOCK' if name=='Reserve' else 'RESERVATION_INCONSISTENT'
  elif t=='DeliveryFeePolicy':
   supported=True;data={'distanceKm':-.001 if '< 0 or > 10' in title else .5 if '< 1' in title else 2 if '< 3' in title else 5};error='OUTSIDE_DELIVERY_AREA' if data['distanceKm']<0 else ''
  elif t=='VndAmount' and name in ['.ctor','FromUnits']:
   supported=True;v='10000'
   if trace.get('units < 0')=='True':v='-1'
   elif trace.get('units > 999999999999999999m')=='True':v='1000000000000000000'
   elif trace.get('decimal.Truncate(units) != units')=='True':v='0.5'
   data={'units':v};error='INVALID_VND_AMOUNT' if v in ['-1','1000000000000000000','0.5'] else ''
  elif t=='BatchPricingPolicy':
   supported=True;rate=10;price=10000
   if trace.get('rate != 0')=='False':rate=0
   if trace.get('rate < 10')=='True':rate=9
   if trace.get('rate > 50')=='True':rate=51
   if trace.get('decimal.Round(rate, 2) != rate')=='True':rate=10.001
   if trace.get('decimal.Truncate(amount) != amount')=='True':price=101
   data={'RetailPrice':str(price),'DiscountRate':rate};error='INVALID_DISCOUNT' if rate!=0 and (rate<10 or rate>50 or round(rate,2)!=rate) else 'ROUNDING_POLICY_TBD' if price==101 else ''
  elif t=='ServiceRules' and name in ['Id','Key']:
   supported=True
   if name=='Id':
    value='1'
    if trace.get('long.TryParse(value, out var n)')=='False':value='abc'
    elif trace.get('n > 0')=='False':value='0'
    error='INVALID_ID' if value!='1' else ''
   else:
    value='k'
    if trace.get('!string.IsNullOrWhiteSpace(value)')=='False':value=' '
    elif trace.get('value.Length <= 128')=='False':value='k'*129
    error='INVALID_REFERENCE' if value!='k' else ''
   data={'value':value}
  if t=='OrderStateMachine' and name=='ProcessEventAsync':
   supported=True;data={'Event':'acceptOrder','AggregateMismatch':False,'ExistingSnapshot':False,'DifferentAggregate':False,'DifferentCustomer':False}
   if trace.get('message.AggregateId != context.AggregateId')=='True':data['AggregateMismatch']=True;error='AGGREGATE_MISMATCH'
   if trace.get('string.IsNullOrWhiteSpace(message.Event)')=='True':data['Event']='';error='INVALID_STATE_EVENT'
   elif trace.get('message.Event.StartsWith("__", StringComparison.Ordinal)')=='True':data['Event']='__completion';error='INVALID_STATE_EVENT'
   data['ExistingSnapshot']=trace.get('snapshot is not null')=='True'
   if trace.get('snapshot.AggregateId != context.AggregateId')=='True':data['DifferentAggregate']=True;error='STATE_MACHINE_AGGREGATE_MISMATCH'
   if trace.get('snapshot.CustomerId != context.CustomerId')=='True':data['DifferentCustomer']=True;error='STATE_MACHINE_AGGREGATE_MISMATCH'
   if title.startswith('catch'):data['RecordEventOnce']=False;error='INCONSISTENT_TRANSITION_EVIDENCE'
  elif t=='OrderStateMachine' and name=='State':
   supported=True;ov=c['data'].get('overrides',{});region='payment' if 'L31' in title or '"payment"' in title else 'refund' if title.endswith('-> _') else 'fulfillment'
   data={'Region':region,'Initial':True,'PaymentInitialized':False,'Completed':False,'Workflow':'initial','StateExpected':'initial'}
   if region=='refund':data['StateExpected']='refund_initial'
   elif region=='payment':
    data['Initial']=trace.get('s.Initial')!='False';data['PaymentInitialized']=trace.get('!s.PaymentInitialized')=='False';data['StateExpected']='pay_initial' if data['Initial'] and not data['PaymentInitialized'] else 'unpaid'
   else:
    data['Completed']=trace.get('s.FulfillmentCompleted')=='True';data['Workflow']=ov.get('s.WorkflowNode','initial');data['StateExpected']='final_pending_unpaid' if data['Completed'] else data['Workflow'] if data['Workflow'] in ['initial','payment_choice'] else 'pending_unpaid'
  elif t=='OrderStateMachine' and name=='Guard':
   supported=True;guard='plannedStock';expected=True
   if 'switch-arm' in title:guard=c['data']['overrides']['scenario'].strip('"');expected=guard not in ['paid','_']
   if 'False' in title:expected=False
   if 'True' in title:expected=True
   data={'Guard':guard,'GuardExpected':expected,'Quantity':2,'Available':7,'BatchId':'1'}
   if guard=='plannedStock' and not expected:
    if 'b.BatchId == g.Key' in trace and trace['b.BatchId == g.Key']=='False':data['BatchId']='99'
    elif 'g.Sum(l => l.Quantity) <= b.CurrentStock - b.ReservedStock' in trace:data['Available']=0
    else:data['Quantity']=0
  elif t=='OrderStateMachine' and name=='CurrentState':supported=True;data={'HasSnapshot':trace.get('snapshot is null')=='False'}
  elif t=='ProfileService' and name=='UpdateProfileAsync' and 'catch' not in title:
   supported=True;data={'Email':'tester@example.com'}
   if any(v=='False' for k,v in trace.items() if 'Regex.IsMatch' in k):data['Email']='bad';error='INVALID_EMAIL'
   if trace.get('string.IsNullOrEmpty(request.Email)')=='True':data['Email']=''
  elif t=='ProfileService' and name=='SaveAddressAsync' and 'catch' not in title:
   supported=True;data={'Phone':'123456789','AddressId':None,'Latitude':10,'Longitude':105,'IsDefault':None}
   for k,v in trace.items():
    if 'Regex.IsMatch' in k and v=='False':data['Phone']='bad';error='INVALID_PHONE'
    if 'geo.Latitude' in k and v=='False':data['Latitude']=91;error='INVALID_ADDRESS_COORDINATES'
    if 'geo.Longitude' in k and v=='False':data['Longitude']=181;error='INVALID_ADDRESS_COORDINATES'
    if k=='!string.IsNullOrEmpty(request.AddressId)' and v=='True':data['AddressId']='2'
    if k.startswith('!(await profileRepository.GetAddressesAsync') and v=='True':data['AddressId']='99';error='NOT_FOUND'
   if 'request.IsDefault' in title or c['data'].get('overrides',{}).get('expression')=='request.IsDefault':data['IsDefault']=None if '-> Null' in title else True
  elif t=='MyOrdersService' and name=='SubmitReviewAsync':
   supported=True;data={'OrderStatus':'Delivered','Rating':5,'SaveReviewOnce':True,'Comment':None if '-> Null' in title else 'Great'}
   if trace.get('request.Rating is >= 1')=='False':data['Rating']=0;error='RATING_OUT_OF_RANGE'
   elif trace.get('request.Rating is <= 5')=='False':data['Rating']=6;error='RATING_OUT_OF_RANGE'
   if trace.get('order.OrderStatus == OrderStatus.Delivered')=='False':data['OrderStatus']='Shipping';error='REVIEW_REQUIRES_DELIVERED'
   if any('SaveReviewOnceAsync' in k and v=='False' for k,v in trace.items()):data['SaveReviewOnce']=False;error='REVIEW_ALREADY_EXISTS'
  elif t=='MyOrdersService' and name=='GetOrderDetailsAsync' and 'L12' not in title and 'L13' not in title:
   supported=True;data={'Receipt':True,'Refund':True,'GoodsAmount':'20000','ShippingAmount':'10000'}
   expression=c['data'].get('overrides',{}).get('expression','')
   if 'receipt is null' in trace:data['Receipt']=trace['receipt is null']!='True';data['Refund']=trace.get('refund is null')!='True'
   elif 'receipt' in expression:data['Receipt']='-> Null' not in title
   elif 'refund' in expression:data['Refund']='-> Null' not in title
   if expression=='order.Failure':data['Failure']='-> Null' not in title
  if supported:
   out[c['id']]={'data':data,'exception':error,'basis':'Concrete witness derived from the approved domain limits; no production seam or requirement change.','originalDecision':c.get('decision'),'conditionTrace':trace}
(D/'materialized-vectors.json').write_text(json.dumps(out,indent=2)+'\n',encoding='utf-8');print('Materialized',len(out),'structural witnesses')
