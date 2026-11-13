# Detailed Design Class Diagrams

Version: 0.6 | Date: 2026-11-03 | Status: revised under explicit stakeholder selection.

The table-driven OrderStateMachine replaces the earlier individual transition implementation classes. Its private table represents all 24 existing transitions. Services submit business events through ProcessEventAsync; CurrentState returns the current managed state. There are no per-transition implementation classes or collection registrations in the active model/source.

The selected implementation keeps backend-only constructor DI, the Web Pages/CallService and Mobile Views/ViewModels/Models refinements, explicit DTO relationships, Entity usage dependencies and interface realizations. Package containers remain excluded. Architecture component names and the five use-case IDs remain unchanged.

## State-machine control design

[Control design and decision record](detailed/order-state-machine-control-design.md). The earlier per-transition model and editable sources are archived under baselines/per-transition-20261101. Transition IDs now identify private table rows and durable execution evidence, not implementation classes. UML choice/final nodes do not introduce persistent business statuses.

## Analysis to design mapping

| Analysis Class | Design Class / Component | Mapping Rationale |
|---|---|---|
| UC-C01 / CatalogView | CatalogPage; CatalogApiClient; CatalogView; CatalogViewModel; CatalogApiModel | Web Pages / CallService; mobile MVVM; no frontend DI |
| UC-C01 / CatalogController | CatalogController | API controller retained; service interface supplied by backend DI |
| UC-C01 / CatalogService | ICatalogService; CatalogService; ICatalogRepository; CatalogRepository; IBatchPricingPolicy; BatchPricingPolicy | Layered application logic + service interface extraction + Repository / domain policies / backend DI |
| UC-C01 / ProductCategory | ProductCategory | Domain entity retained; navigations and invariants refined from data requirements |
| UC-C01 / Product | Product | Domain entity retained; navigations and invariants refined from data requirements |
| UC-C01 / BatchInventory | BatchInventory | Domain entity retained; navigations and invariants refined from data requirements |
| UC-C03 / CartView | CartPage; CartApiClient; CartView; CartViewModel; CartApiModel | Web Pages / CallService; mobile MVVM; no frontend DI |
| UC-C03 / CartController | CartController | API controller retained; service interface supplied by backend DI |
| UC-C03 / CartService | ICartService; CartService; ICartRepository; CartRepository; IBatchPricingPolicy; BatchPricingPolicy | Layered application logic + service interface extraction + Repository / domain policies / backend DI |
| UC-C03 / Cart | Cart | Domain entity retained; navigations and invariants refined from data requirements |
| UC-C03 / CartItem | CartItem | Domain entity retained; navigations and invariants refined from data requirements |
| UC-C03 / Product | Product | Domain entity retained; navigations and invariants refined from data requirements |
| UC-C03 / BatchInventory | BatchInventory | Domain entity retained; navigations and invariants refined from data requirements |
| UC-C05 / ProfileAddressView | ProfilePage; ProfileApiClient; ProfileAddressView; ProfileViewModel; ProfileApiModel | Web Pages / CallService; mobile MVVM; no frontend DI |
| UC-C05 / ProfileController | ProfileController | API controller retained; service interface supplied by backend DI |
| UC-C05 / ProfileService | IProfileService; ProfileService; IProfileRepository; ProfileRepository | Layered application logic + service interface extraction + Repository / domain policies / backend DI |
| UC-C05 / Customer | Customer | Domain entity retained; navigations and invariants refined from data requirements |
| UC-C05 / CustomerAddress | CustomerAddress | Domain entity retained; navigations and invariants refined from data requirements |
| UC-C05 / Order | Order | Domain entity retained; navigations and invariants refined from data requirements |
| UC-C05 / GeocodingBoundary | IGeocodingGateway; GoogleMapsGeocodingAdapter | Adapter / backend DI |
| UC-C06 / CheckoutView | CheckoutPage; CheckoutApiClient; CheckoutView; CheckoutViewModel; CheckoutApiModel | Web Pages / CallService; mobile MVVM; no frontend DI |
| UC-C06 / CheckoutController | CheckoutController | API controller retained; service interface supplied by backend DI |
| UC-C06 / CheckoutService | ICheckoutService; CheckoutService; ICheckoutRepository; CheckoutRepository; IBatchPricingPolicy; BatchPricingPolicy; IDeliveryFeePolicy; DeliveryFeePolicy; IFefoBatchSpecification; FefoBatchSpecification | Layered application logic + service interface extraction + Repository / domain policies / backend DI |
| UC-C06 / Customer | Customer | Domain entity retained; navigations and invariants refined from data requirements |
| UC-C06 / CustomerAddress | CustomerAddress | Domain entity retained; navigations and invariants refined from data requirements |
| UC-C06 / Cart | Cart | Domain entity retained; navigations and invariants refined from data requirements |
| UC-C06 / CartItem | CartItem | Domain entity retained; navigations and invariants refined from data requirements |
| UC-C06 / Product | Product | Domain entity retained; navigations and invariants refined from data requirements |
| UC-C06 / BatchInventory | BatchInventory | Domain entity retained; navigations and invariants refined from data requirements |
| UC-C06 / Order | Order | Domain entity retained; navigations and invariants refined from data requirements |
| UC-C06 / OrderDetail | OrderDetail | Domain entity retained; navigations and invariants refined from data requirements |
| UC-C06 / DistanceBoundary | IDistanceCalculator; DistanceCalculator; IDistanceGateway; GoogleMapsDistanceAdapter | Adapter / backend DI |
| UC-C06 / PaymentBoundary | IPaymentGateway; SePayPaymentAdapter; PaymentNoticeHandler | Adapter / backend DI |
| UC-C06 / NotificationBoundary | INotificationGateway; NotificationAdapter | Adapter / backend DI |
| UC-C07 / MyOrdersView | MyOrdersPage; MyOrdersApiClient; MyOrdersView; MyOrdersViewModel; MyOrdersApiModel | Web Pages / CallService; mobile MVVM; no frontend DI |
| UC-C07 / MyOrdersController | MyOrdersController | API controller retained; service interface supplied by backend DI |
| UC-C07 / MyOrdersService | IMyOrdersService; MyOrdersService; IMyOrdersRepository; MyOrdersRepository; IBatchPricingPolicy; BatchPricingPolicy | Layered application logic + service interface extraction + Repository / domain policies / backend DI |
| UC-C07 / Customer | Customer | Domain entity retained; navigations and invariants refined from data requirements |
| UC-C07 / Order | Order | Domain entity retained; navigations and invariants refined from data requirements |
| UC-C07 / OrderDetail | OrderDetail | Domain entity retained; navigations and invariants refined from data requirements |
| UC-C07 / CustomerAddress | CustomerAddress | Domain entity retained; navigations and invariants refined from data requirements |
| UC-C07 / BatchInventory | BatchInventory | Domain entity retained; navigations and invariants refined from data requirements |
| UC-C07 / Product | Product | Domain entity retained; navigations and invariants refined from data requirements |
| UC-C07 / Cart | Cart | Domain entity retained; navigations and invariants refined from data requirements |
| UC-C07 / CartItem | CartItem | Domain entity retained; navigations and invariants refined from data requirements |
| UC-C07 / OrderReview | OrderReview | Domain entity retained; navigations and invariants refined from data requirements |
| UC-C07 / AuditLog | AuditLog | Domain entity retained; navigations and invariants refined from data requirements |
| UC-C07 / OrderNotificationBoundary | INotificationGateway; NotificationAdapter | Adapter / backend DI |

