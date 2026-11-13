# FreshFood VOPC Analysis Package

Version: 0.1 | Date: 2026-10-28 | Status: Draft for Analysis Review

Scope: five use cases confirmed by the stakeholder as approved. Analysis class names and responsibilities below are logically derived proposals, not new requirements or approved implementation classes.

## Sources and notation

- Master template: templates/Template_Requirements_Analysis_Design_Specification.docx, Chapter IV / VOPC subsection.
- Use case basis: artifacts/requirements/customer-use-case-descriptions.md, version 2.0; artifacts/diagrams/use-case/use-case-list.md.
- Entity basis: artifacts/requirements/data-requirements.md and artifacts/diagrams/class/entity-class-diagram.drawio.
- Reference: examples/SWD392Example_RDS Document-VersionVietNhat.docx, Analysis models and MVC discussion; its interaction examples use Views, Controllers and Services.
- Governing workflow: analysis-modeling; analysis-rules; applicable items of checklists/d4_Checklist_Design Review.xls.

The stakeholder requested four roles: Boundary, Controller, Application Logic and Entity. Controller and Application Logic refine the BCE Control responsibility. Rectangular UML class classifiers use explicit stereotypes; associations show participation and collaboration, not execution order, method signatures or database relations. Application Logic services encapsulate use-case policy and coordination; Controllers route interactions. No repositories, frameworks, SQL objects, DTO fields or technology-specific classes are introduced. CartItem and OrderDetail retain their domain association-class identity; their appearance as participants does not redraw their domain associations. UI Boundary roles cover Web and Mobile without asserting identical source-code classes.

## Source issues and review limits

- SRC-01: UC-C06 activity master contains old BR01/BR02 and a Mailing System, unlike the current use case. The VOPC follows the user-confirmed approved use case and models a generic notification interaction. No separate Email entity/service requirement is introduced. Activity reconciliation requires responsible analyst review before Analysis Baseline approval.
- SRC-02: UC-C03 description permits a Guest persistent session while its Activity primary actor is Customer. Guest participation is shown explicitly as a session variant from the use-case description; confirm actor consistency.
- SRC-03: UC-C01 reuses UC-C01.3 for details and clearance filtering. Both responsibilities are represented without changing approved identifiers.
- SRC-04: FR identifiers differ across historical SRS/prototype catalogs. The supplied FR/BR links are copied from the detailed use-case basis and remain proposed trace links pending RTM reconciliation; no approved identifier is renumbered.
- Notification Service denotes an existing generic interaction role, not a newly selected gateway vendor. PaymentBoundary collaborates with CheckoutService for SePay exchanges. No PaymentBoundary-to-CheckoutController association is modeled in this analysis view; payment verification and state updates belong to CheckoutService. Detailed callback entry and return-message sequencing remain for interaction modeling.

## Participating class catalog

### UC-C01 - Browse & Search Products

Basis: FR-BRW-01, FR-BRW-02, FR-BRW-03; BR-CAT-02, BR-BAT-01, BR-BAT-04.

Editable master: `artifacts/diagrams/class/uc-c01-browse-search-vopc.drawio`  
Rendered image: `artifacts/diagrams/images/uc-c01-browse-search-vopc.png`

| Class ID | Name | Role | Responsibility | Flow basis |
|---|---|---|---|---|
| UC-C01-CatalogView | CatalogView | boundary | Search, category and clearance criteria; product list, details and empty results. | Normal / alternative / exception flows |
| UC-C01-CatalogController | CatalogController | controller | Coordinates browse, search and product-detail requests. | Normal / alternative / exception flows |
| UC-C01-CatalogService | CatalogService | application logic | Select active products and batches; obtain current prices and clearance tags; return details or no-match alternatives. | Normal / alternative / exception flows |
| UC-C01-ProductCategory | ProductCategory | entity | Catalog grouping and active category information. | Use case data participation; domain entity catalog |
| UC-C01-Product | Product | entity | Product details, unit and active catalog status. | Use case data participation; domain entity catalog |
| UC-C01-BatchInventory | BatchInventory | entity | Available / reserved stock, batch price, clearance and expiry. | Use case data participation; domain entity catalog |

Coverage: main, alternative and exception interactions are represented as class responsibilities. This static view does not specify message order or prove behavioral coverage; Analysis Sequence Diagrams remain a separate activity.

### UC-C03 - Manage Shopping Cart

Basis: FR-CRT-01, FR-CRT-02; BR-BAT-01, BR-BAT-02, BR-ORD-01.

Editable master: `artifacts/diagrams/class/uc-c03-manage-cart-vopc.drawio`  
Rendered image: `artifacts/diagrams/images/uc-c03-manage-cart-vopc.png`

