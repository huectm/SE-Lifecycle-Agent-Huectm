import json as _pimjson, runpy as _pimrunpy
from pathlib import Path as _PimPath
if _pimjson.loads(_PimPath('artifacts/design/detailed/detailed-class-model.json').read_text(encoding='utf-8-sig')).get('model_level') == 'PIM':
 _pimrunpy.run_path('scripts/analysis/verify_pim_realization.py', run_name='__main__')
 raise SystemExit(0)
from pathlib import Path
import json
R=Path(__file__).resolve().parents[2];D=R/'artifacts/design/detailed'
report=json.loads((D/'design-code-sequence-consistency.json').read_text(encoding='utf-8'))
findings=[]
def add(id,severity,topic,evidence,impact,proposed):
 findings.append({'id':id,'severity':severity,'topic':topic,'evidence':evidence,'impact':impact,'proposed_resolution':proposed,'status':'Open for technical review'})
for item in report['class_signature_mismatches']:
 name=item['class'];method=item['design']['name'];key=(name,method)
 ids={('CartController','GetCartAsync'):'DCC-001',('CartController','ChangeQuantityAsync'):'DCC-002',('MyOrdersController','CancelOrderAsync'):'DCC-003',('MyOrdersController','SubmitReviewAsync'):'DCC-004',('PostgreSqlSession','QueryAsync'):'DCC-005'}
 add(ids[key],'Medium','Class operation signature differs from C#',item,
  'HTTP adapter actions have different route/body parameters. This is diagram/transport-binding drift, not evidence of an invalid C# invocation.' if 'Controller' in name else 'The design declares a return containing T but omits the method generic parameter; source declares QueryAsync<T> and object?[] parameters.',
  'Reconcile the approved class signature and document HTTP route/body binding while retaining the DTO service contract.' if 'Controller' in name else 'Show QueryAsync<T>(sql: string, parameters: object?[], signal: CancellationToken): Task<List<T>> and the generic constraint.')
for item in report['additional_public_source_methods']:
 if item['class']=='UnitOfWork':add('DCC-006','Medium','Generic unit-of-work result overload missing from implementation class design',item,'Checkout and other services return callback values through ExecuteAsync<T>; the class view currently shows only Task-returning work.','Show both non-generic and generic overloads; align the implementation-class view with its interface.')
 if item['class']=='ProfileController':add('DCC-007','Medium','Address update HTTP action missing from detailed design',item,'PUT address updates use UpdateAddressAsync(addressId, request, signal), while the diagram exposes SaveAddressAsync only.','Document the update action or an explicit transport refinement of the SaveAddress use-case operation; do not introduce a new business use case.')
for item in report['property_differences']:
 add('DCC-008' if item['class']=='TransitionSnapshot' else 'DCC-009','High' if item['class']=='TransitionSnapshot' else 'Low','Snapshot trust boundary and shape differ' if item['class']=='TransitionSnapshot' else 'Order detail projection members are undocumented',item,
  'The design shows mutable/public and obsolete snapshot fields, but source uses an internal constructor, read-only identities, an Order reference, Batches and internal execution flags.' if item['class']=='TransitionSnapshot' else 'ProductId and ProductName are materialized join projections in the partial entity; they are absent from the detailed class attributes.',
  'Review a server-only context model with accurate visibility and constructor; retain the trusted creation boundary rather than exposing setters to satisfy the old diagram.' if item['class']=='TransitionSnapshot' else 'Record derived read-projection attributes and their query provenance; do not add database columns.')
add('DCC-010','Low','State-machine parameter names differ',report['parameter_name_differences'],'Types match, but design snapshot/event and source context/message names are inconsistent.','Use consistent parameter names across IOrderStateMachine, OrderStateMachine, class specifications and message notation.')
for item in report['source_call_pairs_requiring_review']:
 if item['receiver']=='ProfileRepository':
  add('DCC-011' if item['pageTitle']=='SaveAddress' else 'DCC-012','Medium','Sequence contains a repository call absent from the source flow',item,
   'ProfileService does not call GetCustomerAsync from this operation or its same-class helper chain. Ownership is checked through the trusted customer and owned-address queries.',
   'Reconcile this message with the approved responsibility flow; do not add redundant database access merely to satisfy the diagram.')
 else:add('DCC-013','High','QR interaction is designed but not enabled in the current implementation',item,
  'The sequence calls SePayPaymentAdapter.CreateQrAsync, but CheckoutService.CreatePaymentQrAsync throws PRE_ACCEPTANCE_PAYMENT_CORRELATION_TBD (503) before any gateway call. This is an existing deferred integration, not a new payment policy decision.',
  'Mark the current implementation limitation explicitly in the sequence; enable the intended path only after the upstream correlation contract is resolved and approved.')
