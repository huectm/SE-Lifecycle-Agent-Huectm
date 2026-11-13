> Approval update: the stakeholder explicitly approved this design for backend source realization. The approved content is synchronized into Chapter V of the Master Specification Document. Existing TBDs remain unresolved; earlier draft review statements below are historical.

# Detailed Design Class Diagrams

Version: 0.3 | Date: 2026-10-31 | Status: Draft for Architect / Technical Lead Review.

## Design basis and boundaries

Scope: UC-C01, UC-C03, UC-C05, UC-C06 and UC-C07. Inputs are the current use-case descriptions, five VOPCs, five analysis-sequence masters, package/component architecture, entity/data catalog and the 24-transition order/payment/refund model. The stakeholder explicitly requests backend-only constructor dependency injection and one class for every state transition. Detailed class diagrams contain no package frames or qualified package headers. Stored DI/collaborator references use associations; DTO and entity type usages use dependencies; implementation contracts retain realization. These are authorized iterative design inputs; the complete architecture/analysis baseline is not inferred approved.

Ownership remains FreshFood-API.Controllers, Services, Services.Implements and DTOs, together with FreshFood.Reposistory.Repository, Repository.Implements and Entities. These ownership labels exist only in the catalog/mapping, not in diagram notation. Component labels do not choose a code namespace or implementation language/tooling. Web and Mobile use their own Pages/CallService and Views/ViewModels/Models packages. No new subsystem, persistent status or database table is created by this design.

## Analysis-to-Design Class Mapping

