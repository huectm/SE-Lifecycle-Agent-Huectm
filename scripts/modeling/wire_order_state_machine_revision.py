from pathlib import Path
import json,re,csv,os
root=Path.cwd();D=root/'artifacts/design/detailed';m=json.loads((D/'detailed-class-model.json').read_text());C=m['classes']
data=['TransitionSnapshot','StateMachineEvent','StateMachineResult','OrderStateSnapshot']
for p in m['pages']:
 if not any(n in p['classes'] for n in ['OrderStateMachine','IOrderStateMachine']):continue
 added=[]
 for n in data:
  if n not in p['classes']:p['classes'].append(n);added.append(n)
 if p.get('compact'):
  p['lanes'][-1].extend(added)
  for n in added:p['origin_tags'][n]='Internal state-machine data';p['pattern_tags'][n]='Table-driven state-machine control'
 for source in ['OrderStateMachine','IOrderStateMachine']:
  if source in p['classes']:
   for target in data:
    if not any(e['source']==source and e['target']==target and e['kind']=='dependency' for e in p['edges']):p['edges'].append({'source':source,'target':target,'kind':'dependency','label':'uses'})
 if not any(e['source']=='StateMachineResult' and e['target']=='OrderStateSnapshot' for e in p['edges']):p['edges'].append({'source':'StateMachineResult','target':'OrderStateSnapshot','kind':'association','label':'State'})
(D/'detailed-class-model.json').write_text(json.dumps(m,indent=2),encoding='utf-8')
api=root/'src/FreshFood-API';paths={}
for n,c in C.items():
 if not c['package'].startswith(('FreshFood-API','FreshFood.Reposistory')):continue
 project='FreshFood-API' if c['package'].startswith('FreshFood-API') else 'FreshFood.Reposistory';tail=c['package'][len(project):].strip('.').replace('.','/');p=root/'src'/project/tail/(n+'.js');paths[n]=p.relative_to(root).as_posix();assert p.exists(),str(p)
meta={};catalog=[]
for n,path in paths.items():
 c=C[n];ops=[match[1] for o in c['operations'] if (match:=re.match(r'\+ (\w+)\(',o)) and match[1]!=n];meta[n]={'file':path,'role':c['role'],'operations':ops,'revision':'2026-11-02 table-driven state-machine replacement'}
 if n!='ApiCompositionRoot':
  url=os.path.relpath(root/path,api).replace('\\','/');url=url if url.startswith('.') else './'+url;catalog.append('import { '+n+' } from '+json.dumps(url)+';')
catalog.append('export const classes = {'+', '.join(n for n in paths if n!='ApiCompositionRoot')+'};')
(api/'class-catalog.js').write_text('\n'.join(catalog)+'\n',encoding='utf-8');(api/'design-contracts.json').write_text(json.dumps(meta,indent=2),encoding='utf-8');(root/'scratch/backend-mapping-paths.json').write_text(json.dumps(paths,indent=2),encoding='utf-8')
constructors={}
for n,c in C.items():
 ctor=next((o for o in c['operations'] if o.startswith('+ '+n+'(')),None)
 if ctor:constructors[n]=[p.split(':',1)[1].strip() for p in re.search(r'\((.*?)\)',ctor)[1].split(',') if p.strip()]
rows=list(csv.DictReader((D/'dependency-injection-registrations.csv').open(encoding='utf-8-sig')))
(api/'bindings.js').write_text('export const bindings = '+json.dumps(rows,indent=2)+';\nexport const constructors = '+json.dumps(constructors,indent=2)+';\n',encoding='utf-8')
(api/'ApiCompositionRoot.js').write_text('''import {classes} from './class-catalog.js';
import {bindings,constructors} from './bindings.js';
export class ApiCompositionRoot {
  ConfigureServices(services){
    const construct=name=>new classes[name](...(constructors[name]??[]).map(type=>services.Resolve(type)));
    for(const row of bindings)services.Bind(row.Contract,()=>construct(row.Implementation));
    for(const name of ['CatalogController','CartController','ProfileController','CheckoutController','MyOrdersController','PaymentNoticeHandler'])services.Bind(name,()=>construct(name));
  }
}
''',encoding='utf-8')
# Reconcile source comments with the selected design revision rather than retaining old contracts.
for n,path in paths.items():
 p=root/path;s=p.read_text(encoding='utf-8');s=re.sub(r'/\*\*\n \* Approved design classifier:.*?\*/\n','',s,count=1,flags=re.S)
 c=C[n];header='/**\n * Design revision 2026-11-02: '+n+'\n * Ownership: '+c['package']+'\n'+''.join(' * '+x+'\n' for x in c['attributes']+c['operations'])+' */\n';p.write_text(header+s,encoding='utf-8')
p=api/'tests/backend.test.js';s=p.read_text(encoding='utf-8')
s=re.sub(r"import \{ (TransitionExecutor|AcceptOrderTransition|EnterPendingUnpaidTransition|InitializeUnpaidPaymentTransition|CancelPendingUnpaidTransition) \} from '[^']+';\n",'',s)
s="import { OrderStateMachine } from '../Services/Implements/OrderStateMachine.js';\n"+s
s=re.sub(r'const transitions=\[new AcceptOrderTransition\(lifecycle\).*?const executor=new TransitionExecutor\(transitions,unit,lifecycle\);','const executor=new OrderStateMachine(lifecycle);',s)
s=s.replace("const x=new TransitionExecutor([],uow().unit,{});await assert.rejects(x.ExecuteInCurrentTransactionAsync({AggregateId:'1'},{AggregateId:'1',TransitionId:'T01p'})", "const x=new OrderStateMachine({});await assert.rejects(x.processEvent({AggregateId:'1'},{AggregateId:'1',Event:'acceptOrder'})")
s=s.replace("test('DI resolves all five controllers and exactly 24 transition handlers'", "test('DI resolves five controllers and one table-driven state machine'")
s=s.replace("const handlers=scope.ResolveMany('IStateTransition');assert.equal(handlers.length,24);assert.equal(new Set(handlers.map(x=>x.Id)).size,24);", "const machine=scope.Resolve('IOrderStateMachine');assert.equal(typeof machine.processEvent,'function');assert.equal(typeof machine.currentState,'function');assert.equal(machine.currentState(),null);assert.equal(scope.ResolveMany('IStateTransition').length,0);")
s=s.replace('const executor=new TransitionExecutor([new CancelPendingUnpaidTransition(lifecycle)],f.x.unit,lifecycle);f.service.transitionExecutor=executor;', 'const executor=new OrderStateMachine(lifecycle);f.service.orderStateMachine=executor;')
p.write_text(s,encoding='utf-8')
print('Updated DI and test wiring:',len(paths),'backend classifiers; no transition-class bindings')
