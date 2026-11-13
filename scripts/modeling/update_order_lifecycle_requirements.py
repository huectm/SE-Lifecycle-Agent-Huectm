from pathlib import Path
import json,csv,io,re
ROOT=Path(__file__).resolve().parents[2];m=json.loads((ROOT/'artifacts/design/order-lifecycle-model.json').read_text());R=m['rules'];F=m['requirements']
srs=ROOT/'artifacts/requirements/software-requirements-specification.md';lines=srs.read_text(encoding='utf-8-sig').splitlines();out=[]
for line in lines:
 rid=next((k for k in R if line.startswith('| **'+k+'** |')),None)
 fid=next((k for k in F if line.startswith('| **'+k+'** |')),None)
 if rid:
  c=line.split('|');c[2]=' '+R[rid]+' ';line='|'.join(c)
 if fid:
  c=line.split('|');c[2]=' '+F[fid]+' ';line='|'.join(c)
 if line.startswith('| **NFR-INT-02**') or 'NFR-INT-02 (Restock Accuracy)' in line:
  line='- **NFR-INT-02 (Stock Update Accuracy):** Valid pre-dispatch cancellations shall release original batch reservations atomically within <=1.0 second of confirmation. For failed deliveries, available stock shall change only after the staff inventory-disposition decision; physical return/inspection time is not a one-second guarantee. The authorized system update shall meet the existing <=1.0-second processing target.'
 out.append(line)
 if line.startswith('| **FR-PAY-02**'):
  for k in ['FR-PAY-03','FR-PAY-04','FR-PAY-05']:out.append(f'| **{k}** | {F[k]} | Stakeholder 2026-10-29; BR-FUL-05/06 | TBD - Wiegers scoring required |')
 if line.startswith('| **FR-DEL-03**'):
  for k in ['FR-DEL-04','FR-DEL-05','FR-DEL-06','FR-DEL-07']:out.append(f'| **{k}** | {F[k]} | Stakeholder 2026-10-29; BR-FUL-04..06 | TBD - Wiegers scoring required |')
 if line.startswith('| **BR-FUL-04**'):
  for k in ['BR-FUL-05','BR-FUL-06']:out.append(f'| **{k}** | {R[k]} | Stakeholder-confirmed policy / unresolved authority noted | Stakeholder 2026-10-29; BP-03 |')
s='\n'.join(out)+'\n'
s=s.replace('**Document Version:** 2.0','**Document Version:** 2.1')
s=s.replace('`Pending Unpaid`, `Pending Paid`, `Confirmed`, `Packing`, `Shipping`, `Delivered`, `Cancelled`, `Delivery Failed`','`Pending` (derived `Pending Unpaid` / `Pending Paid`), `Confirmed`, `Packing`, `Shipping`, `Delivered`, `Cancelled`, `Delivery Failed`, `Returned`')
s=s.replace('`Unpaid`, `Paid`, `Refunded`','`Unpaid`, `Paid`, `Partially Refunded`, `Refunded`')
s=s.replace('(`Pending Unpaid`, `Pending Paid`, `Confirmed`, `Packing`, `Shipping`, `Delivered`, `Cancelled`)','(`Pending Unpaid`, `Pending Paid`, `Confirmed`, `Packing`, `Shipping`, `Delivered`, `Cancelled`, `Delivery Failed`, `Returned`)')
# New data dictionary groups use the existing 5-column structure and conceptual types.
def conceptual(t):
 if any(k in t for k in ['NUMERIC','DECIMAL']):return 'Decimal'
 if 'TIMESTAMP' in t:return 'DateTime'
 if t=='INT' or t=='BIGINT':return 'Identifier / Integer'
 return 'String'
extra=['','### Order Lifecycle Data Requirement Revision','', 'OrderStatus stores the independent initial states Pending Unpaid and Pending Paid. Select exactly one at accepted checkout from verified payment evidence. There is no Pending parent or transition between these states. Shipping-only cash collection does not set goods Paid. First unpaid orders require a successful staff call before approval; unconfirmed calls do not cause automatic cancellation. Data records separate original payment allocations, confirmed cause, physical receipt, staff quality decisions, refund settlement and delivery-agent compensation.','', '| Entity | Attribute | Data Type | Constraints | Description |','|---|---|---|---|---|']
for c in m['order_additions']:extra.append(f"| Order | `{c['name']}` | {conceptual(c['type'])} | {c['constraint'] or 'Optional'} | {c['description']} |")
extra.append('| Order | `OrderStatus` | Enumeration | Stored independent initial state | Independent initial OrderStatus values, selected at accepted checkout |')
for t in m['tables']:
 for c in t['columns']:extra.append(f"| {t['entity']} | `{c['name']}` | {conceptual(c['type'])} | {c['constraint'] or 'Optional'} | {c['description']} |")