| Class ID | Name | Role | Responsibility | Flow basis |
|---|---|---|---|---|
| UC-C03-CartView | CartView | boundary | View basket; add, change or remove items; show stock warnings and totals. | Normal / alternative / exception flows |
| UC-C03-CartController | CartController | controller | Coordinates cart retrieval, item changes and response messages. | Normal / alternative / exception flows |
| UC-C03-CartService | CartService | application logic | Check active products and available stock; maintain cart lines; recalculate totals; flag invalid items without reserving checkout stock. | Normal / alternative / exception flows |
| UC-C03-Cart | Cart | entity | Current shopping basket and its customer/session context. | Use case data participation; domain entity catalog |
| UC-C03-CartItem | CartItem | entity | Product quantity within a shopping cart. | Use case data participation; domain entity catalog |
| UC-C03-Product | Product | entity | Product details, unit and active catalog status. | Use case data participation; domain entity catalog |
| UC-C03-BatchInventory | BatchInventory | entity | Available / reserved stock, batch price, clearance and expiry. | Use case data participation; domain entity catalog |

Coverage: main, alternative and exception interactions are represented as class responsibilities. This static view does not specify message order or prove behavioral coverage; Analysis Sequence Diagrams remain a separate activity.

### UC-C05 - Manage Profile & Addresses

Basis: FR-PRF-01, FR-PRF-02; BR-AUTH-01, BR-AUTH-03.

Editable master: `artifacts/diagrams/class/uc-c05-profile-addresses-vopc.drawio`  
Rendered image: `artifacts/diagrams/images/uc-c05-profile-addresses-vopc.png`

| Class ID | Name | Role | Responsibility | Flow basis |
|---|---|---|---|---|
| UC-C05-ProfileAddressView | ProfileAddressView | boundary | View and edit profile; maintain addresses and default selection; show validation errors. | Normal / alternative / exception flows |
| UC-C05-ProfileController | ProfileController | controller | Coordinates authenticated profile and address-book requests. | Normal / alternative / exception flows |
| UC-C05-ProfileService | ProfileService | application logic | Validate profile/contact data; coordinate geocoding; maintain default address; prevent deletion of addresses used by active pending orders. | Normal / alternative / exception flows |
| UC-C05-Customer | Customer | entity | Customer identity, profile and contact information. | Use case data participation; domain entity catalog |
| UC-C05-CustomerAddress | CustomerAddress | entity | Recipient, geographic coordinates and default address. | Use case data participation; domain entity catalog |
| UC-C05-Order | Order | entity | Order owner, lifecycle, delivery, amounts and payment state. | Use case data participation; domain entity catalog |
| UC-C05-GeocodingBoundary | GeocodingBoundary | boundary | Address resolution requests, coordinates and failure results. | A3.1-A3.2; E3.2 |

Coverage: main, alternative and exception interactions are represented as class responsibilities. This static view does not specify message order or prove behavioral coverage; Analysis Sequence Diagrams remain a separate activity.

### UC-C06 - Checkout & Place Order

Basis: FR-PAY-01, FR-ORD-01, FR-ORD-02, FR-ORD-03, FR-PAY-02; BR-AUTH-01, BR-AUTH-03, BR-DEL-01, BR-DEL-02, BR-ORD-01, BR-ORD-02, BR-ORD-03, BR-BAT-02.

Editable master: `artifacts/diagrams/class/uc-c06-checkout-vopc.drawio`  
Rendered image: `artifacts/diagrams/images/uc-c06-checkout-vopc.png`

| Class ID | Name | Role | Responsibility | Flow basis |
|---|---|---|---|---|
| UC-C06-CheckoutView | CheckoutView | boundary | Select address and payment; review totals; display QR, payment status and order confirmation. | Normal / alternative / exception flows |
| UC-C06-CheckoutController | CheckoutController | controller | Coordinates checkout submission and user-facing responses. | Normal / alternative / exception flows |
| UC-C06-CheckoutService | CheckoutService | application logic | Validate distance and delivery fee; allocate FEFO lines; reserve stock and create order atomically; verify payment confirmation; clear cart and notify. | Normal / alternative / exception flows |
| UC-C06-Customer | Customer | entity | Customer identity, profile and contact information. | Use case data participation; domain entity catalog |
| UC-C06-CustomerAddress | CustomerAddress | entity | Recipient, geographic coordinates and default address. | Use case data participation; domain entity catalog |
| UC-C06-Cart | Cart | entity | Current shopping basket and its customer/session context. | Use case data participation; domain entity catalog |
| UC-C06-CartItem | CartItem | entity | Product quantity within a shopping cart. | Use case data participation; domain entity catalog |
| UC-C06-Product | Product | entity | Product details, unit and active catalog status. | Use case data participation; domain entity catalog |
| UC-C06-BatchInventory | BatchInventory | entity | Available / reserved stock, batch price, clearance and expiry. | Use case data participation; domain entity catalog |
| UC-C06-Order | Order | entity | Order owner, lifecycle, delivery, amounts and payment state. | Use case data participation; domain entity catalog |
| UC-C06-OrderDetail | OrderDetail | entity | Allocated batch, quantity and historical line amounts. | Use case data participation; domain entity catalog |
| UC-C06-DistanceBoundary | DistanceBoundary | boundary | Driving-distance request and response. | Normal 3-4; A2.1; E4.1 |
| UC-C06-PaymentBoundary | PaymentBoundary | boundary | VietQR generation and payment callback exchange. | A6.1 steps 2-6 |
| UC-C06-NotificationBoundary | NotificationBoundary | boundary | Order-confirmation and staff-queue notification interaction. | Postcondition 4 |

