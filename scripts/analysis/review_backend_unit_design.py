"""Review design completeness; never execute backend unit tests."""
from pathlib import Path
import json,csv,collections,hashlib
D=Path('artifacts/testing/test-design/backend-unit')
j=json.loads((D/'backend-unit-test-design.json').read_text());methods=j['methods'];cases=[c for m in methods for c in m['cases']]
errors=[]
def check(name,ok,note=''):
 checks.append({'check':name,'passed':bool(ok),'note':note})
 if not ok:errors.append(name)
checks=[]
check('All 193 executable declarations cataloged',len(methods)==193)
check('All 85 interface contracts map to concrete methods',len(j['contracts'])==85 and all(c['realizations'] for c in j['contracts']))
check('Stable unique method/test IDs',len({m['id'] for m in methods})==len(methods) and len({c['id'] for c in cases})==len(cases))
check('Every method has N/A/B input groups',all({c['inputType'] for c in m['cases']}=={'N','A','B'} for m in methods),'Review-only constructor/pure-method abnormal cases remain explicit, not claimed executed.')
check('Every case records input, action and expected result',all(c['data'] is not None and c['steps'] and c['expected'] for c in cases))
check('Source snapshot hashes still match',all(hashlib.sha256(Path(m['file']).read_bytes()).hexdigest()==m['sourceSha256'] for m in methods))
check('No planned case has fabricated execution result',all(c['status']=='Not executed - awaiting approval' for c in cases))
index={c['id']:c for c in cases}
for d in j['coverage']:
 check('Decision plan '+d['decision'],all(x in index for x in d['caseIds']))
 if d['outcomes']==['True','False']:
  targets={t for cid in d['caseIds'] for t in index[cid]['targets']}
  check('Both outcomes '+d['decision'],all(d['decision']+':'+x in targets for x in ['True','False']))
  for n,a in enumerate(d['atoms'],1):check('Atomic condition '+d['decision']+':C'+str(n),all(d['decision']+':C'+str(n)+':'+x in targets for x in ['True','False']),'True/False must be evaluated; NE never counts as false. Concrete reachability remains a review item.')
check('TC/KLOC norm has no deficit',all(len(m['cases'])>=m['loc']*.1 for m in methods))
levels=collections.Counter(m['testLevel'] for m in methods)
review={'status':'DRAFT_REQUIRES_HUMAN_REVIEW','date':'2026-11-04','template':'templates/Test Documents/Template_Unit Test Case.xls','checklist':'checklists/Checklist_Test Case Review.xls','checks':checks,'failures':errors,'methods':len(methods),'contracts':len(j['contracts']),'testCases':len(cases),'sourceDecisions':len(j['coverage']),'actualCoverage':'NOT MEASURED - no execution authorized','testLevels':dict(levels),'caseDesignConstraints':sum(bool(c['gap']) for c in cases),'reviewItems':[
{'id':'UT-REV-01','topic':'Npgsql isolation','scope':'7 PostgreSqlSession declarations','decision':'Approve a transport seam for true unit tests, or keep these checks separately tagged as component verification; never count a live database as isolated unit coverage.'},
{'id':'UT-REV-02','topic':'Hard-to-reach defensive paths','scope':'static phone regex timeout, immutable table corruption/ambiguity/cycle and trusted ActorId facts','decision':'Review isolated test-resource/private harness or document proven structural unreachability. Do not force flaky timing or silently alter production state.'},
{'id':'UT-REV-03','topic':'Verified-paid state consistency','scope':'OrderStateMachine initial PendingPaid follow-up P01','decision':'Expected PendingPaid/Paid derives from approved decisions; current P01 sets Unpaid. This is a static review concern and planned test, not an executed defect result.'},
{'id':'UT-REV-04','topic':'Concrete witness/abnormal contracts','scope':'Cases carrying explicit review constraints, constructors and pure functions without declared abnormal validation','decision':'Confirm fixture assignments and justify N/A cases before automation. Generated truth constraints are planning evidence, not proof of runtime coverage.'}
],'approval':'Pending stakeholder / Technical Lead / QA. No scripts/project or tests generated/executed.'}
(D/'design-review.json').write_text(json.dumps(review,indent=2)+'\n')
with (D/'interface-realization-mapping.csv').open('w',newline='',encoding='utf-8-sig') as f:
 w=csv.writer(f);w.writerow(['Interface','Signature','Concrete method IDs','Review state'])
 for c in j['contracts']:w.writerow([c['type'],c['signature'],';'.join(c['realizations']),c['status']])
