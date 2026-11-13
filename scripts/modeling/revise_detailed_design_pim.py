"""Authorized PIM normalization; source refinements are retained in an explicit map."""
from pathlib import Path
import json,re,copy,shutil,csv
R=Path(__file__).resolve().parents[2];D=R/'artifacts/design/detailed'
def dump(path,value):path.parent.mkdir(parents=True,exist_ok=True);path.write_text(json.dumps(value,ensure_ascii=False,indent=2)+'\n',encoding='utf-8')
def split(text):
 result=[];start=0;depth=0
 for i,ch in enumerate(text):
  if ch in '<([{':depth+=1
  elif ch in '>)]}':depth-=1
  elif ch==',' and depth==0:result.append(text[start:i].strip());start=i+1
 if text[start:].strip():result.append(text[start:].strip())
 return result
def pim_type(value):
 value=re.sub(r'\s*\{.*','',value).strip()
 if value.endswith('?'):return pim_type(value[:-1])+'?'
 if value.endswith('[]'):return 'Sequence<'+pim_type(value[:-2])+'>'
 g=re.fullmatch(r'(\w+)<(.*)>',value)
 if g:
  outer,inner=g.groups()
  if outer in ['Task','Promise','Future']:return pim_type(inner)
  if outer in ['List','ReadonlyArray','IReadOnlyList','IReadOnlyCollection','IEnumerable']:return 'Sequence<'+pim_type(inner)+'>'
  if outer=='Func':return 'TransactionWork'
  if outer=='ILogger':return 'DiagnosticLog'
  return outer+'<'+', '.join(pim_type(x) for x in split(inner))+'>'
 return {'void':'Void','Task':'Void','ValueTask':'Void','string':'Text','int':'Integer','long':'Integer','number':'Decimal','decimal':'Decimal','double':'Decimal','bool':'Boolean','boolean':'Boolean','object':'Value','Object':'Value','unknown':'Value','DateTimeOffset':'DateTime','IsoDateTime':'DateTime','DateOnly':'Date','LocalDate':'Date','bigint':'Integer','NpgsqlDataSource':'ConnectionProvider','NpgsqlTransaction':'TransactionContext','NpgsqlConnection':'Connection','HttpClient':'HttpTransport','ClaimsPrincipal':'AuthenticatedPrincipal','IServiceCollection':'RegistrationMap','IConfiguration':'Configuration','IHttpContextAccessor':'RequestContext','IDataProtectionProvider':'SessionTokenProtector','ReactNode':'View','Widget':'View'}.get(value,'ServiceFactory' if '=>' in value else value)

