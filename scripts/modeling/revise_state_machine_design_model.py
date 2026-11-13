from pathlib import Path
import json,csv,copy,re,os,shutil
root=Path.cwd().resolve();D=root/'artifacts/design/detailed';m=json.loads((D/'detailed-class-model.json').read_text(encoding='utf-8-sig'))
if m.get('selected_state_machine_pattern','').startswith('Table-driven'):
 print('State-machine model already revised; use the authoritative model for further edits');raise SystemExit(0)
old_handlers={r['class'] for r in m['transitions']};removed=old_handlers|{'IStateTransition','ITransitionExecutor','TransitionExecutor'}
rename={'TransitionCommand':'StateMachineEvent','TransitionResult':'StateMachineResult','ITransitionExecutor':'IOrderStateMachine','TransitionExecutor':'OrderStateMachine','IStateTransition':'IOrderStateMachine',**{n:'OrderStateMachine' for n in old_handlers}}
def swap(value):
 if not isinstance(value,str):return value
 for a,b in sorted(rename.items(),key=lambda p:-len(p[0])):value=re.sub(r'\b'+re.escape(a)+r'\b',b,value)
 return value.replace('transitionExecutor','orderStateMachine')
classes={}
for n,c in m['classes'].items():
 if n in removed:continue
 c=copy.deepcopy(c);c['name']=swap(n);c['attributes']=[swap(a) for a in c['attributes']];c['operations']=[swap(o) for o in c['operations']];classes[c['name']]=c
basis='Stakeholder selection 2026-11-02: table-driven OrderStateMachine replaces individual transition classes'
def cls(n,role,attrs,ops):return {'name':n,'package':'FreshFood-API.Services' if role=='interface' else 'FreshFood-API.DTOs' if role=='DTO' else 'FreshFood-API.Services.Implements','role':role,'attributes':attrs,'operations':ops,'basis':basis,'scope':'shared','status':'Authorized replacement; revised artifacts for review'}
classes['IOrderStateMachine']=cls('IOrderStateMachine','interface',[],['+ processEvent(snapshot: TransitionSnapshot, event: StateMachineEvent, signal: AbortSignal): Promise<StateMachineResult>','+ currentState(): OrderStateSnapshot?'])
classes['OrderStateMachine']=cls('OrderStateMachine','state-machine control',['- repository: IOrderLifecycleRepository','- transitionTable: ReadonlyArray<object> {private; read only}','- snapshot: TransitionSnapshot? {server trusted; request scoped}'],['+ OrderStateMachine(repository: IOrderLifecycleRepository)','+ processEvent(snapshot: TransitionSnapshot, event: StateMachineEvent, signal: AbortSignal): Promise<StateMachineResult>','+ currentState(): OrderStateSnapshot?'])
classes['OrderStateSnapshot']=cls('OrderStateSnapshot','DTO',['+ FulfillmentState: OrderStatus?','+ PaymentState: PaymentStatus?','+ RefundState: string?','+ WorkflowNode: string? {transient UML position}','+ FulfillmentCompleted: boolean'],[])
classes['StateMachineEvent']['attributes']=['+ Event: string','+ AggregateId: EntityId','+ EventId: string','+ Reason: string?'];classes['StateMachineEvent']['basis']=basis
classes['StateMachineResult']['attributes']=['+ Applied: boolean','+ Duplicate: boolean','+ TransitionIds: ReadonlyArray<string>','+ State: OrderStateSnapshot'];classes['StateMachineResult']['basis']=basis
classes['ApiCompositionRoot']['operations']=['+ ConfigureServices(services: RegistrationMap): void']
classes['AuditLog']['attributes']=[a.replace('StaffId: number ','StaffId: number? ') for a in classes['AuditLog']['attributes']]+['+ CustomerId: EntityId? {private set}','+ ActorType: string {derived; read only}']
extra=['+ ClaimCheckoutAsync(customerId: EntityId, reference: string, key: string, requestHash: string, signal: AbortSignal): Promise<object>','+ CompleteCheckoutAsync(customerId: EntityId, reference: string, key: string, response: object, signal: AbortSignal): Promise<void>']
for n in ['ICheckoutRepository','CheckoutRepository']:
 for op in extra:
  if op not in classes[n]['operations']:classes[n]['operations'].append(op)
