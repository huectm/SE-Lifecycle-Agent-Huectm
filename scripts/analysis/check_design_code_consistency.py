import json as _pimjson, runpy as _pimrunpy
from pathlib import Path as _PimPath
if _pimjson.loads(_PimPath('artifacts/design/detailed/detailed-class-model.json').read_text(encoding='utf-8-sig')).get('model_level') == 'PIM':
 _pimrunpy.run_path('scripts/analysis/verify_pim_realization.py', run_name='__main__')
 raise SystemExit(0)
"""Read-only three-way audit: editable Draw.io, typed design model, Roslyn source calls.

This checker reports drift. It never rewrites an approved design to match code.
"""
from pathlib import Path
import json,re,csv,html,collections,hashlib
import xml.etree.ElementTree as E
R=Path(__file__).resolve().parents[2];D=R/'artifacts/design/detailed'
def read(p):return json.loads((R/p).read_text(encoding='utf-8-sig'))
model=read('artifacts/design/detailed/detailed-class-model.json')
source=read('artifacts/design/detailed/source-consistency-symbols.json')
classes={c['name']:c for c in source['classes']}
backend={n:c for n,c in model['classes'].items() if c['package'].startswith(('FreshFood-API','FreshFood.Reposistory'))}
aliases={'EntityId','LocalDate','VndAmountString','IsoDateTime','AuthenticatedPrincipal','DatabaseConnection','DatabaseTransaction','RegistrationMap','HttpTransport','TransactionWork'}
def norm(s):return re.sub(r'\s+','',s).replace('System.String','string').replace('System.Int32','int').replace('System.Boolean','bool').replace('System.Decimal','decimal')
def split(text):
 result=[];start=0;depth=0
 for i,ch in enumerate(text):
  if ch in '<([{':depth+=1
  elif ch in '>)]}':depth-=1
  elif ch==',' and depth==0:result.append(text[start:i].strip());start=i+1
 if text[start:].strip():result.append(text[start:].strip())
 return result
def operation(text):
 s=re.sub(r'\s+\{[^}]*\}$','',text.strip())
 match=re.match(r'([+\-#~])\s+(\w+)(<[^()]*>)?\((.*)\)(?::\s*(.*))?$',s)
 if not match:return None
 visibility,name,generic,args,ret=match.groups();parameters=[]
 for arg in split(args):
  if ': ' not in arg:return None
  n,t=arg.split(': ',1);parameters.append({'name':n,'type':t})
 return {'text':text,'name':name,'arity':len(split(generic[1:-1])) if generic else 0,'parameters':parameters,'returnType':ret or '', 'visibility':visibility}
contracts=[];name_drift=[];missing=[];extra=[];property_drift=[];method_matrix=[]
for name,design in backend.items():
 if name in aliases:continue
 actual=classes.get(name)
 if not actual:missing.append({'class':name,'reason':'No matching source type'});continue
 ops=[operation(s) for s in design['operations']];ops=[o for o in ops if o]
 for op in ops:
  candidates=[m for m in actual['methods'] if m['name']==op['name'] and m['arity']==op['arity']]
  matches=[m for m in candidates if [norm(p['type']) for p in m['parameters']]==[norm(p['type']) for p in op['parameters']] and norm(m['returnType'])==norm(op['returnType'])]
  if not matches:contracts.append({'class':name,'design':op,'sourceCandidates':candidates,'source':actual['file'],'line':actual['line']})
  else:
   matched=matches[0]
   if [p['name'] for p in op['parameters']]!=[p['name'] for p in matched['parameters']]:name_drift.append({'class':name,'method':op['name'],'designParameters':op['parameters'],'sourceParameters':matched['parameters'],'source':matched['file'],'line':matched['line']})
  selected=matches if matches else candidates
  method_matrix.append({'Class':name,'Design operation':op['text'],'Result':'MATCH' if matches else 'MISMATCH','Source candidates':'; '.join(x['name']+('<T>' if x['arity'] else '')+'('+', '.join(p['name']+': '+p['type'] for p in x['parameters'])+'): '+x['returnType'] for x in selected),'Source file':selected[0]['file'] if selected else actual['file'],'Source line':selected[0]['line'] if selected else actual['line']})
 for method in actual['methods']:
  if method['accessibility']=='Public' and not method['isConstructor'] and not any(o['name']==method['name'] and o['arity']==method['arity'] for o in ops):extra.append({'class':name,'method':method})
 if design['role'] in ['DTO','entity','record']:
  props={p['name']:p for p in actual['properties']};differences=[];listed=[]
  for attr in design['attributes']:
   match=re.match(r'([+\-#~])\s+(\w+):\s*([^{}]+)',attr)
   if not match:continue
   vis,n,t=match.groups();listed.append(n);p=props.get(n)
   if not p:differences.append({'property':n,'kind':'design-only property','design':attr})
   elif norm(t)!=norm(p['type']) or (vis=='+' and p['accessibility']!='Public') or ('set;' in attr and p['setter'] is None):differences.append({'property':n,'kind':'property type/access/setter differs','design':attr,'source':p})
  differences.extend({'property':p['name'],'kind':'source-only property','source':p} for p in actual['properties'] if p['name'] not in listed)
  if differences:property_drift.append({'class':name,'source':actual['file'],'differences':differences})

