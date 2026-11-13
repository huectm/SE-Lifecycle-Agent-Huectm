"""Preserve the Node baseline and generate strongly typed C# design contracts.

Runtime implementations are maintained separately; this script never overwrites them.
"""
import json, re, shutil
from pathlib import Path

ROOT = Path(__file__).resolve().parents[2]
BASE = ROOT / 'artifacts/implementation/baselines/nodejs-20261102'
MODEL = ROOT / 'artifacts/design/detailed/detailed-class-model.json'
m = json.loads(MODEL.read_text(encoding='utf-8'))

def write(path, text):
    p = ROOT / path
    p.parent.mkdir(parents=True, exist_ok=True)
    p.write_text(text, encoding='utf-8')

def archive():
    for name in ['FreshFood-API', 'FreshFood.Reposistory']:
        source = (ROOT / 'src' / name).resolve()
        target = (BASE / 'src' / name).resolve()
        assert source.is_relative_to(ROOT) and target.is_relative_to(ROOT)
        if not target.exists():
            target.parent.mkdir(parents=True, exist_ok=True)
            shutil.move(str(source), str(target))

def cs_type(t, name=''):
    t=re.sub(r'\s*\{.*$', '', t).strip()
    if t.startswith('Promise<'): return 'Task' if t=='Promise<void>' else 'Task<'+cs_type(t[8:-1],name)+'>'
    if t.startswith('ReadonlyArray<'): return 'List<'+cs_type(t[14:-1],name)+'>'
    if t.endswith('?'): return cs_type(t[:-1],name)+'?'
    if t=='number':
        return 'decimal' if any(s.lower() in name.lower() for s in ['price','amount','rate','latitude','longitude','distance','fee','total']) else 'int'
    return {'EntityId':'string','VndAmountString':'string','IsoDateTime':'DateTimeOffset','LocalDate':'DateOnly',
            'Date':'DateTimeOffset','boolean':'bool','bigint':'decimal','AbortSignal':'CancellationToken',
            'unknown':'object','AuthenticatedPrincipal':'ClaimsPrincipal','TransactionWork':'Func<CancellationToken, Task>',
            'DatabaseConnection':'NpgsqlDataSource','DatabaseTransaction':'NpgsqlTransaction','RegistrationMap':'IServiceCollection',
            'HttpTransport':'HttpClient'}.get(t,t)

def op(s, cls):
    s=s.removeprefix('+ ').replace(' {static}','')
    match=re.match(r'(\w+)\((.*)\)(?:: (.*))?$',s)
    if not match:return None
    name,args,ret=match.groups()
    if name==cls:return None
    params=[]
    for arg in args.split(', ') if args else []:
        n,t=arg.split(': ',1)
        if n=='event':n='message'
        params.append(cs_type(t,n)+' '+n)
    name={'processEvent':'ProcessEventAsync','currentState':'CurrentState'}.get(name,name)
    return f'{cs_type(ret or "void")} {name}({", ".join(params)})'

if __name__=='__main__':
    if (ROOT/'src/FreshFood-API/Services/Implements/CheckoutService.cs').exists():
        raise SystemExit('C# implementations exist. This one-time migration generator is retired; edit the current C# source and model directly.')
    archive()
    write('global.json',json.dumps({'sdk':{'version':'10.0.401','rollForward':'latestPatch'}},indent=2)+'\n')
    for project,sdk in [('FreshFood-API','Microsoft.NET.Sdk.Web'),('FreshFood.Reposistory','Microsoft.NET.Sdk')]:
        deps='<ProjectReference Include="../FreshFood.Reposistory/FreshFood.Reposistory.csproj" />' if project=='FreshFood-API' else '<PackageReference Include="Npgsql" Version="10.0.3" />'
        write(f'src/{project}/{project}.csproj',f'<Project Sdk="{sdk}">\n  <PropertyGroup><TargetFramework>net10.0</TargetFramework><ImplicitUsings>enable</ImplicitUsings><Nullable>enable</Nullable><TreatWarningsAsErrors>true</TreatWarningsAsErrors><RootNamespace>{"FreshFood.Api" if project=="FreshFood-API" else project}</RootNamespace></PropertyGroup>\n  <ItemGroup>{deps}</ItemGroup>\n</Project>\n')
    common='''global using FreshFood.Reposistory.Entities;
global using FreshFood.Reposistory.Repository;
global using FreshFood.Reposistory.Repository.Implements;
global using System.Globalization;
global using System.Text.Json;
global using System.Text.Json.Serialization;
'''
    write('src/FreshFood.Reposistory/GlobalUsings.cs',common+'global using Npgsql;\n')
    write('src/FreshFood-API/GlobalUsings.cs',common+'''global using FreshFood.Api.DTOs;
global using FreshFood.Api.Services;
global using FreshFood.Api.Services.Implements;
global using System.Security.Claims;
''')
    for c in m['classes'].values():
        pkg=c['package']
        if not pkg.startswith(('FreshFood-API','FreshFood.Reposistory')):continue
        name,role=c['name'],c['role']
        project='FreshFood-API' if pkg.startswith('FreshFood-API') else 'FreshFood.Reposistory'
        sub=pkg.split('.')[1:] if project=='FreshFood-API' else pkg.split('.')[2:]
        ns=pkg.replace('FreshFood-API','FreshFood.Api')
        dest=f'src/{project}/'+('/'.join(sub)+'/' if sub else '')+name+'.cs'
        if role=='interface':
            if name in ['IUnitOfWork','IRepositorySession']:continue
            body='\n'.join('    '+op(s,name)+';' for s in c['operations'] if op(s,name))
            write(dest,f'namespace {ns};\n\npublic interface {name}\n{{\n{body}\n}}\n')
        elif role in ['DTO','entity','record'] and name not in ['AuthenticatedPrincipal','TransitionSnapshot']:
            props=[]
            for a in c['attributes']:
                a=a.lstrip('+-# ')
                if ': ' not in a:continue
                n,t=a.split(': ',1)
                typ=cs_type(t,n)
                default=' = [];' if typ.startswith('List<') else ' = string.Empty;' if typ=='string' else ''
                if typ not in ['string','int','bool','decimal','DateOnly','DateTimeOffset','OrderStatus','PaymentStatus','PaymentMethod'] and not typ.endswith('?') and not default:default=' = default!;'
                props.append(f'    public {typ} {n} {{ get; set; }}{default}')
            partial='partial ' if role=='entity' else ''
            write(dest,f'namespace {ns};\n\npublic {partial}class {name}\n{{\n'+ '\n'.join(props)+'\n}\n')
        elif role=='enumeration':
            values=[re.split(r'[: =]',a.lstrip('+-# '))[0] for a in c['attributes']]
            write(dest,f'namespace {ns};\n\npublic enum {name} {{ '+', '.join(values)+' }\n')
    # Physical layer must not depend on API DTOs.
    write('src/FreshFood.Reposistory/Repository/Implements/Errors.cs','''namespace FreshFood.Reposistory.Repository.Implements;
public sealed class DomainException(string code, int status = 400) : Exception(code)
{
    public string Code { get; } = code;
    public int Status { get; } = status;
}
''')
    print('Node baseline preserved; C# contracts generated. Implementations require build verification.')
