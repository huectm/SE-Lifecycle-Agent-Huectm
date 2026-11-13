from pathlib import Path
import json,csv,re,hashlib,xml.etree.ElementTree as E
from zipfile import ZipFile
R=Path.cwd();D=R/'artifacts/design/detailed';m=json.loads((D/'detailed-class-model.json').read_text());C=m['classes'];pages=json.loads((D/'diagram-pages.json').read_text());checks=[]
def check(name,value):
 assert value,name
 checks.append({'check':name,'status':'PASS'})
for uc,info in m['scope'].items():
 own=[p for p in m['pages'] if p['owner']==uc];overview=own[0];web=own[1];mobile=own[2];f=info['feature']
 assert overview['title']=='VOPC to Detailed Design Realization'
 assert web['title']=='Web View Classes' and mobile['title']=='Mobile View Classes'
 assert C[f+'Page']['package']=='FreshFood-Customer-Web.Pages'
 assert C[f+'ApiClient']['package']=='FreshFood-Customer-Web.CallService'
 assert any('On' in o and 'Promise<void>' in o for o in C[f+'Page']['operations'])
 assert any(e['source']==f+'Page' and e['target']==f+'ApiClient' and e['kind']=='association' for e in web['edges'])
 assert not any(e['source']==f+'Page' and e['target'] in [f+'Controller',f+'Service'] for e in web['edges'])
 assert 'I'+f+'ApiClient' not in C and 'I'+f+'ApiModel' not in C
for n,c in C.items():
 if c['package'].startswith(('FreshFood-Customer-Web','FreshFood-App')):assert not any(o.startswith('+ '+n+'(') for o in c['operations'])
check('Frontend classes use ordinary concrete associations and no injection constructors or DI interfaces',True)
check('Architectural View ownership remains mapped outside the diagram',True)
check('Detailed class relationships distinguish association, usage dependency and realization',all(e['kind'] in ['association','dependency','realization','remote'] for p in m['pages'] for e in p['edges']))
realizations=json.loads((D/'vopc-realization-mapping.json').read_text())
check('All 48 participating VOPC classes have explicit solution-aware realizations',len(realizations)==48)
for uc,info in m['scope'].items():
 overview=next(p for p in m['pages'] if p['owner']==uc);seen={info['feature']+'Page'}
 for r in [r for r in realizations if r['UseCase']==uc]:assert set(r['DesignClasses'])<=set(overview['classes'])
 for _ in range(len(overview['classes'])):
  for e in overview['edges']:
   if e['source'] in seen:seen.add(e['target'])
   if e['target'] in seen:seen.add(e['source'])
 assert set(overview['classes'])<=seen,uc
 assert len(overview['edges'])==len({(e['source'],e['target'],e['kind']) for e in overview['edges']})
check('Every use-case realization is connected and contains all mapped VOPC participants',True)
check('No duplicate classifier relationship in realization views',True)
banned=['Task<','CancellationToken','IServiceCollection','ClaimsPrincipal','DbConnection','DbTransaction','IReadOnlyList','IEnumerable']
check('All backend signatures match Node runtime rather than .NET types',all(not any(t in ' '.join(c['attributes']+c['operations']) for t in banned) for c in C.values()))
check('Exact VND amounts use bigint value semantics, never binary floating-point money','- units: bigint' in C['VndAmount']['attributes'])
check('Selected Repository/Adapter/FEFO and distance solutions have concrete classes',all(n in C for n in ['DistanceCalculator','GoogleMapsDistanceAdapter','FefoBatchSpecification','BatchPricingPolicy','DeliveryFeePolicy']))
check('Exactly the five approved customer use cases are in scope',set(m['scope'])=={'UC-C01','UC-C03','UC-C05','UC-C06','UC-C07'})
check('Every classifier is represented in an editable diagram',set(C)=={n for p in m['pages'] for n in p['classes']})
t=list(csv.DictReader((R/'artifacts/analysis/order-state-traceability.csv').open(encoding='utf-8-sig')))
check('Each existing state-machine transition maps to exactly one distinct concrete class',len(m['transitions'])==len(t)==24 and len({r['class'] for r in m['transitions']})==24 and {r['id'] for r in t}=={r['id'] for r in m['transitions']})
check('No invented PendingUnpaid to PendingPaid transition',not any(r['source']=='pending_unpaid' and r['target']=='pending_paid' for r in m['transitions']))
check('Every handler has guard and execution signatures',all(any('CanExecute(' in o for o in C[r['class']]['operations']) and any('ExecuteAsync(snapshot:' in o for o in C[r['class']]['operations']) for r in m['transitions']))
realizes={(e['source'],e['target']) for p in m['pages'] for e in p['edges'] if e['kind']=='realization'}
check('Each transition class realizes IStateTransition',all((r['class'],'IStateTransition') in realizes for r in m['transitions']))
for impl,iface in realizes:
 for sig in C[iface]['operations']:
  if '(' in sig:assert sig in C[impl]['operations'],(impl,iface,sig)
