# FreshFood Analysis Sequence Diagram Package

Version: 0.1 | Date: 2026-10-28 | Status: Draft for Analysis Review

Scope: five stakeholder-confirmed approved use cases; one multi-page editable Draw.io master per use case, with scenario-specific PNG exports.

## Sources and template

- artifacts/requirements/customer-use-case-descriptions.md, version 2.0: interaction and flow basis.
- artifacts/diagrams/class/*-vopc.drawio: Boundary, Controller, Application Logic and Entity class names; includes the corrected UC-C06 PaymentBoundary relationship.
- templates/Template_Requirements_Analysis_Design_Specification.docx: existing Chapter IV / Analysis Sequence Diagrams subsection.
- examples/SWD392Example_RDS Document-VersionVietNhat.docx: analysis interaction notation using Views, Controllers and Services.
- analysis-modeling skill, analysis-rules and the applicable dynamic-view, class responsibility, interface I/O, exception and formatting items of d4_Checklist_Design Review.xls.

## Modeling decisions

Lifelines show scenario-specific subsets of the current VOPC participants. Calls and returns use solid filled and dashed open arrows; separate asynchronous notifications use solid open arrows. seq, opt and alt fragments express ordered scenarios, optional actions and mutually exclusive guards. Activation rectangles span the execution from receipt to completion/reply, including nested calls and synchronous waiting. Actor-facing UI execution ends at the result received by the Boundary; no reply arrow to the human actor is drawn. Explicit-return intervals are distinguished from implicit completion in verification metadata; vertical length is not a calibrated time scale. Short breaks in dashed lifelines at unrelated message crossings keep arrows unobstructed and do not denote object destruction.

Entity interactions describe analysis responsibilities, not direct database access, repository design, SQL or final method signatures. Interface classes, SDKs and frameworks are not introduced. Actor-to-view requests and the displayed results are shown with the internal collaborations that realize them.

## Coverage and diagram index

| Use case | Editable master | Scenario / source flow | Rendered image |
|---|---|---|---|
| UC-C01 | [uc-c01-browse-search-sequence.drawio](../diagrams/sequence/uc-c01-browse-search-sequence.drawio) | 01 Catalog and search: Normal 1-6; E4.1 | [PNG](../diagrams/images/uc-c01-browse-search-sequence-01.png) |
| UC-C01 | [uc-c01-browse-search-sequence.drawio](../diagrams/sequence/uc-c01-browse-search-sequence.drawio) | 02 Details and clearance: A3.1; A3.2 | [PNG](../diagrams/images/uc-c01-browse-search-sequence-02.png) |
| UC-C03 | [uc-c03-manage-cart-sequence.drawio](../diagrams/sequence/uc-c03-manage-cart-sequence.drawio) | 01 View cart: Normal 1-5; E3.1 | [PNG](../diagrams/images/uc-c03-manage-cart-sequence-01.png) |
| UC-C03 | [uc-c03-manage-cart-sequence.drawio](../diagrams/sequence/uc-c03-manage-cart-sequence.drawio) | 02 Add or update quantity: A1.1; A4.1; E2.1 | [PNG](../diagrams/images/uc-c03-manage-cart-sequence-02.png) |
| UC-C03 | [uc-c03-manage-cart-sequence.drawio](../diagrams/sequence/uc-c03-manage-cart-sequence.drawio) | 03 Remove item: A4.2 | [PNG](../diagrams/images/uc-c03-manage-cart-sequence-03.png) |
| UC-C05 | [uc-c05-profile-addresses-sequence.drawio](../diagrams/sequence/uc-c05-profile-addresses-sequence.drawio) | 01 View and update profile: Normal 1-3; A2.1 | [PNG](../diagrams/images/uc-c05-profile-addresses-sequence-01.png) |
| UC-C05 | [uc-c05-profile-addresses-sequence.drawio](../diagrams/sequence/uc-c05-profile-addresses-sequence.drawio) | 02 Add or edit address: A3.1; A3.2; E3.1; E3.2 | [PNG](../diagrams/images/uc-c05-profile-addresses-sequence-02.png) |
| UC-C05 | [uc-c05-profile-addresses-sequence.drawio](../diagrams/sequence/uc-c05-profile-addresses-sequence.drawio) | 03 Delete saved address: A3.3 | [PNG](../diagrams/images/uc-c05-profile-addresses-sequence-03.png) |
| UC-C06 | [uc-c06-checkout-sequence.drawio](../diagrams/sequence/uc-c06-checkout-sequence.drawio) | 01 Prepare delivery and totals: Normal 1-6; A2.1; E4.1 | [PNG](../diagrams/images/uc-c06-checkout-sequence-01.png) |
| UC-C06 | [uc-c06-checkout-sequence.drawio](../diagrams/sequence/uc-c06-checkout-sequence.drawio) | 02 Submit COD order: Normal 7-9; E8.1; postconditions | [PNG](../diagrams/images/uc-c06-checkout-sequence-02.png) |
| UC-C06 | [uc-c06-checkout-sequence.drawio](../diagrams/sequence/uc-c06-checkout-sequence.drawio) | 03 VietQR and payment confirmation: A6.1; BR-ORD-03; payment postconditions | [PNG](../diagrams/images/uc-c06-checkout-sequence-03.png) |
| UC-C07 | [uc-c07-my-orders-sequence.drawio](../diagrams/sequence/uc-c07-my-orders-sequence.drawio) | 01 Order history and details: Normal 1-5 | [PNG](../diagrams/images/uc-c07-my-orders-sequence-01.png) |
| UC-C07 | [uc-c07-my-orders-sequence.drawio](../diagrams/sequence/uc-c07-my-orders-sequence.drawio) | 02 Cancel order: A3.1; E1.1 | [PNG](../diagrams/images/uc-c07-my-orders-sequence-02.png) |
| UC-C07 | [uc-c07-my-orders-sequence.drawio](../diagrams/sequence/uc-c07-my-orders-sequence.drawio) | 03 Re-order: A5.1; E2.1 | [PNG](../diagrams/images/uc-c07-my-orders-sequence-03.png) |
| UC-C07 | [uc-c07-my-orders-sequence.drawio](../diagrams/sequence/uc-c07-my-orders-sequence.drawio) | 04 Submit review: A5.2 | [PNG](../diagrams/images/uc-c07-my-orders-sequence-04.png) |

## Source issues and limits

- Previous source issues from vopc-analysis.md remain: old checkout Activity BR01/BR02 and Mailing System, UC-C03 Guest-session actor difference, reused UC-C01.3 identifier, and FR catalog inconsistencies. Approved source IDs are not renumbered.
- UC-C06 QR data returns from SePay to PaymentBoundary to CheckoutService. The later payment notification is explicitly asynchronous, forwarded by PaymentBoundary to CheckoutService. No PaymentBoundary-to-CheckoutController interaction is added. CheckoutService verifies the payment and updates Order before publishing a UI payment-state update. The UI push is logically derived from the documented real-time listener and remains subject to analysis review; this does not select a framework or amend the static VOPC.
- UC-C06 VietQR page invokes the shared atomic submission responsibility detailed in its COD submission page. Pending/paid terminology is retained from the use-case source; separate fulfillment-state and payment-state semantics require analyst review. The 15-minute timer is shown without inventing timeout, refund or invalid-callback recovery behavior.
- UC-C05 address deletion models the specified eligible-address path. Invalid-email recovery and deletion rejection for an address in active use remain unspecified.
- UC-C07 review models the valid 1-5 rating, delivered-owned-order and one-review-per-order path. User-visible handling of invalid/duplicate feedback is not specified; no extra exception requirement is invented. Cancellation guards use the states explicitly stated in the source.
- Application class names and message responsibilities are derived analysis proposals. The entire VOPC / Analysis Baseline is not assumed approved; this requested sequence work is authorized iterative analysis.

## Review and gate

All five use cases and every explicitly listed normal, alternative and exception flow ID map to scenario pages. Message-level traceability is recorded in sequence-traceability.csv; XML structure, participant names, source/image hashes and visual review are recorded in sequence-verification.json. These are draft trace links, not changes to approved RTM baselines.

Submit to the System Analyst / Architect and stakeholder. STOP before treating the package as an Analysis Baseline. After explicit approval and resolution of relevant source issues, integrate approved images and narratives into the existing Master Specification Chapter IV / Analysis Sequence Diagrams section, then synchronize the RTM while preserving its structure and stable IDs. Master Specification and approved RTM were not edited during this draft activity.


## Final self-review

Five editable masters, fifteen rendered scenario pages and 244 traceable messages verified. XML IDs are unique on every page. Source/image hashes match. Guard/message-label rectangle collision checks pass after clearance correction. All scenario images were visually reviewed, with the revised guard layout spot-checked on the denser pages. SePay QR reply and asynchronous payment notification both terminate at CheckoutService via PaymentBoundary; no PaymentBoundary-to-CheckoutController message exists. No execution tests were run: these are reviewable analysis artifacts. Gate status remains Draft for Analysis Review.


## Actor-return and activation correction - 2026-10-28

Per stakeholder direction, responses terminate at UI Boundary lifelines. Actor-to-UI actions remain; UI-to-human return arrows were removed. Confirmation prompts and review-form rendering are represented as UI self-processing before the subsequent actor action. Activation rectangles replace the earlier fixed short reception markers: they span calls through their replies/completion, include nested self-calls and stay continuous across combined fragments. A logical execution remains continuous across fragment boundaries; alt operands describe mutually exclusive paths, not consecutive executions. Asynchronous payment processing has its own execution interval, separate from the earlier QR request. No method duration in milliseconds is inferred.


Revision verification: all 5 masters and 15 scenario pages re-exported with interval-based activations; actor return arrows removed. Current message count: 236. All source/image hashes verified; positive execution intervals and branch spans checked. Representative revised images (search alternatives, cart confirmation, cancellation, review form and asynchronous checkout) were inspected. Existing source gaps and draft review status remain unchanged.


## Continuous execution occurrence correction - 2026-10-28

An activation is now one continuous rectangle from the start to completion of the same logical execution occurrence, even when it spans seq/alt/opt fragments. Fragment labels and separators do not split or restart a method. Separate incoming invocations and the later asynchronous payment handler retain separate activations. Nested self-calls remain offset on the same lifeline. Guard labels are placed in the actor/UI whitespace corridor so they do not mask continuous activations. The vertical envelope of alternative operands does not imply execution of every branch or a calibrated duration.
