from pathlib import Path
from copy import deepcopy
import json,re
from docx import Document
from docx.text.paragraph import Paragraph
from docx.shared import Cm,Pt
from docx.enum.text import WD_ALIGN_PARAGRAPH as A
from docx.oxml import OxmlElement
from docx.oxml.ns import qn
from PIL import Image
ROOT=Path(__file__).resolve().parents[2];m=json.loads((ROOT/'artifacts/design/order-lifecycle-model.json').read_text());catalog=json.loads((ROOT/'artifacts/design/database/physical-schema-catalog.json').read_text());C={t['name']:t for t in catalog}
changes=[]
def para(doc,text,after,caption=False):
 p=doc.add_paragraph();p.add_run(text);p._p.getparent().remove(p._p);after.addnext(p._p)
 p.paragraph_format.first_line_indent=Cm(0 if caption else .5);p.alignment=A.LEFT if caption else A.JUSTIFY
 p.paragraph_format.space_before=Pt(6 if caption else 3);p.paragraph_format.space_after=Pt(3 if caption else 6)
 p.paragraph_format.keep_with_next=caption
 for r in p.runs:r.font.name='Times New Roman';r.font.size=Pt(10);r.bold=caption
 return p._p

def setcell(c,value,header=False,short=False):
 c.text=str(value)
 for p in c.paragraphs:
  p.alignment=A.CENTER if header or short else A.JUSTIFY;p.paragraph_format.first_line_indent=Cm(0)
  for r in p.runs:r.bold=header or short;r.font.name='Times New Roman';r.font.size=Pt(10)

def add_table(doc,headers,rows,after,widths=None):
 t=doc.add_table(rows=1,cols=len(headers));t.style='Table Grid';t._tbl.getparent().remove(t._tbl);after.addnext(t._tbl)
 for i,h in enumerate(headers):setcell(t.rows[0].cells[i],h,True)
 repeat=OxmlElement('w:tblHeader');t.rows[0]._tr.get_or_add_trPr().append(repeat)
 for vals in rows:
  rr=t.add_row()
  for i,v in enumerate(vals):setcell(rr.cells[i],v)
 if widths:
  t.autofit=False
  for row in t.rows:
   for c,w in zip(row.cells,widths):c.width=Cm(w)
 return t

def picture(doc,path,after):
 p=doc.add_paragraph();p._p.getparent().remove(p._p);after.addnext(p._p);p.alignment=A.CENTER;p.paragraph_format.first_line_indent=Cm(0);p.paragraph_format.keep_with_next=True
 with Image.open(ROOT/path) as im:w,h=im.size
 maxw,maxh=16,21.2;usew=min(maxw,maxh*w/h)
 p.add_run().add_picture(str(ROOT/path),width=Cm(usew));return p._p

def replace_or_add_figures(doc,keywords,paths,titles,chapter,anchor_tokens):
 match=None
 for p in doc.paragraphs:
  if re.match(r'^Figure\s+\d+\.\d+:',p.text) and any(k.lower() in p.text.lower() for k in keywords):match=p;break
 if match:
  previous=match._p.getprevious();found=None
  for _ in range(4):
   if previous is None:break
   if previous.findall('.//'+qn('a:blip')):found=previous;break
   if previous.tag!=qn('w:p'):break
   previous=previous.getprevious()
  if found is not None:
   prev=found.getprevious();found.getparent().remove(found)
  else:prev=match._p.getprevious()
  oldid=re.match(r'Figure\s+(\d+\.\d+):',match.text)[1]
  match._p.getparent().remove(match._p)
 else:
  anchors=[p for p in doc.paragraphs if any(t.lower() in p.text.lower() for t in anchor_tokens) and p.style.name.startswith('Heading')]
  if not anchors:anchors=[p for p in doc.paragraphs if any(t.lower() in p.text.lower() for t in anchor_tokens)]
  if not anchors:return False
  prev=anchors[0]._p;oldid=None
 for i,(path,title) in enumerate(zip(paths,titles)):
  prev=picture(doc,path,prev);label=oldid if i==0 and oldid else f'{chapter}.NEW{len(doc.paragraphs)}'
  prev=para(doc,'Figure '+label+': '+title,prev,True);Paragraph(prev,doc).alignment=A.CENTER
 return True

