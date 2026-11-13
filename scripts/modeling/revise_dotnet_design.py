"""Apply the explicitly requested ASP.NET Core technology change to active artifacts."""
from pathlib import Path
import json,re,shutil,xml.etree.ElementTree as E,base64
from migrate_backend_dotnet import cs_type
R=Path(__file__).resolve().parents[2];D=R/'artifacts/design/detailed'
m=json.loads((D/'detailed-class-model.json').read_text(encoding='utf-8'))
archive=R/'artifacts/design/baselines/nodejs-20261102'
archive.mkdir(parents=True,exist_ok=True)
if m['version']!='0.5':
    shutil.copy2(D/'detailed-class-model.json',archive/'detailed-class-model.json')
    for folder in ['class','sequence','architecture']:
        for p in (R/'artifacts/diagrams'/folder).glob('*.drawio'):
            dest=archive/'diagrams'/folder/p.name;dest.parent.mkdir(parents=True,exist_ok=True);shutil.copy2(p,dest)
    for c in m['classes'].values():
        if not c['package'].startswith(('FreshFood-API','FreshFood.Reposistory')):continue
        attrs=[]
        for a in c['attributes']:
            if ': ' not in a:attrs.append(a);continue
            name,typ=a.split(': ',1)
            attrs.append(name+': '+cs_type(typ,name)+' {get; set;}')
        c['attributes']=attrs
        ops=[]
        for s in c['operations']:
            match=re.match(r'([+\-#] )?(\w+)\((.*)\)(?:: (.*))?$',s.replace(' {static}',''))
            if not match:ops.append(s);continue
            visibility,name,args,ret=match.groups();params=[]
            if '() =>' in args:
                ops.append(s.replace('RegistrationMap','IServiceCollection'));continue
            for arg in args.split(', ') if args else []:
                n,t=arg.split(': ',1);params.append(n+': '+cs_type(t,n))
            name={'processEvent':'ProcessEventAsync','currentState':'CurrentState'}.get(name,name)
            result=cs_type(ret,name) if ret else None
            if c['name'] in ['IDistanceCalculator','DistanceCalculator','IDistanceGateway','GoogleMapsDistanceAdapter'] and ret:result='Task<decimal>'
            ops.append((visibility or '+ ')+name+'('+', '.join(params)+')'+(': '+result if result else ''))
        c['operations']=ops
        c['status']='ASP.NET Core 10 / C# migration requested by stakeholder on 2026-11-02; review required'
    m['version']='0.5';m['status']='Stakeholder-authorized ASP.NET Core C# migration; implementation verification in progress'
    m['architecture_alignment']['runtime']='ASP.NET Core 10 / C#; built-in constructor DI; Npgsql 10.0.3; PostgreSQL'
    def replace(value):
        if isinstance(value,str):return value.replace('Node.js','ASP.NET Core 10 / C#').replace('processEvent','ProcessEventAsync').replace('currentState','CurrentState')
        if isinstance(value,list):return [replace(v) for v in value]
        if isinstance(value,dict):return {k:replace(v) for k,v in value.items()}
        return value
    m=replace(m)
    (D/'detailed-class-model.json').write_text(json.dumps(m,ensure_ascii=False,indent=2)+'\n',encoding='utf-8')

# Scripts that read the same model must understand Task signatures and the C# operation names.
for name in ['build_design_sequences.py','verify_design_sequences.py','write_design_sequence_index.py','write_table_state_machine_design.py','verify_table_state_machine_design.py']:
    p=R/'scripts/modeling'/name;s=p.read_text(encoding='utf-8')
    s=s.replace('processEvent','ProcessEventAsync').replace('currentState','CurrentState')
    s=s.replace("rsplit('Promise<',1)","rsplit('Task<',1)").replace("if 'Promise<' in s","if 'Task<' in s").replace("if 'Promise<' in o","if 'Task<' in o")
    s=s.replace('JavaScript represents', 'C# represents').replace('Promise/AbortSignal','Task/CancellationToken')
    s=s.replace('Version: 0.4','Version: 0.5').replace('individual transition handlers','one table-driven OrderStateMachine')
    s=s.replace('durable transition-event storage, customer audit actor mapping, ','')
    s=s.replace('Design baseline approval and integration into the Master Specification Document remain pending the Architect/Technical Lead review gate required by `.agents/skills/software-design/SKILL.md`. Existing approved analysis diagrams are preserved.','The stakeholder authorized the table-driven state-machine replacement, storage amendment and ASP.NET Core C# migration. This is a reviewable implementation revision; release and external integration acceptance remain pending. Existing approved analysis diagrams are preserved.')
    p.write_text(s,encoding='utf-8')

p=R/'.agents/skills/software-design/references/detailed-class-design.md';s=p.read_text(encoding='utf-8')
s=s.replace("FreshFood's API is Node.js; Web clients are React and Mobile is Flutter. Do not introduce .NET signatures or assume an unselected HTTP framework, DI container, language tooling, or database driver.","FreshFood's API is ASP.NET Core 10 in C#, selected explicitly by the stakeholder on 2026-11-02; Web clients are React and Mobile is Flutter. Use Task/Task<T>, CancellationToken, ASP.NET Core constructor DI and Npgsql for PostgreSQL in backend designs. Keep frontend Promise/Future contracts in their own client languages. Earlier Node.js signatures are historical and must not be regenerated into active backend artifacts.")
s=s.replace('processEvent','ProcessEventAsync').replace('currentState','CurrentState')
p.write_text(s,encoding='utf-8')

p=R/'artifacts/requirements/software-requirements-specification.md';s=p.read_text(encoding='utf-8')
s=s.replace('.NET 8 / ASP.NET Core Web API or Node.js runtime','ASP.NET Core 10 Web API implemented in C# on .NET 10')
p.write_text(s,encoding='utf-8')

p=R/'artifacts/diagrams/architecture/high-level-architecture.drawio';tree=E.parse(p)
for cell in tree.iter('mxCell'):
    value=cell.get('value','')
    if 'Node.js' in value:cell.set('value',value.replace('Node.js','ASP.NET Core 10 / C#'))
    if cell.get('id')=='api_logo':
        svg='<svg xmlns="http://www.w3.org/2000/svg" width="128" height="128"><rect width="128" height="128" fill="#512BD4"/><text x="64" y="79" text-anchor="middle" fill="white" font-family="Arial" font-size="40">.NET</text></svg>'
        style=re.sub(r'image=[^;]*','image=data:image/svg+xml,'+__import__('urllib.parse',fromlist=['quote']).quote(svg,safe=''),cell.get('style',''))
        cell.set('style',style)
tree.write(p,encoding='utf-8',xml_declaration=True)

for name in ['selected-design-solutions.json','vopc-realization-mapping.json']:
    p=D/name;s=p.read_text(encoding='utf-8').replace('Node.js','ASP.NET Core 10 / C#').replace('processEvent','ProcessEventAsync').replace('currentState','CurrentState')
    p.write_text(s,encoding='utf-8')
print('Updated active requirements, C# design contracts, generators, architecture master and design skill.')
