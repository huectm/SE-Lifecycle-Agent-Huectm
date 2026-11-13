> Approval update: the stakeholder explicitly approved this design for backend source realization. The approved content is synchronized into Chapter V of the Master Specification Document. Existing TBDs remain unresolved; earlier draft review statements below are historical.

# Design Sequence Diagrams

Version: 0.1 | Date: 2026-11-01 | Status: Draft for Design Review

These interactions realize the five customer use cases using the current detailed class contracts. The approved master template section is Chapter V / Detailed Design / Use Case Realization / Design Sequence Diagrams.

| Use case | Editable master | Pages |
|---|---|---|
| UC-C01 — Browse and Search Products | [uc-c01-browse-search-design-sequence.drawio](../diagrams/sequence/uc-c01-browse-search-design-sequence.drawio) | 5 |
| UC-C03 — Manage Shopping Cart | [uc-c03-manage-cart-design-sequence.drawio](../diagrams/sequence/uc-c03-manage-cart-design-sequence.drawio) | 4 |
| UC-C05 — Manage Profile and Addresses | [uc-c05-profile-addresses-design-sequence.drawio](../diagrams/sequence/uc-c05-profile-addresses-design-sequence.drawio) | 6 |
| UC-C06 — Checkout and Place Order | [uc-c06-checkout-design-sequence.drawio](../diagrams/sequence/uc-c06-checkout-design-sequence.drawio) | 7 |
| UC-C07 — Manage My Orders | [uc-c07-my-orders-design-sequence.drawio](../diagrams/sequence/uc-c07-my-orders-design-sequence.drawio) | 7 |

## Reading conventions

- Web entry: React Page → concrete ApiClient → HTTPS → Controller → injected service interface.
- Mobile entry: View → ViewModel → concrete ApiModel → the same API contract. The operation-specific backend page supplies the detailed continuation; the Mobile page does not duplicate it.
- Runtime classifier names identify objects; `via I...` identifies injected contracts where displayed. Gateway implementation bindings remain as specified in the detailed class model. Frontend references use ordinary associations; DI is backend-only.
- Message parameters and return DTOs follow the detailed class signatures. `signal` is supplied locally by the server and is not serialized in HTTP payloads. HTTP labels name contract operations, not selected routes or framework APIs.
- `[local]` denotes an internal computation within the current method, not a new public operation. TransactionWork is the existing callback contract.
- A single activation spans an invocation, its awaited calls and combined fragments. Alternative operands are mutually exclusive, not successive executions. The diagram has no elapsed-time scale.
- Responses stop at the UI; actor response arrows are omitted. The separate SePay webhook page is asynchronous relative to the customer checkout request. No callback is routed through CheckoutController.
- UnitOfWork calls back into the work scope and commits only after it completes; exceptions roll back. ExecuteInCurrentTransactionAsync joins that scope and must not create a nested transaction. Notification calls occur only after a successful commit.

## Source and design traceability

- [Customer use-case descriptions](../requirements/customer-use-case-descriptions.md)
- [Stakeholder order/payment/return review](../requirements/reviews/order-payment-return-use-case-review.md)
- [Detailed class design](detailed-design-class-diagrams.md)
- [Analysis-to-design interaction mapping](detailed/interaction-to-design-mapping.csv)
- [Design operation traceability](design-sequence-operation-traceability.json)
- [Every rendered message and source-flow reference](design-sequence-message-traceability.csv)
- [Static review results](design-sequence-static-review.json) and [export/hash records](design-sequence-verification.json)

## Review limits and unresolved issues

The diagram sources and PNG exports are review artifacts, not an implementation or a runtime test result. Coverage here means representation of the current service operations and source flow groups; it does not assert exhaustive executable branch or condition coverage.

The current repository contracts omit a dedicated non-locking owned-order detail read. GetOrderDetailsAsync therefore shows retrieval through FindOwnedAsync and mapping of the owned order data; efficient OrderDetail loading remains a contract review point. No nonexistent repository method or SQL implementation is invented. Profile uniqueness and validation details remain the responsibilities in the approved specification, without invented storage APIs.

The latest stakeholder decisions govern initial order acceptance: acceptOrder precedes exactly one guarded Pending Unpaid/Pending Paid branch. No Pending Unpaid → Pending Paid fulfillment transition is modeled. First unpaid orders require staff phone confirmation before approval, outside these customer interaction scenarios. Acceptance, initial payment, all-line FEFO reservation, order/line persistence and cart changes share the same outer transaction. The transition dispatch pages are refinements of that execution. Persistence performed by the acceptance handler and SaveOrderAsync must participate in the same aggregate/unit of work, without duplicate inserts.

Pre-acceptance payment-reference persistence/correlation, late or excess payment handling, durable transition-event storage, customer audit actor mapping, prepaid cancellation refunds, outgoing payout provider and reconciliation remain TBD as recorded in the existing design. The verified webhook page indicates guards and fail-closed handling; it does not resolve these policies. VerifiedPaymentDto is a verification result, while HandleVerifiedPaymentAsync retains its current PaymentNoticeDto signature and must enforce trusted verification; review the trust handoff before implementation. Refund/return staff scenarios are not invented as additional customer use cases.

Design baseline approval and integration into the Master Specification Document remain pending the Architect/Technical Lead review gate required by `.agents/skills/software-design/SKILL.md`. Existing approved analysis diagrams are preserved.

## Page and image index

### UC-C01 — Browse and Search Products