def find_anchor(doc,terms):
 for p in doc.paragraphs:
  if p.style.name.startswith('Heading') and any(t.lower() in p.text.lower() for t in terms):return p._p
 for p in doc.paragraphs:
  if any(t.lower() in p.text.lower() for t in terms):return p._p
 return doc.paragraphs[-1]._p

def renumber(doc,word,chapter):
 mapping={};number=0
 for p in doc.paragraphs:
  mt=re.match(r'^'+word+r'\s+('+str(chapter)+r'\.(?:\d+|NEW\d+)):',p.text)
  if mt:
   number+=1;mapping[mt[1]]=f'{chapter}.{number}'
 for p in doc.paragraphs:
  s=p.text
  for old,new in mapping.items():s=re.sub(r'\b'+word+r'\s+'+re.escape(old)+r'(?=[:\s.,)]|$)',word+' __REF_'+old.replace('.','_')+'__',s)
  for old,new in mapping.items():s=s.replace('__REF_'+old.replace('.','_')+'__',new)
  if s!=p.text:
   iscap=bool(re.match(r'^(Figure|Table)\s+\d+\.\d+:',s));p.text=s
   if iscap:
    p.paragraph_format.first_line_indent=Cm(0);p.alignment=A.CENTER if word=='Figure' else A.LEFT
    for r in p.runs:r.bold=True