# Inspect the real editable class boxes, including all focused pages (not only compact excerpts).
rendered=collections.defaultdict(list);master_hashes={}
for path in sorted((R/'artifacts/diagrams/class').glob('*design-classes.drawio')):
 master_hashes[path.relative_to(R).as_posix()]=hashlib.sha256(path.read_bytes()).hexdigest()
 for page,dia in enumerate(E.parse(path).findall('diagram'),1):
  for cell in dia.iter('mxCell'):
   if cell.get('id') in model['classes'] and cell.get('vertex')=='1':
    text=html.unescape(re.sub(r'<[^>]+>',' ',cell.get('value','')))
    rendered[cell.get('id')].append({'master':path.relative_to(R).as_posix(),'page':page,'text':norm(text)})
render_drift=[]
for name,c in backend.items():
 for op in c['operations']:
  if not any(norm(op) in view['text'] for view in rendered.get(name,[])):render_drift.append({'class':name,'operation':op,'kind':'model operation not found in any editable class view'})

# Compare the published sequence trace to the actual visible message labels in its master.
records=read('artifacts/design/design-sequence-verification.json')
trace=list(csv.DictReader((R/'artifacts/design/design-sequence-message-traceability.csv').open(encoding='utf-8-sig')))
sequence_trace_drift=[];page_lookup={}
for record in records:
 path=R/record['master'];master_hashes[path.relative_to(R).as_posix()]=hashlib.sha256(path.read_bytes()).hexdigest()
 for info,dia in zip(record['pages'],E.parse(path).findall('diagram')):
  key=(record['use_case'],info['name']);page_lookup[key]={'master':path.relative_to(R).as_posix(),'page':info['page']}
  labels={c.get('id'):html.unescape(re.sub(r'<[^>]+>',' ',c.get('value',''))) for c in dia.iter('mxCell') if c.get('id','').startswith('label_')}
  for row in [r for r in trace if (r['UseCase'],r['Page'])==key]:
   expected=str(row['Number'])+': '+row['Interaction']
   if norm(labels.get('label_'+row['Number'],''))!=norm(expected):sequence_trace_drift.append({'useCase':key[0],'page':key[1],'message':row['Number'],'trace':expected,'masterLabel':labels.get('label_'+row['Number'])})

def message_call(text):
 m=re.search(r'(\w+)\(',text)
 if not m:return None
 depth=1;start=m.end();end=start
 while end<len(text) and depth:
  if text[end]=='(':depth+=1
  if text[end]==')':depth-=1
  end+=1
 return {'method':m[1],'arguments':split(text[start:end-1])}
bindings={row['Contract']:row['Implementation'] for row in csv.DictReader((D/'dependency-injection-registrations.csv').open(encoding='utf-8-sig'))}
calls=source['calls'];by_caller=collections.defaultdict(list)
for call in calls:by_caller[(call['callerType'],call['callerMethod'])].append(call)
def reachable(cls,method,visited=None):
 visited=set() if visited is None else visited
 if (cls,method) in visited:return []
 visited.add((cls,method));found=list(by_caller[(cls,method)])
 for call in list(found):
  if call['receiverType']==cls:found.extend(reachable(cls,call['method'],visited))
 return found
