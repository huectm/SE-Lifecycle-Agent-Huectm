# Order State Machine Analysis

Version: 2.0 | Date: 2026-10-29 | Status: Updated for analysis review.

## Basis and state dimensions

The approved stakeholder decisions are recorded in [the use-case review](../requirements/reviews/order-payment-return-use-case-review.md). Requirements, process, entity and database revisions are synchronized in the master specification. Revised diagrams and technical schema remain subject to review; no production migration or payout was executed.

Fulfillment categories are Pending Unpaid, Pending Paid, Confirmed, Packing, Shipping, Delivered, Cancelled, Delivery Failed and Returned. Pending Unpaid and Pending Paid are independent initial order states. Select one at checkout according to verified payment; neither is a substate, and no transition connects them. Payment remains independent during later fulfillment: Unpaid, Paid, Partially Refunded or Refunded. A shipping-only cash receipt never marks goods Paid.

Checkout atomically validates and reserves available on-hand FEFO quantities. A first order that remains unpaid requires staff telephone confirmation before approval. Other orders still require staff approval. An unsuccessful call does not automatically cancel an order: staff may explicitly cancel or leave it pending. Customer cancellation remains limited to Pending Unpaid/Pending Paid/Confirmed.

Delivery Failed records the unsuccessful delivery. Returned requires warehouse confirmation of every original line quantity. Staff inspect quality and decide inventory disposition separately; physical receipt never implies automatic resale.

## Financial behavior

A confirmed product fault waives customer shipping charges. For a prepaid order, refund captured goods and shipping; for an unpaid order, collect neither. Confirmed deliberate refusal unrelated to product fault retains prepaid shipping and refunds captured goods only. For an unpaid deliberate refusal, the customer owes shipping directly to the delivery agent. Record actual collection and actual compensation separately.

Automatic refund eligibility requires verified goods collection, complete warehouse receipt and a confirmed applicable cause. Quality inspection is not a refund guard. Overpayment and unclassified causes remain unresolved and do not trigger an inferred payout. A queued request does not mean settlement succeeded. Only verified settlement updates refunded amounts and payment state; prevent duplicate obligations and blind retries.

## Traceable transitions

| ID | Diagram page | Source → target | Trigger / guard |
|---|---|---|---|
| I00 | Order Fulfillment | initial → payment_choice | acceptOrder / reserve stock atomically |
| T01u | Order Fulfillment | payment_choice → pending_unpaid | [not paid at checkout] |
| T01p | Order Fulfillment | payment_choice → pending_paid | [verified paid at checkout] |
| T02u | Order Fulfillment | pending_unpaid → confirmed | approveOrder; [not first order OR phone confirmed] |
| T02p | Order Fulfillment | pending_paid → confirmed | approveOrder; [staff approval] |
| T03 | Order Fulfillment | confirmed → packing | startPacking |
| T04 | Order Fulfillment | packing → shipping | dispatchOrder; [documents and assigned agent] |
| T05 | Order Fulfillment | shipping → delivered | deliverySuccess |
| T06 | Order Fulfillment | shipping → delivery_failed | deliveryFailure; [reason recorded] |
| T07 | Order Fulfillment | delivery_failed → returned | confirmReturnReceipt; [all goods received] |
| T08u | Order Fulfillment | pending_unpaid → cancelled | cancelOrder; [customer OR staff cancels; unconfirmed first unpaid order] |
| T08p | Order Fulfillment | pending_paid → cancelled | cancelOrder [customer confirms] |
| T09 | Order Fulfillment | confirmed → cancelled | cancelOrder [customer confirms] |
| F_delivered | Order Fulfillment | delivered → final_delivered | Completion transition |
| F_returned | Order Fulfillment | returned → final_returned | Completion transition |
| F_cancelled | Order Fulfillment | cancelled → final_cancelled | Completion transition |
| R01 | Automatic Goods Refund | refund_initial → awaiting | observe refund candidate |
| R02 | Automatic Goods Refund | awaiting → processing | receiptAndCauseConfirmed; [paid goods AND complete return; AND cause confirmed; no duplicate]; / refund original allocations by policy |
| R03 | Automatic Goods Refund | processing → completed | refundSettlementConfirmed; / record actual completed refund |
| R04 | Automatic Goods Refund | processing → unresolved | refundRejected OR; settlementUncertain; / do not mark refund completed |
| P01 | Payment Settlement | pay_initial → unpaid | createOrder |
| P02 | Payment Settlement | unpaid → paid | verifiedSePayNotification; [order matches AND amount >= total]; / record captured payment |
| P03 | Payment Settlement | paid → partially_refunded | refundSettlementConfirmed; [0 < cumulative refund < captured]; / record retained fee and goods refund |
| P04 | Payment Settlement | paid → refunded | refundSettlementConfirmed; [cumulative refund = captured]; / record full refunded amount |

## Artifacts and limits

- [Editable state machine](../diagrams/state-machine/order-state-machine.drawio): three pages; 24 traceable transitions.
- [Traceability](order-state-traceability.csv) and [verification](order-state-verification.json).
- [Database verification](order-lifecycle-db-verification.json): local embedded PostgreSQL checks; no provider payout or multi-session concurrency claim.

Final cause-confirmation authority, product-fault delivery-agent compensation payer/rate, outgoing payout provider/API, partial returns/payments, prepaid cancellation, late/excess payments and retry/reconciliation remain TBD. New use-case goal identifiers and downstream VOPC/sequence/test impacts require review. No stakeholder decision is inferred for these gaps.

## Fulfillment final nodes

UML final nodes after Delivered, Cancelled and Returned complete the fulfillment region only. They do not assert settled refunds, completed inventory disposition, deletion of the order or a new persisted OrderStatus. Completion transitions follow each terminal fulfillment state. Delivery Failed is not final because warehouse return acknowledgment is still required. Final-node notation introduces no new business status or payout policy.
