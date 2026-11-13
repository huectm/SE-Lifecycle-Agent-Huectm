# Order Payment, Confirmation and Failed-Delivery Return Review

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