pim=json.loads(Path('artifacts/design/detailed/pim-to-code-mapping.json').read_text())
with (D/'requirements-design-code-tests.csv').open('w',newline='',encoding='utf-8-sig') as f:
 w=csv.writer(f);w.writerow(['Use cases','FR support basis','PIM class/operation or internal realization','Source method','Source file','Test case IDs','Workbook sheet','State'])
 for m in methods:
  mapped=[x for x in pim['operations'] if x['sourceClass']==m['type'] and any(s['name']==m['name'] for s in x['sourceMembers'])]
  design='; '.join(x['pimClass']+' :: '+x['pimOperation'] for x in mapped) or 'Internal/technical realization of '+m['type']+'; see source and public-owner cases'
  w.writerow([';'.join(m['useCases']),';'.join(m['requirements']),design,m['signature'],m['file']+':'+str(m['line']),';'.join(c['id'] for c in m['cases']),m['sheet'],'Draft plan; FR support link does not imply full FR acceptance coverage'])
summary=j['summary']
text='''# Backend Unit Test Design - Review Package

Version: 0.2 | Date: 2026-11-04 | Status: DRAFT - awaiting approval.

Use FreshFood_Backend_Unit_Test_Cases_v0.2.xlsx. Version 0.1 is retained for comparison and superseded for worksheet layout. Preconditions, input variants and confirmation criteria appear on the left; test-case intersections contain only O (selected) or blank (not selected). True, False and NE are explicit condition values on the left, not interpretations of blank cells. All 1,190 stable case identifiers and the canonical design data are preserved. Repeated rows retain the template Condition, Confirm and Result sections. unit-test-matrix-row-map.json identifies each sheet's actual result rows; matrix-workbook-verification-v0.2.json records the selection and formula checks.

The workbook is instantiated from the approved Template_Unit Test Case.xls. The legacy template was converted to XLSX while retaining its structural sheet names, column roles and condition/confirmation/result sections. Repeated test-case columns and additional function sheets follow the template guideline: one sheet per executable method. Original instructional sheets remain marked REFERENCE ONLY and are excluded from project totals.

## Scope and navigation

- Use cases: UC-C01 (catalog), UC-C03 (cart), UC-C05 (profile/addresses), UC-C06 (checkout), UC-C07 (my orders), plus their shared backend services, repositories, policies, entities and technical helpers.
- METHOD_COUNT executable declarations and CONTRACT_COUNT interface declarations. Compiler-generated methods and trivial auto-property accessors are excluded; explicit getter logic, constructors and private/protected helpers are included.
- CASE_COUNT designed cases: NORMAL normal, BOUNDARY boundary, ABNORMAL abnormal. There are DECISION_COUNT structural decision points in the source snapshot.
- FunctionList links to each method sheet. Contract-only rows link to concrete realization; interfaces have no executable branch body.
- Each case contains preconditions, input/mock state, action, expected output/exception, side-effect checks, technique and trace references.
- Supporting files: method-coverage.csv, branch-condition-coverage.csv, interface-realization-mapping.csv, requirements-design-code-tests.csv and fixtures.json.
- Existing source/compiled symbols and detailed PIM signatures are the mapping basis. Support links to FRs do not claim full system-level requirements acceptance coverage.

## Coverage semantics

LOC is the non-empty method-declaration line count (including signature); primary constructors count as one declaration line. The template TC/KLOC calculation is a planning norm and does not replace branch/condition adequacy.

The design targets every feasible decision outcome and each elementary condition True and False when actually evaluated. NE denotes short-circuit non-evaluation and never counts as False. Condition truth vectors and explicit state/data partitions supplement boundary analysis and experience-based cases (ownership, tampered cookies, replay, stale addresses, partial stock, late notification failure, SQL-like input and monetary precision).

Coverage is NOT MEASURED at this stage. Template Test coverage is the proportion of executed test cases, not source branch or condition coverage. Existing 67 tests and prior Sonar coverage are not results of this new plan. After approval, measure source statements/branches and retain separate evaluated-condition evidence; do not infer atomic-condition coverage from a branch percentage alone. Project minima are >=90% core statements and >=80% branches; the requested design target is 100% feasible branch/condition outcomes, with justified infeasible paths.

## Review items before automation

1. PostgreSqlSession has seven concrete Npgsql-dependent declarations. Choose an approved isolation seam for pure unit tests, or separately tag these cases as component verification. The workbook labels this distinction explicitly.
2. Corrupt embedded resources, ambiguity/cycle defenses and static bounded-regex timeouts may require a reviewed test-only resource/harness or structural-unreachability justification. Production tables/visibility must not be changed silently.
3. The planned verified-paid state case expects PendingPaid/Paid under approved decisions. Static inspection shows P01 initializes Unpaid after the paid branch; investigate this potential mismatch during review/execution. No runtime defect or failed result has been fabricated.
4. Cases marked with review constraints require concrete witness and abnormal-contract confirmation. Constructors/pure methods without an abnormal-input requirement do not acquire an invented rejection rule.
5. Payment/provider/refund success paths that remain TBD have fail-closed tests for current behavior. They are not represented as implemented successful business flows.
6. Proposed automation project after approval: src/Tests/Backend/FreshFood.Backend.UnitTests (.NET 10 / xUnit, referencing the existing backend projects). Existing regression tests remain separate. Internal access/private harness changes need the technical approval noted above.

## Approval and subsequent execution workflow

No new unit-test project or backend test scripts have been created or executed for this package. The current phase stops at design review.

After explicit approval:
1. Baseline the approved design and synchronize approved content under project governance.
2. Create the selected unit-test project, fixture builders, strict fakes and scripts traced to the stable UTM-xxx-TCyyy identifiers. Resolve reviewed testability items before claiming coverage.
3. Execute approved cases; record actual assertions and measured statement/branch/evaluated-condition evidence.
4. Record every failed execution using templates/Test Documents/Template_Defect_log.xls. Preserve its eight columns. Put artifact/version, test case reference, steps, input, expected/actual, assigned owner and retest evidence in the Description field; do not add columns or invent defects before execution.
5. Fill each method sheet: Executed By (L3), Passed/Failed, Executed Date and Defect ID in its Result section. Locate these rows using their labels or unit-test-matrix-row-map.json; row numbers vary with repeated input and confirmation variants. Leave not-run cases blank. The embedded Test Report recalculates passed, failed, untested and N/A/B totals using each sheet's actual result rows.
6. Retest/regressions, defect verification and final test report remain subject to the project verification gate. No duplicate standalone test result report will replace the embedded Test Report.

## Source basis

- templates/Test Documents/Template_Unit Test Case.xls
- templates/Test Documents/Template_Defect_log.xls
- checklists/Checklist_Test Case Review.xls
- .agents/Rules/testing-rules.md and .agents/skills/software-testing/SKILL.md
- artifacts/requirements/customer-use-case-descriptions.md
- artifacts/requirements/reviews/order-payment-return-use-case-review.md
- artifacts/design/detailed/detailed-class-model.json and pim-to-code-mapping.json
- artifacts/design/design-sequence-message-traceability.csv
- artifacts/testing/test-design/backend-unit-method-inventory.json

design-review.json records the static checks and unresolved human review items. The Master Specification and approved test baseline are not updated until this draft is approved.
'''
for old,new in [('METHOD_COUNT',summary['executableMethods']),('CONTRACT_COUNT',summary['interfaceContracts']),('CASE_COUNT',summary['testCases']),('NORMAL',summary['inputGroups']['N']),('BOUNDARY',summary['inputGroups']['B']),('ABNORMAL',summary['inputGroups']['A']),('DECISION_COUNT',summary['decisions'])]:text=text.replace(old,str(new))
(D/'README.md').write_text(text,encoding='utf-8')
print(json.dumps({k:v for k,v in review.items() if k in ['methods','contracts','testCases','sourceDecisions','failures','caseDesignConstraints','testLevels']},indent=2))
assert not errors

