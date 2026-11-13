"""Create class-organized NUnit cases with stable design IDs and explicit blockers."""
from pathlib import Path
import json,re,collections,textwrap,subprocess,tempfile,shutil
from html import escape
target=Path('src/Tests/Backend/FreshFood.Backend.UnitTests');target.mkdir(parents=True,exist_ok=True)
root=Path(tempfile.mkdtemp(prefix='readable-unit-stage-',dir='scratch'))
design=json.loads(Path('artifacts/testing/test-design/backend-unit/backend-unit-test-design.json').read_text(encoding='utf-8'))
resolved=json.loads(Path('artifacts/testing/test-design/backend-unit/materialized-vectors.json').read_text(encoding='utf-8'))
groups=collections.defaultdict(list);mapping=[]
def documentation(summary, paragraphs):
 lines=['    /// <summary>']
 for line in textwrap.wrap(summary,width=108,break_long_words=False,break_on_hyphens=False):lines.append('    /// '+escape(line,quote=False))
 lines+=['    /// </summary>','    /// <remarks>']
 for text in paragraphs:
  lines.append('    /// <para>')
  for line in textwrap.wrap(text,width=108,break_long_words=False,break_on_hyphens=False):lines.append('    /// '+escape(line,quote=False))
  lines.append('    /// </para>')
 return lines+['    /// </remarks>']
def case_documentation(method,case,reason):
 notes=[
  'Method under test: '+method['signature'],
  'Technique: '+case['technique']+'; input category: '+{'N':'Normal','A':'Abnormal','B':'Boundary'}[case['inputType']]+'.',
  'Arrange: '+case['preconditions'],
  'Design input: '+json.dumps(case['data'],ensure_ascii=True),
  'Act: '+case['steps'],
  'Design expected result: '+case['expected'],
  'Design exception expectation: '+(case['exception'] or 'No exception specified.'),
  'Expected side effects: '+case['sideEffects']
 ]
 if case['id'] in resolved:
  concrete=resolved[case['id']]
  notes+=['Concrete execution input: '+json.dumps(concrete['data'],ensure_ascii=True),
          'Concrete exception expectation: '+(concrete['exception'] or 'No exception.'),
          'Concrete witness basis: '+concrete['basis']]
 if case.get('targets'):notes+=['Branch/condition targets: '+', '.join(case['targets'])]
 if reason:notes+=['Execution constraint (NUnit Ignore): '+reason]
 elif case['id']=='UTM-087-TC003':notes+=['Verified refinement UT-DEF-001: expected transition evidence is I00, T01p, P01, P02; final fulfillment/payment states are PendingPaid/Paid. The original design list omitted P02.']
 elif case.get('gap') and case['id'] not in resolved:notes+=['Design review note: '+case['gap']]
 notes+=['Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID '+method['id']+'.']
 return documentation(case['id']+': '+case['title'],notes)
for m in design['methods']:groups[m['fullType']].append(m)
for typename,methods in groups.items():
 name=re.sub(r'[^A-Za-z0-9_]','_',typename.replace('FreshFood.Api.','').replace('FreshFood.Reposistory.',''))+'Tests'
 lines=['// Generated NUnit tests with explicit business calls and expected-result assertions.','namespace FreshFood.Backend.UnitTests;','[NUnit.Framework.TestFixture]','public sealed class '+name,'{']
 for m in methods:
  for c in m['cases']:
   reason=''
   if m['type']=='SqlRepository' and m['name']=='.ctor':reason='Abstract base constructor is exercised through concrete repository classes.'
   elif m['type']=='OrderStateMachine' and m['name'] in ['State','Guard'] and c['id'] not in resolved:reason='Private predicate plan needs concrete region/guard snapshots; no source visibility change authorized.'
   elif m['type']=='PostgreSqlSession':reason='Component case: requires an approved PostgreSQL transport fixture; excluded from isolated unit execution.'
   elif c.get('targets') and c['id'] not in resolved:reason='Symbolic structural vector: concrete witness and independent oracle are not specified in the approved design.'
   elif c.get('gap') and c['id'] not in resolved and c['id']!='UTM-087-TC003':reason=c['gap']
   elif m['type'] in ['FollowUp','Rule','Preparation','Allocation']:reason='Private implementation record: verify through owning service; no separate executable oracle specified.'
   lines+=case_documentation(m,c,reason)
   lines+=['    [NUnit.Framework.Test'+('][NUnit.Framework.Ignore('+json.dumps(reason)+')' if reason else '')+']','    [NUnit.Framework.Property("DesignCase", "'+c['id']+'")]', '    public System.Threading.Tasks.Task '+c['id'].replace('-','_')+'() => throw new System.InvalidOperationException("Test body generation has not completed.");']
   mapping.append({'caseId':c['id'],'methodId':m['id'],'sourceClass':typename,'script':str(target/(name+'.cs')),'test':name+'.'+c['id'].replace('-','_'),'designBlocker':reason})
 if typename=='FreshFood.Api.Services.Implements.OrderStateMachine':
  lines+=documentation('Supplemental payment-guard rejection cases for UT-DEF-001.',[
   'Method under test: OrderStateMachine.ProcessEventAsync; verifiedInitialPayment guard for transition P02.',
   'Technique: evaluated condition and experience-based security regression testing.',
   'Input tuples (initial, verified, paidState): (false, true, true), (true, false, true), (true, true, false).',
   'Arrange: an unpaid order, a trusted internal context with the selected flags, and a strict repository that rejects every write.',
   'Act: process verifiedSePayNotification using the matching aggregate identifier.',
   'Expected: DomainException with STATE_GUARD_REJECTED; payment remains Unpaid and no transition evidence is written.',
   'Evidence basis: artifacts/testing/unit-execution/fix-log.md, UT-DEF-001. These three supplemental cases are outside the 1,190 design IDs.'
  ])
  lines+=['    [NUnit.Framework.TestCase(false, true, true)]','    [NUnit.Framework.TestCase(true, false, true)]','    [NUnit.Framework.TestCase(true, true, false)]','    [NUnit.Framework.Category("Supplemental")]','    public System.Threading.Tasks.Task RejectUntrustedInitialPayment(bool initial, bool verified, bool paidState) => throw new System.InvalidOperationException("Test body generation has not completed.");']
 lines+=['}'];(root/(name+'.cs')).write_text('\n'.join(lines)+'\n',encoding='utf-8')
subprocess.run(['dotnet','run','--project','scripts/analysis/ReadableUnitTests/ReadableUnitTests.csproj','--',str(root)],check=True)
for file in root.glob('*.cs'):
 source=file.read_text(encoding='utf-8')
 assert 'Test body generation has not completed.' not in source,file
 assert 'CaseRunner' not in source,file
for file in root.glob('*.cs'):shutil.copy2(file,target/file.name)
Path('artifacts/testing/test-design/backend-unit/script-case-mapping.json').write_text(json.dumps(mapping,indent=2)+'\n',encoding='utf-8')
print(len(groups),'test classes;',len(mapping),'stable IDs; fully expanded bodies published')