extra += ['', '**Unresolved policy:** final cause-decision authority, unclassified/other failures, partial returns/payments, product-fault courier-compensation payer/rate and outgoing refund integration remain TBD. No irreversible financial action is inferred before the applicable cause is confirmed.','']
s+='\n'.join(extra);srs.write_text(s,encoding='utf-8')
p=ROOT/'artifacts/requirements/business-rules.md';ls=[]
for line in p.read_text(encoding='utf-8-sig').splitlines():
 k=next((k for k in R if line.startswith('| **'+k+'** |')),None)
 if k:
  c=line.split('|');c[4]=' '+R[k]+' ';line='|'.join(c)
 ls.append(line)
 if k=='BR-FUL-04':
  for new in ['BR-FUL-05','BR-FUL-06']:ls.append(f'| **{new}** | Failed Delivery Fee / Refund Policy | Constraint | {R[new]} | System with confirmed cause | Stakeholder 2026-10-29; BP-03 |')
p.write_text('\n'.join(ls)+'\n',encoding='utf-8')
p=ROOT/'artifacts/requirements/business-rules.csv';rows=list(csv.DictReader(io.StringIO(p.read_text(encoding='utf-8-sig'))))
for r in rows:
 if r['Rule ID'] in R:r['Rule Description']=R[r['Rule ID']];r['Source Traceability']='Stakeholder 2026-10-29; BP-02/BP-03; existing stable rule ID'
for k in ['BR-FUL-05','BR-FUL-06']:
 r={key:'' for key in rows[0]};r.update({'Rule ID':k,'Rule Name (English)':'Failed Delivery Fee and Refund Policy','Domain':'Order Fulfillment & Delivery','Type':'Constraint','Enforcement Level':'System with confirmed cause','Rule Description':R[k],'Source Traceability':'Stakeholder 2026-10-29; BP-03'});rows.append(r)
with p.open('w',newline='',encoding='utf-8-sig') as f:
 w=csv.DictWriter(f,fieldnames=list(rows[0]),quoting=csv.QUOTE_ALL);w.writeheader();w.writerows(rows)
# Preserve existing UC structure and identifiers; replace only affected flow clauses.
p=ROOT/'artifacts/requirements/customer-use-case-descriptions.md';s=p.read_text(encoding='utf-8-sig').replace('2.0 (Baselined Specification)','2.1 (Requested order-lifecycle revision; affected flows under review)')
s=s.replace('status `Pending` and generates a dynamic VietQR code','fulfillment status `Pending` and goods payment status `Unpaid`, and generates a dynamic VietQR code')
s=s.replace('transitions order payment status to `Paid`','changes independent goods PaymentStatus to `Paid`, showing the derived Pending Paid substate using the paid initial state when payment is verified at accepted checkout')
s=s.replace('(`Pending Unpaid`, `Pending Paid`, `Confirmed`, `Packing`, `Shipping`, `Delivered`, `Cancelled`)','(`Pending Unpaid`, `Pending Paid`, `Confirmed`, `Packing`, `Shipping`, `Delivered`, `Cancelled`, `Delivery Failed`, `Returned`)')
s+='''\n\n## Order Lifecycle Revision Notes - 2026-10-29\n\nUC-C06 accepts only stock-backed orders, reserving all lines atomically. Its initial state is independently Pending Unpaid or Pending Paid according to verified payment at accepted checkout; no transition connects these states. The mandatory first-order call belongs to staff approval (UC-M01.3) and applies only when the first order is still unpaid. Staff may cancel an unconfirmed first unpaid order; no automatic timeout or retry count is specified.\n\nUC-C07 displays independent fulfillment, goods-payment/refund and shipping-fee information. Failed delivery does not mean returned goods received. Complete warehouse receipt enables the full-return path; staff quality inspection/disposition is separate from the customer refund.\n\nFor product fault, the customer owes no delivery fee and a paid order receives its captured goods and delivery fee back. For confirmed deliberate refusal unrelated to product fault, refund paid goods only and retain paid shipping for the delivery agent; if goods were unpaid, the customer owes shipping directly to the delivery agent. Record actual collection and compensation; do not mark goods Paid for shipping-only cash. Final cause authority and unclassified/other cases are TBD; no automated blame classification.\n\nExisting UC identifiers are retained. Detailed receiving/refund goal identifiers and VOPC/sequence revisions require review; no new independent goal is silently assigned to an existing micro-action identifier.\n'''
p.write_text(s,encoding='utf-8')
# Preserve existing scored requirements; add no invented estimates for new candidates.
p=ROOT/'artifacts/requirements/requirements-prioritization.csv';rows=list(csv.DictReader(p.open(encoding='utf-8-sig')))
for r in rows:
 if r['ID'] in F:r['Requirement_Name']=F[r['ID']]
known={r['ID'] for r in rows}
for k,v in F.items():
 if k not in known:
  r={key:'' for key in rows[0]};r.update(ID=k,Requirement_Name=v,Tier='TBD - stakeholder/engineering Wiegers scoring required');rows.append(r)
with p.open('w',newline='',encoding='utf-8') as f:w=csv.DictWriter(f,fieldnames=list(rows[0]));w.writeheader();w.writerows(rows)
print('Updated SRS, rule catalogs, affected use-case clauses, data requirements and unscored new backlog candidates.')
