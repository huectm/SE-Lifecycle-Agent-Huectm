raise SystemExit('Historical Node.js generator retired after the explicit ASP.NET Core C# selection. Maintain the current C# source and detailed-class-model.json; do not regenerate the former backend.')
﻿from pathlib import Path
import json,re,csv,os
m=json.loads(Path('artifacts/design/detailed/detailed-class-model.json').read_text(encoding='utf-8-sig'))
api=Path('src/FreshFood-API');repo=Path('src/FreshFood.Reposistory')
paths={};mapping=[]
for n,c in m['classes'].items():
 pkg=c['package']
 if not pkg.startswith(('FreshFood-API','FreshFood.Reposistory')):continue
 root=api if pkg.startswith('FreshFood-API') else repo;tail=pkg[len(root.name):].strip('.').replace('.', '/')
 paths[n]=root/tail/(n+'.js')
def rel(a,b):
 s=os.path.relpath(b,a.parent).replace('\\','/');return s if s.startswith('.') else './'+s
def put(n,s):p=paths[n];p.parent.mkdir(parents=True,exist_ok=True);p.write_text(s,encoding='utf-8')
for n,p in paths.items():
 c=m['classes'][n];ops=[]
 for s in c['operations']:
  match=re.match(r'\+ (\w+)\((.*?)\)',s)
  if match and match[1]!=n:ops.append((match[1],', '.join(x.split(':')[0].strip() for x in match[2].split(',') if x.strip())))
 attrs=[re.match(r'[+\-] (\w+):',a)[1] for a in c['attributes'] if re.match(r'[+\-] (\w+):',a)]
 header='/** '+n+' — '+c['package']+'; approved design source: detailed-class-model.json. */\n'
 role=c['role'];status='Contract'
 if role=='enumeration':s=header+'export const '+n+' = Object.freeze('+json.dumps({a:a for a in c['attributes']})+');\n'
 elif role in ('DTO','record','datatype','value object'):
  s=header+'export class '+n+' {\n  constructor(values = {}) {\n'
  for a in attrs:s+=f'    this.{a} = values.{a};\n'
  s+='  }\n}\n';status='Data shape'
 elif role=='entity':
  s=header+'export class '+n+' {\n  constructor(values = {}) {\n'
  for a in attrs:s+=f'    this.{a} = values.{a};\n'
  s+='  }\n'
  for op,params in ops:s+=f'  {op}({params}) {{ throw new Error("Domain operation {n}.{op} is not configured"); }}\n'
  s+='}\n';status='Entity mapping'
 else:
  s=header+'export class '+n+' {\n'
  constructor=next((o for o in c['operations'] if o.startswith('+ '+n+'(')),None)
  if constructor:
   ps=re.search(r'\((.*?)\)',constructor)[1];ns=[x.split(':')[0].strip() for x in ps.split(',') if x.strip()];s+='  constructor('+', '.join(ns)+') {\n'+''.join('    this.'+x+' = '+x+';\n' for x in ns)+'  }\n'
  for op,params in ops:
   s+=f'  {"async " if op.endswith("Async") else ""}{op}({params}) {{ throw Object.assign(new Error("{n}.{op}: implementation or external port required"), {{ code: "DESIGN_PORT_UNCONFIGURED", status: 503 }}); }}\n'
  s+='}\n'
 put(n,s)
 mapping.append({'DesignClass':n,'Package':c['package'],'Role':role,'SourceFile':p.as_posix(),'InitialMapping':status,'Scope':str(c.get('scope','shared'))})
# Controllers retain their injected service reference and delegate only modeled operations.
for uc,scope in m['scope'].items():
 n=scope['controller'];ops=m['classes'][n]['operations'];s=f'/** {uc}: injected service contract; transport/authentication belongs to HTTP composition. */\nexport class {n} {{\n  constructor(service) {{ this.service = service; }}\n'
 for op in ops:
  match=re.match(r'\+ (\w+)\((.*?)\)',op)
  if not match or match[1]==n:continue
  name=match[1];params=', '.join(x.split(':')[0].strip() for x in match[2].split(',') if x.strip())
  s+=f'  async {name}({params}) {{ return this.service.{name}({params}); }}\n'
 s+='}\n';put(n,s)
# DTO metadata keeps all approved field names/types visible and supports contract verification.
(api/'DTOs'/'contracts.json').write_text(json.dumps({n:{'attributes':m['classes'][n]['attributes']} for n in paths if m['classes'][n]['role']=='DTO'},indent=2),encoding='utf-8')
Path('artifacts/implementation').mkdir(exist_ok=True)
with Path('artifacts/implementation/backend-class-source-mapping.csv').open('w',encoding='utf-8',newline='') as f:
 w=csv.DictWriter(f,fieldnames=list(mapping[0]));w.writeheader();w.writerows(mapping)
(api/'package.json').write_text(json.dumps({'name':'@freshfood/api','version':'0.1.0','private':True,'type':'module','description':'Five customer use-case backend mapped from approved design','engines':{'node':'>=22'},'scripts':{'start':'node server.js','test':'node --test tests/*.test.js','check':'node scripts/check-source.js'},'dependencies':{'@freshfood/data-access':'file:../FreshFood.Reposistory'}},indent=2)+'\n')
(repo/'package.json').write_text(json.dumps({'name':'@freshfood/data-access','version':'0.1.0','private':True,'type':'module','description':'FreshFood.Reposistory domain entities and repository contracts','engines':{'node':'>=22'}},indent=2)+'\n')
Path('scratch/backend-mapping-paths.json').write_text(json.dumps({n:p.as_posix() for n,p in paths.items()},indent=2))
print('Mapped backend classifiers:',len(paths),'Frontend excluded:',len(m['classes'])-len(paths))
