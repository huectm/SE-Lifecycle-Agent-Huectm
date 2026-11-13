# Detailed Design Review

Date: 2026-10-31 | Status: Self-review complete; Architect / Technical Lead approval pending.

Source checklist: checklists/d4_Checklist_Design Review.xls, read locally using Excel. Reference numbers below are zero-based extracted nonempty row indexes, not invented checklist IDs. The workbook itself was not modified.

| Checklist row | Source question | Assessment | Evidence / limit |
|---|---|---|---|
| 21 | Are component boundaries well defined, including functionalities and interfaces? | Pass - scoped design | Component ownership follows Controllers/Services/DTOs and FreshFood.Reposistory; no API DTO is referenced by repository/entity signatures. |
| 93 | Are the inputs and outputs for all the interfaces are sufficient and necessary? | Review required | Typed request/response and repository contracts are specified; provider/cancellation and customer-audit storage details remain unresolved. |
| 95 | Does each components specified in Architecture being decomposed to classes and depicted in a class diagram ? | Pass - scoped design | API and repository components are decomposed into interfaces/classes. Customer Web and Mobile have separate boundary, concrete API adapter and ViewModel classes with ordinary associations; DI is backend-only. Staff lifecycle support is shared, not a new customer use case. |
| 96 | Does the class diagram view provided to each business ? | Pass | Each of the five customer use cases has a separate multi-page editable class master. |
| 100 | Are classes' main interface/methods all clearly described ? | Pass - static | Main interfaces/methods, attributes, visibility, constructor dependencies and parameter/return types are in Draw.io and class-specifications.md. |
| 102 | Are there dynamic diagram (sequence, activity diagram) used to describe the complicated method ? | Partial | All 48 VOPC classes are explicitly mapped and shown on connected first-page realizations, with source/pattern tags. Existing analysis sequence messages are mapped to design operations. Design sequence diagrams are now available in ../design-sequence-diagrams.md as a separate draft for review; they do not assert implementation or dynamic test completion. |
| 103 | Are inputs to methods necessary and sufficient to perform the required operation? | Review required | Owned customer identity and trusted snapshots are server-resolved. QR pre-acceptance correlation, version/event storage and final cause authority require detailed approval. |
| 104 | Do methods clearly state how the output is derived from input or shared data? | Pass - design specification | Transaction/guard/effect derivation is recorded for checkout, cancellation, refund and settlement. Node-compatible UML signatures and exact integer-VND value semantics are checked. No runtime execution proof. |
| 105 | Are error, exception and other abnormal processing and states described in detail? | Partial / baseline blocker | Documented failure/uncertainty and source-policy gaps fail closed. Provider retry, late/partial/excess payment, prepaid cancellation and audit actor schema remain TBD. |
| 106 | Are all classes, methods… named follow the coding convention? | Pass - static | Stable UC/transition identifiers retained; canonical component spelling FreshFood.Reposistory preserved; package ownership labels are distinct from compilable namespaces. |

## Corrected during self-review

- Separated server payment callback responsibility from customer-facing controller/client methods. PaymentNoticeHandler calls ICheckoutService and IPaymentGateway; it never calls CheckoutController.
- Interface realizations and constructor signatures are cross-checked. Private entity setters remain; guarded domain methods are accessible to the API-owned services across the repository component boundary.
- Each of 24 transitions maps to a unique handler; pseudostate/final handlers do not create persistent business statuses. Both initial branches pass the common acceptOrder step in one transaction.
- Handler execution receives the same trusted server-created snapshot used for guard evaluation. Initial checkout carries an in-memory workflow position until one initial status is persisted, rather than trying to load a nonexistent accepted order.
- Repository contracts include writes for each modeled transition effect; they return repository-owned domain records, never API DTOs.
- Independent orthogonal routes, distinct perimeter anchors and opaque text backgrounds are used. Detailed diagrams show no package notation. Stored DI/collaborator references are solid associations; DTO/entity usage is a dashed dependency and interface realization uses a hollow triangle. All routes are checked against unrelated class bounds. Contact sheets cover all current diagram pages; representative API, transition and dense entity views were inspected at full size.
- RTM additions are draft design links; implementation and test columns remain empty. Existing sheet names and formulas are compared with the pre-change backup.

## Open issues before baseline

1. Resolve the old Pending clauses in UC-C06/C07 and align downstream design sequences under controlled review.
2. Confirm outgoing payout integration and final fault-decision authority; preserve the approved fee matrix. No unverified settlement is represented as completed.
3. Specify customer identity audit storage without mapping a customer to a staff account.
4. Approve durable transition-event/idempotency and concurrency/version storage; this design creates no migration.
5. Confirm provider correlation before accepted checkout, late/partial/excess payments, prepaid cancellation refunds, retry/reconciliation and product-fault courier compensation.
6. Bind notification channel/runtime transport details in startup without promising unapproved delivery/retry guarantees.

## Gate

This is a proposed technical design package. No application code was implemented or compiled and no dynamic test was executed. After explicit design approval, integrate the approved mapping, class diagrams/figures and class specifications into the existing Chapter V template sections, then initiate the corresponding unit/module-integration test design. Do not bypass the Human Verification Gate.
