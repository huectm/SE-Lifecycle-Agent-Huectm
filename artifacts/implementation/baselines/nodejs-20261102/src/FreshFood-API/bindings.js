export const bindings = [
  {
    "Contract": "ICatalogService",
    "Implementation": "CatalogService",
    "Lifetime": "Scoped per API request / transaction",
    "Composition Root": "ApiCompositionRoot",
    "Status": "Authorized table-driven replacement; backend implementation review"
  },
  {
    "Contract": "ICatalogRepository",
    "Implementation": "CatalogRepository",
    "Lifetime": "Scoped per API request / transaction",
    "Composition Root": "ApiCompositionRoot",
    "Status": "Authorized table-driven replacement; backend implementation review"
  },
  {
    "Contract": "IBatchPricingPolicy",
    "Implementation": "BatchPricingPolicy",
    "Lifetime": "Scoped per API request / transaction",
    "Composition Root": "ApiCompositionRoot",
    "Status": "Authorized table-driven replacement; backend implementation review"
  },
  {
    "Contract": "ICartService",
    "Implementation": "CartService",
    "Lifetime": "Scoped per API request / transaction",
    "Composition Root": "ApiCompositionRoot",
    "Status": "Authorized table-driven replacement; backend implementation review"
  },
  {
    "Contract": "ICartRepository",
    "Implementation": "CartRepository",
    "Lifetime": "Scoped per API request / transaction",
    "Composition Root": "ApiCompositionRoot",
    "Status": "Authorized table-driven replacement; backend implementation review"
  },
  {
    "Contract": "IProfileService",
    "Implementation": "ProfileService",
    "Lifetime": "Scoped per API request / transaction",
    "Composition Root": "ApiCompositionRoot",
    "Status": "Authorized table-driven replacement; backend implementation review"
  },
  {
    "Contract": "IProfileRepository",
    "Implementation": "ProfileRepository",
    "Lifetime": "Scoped per API request / transaction",
    "Composition Root": "ApiCompositionRoot",
    "Status": "Authorized table-driven replacement; backend implementation review"
  },
  {
    "Contract": "IGeocodingGateway",
    "Implementation": "GoogleMapsGeocodingAdapter",
    "Lifetime": "Scoped per API request / transaction",
    "Composition Root": "ApiCompositionRoot",
    "Status": "Authorized table-driven replacement; backend implementation review"
  },
  {
    "Contract": "ICheckoutService",
    "Implementation": "CheckoutService",
    "Lifetime": "Scoped per API request / transaction",
    "Composition Root": "ApiCompositionRoot",
    "Status": "Authorized table-driven replacement; backend implementation review"
  },
  {
    "Contract": "ICheckoutRepository",
    "Implementation": "CheckoutRepository",
    "Lifetime": "Scoped per API request / transaction",
    "Composition Root": "ApiCompositionRoot",
    "Status": "Authorized table-driven replacement; backend implementation review"
  },
  {
    "Contract": "IOrderStateMachine",
    "Implementation": "OrderStateMachine",
    "Lifetime": "Scoped per API request / transaction",
    "Composition Root": "ApiCompositionRoot",
    "Status": "Authorized table-driven replacement; backend implementation review"
  },
  {
    "Contract": "IDistanceGateway",
    "Implementation": "GoogleMapsDistanceAdapter",
    "Lifetime": "Scoped per API request / transaction",
    "Composition Root": "ApiCompositionRoot",
    "Status": "Authorized table-driven replacement; backend implementation review"
  },
  {
    "Contract": "IPaymentGateway",
    "Implementation": "SePayPaymentAdapter",
    "Lifetime": "Scoped per API request / transaction",
    "Composition Root": "ApiCompositionRoot",
    "Status": "Authorized table-driven replacement; backend implementation review"
  },
  {
    "Contract": "INotificationGateway",
    "Implementation": "NotificationAdapter",
    "Lifetime": "Scoped per API request / transaction",
    "Composition Root": "ApiCompositionRoot",
    "Status": "Authorized table-driven replacement; backend implementation review"
  },
  {
    "Contract": "IDeliveryFeePolicy",
    "Implementation": "DeliveryFeePolicy",
    "Lifetime": "Scoped per API request / transaction",
    "Composition Root": "ApiCompositionRoot",
    "Status": "Authorized table-driven replacement; backend implementation review"
  },
  {
    "Contract": "IDistanceCalculator",
    "Implementation": "DistanceCalculator",
    "Lifetime": "Scoped per API request / transaction",
    "Composition Root": "ApiCompositionRoot",
    "Status": "Authorized table-driven replacement; backend implementation review"
  },
  {
    "Contract": "IFefoBatchSpecification",
    "Implementation": "FefoBatchSpecification",
    "Lifetime": "Scoped per API request / transaction",
    "Composition Root": "ApiCompositionRoot",
    "Status": "Authorized table-driven replacement; backend implementation review"
  },
  {
    "Contract": "IMyOrdersService",
    "Implementation": "MyOrdersService",
    "Lifetime": "Scoped per API request / transaction",
    "Composition Root": "ApiCompositionRoot",
    "Status": "Authorized table-driven replacement; backend implementation review"
  },
  {
    "Contract": "IMyOrdersRepository",
    "Implementation": "MyOrdersRepository",
    "Lifetime": "Scoped per API request / transaction",
    "Composition Root": "ApiCompositionRoot",
    "Status": "Authorized table-driven replacement; backend implementation review"
  },
  {
    "Contract": "IUnitOfWork",
    "Implementation": "UnitOfWork",
    "Lifetime": "Scoped per API request / transaction",
    "Composition Root": "ApiCompositionRoot",
    "Status": "Authorized table-driven replacement; backend implementation review"
  },
  {
    "Contract": "IRepositorySession",
    "Implementation": "PostgreSqlSession",
    "Lifetime": "Scoped per API request / transaction",
    "Composition Root": "ApiCompositionRoot",
    "Status": "Authorized table-driven replacement; backend implementation review"
  },
  {
    "Contract": "ICurrentCustomer",
    "Implementation": "CurrentCustomer",
    "Lifetime": "Scoped per API request / transaction",
    "Composition Root": "ApiCompositionRoot",
    "Status": "Authorized table-driven replacement; backend implementation review"
  },
  {
    "Contract": "IOrderLifecycleRepository",
    "Implementation": "OrderLifecycleRepository",
    "Lifetime": "Scoped per API request / transaction",
    "Composition Root": "ApiCompositionRoot",
    "Status": "Authorized table-driven replacement; backend implementation review"
  },
  {
    "Contract": "IPayoutPort",
    "Implementation": "UnconfiguredPayoutAdapter",
    "Lifetime": "Scoped per API request / transaction",
    "Composition Root": "ApiCompositionRoot",
    "Status": "Authorized table-driven replacement; backend implementation review"
  },
  {
    "Contract": "INotificationPublisher",
    "Implementation": "ConfiguredNotificationPublisher",
    "Lifetime": "Scoped per API request / transaction",
    "Composition Root": "ApiCompositionRoot",
    "Status": "Authorized table-driven replacement; backend implementation review"
  }
];
export const constructors = {
  "UnitOfWork": [
    "IRepositorySession"
  ],
  "PostgreSqlSession": [
    "DatabaseConnection"
  ],
  "CurrentCustomer": [
    "AuthenticatedPrincipal"
  ],
  "GoogleMapsGeocodingAdapter": [
    "HttpTransport"
  ],
  "GoogleMapsDistanceAdapter": [
    "HttpTransport"
  ],
  "SePayPaymentAdapter": [
    "HttpTransport"
  ],
  "NotificationAdapter": [
    "INotificationPublisher"
  ],
  "CatalogService": [
    "ICatalogRepository",
    "IBatchPricingPolicy"
  ],
  "CatalogController": [
    "ICatalogService"
  ],
  "CatalogRepository": [
    "IRepositorySession"
  ],
  "CartService": [
    "ICartRepository",
    "ICurrentCustomer",
    "IUnitOfWork",
    "IBatchPricingPolicy"
  ],
  "CartController": [
    "ICartService"
  ],
  "CartRepository": [
    "IRepositorySession"
  ],
  "ProfileService": [
    "IProfileRepository",
    "ICurrentCustomer",
    "IUnitOfWork",
    "IGeocodingGateway"
  ],
  "ProfileController": [
    "IProfileService"
  ],
  "ProfileRepository": [
    "IRepositorySession"
  ],
  "CheckoutService": [
    "ICheckoutRepository",
    "ICurrentCustomer",
    "IUnitOfWork",
    "IDistanceCalculator",
    "IPaymentGateway",
    "INotificationGateway",
    "IOrderStateMachine",
    "IBatchPricingPolicy",
    "IDeliveryFeePolicy"
  ],
  "CheckoutController": [
    "ICheckoutService"
  ],
  "CheckoutRepository": [
    "IRepositorySession",
    "IFefoBatchSpecification"
  ],
  "MyOrdersService": [
    "IMyOrdersRepository",
    "ICurrentCustomer",
    "IUnitOfWork",
    "INotificationGateway",
    "IOrderStateMachine",
    "IBatchPricingPolicy"
  ],
  "MyOrdersController": [
    "IMyOrdersService"
  ],
  "MyOrdersRepository": [
    "IRepositorySession"
  ],
  "OrderLifecycleRepository": [
    "IRepositorySession"
  ],
  "PaymentNoticeHandler": [
    "ICheckoutService",
    "IPaymentGateway"
  ],
  "ConfiguredNotificationPublisher": [
    "HttpTransport"
  ],
  "DistanceCalculator": [
    "IDistanceGateway"
  ],
  "OrderStateMachine": [
    "IOrderLifecycleRepository"
  ]
};
