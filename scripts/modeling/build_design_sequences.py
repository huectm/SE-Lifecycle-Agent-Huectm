from pathlib import Path
import json,re,csv,sys
M=json.loads(Path('artifacts/implementation/psm-contract-model.json').read_text(encoding='utf-8-sig'))
DATA=[]; ROLES={}; TRACE=[]
for n,c in M['classes'].items():
 ROLES[n]='boundary' if any(x in n for x in ['Page','View','ApiClient','ApiModel']) else 'controller' if 'Controller' in n or n=='PaymentNoticeHandler' else 'entity' if c.get('role')=='entity' else 'application logic'
ROLES.update({'Customer':'actor','SePay':'actor'})
def build(uc):
 s=M['scope'][uc]; f=s['feature']; pages=[]
 def page(title,basis,lines):pages.append((title,basis,'\n'.join(lines)))
 def call(lines,a,b,method,result):
  lines += [f'C {a} {b} {method}',f'R {b} {a} {result}']
 def transaction(lines,body):
  lines += ['C S W ExecuteAsync(work, signal)','C W S TransactionWork callback (same transaction)']
  body(lines)
  lines += ['R S W work completed; otherwise throw to roll back','R W S committed; exception means rolled back']
 def body(op,L):
  def q(method,result='entities'):call(L,'S','R',method,result)
  def price():call(L,'S','B','Quote(batch, asOf)','VndAmount')
  if f!='Catalog':call(L,'S','I','GetCartIdentity()' if f=='Cart' else 'RequireCustomerId()','trusted identity')
  if f=='Catalog':
   q('GetProductAsync(productId, signal)','Product?') if op=='GetProductDetails' else q('FindActiveAsync(keyword, categoryId, clearanceOnly, signal)','Product[]')
   if op!='GetProductDetails':q('GetCategoriesAsync(signal)','ProductCategory[]')
   q('GetSellableBatchesAsync(productIds, signal)','BatchInventory[]');price()
   L += ['# alt [matching sellable products found]','C S S '+op+'Async: map entities to response DTO (local computation)','# else [no matching products / unavailable detail]']
   if op!='GetProductDetails':
    q('GetPopularAsync(limit, signal)','alternative products');q('GetSellableBatchesAsync(productIds, signal)','alternative sellable batches');price()
   L += ['C S S '+op+'Async: map existing empty/unavailable outcome and alternatives where applicable']
  elif f=='Cart':
   if op=='GetCart':
    q('GetAsync(customerId, sessionId, signal)','Cart');q('GetProductsAsync(ids, signal)','Product[]');q('GetSellableBatchesAsync(ids, signal)','BatchInventory[]');price();return
   def cart_change(x):
    q_into(x,'GetAsync(customerId, sessionId, signal)','owned cart in current transaction')
    if op=='ChangeQuantity':
     q_into(x,'GetProductsAsync(ids, signal)','active product');q_into(x,'GetSellableBatchesAsync(ids, signal)','current availability')
    x += ['# alt [valid owned mutation and current availability]','C S S [local] change absolute quantity, clamp if necessary, or remove selected item']
    q_into(x,'SaveAsync(cart, signal)','cart saved')
    q_into(x,'GetProductsAsync(ids, signal)','remaining products');q_into(x,'GetSellableBatchesAsync(ids, signal)','current display stock');call(x,'S','B','Quote(batch, asOf)','current price')
    x += ['# else [invalid quantity / unavailable product / ownership failure]','C S S [local] reject mutation; transaction rolls back','# end cart mutation outcome']
   transaction(L,cart_change)
  elif f=='Profile':
   if op=='GetProfile':
    q('GetCustomerAsync(customerId, signal)','Customer');q('GetAddressesAsync(customerId, signal)','CustomerAddress[]');return
   if op=='SaveAddress':call(L,'S','G','ResolveAsync(address, signal)','GeoPointDto or integration unavailable')
   L += ['# alt [valid owned change; required integration available]']
   def profile_change(x):
    if op=='UpdateProfile':q_into(x,'GetCustomerAsync(customerId, signal)','owned Customer')
    else:
     q_into(x,('[editing existing address] ' if op=='SaveAddress' else '')+'GetAddressesAsync(customerId, signal)','owned addresses')
    if op=='DeleteAddress':q_into(x,'HasActiveOrderAsync(customerId, addressId, signal)','false required for deletion')
    method={'UpdateProfile':'SaveCustomerAsync(customer, signal)','SaveAddress':'SaveAddressAsync(address, signal)','SetDefaultAddress':'SaveAddressAsync(address, signal)','DeleteAddress':'DeleteAddressAsync(customerId, addressId, signal)'}[op]
    q_into(x,method,'change saved; errors roll back')
   transaction(L,profile_change)
   L += ['# else [validation / ownership / active-order / integration failure]','C S S [local] reject change without partial persistence','# end profile update outcome']
   if op in ['UpdateProfile','SetDefaultAddress']:
    q('GetCustomerAsync(customerId, signal)','refreshed Customer');q('GetAddressesAsync(customerId, signal)','refreshed owned addresses')
  elif f=='Checkout':
   if op=='CreatePaymentQr':
    L += ['# alt [payment correlation contract unresolved]','C S S [local] report payment unavailable; do not invoke payment creation','# else [future approved payment correlation and provider available]']
    call(L,'S','P','CreateQrAsync(reference, amount, signal)','PaymentQrDto; planned integration, currently deferred')
    L += ['# end payment availability outcome'];return
   q('GetCheckoutCartAsync(customerId, signal)','Cart');q('GetOwnedAddressAsync(customerId, addressId, signal)','CustomerAddress')
   call(L,'S','D','CalculateAsync(addressId, signal)','distanceKm');call(L,'S','F','Quote(distanceKm)','VndAmount delivery fee')
   if op=='PrepareCheckout':
    L += ['# alt [valid cart and address; delivery serviceable]']
    q('LockFefoBatchesAsync(productIds, signal)','available FEFO candidates; read-only preparation');price()
    L += ['C S S PrepareCheckoutAsync: allocate all lines and calculate summary','# else [empty / unavailable stock / stale cart / outside delivery area]','C S S PrepareCheckoutAsync: validation result; no order created'];return
   def submit(x):
    q_into(x,'ClaimCheckoutAsync(customerId, reference, key, requestHash, signal)','new claim or original stored confirmation')
    x += ['# opt [new checkout claim]']
    q_into(x,'GetCheckoutCartAsync(customerId, signal)','cart revalidated under current transaction')
    q_into(x,'GetOwnedAddressAsync(customerId, addressId, signal)','owned address revalidated; changed preparation is rejected')
    q_into(x,'LockFefoBatchesAsync(productIds, signal)','locked sellable FEFO batches');call(x,'S','B','Quote(batch, asOf)','VndAmount')
    x += ['# end optional preparation','# alt [matching completed checkout claim]','C S S [local] reuse original confirmation; skip state, stock and cart writes','# else [new claim; all stock and payment guards satisfied]']
    call(x,'S','T','ProcessEventAsync(snapshot, acceptOrderEvent, signal)','StateMachineResult; I00, selected T01 branch and initial payment row')
    q_into(x,'SaveOrderAsync(order, signal)','order persisted in current transaction');q_into(x,'ClearCartAsync(cartId, signal)','cart cleared');q_into(x,'CompleteCheckoutAsync(customerId, reference, key, response, signal)','response persisted and initial events linked in the same transaction')
    x += ['# else [claim conflict / unavailable stock / persistence failure / unsupported payment]','C S S PlaceOrderAsync: throw; roll back all order, payment, reservation and cart effects','# end checkout claim outcome']
   transaction(L,submit)
   L += ['# opt [commit succeeded and newly accepted order; not replay]'];call(L,'S','N','PublishAsync(message, signal)','notification submitted once after commit')
  else:
   if op=='GetOrders':q('FindOwnedAsync(customerId, signal)','Order[]');return
   if op=='GetOrderDetails':
    q('FindOwnedAsync(customerId, signal)','owned Order and OrderDetail data');q('GetReturnReceiptAsync(orderId, signal)','ReturnReceipt?');q('GetRefundAsync(orderId, signal)','Refund?');return
   def change(x):
    q_into(x,'LockOwnedAsync(customerId, orderId, signal)','locked owned Order')
    x += ['# alt [owned order; use-case guard satisfied]']
    if op=='CancelOrder':call(x,'S','T','ProcessEventAsync(snapshot, cancelOrderEvent, signal)','StateMachineResult; table selects cancellation and fulfillment completion')
    elif op=='Reorder':
     q_into(x,'GetCurrentBatchesAsync(productIds, signal)','current availability');call(x,'S','B','Quote(batch, asOf)','current VndAmount');q_into(x,'SaveCartAsync(cart, signal)','available items copied; changed/unavailable items reported')
    else:q_into(x,'SaveReviewOnceAsync(review, signal)','once only; Delivered order and rating 1..5 required')
    x += ['# else [not owned / concurrent status change / invalid data / duplicate]','C S S '+op+'Async: reject or return existing outcome; no unauthorized mutation','# end order mutation outcome']
   transaction(L,change)
   if op=='CancelOrder':L += ['# opt [new cancellation committed; not an already-cancelled replay]'];call(L,'S','N','PublishAsync(message, signal)','notification submitted after commit')
 def q_into(lines,method,result):call(lines,'S','R',method,result)
 names={'A':'Customer','U':f+'Page','V':f+'ApiClient','C':f+'Controller','S':f+'Service','R':f+'Repository','I':'CurrentCustomer','W':'UnitOfWork','B':'BatchPricingPolicy','G':'GoogleMapsGeocodingAdapter','D':'DistanceCalculator','F':'DeliveryFeePolicy','P':'SePayPaymentAdapter','N':'NotificationAdapter','T':'OrderStateMachine'}
 source=list(csv.DictReader(open('artifacts/design/detailed/interaction-to-design-mapping.csv',encoding='utf-8-sig')))
 for op,args,result in s['operations']:
  if op=='HandleVerifiedPayment':continue
  sig=next(x for x in M['classes'][f+'Service']['operations'] if x.startswith('+ '+op+'Async('))
  params=sig.split('(',1)[1].split(')',1)[0]; argnames=', '.join(p.split(':')[0].strip() for p in params.split(',') if p.strip());clientargs=argnames.replace(', signal','').replace('signal','')
  flows='; '.join(dict.fromkeys(x['Source Flows'] for x in source if x['Use Case']==uc and x['Design Operation']==op+'Async')) or 'Address default selection in approved profile flow'
  L=[f'C A U On{op}Async({clientargs})',f'C U V {op}Async({clientargs})',f'C V C HTTPS {op}Async({clientargs}); server supplies signal',f'C C S {op}Async({argnames})']
  body(op,L)
  # Return DTO is taken from exact service signature, not old scope primitive aliases.
  dto=sig.rsplit('Task<',1)[1].rstrip('>')
  L += ['# end common continuation',f'R S C {dto}',f'R C V HTTPS response: {dto}',f'R V U {dto}; update UI']
  page(op,flows,L)
  TRACE.append({'UseCase':uc,'Page':len(pages),'Operation':op+'Async','Signature':sig,'SourceFlows':flows})
 # Mobile entry refinement shares the operation-specific backend interaction; no frontend DI.
 op,args,result=s['operations'][0];sig=next(x for x in M['classes'][f+'ApiModel']['operations'] if x.startswith('+ '+op+'Async('));dto=sig.rsplit('Future<',1)[1].rstrip('>')
 mobileargs=', '.join(p.split(':')[0].strip() for p in sig.split('(',1)[1].split(')',1)[0].split(',') if p.strip())
 serverargs=', '.join(x for x in [mobileargs,'signal'] if x)
 mn={'MV':s['analysis_view'],'VM':f+'ViewModel','AM':f+'ApiModel'};names.update(mn)
 page('Mobile entry refinement','Same DTO/API contract; ref operation-specific backend pages',[
 f'C A MV user action: {op}',f'C MV VM {op}Async({mobileargs})',f'C VM AM {op}Async({mobileargs})',f'C AM C HTTPS {op}Async({mobileargs}); server supplies signal',f'C C S {op}Async({serverargs})',f'R S C {dto}; ref detailed backend page',f'R C AM HTTPS response: {dto}',f'R AM VM {dto}',f'R VM MV {dto}; render result'])
 if f=='Checkout':
  names['H']='PaymentNoticeHandler';names['E']='SePay'
  page('Verified payment webhook','A6.1; latest initial-state rules override stale Pending wording',[
   'A E H HandleAsync(notice, signal)','C H S HandleVerifiedPaymentAsync(notice, signal)',
   'C S P VerifyNoticeAsync(notice, signal)','R P S VerifiedPaymentDto or unconfigured verification error',
   '# alt [verification unavailable or invalid notice]','C S S [local] reject unsigned notice',
   '# else [verified notice; correlation policy TBD]','C S S [local] explicit correlation error; P02 capture remains disabled',
   '# end payment outcome','R S H PaymentResultDto error; no payment mutation',
  ])
 DATA.append((uc,s['title'],s['slug'],names,pages))
