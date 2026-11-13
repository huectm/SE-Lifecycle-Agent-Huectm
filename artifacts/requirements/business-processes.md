# Business Process Analysis - Order Lifecycle Revision

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