| Analysis Class | Design Class / Component | Mapping Rationale |
|---|---|---|
| UC-C01 / CatalogView | CatalogPage; CatalogApiClient; CatalogView; CatalogViewModel; CatalogApiModel | Web Pages / CallService; mobile MVVM; no frontend DI; shown together on page 1 with source/pattern tags. |
| UC-C01 / CatalogController | CatalogController | API controller retained; service interface supplied by backend DI; shown together on page 1 with source/pattern tags. |
| UC-C01 / CatalogService | ICatalogService; CatalogService; ICatalogRepository; CatalogRepository; IBatchPricingPolicy; BatchPricingPolicy | Layered application logic + service interface extraction + Repository / domain policies / backend DI; shown together on page 1 with source/pattern tags. |
| UC-C01 / ProductCategory | ProductCategory | Domain entity retained; navigations and invariants refined from data requirements; shown together on page 1 with source/pattern tags. |
| UC-C01 / Product | Product | Domain entity retained; navigations and invariants refined from data requirements; shown together on page 1 with source/pattern tags. |
| UC-C01 / BatchInventory | BatchInventory | Domain entity retained; navigations and invariants refined from data requirements; shown together on page 1 with source/pattern tags. |
| UC-C03 / CartView | CartPage; CartApiClient; CartView; CartViewModel; CartApiModel | Web Pages / CallService; mobile MVVM; no frontend DI; shown together on page 1 with source/pattern tags. |
| UC-C03 / CartController | CartController | API controller retained; service interface supplied by backend DI; shown together on page 1 with source/pattern tags. |
| UC-C03 / CartService | ICartService; CartService; ICartRepository; CartRepository; IBatchPricingPolicy; BatchPricingPolicy | Layered application logic + service interface extraction + Repository / domain policies / backend DI; shown together on page 1 with source/pattern tags. |
| UC-C03 / Cart | Cart | Domain entity retained; navigations and invariants refined from data requirements; shown together on page 1 with source/pattern tags. |
| UC-C03 / CartItem | CartItem | Domain entity retained; navigations and invariants refined from data requirements; shown together on page 1 with source/pattern tags. |
| UC-C03 / Product | Product | Domain entity retained; navigations and invariants refined from data requirements; shown together on page 1 with source/pattern tags. |
| UC-C03 / BatchInventory | BatchInventory | Domain entity retained; navigations and invariants refined from data requirements; shown together on page 1 with source/pattern tags. |
| UC-C05 / ProfileAddressView | ProfilePage; ProfileApiClient; ProfileAddressView; ProfileViewModel; ProfileApiModel | Web Pages / CallService; mobile MVVM; no frontend DI; shown together on page 1 with source/pattern tags. |
| UC-C05 / ProfileController | ProfileController | API controller retained; service interface supplied by backend DI; shown together on page 1 with source/pattern tags. |
| UC-C05 / ProfileService | IProfileService; ProfileService; IProfileRepository; ProfileRepository | Layered application logic + service interface extraction + Repository / domain policies / backend DI; shown together on page 1 with source/pattern tags. |
| UC-C05 / Customer | Customer | Domain entity retained; navigations and invariants refined from data requirements; shown together on page 1 with source/pattern tags. |
| UC-C05 / CustomerAddress | CustomerAddress | Domain entity retained; navigations and invariants refined from data requirements; shown together on page 1 with source/pattern tags. |
| UC-C05 / Order | Order | Domain entity retained; navigations and invariants refined from data requirements; shown together on page 1 with source/pattern tags. |
| UC-C05 / GeocodingBoundary | IGeocodingGateway; GoogleMapsGeocodingAdapter | Adapter / backend DI; shown together on page 1 with source/pattern tags. |
| UC-C06 / CheckoutView | CheckoutPage; CheckoutApiClient; CheckoutView; CheckoutViewModel; CheckoutApiModel | Web Pages / CallService; mobile MVVM; no frontend DI; shown together on page 1 with source/pattern tags. |
| UC-C06 / CheckoutController | CheckoutController | API controller retained; service interface supplied by backend DI; shown together on page 1 with source/pattern tags. |
| UC-C06 / CheckoutService | ICheckoutService; CheckoutService; ICheckoutRepository; CheckoutRepository; IBatchPricingPolicy; BatchPricingPolicy; IDeliveryFeePolicy; DeliveryFeePolicy; IFefoBatchSpecification; FefoBatchSpecification | Layered application logic + service interface extraction + Repository / domain policies / backend DI; shown together on page 1 with source/pattern tags. |
| UC-C06 / Customer | Customer | Domain entity retained; navigations and invariants refined from data requirements; shown together on page 1 with source/pattern tags. |
| UC-C06 / CustomerAddress | CustomerAddress | Domain entity retained; navigations and invariants refined from data requirements; shown together on page 1 with source/pattern tags. |
| UC-C06 / Cart | Cart | Domain entity retained; navigations and invariants refined from data requirements; shown together on page 1 with source/pattern tags. |
| UC-C06 / CartItem | CartItem | Domain entity retained; navigations and invariants refined from data requirements; shown together on page 1 with source/pattern tags. |
| UC-C06 / Product | Product | Domain entity retained; navigations and invariants refined from data requirements; shown together on page 1 with source/pattern tags. |
| UC-C06 / BatchInventory | BatchInventory | Domain entity retained; navigations and invariants refined from data requirements; shown together on page 1 with source/pattern tags. |
| UC-C06 / Order | Order | Domain entity retained; navigations and invariants refined from data requirements; shown together on page 1 with source/pattern tags. |
| UC-C06 / OrderDetail | OrderDetail | Domain entity retained; navigations and invariants refined from data requirements; shown together on page 1 with source/pattern tags. |
| UC-C06 / DistanceBoundary | IDistanceCalculator; DistanceCalculator; IDistanceGateway; GoogleMapsDistanceAdapter | Adapter / backend DI; shown together on page 1 with source/pattern tags. |
| UC-C06 / PaymentBoundary | IPaymentGateway; SePayPaymentAdapter; PaymentNoticeHandler | Adapter / backend DI; shown together on page 1 with source/pattern tags. |
| UC-C06 / NotificationBoundary | INotificationGateway; NotificationAdapter | Adapter / backend DI; shown together on page 1 with source/pattern tags. |
| UC-C07 / MyOrdersView | MyOrdersPage; MyOrdersApiClient; MyOrdersView; MyOrdersViewModel; MyOrdersApiModel | Web Pages / CallService; mobile MVVM; no frontend DI; shown together on page 1 with source/pattern tags. |
| UC-C07 / MyOrdersController | MyOrdersController | API controller retained; service interface supplied by backend DI; shown together on page 1 with source/pattern tags. |
| UC-C07 / MyOrdersService | IMyOrdersService; MyOrdersService; IMyOrdersRepository; MyOrdersRepository; IBatchPricingPolicy; BatchPricingPolicy | Layered application logic + service interface extraction + Repository / domain policies / backend DI; shown together on page 1 with source/pattern tags. |
| UC-C07 / Customer | Customer | Domain entity retained; navigations and invariants refined from data requirements; shown together on page 1 with source/pattern tags. |
| UC-C07 / Order | Order | Domain entity retained; navigations and invariants refined from data requirements; shown together on page 1 with source/pattern tags. |
| UC-C07 / OrderDetail | OrderDetail | Domain entity retained; navigations and invariants refined from data requirements; shown together on page 1 with source/pattern tags. |
| UC-C07 / CustomerAddress | CustomerAddress | Domain entity retained; navigations and invariants refined from data requirements; shown together on page 1 with source/pattern tags. |
| UC-C07 / BatchInventory | BatchInventory | Domain entity retained; navigations and invariants refined from data requirements; shown together on page 1 with source/pattern tags. |
| UC-C07 / Product | Product | Domain entity retained; navigations and invariants refined from data requirements; shown together on page 1 with source/pattern tags. |
| UC-C07 / Cart | Cart | Domain entity retained; navigations and invariants refined from data requirements; shown together on page 1 with source/pattern tags. |
| UC-C07 / CartItem | CartItem | Domain entity retained; navigations and invariants refined from data requirements; shown together on page 1 with source/pattern tags. |
| UC-C07 / OrderReview | OrderReview | Domain entity retained; navigations and invariants refined from data requirements; shown together on page 1 with source/pattern tags. |
| UC-C07 / AuditLog | AuditLog | Domain entity retained; navigations and invariants refined from data requirements; shown together on page 1 with source/pattern tags. |
| UC-C07 / OrderNotificationBoundary | INotificationGateway; NotificationAdapter | Adapter / backend DI; shown together on page 1 with source/pattern tags. |