for rel in ['artifacts/Requirements_Analysis_Design_Specification.docx','artifacts/requirements/Software_Requirements_Specification.docx']:
 path=ROOT/rel;doc=Document(path);log={'path':rel,'rules':0,'requirements':0,'schema_tables':0}
 for table in list(doc.tables):
  ids={row.cells[0].text.strip():row for row in table.rows if row.cells}
  for k,value in m['rules'].items():
   if k in ids:setcell(ids[k].cells[1],value);log['rules']+=1
  if 'BR-FUL-04' in ids:
   for k in ['BR-FUL-05','BR-FUL-06']:
    if k not in ids:
     rr=table.add_row();setcell(rr.cells[0],k,short=True);setcell(rr.cells[1],m['rules'][k]);setcell(rr.cells[2],'Stakeholder 2026-10-29' if len(rr.cells)==3 else 'Constraint')
     if len(rr.cells)>3:setcell(rr.cells[3],'Stakeholder 2026-10-29; BP-03')
     log['rules']+=1
  for k,value in m['requirements'].items():
   if k in ids:setcell(ids[k].cells[1],value);log['requirements']+=1
  for anchor,newkeys in [('FR-PAY-02',['FR-PAY-03','FR-PAY-04','FR-PAY-05']),('FR-DEL-03',['FR-DEL-04','FR-DEL-05','FR-DEL-06','FR-DEL-07'])]:
   if anchor in ids:
    for k in newkeys:
     if k not in ids:
      rr=table.add_row();vals=[k,m['requirements'][k],'Stakeholder 2026-10-29; BR-FUL-04..06','TBD - Wiegers scoring required']
      for c,v in zip(rr.cells,vals):setcell(c,v,short=(v==k))
      log['requirements']+=1
  if 'NFR-INT-02' in ids:setcell(ids['NFR-INT-02'].cells[1],'Valid pre-dispatch cancellations release original reservations atomically within <=1.0 second of confirmation. Failed-delivery inventory availability changes only after the staff disposition decision; the authorized system adjustment meets the existing <=1.0-second processing target, not physical transport/inspection time.')
 # Correct scoped terminology / out-of-date paid-order postconditions and overview descriptions.
 for p in doc.paragraphs:
  if '5 discrete stages' in p.text:p.text=p.text.replace('5 discrete stages (Pending, Confirmed, Packing, Shipping, Delivered)','Pending Unpaid and Pending Paid initial states and the Confirmed, Packing, Shipping, Delivered, Cancelled, Delivery Failed and Returned lifecycle')
 # Process narrative uses the existing approved TO-BE section.
 a=find_anchor(doc,['TO-BE Business Processes','TO-BE Process'])
 for text in [
  'Order lifecycle revision 2026-10-29: accept only sellable on-hand stock backed orders, with all FEFO reservations and order lines committed atomically. Pending Unpaid and Pending Paid are independent initial states selected at checkout; the independent goods-payment state persists after staff approval.',
  'Staff telephone confirmation is mandatory only for a first unpaid order. Staff may explicitly cancel an unconfirmed first unpaid order; no automatic retry count/deadline is specified. Paid first orders and repeat orders do not need that mandatory call, but still require store approval.',
  'For product fault the customer owes no shipping fee: refund captured goods and shipping if paid, or collect neither if unpaid. For confirmed deliberate refusal, refund captured goods only and retain shipping, or collect the shipping fee directly through the delivery agent when goods were unpaid. Record actual collection and agent compensation separately.',
  'Complete warehouse receipt is distinct from failed delivery and from staff quality disposition. Eligible refunds do not wait for quality inspection. Final fault-decision authority, partial/other cases, outgoing payout integration and product-fault agent compensation remain TBD; no unsupported automatic financial decision is inferred.'
 ]:a=para(doc,text,a)
 process_figs=[(['BP-02','Online Customer Ordering','Online Ordering'],['artifacts/diagrams/images/bp02-order-acceptance.png'],['BP-02 BPMN stock-backed ordering and payment']),(['BP-03','Order Fulfillment & Delivery'],['artifacts/diagrams/images/bp03-fulfillment-returns.png','artifacts/diagrams/images/bp03-fulfillment-returns-2.png'],['BP-03A BPMN staff approval and dispatch','BP-03B BPMN delivery outcome, receiving and independent inventory/refund branches'])]
 for keys,paths,titles in process_figs:replace_or_add_figures(doc,keys,paths,titles,2,['TO-BE BPMN','TO-BE Process','Business Process'])
 replace_or_add_figures(doc,['Conceptual Entity Class Diagram','Entity Class Diagram'],['artifacts/diagrams/images/entity-class-diagram.png','artifacts/diagrams/images/entity-class-diagram-2.png','artifacts/diagrams/images/entity-class-diagram-3.png'],['Entity class overview with revised order lifecycle','Order payment, phone evidence and delivery-fee entities','Receiving, staff inspection and refund entities'],3,['Data Entities','Data Requirements'])
 # Preserve the existing dictionary's field order; append justified new entity groups in its approved columns.
 dictionaries=[t for t in doc.tables if t.rows and t.rows[0].cells[0].text.strip()=='Name' and len(t.rows[0].cells)==4]
 if dictionaries:
  dt=dictionaries[0]
  for row in dt.rows:
   if len(row.cells)<4:continue
   if row.cells[0].text.strip()=='OrderStatus':setcell(row.cells[3],'Pending Unpaid, Pending Paid, Confirmed, Packing, Shipping, Delivered, Cancelled, Delivery Failed, Returned');setcell(row.cells[2],'30')
   if row.cells[0].text.strip()=='PaymentStatus':setcell(row.cells[3],'Independent goods-payment/settlement: Unpaid, Paid, Partially Refunded, Refunded. Shipping-only collection does not establish Paid.')
 else:
  a=find_anchor(doc,['Data Dictionary','Data Requirements']);dt=add_table(doc,['Name','Data Type','Length','Description'],[],a,[4,2.5,1.5,8])
 groups=[('Order extension',m['order_additions'])]+[(t['entity'],t['columns']) for t in m['tables']]
 for group,cols in groups:
  rr=dt.add_row();merged=rr.cells[0].merge(rr.cells[-1]);setcell(merged,group+' - order lifecycle revision',True)
  for c in cols:
   typ='DateTime' if 'TIMESTAMP' in c['type'] else 'Decimal' if 'NUMERIC' in c['type'] else 'Identifier / Integer' if 'INT' in c['type'] else 'String'
   length=re.search(r'\((\d+)',c['type']);vals=[c['name'],typ,length[1] if length else '-',c['description']+'; '+(c['constraint'] or 'Optional')]
   rr=dt.add_row()
   for cc,v in zip(rr.cells,vals):setcell(cc,v)
 rr=dt.add_row()
 for cc,v in zip(rr.cells,['Order.OrderStatus','Derived state','-','Pending Unpaid / Pending Paid are stored OrderStatus values selected at checkout; no parent Pending and no transition between them.']):setcell(cc,v)
 if rel.startswith('artifacts/Requirements_Analysis_Design'):
  replace_or_add_figures(doc,['Physical Entity-Relationship Diagram','Physical ERD'],['artifacts/diagrams/images/physical-erd.png','artifacts/diagrams/images/physical-erd-2.png','artifacts/diagrams/images/physical-erd-3.png'],['Physical ERD core overview','Physical order/payment/fee schema extension','Physical return/inspection/refund schema extension'],5,['Database Design'])
  # Update the existing orders schema table in place.
  schema_end=None
  for p in doc.paragraphs:
   if re.match(r'^Table\s+5\.\d+:.*Physical Schema Specification for ',p.text):
    table_name=p.text.split(' for ',1)[1].strip();n=p._p.getnext()
    while n is not None and n.tag!=qn('w:tbl'):n=n.getnext()
    if n is not None:schema_end=n
    if table_name=='orders' and n is not None:
     from docx.table import Table
     t=Table(n,doc)
     for row in list(t.rows)[1:]:t._tbl.remove(row._tr)
     for c in C['orders']['columns']:
      row=t.add_row()
      for cc,v in zip(row.cells,[c['name'],c['type'],c['constraint'],c['description']]):setcell(cc,v)
     log['schema_tables']+=1
  a=schema_end if schema_end is not None else find_anchor(doc,['Database Design'])
  for t in m['tables']:
   a=para(doc,f"Table 5.NEW{len(doc.paragraphs)}: Physical Schema Specification for {t['name']}",a,True)
   tbl=add_table(doc,['Column Name','Physical Type','Integrity Constraints','Business Description'],[[c['name'],c['type'],c['constraint'] or 'NULL',c['description']] for c in t['columns']],a,[4,3,4,5]);a=tbl._tbl;log['schema_tables']+=1
  for text in [
   'Database revision for review: PostgreSQL design now includes eight lifecycle tables (24 total core/extension tables), independent payment allocations, final fault evidence, line-matched complete receipts, staff quality dispositions, refund obligations and agent compensation. See artifacts/design/database/order-lifecycle-extension.sql; this is not a deployed migration.',
   'Use row-locked stock acceptance and all-or-nothing reservation; serialize first-order classification. Phone approval, complete receiving, original-line ownership and duplicate refund obligations have explicit database guards. Outgoing payouts, final role authorization and multi-session stock races are not proven by the isolated SQL checks.',
   'Schema review/migration prerequisites: inspect existing enum/check names and legacy data; do not guess ambiguous historical Processing, payment, fault or receipt values. Financial records must retain their evidence and must not be deleted by cascade. Initial Pending Unpaid/Paid states are stored explicitly; original amount allocations and received goods remain separately traceable.',
   'Outstanding policies remain explicit: final cause authority, other/unclassified failures, partial/late/overpaid cases, product-fault courier compensation and payout/retry integration. New diagrams and schema choices are reviewable revisions under the existing database gate, not automatically approved production artifacts.'
  ]:a=para(doc,text,a)
 for chapter in [2,3,5]:renumber(doc,'Figure',chapter);renumber(doc,'Table',chapter)
 doc.settings.element.append(OxmlElement('w:updateFields'));doc.settings.element[-1].set(qn('w:val'),'true')
 doc.save(path);changes.append(log)
(ROOT/'artifacts/analysis/order-lifecycle-document-sync.json').write_text(json.dumps(changes,indent=2),encoding='utf-8');print(json.dumps(changes,indent=2))
