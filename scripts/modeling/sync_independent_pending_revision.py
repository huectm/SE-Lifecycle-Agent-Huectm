from pathlib import Path
import json,hashlib,csv
from docx import Document
from docx.shared import Cm
from PIL import Image
R=Path.cwd();B=R/'scratch/pending-independent-before';m=json.loads((R/'artifacts/design/order-lifecycle-model.json').read_text())
rep={
'Pending Unpaid/Paid are derived substates':'Pending Unpaid and Pending Paid are independent initial states selected by verified payment at accepted checkout',
'Pending Unpaid/Paid substates':'Pending Unpaid and Pending Paid initial states',
'Pending (derived Unpaid/Paid substates)':'Pending Unpaid, Pending Paid',
'Pending substates are a derived view':'Pending Unpaid and Pending Paid are stored initial OrderStatus values; no cross-state transition is permitted',
'Pending Unpaid / Pending Paid; derived from fulfillment and goods-payment evidence, not a separate mutable lifecycle column.':'Pending Unpaid / Pending Paid are independent stored initial OrderStatus values, selected at accepted checkout. There is no parent Pending or transition between them.',
'Pending Unpaid and Pending Paid as substates of Pending':'Pending Unpaid and Pending Paid as independent initial order states',
'derive goods-payment and pending-substate information independently of fulfillment':'track goods-payment independently of fulfillment and select the initial Pending Unpaid/Paid state from verified payment at checkout',
'Pending/Confirmed':'Pending Unpaid/Pending Paid/Confirmed',
'only Pending or Confirmed orders':'only Pending Unpaid, Pending Paid or Confirmed orders',
'Pending, Confirmed, Packing, Shipping, Delivered, Cancelled, Delivery Failed, Returned':'Pending Unpaid, Pending Paid, Confirmed, Packing, Shipping, Delivered, Cancelled, Delivery Failed, Returned',
'Order.pendingSubstate':'Order.OrderStatus',
}
image_map={}
for p in (B/'artifacts/diagrams').rglob('*.png'):
 current=R/p.relative_to(B)
 if current.exists() and p.read_bytes()!=current.read_bytes():image_map[hashlib.sha256(p.read_bytes()).hexdigest()]=current
logs=[]
for rel in ['artifacts/Requirements_Analysis_Design_Specification.docx','artifacts/requirements/Software_Requirements_Specification.docx']:
 d=Document(R/rel);ps=list(d.paragraphs)
 for t in d.tables:
  for row in t.rows:
   for c in row.cells:ps.extend(c.paragraphs)
 seen=set();changed=0
 for p in ps:
  el=p._p
  if el in seen:continue
  seen.add(el);s=p.text;n=s
  for a,b in rep.items():n=n.replace(a,b)
  if s.strip()=="NOT NULL, DEFAULT 'PENDING'":n="NOT NULL, DEFAULT 'PENDING_UNPAID'"
  # Enum value cells; refund-status enum is deliberately unchanged.
  if n.startswith('PENDING`, `CONFIRMED`') or n.startswith('`PENDING`, `CONFIRMED`'):n=n.replace('PENDING','PENDING_UNPAID`, `PENDING_PAID',1)
  if n!=s:
   if p.runs:
    p.runs[0].text=n
    for r in p.runs[1:]:r.text=''
   else:p.add_run(n)
   changed+=1
 for t in d.tables:
  for row in t.rows:
   if len(row.cells)>1:
    id=row.cells[0].text.strip().strip('*')
    if id in m['requirements']:row.cells[1].text=m['requirements'][id]
    if id=='OrderStatus':row.cells[-1].text='Pending Unpaid, Pending Paid, Confirmed, Packing, Shipping, Delivered, Cancelled, Delivery Failed, Returned. Initial choice uses verified checkout payment; no parent Pending and no cross-pending transition.'
 replacements=0
 for part in list(d.part.package.parts):
  if part.content_type.startswith('image/'):
   p=image_map.get(hashlib.sha256(part.blob).hexdigest())
   if p:part._blob=p.read_bytes();replacements+=1
 # Preserve image proportions after replacement.
 for inline in d.inline_shapes:
  blips=inline._inline.xpath('.//a:blip')
  if not blips:continue
  from docx.oxml.ns import qn
  rid=blips[0].get(qn('r:embed'))
  if rid in d.part.related_parts:
   part=d.part.related_parts[rid]
   for p in image_map.values():
    if part.blob==p.read_bytes():
     w,h=Image.open(p).size;inline.height=int(inline.width*h/w);break
 # Existing chapter-IV narrative: insert explicit correction under its existing heading.
 for i,p in enumerate(d.paragraphs):
  if p.text.strip()=='State Machine Diagrams':
   note='Stakeholder correction 2026-10-29: Pending Unpaid and Pending Paid are independent initial OrderStatus values. The initial choice uses mutually exclusive guards: not paid at accepted checkout / verified paid at accepted checkout. No parent Pending state or Pending Unpaid to Pending Paid transition exists. Both states require staff approval. Later-payment fulfillment handling remains TBD.'
   after=d.paragraphs[i+1]
   after.text=note;after.paragraph_format.first_line_indent=Cm(.5)
   break
 d.save(R/rel);logs.append({'document':rel,'text_replacements':changed,'replaced_images':replacements})
(R/'artifacts/analysis/pending-initial-state-revision.json').write_text(json.dumps({'decision':'Two independent initial states, no parent or transition between them','documents':logs,'database_checks':20,'later_payment_policy':'TBD - Stakeholder confirmation required.'},indent=2))
print(logs)
# Refresh transition table from authoritative diagram source.
p=R/'artifacts/analysis/order-state-analysis.md';s=p.read_text();a=s.index('| ID | Diagram page');b=s.index('## Artifacts and limits',a)
rows=list(csv.DictReader((R/'artifacts/analysis/order-state-traceability.csv').open(encoding='utf-8-sig')))
t='| ID | Diagram page | Source → target | Trigger / guard |\n|---|---|---|---|\n'
for r in rows:t+='| '+' | '.join([r['id'],r['page'],r['source']+' → '+r['target'],r['label'].replace('\n','; ') or r['basis']])+' |\n'
p.write_text(s[:a]+t+'\n'+s[b:],encoding='utf-8')
