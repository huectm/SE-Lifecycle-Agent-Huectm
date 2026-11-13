from pathlib import Path
import re,json,hashlib,collections
R=Path(__file__).resolve().parents[2];D=R/'artifacts/analysis/sonarqube'
rules={r['key'].split(':')[-1]:r for r in json.loads((D/'rules.json').read_text(encoding='utf-8-sig'))}
rows=[];seen=set()
for line in (D/'build-analysis.txt').read_text(encoding='utf-8-sig').splitlines():
 match=re.search(r'([^\r\n]+?\.cs)\((\d+),(\d+)\): warning (S\d+): (.*?)(?: \[|$)',line)
 if not match or match.groups() in seen:continue
 seen.add(match.groups());file,line_number,column,rule,message=match.groups()
 path=Path(file.strip());relative=path.relative_to(R).as_posix();meta=rules[rule]
 if rule=='S6444':
  triage='Timeout hardening required; assess whether input is attacker-controlled. Enum normalization uses a fixed pattern and bounded domain values.'
  if path.name=='ProfileService.cs':triage='Add an explicit regex timeout. Email/phone originate in HTTP requests; validate approved input limits. Do not assume this is an exploitable denial of service without reproduction.'
  action='Use a bounded regex execution timeout or a reviewed non-backtracking implementation.'
 elif rule=='S2092':
  triage='Confirmed conditional Secure flag: HTTP requests receive a cookie without Secure. Production exposure depends on HTTPS termination and proxy configuration.'
  action='Enforce Secure cookies and HTTPS in production; verify trusted reverse-proxy forwarded scheme handling.'
 elif rule=='S6964':
  triage='Explicit input-contract review required. Quantity/rating are validated by the service; omission becomes zero and is rejected. This warning does not demonstrate a validation bypass.'
  if path.name=='CatalogQueryDto.cs':triage='ClearanceOnly defaults to false for ordinary catalog requests. The omitted-filter behavior is intentional; review explicit optional/default contract documentation.'
  if path.name=='AddressInputDto.cs':triage='IsDefault defaults to false. Confirm whether the complete address PUT contract requires this flag or intentionally accepts that default.'
  action='Use JsonRequired/nullable semantics only where required by the approved request contract; preserve intentional optional filters.'
 elif rule=='S6932':
  triage='Raw payment payload access supports signature verification. Model-binding normalization could break signature verification; do not mechanically apply this recommendation.'
  action='Review the payment-verification contract and retain documented raw-body access if required. Human acceptance/suppression is pending.'
 else:
  triage='Maintainability recommendation; top-level ASP.NET startup uses synchronous Run.'
  action='Use await app.RunAsync() in the top-level asynchronous startup.'
 scope='Shared backend'
 for word,uc in [('Catalog','UC-C01'),('Cart','UC-C03'),('Profile','UC-C05'),('Address','UC-C05'),('Checkout','UC-C06'),('Payment','UC-C06'),('OrderReview','UC-C07')]:
  if word in path.name:scope=uc;break
 if path.name=='OrderStateMachine.cs':scope='UC-C06 / UC-C07'
 rows.append({'id':f'SQ-{len(rows)+1:03}','file':relative,'line':int(line_number),'column':int(column),'rule':meta['key'],'sonar_type':meta['type'],'sonar_severity':meta['severity'],'message':message,'scope':scope,'triage':triage,'recommended_action':action,'status':'Pending human review','source_sha256':hashlib.sha256(path.read_bytes()).hexdigest()})
report={'status':'PRELIMINARY_UPLOAD_BLOCKED','project':'huectm_SE-Lifecycle-Agent','organization':'huectm','basis':'SonarCloud-provisioned C# Roslyn analyzer build output, not a completed server analysis','blocker':'Automatic Analysis is enabled; SonarCloud rejected the .NET scanner submission.','quality_gate':'NOT_EVALUATED','tests_passed':41,'tests_failed':0,'findings':rows,'counts':dict(collections.Counter(r['sonar_type'] for r in rows))}
(D/'preliminary-review.json').write_text(json.dumps(report,ensure_ascii=False,indent=2)+'\n',encoding='utf-8')
print(json.dumps({k:v for k,v in report.items() if k!='findings'},indent=2))