for uc in M['scope']:build(uc)
# Table-driven state-machine refinements replace per-transition class lifelines.
for uc,title,slug,names,pages in DATA:
 if uc not in ('UC-C06','UC-C07'):continue
 names.update({'L':'OrderLifecycleRepository'})
 if uc=='UC-C06':
  pages.append(('OrderStateMachine acceptance','acceptOrder; one private table; all database effects share the checkout transaction','\n'.join([
   'C S T ProcessEventAsync(snapshot, acceptOrderEvent, signal)',
   'C T T [local] resolve current state + event + trusted guard in private table',
   'C T L RecordEventOnceAsync(aggregateId, eventId, transitionId, signal)','R L T I00 recorded once',
   'C T T [local] apply acceptance and follow completion to guarded initial branch',
   '# alt [goods unpaid at acceptance]',
   'C T L RecordEventOnceAsync(aggregateId, eventId, transitionId, signal)','R L T T01u recorded once',
   'C T T [local] set Pending Unpaid; internal createOrder event selects P01',
   'C T L RecordEventOnceAsync(aggregateId, eventId, transitionId, signal)','R L T P01 recorded once',
   '# else [paid at acceptance; verified persistent correlation required]',
   'C T T [local] table selects T01p; required P02 remains disabled until payment correlation is resolved',
   '# end acceptance branch complete','C T T CurrentState()','R T S StateMachineResult; Pending Unpaid or explicit unresolved-payment error; caller owns commit',
  ])))
  pages.append(('Idempotent checkout replay','Same customer + key + fingerprint; original response survives cart clearing','\n'.join([
   'C A U OnPlaceOrderAsync(request)','C U V PlaceOrderAsync(request)','C V C HTTPS PlaceOrderAsync(request); server supplies signal',
   'C C S PlaceOrderAsync(request, signal)',
   'C S W ExecuteAsync(work, signal)','C W S TransactionWork callback (same transaction)',
   'C S R ClaimCheckoutAsync(customerId, reference, key, requestHash, signal)','R R S stored matching confirmation or claim conflict',
   '# alt [matching completed request]','C S S [local] replay original confirmation; skip state machine, reservation, cart writes and notification',
   '# else [key reused with changed body / reference reused with another key]','C S S [local] reject conflict; preserve earlier successful outcome',
   '# end replay outcome','R S W work completed or conflict thrown','R W S committed read/replay scope or rolled back conflict',
   'R S C OrderConfirmationDto or conflict','R C V HTTPS response','R V U render result',
  ])))
 else:
  pages.append(('OrderStateMachine cancellation','cancelOrder; private table selects T08u/T08p/T09; no per-transition objects','\n'.join([
   'C S T ProcessEventAsync(snapshot, cancelOrderEvent, signal)',
   'C T T [local] select exactly one source-state / event / guard row',
   'C T L RecordEventOnceAsync(aggregateId, eventId, transitionId, signal)','R L T selected cancellation row recorded once',
   'C T L LockReservedBatchesAsync(orderId, signal)','R L T locked reserved batches',
   'C T T [local] release reservations once; set Cancelled; retain independent payment state',
   'C T L SaveBatchesAsync(batches, signal)','R L T reservations persisted',
   'C T L SaveAsync(order, signal)','R L T Cancelled persisted',
   'C T L AppendAuditAsync(audit, signal)','R L T customer actor audit persisted',
   'C T T [local] completion lookup selects F_cancelled without adding a persistent status',
   'C T L RecordEventOnceAsync(aggregateId, eventId, transitionId, signal)','R L T fulfillment completion evidence',
   'C T T CurrentState()','R T S StateMachineResult; caller commits all effects together',
  ])))