## Editable diagrams and exported images

| Scope | Page | View | Draw.io master | PNG |
|---|---|---|---|---|
| UC-C01 | 1 | VOPC to Detailed Design Realization | [Edit](../diagrams/class/uc-c01-browse-search-design-classes.drawio) | [View](../diagrams/images/uc-c01-browse-search-design-classes-01.png) |
| UC-C01 | 2 | Web View Classes | [Edit](../diagrams/class/uc-c01-browse-search-design-classes.drawio) | [View](../diagrams/images/uc-c01-browse-search-design-classes-02.png) |
| UC-C01 | 3 | Mobile View Classes | [Edit](../diagrams/class/uc-c01-browse-search-design-classes.drawio) | [View](../diagrams/images/uc-c01-browse-search-design-classes-03.png) |
| UC-C01 | 4 | Application Services and Constructor Injection | [Edit](../diagrams/class/uc-c01-browse-search-design-classes.drawio) | [View](../diagrams/images/uc-c01-browse-search-design-classes-04.png) |
| UC-C01 | 5 | Participating Entities 1 | [Edit](../diagrams/class/uc-c01-browse-search-design-classes.drawio) | [View](../diagrams/images/uc-c01-browse-search-design-classes-05.png) |
| UC-C01 | 6 | DTO Contracts and Usage 1 | [Edit](../diagrams/class/uc-c01-browse-search-design-classes.drawio) | [View](../diagrams/images/uc-c01-browse-search-design-classes-06.png) |
| UC-C03 | 1 | VOPC to Detailed Design Realization | [Edit](../diagrams/class/uc-c03-manage-cart-design-classes.drawio) | [View](../diagrams/images/uc-c03-manage-cart-design-classes-01.png) |
| UC-C03 | 2 | Web View Classes | [Edit](../diagrams/class/uc-c03-manage-cart-design-classes.drawio) | [View](../diagrams/images/uc-c03-manage-cart-design-classes-02.png) |
| UC-C03 | 3 | Mobile View Classes | [Edit](../diagrams/class/uc-c03-manage-cart-design-classes.drawio) | [View](../diagrams/images/uc-c03-manage-cart-design-classes-03.png) |
| UC-C03 | 4 | Application Services and Constructor Injection | [Edit](../diagrams/class/uc-c03-manage-cart-design-classes.drawio) | [View](../diagrams/images/uc-c03-manage-cart-design-classes-04.png) |
| UC-C03 | 5 | Participating Entities 1 | [Edit](../diagrams/class/uc-c03-manage-cart-design-classes.drawio) | [View](../diagrams/images/uc-c03-manage-cart-design-classes-05.png) |
| UC-C03 | 6 | DTO Contracts and Usage 1 | [Edit](../diagrams/class/uc-c03-manage-cart-design-classes.drawio) | [View](../diagrams/images/uc-c03-manage-cart-design-classes-06.png) |
| UC-C05 | 1 | VOPC to Detailed Design Realization | [Edit](../diagrams/class/uc-c05-profile-addresses-design-classes.drawio) | [View](../diagrams/images/uc-c05-profile-addresses-design-classes-01.png) |
| UC-C05 | 2 | Web View Classes | [Edit](../diagrams/class/uc-c05-profile-addresses-design-classes.drawio) | [View](../diagrams/images/uc-c05-profile-addresses-design-classes-02.png) |
| UC-C05 | 3 | Mobile View Classes | [Edit](../diagrams/class/uc-c05-profile-addresses-design-classes.drawio) | [View](../diagrams/images/uc-c05-profile-addresses-design-classes-03.png) |
| UC-C05 | 4 | Application Services and Constructor Injection | [Edit](../diagrams/class/uc-c05-profile-addresses-design-classes.drawio) | [View](../diagrams/images/uc-c05-profile-addresses-design-classes-04.png) |
| UC-C05 | 5 | Participating Entities 1 | [Edit](../diagrams/class/uc-c05-profile-addresses-design-classes.drawio) | [View](../diagrams/images/uc-c05-profile-addresses-design-classes-05.png) |
| UC-C05 | 6 | DTO Contracts and Usage 1 | [Edit](../diagrams/class/uc-c05-profile-addresses-design-classes.drawio) | [View](../diagrams/images/uc-c05-profile-addresses-design-classes-06.png) |
| UC-C06 | 1 | VOPC to Detailed Design Realization | [Edit](../diagrams/class/uc-c06-checkout-design-classes.drawio) | [View](../diagrams/images/uc-c06-checkout-design-classes-01.png) |
| UC-C06 | 2 | Web View Classes | [Edit](../diagrams/class/uc-c06-checkout-design-classes.drawio) | [View](../diagrams/images/uc-c06-checkout-design-classes-02.png) |
| UC-C06 | 3 | Mobile View Classes | [Edit](../diagrams/class/uc-c06-checkout-design-classes.drawio) | [View](../diagrams/images/uc-c06-checkout-design-classes-03.png) |
| UC-C06 | 4 | Application Services and Constructor Injection | [Edit](../diagrams/class/uc-c06-checkout-design-classes.drawio) | [View](../diagrams/images/uc-c06-checkout-design-classes-04.png) |
| UC-C06 | 5 | Participating Entities 1 | [Edit](../diagrams/class/uc-c06-checkout-design-classes.drawio) | [View](../diagrams/images/uc-c06-checkout-design-classes-05.png) |
| UC-C06 | 6 | Participating Entities 2 | [Edit](../diagrams/class/uc-c06-checkout-design-classes.drawio) | [View](../diagrams/images/uc-c06-checkout-design-classes-06.png) |
| UC-C06 | 7 | Participating Entities 3 | [Edit](../diagrams/class/uc-c06-checkout-design-classes.drawio) | [View](../diagrams/images/uc-c06-checkout-design-classes-07.png) |
| UC-C06 | 8 | DTO Contracts and Usage 1 | [Edit](../diagrams/class/uc-c06-checkout-design-classes.drawio) | [View](../diagrams/images/uc-c06-checkout-design-classes-08.png) |
| UC-C06 | 9 | DTO Contracts and Usage 2 | [Edit](../diagrams/class/uc-c06-checkout-design-classes.drawio) | [View](../diagrams/images/uc-c06-checkout-design-classes-09.png) |
| UC-C06 | 10 | State Transition Realizations 1 | [Edit](../diagrams/class/uc-c06-checkout-design-classes.drawio) | [View](../diagrams/images/uc-c06-checkout-design-classes-10.png) |
| UC-C06 | 11 | State Transition Realizations 2 | [Edit](../diagrams/class/uc-c06-checkout-design-classes.drawio) | [View](../diagrams/images/uc-c06-checkout-design-classes-11.png) |
| UC-C07 | 1 | VOPC to Detailed Design Realization | [Edit](../diagrams/class/uc-c07-my-orders-design-classes.drawio) | [View](../diagrams/images/uc-c07-my-orders-design-classes-01.png) |
| UC-C07 | 2 | Web View Classes | [Edit](../diagrams/class/uc-c07-my-orders-design-classes.drawio) | [View](../diagrams/images/uc-c07-my-orders-design-classes-02.png) |
| UC-C07 | 3 | Mobile View Classes | [Edit](../diagrams/class/uc-c07-my-orders-design-classes.drawio) | [View](../diagrams/images/uc-c07-my-orders-design-classes-03.png) |
| UC-C07 | 4 | Application Services and Constructor Injection | [Edit](../diagrams/class/uc-c07-my-orders-design-classes.drawio) | [View](../diagrams/images/uc-c07-my-orders-design-classes-04.png) |
| UC-C07 | 5 | Participating Entities 1 | [Edit](../diagrams/class/uc-c07-my-orders-design-classes.drawio) | [View](../diagrams/images/uc-c07-my-orders-design-classes-05.png) |
| UC-C07 | 6 | Participating Entities 2 | [Edit](../diagrams/class/uc-c07-my-orders-design-classes.drawio) | [View](../diagrams/images/uc-c07-my-orders-design-classes-06.png) |
| UC-C07 | 7 | Participating Entities 3 | [Edit](../diagrams/class/uc-c07-my-orders-design-classes.drawio) | [View](../diagrams/images/uc-c07-my-orders-design-classes-07.png) |
| UC-C07 | 8 | Participating Entities 4 | [Edit](../diagrams/class/uc-c07-my-orders-design-classes.drawio) | [View](../diagrams/images/uc-c07-my-orders-design-classes-08.png) |
| UC-C07 | 9 | DTO Contracts and Usage 1 | [Edit](../diagrams/class/uc-c07-my-orders-design-classes.drawio) | [View](../diagrams/images/uc-c07-my-orders-design-classes-09.png) |
| UC-C07 | 10 | DTO Contracts and Usage 2 | [Edit](../diagrams/class/uc-c07-my-orders-design-classes.drawio) | [View](../diagrams/images/uc-c07-my-orders-design-classes-10.png) |
| UC-C07 | 11 | State Transition Realizations 1 | [Edit](../diagrams/class/uc-c07-my-orders-design-classes.drawio) | [View](../diagrams/images/uc-c07-my-orders-design-classes-11.png) |
| shared | 1 | Transaction and Gateway Adapters | [Edit](../diagrams/class/shared-di-design-classes.drawio) | [View](../diagrams/images/shared-di-design-classes-01.png) |
| shared | 2 | External Adapter geocoding | [Edit](../diagrams/class/shared-di-design-classes.drawio) | [View](../diagrams/images/shared-di-design-classes-02.png) |
| shared | 3 | External Adapter distance | [Edit](../diagrams/class/shared-di-design-classes.drawio) | [View](../diagrams/images/shared-di-design-classes-03.png) |
| shared | 4 | External Adapter payment | [Edit](../diagrams/class/shared-di-design-classes.drawio) | [View](../diagrams/images/shared-di-design-classes-04.png) |
| shared | 5 | External Adapter notification | [Edit](../diagrams/class/shared-di-design-classes.drawio) | [View](../diagrams/images/shared-di-design-classes-05.png) |
| shared | 6 | State Transition Dispatch | [Edit](../diagrams/class/shared-di-design-classes.drawio) | [View](../diagrams/images/shared-di-design-classes-06.png) |
| shared | 7 | Transition Command and Trusted Snapshot | [Edit](../diagrams/class/shared-di-design-classes.drawio) | [View](../diagrams/images/shared-di-design-classes-07.png) |
| shared | 8 | Unresolved Provider and Notification Seams | [Edit](../diagrams/class/shared-di-design-classes.drawio) | [View](../diagrams/images/shared-di-design-classes-08.png) |
| shared | 9 | Shared Results and Delivery Agent | [Edit](../diagrams/class/shared-di-design-classes.drawio) | [View](../diagrams/images/shared-di-design-classes-09.png) |
| shared | 10 | Composition Root and Domain Enumerations | [Edit](../diagrams/class/shared-di-design-classes.drawio) | [View](../diagrams/images/shared-di-design-classes-10.png) |
| shared | 11 | Domain Policies and Exact VND Values | [Edit](../diagrams/class/shared-di-design-classes.drawio) | [View](../diagrams/images/shared-di-design-classes-11.png) |
| shared | 12 | Distance and FEFO Specification | [Edit](../diagrams/class/shared-di-design-classes.drawio) | [View](../diagrams/images/shared-di-design-classes-12.png) |
| shared | 13 | Node Runtime and Wire Contracts | [Edit](../diagrams/class/shared-di-design-classes.drawio) | [View](../diagrams/images/shared-di-design-classes-13.png) |
| transitions | 1 | Order State Machine Control and Private Transition Table | [Edit](../diagrams/class/state-transitions-design-classes.drawio) | [View](../diagrams/images/state-transitions-design-classes-01.png) |

## Class specifications and consistency

[Class specifications](detailed/class-specifications.md) contain attributes, operation signatures, ownership and relationships for all 157 classifiers. [DI bindings](detailed/dependency-injection-registrations.csv) register one IOrderStateMachine implementation; the old IStateTransition collection is removed. [Transition table mapping](detailed/state-transition-class-mapping.csv) preserves all 24 source/target/trigger identities.

[Design sequences](design-sequence-diagrams.md) use the same ProcessEventAsync/CurrentState contracts. The caller owns UnitOfWork; state-machine evaluation, event evidence, domain effects and customer audit commit or roll back together. Customer idempotent replay returns before invoking the state machine.

Payment correlation/provider and staff/return/refund implementation limitations remain explicit. This pattern replacement does not imply that those integrations or use cases are implemented or released. [Storage amendment](database/order-consistency-storage-design.md) documents idempotency and audit migrations.

[Current design verification](detailed/state-machine-design-verification.json). Source implementation and test evidence are recorded separately in ../implementation/order-state-machine-review.md.