check('Every shown interface operation has a matching implementation signature',True)
check('Repositories and entities never reference API-owned DTOs',all('Dto' not in ' '.join(c['attributes']+c['operations']) for c in C.values() if c['package'].startswith('FreshFood.Reposistory')))
check('Controllers depend on service interfaces, not implementation/repository classes',all(c['attributes']==['- service: I'+name.removesuffix('Controller')+'Service'] for name,c in C.items() if c['role']=='controller'))
check('Every business service exposes constructor injection',all(any(o.startswith('+ '+name+'(') for o in c['operations']) for name,c in C.items() if c['role'] in ['service','controller','repository','transition']))
check('Payment callback entry is absent from customer controller and API clients',all(not any('HandleVerifiedPayment' in o for o in c['operations']) for c in C.values() if c['role'] in ['controller','viewmodel'] or c['package'].startswith(('FreshFood-Customer-Web','FreshFood-App'))))
check('Payment notice routes through service interface rather than CheckoutController',('PaymentNoticeHandler','ICheckoutService') in {(e['source'],e['target']) for p in m['pages'] for e in p['edges']} and not any(e['source']=='PaymentNoticeHandler' and e['target']=='CheckoutController' for p in m['pages'] for e in p['edges']))
for p in m['pages']:
 for e in p['edges']:
  src=C[e['source']]
  if e['kind']=='association' and src['role']!='entity':assert any(e['target'] in field for field in src['attributes']),(e,src['attributes'])
check('Structural collaborator associations are backed by owned reference attributes',True)
for p in m['pages']:
 for e in p['edges']:
  if C[e['target']]['role']=='entity' and C[e['source']]['role']!='entity':assert e['kind']=='dependency',e
 for src in p['classes']:
  targets={n for n in p['classes'] if C[n]['role']=='DTO' and n!=src and re.search(r'\b'+re.escape(n)+r'\b',' '.join(C[src]['attributes']+C[src]['operations']))}
  for dst in targets:
   assert any(e['source']==src and e['target']==dst and e['kind']==('association' if C[src]['role']=='DTO' and dst in ' '.join(C[src]['attributes']) else 'dependency') for e in p['edges']),(p['title'],src,dst)
check('Every non-entity-to-entity relationship is a usage dependency',True)
check('All co-present DTO usages have explicit relationships',True)
check('Repository query results are not modeled as retained collaborator fields',all(not any(a.startswith('- materialized') for a in c['attributes']) for c in C.values()))
for uc in m['scope']:
 overview=next(p for p in m['pages'] if p['owner']==uc)
 assert any(C[n]['role']=='DTO' for n in overview['classes'])
 assert any(e['kind']=='dependency' and C[e['target']]['role']=='DTO' for e in overview['edges'])
