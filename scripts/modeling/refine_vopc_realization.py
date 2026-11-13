from pathlib import Path
import re,json,xml.etree.ElementTree as E,html

def refine(classes,pages,ucs,C,dep,page):
 API='FreshFood-API';REPO='FreshFood.Reposistory'
 # Pure domain policies decompose application-logic responsibilities without adding business rules.
 C('IBatchPricingPolicy',REPO+'.Entities','interface',[],['+ Quote(batch: BatchInventory, asOf: Date): VndAmount'],'BR-BAT-01/04; isolate current active batch price/discount logic')
 C('BatchPricingPolicy',REPO+'.Entities','policy',[],['+ Quote(batch: BatchInventory, asOf: Date): VndAmount'],'Pure integer-VND pricing responsibility refined from application logic; proposed implementation')
 C('IDeliveryFeePolicy',REPO+'.Entities','interface',[],['+ Quote(distanceKm: number): VndAmount'],'BR-DEL-01/02; service radius and tiered fee')
 C('DeliveryFeePolicy',REPO+'.Entities','policy',[],['+ Quote(distanceKm: number): VndAmount'],'Use existing 1/3/10 km boundaries and fees; reject invalid distance; no new policy')
 C('IDistanceCalculator',API+'.Services','interface',[],['+ CalculateAsync(addressId: EntityId, signal: AbortSignal): Promise<number>'],'Architecture CON-01 DistanceCalculator; external distance boundary refinement')
 C('DistanceCalculator',API+'.Services.Implements','service',['- gateway: IDistanceGateway'],['+ DistanceCalculator(gateway: IDistanceGateway)','+ CalculateAsync(addressId: EntityId, signal: AbortSignal): Promise<number>'],'Coordinate driving-distance adapter and <=10 km validation; provider fallback remains TBD')
 C('IFefoBatchSpecification',REPO+'.Repository','interface',[],['+ Criteria(asOf: Date): BatchCriteria'],'Architecture CON-02 query specification; BR-BAT-02 / BR-ORD-01')
 C('FefoBatchSpecification',REPO+'.Repository.Implements','specification',[],['+ Criteria(asOf: Date): BatchCriteria'],'Translate eligible sellable batches and expiry ASC / deterministic batch tie-break into locked repository query; no in-memory substitute for DB locking')
 C('BatchCriteria',REPO+'.Repository','record',['+ ActiveProductsOnly: boolean','+ AsOf: Date','+ MinimumAvailable: number','+ SortKeys: ReadonlyArray<string>','+ LockForUpdate: boolean'],[],'Repository-owned closed query criteria; no API DTO dependency or chosen SQL/ORM framework')
 C('VndAmount',REPO+'.Entities','value object',['- units: bigint'],['+ FromUnits(units: bigint): VndAmount {static}','+ Add(other: VndAmount): VndAmount','+ ToWire(): string'],'CON-04 integer VND; exact 18-digit amounts, no JS binary floating-point money')
 C('EntityId',REPO+'.Entities','datatype',['= opaque decimal identifier string'],[],'Safe SQL BIGINT / JSON identifier representation; not a new database entity')
 C('LocalDate',REPO+'.Entities','datatype',['= ISO calendar date string'],[],'Preserve date-only expiry/manufacture values without choosing an instant/timezone policy')
 C('VndAmountString',API+'.DTOs','datatype',['= decimal integer string'],[],'Wire projection of exact VND amounts; map to/from VndAmount explicitly')
 C('IsoDateTime',API+'.DTOs','datatype',['= ISO timestamp string'],[],'Wire representation of existing timestamp evidence')
 C('AuthenticatedPrincipal',API+'.Services','record',['+ CustomerId: EntityId?','+ SessionId: string?','+ Roles: ReadonlyArray<string>'],[],'Trusted server identity, never populated from customer request fields')
 C('DatabaseConnection',REPO+'.Repository','external protocol',[],['+ QueryAsync(sql: string, parameters: ReadonlyArray<unknown>, signal: AbortSignal): Promise<unknown>'],'Provider-neutral Node.js database connection; PostgreSQL driver remains unselected')
 C('DatabaseTransaction',REPO+'.Repository','external protocol',[],['+ CommitAsync(signal: AbortSignal): Promise<void>','+ RollbackAsync(signal: AbortSignal): Promise<void>'],'Provider-neutral transaction protocol, not a selected ORM')
 C('RegistrationMap',API,'composition contract',[],['+ Bind(token: string, factory: () => object): void','+ BindMany(token: string, factories: ReadonlyArray<() => object>): void'],'Framework-neutral Node.js bootstrap constructor bindings; no .NET IServiceCollection or chosen DI library')
 C('HttpTransport',API+'.Services','external protocol',[],['+ SendAsync(url: string, payload: unknown, signal: AbortSignal): Promise<unknown>'],'Opaque platform HTTP transport; no provider/framework imposed or backend runtime imported into frontend')

 def add_collaborator(name,target,role):
  c=classes[name];field='- '+role+': '+target
  if field not in c['attributes']:c['attributes'].append(field)
  pref='+ '+name+'('
  for i,op in enumerate(c['operations']):
   if op.startswith(pref):
    c['operations'][i]=op[:-1]+(', ' if op[len(pref):-1] else '')+role+': '+target+')';break
  else:c['operations'].insert(0,pref+role+': '+target+')')

 # Pricing is shared in process. It is not a new remotely deployed microservice.
 for uc in ['UC-C01','UC-C03','UC-C06','UC-C07']:
  add_collaborator(ucs[uc]['service'],'IBatchPricingPolicy','pricing')
  for p in pages:
   if p['owner']==uc and p['title']=='Application Services and Constructor Injection':
    p['classes'].append('IBatchPricingPolicy');p['edges'].append(dep(ucs[uc]['service'],'IBatchPricingPolicy','pricing'))
 # Checkout now uses the architecture-named calculator, which in turn owns the gateway seam.
 sv=classes['CheckoutService'];sv['attributes']=[x.replace('distanceGateway: IDistanceGateway','distanceCalculator: IDistanceCalculator') for x in sv['attributes']]
 sv['operations']=[x.replace('distanceGateway: IDistanceGateway','distanceCalculator: IDistanceCalculator') for x in sv['operations']]
 add_collaborator('CheckoutService','IDeliveryFeePolicy','deliveryFeePolicy')
 add_collaborator('CheckoutRepository','IFefoBatchSpecification','fefo')
 for p in pages:
  for edge in p['edges']:
   if edge['source']=='CheckoutService' and edge['target']=='IDistanceGateway':edge['target']='IDistanceCalculator';edge['label']='distanceCalculator'
  if p['owner']=='UC-C06' and p['title']=='Application Services and Constructor Injection':
   p['classes']=[('IDistanceCalculator' if n=='IDistanceGateway' else n) for n in p['classes']]+['IDeliveryFeePolicy','IFefoBatchSpecification']
   p['edges'] += [dep('CheckoutService','IDeliveryFeePolicy','deliveryFeePolicy'),dep('CheckoutRepository','IFefoBatchSpecification','fefo')]
 # Object navigations refine entity associations; they are derived/materialized, not new DB columns.
 navs=[('Customer','CustomerAddress','Addresses','0..*'),('ProductCategory','Product','Products','0..*'),('Product','BatchInventory','Batches','0..*'),('Cart','CartItem','Items','0..*'),('CartItem','Product','Product','1'),('Order','OrderDetail','Details','1..*'),('OrderDetail','BatchInventory','Batch','1'),('Order','Customer','Customer','1'),('Order','CustomerAddress','DeliveryAddress','1'),('Order','OrderPayment','Payments','0..*'),('Order','DeliveryFailure','Failure','0..1'),('Order','ReturnReceipt','Return','0..1'),('Order','Refund','Refund','0..1'),('ReturnReceipt','ReturnReceiptItem','Items','0..*'),('ReturnReceiptItem','ReturnInspection','Inspections','0..*')]
 for a,b,role,mult in navs:
  typ='ReadonlyArray<'+b+'>' if '*' in mult else b+'?' if mult=='0..1' else b
  field='+ '+role+': '+typ+' {read only; materialized navigation}'
  if field not in classes[a]['attributes']:classes[a]['attributes'].append(field)
 # Repository-managed references expose actual objects to the class view, not table-only foreign keys.
 for uc,info in ucs.items():
  repo=classes[info['feature']+'Repository']
  for entity in info['entities']:
   repo['attributes'].append('- materialized'+entity+': ReadonlyArray<'+entity+'> {request scoped; not a cache}')

 # Correct the earlier accidental .NET-specific signatures for the Node.js architecture.
 def normalize(text,owner):
  replace={'CancellationToken':'AbortSignal','IReadOnlyList':'ReadonlyArray','IReadOnlyDictionary':'ReadonlyMap','IEnumerable':'ReadonlyArray','ClaimsPrincipal':'AuthenticatedPrincipal','DbConnection':'DatabaseConnection','DbTransaction':'DatabaseTransaction','IServiceCollection':'RegistrationMap','HttpClient':'HttpTransport','DateOnly':'LocalDate'}
  for a,b in replace.items():text=text.replace(a,b)
  text=text.replace('Task<','Promise<');text=re.sub(r'\bTask\b','Promise<void>',text);text=text.replace('ct: AbortSignal','signal: AbortSignal')
  text=re.sub(r'\blong\b','EntityId',text);text=re.sub(r'\bint\b','number',text);text=re.sub(r'\bbool\b','boolean',text)
  if 'DateTimeOffset' in text:text=text.replace('DateTimeOffset','IsoDateTime' if owner['role']=='DTO' else 'Date')
  if 'decimal' in text:
   money=not any(k in text.lower() for k in ['latitude','longitude','distance','discountrate'])
   text=text.replace('decimal',('VndAmountString' if owner['role']=='DTO' else 'VndAmount') if money else 'number')
  return text
 for c in classes.values():
  c['attributes']=[normalize(x,c) for x in c['attributes']];c['operations']=[normalize(x,c) for x in c['operations']]
 # Public wire identifiers are opaque strings; a JS number must not truncate a SQL BIGINT.
 for c in classes.values():
  if c['package'].startswith(('FreshFood-Customer-Web','FreshFood-App')) or c['role']=='DTO':
   c['attributes']=[re.sub(r'((?:[A-Za-z]*Id|[A-Za-z]*Ids): )number\b',r'\1EntityId',x) for x in c['attributes']]
   c['operations']=[re.sub(r'((?:[A-Za-z]*Id|[A-Za-z]*Ids): )number\b',r'\1EntityId',x) for x in c['operations']]
  if c['package'].startswith('FreshFood-App'):
   c['attributes']=[re.sub(r'\bnumber\b','int',re.sub(r'\bboolean\b','bool',x)) for x in c['attributes']]
   c['operations']=[re.sub(r'\bnumber\b','int',re.sub(r'\bboolean\b','bool',x)) for x in c['operations']]

 domain=['IBatchPricingPolicy','BatchPricingPolicy','IDeliveryFeePolicy','DeliveryFeePolicy','VndAmount','EntityId','LocalDate']
 page('shared','Domain Policies and Exact VND Values',domain,[dep('BatchPricingPolicy','IBatchPricingPolicy','implements','realization'),dep('DeliveryFeePolicy','IDeliveryFeePolicy','implements','realization')])
 page('shared','Distance and FEFO Specification',['IDistanceCalculator','DistanceCalculator','IDistanceGateway','IFefoBatchSpecification','FefoBatchSpecification','BatchCriteria'],[dep('DistanceCalculator','IDistanceCalculator','implements','realization'),dep('DistanceCalculator','IDistanceGateway','gateway'),dep('FefoBatchSpecification','IFefoBatchSpecification','implements','realization')])
 page('shared','Node Runtime and Wire Contracts',['VndAmountString','IsoDateTime','AuthenticatedPrincipal','DatabaseConnection','DatabaseTransaction','RegistrationMap','HttpTransport'],[])

 patterns={'IBatchPricingPolicy':'DI / pricing domain policy','BatchPricingPolicy':'Domain policy','IDeliveryFeePolicy':'DI / delivery domain policy','DeliveryFeePolicy':'Domain policy','IDistanceCalculator':'DI / adapter coordination','DistanceCalculator':'Layered domain service','IFefoBatchSpecification':'Query Specification contract','FefoBatchSpecification':'Query Specification','IUnitOfWork':'Unit of Work / transaction boundary','ITransitionExecutor':'Transition dispatch contract','TransitionExecutor':'One class per transition / DI'}
 ext={'GeocodingBoundary':['IGeocodingGateway','GoogleMapsGeocodingAdapter'],'DistanceBoundary':['IDistanceCalculator','DistanceCalculator','IDistanceGateway','GoogleMapsDistanceAdapter'],'PaymentBoundary':['IPaymentGateway','SePayPaymentAdapter','PaymentNoticeHandler'],'NotificationBoundary':['INotificationGateway','NotificationAdapter'],'OrderNotificationBoundary':['INotificationGateway','NotificationAdapter']}
 mappings=[];overviews=[]
 for uc,info in ucs.items():
  f=info['feature'];source=next(Path('artifacts/diagrams/class').glob(uc.lower()+'-*vopc.drawio'));vopc=[]
  for cell in E.parse(source).findall('.//mxCell'):
   bold=re.findall(r'<b>(.*?)</b>',cell.get('value',''))
   if bold:
    n=html.unescape(re.sub('<[^>]+>','',bold[0])).strip()
    if n in classes or n in ext or n==info['analysis_view']:vopc.append(n)
  core=[f+'Page',info['analysis_view'],f+'ApiClient',f+'ViewModel',f+'ApiModel',info['controller'],'I'+f+'Service',f+'Service','I'+f+'Repository',f+'Repository']
  source_entities=[n for n in vopc if classes.get(n,{}).get('role')=='entity']
  helpers=[]
  for n in vopc:
   if n in ext:helpers+=ext[n]
  if uc!='UC-C01':helpers+=['IUnitOfWork','ICurrentCustomer']
  if uc in ['UC-C01','UC-C03','UC-C06','UC-C07']:helpers+=['IBatchPricingPolicy','BatchPricingPolicy']
  if uc=='UC-C06':helpers+=['IDeliveryFeePolicy','DeliveryFeePolicy','IFefoBatchSpecification','FefoBatchSpecification']
  if uc in ['UC-C06','UC-C07']:helpers+=['ITransitionExecutor','TransitionExecutor']
  helpers=list(dict.fromkeys(n for n in helpers if n not in core+source_entities))
  names=core+source_entities+helpers;names=list(dict.fromkeys(names));tags={}
  for n in vopc:
   if n==info['analysis_view']:targets=[f+'Page',f+'ApiClient',n,f+'ViewModel',f+'ApiModel'];solution='Web Pages / CallService; mobile MVVM; no frontend DI'
   elif n in ext:targets=ext[n];solution='Adapter / backend DI'
   elif n==f+'Service':
    targets=['I'+f+'Service',n,'I'+f+'Repository',f+'Repository']
    if uc in ['UC-C01','UC-C03','UC-C06','UC-C07']:targets+=['IBatchPricingPolicy','BatchPricingPolicy']
    if uc=='UC-C06':targets+=['IDeliveryFeePolicy','DeliveryFeePolicy','IFefoBatchSpecification','FefoBatchSpecification']
    solution='Layered application logic + service interface extraction + Repository / domain policies / backend DI'
   elif n==info['controller']:targets=[n];solution='API controller retained; service interface supplied by backend DI'
   else:targets=[n];solution='Domain entity retained; navigations and invariants refined from data requirements'
   assert set(targets)<=set(names),(uc,n,targets)
   mappings.append({'UseCase':uc,'AnalysisClass':n,'DesignClasses':targets,'SelectedSolution':solution})
   for target in targets:tags.setdefault(target,[]).append(n)
  edges=[]
  # Pull the declared collaborations together on a single view, without inventing frontend DI.
  for p in pages:
   if p['owner']==uc or p['owner']=='shared':
    for e in p['edges']:
     if e['source'] in names and e['target'] in names and e not in edges:edges.append(e.copy())
  for entity in source_entities:edges.append(dep(f+'Repository',entity,'materializes'))
  for a,b,role,mult in navs:
   if a in names and b in names and not any(e['source']==a and e['target']==b for e in edges):edges.append(dep(a,b,'1 : '+mult))
  unique_edges=[];edge_keys=set()
  for e in edges:
   key=(e['source'],e['target'],e['kind'])
   if key not in edge_keys:unique_edges.append(e);edge_keys.add(key)
  edges=unique_edges
  # Interface realization of all source-bound external adapters keeps them connected to the service.
  for n in helpers:
   if n in patterns and n not in tags:tags[n]=[]
  lanes=[[f+'Page',info['analysis_view']],[f+'ApiClient',f+'ViewModel',f+'ApiModel'],[info['controller'],'I'+f+'Service',f+'Service'],['I'+f+'Repository',f+'Repository'],source_entities]
  if len(helpers)>10:
   middle=(len(helpers)+1)//2;lanes += [helpers[:middle],helpers[middle:]]
  elif helpers:lanes.append(helpers)
  overviews.append({'owner':uc,'title':'VOPC to Detailed Design Realization','classes':names,'edges':edges,'compact':True,'lanes':lanes,'origin_tags':{n:(', '.join(tags.get(n,[])) or 'design support') for n in names},'pattern_tags':{n:patterns.get(n,'Repository' if n.endswith('Repository') else 'Backend DI contract' if n.startswith('I') and classes[n]['role']=='interface' else 'Adapter' if classes[n]['role']=='adapter' else '') for n in names}})
 # Add an overview before the existing full member views for each use case.
 ordered=[]
 for uc in ucs:ordered += [p for p in overviews if p['owner']==uc]+[p for p in pages if p['owner']==uc]
 ordered += [p for p in pages if p['owner'] not in ucs];pages[:]=ordered
 for c in classes.values():c['status']='Proposed Node.js-aligned detailed design - review required'
 Path('artifacts/design/detailed/vopc-realization-mapping.json').write_text(json.dumps(mappings,indent=2))
 return {'architecture_runtime':'Node.js','signature_notation':'Typed UML with Node-compatible Promise/AbortSignal; no language tooling, HTTP framework, DI library or SQL driver selected','vopc_realizations':len(mappings),'selected_patterns':['Layered Modular Monolith','Repository','Adapter','Unit of Work','backend-only constructor DI','mobile MVVM','FEFO query specification','one class per transition']}
