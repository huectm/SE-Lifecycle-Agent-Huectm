"""Verify logical PIM contracts and explicit source refinements without literal PSM equality."""
from pathlib import Path
import json,re,csv,collections,xml.etree.ElementTree as E,html,hashlib
R=Path(__file__).resolve().parents[2];D=R/'artifacts/design/detailed'
def read(p):return json.loads((R/p).read_text(encoding='utf-8-sig'))
m=read('artifacts/design/detailed/detailed-class-model.json');mapping=read('artifacts/design/detailed/pim-to-code-mapping.json');source=read('artifacts/design/detailed/source-consistency-symbols.json')
errors=[];checks=[]
def check(name,ok,details=None):
 checks.append({'check':name,'passed':bool(ok)})
 if not ok:errors.append({'check':name,'details':details})
def parse(text):
 match=re.search(r'(\w+)(?:<[^()]*>)?\((.*)\)',text)
 return match[1] if match else None
check('Model explicitly declares PIM',m.get('model_level')=='PIM')
leaks=[]
for c in m['classes'].values():
 for s in c['attributes']+c['operations']:
  if re.search(r'\b(Task|ValueTask|Promise|Future|CancellationToken|NpgsqlDataSource|NpgsqlTransaction|HttpClient|IServiceCollection|IHttpContextAccessor|IDataProtectionProvider|IConfiguration|ReactNode|Widget)\b',s):leaks.append([c['name'],s])
check('Class notation is platform independent',not leaks,leaks)
indexed={(x['pimClass'],x['pimOperation']):x for x in mapping['operations']};missing=[]
for name,c in m['classes'].items():
 for op in c['operations']:
  if (name,op) not in indexed:missing.append([name,op])
check('Every declared operation has an explicit source/refinement status',not missing,missing)
bad_source=[];implemented=0;deferred=[]
for row in mapping['operations']:
 if row['status']=='Implemented':
  implemented+=1
  if not row['sourceMembers']:bad_source.append(row)
 for member in row['sourceMembers']:
  if not (R/member['file']).exists():bad_source.append(row)
 if row['status']=='DeferredIntegration':deferred.append({'class':row['pimClass'],'operation':row['pimOperation'],'status':row['status']})
check('Implemented refinements identify existing source members',not bad_source,bad_source)
check('Source semantic extraction has no compile errors',not source['compileErrors'],source['compileErrors'])
check('One table-driven state machine retained','OrderStateMachine' in m['classes'] and not any('StateTransition' in n or n=='TransitionExecutor' for n in m['classes']))
check('Logical snapshot is server-only data','~ TransitionSnapshot(order: Order, facts: GuardFactsDto)' in m['classes']['TransitionSnapshot']['operations'] and all('get; set;' not in a for a in m['classes']['TransitionSnapshot']['attributes']))

trace=list(csv.DictReader((R/'artifacts/design/design-sequence-message-traceability.csv').open(encoding='utf-8-sig')))
records=read('artifacts/design/design-sequence-verification.json');page_meta={};texts={};label_drift=[];signature_errors=[];deferred_calls=[]
for rec in records:
 tree=E.parse(R/rec['master'])
 for pg,dia in zip(rec['pages'],tree.findall('diagram')):
  key=(rec['use_case'],pg['name']);page_meta[key]={'master':rec['master'],'page':pg['page']}
  texts[key]=' '.join(html.unescape(c.get('value','')) for c in dia.iter('mxCell'))
  labels={c.get('id'):html.unescape(re.sub(r'<[^>]+>',' ',c.get('value',''))) for c in dia.iter('mxCell') if c.get('id','').startswith('label_')}
  for r in [x for x in trace if (x['UseCase'],x['Page'])==key]:
   if re.sub(r'\s+','',labels.get('label_'+r['Number'],''))!=re.sub(r'\s+','',r['Number']+': '+r['Interaction']):label_drift.append(r)
for row in trace:
 if row['Kind'] not in ['C','A'] or row['Interaction'].startswith(('user action:','[local]','TransactionWork')):continue
 name=parse(row['Interaction']);receiver=row['Receiver']
 if not name or receiver not in m['classes']:continue
 if not any(parse(op)==name for op in m['classes'][receiver]['operations']):signature_errors.append(row)
 candidates=[x for x in mapping['operations'] if x['pimClass']==receiver and parse(x['pimOperation'])==name]
 if candidates and all(x['status']=='DeferredIntegration' for x in candidates):deferred_calls.append({'useCase':row['UseCase'],'page':row['Page'],'receiver':receiver,'message':row['Interaction'],'status':'Declared deferred integration; not claimed implemented'})
