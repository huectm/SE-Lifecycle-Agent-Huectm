from pathlib import Path
import re,json,csv,shutil
R=Path(__file__).resolve().parents[2]
def write(path,text):
 p=R/path;p.parent.mkdir(parents=True,exist_ok=True);p.write_text(text,encoding='utf-8')
write('src/README.md','''# FreshFood Project Structure

Stakeholder decision 2026-11-02: ASP.NET Core C# backend. Approved use-case IDs and business behavior remain the basis.

| Project | Type | Responsibility |
|---|---|---|
| FreshFood-API | ASP.NET Core 10 C# Web API | Controllers, service contracts/implementations, DTOs, DI composition |
| FreshFood.Reposistory | .NET 10 C# class library | Entities, repository contracts/implementations, Npgsql transactions |
| FreshFood-API.Tests | .NET 10 xUnit | Unit, HTTP and disposable PostgreSQL integration tests |
| FreshFood-Customer-Web | React | Customer Pages / CallService |
| FreshFood-Web | React | Staff Pages / CallService |
| FreshFood-App | Flutter | Views / ViewModels / Models |
| FreshFood-DB | PostgreSQL SQL assets | Migrations and seeds |

Solution: `FreshFood.sln`. Build/run instructions and configuration limits: [API README](FreshFood-API/README.md). Former Node backend sources are historical evidence under `artifacts/implementation/baselines/nodejs-20261102/src/` and are outside the active solution.
''')
for path in ['artifacts/design/system-architecture-design.md','artifacts/design/detailed/architecture-to-design-realization.csv']:
 p=R/path;s=p.read_text(encoding='utf-8').replace('Node.js','ASP.NET Core 10 / C#').replace('bigint-backed','decimal-backed')
 p.write_text(s,encoding='utf-8')
p=R/'artifacts/requirements/non-functional-requirements.md';s=p.read_text(encoding='utf-8')
s=s.replace('Web Server / Backend (.NET / Node.js)','Web Server / Backend (ASP.NET Core 10 / C#)')
s=s.replace('Xử lý nhẹ nhàng 100 kết nối đồng thời với cấu hình máy chủ cơ bản.','Capacity estimate only; verify 100 concurrent users on the configured target environment.')
p.write_text(s,encoding='utf-8')
for path in ['artifacts/implementation/project-scaffold.md','artifacts/implementation/backend-implementation-review.md','artifacts/design/detailed/architecture-realization-review.md']:
 p=R/path;archive=R/'artifacts/implementation/baselines/nodejs-20261102/reviews'/p.name
 if p.exists() and not archive.exists():archive.parent.mkdir(parents=True,exist_ok=True);shutil.copy2(p,archive)
 if 'architecture' in path:
  body='''# Architecture to C# Design Realization Review

Revision 2026-11-02: FreshFood-API is an ASP.NET Core 10 Web API; FreshFood.Reposistory is its .NET 10 class-library dependency. The component/package names and frontend packages remain unchanged. Controllers map to ASP.NET endpoints, application logic to injected service interfaces, repositories to parameterized Npgsql implementations, DTOs to C# boundary contracts, and VOPC entities to repository-owned C# entity types.

Backend DI references remain associations to interfaces; realizations point to interfaces; DTO/entity usage remains dependency. Web and Mobile views retain their client-language contracts. Detailed class diagrams have no package containers. One OrderStateMachine encapsulates 24 table rows; per-transition classes are historical only.

The 48 VOPC participations remain in analysis-to-design-mapping.csv. Actual C# source paths are recorded in artifacts/implementation/dotnet-source-mapping.csv. Technical verification and unresolved external contracts are recorded in artifacts/implementation/dotnet-migration-review.md.
'''
 else:body='''# Current Backend Project Realization

The active backend is ASP.NET Core 10 C#, selected by the stakeholder on 2026-11-02. See [current migration review](dotnet-migration-review.md) and `src/README.md` for project types, source paths, tests and integration limits. Earlier scaffold/Node review content is retained under `baselines/nodejs-20261102/reviews/` and does not describe current source.
'''
 p.write_text(body,encoding='utf-8')

p=R/'artifacts/design/detailed/dependency-injection-registrations.csv'
rows=list(csv.DictReader(p.open(encoding='utf-8-sig')))
for row in rows:
 row['Lifetime']='Singleton' if row['Contract'] in ['IBatchPricingPolicy','IDeliveryFeePolicy','IFefoBatchSpecification'] else 'Scoped per API request / transaction'
 row['Composition Root']='src/FreshFood-API/ApiCompositionRoot.cs'
 row['Status']='ASP.NET Core C#; stakeholder-requested migration; technical review'
with p.open('w',encoding='utf-8',newline='') as f:
 w=csv.DictWriter(f,fieldnames=rows[0].keys());w.writeheader();w.writerows(rows)

# Retain unrelated CI work and update only the .NET build/test steps.
p=R/'.github/workflows/ci.yml';s=p.read_text(encoding='utf-8')
s=s.replace('if compgen -G "**/*.csproj" > /dev/null || compgen -G "**/*.sln" > /dev/null; then','if [ -f "src/FreshFood.sln" ]; then')
s=s.replace("dotnet-version: '8.0.x'","dotnet-version: '10.0.401'")
s=s.replace('run: dotnet restore\n','run: dotnet restore src/FreshFood.sln\n')
s=s.replace('run: dotnet build --no-restore --configuration Release','run: dotnet build src/FreshFood.sln --no-restore --configuration Release')
s=s.replace('run: dotnet test --no-build --configuration Release --verbosity normal','run: dotnet test src/FreshFood.sln --no-build --configuration Release --verbosity normal')
p.write_text(s,encoding='utf-8')

# A one-time archive/conversion tool must never overwrite reviewed implementations on a later run.
p=R/'scripts/modeling/migrate_backend_dotnet.py';s=p.read_text(encoding='utf-8')
guard="    if (ROOT/'src/FreshFood-API/Services/Implements/CheckoutService.cs').exists():\n        raise SystemExit('C# implementations exist. This one-time migration generator is retired; edit the current C# source and model directly.')\n"
if guard not in s:s=s.replace("if __name__=='__main__':\n","if __name__=='__main__':\n"+guard)
p.write_text(s,encoding='utf-8')
print('Updated project documentation, architecture text, runtime constraint, DI lifetimes and .NET CI steps.')
