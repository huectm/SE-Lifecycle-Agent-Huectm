from pathlib import Path
import json,csv,hashlib
D=Path('artifacts/design/detailed');m=json.loads((D/'detailed-class-model.json').read_text(encoding='utf-8'));pages=json.loads((D/'diagram-pages.json').read_text());rules=json.loads((D/'order-state-transition-table.json').read_text());real=json.loads((D/'vopc-realization-mapping.json').read_text());C=m['classes']
def csvwrite(name,rows):
 with (D/name).open('w',encoding='utf-8',newline='') as f:
  w=csv.DictWriter(f,fieldnames=list(rows[0]));w.writeheader();w.writerows(rows)
maprows=[]
for r in real:
 rationale=r['SelectedSolution']
 if r['UseCase'] in ['UC-C06','UC-C07'] and 'OrderStateMachine' in r['DesignClasses']:rationale+='; event-driven table lookup in OrderStateMachine replaces per-transition classes'
 maprows.append({'Analysis Class':r['UseCase']+' / '+r['AnalysisClass'],'Design Class / Component':'; '.join(r['DesignClasses']),'Mapping Rationale':rationale})
csvwrite('analysis-to-design-mapping.csv',maprows)
rows=[{'Transition ID':r['Id'],'Region':r['Region'],'Source':r['Source'],'Event':', '.join(r['Events']),'Guard':r['Guard'],'Action':r['Action'],'Target':r['Target'],'Class':'OrderStateMachine','Contract':'IOrderStateMachine','Basis':r['Basis']} for r in rules]
csvwrite('state-transition-class-mapping.csv',rows)
lines=['# Detailed Design Class Diagrams','','Version: 0.6 | Date: 2026-11-03 | Status: revised under explicit stakeholder selection.','','The table-driven OrderStateMachine replaces the earlier individual transition implementation classes. Its private table represents all 24 existing transitions. Services submit business events through ProcessEventAsync; CurrentState returns the current managed state. There are no per-transition implementation classes or collection registrations in the active model/source.','','The selected implementation keeps backend-only constructor DI, the Web Pages/CallService and Mobile Views/ViewModels/Models refinements, explicit DTO relationships, Entity usage dependencies and interface realizations. Package containers remain excluded. Architecture component names and the five use-case IDs remain unchanged.','','## State-machine control design','','[Control design and decision record](detailed/order-state-machine-control-design.md). The earlier per-transition model and editable sources are archived under baselines/per-transition-20261101. Transition IDs now identify private table rows and durable execution evidence, not implementation classes. UML choice/final nodes do not introduce persistent business statuses.','','## Analysis to design mapping','','| Analysis Class | Design Class / Component | Mapping Rationale |','|---|---|---|']
for r in maprows:lines.append('| '+' | '.join(str(x).replace('|','/') for x in r.values())+' |')
lines+=['','## Editable diagrams and exported images','','| Scope | Page | View | Draw.io master | PNG |','|---|---|---|---|---|']
for p in pages:
 source=p['source'].replace('artifacts/','../',1);image=p['image'].replace('artifacts/','../',1);lines.append(f"| {p['owner']} | {p['page']} | {p['title']} | [Edit]({source}) | [View]({image}) |")
lines+=['','## Class specifications and consistency','','[Class specifications](detailed/class-specifications.md) contain attributes, operation signatures, ownership and relationships for all '+str(len(C))+' classifiers. [DI bindings](detailed/dependency-injection-registrations.csv) register one IOrderStateMachine implementation; the old IStateTransition collection is removed. [Transition table mapping](detailed/state-transition-class-mapping.csv) preserves all 24 source/target/trigger identities.','','[Design sequences](design-sequence-diagrams.md) use the same ProcessEventAsync/CurrentState contracts. The caller owns UnitOfWork; state-machine evaluation, event evidence, domain effects and customer audit commit or roll back together. Customer idempotent replay returns before invoking the state machine.','','Payment correlation/provider and staff/return/refund implementation limitations remain explicit. This pattern replacement does not imply that those integrations or use cases are implemented or released. [Storage amendment](database/order-consistency-storage-design.md) documents idempotency and audit migrations.','','[Current design verification](detailed/state-machine-design-verification.json). Source implementation and test evidence are recorded separately in ../implementation/order-state-machine-review.md.','']
Path('artifacts/design/detailed-design-class-diagrams.md').write_text('\n'.join(lines),encoding='utf-8')
spec=['# Detailed Class Specifications','','Version: 0.6 | 2026-11-03 | Selected solution: table-driven state-machine control.']
for name,c in C.items():
 spec+=['',f'## {name}','','Ownership: '+c['package']+'. Role: '+c['role']+'.','', 'Basis: '+str(c.get('basis','Current approved design responsibility')),'','### Attributes','']+['- '+a for a in c['attributes']]+['','### Operations','']+['- '+o for o in c['operations']]+['','### Relationships','']
 edges={(e['source'],e['kind'],e['target'],e.get('label','')) for p in m['pages'] for e in p['edges'] if e['source']==name or e['target']==name}
 spec+=['- '+a+' --'+kind+'--> '+b+(' ('+label+')' if label else '') for a,kind,b,label in sorted(edges)]
(D/'class-specifications.md').write_text('\n'.join(spec)+'\n',encoding='utf-8')
usage=[]
for p in m['pages']:
 for e in p['edges']:
  target=C[e['target']]
  if target['role'] in ['DTO','entity'] and C[e['source']]['role']!='entity':usage.append({'Owner':p['owner'],'View':p['title'],'Consumer':e['source'],'Data Type':e['target'],'Relation':e['kind']})
csvwrite('dto-entity-dependency-mapping.csv',usage)
print('Wrote current model index, 48 mappings, class specifications and table-row mapping')