# Reuse the established source-first UML sequence renderer without touching analysis artifacts.
src=Path('scratch/generate_analysis_sequences.py').read_text(encoding='utf-8-sig')
start=src.index('records=[];trace=[]')
src=src[start:]
src=src.replace("'Customer actor','Google Maps','SePay'","'Customer actor','Google Maps','SePay'")
src=src.replace("preferred=[names[k] for k in ['A','U','C','S']]","preferred=[names[k] for k in (['E','A','U','V','MV','VM','AM','C','H','W','S'] if uc in ('UC-C06','UC-C07') else ['E','A','U','V','MV','VM','AM','C','H','W','S']) if k in names]")
src=src.replace("'Analysis Sequence Diagram | '","'Design Sequence Diagram | '").replace('Draft for Analysis Review','Revised table-driven design for review')
src=src.replace("270,y-6,270,70,14","132,y-6,240,92,13")
src=src.replace('W=100+330*len(parts)','W=300+330*len(parts)').replace('245+i*330','445+i*330')
src=src.replace("120 if e[0]=='guard' else 82","140 if e[0]=='guard' else 100").replace('y+=120','y+=140').replace('y+=82','y+=100')
src=src.replace("f'{uc.lower()}-{slug}-sequence.drawio'","f'{uc.lower()}-{slug}-design-sequence.drawio'")
src=src.replace('artifacts/analysis/sequence-verification.json','artifacts/design/design-sequence-verification.json').replace('artifacts/analysis/sequence-traceability.csv','artifacts/design/design-sequence-message-traceability.csv')
src=src.replace('Analysis Sequence -','Design Sequence -')
src=src.replace('yy-46,lw,42,17','yy-(68 if num==1 else 88),lw,60 if num==1 else 80,15 if len(msg)<105 else 13')
src=src.replace('lw=max(220,min(abs(tx-sx)-35,650));lx=(sx+tx)/2-lw/2','lw=280;lx=tx-165-lw/2 if tx>sx else tx+165-lw/2')
src=src.replace("if line.startswith('else '):", "if line.startswith('end '):\n     close_frame(y-15);y+=60;continue\n    if line.startswith('else '):")
src=src.replace('execution_intervals(msgs,set(ROLES),guard_bands)',"execution_intervals(msgs,{n for n,r in ROLES.items() if r!='actor'},guard_bands)")
src=src.replace("assert n in ROLES or n in ['Shopper','Customer actor','Google Maps','SePay'],n","assert n in ROLES,n")
# Interface role is shown with implementing classifier, retaining actual design type names.
contracts={c['name']:next((n for n in M['classes'] if n=='I'+c['name']),None) for c in M['classes'].values()}
src=src.replace("'<b>:'+n+'</b>'","'<b>:'+n+'</b>'")
src=src.replace("'&lt;&lt;'+r+'&gt;&gt;<br><b>:'+n+'</b>'","'&lt;&lt;'+r+'&gt;&gt;<br><b>:'+n+'</b>'+('<br>via '+contracts[n] if contracts.get(n) else '')")
# User action has no response back to actor. Asynchronous callback header is an external actor.
import xml.etree.ElementTree as E,html,hashlib
sys.path.insert(0,'scratch')
from test_render_drawio import render_drawio_file
from sequence_executions import execution_intervals
BASE=Path('artifacts/diagrams/sequence');BASE.mkdir(exist_ok=True)
Path('artifacts/design/design-sequence-operation-traceability.json').write_text(json.dumps(TRACE,indent=2),encoding='utf-8')
for _uc,_title,_slug,_names,_pages in DATA:
 for _i,(_pn,_basis,_raw) in enumerate(_pages):
  _raw=re.sub(r'(C S S )\w+Async: ',r'\1[local] ',_raw)
  _pages[_i]=(_pn,_basis,_raw)
# PIM is the authoritative diagram notation. The earlier source signatures only
# seed the scenario recipe; explicit PSM refinements live in the mapping artifact.
PIM=json.loads(Path('artifacts/design/detailed/detailed-class-model.json').read_text(encoding='utf-8'))
for _uc,_title,_slug,_names,_pages in DATA:
 for _i,(_pn,_basis,_raw) in enumerate(_pages):
  _raw=_raw.replace('; server supplies signal','').replace(', signal','').replace('(signal)','()')
  _raw=re.sub(r'\b((?:On)?GetCartAsync)\(identity\)',r'\1()',_raw)
  _pages[_i]=(_pn,_basis+' | PIM',_raw)
for entry in TRACE:
 _service=PIM['scope'][entry['UseCase']]['service']
 entry['Signature']=next(s for s in PIM['classes'][_service]['operations'] if s.startswith('+ '+entry['Operation']+'('))
 entry['ModelLevel']='PIM';entry['SourceMapping']='detailed/pim-to-code-mapping.json'
M=PIM
exec(compile(src,'design-sequence-renderer','exec'))