Full structured mapping: [CSV](detailed/analysis-to-design-mapping.csv). Interaction responsibility mapping: [CSV](detailed/interaction-to-design-mapping.csv).

## Detailed Design Class Diagrams

Each editable master contains multiple pages. Page 1 is the connected VOPC-to-design realization, with source analysis class and applied solution tagged on each classifier. DTO contracts are connected by usage dependencies, and processing/repository classes depend on entity types. Member excerpts keep this complete collaboration view readable. Page 2 shows Web View classes, page 3 Mobile classes, and the subsequent full-detail pages provide complete attributes/operations. Package ownership is traced in a separate mapping; no package is displayed in the diagrams. Later pages show API/controller/service/repository injection, participating entities, request/response contracts and applicable transition classes. Shared types are the same classifier wherever projected; repeated appearances are not separate implementations.

| Use case / shared concern | Editable master | Pages |
|---|---|---|
| UC-C01 Browse and Search Products | [uc-c01-browse-search-design-classes.drawio](../diagrams/class/uc-c01-browse-search-design-classes.drawio) | 6 |
| UC-C03 Manage Shopping Cart | [uc-c03-manage-cart-design-classes.drawio](../diagrams/class/uc-c03-manage-cart-design-classes.drawio) | 6 |
| UC-C05 Manage Profile and Addresses | [uc-c05-profile-addresses-design-classes.drawio](../diagrams/class/uc-c05-profile-addresses-design-classes.drawio) | 6 |
| UC-C06 Checkout and Place Order | [uc-c06-checkout-design-classes.drawio](../diagrams/class/uc-c06-checkout-design-classes.drawio) | 11 |
| UC-C07 Manage My Orders | [uc-c07-my-orders-design-classes.drawio](../diagrams/class/uc-c07-my-orders-design-classes.drawio) | 11 |
| Shared DI and transaction adapters | [shared-di-design-classes.drawio](../diagrams/class/shared-di-design-classes.drawio) | 13 |
| All 24 state-transition classes | [state-transitions-design-classes.drawio](../diagrams/class/state-transitions-design-classes.drawio) | 8 |

### Rendered page index

