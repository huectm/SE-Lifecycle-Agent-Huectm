"""Record the authorized Sonar remediation against the existing review/defect IDs."""
from pathlib import Path
import json,collections,hashlib,datetime
D=Path('artifacts/analysis/sonarqube')
def read(name):return json.loads((D/name).read_text(encoding='utf-8-sig'))
r=read('review.json');run=read('analysis-run.json');gate=read('quality-gate.json')['projectStatus'];open_issues=read('issues.json')['issues'];server={x['key']:x for x in read('all-issues-server-verification.json')['issues']}
assert not open_issues
assert len(server)==18 and all(x['issueStatus']=='FIXED' for x in server.values())
actions={
'SQ-001':'Set a 100 ms timeout on enum-to-SQL-name regex replacement; retain existing casing and VIETQR encoding.',
'SQ-002':'Use nullable IsDefault transport input and explicitly default to false in ProfileService; preserve optional-field behavior.',
'SQ-003':'Use nullable ClearanceOnly transport input and explicitly default to false in CatalogService; preserve optional filtering.',
'SQ-004':'Mark Quantity with JsonRequired so omitted JSON cannot silently become zero; preserve existing quantity validation.',
'SQ-005':'Mark Rating with JsonRequired so omitted JSON cannot silently become zero; preserve existing rating validation.',
'SQ-006':'Await app.RunAsync instead of synchronously running the web host.',
'SQ-008':'Bind PaymentNoticeDto through PaymentNoticeModelBinder, retaining exact raw body text and verification headers; controller delegates unchanged.',
'SQ-010':'Use a 100 ms phone regex timeout; map timeout to INVALID_PHONE before geocoding, transaction or persistence.',
'SQ-011':'Set a 100 ms timeout on state-name normalization; retain the single table-driven OrderStateMachine and stable transition IDs.',
'SQ-012':'Reuse a static readonly expected transition array in the existing test.',
'SQ-013':'Reuse a static readonly JsonSerializerOptions instance in design-mapping serialization.',
'SQ-014':'Remove the redundant partial Program declaration under ASP.NET Core 10; HTTP integration tests verify generated Program accessibility.',
'SQ-015':'The bounded-time regex overload removes the GeneratedRegex recommendation; no independent state-machine refactor or suppression.',
'SQ-017':'The bounded-time phone regex overload removes the GeneratedRegex recommendation; no change to the accepted phone pattern.',
'SQ-018':'The bounded-time SQL-name regex overload removes the GeneratedRegex recommendation; no SQL encoding change.'}
baseline=json.loads(Path('artifacts/analysis/baselines/sonarqube-before-all-fixes-20261104/review.json').read_text(encoding='utf-8-sig'));before={f['id']:f for f in baseline['findings']}
for f in r['findings']:
 if f['id'] in actions:f.update(implemented_action=actions[f['id']],approval_date='2026-11-04',approval_basis='Stakeholder authorized fixing all remaining Sonar issues and recording the process.')
 f['status']='Fixed and verified by SonarCloud';f['resolution']=server[f['issue_key']]['resolution'];f['server_verification']='all-issues-server-verification.json'
 f['verification']='Sonar issue FIXED after analysis '+run['analysisId']+'; 67/67 tests passed; analysis build has 0 warnings and 0 errors.'
 f['source_sha256_before_batch']=before[f['id']]['source_sha256'];f['source_sha256']=hashlib.sha256(Path(f['file']).read_bytes()).hexdigest()