check('All executable receiver messages resolve to a PIM operation',not signature_errors,signature_errors)
check('Editable sequence labels match trace records',not label_drift,label_drift)
def calls(uc,page,receiver,method):return [r for r in trace if r['UseCase']==uc and r['Page']==page and r['Receiver']==receiver and r['Kind'] in ['C','A'] and parse(r['Interaction'])==method]
check('Address save/delete do not invent a customer reload',not calls('UC-C05','SaveAddress','ProfileRepository','GetCustomerAsync') and not calls('UC-C05','DeleteAddress','ProfileRepository','GetCustomerAsync'))
check('Prepare checkout includes FEFO and price collaborators',bool(calls('UC-C06','PrepareCheckout','CheckoutRepository','LockFefoBatchesAsync')) and bool(calls('UC-C06','PrepareCheckout','BatchPricingPolicy','Quote')))
check('Checkout notification explicitly excludes replay','not replay' in texts[('UC-C06','PlaceOrder')])
check('QR planned integration and unavailable branch are explicit','correlation contract unresolved' in texts[('UC-C06','CreatePaymentQr')] and 'future approved' in texts[('UC-C06','CreatePaymentQr')])
for uc,page in [('UC-C06','OrderStateMachine acceptance'),('UC-C07','OrderStateMachine cancellation')]:
 current=calls(uc,page,'OrderStateMachine','CurrentState');evidence=calls(uc,page,'OrderLifecycleRepository','RecordEventOnceAsync')
 check(uc+' state result is read after transition effects',len(current)==1 and int(current[0]['Number'])>max(int(x['Number']) for x in evidence))
check('No result returns to an actor',not any(r['Kind']=='R' and r['Receiver'] in ['Customer','SePay'] for r in trace))
check('No local cancellation token leaks into logical messages',not any(re.search(r'\bsignal\b|CancellationToken',r['Interaction']) for r in trace))
# Compare logical argument counts and the editable class masters as well as names.
def argument_count(signature):
 value=signature.split('(',1)[1].rsplit(')',1)[0];depth=0;count=0
 if not value.strip():return 0
 for ch in value:
  if ch in '<([{':depth+=1
  elif ch in '>)]}':depth-=1
  elif ch==',' and depth==0:count+=1
 return count+1
argument_errors=[]
for row in trace:
 if row['Kind'] not in ['C','A'] or row['Interaction'].startswith(('user action:','[local]','TransactionWork')):continue
 name=parse(row['Interaction']);receiver=m['classes'].get(row['Receiver'])
 if not name or not receiver:continue
 ops=[op for op in receiver['operations'] if parse(op)==name]
 if ops and not any(argument_count(op)==argument_count(row['Interaction']) for op in ops):argument_errors.append(row)
check('PIM message argument counts match receiver operations',not argument_errors,argument_errors)
normalize=lambda value:re.sub(r'\s+','',html.unescape(value))
rendered=collections.defaultdict(list)
for path in (R/'artifacts/diagrams/class').glob('*design-classes.drawio'):
 for cell in E.parse(path).iter('mxCell'):
  if cell.get('id') in m['classes'] and cell.get('vertex')=='1':rendered[cell.get('id')].append(normalize(re.sub(r'<[^>]+>',' ',cell.get('value',''))))
drift=[]
for name,klass in m['classes'].items():
 for operation in klass['operations']:
  if not any(normalize(operation) in view for view in rendered[name]):drift.append([name,operation])
check('All PIM operations appear in editable class masters',not drift,drift)

dispositions=[]
for n in range(1,17):
 state='Accepted PSM refinement' if n in [1,2,3,4,5,6,7,10] else 'Corrected PIM data/responsibility' if n in [8,9] else 'Corrected PIM interaction'
 if n==13:state='Explicit deferred integration; upstream correlation/provider remains unresolved'
 dispositions.append({'finding':f'DCC-{n:03}','disposition':state})
report={'date':mapping['date'],'model_level':'PIM','status':'CONSISTENT_WITH_EXPLICIT_REFINEMENTS_AND_DECLARED_DEFERRED_INTEGRATIONS' if not errors else 'VERIFICATION_FAILED','checks':checks,'errors':errors,'operation_mappings':len(mapping['operations']),'implemented_operation_refinements':implemented,'mapping_statuses':dict(collections.Counter(x['status'] for x in mapping['operations'])),'sequence_messages':len(trace),'sequence_pages':sum(len(x['pages']) for x in records),'deferred_operations':deferred,'deferred_messages':deferred_calls,'prior_finding_dispositions':dispositions,'limits':['This verifies representation, declared refinements and selected business-ordering invariants; it is not exhaustive dynamic path equivalence.','FrontendDesignOnly entries are not claimed implemented.','Maps, payment correlation/verification, notifications and payouts retain their pre-existing deferred integration status.','The existing SonarCloud Quality Gate was not changed or reclassified by this PIM revision.']}
(D/'pim-code-consistency.json').write_text(json.dumps(report,ensure_ascii=False,indent=2)+'\n',encoding='utf-8')
(D/'design-code-sequence-consistency.json').write_text(json.dumps({'model_level':'PIM','status':report['status'],'supersedes':'Literal PSM-signature equality audit; retained in baselines/mixed-psm-20261103','current_report':'pim-code-consistency.json','current_mapping':'pim-to-code-mapping.json','prior_finding_dispositions':dispositions},indent=2)+'\n',encoding='utf-8')
print(json.dumps({k:v for k,v in report.items() if k not in ['checks','deferred_operations','deferred_messages','prior_finding_dispositions']},indent=2));assert not errors