| Owner | Page | View | PNG |
|---|---|---|---|
| UC-C01 | 1 | VOPC to Detailed Design Realization | [PNG](../diagrams/images/uc-c01-browse-search-design-classes-01.png) |
| UC-C01 | 2 | Web View Classes | [PNG](../diagrams/images/uc-c01-browse-search-design-classes-02.png) |
| UC-C01 | 3 | Mobile View Classes | [PNG](../diagrams/images/uc-c01-browse-search-design-classes-03.png) |
| UC-C01 | 4 | Application Services and Constructor Injection | [PNG](../diagrams/images/uc-c01-browse-search-design-classes-04.png) |
| UC-C01 | 5 | Participating Entities 1 | [PNG](../diagrams/images/uc-c01-browse-search-design-classes-05.png) |
| UC-C01 | 6 | DTO Contracts and Usage 1 | [PNG](../diagrams/images/uc-c01-browse-search-design-classes-06.png) |
| UC-C03 | 1 | VOPC to Detailed Design Realization | [PNG](../diagrams/images/uc-c03-manage-cart-design-classes-01.png) |
| UC-C03 | 2 | Web View Classes | [PNG](../diagrams/images/uc-c03-manage-cart-design-classes-02.png) |
| UC-C03 | 3 | Mobile View Classes | [PNG](../diagrams/images/uc-c03-manage-cart-design-classes-03.png) |
| UC-C03 | 4 | Application Services and Constructor Injection | [PNG](../diagrams/images/uc-c03-manage-cart-design-classes-04.png) |
| UC-C03 | 5 | Participating Entities 1 | [PNG](../diagrams/images/uc-c03-manage-cart-design-classes-05.png) |
| UC-C03 | 6 | DTO Contracts and Usage 1 | [PNG](../diagrams/images/uc-c03-manage-cart-design-classes-06.png) |
| UC-C05 | 1 | VOPC to Detailed Design Realization | [PNG](../diagrams/images/uc-c05-profile-addresses-design-classes-01.png) |
| UC-C05 | 2 | Web View Classes | [PNG](../diagrams/images/uc-c05-profile-addresses-design-classes-02.png) |
| UC-C05 | 3 | Mobile View Classes | [PNG](../diagrams/images/uc-c05-profile-addresses-design-classes-03.png) |
| UC-C05 | 4 | Application Services and Constructor Injection | [PNG](../diagrams/images/uc-c05-profile-addresses-design-classes-04.png) |
| UC-C05 | 5 | Participating Entities 1 | [PNG](../diagrams/images/uc-c05-profile-addresses-design-classes-05.png) |
| UC-C05 | 6 | DTO Contracts and Usage 1 | [PNG](../diagrams/images/uc-c05-profile-addresses-design-classes-06.png) |
| UC-C06 | 1 | VOPC to Detailed Design Realization | [PNG](../diagrams/images/uc-c06-checkout-design-classes-01.png) |
| UC-C06 | 2 | Web View Classes | [PNG](../diagrams/images/uc-c06-checkout-design-classes-02.png) |
| UC-C06 | 3 | Mobile View Classes | [PNG](../diagrams/images/uc-c06-checkout-design-classes-03.png) |
| UC-C06 | 4 | Application Services and Constructor Injection | [PNG](../diagrams/images/uc-c06-checkout-design-classes-04.png) |
| UC-C06 | 5 | Participating Entities 1 | [PNG](../diagrams/images/uc-c06-checkout-design-classes-05.png) |
| UC-C06 | 6 | Participating Entities 2 | [PNG](../diagrams/images/uc-c06-checkout-design-classes-06.png) |
| UC-C06 | 7 | Participating Entities 3 | [PNG](../diagrams/images/uc-c06-checkout-design-classes-07.png) |
| UC-C06 | 8 | DTO Contracts and Usage 1 | [PNG](../diagrams/images/uc-c06-checkout-design-classes-08.png) |
| UC-C06 | 9 | DTO Contracts and Usage 2 | [PNG](../diagrams/images/uc-c06-checkout-design-classes-09.png) |
| UC-C06 | 10 | State Transition Realizations 1 | [PNG](../diagrams/images/uc-c06-checkout-design-classes-10.png) |
| UC-C06 | 11 | State Transition Realizations 2 | [PNG](../diagrams/images/uc-c06-checkout-design-classes-11.png) |
| UC-C07 | 1 | VOPC to Detailed Design Realization | [PNG](../diagrams/images/uc-c07-my-orders-design-classes-01.png) |
| UC-C07 | 2 | Web View Classes | [PNG](../diagrams/images/uc-c07-my-orders-design-classes-02.png) |
| UC-C07 | 3 | Mobile View Classes | [PNG](../diagrams/images/uc-c07-my-orders-design-classes-03.png) |
| UC-C07 | 4 | Application Services and Constructor Injection | [PNG](../diagrams/images/uc-c07-my-orders-design-classes-04.png) |
| UC-C07 | 5 | Participating Entities 1 | [PNG](../diagrams/images/uc-c07-my-orders-design-classes-05.png) |
| UC-C07 | 6 | Participating Entities 2 | [PNG](../diagrams/images/uc-c07-my-orders-design-classes-06.png) |
| UC-C07 | 7 | Participating Entities 3 | [PNG](../diagrams/images/uc-c07-my-orders-design-classes-07.png) |
| UC-C07 | 8 | Participating Entities 4 | [PNG](../diagrams/images/uc-c07-my-orders-design-classes-08.png) |
| UC-C07 | 9 | DTO Contracts and Usage 1 | [PNG](../diagrams/images/uc-c07-my-orders-design-classes-09.png) |
| UC-C07 | 10 | DTO Contracts and Usage 2 | [PNG](../diagrams/images/uc-c07-my-orders-design-classes-10.png) |
| UC-C07 | 11 | State Transition Realizations 1 | [PNG](../diagrams/images/uc-c07-my-orders-design-classes-11.png) |
| shared | 1 | Transaction and Gateway Adapters | [PNG](../diagrams/images/shared-di-design-classes-01.png) |
| shared | 2 | External Adapter geocoding | [PNG](../diagrams/images/shared-di-design-classes-02.png) |
| shared | 3 | External Adapter distance | [PNG](../diagrams/images/shared-di-design-classes-03.png) |
| shared | 4 | External Adapter payment | [PNG](../diagrams/images/shared-di-design-classes-04.png) |
| shared | 5 | External Adapter notification | [PNG](../diagrams/images/shared-di-design-classes-05.png) |
| shared | 6 | State Transition Dispatch | [PNG](../diagrams/images/shared-di-design-classes-06.png) |
| shared | 7 | Transition Command and Trusted Snapshot | [PNG](../diagrams/images/shared-di-design-classes-07.png) |
| shared | 8 | Unresolved Provider and Notification Seams | [PNG](../diagrams/images/shared-di-design-classes-08.png) |
| shared | 9 | Shared Results and Delivery Agent | [PNG](../diagrams/images/shared-di-design-classes-09.png) |
| shared | 10 | Composition Root and Domain Enumerations | [PNG](../diagrams/images/shared-di-design-classes-10.png) |
| shared | 11 | Domain Policies and Exact VND Values | [PNG](../diagrams/images/shared-di-design-classes-11.png) |
| shared | 12 | Distance and FEFO Specification | [PNG](../diagrams/images/shared-di-design-classes-12.png) |
| shared | 13 | Node Runtime and Wire Contracts | [PNG](../diagrams/images/shared-di-design-classes-13.png) |
| transitions | 1 | One Class per Transition 1 | [PNG](../diagrams/images/state-transitions-design-classes-01.png) |
| transitions | 2 | One Class per Transition 2 | [PNG](../diagrams/images/state-transitions-design-classes-02.png) |
| transitions | 3 | One Class per Transition 3 | [PNG](../diagrams/images/state-transitions-design-classes-03.png) |
| transitions | 4 | One Class per Transition 4 | [PNG](../diagrams/images/state-transitions-design-classes-04.png) |
| transitions | 5 | One Class per Transition 5 | [PNG](../diagrams/images/state-transitions-design-classes-05.png) |
| transitions | 6 | One Class per Transition 6 | [PNG](../diagrams/images/state-transitions-design-classes-06.png) |
| transitions | 7 | One Class per Transition 7 | [PNG](../diagrams/images/state-transitions-design-classes-07.png) |
| transitions | 8 | One Class per Transition 8 | [PNG](../diagrams/images/state-transitions-design-classes-08.png) |

