from pathlib import Path
import json,hashlib,csv,re
D=Path('artifacts/design/detailed');m=json.loads((D/'detailed-class-model.json').read_text());rules=json.loads((D/'order-state-transition-table.json').read_text());old=json.loads(Path('artifacts/design/baselines/per-transition-20261101/artifacts/design/detailed/detailed-class-model.json').read_text())
removed={r['class'] for r in old['transitions']}|{'IStateTransition','ITransitionExecutor','TransitionExecutor'}
checks=[]
def ck(name,ok):checks.append({'check':name,'passed':bool(ok)})
ck('24 stable table row identifiers',len(rules)==24 and len({r['Id'] for r in rules})==24)
ck('Original transition sources and targets preserved',{(r['Id'],r['Source'],r['Target']) for r in rules}=={(r['id'],r['source'],r['target']) for r in old['transitions']})
ck('No per-transition classifiers in active design',not(removed&set(m['classes'])))
ck('One state-machine interface and control class',all(n in m['classes'] for n in ['IOrderStateMachine','OrderStateMachine']))
ck('Five use case identifiers preserved',set(m['scope'])==set(old['scope']))
real=json.loads((D/'vopc-realization-mapping.json').read_text());ck('All 48 VOPC participations retained',len(real)==48 and all(set(r['DesignClasses'])<=set(m['classes']) for r in real))
ck('Current-state and event processing are exposed',all(any(op.startswith('+ '+name+'(') for op in m['classes']['OrderStateMachine']['operations']) for name in ['ProcessEventAsync','CurrentState']))
ck('Only repository collaborator is retained by state-machine DI',all(e['target']=='IOrderLifecycleRepository' for p in m['pages'] for e in p['edges'] if e['source']=='OrderStateMachine' and e['kind']=='association'))
ck('No obsolete source classifier files remain',all(not Path('src/FreshFood-API/Services/Implements/'+n+'.js').exists() and not Path('src/FreshFood-API/Services/'+n+'.js').exists() for n in removed))
records=json.loads((D/'diagram-pages.json').read_text());collisions=[]
for p in records:
 boxes=p['class_boxes'];ns=list(boxes)
 for i,a in enumerate(ns):
  x,y,w,h=boxes[a]
  for b in ns[i+1:]:
   xx,yy,ww,hh=boxes[b]
   if min(x+w,xx+ww)>max(x,xx) and min(y+h,yy+hh)>max(y,yy):collisions.append([p['owner'],p['page'],a,b])
 for route in p['routes']:
  for a,b in zip(route['points'],route['points'][1:]):
   x1,y1=a;x2,y2=b
   for n,(x,y,w,h) in boxes.items():
    if n in [route['source'],route['target']]:continue
    if (x1==x2 and x<x1<x+w and max(min(y1,y2),y)<min(max(y1,y2),y+h)) or (y1==y2 and y<y1<y+h and max(min(x1,x2),x)<min(max(x1,x2),x+w)):collisions.append([p['owner'],p['page'],'route crossing',n])
ck('No class overlaps or connector crossings through unrelated classes',not collisions)
(D/'state-machine-design-verification.json').write_text(json.dumps({'checks':checks,'failures':[c for c in checks if not c['passed']],'class_pages':len(records),'classifiers':len(m['classes']),'table_rows':len(rules),'geometry_collisions':collisions},indent=2),encoding='utf-8')
print('Checks',len(checks),'failures',[c for c in checks if not c['passed']]);assert all(c['passed'] for c in checks)
Path('artifacts/design/detailed/order-state-machine-control-design.md').write_text('''# Order State Machine Control Design

Version: 0.6 | Decision date: 2026-11-03 | Basis: explicit stakeholder selection of the table-driven alternative.

## Selected solution

OrderStateMachine replaces TransitionExecutor, ITransitionExecutor, IStateTransition and the 24 individual transition implementation classes. The earlier model/source is retained only as a dated baseline archive. The class encapsulates a private transition table and implements IOrderStateMachine through backend constructor DI.

- ProcessEventAsync(snapshot, event) resolves the current state, incoming business event and trusted guard facts, selects an unambiguous table row per region, executes its action and follows declared internal completion events.
- CurrentState() returns the managed order state view. Fulfillment, payment, refund and transient UML workflow position remain distinct. Before an aggregate is bound, it returns null.

The logical result represents the reference figure's out-action output through StateMachineResult: Applied, Duplicate, TransitionIds, Actions and State. The action outputs describe effects executed in the caller's transaction, not arbitrary commands that the UI may inject. The table and guard dispatch remain private.

## Table and state semantics

[Transition table](order-state-transition-table.json) and [traceable row mapping](state-transition-class-mapping.csv) preserve all 24 existing transition IDs, sources and targets. IDs identify rows and durable execution evidence; they do not identify implementation classes.

The common acceptOrder event applies I00, routes the private payment-choice pseudostate to exactly one T01u/T01p branch, and initializes the independent payment region. The enabled unpaid path records I00, T01u and P01 in the checkout transaction. Verified paid acceptance and payment capture remain disabled pending persistent payment correlation and provider policy; table representation does not imply completed integration.

cancelOrder selects T08u, T08p or T09 from the locked current fulfillment state and trusted ownership. Its action releases reservations, saves Cancelled and records the customer audit. Internal completion records F_cancelled and finishes fulfillment without adding a database OrderStatus. Payment/refund dimensions remain accessible independently. A completed cancellation request replay returns at the service layer and does not add a self-loop to the state chart.

## Responsibilities and transaction boundary

CheckoutService and MyOrdersService submit events; they do not select transition IDs. The service owns UnitOfWork. OrderStateMachine retains IOrderLifecycleRepository through an association and uses internal DTOs/entities through dependencies. There are no package frames in the detailed class view.

The checkout repository remains the sole persistence site for stock reservation/order lines, after state-machine acceptance, in the same transaction. This avoids reserving stock a second time in the machine. Customer/reference-scoped idempotency claims and the original confirmation commit together with the domain effects and table-row evidence. Notification attempts occur after commit and are not repeated on replay; a durable notification outbox is outside this increment.

## Scope and verification limits

Customer acceptance/cancellation actions and fulfillment completion are implemented. Staff fulfillment, return and refund effects remain deferred, with explicit unsupported-event errors. The private table retains their approved triggers/guards/targets as design data; it does not invent policies for them. Unknown events, ambiguous per-region routing, completion cycles, untrusted snapshots and inconsistent prior evidence fail closed.

The active source has one state-machine control class rather than classes per transition or per state. Web/Mobile refinements, backend-only DI, DTO relationships and Entity dependency conventions are preserved. The revised class and sequence artifacts and the consolidated specification must reference this selection consistently.
''',encoding='utf-8')
p=Path('artifacts/design/detailed/order-state-machine-control-proposal.md');p.write_text('# State Machine Decision\n\nThe stakeholder selected replacement with a table-driven OrderStateMachine. See [the selected design](order-state-machine-control-design.md). The earlier retain/replace question is resolved.\n',encoding='utf-8')
