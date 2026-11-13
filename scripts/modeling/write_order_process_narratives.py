from pathlib import Path
ROOT=Path(__file__).resolve().parents[2]
(ROOT/'artifacts/requirements/business-processes.md').write_text('''# Business Process Analysis - Order Lifecycle Revision

Version: 2.0 | Date: 2026-10-29 | Status: Requested revision for process review.

## AS-IS Business Processes

The existing SRS AS-IS assessment remains unchanged. This revision changes the TO-BE ordering, approval, unsuccessful delivery, receiving and financial handling based on stakeholder decisions; it does not invent new AS-IS observations.

## TO-BE Business Processes

### BP-02: Stock-Backed Online Ordering and Payment

Trigger: customer submits an order. Responsible process participant: FreshFood System; customer and payment gateway supply the inputs. Validate existing checkout constraints and all requested sellable on-hand quantities. Lock eligible FEFO batches and subtract current reservations. If any line is short, reject the whole submission and roll back all effects. Otherwise select the initial state at accepted checkout: Pending Unpaid if payment has not been verified, or Pending Paid if payment has been verified. Commit the selected state, order lines, payment allocations where applicable and all reservations atomically; clear the cart. Do not create Pending Unpaid and subsequently change it to Pending Paid. Payment remains an independent financial state after staff approval and dispatch. No waiting-for-replenishment order is accepted. Completion: accepted pending order enters the staff queue; no automatic approval is inferred from payment.

### BP-03A: Staff Approval and Dispatch

Store Staff recheck the current order/payment evidence. A telephone confirmation is mandatory only when this is the first order and goods remain unpaid. On successful confirmation staff may approve. If confirmation cannot be obtained, staff explicitly choose cancellation or leave it Pending; no automatic retry count, timeout or cancellation is introduced. Paid first orders and repeat unpaid orders are exempt from the mandatory call, but still require staff approval. Cancellation releases original reservations once. Confirmed -> Packing -> Shipping requires completed packing, mandatory documents and an assigned delivery agent.

### BP-03B: Delivery Outcome, Physical Return and Independent Financial/Inventory Work

Successful delivery records Delivered and the existing stock/revenue effects. Failure records Delivery Failed, observed reason and evidence; absence of contact is not proof of deliberate refusal. Warehouse Staff record received quantities against original order lines. Only complete physical receipt allows Returned and the full-return automatic-refund path. Incomplete facts remain draft and require a separate partial-return policy.

Receiving creates two independent branches: (1) staff inspect physical quality and decide permitted inventory handling; (2) the system determines financial obligations from goods-payment evidence and the confirmed delivery-failure cause. Customer refunds do not wait for warehouse quality inspection. Quality is not automatically inferred and the customer had not accepted the failed delivery. No stock is automatically made sellable on receiving.

| Confirmed failure cause | Goods paid | Goods unpaid |
|---|---|---|
| Product fault | Refund actual captured goods and delivery fee; customer bears no shipping charge | Collect neither goods nor shipping charge |
| Deliberate customer refusal unrelated to product fault | Refund actual captured goods only; retain paid shipping for delivery-agent compensation | Customer owes shipping directly to the delivery agent; record actual collection/compensation; goods remain unpaid |

Final cause-confirmation authority remains **TBD - Stakeholder confirmation required**. A warehouse quality decision is not silently equated with that financial fault decision. Until cause is confirmed under an approved authority, keep liability unresolved and do not guess the payout. For confirmed paid full returns create an idempotent automatic-refund request; only verified settlement establishes completed partial/full reimbursement. A retained shipping fee is not proof the delivery agent was paid. For product fault, who funds the agent and the compensation rate remain TBD; the customer's zero liability must not be changed to fill that gap. Outgoing refund provider/API remains TBD.

## TO-BE BPMN Models

The BPMN masters are authoritative process views for this revision; corresponding UML Activity views are updated from the same process definition, not substituted for BPMN notation.

| Process | Editable BPMN | PNG | Related UML Activity master |
|---|---|---|---|
| BP-02 ordering/payment | [BPMN](../diagrams/business-process/bp02-order-acceptance.drawio) | [PNG](../diagrams/images/bp02-order-acceptance.png) | [Activity](../diagrams/activity/bp02-online-ordering-activity-diagram.drawio) |
| BP-03A approval/dispatch | [BPMN page 1](../diagrams/business-process/bp03-fulfillment-returns.drawio) | [PNG](../diagrams/images/bp03-fulfillment-returns.png) | [Activity page 1](../diagrams/activity/bp03-order-fulfillment-activity-diagram.drawio) |
| BP-03B failure/receiving/finance | [BPMN page 2](../diagrams/business-process/bp03-fulfillment-returns.drawio) | [PNG](../diagrams/images/bp03-fulfillment-returns-2.png) | [Activity page 2](../diagrams/activity/bp03-order-fulfillment-activity-diagram.drawio) |

Sources: stakeholder instructions 2026-10-29; BR-ORD-01/03/04/05, BR-FUL-01..06; FR-ORD-03, FR-FUL-02, FR-DEL-03..07, FR-PAY-03..05. Business identifiers are preserved. Proposed database enums and new receiving/refund goal identifiers require their normal review gates; no new use-case diagram relationship is silently baselined.
''',encoding='utf-8')
(ROOT/'artifacts/requirements/reviews/order-payment-return-use-case-review.md').write_text('''# Order Payment, Confirmation and Failed-Delivery Return Review

Version: 2.0 | Date: 2026-10-29 | Status: Requested cross-artifact revision for review.

## Current stakeholder-confirmed decisions

Orders are accepted only against sufficient sellable on-hand stock, atomically reserved for all lines. Pending Unpaid and Pending Paid are independent initial order states, selected at accepted checkout using mutually exclusive verified-payment guards. There is no parent Pending state or transition between these two states. The mandatory phone call applies only to a first unpaid order. Staff may cancel an unconfirmed first unpaid order with a reason; an unsuccessful call does not automatically cancel it. Customer cancellation remains limited to Pending Unpaid/Pending Paid/Confirmed, not Packing/Shipping.

Delivery Failed does not prove the goods returned. Warehouse Staff confirm all physically returned quantities before Returned. Staff physically inspect quality and decide inventory disposition; the system records the decision, without assuming customer-caused damage or making food sellable automatically. This inspection does not delay the eligible customer refund.

## Confirmed fee and refund matrix

| Failure cause | Goods paid | Goods unpaid |
|---|---|---|
| Product fault | Automatically refund actual collected goods and shipping amounts after complete physical receipt and confirmed cause | No customer goods or shipping charge |
| Confirmed deliberate refusal unrelated to product fault | Automatically refund actual collected goods only; retain paid shipping for the delivery agent | Customer owes shipping directly to delivery agent; record actual collection, with goods still Unpaid |

This matrix supersedes the earlier unconditional goods-only/retain-shipping draft. Refund request submission is not completed settlement. A completed goods-only refund normally yields Partially Refunded because shipping is retained; refunding the original captured goods and shipping normally yields Refunded. These are independent from fulfillment, which remains Returned.

## Affected use-case clauses

### UC-C06: Checkout & Place Order

| Specification Field | Content Description |
|---|---|
| **Use Case ID & Name** | UC-C06: Checkout & Place Order; identifier retained. |
| **Primary Actor** | Customer. |
| **Secondary Actors** | Existing Google Maps, SePay and notification parties; no outgoing refund integration assumed. |
| **Description** | Place a stock-backed order with immediate or deferred payment; track goods payment independently of fulfillment. |
| **Preconditions** | Existing authenticated customer and checkout constraints; every item has sufficient sellable on-hand stock at atomic submission. |
| **Postconditions** | All lines and reservations commit together or none do. Order is Pending Unpaid or Pending Paid according to verified capture evidence; financial information persists after leaving Pending. |
| **Normal Flow of Events** | Retain address, distance, fee and FEFO logic. Revalidate all lines under lock, commit Pending/Unpaid order and reservations, clear cart and notify staff queue. Customer may defer payment. |
| **Alternative Flows** | Verified immediate VietQR payment records original goods/shipping allocations and Pending Paid. Staff's first-unpaid-order phone confirmation belongs to UC-M01.3, not a new customer micro-action UC. |
| **Exception Flows** | Shortage rejects the entire order. Existing invalid checkout and payment mismatches remain. Late/partial payments and overpayment allocation remain TBD; no callback is treated as a delivery result. |
| **Business Rules** | BR-ORD-01/03; BR-FUL-01; existing distance/pricing/FEFO rules. |

### UC-C07: Manage My Orders

| Specification Field | Content Description |
|---|---|
| **Use Case ID & Name** | UC-C07: Manage My Orders; identifier retained. |
| **Primary Actor** | Customer. |
| **Secondary Actors** | None newly assigned. |
| **Description** | Track fulfillment, payment/refund and shipping-fee outcomes independently. |
| **Preconditions** | Existing authentication and ownership rules. |
| **Postconditions** | Views show correct current states and actual receiving/refund evidence, without false completed settlement. |
| **Normal Flow of Events** | Show Pending Unpaid/Paid, Confirmed, Packing, Shipping, Delivered, Cancelled, Delivery Failed and Returned; show financial amounts/status independently. |
| **Alternative Flows** | Existing customer cancellation only in Pending Unpaid/Pending Paid/Confirmed. Existing re-order and review behavior remains: reviews only for Delivered; re-order does not reset the old order. |
| **Exception Flows** | Packing/Shipping cancellation remains blocked. Unclassified failure cannot be represented as deliberate refusal; partial receiving does not falsely complete a return or automatic refund. |
| **Business Rules** | BR-ORD-04/05, BR-FUL-04..06, BR-FB-01 and BR-RE-01. |

### UC-M01.3 and UC-M03.3 staff-flow amendments

UC-M01.3: mandatory telephone confirmation only if first order AND goods Unpaid; store staff record result and may explicitly cancel an unconfirmed order. Paid status does not automatically approve the order. UC-M03.3: record failure and evidence, then separate complete warehouse receipt, staff disposition, customer liability and refund settlement. Existing identifiers retain their actor goals.

Distinct goals for warehouse receiving and automated eligible refunds remain proposed additions to the use-case review list; stable new identifiers and diagram relationships require review rather than silently reusing an existing identifier for a different goal.

## Unresolved policy boundaries

Final financial cause-decision authority; unclassified/other failures; partial physical returns, partial/late/overpaid payments; prepaid cancellation refunds; actual outgoing payout provider; reconciliation/retry rules; and the product-fault delivery-agent compensation payer/rate remain TBD. Data structures can record facts and evidence while these automatic decisions remain blocked. Staff quality/disposition authority does not by itself assign fault-confirmation authority.

## Synchronized artifacts and review gate

The requested update spans SRS/rule catalogs and use-case clauses, BP-02/BP-03 process sources and images, entity class model/data dictionary, PostgreSQL physical ERD/catalog/design delta and traceability. See `../../design/database-design.md` and `../business-processes.md`. Database checks are isolated design validation; no live database or payment provider is changed. New engineering schema/enum choices and diagrams are reviewable revisions, not automatically approved production baselines.
''',encoding='utf-8')
print('Saved current process narratives and consolidated review; superseded unconditional shipping-retention policy removed.')