## Detailed Class Specifications

[Full class specifications](detailed/class-specifications.md) contain all 181 classifiers, constructor dependencies, attribute visibility, typed operations and interface realizations. [Machine-readable class model](detailed/detailed-class-model.json) is a generation/verification input; the Draw.io files remain the editable diagram masters.

View class ownership and backend-only DI correction: [review](detailed/view-layer-consistency.md) / [mapping](detailed/view-layer-class-mapping.csv).

View package correction and class allocation: [review](detailed/view-layer-consistency.md) / [mapping](detailed/view-layer-class-mapping.csv).

Runtime and design-solution audit: [review](detailed/architecture-realization-review.md).

View package correction and class allocation: [review](detailed/view-layer-consistency.md) / [mapping](detailed/view-layer-class-mapping.csv).

DTO/entity relationship conventions: [review](detailed/dto-entity-relationship-review.md) / [usage mapping](detailed/dto-entity-dependency-mapping.csv).

## Dependency injection design

Controllers consume service interfaces. Services consume repository, identity and gateway interfaces. Concrete repository implementations share one scoped IRepositorySession and IUnitOfWork; they do not reference API DTOs, services or controllers. API service implementations map entities to DTOs. The selected backend runtime is Node.js. Backend and Web async contracts use Promise and Node cancellation uses AbortSignal; Mobile uses Future. Typed UML signatures do not select TypeScript, an HTTP framework, a DI container library or a PostgreSQL driver. DTO names in client signatures denote platform-local JSON projections, not imported backend classes. Page classifiers represent React page/component responsibilities. Frontend classes hold concrete collaborators through normal object/module/widget lifecycle; frontend injection constructors, client DI interfaces and client DI registrations are removed.

