from pathlib import Path
import json,collections,hashlib,re
R=Path(__file__).resolve().parents[2];D=R/'artifacts/analysis/sonarqube'
def read(name):return json.loads((D/name).read_text(encoding='utf-8-sig'))
previous=read('preliminary-review.json');index={(f['file'],f['line'],f['rule']):f for f in previous['findings']}
run=read('analysis-run.json');gate=read('quality-gate.json')['projectStatus'];metrics={m['metric']:m['value'] for m in read('metrics.json')['component']['measures']}
rows=[];next_id=max(int(f['id'].split('-')[-1]) for f in previous['findings'])+1
for issue in read('issues.json')['issues']:
 file=issue['component'].split(':',1)[1];line=issue.get('line',1);rule=issue['rule'];old=index.get((file,line,rule))
 if old:row=dict(old)
 else:
  row={'id':f'SQ-{next_id:03}','file':file,'line':line,'rule':rule,'scope':'Test infrastructure' if '/FreshFood-API.Tests/' in file else 'Shared backend'};next_id+=1
  if rule.endswith('SYSLIB1045'):
   row['triage']='GeneratedRegex is a performance/maintainability recommendation. Consider it with timeout hardening; it does not independently fix S6444.'
   row['recommended_action']='Evaluate a source-generated, bounded-time regex for the existing fixed pattern; preserve behavior.'
  elif rule.endswith('ASP0027'):
   row['triage']='ASP.NET Core 10 no longer requires the legacy public partial Program declaration for WebApplicationFactory access.'
   row['recommended_action']='Remove the redundant declaration after verifying the HTTP test host still builds and runs.'
  elif rule.endswith('CA1869'):
   row['triage']='Informational analyzer recommendation in DesignMappingTests; not a production request-path finding.'
   row['recommended_action']='Reuse a static JsonSerializerOptions instance in the design-mapping test.'
  else:
   row['triage']='Informational constant-array allocation recommendation in BackendTests; not a production defect.'
   row['recommended_action']='Reuse the constant expected array where justified; do not prioritize this over security and coverage gaps.'
 row.update({'issue_key':issue['key'],'sonar_type':issue['type'],'sonar_severity':issue['severity'],'message':issue['message'],'status':'Pending human review'})
 row['source_sha256']=hashlib.sha256((R/file).read_bytes()).hexdigest();rows.append(row)
rows.sort(key=lambda f:int(f['id'].split('-')[-1]))
coverage=[]
for component in read('file-coverage.json')['components']:
 if component.get('path','').startswith('src/FreshFood-API/Services/Implements/') and Path(component['path']).name in ['CatalogService.cs','CartService.cs','ProfileService.cs','CheckoutService.cs','MyOrdersService.cs']:
  measures={m['metric']:m['value'] for m in component.get('measures',[])}
  coverage.append({'class':Path(component['path']).name,'coverage':measures.get('coverage'),'uncovered_lines':measures.get('uncovered_lines')})
report={'status':'COMPLETE_QUALITY_GATE_FAILED','project':run['projectKey'],'organization':'huectm','analysis_id':run['analysisId'],'dashboard':run['dashboard'],'basis':'Completed SonarCloud server analysis, including imported Roslyn findings','quality_gate':gate['status'],'failed_conditions':[c for c in gate['conditions'] if c['status']=='ERROR'],'metrics':metrics,'tests_passed':41,'tests_failed':0,'tests_skipped':0,'counts':dict(collections.Counter(f['sonar_type'] for f in rows)),'service_class_coverage':coverage,'findings':rows,'production_source_modified':False,'server_issues_suppressed_or_closed':False}
(D/'review.json').write_text(json.dumps(report,ensure_ascii=False,indent=2)+'\n',encoding='utf-8')
(D/'analysis-mode-change.json').write_text(json.dumps({'project':run['projectKey'],'key':'sonar.autoscan.enabled','before':'true','after':'false','changedBy':'Stakeholder confirmation in conversation','agentChangedSetting':False,'restoreRequired':False},indent=2)+'\n',encoding='utf-8')
p=R/'artifacts/implementation/dotnet-migration-review.md';s=p.read_text(encoding='utf-8');heading='## SonarCloud review on 2026-11-02';s=s.split(heading)[0].rstrip()
s=s.replace('40 passing tests: 31 unit/data cases','41 passing tests: 32 unit/data cases').replace('37 passing tests: 30 unit/data cases, six ASP.NET HTTP cases and one SQL integration scenario','41 passing tests: 32 unit/data cases, two design/DI checks, six ASP.NET HTTP cases and one SQL integration scenario')
s+='\n\n'+heading+'\n\n'
s+=f"Completed analysis: {run['analysisId']}. Project: {run['projectKey']}; organization: huectm. SonarScanner for .NET 12.0.0 uploaded the C# analysis after the stakeholder disabled Automatic Analysis. All 41 tests passed with coverage collection. Quality Gate: FAILED.\n\n"
s+='| Metric | Actual result |\n|---|---|\n| Bugs | 0 |\n| Vulnerabilities | 5 |\n| Code Smells | 13 |\n| Security Hotspots | 0 |\n| Coverage | 68.7% |\n| Duplicated lines | 0.0% |\n| Security Rating | B; gate requires A |\n\n'
s+='The two failed gate conditions are new-code security rating B (required A) and new-code coverage 68.7% (required at least 80%). Reliability, maintainability, duplication and reviewed-hotspot conditions passed. This does not establish production acceptance.\n\n'
s+='The 18 server issues comprise the original 11 Sonar C# findings and seven imported Roslyn recommendations. Two informational recommendations concern test infrastructure; 16 issues concern production sources. Five vulnerabilities are four missing regex timeouts and one conditional Secure cookie flag. Exploitability and treatment remain subject to contextual review. Raw webhook payload access and optional input defaults must be assessed against their approved contracts before mechanical changes. No production source fixes, issue suppression, false-positive closure or Quality Gate relaxation were performed.\n\n'
s+='| Main application service class | Coverage | Uncovered lines |\n|---|---|---|\n'
for c in sorted(coverage,key=lambda x:x['class']):s+=f"| {c['class']} | {c['coverage']}% | {c['uncovered_lines']} |\n"
s+='\nThese are service-class metrics, not use-case event-flow or branch/condition coverage claims. Prioritize missing address-management paths in ProfileService and reorder/review/cancellation exception paths in MyOrdersService, while retaining tests for ownership, atomicity and payment independence.\n\nEvidence: artifacts/analysis/sonarqube/review.json, quality-gate.json, metrics.json, issues.json, file-coverage.json and SonarCloud_Defect_Log.xlsx. The prior preliminary-review.json is retained as historical evidence and is superseded by this completed analysis.\n'
p.write_text(s,encoding='utf-8')
print(json.dumps({k:v for k,v in report.items() if k not in ['findings','service_class_coverage','metrics']},indent=2))
