from pathlib import Path
import json,re
ROOT=Path(__file__).resolve().parents[2];m=json.loads((ROOT/'artifacts/design/order-lifecycle-model.json').read_text());p=ROOT/'artifacts/design/database-design.md';s=p.read_text(encoding='utf-8-sig')
s=s.replace('**Document Version:** 1.0','**Document Version:** 2.0 - Requested order-lifecycle revision for review')
s=s.replace('maps all 16 conceptual domain entities','maps the existing conceptual domain and the order-lifecycle extensions').replace('displays 16 tables organized into 4 logical clusters','displays the 16 existing core tables plus 8 new lifecycle tables across focused pages')
s=s.replace('`COD`, `VNPAY`, `MOMO`, `BANK_TRANSFER`','`COD`, `VIETQR`').replace('`UNPAID`, `PAID`, `REFUNDED`','`UNPAID`, `PAID`, `PARTIALLY_REFUNDED`, `REFUNDED`').replace('`PENDING`, `CONFIRMED`, `PACKING`, `SHIPPING`, `COMPLETED`, `CANCELLED`','`PENDING`, `CONFIRMED`, `PACKING`, `SHIPPING`, `DELIVERED`, `CANCELLED`, `DELIVERY_FAILED`, `RETURNED`').replace('Flag for first-order welcome gift promotion','Snapshot of whether this is the first order; mandatory phone confirmation only while goods payment is unpaid')
needle='| `is_first_order` |'
lines=s.splitlines();out=[]
for line in lines:
 out.append(line)
 if line.startswith(needle):
  for c in m['order_additions']:out.append(f"| `{c['name']}` | `{c['type']}` | {c['constraint'] or 'NULL'} | {c['description']} |")
s='\n'.join(out)+'\n'
addition=['### 3.5 Order Payment, Return and Delivery-Fee Records','', 'The new records support the confirmed stakeholder policies; surrogate keys and idempotency references are justified technical integrity choices. They do not assign unresolved cause-decision authority or invent a payout integration.','']
for i,t in enumerate(m['tables'],17):
 addition += [f"#### Table 5.{i}: `{t['name']}`",t['basis'],'','| Column Name | Physical Data Type | Constraints | Description |','|---|---|---|---|']
 for c in t['columns']:addition.append(f"| `{c['name']}` | `{c['type']}` | {c['constraint'] or 'NULL'} | {c['description']} |")
 addition += ['','Additional checks: '+('; '.join(t['checks']) or 'See relationship constraints in the design SQL.'),'']
