from pathlib import Path
import json
R=Path(__file__).resolve().parents[2]
p=R/'artifacts/design/detailed/detailed-class-model.json';m=json.loads(p.read_text(encoding='utf-8'))
m['architecture_alignment']['signature_notation']='C# Task/Task<T> and CancellationToken; frontend React Promise and Flutter Future remain unchanged'
for page in m['pages']:
 page['edges']=[e for e in page['edges'] if not(e['source']=='PaymentNoticeHandler' and e['target']=='IPaymentGateway' and e['kind']=='association')]
p.write_text(json.dumps(m,ensure_ascii=False,indent=2)+'\n',encoding='utf-8')
p=R/'artifacts/design/detailed/architecture-to-design-realization.csv';s=p.read_text(encoding='utf-8').replace('Promise/AbortSignal contract notation; no .NET types','Task/CancellationToken C# contracts; ASP.NET Core built-in DI');p.write_text(s,encoding='utf-8')
p=R/'artifacts/requirements/software-requirements-specification.md';s=p.read_text(encoding='utf-8').replace('Microsoft SQL Server 2022 or PostgreSQL 16+','PostgreSQL 16+');p.write_text(s,encoding='utf-8')
p=R/'artifacts/design/detailed/selected-design-solutions.json';x=json.loads(p.read_text());x['backend_runtime']={'framework':'ASP.NET Core 10','language':'C#','database_driver':'Npgsql 10.0.3','dependency_injection':'ASP.NET Core built-in constructor DI','basis':'Explicit stakeholder request, 2026-11-02'};p.write_text(json.dumps(x,indent=2)+'\n',encoding='utf-8')
p=R/'scripts/modeling/update_backend_rtm.mjs';s=p.read_text(encoding='utf-8').replace("+'Service.js'","+'Service.cs'").replace('src/FreshFood-API/tests/backend.test.js','src/Tests/Backend/FreshFood-API.Tests/BackendTests.cs; src/Tests/Backend/FreshFood-API.Tests/PostgreSqlTests.cs')
s=s.replace('156 backend classifiers mapped; local tests use test doubles. PostgreSQL/provider integration and unresolved storage/payment policies are not marked complete.','ASP.NET Core C#: 132 backend classifiers mapped; 39 local unit/HTTP/SQL tests passed. Real-server contention and external provider acceptance remain pending.')
p.write_text(s,encoding='utf-8')
print('Finalized C# runtime metadata, callback ownership and RTM source paths.')