def run():
 current=json.loads((D/'detailed-class-model.json').read_text(encoding='utf-8'))
 archive=R/'artifacts/design/baselines/mixed-psm-20261103';archive.mkdir(parents=True,exist_ok=True)
 snapshot=R/'artifacts/implementation/psm-contract-model.json'
 if not snapshot.exists():
  dump(snapshot,current);dump(archive/'detailed-class-model.json',current)
  for folder in ['class','sequence']:
   for path in (R/'artifacts/diagrams'/folder).glob('*design-*.drawio'):
    dest=archive/'diagrams'/folder/path.name;dest.parent.mkdir(parents=True,exist_ok=True);shutil.copy2(path,dest)
  for name in ['design-code-sequence-consistency.json','design-code-consistency-findings.json']:
   if (D/name).exists():shutil.copy2(D/name,archive/name)
 old=json.loads(snapshot.read_text(encoding='utf-8'));m=copy.deepcopy(old)
 rename={'PostgreSqlSession':'RepositorySession'}
 mapping=[];source=json.loads((D/'source-consistency-symbols.json').read_text(encoding='utf-8'));types={x['name']:x for x in source['classes']}
 for original,c in list(m['classes'].items()):
  c['attributes']=[prefix+': '+pim_type(t) if sep else a for a in c['attributes'] for prefix,sep,t in [a.partition(': ')]]
  c['attributes']=[a for a in c['attributes'] if not re.match(r'[-+] logger:',a)]
  ops=[]
  for text in old['classes'][original]['operations']:
   match=re.match(r'([+\-#~])\s+(\w+)(<[^()]*>)?\((.*)\)(?::\s*(.*))?$',text.replace(' {static}',''))
   if not match:continue
   vis,name,generic,args,result=match.groups();params=[]
   for arg in split(args):
    if ': ' not in arg:continue
    key,value=arg.split(': ',1)
    if key in ['signal','logger']:continue
    if name.endswith('GetCartAsync') and key=='identity':continue
    params.append(key+': '+pim_type(value))
   signature=vis+' '+name+(generic or '')+'('+', '.join(params)+')'+(': '+pim_type(result) if result else '')
   ops.append(signature)
  c['operations']=ops;c['status']='PIM revision 0.6; authorized platform-independence correction 2026-11-03; review evidence recorded separately'
  if original in ['IUnitOfWork','UnitOfWork']:
   ctor=[x for x in ops if x.startswith('+ UnitOfWork(')]
   c['operations']=ctor+['+ ExecuteAsync(work: TransactionWork): Value']
  if original in ['IRepositorySession','PostgreSqlSession']:
   c['operations']=[x for x in c['operations'] if 'QueryAsync' not in x]+['+ QueryAsync(statement: Query, parameters: Sequence<Value>): Sequence<Record>']
  if original=='TransactionWork':c['operations']=['+ InvokeAsync(): Value']
  if original=='TransitionSnapshot':
   c['attributes']=['+ AggregateId: EntityId {readOnly}','+ CustomerId: EntityId {serverResolved}','+ ActorId: EntityId {serverResolved}','+ Order: Order {serverResolved}','+ Batches: Sequence<BatchInventory> {serverResolved}','+ GuardFacts: GuardFactsDto {serverResolved}']
   c['operations']=['~ TransitionSnapshot(order: Order, facts: GuardFactsDto)']
  if original=='OrderDetail':c['attributes']+=['+ ProductId: EntityId {derived projection}','+ ProductName: Text {derived projection}']
  if original=='OrderStateMachine':c['attributes']=['- repository: IOrderLifecycleRepository','- transitionTable: Sequence<Value> {private transition definitions}','- snapshot: TransitionSnapshot?']
  if original=='VndAmount':
   c['attributes']=[a.replace('Units: Decimal','Units: Integer') for a in c['attributes']]
   c['operations']=[a.replace('units: Decimal','units: Integer') for a in c['operations']]
  if c['role']=='DTO':
   money={'SubTotal','ShippingFee','Total','TotalAmount','CurrentPrice','LineTotal','UnitPrice','Discount','GoodsRefunded','ShippingRefunded','GoodsAmount','ShippingAmount','CapturedGoods','CapturedShipping','SettledRefund'}
   c['attributes']=[re.sub(r': Text\b',': VndAmount',a) if a.split(':',1)[0].lstrip('+-#~ ') in money else a for a in c['attributes']]
  actual=types.get(original)
  for signature in c['operations']:
   name=re.search(r'\s(\w+)(?:<[^>]*>)?\(',signature)[1]
   candidates=[x for x in (actual or {}).get('methods',[]) if x['name']==name]
   if original=='ProfileController' and name=='SaveAddressAsync':candidates+=[x for x in actual['methods'] if x['name']=='UpdateAddressAsync']
   rationale=['Logical result maps to the platform async wrapper; cancellation and diagnostics are local technical concerns.']
   if original.endswith('Controller'):rationale+=['HTTP route/body binding assembles the logical request; action signatures need not be identical to PIM.']
   if name.endswith('GetCartAsync'):rationale+=['Identity is resolved by CurrentCustomer on the server. The existing service identity argument is a technical legacy parameter, not caller authority.']
   if name=='ExecuteAsync':rationale+=['One logical transaction responsibility maps to generic and non-generic result overloads.']
   if name=='QueryAsync':rationale+=['SQL text/parameters, generic materialization T and provider connection details refine the logical query contract.']
   if original=='TransitionSnapshot':rationale+=['Internal constructor and flags implement a trusted server-only context. Logical guard facts are flattened/derived; future staff/payment facts remain deferred.']
   status='Implemented' if candidates else 'FrontendDesignOnly' if not c['package'].startswith(('FreshFood-API','FreshFood.Reposistory')) else 'FrameworkRefinement'
   if original in ['GoogleMapsGeocodingAdapter','GoogleMapsDistanceAdapter','SePayPaymentAdapter','ConfiguredNotificationPublisher','UnconfiguredPayoutAdapter'] or original=='CheckoutService' and name in ['CreatePaymentQrAsync','HandleVerifiedPaymentAsync']:status='DeferredIntegration'
   mapping.append({'pimClass':rename.get(original,original),'pimOperation':signature.replace('PostgreSqlSession','RepositorySession'),'sourceClass':original,'sourceMembers':candidates,'adaptation':rationale,'status':status})
 # Rename the provider-neutral session role consistently in the PIM, including all views/edges.
 def replace(v):
  if isinstance(v,str):return v.replace('PostgreSqlSession','RepositorySession')
  if isinstance(v,list):return [replace(x) for x in v]
  if isinstance(v,dict):return {rename.get(k,k):replace(x) for k,x in v.items()}
  return v
 m=replace(m)
 for page in m['pages']:
  page['edges']=[e for e in page['edges'] if not(e['source']=='TransitionSnapshot' and e['target']=='CheckoutLineDto')]
  if 'TransitionSnapshot' in page['classes']:
   for name in ['Order','BatchInventory']:
    if name in page['classes'] and not any(e['source']=='TransitionSnapshot' and e['target']==name for e in page['edges']):page['edges'].append({'source':'TransitionSnapshot','target':name,'kind':'dependency','label':'trusted context'})
 m['version']='0.6';m['date']='2026-11-03';m['model_level']='PIM';m['status']='Authorized PIM alignment; deferred integrations explicitly mapped'
 m['architecture_alignment']['signature_notation']='Platform-independent logical operations and types; implementation refinements are in pim-to-code-mapping.json'
 dump(D/'detailed-class-model.json',m)
 dump(D/'pim-to-code-mapping.json',{'date':'2026-11-03','model_level':'PIM','implementation_platform':'ASP.NET Core 10 / C#','class_aliases':rename,'operations':mapping,'data_refinements':{'money':'PIM VndAmount denotes exact integer VND; source uses a decimal-backed validated value object and decimal-string DTO/wire projection.','identity':'Logical identity is server-resolved; BIGINT identifiers retain string JSON representation.','snapshot':'Logical Order/Batches/GuardFacts map to the internal server-only TransitionSnapshot context; current state is derived from Order and execution flags.','projection':'OrderDetail ProductId/ProductName are joined read projections, not additional database columns.'},'deferred_scope':'Existing payment correlation/provider and outgoing payout policies are not invented by this revision.'})
 with (D/'pim-to-code-mapping.csv').open('w',encoding='utf-8',newline='') as f:
  w=csv.writer(f);w.writerow(['PIM Class','PIM Operation','C# Class','C# Members','Adaptation','Status'])
  for row in mapping:w.writerow([row['pimClass'],row['pimOperation'],row['sourceClass'],'; '.join(x['name']+' @ '+x['file']+':'+str(x['line']) for x in row['sourceMembers']),' '.join(row['adaptation']),row['status']])
 print('Saved PIM model and',len(mapping),'explicit operation refinements; mixed-level baseline archived.')
if __name__=='__main__':run()