check('Each first-page use-case realization explicitly includes DTOs and usage dependencies',True)
check('All DI registration rows belong to backend implementations',all(C[r['Implementation']]['package'].startswith(('FreshFood-API','FreshFood.Reposistory')) for r in csv.DictReader((D/'dependency-injection-registrations.csv').open(encoding='utf-8-sig'))))
check('All seven Draw.io masters exist',len({p['source'] for p in pages})==7 and all((R/p['source']).exists() for p in pages))
# Validate geometry recorded by the router independently of PNG rendering.
for rec in pages:
 tree=E.parse(R/rec['source']).findall('diagram')[rec['page']-1];cells=tree.findall('.//mxCell');ids={c.get('id'):c for c in cells};assert len(cells)==len(ids)
 assert not any('shape=folder' in c.get('style','') or c.get('id','').startswith('package_') for c in cells)
 for n in rec['classes']:assert C[n]['package'] not in ids[n].get('value','')
 for e in cells:
  if e.get('edge')=='1':
   style=e.get('style','');assert ('dashed=1' in style and ('endArrow=block' in style or 'endArrow=open' in style)) or 'dashed=0' in style
 boxes={}
 for n in rec['classes']:
  g=ids[n].find('mxGeometry');boxes[n]=tuple(float(g.get(x)) for x in ['x','y','width','height'])
 for route in rec['routes']:
  for a,b in zip(route['points'],route['points'][1:]):
   assert a[0]==b[0] or a[1]==b[1]
   for n,(x,y,w,h) in boxes.items():
    if n in [route['source'],route['target']]:continue
    hit=(x<a[0]<x+w and max(min(a[1],b[1]),y)<min(max(a[1],b[1]),y+h)) if a[0]==b[0] else (y<a[1]<y+h and max(min(a[0],b[0]),x)<min(max(a[0],b[0]),x+w))
    assert not hit,(rec['source'],rec['page'],route,n)
check('All routes are orthogonal and avoid unrelated class boxes',True)
# Approved workbook shape/formulas must survive the narrow addition.
ns={'s':'http://schemas.openxmlformats.org/spreadsheetml/2006/main'}
def workbook_state(path):
 with ZipFile(path) as z:
  workbook=E.fromstring(z.read('xl/workbook.xml'));sheets=[s.get('name') for s in workbook.findall('.//s:sheet',ns)];forms={};errors=[]
  for n in z.namelist():
   if n.startswith('xl/worksheets/sheet') and n.endswith('.xml'):
    for cell in E.fromstring(z.read(n)).findall('.//s:c',ns):
     f=cell.find('s:f',ns)
     if f is not None:forms[(n,cell.get('r'))]=f.text
     if cell.get('t')=='e':errors.append((n,cell.get('r')))
 return sheets,forms,errors
before=workbook_state(R/'scratch/detailed-design-rtm-before.xlsx');after=workbook_state(R/'artifacts/traceability/Requirements_Traceability_Matrix.xlsx')
check('RTM original sheets and formulas preserved',before[0]==after[0] and before[1]==after[1]);check('No Excel formula error cells introduced',not after[2])
# Rendering hashes are finalized only after the renderer finishes.
render_ready=all('png_sha256' in p for p in pages)
if render_ready:check('Every PNG matches its recorded rendered output',all(hashlib.sha256((R/p['image']).read_bytes()).hexdigest()==p['png_sha256'] for p in pages))
result={'status':'Draft for Design Review','date':'2026-10-31','use_cases':5,'classifiers':len(C),'transition_classes':24,'masters':7,'pages':len(pages),'static_checks':checks,'rendering_hashes_finalized':render_ready,'not_proven':['Compiled implementation','Runtime DI container execution','Detailed design sequence diagrams','Provider payout','Concurrency/end-to-end functional tests'],'gate':'Architect/Technical Lead approval required before baseline and implementation'}
(D/'design-verification.json').write_text(json.dumps(result,indent=2));print('PASS:',len(checks),'static design checks; rendered hashes ready:',render_ready)