m['classes']=classes;m['version']='0.4';m['date']='2026-11-02';m['status']='Revised by explicit stakeholder selection: table-driven state-machine control'
m['selected_state_machine_pattern']='Table-driven OrderStateMachine with processEvent/currentState; no per-transition implementation classes'
for r in m['transitions']:r['class']='OrderStateMachine';r['implementation']='private transition-table row '+r['id']
newpages=[]
for p in m['pages']:
 if p['owner']=='transitions':continue
 p=copy.deepcopy(p);p['classes']=list(dict.fromkeys(swap(n) for n in p['classes']))
 p['classes']=[n for n in p['classes'] if n in classes]
 edges=[];seen=set()
 for e in p['edges']:
  e={**e,'source':swap(e['source']),'target':swap(e['target']),'label':swap(e.get('label',''))}
  if e['source']==e['target'] or e['source'] not in p['classes'] or e['target'] not in p['classes']:continue
  if e['source']=='OrderStateMachine' and e['target']=='IUnitOfWork':continue
  key=(e['source'],e['target'],e['kind'])
  if key not in seen:seen.add(key);edges.append(e)
 p['edges']=edges;p['title']=p['title'].replace('Handler','State Machine').replace('Transition Handler','State Machine').replace('Transition Contracts','State Machine Contracts')
 for field in ['origin_tags','pattern_tags']:
  if field in p:
   tags={}
   for k,v in p[field].items():
    n=swap(k)
    if n in p['classes']:tags[n]=swap(v)
   if 'OrderStateMachine' in tags and field=='pattern_tags':tags['OrderStateMachine']='Table-driven state-machine control'
   p[field]=tags
 if 'lanes' in p:
  used=set();lanes=[]
  for lane in p['lanes']:
   new=[]
   for n in lane:
    n=swap(n)
    if n in p['classes'] and n not in used:used.add(n);new.append(n)
   if new:lanes.append(new)
  p['lanes']=lanes
 if p['classes']:newpages.append(p)
names=['OrderStateMachine','IOrderStateMachine','IOrderLifecycleRepository','TransitionSnapshot','StateMachineEvent','StateMachineResult','OrderStateSnapshot','Order']
edges=[{'source':'OrderStateMachine','target':'IOrderStateMachine','kind':'realization','label':''},{'source':'OrderStateMachine','target':'IOrderLifecycleRepository','kind':'association','label':'repository'}]
for n in ['TransitionSnapshot','StateMachineEvent','StateMachineResult','OrderStateSnapshot','Order']:edges.append({'source':'OrderStateMachine','target':n,'kind':'dependency','label':'uses'})
edges.append({'source':'StateMachineResult','target':'OrderStateSnapshot','kind':'association','label':'State'})
newpages.append({'owner':'transitions','title':'Order State Machine Control and Private Transition Table','classes':names,'edges':edges})
m['pages']=newpages
(D/'detailed-class-model.json').write_text(json.dumps(m,indent=2),encoding='utf-8')
# Rewrite mappings and DI registry while preserving stable use case / transition identifiers.
for name in ['vopc-realization-mapping.json','dto-entity-usage.json']:
 p=D/name
 if p.exists():
  obj=json.loads(p.read_text(encoding='utf-8-sig'))
  def walk(x):
   if isinstance(x,str):return swap(x)
   if isinstance(x,list):
    vals=[walk(v) for v in x];return list(dict.fromkeys(vals)) if all(isinstance(v,str) for v in vals) else vals
   if isinstance(x,dict):return {swap(k):walk(v) for k,v in x.items()}
   return x
  p.write_text(json.dumps(walk(obj),indent=2),encoding='utf-8')
p=D/'dependency-injection-registrations.csv';rows=list(csv.DictReader(p.open(encoding='utf-8-sig')));rows=[r for r in rows if r['Contract']!='IStateTransition']
for r in rows:
 for k in r:r[k]=swap(r[k])
 r['Status']='Authorized table-driven replacement; backend implementation review'
with p.open('w',encoding='utf-8',newline='') as f:w=csv.DictWriter(f,fieldnames=list(rows[0]));w.writeheader();w.writerows(rows)
# Archive obsolete source files, never leave per-transition classes in the active source graph.
archive=root/'artifacts/implementation/baselines/per-transition-20261101';archive.mkdir(parents=True,exist_ok=True)
old_paths=json.loads((root/'scratch/backend-mapping-paths.json').read_text())
for n in removed|{'TransitionCommand','TransitionResult'}:
 if n in old_paths:
  source=root/old_paths[n]
  if source.exists():
   target=archive/old_paths[n];target.parent.mkdir(parents=True,exist_ok=True)
   assert source.resolve().is_relative_to(root) and target.resolve().is_relative_to(root)
   shutil.move(str(source),str(target))
source=root/'src/FreshFood-API/Services/Implements/TransitionHandler.js'
if source.exists():target=archive/'TransitionHandler.js';shutil.move(str(source),str(target))
# Materialize new internal DTO shapes.
for n in ['StateMachineEvent','StateMachineResult','OrderStateSnapshot']:
 c=classes[n];fields=[re.match(r'\+ (\w+):',a)[1] for a in c['attributes']]
 path=root/'src/FreshFood-API/DTOs'/f'{n}.js';path.write_text('export class '+n+' { constructor(values={}) { '+''.join('this.'+a+'=values.'+a+';' for a in fields)+' } }\n',encoding='utf-8')
print('Revised model:',len(classes),'classifiers,',len(newpages),'class pages; obsolete source classes archived')