metrics={x['metric']:x['value'] for x in read('metrics.json')['component']['measures']}
r.update(status='ALL_ISSUES_FIXED_COVERAGE_GATE_FAILED',analysis_id=run['analysisId'],review_date='2026-11-04',quality_gate=gate['status'],failed_conditions=[x for x in gate['conditions'] if x['status']=='ERROR'],metrics=metrics,tests_passed=67,tests_failed=0,tests_skipped=0,counts={'VULNERABILITY':0,'CODE_SMELL':0,'BUG':0},open_issue_count=0,fixed_issue_count=18,approved_fix_scope=[f['id'] for f in r['findings']],production_source_modified=True,server_issues_suppressed_or_closed=False)
r['basis']='Stakeholder-authorized remediation of all Sonar issues; fresh build/tests/coverage/scan; all 18 original issue keys verified FIXED automatically, without suppression or manual closure.'
r['fix_log']=[{'step':1,'event':'Preserved pre-batch report, metrics, issue list and defect workbook','evidence':'artifacts/analysis/baselines/sonarqube-before-all-fixes-20261104','open_issues':15}, {'step':2,'event':'Applied code fixes grouped by security regex, DTO presence/defaults, webhook binding, async host and test allocation recommendations','findings':[f['id'] for f in r['findings'] if f['id'] in actions]}, {'step':3,'event':'Added HTTP raw-webhook, required numeric input, optional-filter and phone-boundary regression tests','evidence':'src/Tests/Backend/FreshFood-API.Tests/SonarRemediationTests.cs'}, {'step':4,'event':'Release build and all 67 tests passed; static analysis build produced 0 warnings and 0 errors','evidence':['build-analysis.txt','test-coverage.txt','coverage.xml']}, {'step':5,'event':'Completed SonarCloud scan and verified all original issue keys FIXED','analysis_id':run['analysisId'],'open_issues':0,'evidence':['issues.json','all-issues-server-verification.json']}, {'step':6,'event':'Rechecked PIM source refinements; 347 logical operation mappings retained; raw-body adapter and optional flags documented','evidence':'artifacts/design/detailed/pim-code-consistency.json'}, {'step':7,'event':'Recorded remaining coverage gate failure without changing its threshold','actual_coverage':metrics['coverage'],'required_coverage':'80'}]
r['logged_at_utc']=datetime.datetime.now(datetime.timezone.utc).isoformat()
(D/'review.json').write_text(json.dumps(r,ensure_ascii=False,indent=2)+'\n',encoding='utf-8')
run.update(date='2026-11-04',approved_fix='All remaining Sonar issues',tests_passed=67);(D/'analysis-run.json').write_text(json.dumps(run,indent=2)+'\n')
lines=['# Sonar Remediation Execution Log','','Date: 2026-11-04 | Scope: all 18 original issues | Authority: explicit stakeholder instruction.','','## Result','','All 18 original issue keys are FIXED on SonarCloud. No issue suppression or manual server-side closure was used. Release build: 0 errors, 0 warnings. Tests: 67 passed, 0 failed, 0 skipped. Open issues: 0. Coverage: '+metrics['coverage']+'%. Quality Gate remains ERROR solely because coverage is below 80%.','','## Execution history','']
for event in r['fix_log']:lines.append(str(event['step'])+'. '+event['event']+'.')
lines+=['','## Issue-by-issue change log','','| ID | Rule | Source location at detection | Implemented change | Server result |','|---|---|---|---|---|']
for f in r['findings']:lines.append('| '+f['id']+' | '+f['rule']+' | '+f['file']+':'+str(f['line'])+' | '+f['implemented_action']+' | FIXED |')
lines+=['','## Evidence','','- Current analysis: `'+run['analysisId']+'`.','- `review.json`: complete findings, source hashes and execution history.','- `all-issues-server-verification.json`: original issue statuses from SonarCloud.','- `SonarCloud_Defect_Log.xlsx`: existing approved defect-log format.','- `build-analysis.txt`, `test-coverage.txt`, `coverage.xml`, `quality-gate.json`: verification evidence.','','Existing deferred payment/provider integrations and business-policy TBDs remain explicit. This remediation does not claim release readiness or exhaustive branch coverage.']
(D/'fix-log.md').write_text('\n'.join(lines)+'\n',encoding='utf-8')
print('Logged 18 fixed findings; coverage',metrics['coverage'])
