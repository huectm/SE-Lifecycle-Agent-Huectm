from pathlib import Path
import json,csv,re,xml.etree.ElementTree as E,urllib.parse
R=Path(__file__).resolve().parents[2];D=R/'artifacts/design/detailed'
m=json.loads((D/'detailed-class-model.json').read_text(encoding='utf-8'))
compiled=json.loads((R/'artifacts/implementation/dotnet-compiled-design-mapping.json').read_text(encoding='utf-8'))
sources={}
for project in ['FreshFood-API','FreshFood.Reposistory']:
 for p in (R/'src'/project).rglob('*.cs'):
  if any(part in ['obj','bin'] for part in p.parts):continue
  for name in re.findall(r'public\s+(?:(?:sealed|static|readonly|partial|abstract)\s+)*(?:class|interface|enum|record(?:\s+struct)?)\s+(\w+)',p.read_text(encoding='utf-8')):sources[name]=p.relative_to(R).as_posix()
rows=[]
for entry in compiled:
 name=entry['Name'];c=m['classes'][name]
 rows.append({'Design Classifier':name,'C# Symbol':entry['Symbol'],'Source':sources.get(name,'Framework / type alias'),'Mapping':entry['Kind'],'Basis':c.get('basis','Current design')})
 if name in ['CurrentCustomer','CheckoutService','MyOrdersService','PostgreSqlSession','ApiCompositionRoot','PaymentNoticeHandler','GoogleMapsGeocodingAdapter','GoogleMapsDistanceAdapter','SePayPaymentAdapter','ConfiguredNotificationPublisher']:
  ops=[s for s in entry['Operations'] if not s.startswith('+ '+name+'()')]
  if name.endswith('Adapter') or name=='ConfiguredNotificationPublisher':
   # Unconfigured providers retain their contracts without claiming an active HTTP transport.
   ops=[s for s in ops if not s.startswith('+ '+name+'(')]
   c['attributes']=[]
  else:
   ctor=next((s for s in ops if s.startswith('+ '+name+'(')),None)
   if ctor:
    args=ctor.split('(',1)[1].rsplit(')',1)[0]
    c['attributes']=['- '+a for a in args.split(', ')]
  c['operations']=ops
 if name=='IUnitOfWork':c['operations'].append('+ ExecuteAsync<T>(work: Func<CancellationToken, Task<T>>, signal: CancellationToken): Task<T>') if not any('ExecuteAsync<T>' in x for x in c['operations']) else None
 if name in ['IRepositorySession','PostgreSqlSession'] and not any('QueryAsync' in x for x in c['operations']):c['operations'].append('+ QueryAsync<T>(sql: string, parameters: object?[], signal: CancellationToken): Task<List<T>>')
for name in ['IDistanceCalculator','DistanceCalculator','IDistanceGateway','GoogleMapsDistanceAdapter']:
 m['classes'][name]['operations']=[x.replace('Task<int>','Task<decimal>') for x in m['classes'][name]['operations']]
(D/'detailed-class-model.json').write_text(json.dumps(m,ensure_ascii=False,indent=2)+'\n',encoding='utf-8')
with (R/'artifacts/implementation/dotnet-source-mapping.csv').open('w',newline='',encoding='utf-8') as f:
 w=csv.DictWriter(f,fieldnames=rows[0].keys());w.writeheader();w.writerows(rows)

p=R/'artifacts/diagrams/architecture/high-level-architecture.drawio';t=E.parse(p)
for c in t.iter('mxCell'):
 if c.get('id')=='api_icon':
  svg='<svg xmlns="http://www.w3.org/2000/svg" width="128" height="128"><rect width="128" height="128" fill="#512BD4"/><text x="64" y="79" text-anchor="middle" fill="white" font-family="Arial" font-size="40">.NET</text></svg>'
  c.set('style',re.sub(r'image=[^;]*','image=data:image/svg+xml,'+urllib.parse.quote(svg,safe=''),c.get('style','')))
t.write(p,encoding='utf-8',xml_declaration=True)
print('Mapped',len(rows),'backend classifiers to compiled C# or framework symbols.')