ApiCompositionRoot registers service and repository implementations, adapters and IEnumerable<IStateTransition>. Business services never call IServiceProvider/GetService. TransitionExecutor materializes a dictionary keyed by transition ID, rejects duplicate IDs and dispatches through IStateTransition. Transition IDs are source-model IDs, not client-authorized operation names. Constructor injection and runtime authorization solve different problems. Client-visible operations cannot submit a verified-payment callback or trusted guard facts. PaymentNoticeHandler represents the server adapter and calls ICheckoutService; there is no PaymentBoundary-to-CheckoutController dependency.

[Registration and lifetime matrix](detailed/dependency-injection-registrations.csv). API business services, repository instances, transaction session and transition handlers are scoped together. Stateless configured HttpClient transports are supplied by startup; no lifetime claim about a selected HTTP library/version is imposed. Only backend implementations appear in the DI registration matrix. Frontend associations denote ordinary collaboration; labeled HTTPS associations denote remote communication rather than a server object stored in the client.

## One class per state transition

Every one of the 24 existing transitions has a distinct concrete IStateTransition implementation. This is a transition-handler design, rather than one class per state. UC-C01, UC-C03 and UC-C05 have no approved lifecycle state machine; ordinary method calls are not invented as new state transitions. Staff approval, dispatch, returns and financial settlement transitions are shared lifecycle support, not newly invented customer use cases.