| Page | Scenario | Source flows | PNG |
|---|---|---|---|
| 1 | GetCatalog | Normal 1-6; E4.1 | [View image](../diagrams/images/uc-c01-browse-search-design-sequence-01.png) |
| 2 | Search | Normal 1-6; E4.1 | [View image](../diagrams/images/uc-c01-browse-search-design-sequence-02.png) |
| 3 | GetProductDetails | A3.1; A3.2 | [View image](../diagrams/images/uc-c01-browse-search-design-sequence-03.png) |
| 4 | GetClearance | A3.1; A3.2 | [View image](../diagrams/images/uc-c01-browse-search-design-sequence-04.png) |
| 5 | Mobile entry refinement | Same DTO/API contract; ref operation-specific backend pages | [View image](../diagrams/images/uc-c01-browse-search-design-sequence-05.png) |

### UC-C03 — Manage Shopping Cart

| Page | Scenario | Source flows | PNG |
|---|---|---|---|
| 1 | GetCart | Normal 1-5; E3.1; A1.1; A4.1; E2.1; A4.2 | [View image](../diagrams/images/uc-c03-manage-cart-design-sequence-01.png) |
| 2 | ChangeQuantity | A1.1; A4.1; E2.1 | [View image](../diagrams/images/uc-c03-manage-cart-design-sequence-02.png) |
| 3 | RemoveItem | A4.2 | [View image](../diagrams/images/uc-c03-manage-cart-design-sequence-03.png) |
| 4 | Mobile entry refinement | Same DTO/API contract; ref operation-specific backend pages | [View image](../diagrams/images/uc-c03-manage-cart-design-sequence-04.png) |

### UC-C05 — Manage Profile and Addresses

| Page | Scenario | Source flows | PNG |
|---|---|---|---|
| 1 | GetProfile | Normal 1-3; A2.1 | [View image](../diagrams/images/uc-c05-profile-addresses-design-sequence-01.png) |
| 2 | UpdateProfile | Normal 1-3; A2.1 | [View image](../diagrams/images/uc-c05-profile-addresses-design-sequence-02.png) |
| 3 | SaveAddress | A3.1; A3.2; E3.1; E3.2 | [View image](../diagrams/images/uc-c05-profile-addresses-design-sequence-03.png) |
| 4 | SetDefaultAddress | Address default selection in approved profile flow | [View image](../diagrams/images/uc-c05-profile-addresses-design-sequence-04.png) |
| 5 | DeleteAddress | A3.3 | [View image](../diagrams/images/uc-c05-profile-addresses-design-sequence-05.png) |
| 6 | Mobile entry refinement | Same DTO/API contract; ref operation-specific backend pages | [View image](../diagrams/images/uc-c05-profile-addresses-design-sequence-06.png) |

### UC-C06 — Checkout and Place Order

| Page | Scenario | Source flows | PNG |
|---|---|---|---|
| 1 | PrepareCheckout | Normal 1-6; A2.1; E4.1 | [View image](../diagrams/images/uc-c06-checkout-design-sequence-01.png) |
| 2 | PlaceOrder | Normal 7-9; E8.1; postconditions; A6.1; BR-ORD-03; payment postconditions | [View image](../diagrams/images/uc-c06-checkout-design-sequence-02.png) |
| 3 | CreatePaymentQr | Address default selection in approved profile flow | [View image](../diagrams/images/uc-c06-checkout-design-sequence-03.png) |
| 4 | Mobile entry refinement | Same DTO/API contract; ref operation-specific backend pages | [View image](../diagrams/images/uc-c06-checkout-design-sequence-04.png) |
| 5 | Verified payment webhook | A6.1; latest initial-state rules override stale Pending wording | [View image](../diagrams/images/uc-c06-checkout-design-sequence-05.png) |
| 6 | Acceptance transition dispatch | I00; T01u/T01p; P01/P02; ref PlaceOrder outer transaction | [View image](../diagrams/images/uc-c06-checkout-design-sequence-06.png) |
| 7 | Initial payment transition dispatch | P01/P02; ref PlaceOrder; financial state independent of fulfillment | [View image](../diagrams/images/uc-c06-checkout-design-sequence-07.png) |

### UC-C07 — Manage My Orders

| Page | Scenario | Source flows | PNG |
|---|---|---|---|
| 1 | GetOrders | Normal 1-5 | [View image](../diagrams/images/uc-c07-my-orders-design-sequence-01.png) |
| 2 | GetOrderDetails | Normal 1-5 | [View image](../diagrams/images/uc-c07-my-orders-design-sequence-02.png) |
| 3 | CancelOrder | A3.1; E1.1 | [View image](../diagrams/images/uc-c07-my-orders-design-sequence-03.png) |
| 4 | Reorder | A5.1; E2.1 | [View image](../diagrams/images/uc-c07-my-orders-design-sequence-04.png) |
| 5 | SubmitReview | A5.2 | [View image](../diagrams/images/uc-c07-my-orders-design-sequence-05.png) |
| 6 | Mobile entry refinement | Same DTO/API contract; ref operation-specific backend pages | [View image](../diagrams/images/uc-c07-my-orders-design-sequence-06.png) |
| 7 | Cancellation transition dispatch | T08u/T08p/T09; ref CancelOrder transaction; no Packing/Shipping cancellation | [View image](../diagrams/images/uc-c07-my-orders-design-sequence-07.png) |


## Self-review outcome

All 334 structural checks passed: 242 named receiver method calls match the detailed class catalog; 284 execution occurrences have one continuous span; rendered label rectangles do not overlap headers or activations; message segments do not cross unrelated activation rectangles. Master/PNG hashes are recorded. A contact-sheet review covered all 29 pages, with full-size inspection of representative message/fragment layout. These checks verify the model and exported layout, not runtime behavior or exhaustive business-path coverage.