Coverage: main, alternative and exception interactions are represented as class responsibilities. This static view does not specify message order or prove behavioral coverage; Analysis Sequence Diagrams remain a separate activity.

### UC-C07 - Manage My Orders

Basis: FR-MYO-01, FR-MYO-02, FR-MYO-04, FR-MYO-03; BR-AUTH-01, BR-ORD-04, BR-ORD-05, BR-RE-01, BR-FB-01.

Editable master: `artifacts/diagrams/class/uc-c07-my-orders-vopc.drawio`  
Rendered image: `artifacts/diagrams/images/uc-c07-my-orders-vopc.png`

| Class ID | Name | Role | Responsibility | Flow basis |
|---|---|---|---|---|
| UC-C07-MyOrdersView | MyOrdersView | boundary | History, details and timeline; cancellation confirmation; re-order and review controls. | Normal / alternative / exception flows |
| UC-C07-MyOrdersController | MyOrdersController | controller | Coordinates owned-order queries, cancellation, re-order and feedback requests. | Normal / alternative / exception flows |
| UC-C07-MyOrdersService | MyOrdersService | application logic | Enforce ownership and lifecycle guards; cancel and release stock atomically; restore available items to cart at current prices; validate and save reviews. | Normal / alternative / exception flows |
| UC-C07-Customer | Customer | entity | Customer identity, profile and contact information. | Use case data participation; domain entity catalog |
| UC-C07-Order | Order | entity | Order owner, lifecycle, delivery, amounts and payment state. | Use case data participation; domain entity catalog |
| UC-C07-OrderDetail | OrderDetail | entity | Allocated batch, quantity and historical line amounts. | Use case data participation; domain entity catalog |
| UC-C07-CustomerAddress | CustomerAddress | entity | Recipient, geographic coordinates and default address. | Use case data participation; domain entity catalog |
| UC-C07-BatchInventory | BatchInventory | entity | Available / reserved stock, batch price, clearance and expiry. | Use case data participation; domain entity catalog |
| UC-C07-Product | Product | entity | Product details, unit and active catalog status. | Use case data participation; domain entity catalog |
| UC-C07-Cart | Cart | entity | Current shopping basket and its customer/session context. | Use case data participation; domain entity catalog |
| UC-C07-CartItem | CartItem | entity | Product quantity within a shopping cart. | Use case data participation; domain entity catalog |
| UC-C07-OrderReview | OrderReview | entity | Delivered-order rating and optional comment. | Use case data participation; domain entity catalog |
| UC-C07-AuditLog | AuditLog | entity | Cancellation audit event required by UC-C07. | Use case data participation; domain entity catalog |
| UC-C07-OrderNotificationBoundary | OrderNotificationBoundary | boundary | Cancellation/status updates and staff-queue notification interaction. | A3.1 step 5 |

Coverage: main, alternative and exception interactions are represented as class responsibilities. This static view does not specify message order or prove behavioral coverage; Analysis Sequence Diagrams remain a separate activity.

## Self-review and gate

| Check | Assessment |
|---|---|
| Five selected use cases covered | Pass |
| Four requested analysis roles explicit | Pass |
| Entity names trace to data requirements | Pass |
| Class responsibilities and UC basis recorded | Pass - proposed analysis links |
| Controller separated from application policy | Pass |
| Technology-independent analysis | Pass |
| Editable source saved before PNG export | Pass |
| Orthogonal routing and unrelated-node collision checks | Pass |
| Exported PNG visual review | Pass - all five images inspected; readable labels, unclipped text and clear routing |
| Detailed design method signatures / attributes | Not applicable to this VOPC activity |
| Sequence/state models | Not created; outside the requested static view |
| Upstream source consistency | Review required - SRC-01 to SRC-04 |

Gate: Submit to System Analyst / Architect and stakeholder for review. No Analysis Baseline approval is inferred. Upon explicit approval and resolution of relevant source issues, synchronize the approved diagrams and class catalogs into the existing Master Specification Chapter IV / VOPC section and update RTM using existing IDs and workbook structure. Drafts are not embedded as an approved baseline.


## VOPC classification and source location - 2026-10-28

VOPC is an analysis-level UML class diagram. All five editable drawio masters are stored in artifacts/diagrams/class/. Their PNGs remain in artifacts/diagrams/images/. This relocation preserves exact source bytes, class identities, associations and rendered image bytes; it does not constitute approval of the analysis content.


## UC-C06 association correction - 2026-10-28

Removed PaymentBoundary to CheckoutController association as explicitly directed by the stakeholder. CheckoutService retains its association with PaymentBoundary and the responsibility for payment verification and order-state updates. This static class view does not model response messages or prescribe webhook transport implementation. No use-case behavior, Entity or other association was removed.