| Transition | Concrete class | Source -> target | Trigger / guard |
|---|---|---|---|
| I00 | `AcceptOrderTransition` | initial -> payment_choice | acceptOrder / reserve stock atomically |
| T01u | `EnterPendingUnpaidTransition` | payment_choice -> pending_unpaid | [not paid at checkout] |
| T01p | `EnterPendingPaidTransition` | payment_choice -> pending_paid | [verified paid at checkout] |
| T02u | `ApprovePendingUnpaidTransition` | pending_unpaid -> confirmed | approveOrder; [not first order OR phone confirmed] |
| T02p | `ApprovePendingPaidTransition` | pending_paid -> confirmed | approveOrder; [staff approval] |
| T03 | `StartPackingTransition` | confirmed -> packing | startPacking |
| T04 | `DispatchOrderTransition` | packing -> shipping | dispatchOrder; [documents and assigned agent] |
| T05 | `DeliverOrderTransition` | shipping -> delivered | deliverySuccess |
| T06 | `FailDeliveryTransition` | shipping -> delivery_failed | deliveryFailure; [reason recorded] |
| T07 | `ReceiveReturnedOrderTransition` | delivery_failed -> returned | confirmReturnReceipt; [all goods received] |
| T08u | `CancelPendingUnpaidTransition` | pending_unpaid -> cancelled | cancelOrder; [customer OR staff cancels; unconfirmed first unpaid order] |
| T08p | `CancelPendingPaidTransition` | pending_paid -> cancelled | cancelOrder [customer confirms] |
| T09 | `CancelConfirmedOrderTransition` | confirmed -> cancelled | cancelOrder [customer confirms] |
| F_delivered | `CompleteDeliveredFulfillmentTransition` | delivered -> final_delivered | Completion transition |
| F_returned | `CompleteReturnedFulfillmentTransition` | returned -> final_returned | Completion transition |
| F_cancelled | `CompleteCancelledFulfillmentTransition` | cancelled -> final_cancelled | Completion transition |
| R01 | `ObserveRefundCandidateTransition` | refund_initial -> awaiting | observe refund candidate |
| R02 | `StartEligibleRefundTransition` | awaiting -> processing | receiptAndCauseConfirmed; [paid goods AND complete return; AND cause confirmed; no duplicate]; / refund original allocations by policy |
| R03 | `ConfirmRefundSettlementTransition` | processing -> completed | refundSettlementConfirmed; / record actual completed refund |
| R04 | `RecordUncertainRefundTransition` | processing -> unresolved | refundRejected OR; settlementUncertain; / do not mark refund completed |
| P01 | `InitializeUnpaidPaymentTransition` | pay_initial -> unpaid | createOrder |
| P02 | `CaptureVerifiedPaymentTransition` | unpaid -> paid | verifiedSePayNotification; [order matches AND amount >= total]; / record captured payment |
| P03 | `MarkPartialRefundTransition` | paid -> partially_refunded | refundSettlementConfirmed; [0 < cumulative refund < captured]; / record retained fee and goods refund |
| P04 | `MarkFullRefundTransition` | paid -> refunded | refundSettlementConfirmed; [cumulative refund = captured]; / record full refunded amount |

[Full transition mapping](detailed/state-transition-class-mapping.csv). Completion handlers only finish the fulfillment region. They never write a Final status, delete the order or assert a settled refund. I00 and T01u/T01p represent the common acceptOrder and guarded initial-entry steps: all execute in the same checkout transaction, with exactly one initial branch selected. There is no Pending parent and no PendingUnpaid -> PendingPaid transition.

### Transaction and concurrency responsibilities

1. Resolve principal/ownership from trusted server context. Caller IDs and guard facts are never accepted as authority from DTOs.

2. At checkout, lock all sellable FEFO batches deterministically, validate every requested quantity and calculate original goods/shipping allocations. AcceptOrderTransition, exactly one initial-entry handler and the initial payment write join the existing checkout unit of work; order, lines, reservations and cart clear commit together. A shortage rolls everything back. No backorder is accepted. A pre-acceptance payment reference may be a technical in-memory/correlation token; persistence/provider correlation details need design review and do not create a new order state.

3. TransitionExecutor.ExecuteAsync starts a unit of work for a standalone transition. ExecuteInCurrentTransactionAsync receives the trusted transaction-local snapshot and joins an already active checkout/cancellation unit of work; it must not start or commit a nested transaction. For existing aggregates, load authoritative records under lock and construct a trusted snapshot. For initial acceptance there is no persisted order yet: CheckoutService supplies the server-prepared checkout snapshot and transient workflow position, and the common accept/selected-entry handlers run in that same transaction. The executor updates only the transaction-local UML workflow position until the chosen initial OrderStatus is persisted. Never try to read a nonexistent initial order as an accepted Pending record. Validate source/event/ownership/guards before applying the handler; pass that snapshot to ExecuteAsync as well as CanExecute. Domain methods also check expected state.