add('DCC-014','Medium','PrepareCheckout omits mapped pricing and allocation collaborations',{'master':'artifacts/diagrams/sequence/uc-c06-checkout-design-sequence.drawio','page':1,'source':'src/FreshFood-API/Services/Implements/CheckoutService.cs','line':40},
 'Source PrepareCheckoutAsync calls Allocate, which invokes CheckoutRepository.LockFefoBatchesAsync and BatchPricingPolicy.Quote. The sequence represents the summary as a local computation and omits both collaborator messages.',
 'Expand the design sequence or add a linked allocation refinement covering repository access and batch pricing.')
add('DCC-015','Low','State-machine refinement shows an extra early CurrentState call',{'masters':['artifacts/diagrams/sequence/uc-c06-checkout-design-sequence.drawio','artifacts/diagrams/sequence/uc-c07-my-orders-design-sequence.drawio'],'pages':[6,7],'source':'src/FreshFood-API/Services/Implements/OrderStateMachine.cs','lines':[97,98]},
 'Both refinements call CurrentState before table lookup and after processing. Source ProcessEventAsync uses private State/Process evaluation and calls CurrentState when constructing its final result.',
 'Align message order with the approved control responsibility; distinguish private state resolution from the public CurrentState result operation.')
add('DCC-016','Medium','Main checkout notification guard is broader than source replay behavior',{'master':'artifacts/diagrams/sequence/uc-c06-checkout-design-sequence.drawio','page':2,'message':36,'source':'src/FreshFood-API/Services/Implements/CheckoutService.cs','line':111},
 'The main sequence uses a commit-succeeded notification guard. Source additionally requires !result.Replay. The separate replay refinement correctly skips notifications, so the main view needs an explicit cross-reference/guard.',
 'Clarify that post-commit notification occurs for a newly accepted order only; preserve idempotent replay behavior.')
findings.sort(key=lambda x:x['id'])
result={'date':'2026-11-03','status':'INCONSISTENCIES_CONFIRMED','basis':'Current C# semantic symbols, direct Draw.io inspection and manual source-flow review','summary':report['summary'],'findings':findings,'limitations':['Frontend implementations remain outside the C# backend scope; their messages were checked against the design only.','HTTP operation labels may abstract route/body binding. Such adaptation must be documented, not treated as a CLR call failure.','The automated call check establishes name/signature and same-class-helper reachability, not exhaustive branch, timing, exception or dynamic execution equivalence.','Differences in categories can refer to the same underlying defect; category counts must not be summed as independent findings.'],'source_and_design_modified':False}
(D/'design-code-consistency-findings.json').write_text(json.dumps(result,ensure_ascii=False,indent=2)+'\n',encoding='utf-8')
p=D/'architecture-realization-review.md';text=p.read_text(encoding='utf-8');heading='## Three Way Source Class and Sequence Consistency Review'
text=text.split(heading)[0].rstrip()+'\n\n'+heading+'\n\n'
text+='Review date: 2026-11-03. Result: not fully synchronized. This is a consistency review, not approval of changes to the design or production implementation.\n\n'
s=report['summary']
text+=f"Roslyn loaded the two backend projects with {s['compiledSourceErrors']} compilation errors and {s['workspaceDiagnostics']} workspace diagnostics. The review considered {s['backendClassifiers']} backend design classifiers, {s['sourceTypes']} source types, {s['sourceInvocations']} invocation expressions and {s['backendSequenceCallsChecked']} backend-targeted sequence calls. Platform aliases are explicitly mapped; frontend implementations remain scaffolds.\n\n"
text+=f"The editable class masters match their current model operations, and all sequence trace labels match their editable masters. This confirms export consistency, not source conformance. Five class-operation signatures differ from C#, five HTTP message occurrences require binding reconciliation, two data classes have attribute drift, and three inter-object messages have no matching call in their corresponding source flow. There are also two parameter-naming differences. Some categories overlap.\n\n"
text+='| Finding | Severity | Topic | Proposed resolution |\n|---|---|---|---|\n'
for f in findings:text+=f"| {f['id']} | {f['severity']} | {f['topic']} | {f['proposed_resolution']} |\n"
text+='\nThe source still has one table-driven OrderStateMachine implementing IOrderStateMachine; no per-transition classes were reintroduced. No source or editable diagram was rewritten in this audit. Upstream approvals are not inferred from successful compilation. Proposed corrections require the existing design-change review and subsequent Draw.io-to-PNG/Master Specification synchronization.\n\n'
text+='Evidence: design-code-sequence-consistency.json (all checks and signatures), design-code-consistency-findings.json (16 deduplicated review findings), design-code-method-matrix.csv (operation correspondence), design-code-sequence-call-matrix.csv (message correspondence), and source-consistency-symbols.json (current Roslyn symbols/calls).\n'
p.write_text(text,encoding='utf-8')
print('Recorded',len(findings),'deduplicated review findings; production source and design masters remain unchanged.')
