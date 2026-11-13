from pathlib import Path
import json,xml.etree.ElementTree as E,html,re,csv,hashlib
m=json.loads(Path('artifacts/design/detailed/detailed-class-model.json').read_text(encoding='utf-8-sig'))
# Read-only static contract verification, not runtime testing.
rows=list(csv.DictReader(Path('artifacts/design/design-sequence-message-traceability.csv').open(encoding='utf-8-sig')))
errors=[]; checked=0
for r in rows:
 if r['Kind'] not in ('C','A'):continue
 n=r['Receiver']; msg=r['Interaction']; c=m['classes'].get(n)
 if not c or r['Sender']==n or msg.startswith(('TransactionWork','user action:')):continue
 method=re.search(r'(\w+)\(',msg)
 if method:
  checked+=1
  if not any(re.search(r'\b'+method[1]+r'\(',op) for op in c['operations']):errors.append([n,msg])
print('Checked named receiver methods',checked,'errors',errors)

records=json.loads(Path('artifacts/design/design-sequence-verification.json').read_text(encoding='utf-8'))
checks=[]
def check(name,ok):checks.append({'check':name,'passed':bool(ok)})
check('Exactly five use-case masters',len(records)==5)
check('Named receiver methods exist in detailed class model',not errors)
check('No result message returns to a customer or external actor',not any(r['Kind']=='R' and r['Receiver'] in ('Customer','SePay') for r in rows))
check('SePay callback calls CheckoutService, never CheckoutController',any(r['Sender']=='PaymentNoticeHandler' and r['Receiver']=='CheckoutService' for r in rows) and not any(r['Sender']=='PaymentNoticeHandler' and r['Receiver']=='CheckoutController' for r in rows))
for uc,scope in m['scope'].items():
 expected={re.search(r'\+ (\w+)\(',s)[1] for s in m['classes'][scope['service']]['operations'] if re.search(r'\+ (\w+Async)\(',s)}
 actual={re.search(r'(\w+)\(',r['Interaction'])[1] for r in rows if r['UseCase']==uc and r['Receiver']==scope['service'] and r['Kind'] in ('C','A') and re.search(r'(\w+)\(',r['Interaction'])}
 check(uc+' all service operations represented',expected<=actual)
 check(uc+' Web and Mobile entry chains represented',all(any(r['UseCase']==uc and r['Receiver']==scope['feature']+suffix for r in rows) for suffix in ('Page','ApiClient','ViewModel','ApiModel')))
collisions=[]; route_collisions=[]; executions=0;pages=0
for record in records:
 check(record['use_case']+' master matches recorded hash',hashlib.sha256(Path(record['master']).read_bytes()).hexdigest()==record['master_sha256'])
 tree=E.parse(record['master'])
 for pg,dia in zip(record['pages'],tree.findall('diagram')):
  pages+=1
  check(record['use_case']+' page '+str(pg['page'])+' PNG matches master export record',Path(pg['png']).exists() and hashlib.sha256(Path(pg['png']).read_bytes()).hexdigest()==pg['png_sha256'])
  for ex in pg['executions']:
   executions+=1
   check('Continuous activation '+record['use_case']+'/'+str(pg['page'])+'/'+str(ex['message']),len(ex['spans'])==1 and ex['end']>ex['start'])
  rects={}
  for c in dia.findall('.//mxCell'):
   g=c.find('mxGeometry')
   if c.get('vertex')=='1' and g is not None:rects[c.get('id')]=tuple(float(g.get(k,0)) for k in ('x','y','width','height'))
  for c in dia.findall('.//mxCell'):
   if not c.get('id','').startswith('message_'):continue
   g=c.find('mxGeometry');a=g.find("mxPoint[@as='sourcePoint']");b=g.find("mxPoint[@as='targetPoint']")
   sx,sy,tx,ty=map(float,[a.get('x'),a.get('y'),b.get('x'),b.get('y')])
   if sy!=ty:continue
   for aid,(x,y,w,h) in rects.items():
    if aid.startswith('execution_') and min(sx,tx)+8<x and x+w<max(sx,tx)-8 and y+1<sy<y+h-1:route_collisions.append([record['use_case'],pg['page'],c.get('id'),aid])
  for a,ra in rects.items():
   if not a.startswith(('label_','guard_')):continue
   for b,rb in rects.items():
    if not b.startswith(('head_','execution_')):continue
    if min(ra[0]+ra[2],rb[0]+rb[2])-max(ra[0],rb[0])>1 and min(ra[1]+ra[3],rb[1]+rb[3])-max(ra[1],rb[1])>1:collisions.append([record['use_case'],pg['page'],a,b])
check('Message segments do not cross unrelated activations',not route_collisions)
check('Label rectangles do not overlap participant headers or activations',not collisions)
report={'status':'Draft for Design Review','scope':'Static model verification; not implementation or dynamic testing','pages':pages,'messages':len(rows),'checked_receiver_method_calls':checked,'execution_occurrences':executions,'checks':checks,'failures':[x for x in checks if not x['passed']],'method_errors':errors,'label_collisions':collisions,'route_collisions':route_collisions}
Path('artifacts/design/design-sequence-static-review.json').write_text(json.dumps(report,indent=2),encoding='utf-8')
print(json.dumps({k:v for k,v in report.items() if k!='checks'},indent=2))
assert not report['failures']