4. Deduplicate using aggregate ID, event ID AND transition ID, so common accept and initial-entry steps for one event are not mistaken for duplicates. Provider-payment dedup uses the existing channel/provider reference uniqueness. Durable generic transition-event storage/version scheme remains a technical design decision; no unapproved table is added here.

5. Cancellation rechecks current state under the same order lock as staff progression. Only PendingUnpaid, PendingPaid and Confirmed are eligible; release original reservations exactly once, record the specified audit and commit together. A paid cancellation does not trigger an invented refund policy. Customer audit identity storage is unresolved because the current audit catalog has a staff reference; never impersonate a staff member.

6. Failed delivery records cause/evidence. ReceiveReturnedOrderTransition requires every original line fully received. Staff inspection/disposition remains separate. Product fault refunds captured goods and shipping; confirmed deliberate refusal refunds goods only and retains paid shipping, or records shipping owed/actually collected directly for unpaid goods. Shipping-only cash never sets goods Paid.

7. StartEligibleRefundTransition requires captured goods, complete receipt, confirmed applicable cause and no duplicate obligation; quality inspection is not a guard. Persist the refund obligation transactionally before any provider call. Do not keep row locks or a database transaction open during an external payout. A post-commit worker/dispatcher may invoke IPayoutPort with the durable refund idempotency key; scheduling/retry policy is TBD and no outbox table is silently added. UnconfiguredPayoutAdapter blocks outgoing transfer pending provider approval. R03/P03/P04 only apply verified settlement evidence and actual amounts; uncertain results never become completed refunds.

8. Publish existing UI/staff notifications after commit; a publish failure cannot roll back a committed order. Notification retry/durable-delivery guarantees remain TBD. Re-order uses current stock/prices, not historical batch reservations. Reviews require owned Delivered order, 1-5 rating and one review per order. Default-address changes and active-address deletion guards must be atomic within the existing profile unit of work.

## Source conflicts and unresolved decisions

- The old UC-C06 normal step 8 and old UC-C07 cancellation clause still contain Pending, while later stakeholder decisions require two independent initial states. This design follows the explicit stakeholder correction and flags the older clauses for controlled reconciliation; it does not renumber use cases. Old sequence pages are inputs, not approved new design sequences.

- Mandatory telephone confirmation applies only to first unpaid orders. Later capture on an already accepted PendingUnpaid order does not imply an order-state transition. Late-payment fulfillment handling is TBD.

- Outgoing refund provider/API, final fault-confirmation authority, product-fault courier compensation payer/rate, partial returns/payments, prepaid cancellation refunds, excess/late payments and retry/reconciliation rules remain TBD. The handler exists where the source model specifies a transition, but unresolved actions are blocked rather than implemented with invented policy.

- Historical FR aliases and UC-C01.3 reuse remain source traceability issues. Use-case and message IDs are retained. Guest cart session identity is maintained without asserting an authenticated guest.

- Audit storage for customer cancellation, optimistic version representation and durable transition-event evidence need approved schema mapping. Repository interfaces are proposed design seams, not proof that all signatures already have database implementations. No synthetic code/test-pass claim is made.

## Review and verification gate

The project master template was inspected for Analysis-to-Design Class Mapping, Detailed Design Class Diagrams and Detailed Class Specifications. The design checklist d4_Checklist_Design Review.xls was read locally. See [review findings](detailed/design-review.md) and [verification](detailed/design-verification.json).

The new technical design is submitted for Architect/Technical Lead and stakeholder review. Per AGENTS.md sections 2.1 and 2.6, only after explicit design approval are these new diagrams, mappings and class specifications integrated into Chapter V of Requirements_Analysis_Design_Specification.docx and treated as an implementation baseline. The current master is not silently baselined with unapproved new technical classes. No implementation, database migration or test execution was performed by this task.

Layout revision: [review](detailed/layout-review.md) / [geometry verification](detailed/layout-verification.json). Class/member and relationship semantics are unchanged.

Design interactions: [Design Sequence Diagrams](design-sequence-diagrams.md) ? separate draft realization using these class contracts.