s=s.replace('## 4. Physical Indexing Strategy for High Performance','\n'.join(addition)+'\n## 4. Physical Indexing Strategy for High Performance')
s+='''

## 5. Order Transaction and Financial Integrity Protocols

The review-only PostgreSQL design delta is `database/order-lifecycle-extension.sql`. It assumes the modeled base tables and does not constitute an approved production migration. Existing constraints and legacy rows must be inspected first. Do not deploy it automatically.

### 5.1 Stock-backed acceptance and independent initial pending states

OrderStatus stores PENDING_UNPAID or PENDING_PAID as separate initial values. The order_pending_states view projects the stored value and never converts it from PaymentStatus. No PENDING parent or cross-pending-state transition is permitted. PaymentStatus remains available after confirmation, packing and dispatch. Shipping-only cash receipts do not meet the evidence needed for PAID.

Atomic acceptance: group requested quantities; lock eligible batch rows in a deterministic FEFO order with SELECT FOR UPDATE; recompute current_stock minus reserved_stock; validate all requested products before committing any order; update reservations; create Pending/Unpaid order and immutable original order lines; clear the cart; commit. Roll back all effects if any line is short. A previously rendered product/cart screen is not a reservation. Stock/perishability rules still exclude inactive/expired batches. First-order determination must be serialized with customer order creation so concurrent submissions cannot both bypass or falsely claim the first-order rule; its historical-count scope remains the existing requirement.

Before approving an unpaid first order, require a successful staff phone result and evidence. If contact is unconfirmed, staff may explicitly cancel, recording the reason and releasing original reservations exactly once. No call count or cancellation timeout is invented. Paid first orders and repeat orders are exempt from this mandatory call, not automatically approved.

### 5.2 Cause, receipt, inspection and refunds

1. Record delivery failure and evidence. Final cause confirmation is a separate authorization decision; the responsible role remains TBD. UNCLASSIFIED/OTHER is not automatically deliberate refusal.
2. Record a DRAFT return receipt and original line quantities. Confirm COMPLETE only when every original line is fully accounted for. In one transaction lock the order/receipt, confirm receiving, move fulfillment to RETURNED and evaluate the financial obligation. Partial receiving facts are retained but do not qualify for the full-return automatic path.
3. Product fault: customer delivery-fee liability is zero; refund actual captured goods and shipping allocations. Confirmed deliberate refusal: refund captured goods only, retain the captured delivery fee, or collect the shipping fee directly from the customer if goods were unpaid. Shipping-only collection is a separate ledger allocation.
4. Once goods payment, complete receipt and the applicable confirmed cause are available, `queue_failed_delivery_refund` creates one idempotent refund obligation; it does not perform an external transfer. No warehouse inspection record is required for the customer refund. Re-evaluation belongs to the application event handler for completed receipt/cause confirmation, subject to the unresolved late-payment policy.
5. Staff inspect goods and decide RESTOCK/HOLD/DISPOSE under existing warehouse rules. Lock the receipt item and affected batch when validating cumulative disposition quantities. Receipt alone never exposes goods as available. As stock was reserved, not permanently deducted until successful delivery, a good return generally releases the matching reservation rather than increasing current_stock twice. Unsellable goods require the authorized disposal/adjustment flow; the system does not infer quality automatically.
6. Preserve captured, refunded, retained, due and actually collected amounts. Mark PARTIALLY_REFUNDED only when a confirmed completed refund is less than the original captured amount, and REFUNDED only when the approved full amount has settled. PENDING/PROCESSING/FAILED/UNKNOWN refund requests do not prove completed payout. Lock original payment/refund records and verify cumulative refunds never exceed captured allocations. Direct database writes must not bypass application authorization, settlement verification or this cumulative check.

### 5.3 Shipping-fee compensation

`shipping_fee_settlements` records a liability snapshot and actual compensation, referencing the delivery agent and any direct cash payment evidence. For deliberate refusal the customer owes the original shipping charge; direct agent cash can satisfy that obligation and compensate the agent, but it is not presumed collected until recorded. For prepaid refusal retained fees fund the agent compensation, but retained customer cash is not itself proof the agent was paid. For product fault the customer owes zero. Who funds and how much compensation the agent receives in the product-fault case is TBD, not silently zero or automatically charged to the customer.

### 5.4 Cross-row constraints and normalization

Composite foreign keys ensure return lines belong to the original order; per-order unique obligations and provider/channel references prevent duplicates. Complete-return and phone/payment guards use triggers. Refund amount calculation locks the order. The database does not use a CHECK that queries other rows. Cumulative inspection quantities, authorization, event immutability, cause freezing after financial processing, provider settlement evidence and multi-session transaction orchestration also require the authorized application service and audit trail.

## 6. Migration, Review and Validation

- Review the new physical names and existing row types before deployment. The design uses PostgreSQL 16+; SRS conceptual identifiers/DateTime do not prescribe SQL Server INT/DATETIME2.
- Inventory the actual existing CHECK/FK/index names. Old constraints allowing COMPLETED but not DELIVERED/RETURNED must be replaced in a reviewed migration. Map legacy COMPLETED to DELIVERED only with verified source semantics; do not auto-map ambiguous historical Processing states, payment gateways or unresolved fault reasons.
- Existing records need evidence-based phone/payment/return backfill. Do not fabricate received-at dates, confirmation staff, cash receipts or fault confirmations. Legacy ambiguous rows remain for reconciliation.
- Financial evidence is retained; do not cascade-delete completed payments, returns or refunds. Follow existing security/retention policy, restricted service access and audit logging. Do not add payment credentials to schema files.
- Isolated validation uses local in-memory PGlite (PostgreSQL 17.4-compatible engine). It exercises design SQL and invariants, not a PostgreSQL 16 deployment, outgoing payout, final authorization policy or multi-session stock race. See `artifacts/analysis/order-lifecycle-db-verification.json`.
- The new schema is a reviewable requested revision. Outstanding: final cause-decision authority, outgoing refund provider, partial returns/payments, other/unreachable-customer cases, retries and product-fault courier compensation. These do not block storing facts; they block unsupported automatic financial decisions.

References: [PostgreSQL constraint documentation](https://www.postgresql.org/docs/16/ddl-constraints.html), [PGlite documentation](https://pglite.dev/docs/).
'''
p.write_text(s,encoding='utf-8')
# Export physical catalog directly from the retained approved table structure.
catalog=[]
for match in re.finditer(r'#### Table 5\.(\d+): `([^`]+)`\n(.*?)(?=\n#### |\n### |\n## |\Z)',s,re.S):
 cols=[]
 for line in match.group(3).splitlines():
  if line.startswith('| `'):
   c=[v.strip().strip('`') for v in line.strip('|').split('|')]
   if len(c)==4:cols.append(dict(name=c[0],type=c[1],constraint=c[2],description=c[3]))
 catalog.append(dict(name=match.group(2),columns=cols))
(ROOT/'artifacts/design/database/physical-schema-catalog.json').write_text(json.dumps(catalog,indent=2),encoding='utf-8')
print('Updated physical dictionary with',len(catalog),'tables and documented transaction/migration boundaries.')