sequence_calls=[];message_contract_drift=[];unrealized=[];contexts={};direct_count=0
for row in trace:
 if row['Kind'] not in ['C','A']:continue
 sender,receiver,text=row['Sender'],row['Receiver'],row['Interaction'];parsed=message_call(text)
 if not parsed or text.startswith(('[local]','TransactionWork','user action:')):continue
 if receiver not in backend:continue
 actual=classes.get(receiver)
 if not actual:continue
 method=parsed['method'];args=parsed['arguments'];is_http=text.startswith('HTTPS ')
 methods=[m for m in actual['methods'] if m['name']==method]
 candidates=[m for m in methods if (len(args)==len([p for p in m['parameters'] if p['type']!='CancellationToken']) if is_http else len(args)==len(m['parameters']))]
 location=page_lookup.get((row['UseCase'],row['Page']),{})
 entry={'useCase':row['UseCase'],'pageTitle':row['Page'],'number':int(row['Number']),'sender':sender,'receiver':receiver,'message':text,'method':method,'arguments':args,'httpBoundary':is_http,**location}
 if not methods or not candidates:message_contract_drift.append({**entry,'sourceCandidates':methods,'reason':'receiver has no matching method/argument count'})
 if sender!=receiver:contexts[(row['UseCase'],row['Page'],receiver)]=method
 if sender not in backend or sender==receiver:
  sequence_calls.append({**entry,'sourceCallCheck':'HTTP boundary/design-only frontend' if sender not in backend else 'self message; method existence checked'});continue
 if sender=='UnitOfWork' and method=='InvokeAsync':continue
 root=contexts.get((row['UseCase'],row['Page'],sender))
 outgoing=reachable(sender,root) if root else [c for c in calls if c['callerType']==sender]
 compatible=lambda c:c['method']==method and (c['receiverType']==receiver or bindings.get(c['receiverType'])==receiver or c['receiverType'] in actual.get('interfaces',[]))
 matching=[c for c in outgoing if compatible(c)]
 if matching:direct_count+=1
 else:unrealized.append({**entry,'callerMethodContext':root,'reason':'no bound source call found in the corresponding method or same-class helpers'})
 sequence_calls.append({**entry,'sourceCallCheck':'bound source call found' if matching else 'manual review required','callerMethodContext':root,'sourceCalls':[{'file':c['file'],'line':c['line'],'expression':c['text']} for c in matching]})

report={'date':'2026-11-03','scope':'Five customer use cases; backend C# source. Frontend messages are checked against design only because frontend implementations remain scaffolds.','status':'INCONSISTENCIES_FOUND' if contracts or message_contract_drift or property_drift or unrealized else 'NO_REPORTED_DRIFT','method':'Roslyn-bound current source plus direct Draw.io XML inspection; name, arity, parameter/return types, property shape and source call reachability. Not dynamic flow proof.','summary':{'backendClassifiers':len(backend),'sourceTypes':len(classes),'compiledSourceErrors':len(source['compileErrors']),'workspaceDiagnostics':len(source['loadDiagnostics']),'sourceInvocations':len(calls),'classSignatureMismatches':len(contracts),'parameterNameDifferences':len(name_drift),'missingSourceTypes':len(missing),'additionalPublicSourceMethods':len(extra),'classesWithPropertyDifferences':len(property_drift),'classModelToDrawioOperationDifferences':len(render_drift),'sequenceTraceToDrawioDifferences':len(sequence_trace_drift),'backendSequenceCallsChecked':len(sequence_calls),'backendMessageSignatureMismatches':len(message_contract_drift),'boundInterObjectCallsMatched':direct_count,'interObjectCallPairsRequiringReview':len(unrealized)},'class_signature_mismatches':contracts,'parameter_name_differences':name_drift,'missing_source_types':missing,'additional_public_source_methods':extra,'property_differences':property_drift,'class_drawio_differences':render_drift,'sequence_trace_differences':sequence_trace_drift,'message_signature_mismatches':message_contract_drift,'source_call_pairs_requiring_review':unrealized,'checked_sequence_calls':sequence_calls,'master_sha256':master_hashes}
(D/'design-code-sequence-consistency.json').write_text(json.dumps(report,ensure_ascii=False,indent=2)+'\n',encoding='utf-8')
with (D/'design-code-method-matrix.csv').open('w',newline='',encoding='utf-8') as f:
 w=csv.DictWriter(f,fieldnames=list(method_matrix[0]));w.writeheader();w.writerows(method_matrix)
with (D/'design-code-sequence-call-matrix.csv').open('w',newline='',encoding='utf-8') as f:
 fields=['useCase','page','pageTitle','number','sender','receiver','message','sourceCallCheck','callerMethodContext','master']
 w=csv.DictWriter(f,fieldnames=fields,extrasaction='ignore');w.writeheader();w.writerows(sequence_calls)
print(json.dumps(report['summary'],indent=2))
for item in contracts:print('CLASS_SIGNATURE',item['class'],item['design']['text'])
for item in unrealized:print('CALL_REVIEW',item['useCase'],item['page'],item['sender'],'->',item['receiver'],item['message'])
