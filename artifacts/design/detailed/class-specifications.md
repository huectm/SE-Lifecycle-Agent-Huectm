# Detailed Class Specifications

Version: 0.6 | 2026-11-03 | Selected solution: table-driven state-machine control.

## IUnitOfWork

Ownership: FreshFood.Reposistory.Repository. Role: interface.

Basis: UC-C06 atomic checkout; UC-C07 atomic cancellation

### Attributes


### Operations

- + ExecuteAsync(work: TransactionWork): Value

### Relationships

- CartService --association--> IUnitOfWork (holds reference)
- CheckoutService --association--> IUnitOfWork (holds reference)
- MyOrdersService --association--> IUnitOfWork (holds reference)
- ProfileService --association--> IUnitOfWork (holds reference)
- UnitOfWork --realization--> IUnitOfWork (implements)

## UnitOfWork

Ownership: FreshFood.Reposistory.Repository.Implements. Role: class.

Basis: Proposed transaction adapter

### Attributes

- - session: IRepositorySession

### Operations

- + UnitOfWork(session: IRepositorySession)
- + ExecuteAsync(work: TransactionWork): Value

### Relationships

- UnitOfWork --association--> IRepositorySession (holds reference)
- UnitOfWork --realization--> IUnitOfWork (implements)

## IRepositorySession

Ownership: FreshFood.Reposistory.Repository. Role: interface.

Basis: Shared scoped transaction; no provider choice imposed

### Attributes


### Operations

- + BeginAsync(): Void
- + CommitAsync(): Void
- + RollbackAsync(): Void
- + QueryAsync(statement: Query, parameters: Sequence<Value>): Sequence<Record>

### Relationships

- RepositorySession --realization--> IRepositorySession (implements)
- UnitOfWork --association--> IRepositorySession (holds reference)

## RepositorySession

Ownership: FreshFood.Reposistory.Repository.Implements. Role: class.

Basis: Existing PostgreSQL; provider factory configured at startup

### Attributes

- - dataSource: ConnectionProvider

### Operations

- + RepositorySession(dataSource: ConnectionProvider)
- + BeginAsync(): Void
- + CommitAsync(): Void
- + RollbackAsync(): Void
- + DisposeAsync(): Void
- + QueryAsync(statement: Query, parameters: Sequence<Value>): Sequence<Record>

### Relationships

- RepositorySession --realization--> IRepositorySession (implements)

## ICurrentCustomer

Ownership: FreshFood-API.Services. Role: interface.

Basis: BR-AUTH-01; guest session variant UC-C03

### Attributes


### Operations

- + RequireCustomerId(): Text
- + GetCartIdentity(): CartIdentityDto

### Relationships

- CartService --association--> ICurrentCustomer (holds reference)
- CheckoutService --association--> ICurrentCustomer (holds reference)
- CurrentCustomer --realization--> ICurrentCustomer (implements)
- ICurrentCustomer --dependency--> CartIdentityDto (uses DTO)
- MyOrdersService --association--> ICurrentCustomer (holds reference)
- ProfileService --association--> ICurrentCustomer (holds reference)

## CurrentCustomer

Ownership: FreshFood-API.Services.Implements. Role: class.

Basis: Server-authenticated principal; session ownership, not request customerId

### Attributes

- - accessor: RequestContext
- - protection: SessionTokenProtector

### Operations

- + CurrentCustomer(accessor: RequestContext, protection: SessionTokenProtector)
- + RequireCustomerId(): Text
- + GetCartIdentity(): CartIdentityDto

### Relationships

- CurrentCustomer --dependency--> CartIdentityDto (uses DTO)
- CurrentCustomer --realization--> ICurrentCustomer (implements)

## OperationResultDto

Ownership: FreshFood-API.DTOs. Role: DTO.

Basis: Existing success/error boundary responses

### Attributes

- + Success: Boolean
- + MessageCode: Text

### Operations


### Relationships

- IMyOrdersService --dependency--> OperationResultDto (uses DTO)
- IProfileService --dependency--> OperationResultDto (uses DTO)
- MyOrdersApiClient --dependency--> OperationResultDto (uses wire DTO)
- MyOrdersApiModel --dependency--> OperationResultDto (uses wire DTO)
- MyOrdersController --dependency--> OperationResultDto (uses DTO)
- MyOrdersService --dependency--> OperationResultDto (uses DTO)
- MyOrdersViewModel --dependency--> OperationResultDto (uses wire DTO)
- ProfileApiClient --dependency--> OperationResultDto (uses wire DTO)
- ProfileApiModel --dependency--> OperationResultDto (uses wire DTO)
- ProfileController --dependency--> OperationResultDto (uses DTO)
- ProfileService --dependency--> OperationResultDto (uses DTO)
- ProfileViewModel --dependency--> OperationResultDto (uses wire DTO)

## IGeocodingGateway

Ownership: FreshFood-API.Services. Role: interface.

Basis: GeocodingBoundary; UC-C05

### Attributes


### Operations

- + ResolveAsync(address: Text): GeoPointDto

### Relationships

- GoogleMapsGeocodingAdapter --realization--> IGeocodingGateway (implements)
- IGeocodingGateway --dependency--> GeoPointDto (uses DTO)
- ProfileService --association--> IGeocodingGateway (holds reference)

## GoogleMapsGeocodingAdapter

Ownership: FreshFood-API.Services.Implements. Role: adapter.

Basis: GeocodingBoundary; UC-C05

### Attributes


### Operations

- + ResolveAsync(address: Text): GeoPointDto

### Relationships

- GoogleMapsGeocodingAdapter --dependency--> GeoPointDto (uses DTO)
- GoogleMapsGeocodingAdapter --realization--> IGeocodingGateway (implements)

## IDistanceGateway

Ownership: FreshFood-API.Services. Role: interface.

Basis: DistanceBoundary; BR-DEL-01/02

### Attributes


### Operations

- + DrivingDistanceAsync(addressId: Text): Decimal

### Relationships

- DistanceCalculator --association--> IDistanceGateway (gateway)
- GoogleMapsDistanceAdapter --realization--> IDistanceGateway (implements)

## GoogleMapsDistanceAdapter

Ownership: FreshFood-API.Services.Implements. Role: adapter.

Basis: DistanceBoundary; BR-DEL-01/02

### Attributes


### Operations

- + DrivingDistanceAsync(addressId: Text): Decimal

### Relationships

- GoogleMapsDistanceAdapter --realization--> IDistanceGateway (implements)

## IPaymentGateway

Ownership: FreshFood-API.Services. Role: interface.

Basis: PaymentBoundary; incoming payments only, no invented refund API

### Attributes


### Operations

- + CreateQrAsync(reference: Text, amount: VndAmount): PaymentQrDto
- + VerifyNoticeAsync(notice: PaymentNoticeDto): VerifiedPaymentDto

### Relationships

- CheckoutService --association--> IPaymentGateway (holds reference)
- IPaymentGateway --dependency--> PaymentNoticeDto (uses DTO)
- IPaymentGateway --dependency--> PaymentQrDto (uses DTO)
- IPaymentGateway --dependency--> VerifiedPaymentDto (uses DTO)
- SePayPaymentAdapter --realization--> IPaymentGateway (implements)

## SePayPaymentAdapter

Ownership: FreshFood-API.Services.Implements. Role: adapter.

Basis: PaymentBoundary; incoming payments only, no invented refund API

### Attributes


### Operations

- + CreateQrAsync(reference: Text, amount: VndAmount): PaymentQrDto
- + VerifyNoticeAsync(notice: PaymentNoticeDto): VerifiedPaymentDto

### Relationships

- SePayPaymentAdapter --dependency--> PaymentNoticeDto (uses DTO)
- SePayPaymentAdapter --dependency--> PaymentQrDto (uses DTO)
- SePayPaymentAdapter --dependency--> VerifiedPaymentDto (uses DTO)
- SePayPaymentAdapter --realization--> IPaymentGateway (implements)

## INotificationGateway

Ownership: FreshFood-API.Services. Role: interface.

Basis: NotificationBoundary; channel adapter provider stays configurable

### Attributes


### Operations

- + PublishAsync(message: NotificationDto): Void

### Relationships

- CheckoutService --association--> INotificationGateway (holds reference)
- INotificationGateway --dependency--> NotificationDto (uses DTO)
- MyOrdersService --association--> INotificationGateway (holds reference)
- NotificationAdapter --realization--> INotificationGateway (implements)

## NotificationAdapter

Ownership: FreshFood-API.Services.Implements. Role: adapter.

Basis: NotificationBoundary; channel adapter provider stays configurable

### Attributes

- - publisher: INotificationPublisher

### Operations

- + NotificationAdapter(publisher: INotificationPublisher)
- + PublishAsync(message: NotificationDto): Void

### Relationships

- NotificationAdapter --dependency--> NotificationDto (uses DTO)
- NotificationAdapter --realization--> INotificationGateway (implements)

## INotificationPublisher

Ownership: FreshFood-API.Services. Role: interface.

Basis: Proposed channel seam; no delivery guarantee invented

### Attributes


### Operations

- + SendAsync(message: NotificationDto): Void

### Relationships

- ConfiguredNotificationPublisher --realization--> INotificationPublisher (implements)
- INotificationPublisher --dependency--> NotificationDto (uses DTO)

## NotificationDto

Ownership: FreshFood-API.DTOs. Role: DTO.

Basis: Existing customer/staff notification; transaction commits before publish

### Attributes

- + OrderId: Text
- + EventCode: Text

### Operations


### Relationships

- ConfiguredNotificationPublisher --dependency--> NotificationDto (uses DTO)
- INotificationGateway --dependency--> NotificationDto (uses DTO)
- INotificationPublisher --dependency--> NotificationDto (uses DTO)
- NotificationAdapter --dependency--> NotificationDto (uses DTO)

## VerifiedPaymentDto

Ownership: FreshFood-API.DTOs. Role: DTO.

Basis: Server verified immutable allocation evidence

### Attributes

- + ProviderReference: Text
- + CheckoutReference: Text
- + GoodsAmount: VndAmount
- + ShippingAmount: VndAmount
- + VerifiedAt: DateTime

### Operations


### Relationships

- IPaymentGateway --dependency--> VerifiedPaymentDto (uses DTO)
- SePayPaymentAdapter --dependency--> VerifiedPaymentDto (uses DTO)

## ProductCategory

Ownership: FreshFood.Reposistory.Entities. Role: entity.

Basis: Existing data requirements / product_categories

### Attributes

- + CategoryId: Integer
- + CategoryCode: Text
- + CategoryName: Text
- + Description: Text
- + IsActive: Boolean
- + Products: Sequence<Product>

### Operations


### Relationships

- CatalogRepository --dependency--> ProductCategory (uses entity)
- CatalogService --dependency--> ProductCategory (uses entity)
- ICatalogRepository --dependency--> ProductCategory (uses entity)
- ProductCategory --association--> Product (1 : 0..*)

## Product

Ownership: FreshFood.Reposistory.Entities. Role: entity.

Basis: Existing data requirements / products

### Attributes

- + ProductId: Text
- + CategoryId: Integer
- + Sku: Text
- + ProductName: Text
- + UnitOfMeasure: Text
- + Description: Text
- + ImageUrl: Text
- + IsActive: Boolean
- + CreatedAt: DateTime
- + Batches: Sequence<BatchInventory>

### Operations


### Relationships

- CartItem --association--> Product (1 : 1)
- CartRepository --dependency--> Product (uses entity)
- CartService --dependency--> Product (uses entity)
- CatalogRepository --dependency--> Product (uses entity)
- CatalogService --dependency--> Product (uses entity)
- CheckoutRepository --dependency--> Product (uses entity)
- CheckoutService --dependency--> Product (uses entity)
- ICartRepository --dependency--> Product (uses entity)
- ICatalogRepository --dependency--> Product (uses entity)
- MyOrdersRepository --dependency--> Product (uses entity)
- MyOrdersService --dependency--> Product (uses entity)
- Product --association--> BatchInventory (1 : 0..*)
- ProductCategory --association--> Product (1 : 0..*)
- ProductDetailsDto --dependency--> Product (uses entity)

## BatchInventory

Ownership: FreshFood.Reposistory.Entities. Role: entity.

Basis: Existing data requirements / batch_inventory

### Attributes

- + BatchId: Text
- + ProductId: Text
- + ReceiptId: Text
- + BatchNumber: Text
- + ManufactureDate: Date
- + ExpiryDate: Date
- + ImportQuantity: Integer
- + CurrentStock: Integer
- + ReservedStock: Integer
- + ImportPrice: VndAmount
- + RetailPrice: VndAmount
- + DiscountRate: Decimal
- + SaleStatus: Text

### Operations

- + Reserve(quantity: Integer): Void
- + ReleaseReservation(quantity: Integer): Void

### Relationships

- BatchPricingPolicy --dependency--> BatchInventory (uses entity)
- CartRepository --dependency--> BatchInventory (uses entity)
- CartService --dependency--> BatchInventory (uses entity)
- CatalogRepository --dependency--> BatchInventory (uses entity)
- CatalogService --dependency--> BatchInventory (uses entity)
- CheckoutRepository --dependency--> BatchInventory (uses entity)
- CheckoutService --dependency--> BatchInventory (uses entity)
- IBatchPricingPolicy --dependency--> BatchInventory (uses entity)
- ICartRepository --dependency--> BatchInventory (uses entity)
- ICatalogRepository --dependency--> BatchInventory (uses entity)
- ICheckoutRepository --dependency--> BatchInventory (uses entity)
- IMyOrdersRepository --dependency--> BatchInventory (uses entity)
- MyOrdersRepository --dependency--> BatchInventory (uses entity)
- MyOrdersService --dependency--> BatchInventory (uses entity)
- OrderDetail --association--> BatchInventory (1 : 1)
- Product --association--> BatchInventory (1 : 0..*)
- TransitionSnapshot --dependency--> BatchInventory (trusted context)

## Customer

Ownership: FreshFood.Reposistory.Entities. Role: entity.

Basis: Existing data requirements / customers

### Attributes

- + CustomerId: Text
- + FullName: Text
- + Phone: Text
- + Email: Text?
- + AuthProvider: Text
- + ProviderUserId: Text
- + IsPhoneVerified: Boolean
- + CreatedAt: DateTime
- + Addresses: Sequence<CustomerAddress>

### Operations


### Relationships

- CheckoutRepository --dependency--> Customer (uses entity)
- CheckoutService --dependency--> Customer (uses entity)
- Customer --association--> CustomerAddress (1 : 0..*)
- IProfileRepository --dependency--> Customer (uses entity)
- MyOrdersRepository --dependency--> Customer (uses entity)
- MyOrdersService --dependency--> Customer (uses entity)
- Order --association--> Customer (1 : 1)
- ProfileRepository --dependency--> Customer (uses entity)
- ProfileService --dependency--> Customer (uses entity)

## CustomerAddress

Ownership: FreshFood.Reposistory.Entities. Role: entity.

Basis: Existing data requirements / customer_addresses

### Attributes

- + AddressId: Text
- + CustomerId: Text
- + RecipientName: Text
- + RecipientPhone: Text
- + StreetAddress: Text
- + Latitude: Decimal
- + Longitude: Decimal
- + IsDefault: Boolean

### Operations


### Relationships

- CheckoutRepository --dependency--> CustomerAddress (uses entity)
- CheckoutService --dependency--> CustomerAddress (uses entity)
- Customer --association--> CustomerAddress (1 : 0..*)
- ICheckoutRepository --dependency--> CustomerAddress (uses entity)
- IProfileRepository --dependency--> CustomerAddress (uses entity)
- MyOrdersRepository --dependency--> CustomerAddress (uses entity)
- MyOrdersService --dependency--> CustomerAddress (uses entity)
- Order --association--> CustomerAddress (1 : 1)
- ProfileRepository --dependency--> CustomerAddress (uses entity)
- ProfileService --dependency--> CustomerAddress (uses entity)

## Cart

Ownership: FreshFood.Reposistory.Entities. Role: entity.

Basis: Existing data requirements / carts

### Attributes

- + CartId: Text
- + CustomerId: Text
- + SessionId: Text
- + CreatedAt: DateTime
- + UpdatedAt: DateTime
- + Items: Sequence<CartItem>

### Operations

- + ChangeQuantity(productId: Text, quantity: Integer): Void
- + RemoveItem(productId: Text): Void

### Relationships

- Cart --association--> CartItem (1 : 0..*)
- CartRepository --dependency--> Cart (uses entity)
- CartService --dependency--> Cart (uses entity)
- CheckoutRepository --dependency--> Cart (uses entity)
- CheckoutService --dependency--> Cart (uses entity)
- ICartRepository --dependency--> Cart (uses entity)
- ICheckoutRepository --dependency--> Cart (uses entity)
- IMyOrdersRepository --dependency--> Cart (uses entity)
- MyOrdersRepository --dependency--> Cart (uses entity)
- MyOrdersService --dependency--> Cart (uses entity)

## CartItem

Ownership: FreshFood.Reposistory.Entities. Role: entity.

Basis: Existing data requirements / cart_items

### Attributes

- + CartItemId: Text
- + CartId: Text
- + ProductId: Text
- + Quantity: Integer
- + AddedAt: DateTime
- + Product: Product

### Operations


### Relationships

- Cart --association--> CartItem (1 : 0..*)
- CartItem --association--> Product (1 : 1)
- CartRepository --dependency--> CartItem (uses entity)
- CartService --dependency--> CartItem (uses entity)
- CheckoutRepository --dependency--> CartItem (uses entity)
- CheckoutService --dependency--> CartItem (uses entity)
- MyOrdersRepository --dependency--> CartItem (uses entity)
- MyOrdersService --dependency--> CartItem (uses entity)

## Order

Ownership: FreshFood.Reposistory.Entities. Role: entity.

Basis: Existing data requirements / orders

### Attributes

- + OrderId: Text
- + OrderNumber: Text
- + CustomerId: Text
- + DeliveryAddressId: Text
- + ProcessedByStaffId: Integer
- + OrderDate: DateTime
- + SubTotal: VndAmount
- + DeliveryDistance: Decimal
- + ShippingFee: VndAmount
- + TotalAmount: VndAmount
- + PaymentMethod: PaymentMethod
- + PaymentStatus: PaymentStatus
- + OrderStatus: OrderStatus
- + IsFirstOrder: Boolean
- + DeliveryAgentId: Text
- + PhoneConfirmationStatus: Text
- + PhoneContactedByStaffId: Integer
- + PhoneContactedAt: DateTime
- + PhoneConfirmationNote: Text
- + CancellationReason: Text
- + Details: Sequence<OrderDetail>
- + Customer: Customer
- + DeliveryAddress: CustomerAddress
- + Payments: Sequence<OrderPayment>
- + Failure: DeliveryFailure?
- + Return: ReturnReceipt?
- + Refund: Refund?

### Operations

- + ApplyFulfillment(expected: OrderStatus, target: OrderStatus): Void
- + RecordPayment(expected: PaymentStatus, target: PaymentStatus): Void
- + Cancel(expected: OrderStatus, reason: Text): Void

### Relationships

- CheckoutRepository --dependency--> Order (uses entity)
- CheckoutService --dependency--> Order (uses entity)
- ICheckoutRepository --dependency--> Order (uses entity)
- IMyOrdersRepository --dependency--> Order (uses entity)
- MyOrdersRepository --dependency--> Order (uses entity)
- MyOrdersService --dependency--> Order (uses entity)
- Order --association--> Customer (1 : 1)
- Order --association--> CustomerAddress (1 : 1)
- Order --association--> OrderDetail (1 : 1..*)
- OrderDetailsDto --dependency--> Order (uses entity)
- OrderStateMachine --dependency--> Order (uses)
- ProfileRepository --dependency--> Order (uses entity)
- ProfileService --dependency--> Order (uses entity)
- TransitionSnapshot --dependency--> Order (trusted context)

## OrderDetail

Ownership: FreshFood.Reposistory.Entities. Role: entity.

Basis: Existing data requirements / order_details

### Attributes

- + OrderDetailId: Text
- + OrderId: Text
- + BatchId: Text
- + Quantity: Integer
- + UnitPrice: VndAmount
- + DiscountAmount: VndAmount
- + LineTotal: VndAmount
- + Batch: BatchInventory
- + ProductId: EntityId {derived projection}
- + ProductName: Text {derived projection}

### Operations


### Relationships

- CheckoutRepository --dependency--> OrderDetail (uses entity)
- CheckoutService --dependency--> OrderDetail (uses entity)
- MyOrdersRepository --dependency--> OrderDetail (uses entity)
- MyOrdersService --dependency--> OrderDetail (uses entity)
- Order --association--> OrderDetail (1 : 1..*)
- OrderDetail --association--> BatchInventory (1 : 1)

## OrderReview

Ownership: FreshFood.Reposistory.Entities. Role: entity.

Basis: Existing data requirements / order_reviews

### Attributes

- + ReviewId: Text
- + OrderId: Text
- + CustomerId: Text
- + Rating: Integer
- + Comment: Text
- + CreatedAt: DateTime

### Operations


### Relationships

- IMyOrdersRepository --dependency--> OrderReview (uses entity)
- MyOrdersRepository --dependency--> OrderReview (uses entity)
- MyOrdersService --dependency--> OrderReview (uses entity)

## AuditLog

Ownership: FreshFood.Reposistory.Entities. Role: entity.

Basis: Existing data requirements / audit_logs

### Attributes

- + LogId: Text
- + StaffId: Integer?
- + ActionType: Text
- + EntityName: Text
- + RecordIdentifier: Text
- + OldValues: Text
- + NewValues: Text
- + IpAddress: Text
- + Timestamp: DateTime
- + CustomerId: Text?
- + ActorType: Text

### Operations


### Relationships

- MyOrdersRepository --dependency--> AuditLog (uses entity)
- MyOrdersService --dependency--> AuditLog (uses entity)

## DeliveryAgent

Ownership: FreshFood.Reposistory.Entities. Role: entity.

Basis: Existing data requirements / delivery_agents

### Attributes

- + DeliveryAgentId: Text
- + DisplayName: Text
- + ContactPhone: Text

### Operations


### Relationships


## OrderPayment

Ownership: FreshFood.Reposistory.Entities. Role: entity.

Basis: Existing data requirements / order_payments

### Attributes

- + PaymentId: Text
- + OrderId: Text
- + PaymentChannel: Text
- + ProviderTransactionId: Text
- + GoodsAmount: VndAmount
- + ShippingAmount: VndAmount
- + UnallocatedAmount: VndAmount
- + CapturedAmount: VndAmount
- + ReceivedAt: DateTime
- + RecordedByStaffId: Integer
- + CollectedByDeliveryAgentId: Text

### Operations


### Relationships


## DeliveryFailure

Ownership: FreshFood.Reposistory.Entities. Role: entity.

Basis: Existing data requirements / delivery_failures

### Attributes

- + FailureId: Text
- + OrderId: Text
- + FailureCause: Text
- + Reason: Text
- + ReportedByStaffId: Integer
- + ReportedAt: DateTime
- + CauseConfirmedByStaffId: Integer
- + CauseConfirmedAt: DateTime
- + CauseEvidence: Text

### Operations


### Relationships


## ReturnReceipt

Ownership: FreshFood.Reposistory.Entities. Role: entity.

Basis: Existing data requirements / return_receipts

### Attributes

- + ReturnReceiptId: Text
- + OrderId: Text
- + ReceiptStatus: Text
- + CreatedByStaffId: Integer
- + CreatedAt: DateTime
- + ConfirmedByStaffId: Integer
- + ConfirmedAt: DateTime
- + Items: Sequence<ReturnReceiptItem>

### Operations


### Relationships


## ReturnReceiptItem

Ownership: FreshFood.Reposistory.Entities. Role: entity.

Basis: Existing data requirements / return_receipt_items

### Attributes

- + ReturnReceiptItemId: Text
- + ReturnReceiptId: Text
- + OrderId: Text
- + OrderDetailId: Text
- + QuantityReceived: Integer
- + Inspections: Sequence<ReturnInspection>

### Operations


### Relationships

- ReturnReceiptItem --association--> ReturnInspection (1 : 0..*)

## ReturnInspection

Ownership: FreshFood.Reposistory.Entities. Role: entity.

Basis: Existing data requirements / return_inspections

### Attributes

- + InspectionId: Text
- + ReturnReceiptItemId: Text
- + InspectedByStaffId: Integer
- + InspectedAt: DateTime
- + Quantity: Integer
- + Disposition: Text
- + ConditionNotes: Text
- + InventoryAppliedAt: DateTime

### Operations


### Relationships

- ReturnReceiptItem --association--> ReturnInspection (1 : 0..*)

## Refund

Ownership: FreshFood.Reposistory.Entities. Role: entity.

Basis: Existing data requirements / refunds

### Attributes

- + RefundId: Text
- + OrderId: Text
- + ReturnReceiptId: Text
- + GoodsAmount: VndAmount
- + ShippingAmount: VndAmount
- + RefundStatus: Text
- + IdempotencyKey: Text
- + RequestedAt: DateTime
- + SettledAt: DateTime
- + ProviderRefundReference: Text

### Operations


### Relationships


## ShippingFeeSettlement

Ownership: FreshFood.Reposistory.Entities. Role: entity.

Basis: Existing data requirements / shipping_fee_settlements

### Attributes

- + ShippingSettlementId: Text
- + OrderId: Text
- + DeliveryAgentId: Text
- + CustomerFeeDue: VndAmount
- + CollectionPaymentId: Text
- + CompensationDueAmount: VndAmount
- + CompensationPaidAmount: VndAmount
- + CompensatedAt: DateTime
- + SettlementReference: Text

### Operations


### Relationships


## OrderStatus

Ownership: FreshFood.Reposistory.Entities. Role: enumeration.

Basis: Stakeholder-confirmed lifecycle / payment revision

### Attributes

- PendingUnpaid
- PendingPaid
- Confirmed
- Packing
- Shipping
- Delivered
- Cancelled
- DeliveryFailed
- Returned

### Operations


### Relationships


## PaymentStatus

Ownership: FreshFood.Reposistory.Entities. Role: enumeration.

Basis: Stakeholder-confirmed lifecycle / payment revision

### Attributes

- Unpaid
- Paid
- PartiallyRefunded
- Refunded

### Operations


### Relationships


## PaymentMethod

Ownership: FreshFood.Reposistory.Entities. Role: enumeration.

Basis: Stakeholder-confirmed lifecycle / payment revision

### Attributes

- Cod
- VietQr

### Operations


### Relationships


## ICatalogService

Ownership: FreshFood-API.Services. Role: interface.

Basis: UC-C01; VOPC and analysis sequence scenario pages

### Attributes


### Operations

- + GetCatalogAsync(query: CatalogQueryDto): CatalogResultDto
- + SearchAsync(query: CatalogQueryDto): CatalogResultDto
- + GetProductDetailsAsync(productId: Text): ProductDetailsDto
- + GetClearanceAsync(query: CatalogQueryDto): CatalogResultDto

### Relationships

- CatalogController --association--> ICatalogService (holds reference)
- CatalogController --association--> ICatalogService (service)
- CatalogService --realization--> ICatalogService (implements)
- ICatalogService --dependency--> CatalogQueryDto (uses DTO)
- ICatalogService --dependency--> CatalogResultDto (uses DTO)
- ICatalogService --dependency--> ProductDetailsDto (uses DTO)

## CatalogService

Ownership: FreshFood-API.Services.Implements. Role: service.

Basis: UC-C01; VOPC and analysis sequence scenario pages

### Attributes

- - catalogRepository: ICatalogRepository
- - pricing: IBatchPricingPolicy

### Operations

- + CatalogService(catalogRepository: ICatalogRepository, pricing: IBatchPricingPolicy)
- + GetCatalogAsync(query: CatalogQueryDto): CatalogResultDto
- + SearchAsync(query: CatalogQueryDto): CatalogResultDto
- + GetProductDetailsAsync(productId: Text): ProductDetailsDto
- + GetClearanceAsync(query: CatalogQueryDto): CatalogResultDto

### Relationships

- CatalogService --association--> IBatchPricingPolicy (pricing)
- CatalogService --association--> ICatalogRepository (holds reference)
- CatalogService --dependency--> BatchInventory (uses entity)
- CatalogService --dependency--> CatalogQueryDto (uses DTO)
- CatalogService --dependency--> CatalogResultDto (uses DTO)
- CatalogService --dependency--> Product (uses entity)
- CatalogService --dependency--> ProductCategory (uses entity)
- CatalogService --dependency--> ProductDetailsDto (uses DTO)
- CatalogService --realization--> ICatalogService (implements)

## CatalogController

Ownership: FreshFood-API.Controllers. Role: controller.

Basis: UC-C01; VOPC and analysis sequence scenario pages

### Attributes

- - service: ICatalogService

### Operations

- + CatalogController(service: ICatalogService)
- + GetCatalogAsync(query: CatalogQueryDto): CatalogResultDto
- + SearchAsync(query: CatalogQueryDto): CatalogResultDto
- + GetProductDetailsAsync(productId: Text): ProductDetailsDto
- + GetClearanceAsync(query: CatalogQueryDto): CatalogResultDto

### Relationships

- CatalogApiClient --remote--> CatalogController (HTTPS / JSON)
- CatalogApiModel --remote--> CatalogController (HTTPS / JSON)
- CatalogController --association--> ICatalogService (holds reference)
- CatalogController --association--> ICatalogService (service)
- CatalogController --dependency--> CatalogQueryDto (uses DTO)
- CatalogController --dependency--> CatalogResultDto (uses DTO)
- CatalogController --dependency--> ProductDetailsDto (uses DTO)

## ICatalogRepository

Ownership: FreshFood.Reposistory.Repository. Role: interface.

Basis: UC-C01; VOPC and analysis sequence scenario pages

### Attributes


### Operations

- + FindActiveAsync(keyword: Text?, categoryId: Integer?, clearanceOnly: Boolean): Sequence<Product>
- + GetCategoriesAsync(): Sequence<ProductCategory>
- + GetProductAsync(productId: Text): Product?
- + GetSellableBatchesAsync(productIds: Sequence<Text>): Sequence<BatchInventory>
- + GetPopularAsync(limit: Integer): Sequence<Product>

### Relationships

- CatalogRepository --realization--> ICatalogRepository (implements)
- CatalogService --association--> ICatalogRepository (holds reference)
- ICatalogRepository --dependency--> BatchInventory (uses entity)
- ICatalogRepository --dependency--> Product (uses entity)
- ICatalogRepository --dependency--> ProductCategory (uses entity)

## CatalogRepository

Ownership: FreshFood.Reposistory.Repository.Implements. Role: repository.

Basis: UC-C01; VOPC and analysis sequence scenario pages

### Attributes

- - session: IRepositorySession

### Operations

- + CatalogRepository(session: IRepositorySession)
- + FindActiveAsync(keyword: Text?, categoryId: Integer?, clearanceOnly: Boolean): Sequence<Product>
- + GetCategoriesAsync(): Sequence<ProductCategory>
- + GetProductAsync(productId: Text): Product?
- + GetSellableBatchesAsync(productIds: Sequence<Text>): Sequence<BatchInventory>
- + GetPopularAsync(limit: Integer): Sequence<Product>

### Relationships

- CatalogRepository --dependency--> BatchInventory (uses entity)
- CatalogRepository --dependency--> Product (uses entity)
- CatalogRepository --dependency--> ProductCategory (uses entity)
- CatalogRepository --realization--> ICatalogRepository (implements)

## CatalogQueryDto

Ownership: FreshFood-API.DTOs. Role: DTO.

Basis: UC-C01; VOPC and analysis sequence scenario pages

### Attributes

- + Keyword: Text?
- + CategoryId: Text?
- + ClearanceOnly: Boolean

### Operations


### Relationships

- CatalogApiClient --dependency--> CatalogQueryDto (uses wire DTO)
- CatalogApiModel --dependency--> CatalogQueryDto (uses wire DTO)
- CatalogController --dependency--> CatalogQueryDto (uses DTO)
- CatalogPage --dependency--> CatalogQueryDto (uses wire DTO)
- CatalogService --dependency--> CatalogQueryDto (uses DTO)
- CatalogView --dependency--> CatalogQueryDto (uses wire DTO)
- CatalogViewModel --dependency--> CatalogQueryDto (uses wire DTO)
- ICatalogService --dependency--> CatalogQueryDto (uses DTO)

## CatalogResultDto

Ownership: FreshFood-API.DTOs. Role: DTO.

Basis: UC-C01; VOPC and analysis sequence scenario pages

### Attributes

- + Items: Sequence<ProductSummaryDto>
- + Categories: Sequence<CategoryDto>
- + Alternatives: Sequence<ProductSummaryDto>

### Operations


### Relationships

- CatalogApiClient --dependency--> CatalogResultDto (uses wire DTO)
- CatalogApiModel --dependency--> CatalogResultDto (uses wire DTO)
- CatalogController --dependency--> CatalogResultDto (uses DTO)
- CatalogPage --dependency--> CatalogResultDto (uses wire DTO)
- CatalogResultDto --association--> CategoryDto (contains DTO)
- CatalogResultDto --association--> ProductSummaryDto (contains DTO)
- CatalogService --dependency--> CatalogResultDto (uses DTO)
- CatalogViewModel --dependency--> CatalogResultDto (uses wire DTO)
- ICatalogService --dependency--> CatalogResultDto (uses DTO)

## ProductDetailsDto

Ownership: FreshFood-API.DTOs. Role: DTO.

Basis: UC-C01; VOPC and analysis sequence scenario pages

### Attributes

- + Product: ProductSummaryDto
- + Description: Text?
- + AvailableBatches: Sequence<BatchOfferDto>

### Operations


### Relationships

- CatalogApiClient --dependency--> ProductDetailsDto (uses wire DTO)
- CatalogApiModel --dependency--> ProductDetailsDto (uses wire DTO)
- CatalogController --dependency--> ProductDetailsDto (uses DTO)
- CatalogService --dependency--> ProductDetailsDto (uses DTO)
- CatalogViewModel --dependency--> ProductDetailsDto (uses wire DTO)
- ICatalogService --dependency--> ProductDetailsDto (uses DTO)
- ProductDetailsDto --association--> BatchOfferDto (contains DTO)
- ProductDetailsDto --association--> ProductSummaryDto (contains DTO)
- ProductDetailsDto --dependency--> Product (uses entity)

## ProductSummaryDto

Ownership: FreshFood-API.DTOs. Role: DTO.

Basis: UC-C01; VOPC and analysis sequence scenario pages

### Attributes

- + ProductId: Text
- + Name: Text
- + Unit: Text
- + AvailableQuantity: Integer
- + CurrentPrice: VndAmount

### Operations


### Relationships

- CatalogResultDto --association--> ProductSummaryDto (contains DTO)
- ProductDetailsDto --association--> ProductSummaryDto (contains DTO)

## CategoryDto

Ownership: FreshFood-API.DTOs. Role: DTO.

Basis: UC-C01; VOPC and analysis sequence scenario pages

### Attributes

- + CategoryId: Text
- + Name: Text

### Operations


### Relationships

- CatalogResultDto --association--> CategoryDto (contains DTO)

## BatchOfferDto

Ownership: FreshFood-API.DTOs. Role: DTO.

Basis: UC-C01; VOPC and analysis sequence scenario pages

### Attributes

- + BatchId: Text
- + ExpiryDate: Date
- + Price: Text
- + Clearance: Boolean

### Operations


### Relationships

- ProductDetailsDto --association--> BatchOfferDto (contains DTO)

## CatalogPage

Ownership: FreshFood-Customer-Web.Pages. Role: boundary.

Basis: CatalogView Web rendering/events; ordinary reference to concrete CallService class; no DI

### Attributes

- - api: CatalogApiClient
- - state: CatalogResultDto?
- - isBusy: Boolean
- - errorCode: Text?

### Operations

- + Render(): View
- + OnGetCatalogAsync(query: CatalogQueryDto): Void
- + OnSearchAsync(query: CatalogQueryDto): Void
- + OnGetProductDetailsAsync(productId: EntityId): Void
- + OnGetClearanceAsync(query: CatalogQueryDto): Void

### Relationships

- CatalogPage --association--> CatalogApiClient (api)
- CatalogPage --dependency--> CatalogQueryDto (uses wire DTO)
- CatalogPage --dependency--> CatalogResultDto (uses wire DTO)

## CatalogApiClient

Ownership: FreshFood-Customer-Web.CallService. Role: adapter.

Basis: Authenticated HTTPS/JSON and boundary serialization; ordinary frontend object/module lifecycle, no DI

### Attributes

- - http: HttpTransport

### Operations

- + GetCatalogAsync(query: CatalogQueryDto): CatalogResultDto
- + SearchAsync(query: CatalogQueryDto): CatalogResultDto
- + GetProductDetailsAsync(productId: EntityId): ProductDetailsDto
- + GetClearanceAsync(query: CatalogQueryDto): CatalogResultDto

### Relationships

- CatalogApiClient --dependency--> CatalogQueryDto (uses wire DTO)
- CatalogApiClient --dependency--> CatalogResultDto (uses wire DTO)
- CatalogApiClient --dependency--> ProductDetailsDto (uses wire DTO)
- CatalogApiClient --remote--> CatalogController (HTTPS / JSON)
- CatalogPage --association--> CatalogApiClient (api)

## CatalogView

Ownership: FreshFood-App.Views. Role: boundary.

Basis: CatalogView Mobile rendering/events through ordinary ViewModel association; no DI

### Attributes

- - model: CatalogViewModel

### Operations

- + Build(): View
- + OnGetCatalog(query: CatalogQueryDto): Void
- + OnSearch(query: CatalogQueryDto): Void
- + OnGetProductDetails(productId: EntityId): Void
- + OnGetClearance(query: CatalogQueryDto): Void

### Relationships

- CatalogView --association--> CatalogViewModel (model)
- CatalogView --dependency--> CatalogQueryDto (uses wire DTO)

## CatalogViewModel

Ownership: FreshFood-App.ViewModels. Role: viewmodel.

Basis: MVVM state and orchestration; ordinary association to concrete API model; no DI

### Attributes

- - api: CatalogApiModel
- - state: CatalogResultDto?
- - isBusy: Boolean
- - errorCode: Text?

### Operations

- + GetCatalogAsync(query: CatalogQueryDto): CatalogResultDto
- + SearchAsync(query: CatalogQueryDto): CatalogResultDto
- + GetProductDetailsAsync(productId: EntityId): ProductDetailsDto
- + GetClearanceAsync(query: CatalogQueryDto): CatalogResultDto

### Relationships

- CatalogView --association--> CatalogViewModel (model)
- CatalogViewModel --association--> CatalogApiModel (api)
- CatalogViewModel --dependency--> CatalogQueryDto (uses wire DTO)
- CatalogViewModel --dependency--> CatalogResultDto (uses wire DTO)
- CatalogViewModel --dependency--> ProductDetailsDto (uses wire DTO)

## CatalogApiModel

Ownership: FreshFood-App.Models. Role: adapter.

Basis: Authenticated HTTPS/JSON; ordinary frontend lifecycle; no DI or backend type imports

### Attributes

- - http: HttpTransport

### Operations

- + GetCatalogAsync(query: CatalogQueryDto): CatalogResultDto
- + SearchAsync(query: CatalogQueryDto): CatalogResultDto
- + GetProductDetailsAsync(productId: EntityId): ProductDetailsDto
- + GetClearanceAsync(query: CatalogQueryDto): CatalogResultDto

### Relationships

- CatalogApiModel --dependency--> CatalogQueryDto (uses wire DTO)
- CatalogApiModel --dependency--> CatalogResultDto (uses wire DTO)
- CatalogApiModel --dependency--> ProductDetailsDto (uses wire DTO)
- CatalogApiModel --remote--> CatalogController (HTTPS / JSON)
- CatalogViewModel --association--> CatalogApiModel (api)

## ICartService

Ownership: FreshFood-API.Services. Role: interface.

Basis: UC-C03; VOPC and analysis sequence scenario pages

### Attributes


### Operations

- + GetCartAsync(): CartResultDto
- + ChangeQuantityAsync(request: CartChangeDto): CartResultDto
- + RemoveItemAsync(productId: Text): CartResultDto

### Relationships

- CartController --association--> ICartService (holds reference)
- CartController --association--> ICartService (service)
- CartService --realization--> ICartService (implements)
- ICartService --dependency--> CartChangeDto (uses DTO)
- ICartService --dependency--> CartIdentityDto (uses DTO)
- ICartService --dependency--> CartResultDto (uses DTO)

## CartService

Ownership: FreshFood-API.Services.Implements. Role: service.

Basis: UC-C03; VOPC and analysis sequence scenario pages

### Attributes

- - cartRepository: ICartRepository
- - currentCustomer: ICurrentCustomer
- - unitOfWork: IUnitOfWork
- - pricing: IBatchPricingPolicy

### Operations

- + CartService(cartRepository: ICartRepository, currentCustomer: ICurrentCustomer, unitOfWork: IUnitOfWork, pricing: IBatchPricingPolicy)
- + GetCartAsync(): CartResultDto
- + ChangeQuantityAsync(request: CartChangeDto): CartResultDto
- + RemoveItemAsync(productId: Text): CartResultDto

### Relationships

- CartService --association--> IBatchPricingPolicy (pricing)
- CartService --association--> ICartRepository (holds reference)
- CartService --association--> ICurrentCustomer (holds reference)
- CartService --association--> IUnitOfWork (holds reference)
- CartService --dependency--> BatchInventory (uses entity)
- CartService --dependency--> Cart (uses entity)
- CartService --dependency--> CartChangeDto (uses DTO)
- CartService --dependency--> CartIdentityDto (uses DTO)
- CartService --dependency--> CartItem (uses entity)
- CartService --dependency--> CartResultDto (uses DTO)
- CartService --dependency--> Product (uses entity)
- CartService --realization--> ICartService (implements)

## CartController

Ownership: FreshFood-API.Controllers. Role: controller.

Basis: UC-C03; VOPC and analysis sequence scenario pages

### Attributes

- - service: ICartService

### Operations

- + CartController(service: ICartService)
- + GetCartAsync(): CartResultDto
- + ChangeQuantityAsync(request: CartChangeDto): CartResultDto
- + RemoveItemAsync(productId: Text): CartResultDto

### Relationships

- CartApiClient --remote--> CartController (HTTPS / JSON)
- CartApiModel --remote--> CartController (HTTPS / JSON)
- CartController --association--> ICartService (holds reference)
- CartController --association--> ICartService (service)
- CartController --dependency--> CartChangeDto (uses DTO)
- CartController --dependency--> CartIdentityDto (uses DTO)
- CartController --dependency--> CartResultDto (uses DTO)

## ICartRepository

Ownership: FreshFood.Reposistory.Repository. Role: interface.

Basis: UC-C03; VOPC and analysis sequence scenario pages

### Attributes


### Operations

- + GetAsync(customerId: Text?, sessionId: Text?): Cart
- + GetProductsAsync(ids: Sequence<Text>): Sequence<Product>
- + GetSellableBatchesAsync(ids: Sequence<Text>): Sequence<BatchInventory>
- + SaveAsync(cart: Cart): Void

### Relationships

- CartRepository --realization--> ICartRepository (implements)
- CartService --association--> ICartRepository (holds reference)
- ICartRepository --dependency--> BatchInventory (uses entity)
- ICartRepository --dependency--> Cart (uses entity)
- ICartRepository --dependency--> Product (uses entity)

## CartRepository

Ownership: FreshFood.Reposistory.Repository.Implements. Role: repository.

Basis: UC-C03; VOPC and analysis sequence scenario pages

### Attributes

- - session: IRepositorySession

### Operations

- + CartRepository(session: IRepositorySession)
- + GetAsync(customerId: Text?, sessionId: Text?): Cart
- + GetProductsAsync(ids: Sequence<Text>): Sequence<Product>
- + GetSellableBatchesAsync(ids: Sequence<Text>): Sequence<BatchInventory>
- + SaveAsync(cart: Cart): Void

### Relationships

- CartRepository --dependency--> BatchInventory (uses entity)
- CartRepository --dependency--> Cart (uses entity)
- CartRepository --dependency--> CartItem (uses entity)
- CartRepository --dependency--> Product (uses entity)
- CartRepository --realization--> ICartRepository (implements)

## CartIdentityDto

Ownership: FreshFood-API.DTOs. Role: DTO.

Basis: UC-C03; VOPC and analysis sequence scenario pages

### Attributes

- + CustomerId: Text?
- + SessionId: Text?

### Operations


### Relationships

- CartApiClient --dependency--> CartIdentityDto (uses wire DTO)
- CartApiModel --dependency--> CartIdentityDto (uses wire DTO)
- CartController --dependency--> CartIdentityDto (uses DTO)
- CartPage --dependency--> CartIdentityDto (uses wire DTO)
- CartService --dependency--> CartIdentityDto (uses DTO)
- CartView --dependency--> CartIdentityDto (uses wire DTO)
- CartViewModel --dependency--> CartIdentityDto (uses wire DTO)
- CurrentCustomer --dependency--> CartIdentityDto (uses DTO)
- ICartService --dependency--> CartIdentityDto (uses DTO)
- ICurrentCustomer --dependency--> CartIdentityDto (uses DTO)

## CartChangeDto

Ownership: FreshFood-API.DTOs. Role: DTO.

Basis: UC-C03; VOPC and analysis sequence scenario pages

### Attributes

- + ProductId: Text
- + Quantity: Integer

### Operations


### Relationships

- CartApiClient --dependency--> CartChangeDto (uses wire DTO)
- CartApiModel --dependency--> CartChangeDto (uses wire DTO)
- CartController --dependency--> CartChangeDto (uses DTO)
- CartPage --dependency--> CartChangeDto (uses wire DTO)
- CartService --dependency--> CartChangeDto (uses DTO)
- CartView --dependency--> CartChangeDto (uses wire DTO)
- CartViewModel --dependency--> CartChangeDto (uses wire DTO)
- ICartService --dependency--> CartChangeDto (uses DTO)

## CartResultDto

Ownership: FreshFood-API.DTOs. Role: DTO.

Basis: UC-C03; VOPC and analysis sequence scenario pages

### Attributes

- + Lines: Sequence<CartLineDto>
- + SubTotal: VndAmount
- + CanCheckout: Boolean
- + Warnings: Sequence<Text>

### Operations


### Relationships

- CartApiClient --dependency--> CartResultDto (uses wire DTO)
- CartApiModel --dependency--> CartResultDto (uses wire DTO)
- CartController --dependency--> CartResultDto (uses DTO)
- CartPage --dependency--> CartResultDto (uses wire DTO)
- CartResultDto --association--> CartLineDto (contains DTO)
- CartService --dependency--> CartResultDto (uses DTO)
- CartViewModel --dependency--> CartResultDto (uses wire DTO)
- ICartService --dependency--> CartResultDto (uses DTO)
- IMyOrdersService --dependency--> CartResultDto (uses DTO)
- MyOrdersApiClient --dependency--> CartResultDto (uses wire DTO)
- MyOrdersApiModel --dependency--> CartResultDto (uses wire DTO)
- MyOrdersController --dependency--> CartResultDto (uses DTO)
- MyOrdersService --dependency--> CartResultDto (uses DTO)
- MyOrdersViewModel --dependency--> CartResultDto (uses wire DTO)

## CartLineDto

Ownership: FreshFood-API.DTOs. Role: DTO.

Basis: UC-C03; VOPC and analysis sequence scenario pages

### Attributes

- + ProductId: Text
- + Quantity: Integer
- + AvailableQuantity: Integer
- + CurrentPrice: VndAmount
- + LineTotal: VndAmount

### Operations


### Relationships

- CartResultDto --association--> CartLineDto (contains DTO)

## CartPage

Ownership: FreshFood-Customer-Web.Pages. Role: boundary.

Basis: CartView Web rendering/events; ordinary reference to concrete CallService class; no DI

### Attributes

- - api: CartApiClient
- - state: CartResultDto?
- - isBusy: Boolean
- - errorCode: Text?

### Operations

- + Render(): View
- + OnGetCartAsync(): Void
- + OnChangeQuantityAsync(request: CartChangeDto): Void
- + OnRemoveItemAsync(productId: EntityId): Void

### Relationships

- CartPage --association--> CartApiClient (api)
- CartPage --dependency--> CartChangeDto (uses wire DTO)
- CartPage --dependency--> CartIdentityDto (uses wire DTO)
- CartPage --dependency--> CartResultDto (uses wire DTO)

## CartApiClient

Ownership: FreshFood-Customer-Web.CallService. Role: adapter.

Basis: Authenticated HTTPS/JSON and boundary serialization; ordinary frontend object/module lifecycle, no DI

### Attributes

- - http: HttpTransport

### Operations

- + GetCartAsync(): CartResultDto
- + ChangeQuantityAsync(request: CartChangeDto): CartResultDto
- + RemoveItemAsync(productId: EntityId): CartResultDto

### Relationships

- CartApiClient --dependency--> CartChangeDto (uses wire DTO)
- CartApiClient --dependency--> CartIdentityDto (uses wire DTO)
- CartApiClient --dependency--> CartResultDto (uses wire DTO)
- CartApiClient --remote--> CartController (HTTPS / JSON)
- CartPage --association--> CartApiClient (api)

## CartView

Ownership: FreshFood-App.Views. Role: boundary.

Basis: CartView Mobile rendering/events through ordinary ViewModel association; no DI

### Attributes

- - model: CartViewModel

### Operations

- + Build(): View
- + OnGetCart(identity: CartIdentityDto): Void
- + OnChangeQuantity(request: CartChangeDto): Void
- + OnRemoveItem(productId: EntityId): Void

### Relationships

- CartView --association--> CartViewModel (model)
- CartView --dependency--> CartChangeDto (uses wire DTO)
- CartView --dependency--> CartIdentityDto (uses wire DTO)

## CartViewModel

Ownership: FreshFood-App.ViewModels. Role: viewmodel.

Basis: MVVM state and orchestration; ordinary association to concrete API model; no DI

### Attributes

- - api: CartApiModel
- - state: CartResultDto?
- - isBusy: Boolean
- - errorCode: Text?

### Operations

- + GetCartAsync(): CartResultDto
- + ChangeQuantityAsync(request: CartChangeDto): CartResultDto
- + RemoveItemAsync(productId: EntityId): CartResultDto

### Relationships

- CartView --association--> CartViewModel (model)
- CartViewModel --association--> CartApiModel (api)
- CartViewModel --dependency--> CartChangeDto (uses wire DTO)
- CartViewModel --dependency--> CartIdentityDto (uses wire DTO)
- CartViewModel --dependency--> CartResultDto (uses wire DTO)

## CartApiModel

Ownership: FreshFood-App.Models. Role: adapter.

Basis: Authenticated HTTPS/JSON; ordinary frontend lifecycle; no DI or backend type imports

### Attributes

- - http: HttpTransport

### Operations

- + GetCartAsync(): CartResultDto
- + ChangeQuantityAsync(request: CartChangeDto): CartResultDto
- + RemoveItemAsync(productId: EntityId): CartResultDto

### Relationships

- CartApiModel --dependency--> CartChangeDto (uses wire DTO)
- CartApiModel --dependency--> CartIdentityDto (uses wire DTO)
- CartApiModel --dependency--> CartResultDto (uses wire DTO)
- CartApiModel --remote--> CartController (HTTPS / JSON)
- CartViewModel --association--> CartApiModel (api)

## IProfileService

Ownership: FreshFood-API.Services. Role: interface.

Basis: UC-C05; VOPC and analysis sequence scenario pages

### Attributes


### Operations

- + GetProfileAsync(): ProfileResultDto
- + UpdateProfileAsync(request: ProfileUpdateDto): ProfileResultDto
- + SaveAddressAsync(request: AddressInputDto): AddressDto
- + SetDefaultAddressAsync(addressId: Text): ProfileResultDto
- + DeleteAddressAsync(addressId: Text): OperationResultDto

### Relationships

- IProfileService --dependency--> AddressDto (uses DTO)
- IProfileService --dependency--> AddressInputDto (uses DTO)
- IProfileService --dependency--> OperationResultDto (uses DTO)
- IProfileService --dependency--> ProfileResultDto (uses DTO)
- IProfileService --dependency--> ProfileUpdateDto (uses DTO)
- ProfileController --association--> IProfileService (holds reference)
- ProfileController --association--> IProfileService (service)
- ProfileService --realization--> IProfileService (implements)

## ProfileService

Ownership: FreshFood-API.Services.Implements. Role: service.

Basis: UC-C05; VOPC and analysis sequence scenario pages

### Attributes

- - profileRepository: IProfileRepository
- - currentCustomer: ICurrentCustomer
- - unitOfWork: IUnitOfWork
- - geocodingGateway: IGeocodingGateway

### Operations

- + ProfileService(profileRepository: IProfileRepository, currentCustomer: ICurrentCustomer, unitOfWork: IUnitOfWork, geocodingGateway: IGeocodingGateway)
- + GetProfileAsync(): ProfileResultDto
- + UpdateProfileAsync(request: ProfileUpdateDto): ProfileResultDto
- + SaveAddressAsync(request: AddressInputDto): AddressDto
- + SetDefaultAddressAsync(addressId: Text): ProfileResultDto
- + DeleteAddressAsync(addressId: Text): OperationResultDto

### Relationships

- ProfileService --association--> ICurrentCustomer (holds reference)
- ProfileService --association--> IGeocodingGateway (holds reference)
- ProfileService --association--> IProfileRepository (holds reference)
- ProfileService --association--> IUnitOfWork (holds reference)
- ProfileService --dependency--> AddressDto (uses DTO)
- ProfileService --dependency--> AddressInputDto (uses DTO)
- ProfileService --dependency--> Customer (uses entity)
- ProfileService --dependency--> CustomerAddress (uses entity)
- ProfileService --dependency--> OperationResultDto (uses DTO)
- ProfileService --dependency--> Order (uses entity)
- ProfileService --dependency--> ProfileResultDto (uses DTO)
- ProfileService --dependency--> ProfileUpdateDto (uses DTO)
- ProfileService --realization--> IProfileService (implements)

## ProfileController

Ownership: FreshFood-API.Controllers. Role: controller.

Basis: UC-C05; VOPC and analysis sequence scenario pages

### Attributes

- - service: IProfileService

### Operations

- + ProfileController(service: IProfileService)
- + GetProfileAsync(): ProfileResultDto
- + UpdateProfileAsync(request: ProfileUpdateDto): ProfileResultDto
- + SaveAddressAsync(request: AddressInputDto): AddressDto
- + SetDefaultAddressAsync(addressId: Text): ProfileResultDto
- + DeleteAddressAsync(addressId: Text): OperationResultDto

### Relationships

- ProfileApiClient --remote--> ProfileController (HTTPS / JSON)
- ProfileApiModel --remote--> ProfileController (HTTPS / JSON)
- ProfileController --association--> IProfileService (holds reference)
- ProfileController --association--> IProfileService (service)
- ProfileController --dependency--> AddressDto (uses DTO)
- ProfileController --dependency--> AddressInputDto (uses DTO)
- ProfileController --dependency--> OperationResultDto (uses DTO)
- ProfileController --dependency--> ProfileResultDto (uses DTO)
- ProfileController --dependency--> ProfileUpdateDto (uses DTO)

## IProfileRepository

Ownership: FreshFood.Reposistory.Repository. Role: interface.

Basis: UC-C05; VOPC and analysis sequence scenario pages

### Attributes


### Operations

- + GetCustomerAsync(customerId: Text): Customer
- + GetAddressesAsync(customerId: Text): Sequence<CustomerAddress>
- + HasActiveOrderAsync(customerId: Text, addressId: Text): Boolean
- + SaveCustomerAsync(customer: Customer): Void
- + SaveAddressAsync(address: CustomerAddress): Void
- + DeleteAddressAsync(customerId: Text, addressId: Text): Void

### Relationships

- IProfileRepository --dependency--> Customer (uses entity)
- IProfileRepository --dependency--> CustomerAddress (uses entity)
- ProfileRepository --realization--> IProfileRepository (implements)
- ProfileService --association--> IProfileRepository (holds reference)

## ProfileRepository

Ownership: FreshFood.Reposistory.Repository.Implements. Role: repository.

Basis: UC-C05; VOPC and analysis sequence scenario pages

### Attributes

- - session: IRepositorySession

### Operations

- + ProfileRepository(session: IRepositorySession)
- + GetCustomerAsync(customerId: Text): Customer
- + GetAddressesAsync(customerId: Text): Sequence<CustomerAddress>
- + HasActiveOrderAsync(customerId: Text, addressId: Text): Boolean
- + SaveCustomerAsync(customer: Customer): Void
- + SaveAddressAsync(address: CustomerAddress): Void
- + DeleteAddressAsync(customerId: Text, addressId: Text): Void

### Relationships

- ProfileRepository --dependency--> Customer (uses entity)
- ProfileRepository --dependency--> CustomerAddress (uses entity)
- ProfileRepository --dependency--> Order (uses entity)
- ProfileRepository --realization--> IProfileRepository (implements)

## ProfileResultDto

Ownership: FreshFood-API.DTOs. Role: DTO.

Basis: UC-C05; VOPC and analysis sequence scenario pages

### Attributes

- + CustomerId: Text
- + FullName: Text
- + Phone: Text
- + Email: Text?
- + Addresses: Sequence<AddressDto>

### Operations


### Relationships

- IProfileService --dependency--> ProfileResultDto (uses DTO)
- ProfileApiClient --dependency--> ProfileResultDto (uses wire DTO)
- ProfileApiModel --dependency--> ProfileResultDto (uses wire DTO)
- ProfileController --dependency--> ProfileResultDto (uses DTO)
- ProfilePage --dependency--> ProfileResultDto (uses wire DTO)
- ProfileResultDto --association--> AddressDto (contains DTO)
- ProfileService --dependency--> ProfileResultDto (uses DTO)
- ProfileViewModel --dependency--> ProfileResultDto (uses wire DTO)

## ProfileUpdateDto

Ownership: FreshFood-API.DTOs. Role: DTO.

Basis: UC-C05; VOPC and analysis sequence scenario pages

### Attributes

- + FullName: Text
- + Email: Text?

### Operations


### Relationships

- IProfileService --dependency--> ProfileUpdateDto (uses DTO)
- ProfileAddressView --dependency--> ProfileUpdateDto (uses wire DTO)
- ProfileApiClient --dependency--> ProfileUpdateDto (uses wire DTO)
- ProfileApiModel --dependency--> ProfileUpdateDto (uses wire DTO)
- ProfileController --dependency--> ProfileUpdateDto (uses DTO)
- ProfilePage --dependency--> ProfileUpdateDto (uses wire DTO)
- ProfileService --dependency--> ProfileUpdateDto (uses DTO)
- ProfileViewModel --dependency--> ProfileUpdateDto (uses wire DTO)

## AddressInputDto

Ownership: FreshFood-API.DTOs. Role: DTO.

Basis: UC-C05; VOPC and analysis sequence scenario pages

### Attributes

- + AddressId: Text?
- + RecipientName: Text
- + RecipientPhone: Text
- + StreetAddress: Text
- + IsDefault: Boolean

### Operations


### Relationships

- IProfileService --dependency--> AddressInputDto (uses DTO)
- ProfileAddressView --dependency--> AddressInputDto (uses wire DTO)
- ProfileApiClient --dependency--> AddressInputDto (uses wire DTO)
- ProfileApiModel --dependency--> AddressInputDto (uses wire DTO)
- ProfileController --dependency--> AddressInputDto (uses DTO)
- ProfilePage --dependency--> AddressInputDto (uses wire DTO)
- ProfileService --dependency--> AddressInputDto (uses DTO)
- ProfileViewModel --dependency--> AddressInputDto (uses wire DTO)

## AddressDto

Ownership: FreshFood-API.DTOs. Role: DTO.

Basis: UC-C05; VOPC and analysis sequence scenario pages

### Attributes

- + AddressId: Text
- + RecipientName: Text
- + RecipientPhone: Text
- + StreetAddress: Text
- + Latitude: Decimal
- + Longitude: Decimal
- + IsDefault: Boolean

### Operations


### Relationships

- IProfileService --dependency--> AddressDto (uses DTO)
- OrderDetailsDto --association--> AddressDto (contains DTO)
- ProfileApiClient --dependency--> AddressDto (uses wire DTO)
- ProfileApiModel --dependency--> AddressDto (uses wire DTO)
- ProfileController --dependency--> AddressDto (uses DTO)
- ProfileResultDto --association--> AddressDto (contains DTO)
- ProfileService --dependency--> AddressDto (uses DTO)
- ProfileViewModel --dependency--> AddressDto (uses wire DTO)

## GeoPointDto

Ownership: FreshFood-API.DTOs. Role: DTO.

Basis: UC-C05; VOPC and analysis sequence scenario pages

### Attributes

- + Latitude: Decimal
- + Longitude: Decimal

### Operations


### Relationships

- GoogleMapsGeocodingAdapter --dependency--> GeoPointDto (uses DTO)
- IGeocodingGateway --dependency--> GeoPointDto (uses DTO)

## ProfilePage

Ownership: FreshFood-Customer-Web.Pages. Role: boundary.

Basis: ProfileAddressView Web rendering/events; ordinary reference to concrete CallService class; no DI

### Attributes

- - api: ProfileApiClient
- - state: ProfileResultDto?
- - isBusy: Boolean
- - errorCode: Text?

### Operations

- + Render(): View
- + OnGetProfileAsync(): Void
- + OnUpdateProfileAsync(request: ProfileUpdateDto): Void
- + OnSaveAddressAsync(request: AddressInputDto): Void
- + OnSetDefaultAddressAsync(addressId: EntityId): Void
- + OnDeleteAddressAsync(addressId: EntityId): Void

### Relationships

- ProfilePage --association--> ProfileApiClient (api)
- ProfilePage --dependency--> AddressInputDto (uses wire DTO)
- ProfilePage --dependency--> ProfileResultDto (uses wire DTO)
- ProfilePage --dependency--> ProfileUpdateDto (uses wire DTO)

## ProfileApiClient

Ownership: FreshFood-Customer-Web.CallService. Role: adapter.

Basis: Authenticated HTTPS/JSON and boundary serialization; ordinary frontend object/module lifecycle, no DI

### Attributes

- - http: HttpTransport

### Operations

- + GetProfileAsync(): ProfileResultDto
- + UpdateProfileAsync(request: ProfileUpdateDto): ProfileResultDto
- + SaveAddressAsync(request: AddressInputDto): AddressDto
- + SetDefaultAddressAsync(addressId: EntityId): ProfileResultDto
- + DeleteAddressAsync(addressId: EntityId): OperationResultDto

### Relationships

- ProfileApiClient --dependency--> AddressDto (uses wire DTO)
- ProfileApiClient --dependency--> AddressInputDto (uses wire DTO)
- ProfileApiClient --dependency--> OperationResultDto (uses wire DTO)
- ProfileApiClient --dependency--> ProfileResultDto (uses wire DTO)
- ProfileApiClient --dependency--> ProfileUpdateDto (uses wire DTO)
- ProfileApiClient --remote--> ProfileController (HTTPS / JSON)
- ProfilePage --association--> ProfileApiClient (api)

## ProfileAddressView

Ownership: FreshFood-App.Views. Role: boundary.

Basis: ProfileAddressView Mobile rendering/events through ordinary ViewModel association; no DI

### Attributes

- - model: ProfileViewModel

### Operations

- + Build(): View
- + OnGetProfile(): Void
- + OnUpdateProfile(request: ProfileUpdateDto): Void
- + OnSaveAddress(request: AddressInputDto): Void
- + OnSetDefaultAddress(addressId: EntityId): Void
- + OnDeleteAddress(addressId: EntityId): Void

### Relationships

- ProfileAddressView --association--> ProfileViewModel (model)
- ProfileAddressView --dependency--> AddressInputDto (uses wire DTO)
- ProfileAddressView --dependency--> ProfileUpdateDto (uses wire DTO)

## ProfileViewModel

Ownership: FreshFood-App.ViewModels. Role: viewmodel.

Basis: MVVM state and orchestration; ordinary association to concrete API model; no DI

### Attributes

- - api: ProfileApiModel
- - state: ProfileResultDto?
- - isBusy: Boolean
- - errorCode: Text?

### Operations

- + GetProfileAsync(): ProfileResultDto
- + UpdateProfileAsync(request: ProfileUpdateDto): ProfileResultDto
- + SaveAddressAsync(request: AddressInputDto): AddressDto
- + SetDefaultAddressAsync(addressId: EntityId): ProfileResultDto
- + DeleteAddressAsync(addressId: EntityId): OperationResultDto

### Relationships

- ProfileAddressView --association--> ProfileViewModel (model)
- ProfileViewModel --association--> ProfileApiModel (api)
- ProfileViewModel --dependency--> AddressDto (uses wire DTO)
- ProfileViewModel --dependency--> AddressInputDto (uses wire DTO)
- ProfileViewModel --dependency--> OperationResultDto (uses wire DTO)
- ProfileViewModel --dependency--> ProfileResultDto (uses wire DTO)
- ProfileViewModel --dependency--> ProfileUpdateDto (uses wire DTO)

## ProfileApiModel

Ownership: FreshFood-App.Models. Role: adapter.

Basis: Authenticated HTTPS/JSON; ordinary frontend lifecycle; no DI or backend type imports

### Attributes

- - http: HttpTransport

### Operations

- + GetProfileAsync(): ProfileResultDto
- + UpdateProfileAsync(request: ProfileUpdateDto): ProfileResultDto
- + SaveAddressAsync(request: AddressInputDto): AddressDto
- + SetDefaultAddressAsync(addressId: EntityId): ProfileResultDto
- + DeleteAddressAsync(addressId: EntityId): OperationResultDto

### Relationships

- ProfileApiModel --dependency--> AddressDto (uses wire DTO)
- ProfileApiModel --dependency--> AddressInputDto (uses wire DTO)
- ProfileApiModel --dependency--> OperationResultDto (uses wire DTO)
- ProfileApiModel --dependency--> ProfileResultDto (uses wire DTO)
- ProfileApiModel --dependency--> ProfileUpdateDto (uses wire DTO)
- ProfileApiModel --remote--> ProfileController (HTTPS / JSON)
- ProfileViewModel --association--> ProfileApiModel (api)

## ICheckoutService

Ownership: FreshFood-API.Services. Role: interface.

Basis: UC-C06; VOPC and analysis sequence scenario pages

### Attributes


### Operations

- + PrepareCheckoutAsync(request: CheckoutInputDto): CheckoutSummaryDto
- + PlaceOrderAsync(request: PlaceOrderDto): OrderConfirmationDto
- + CreatePaymentQrAsync(request: PaymentQrRequestDto): PaymentQrDto
- + HandleVerifiedPaymentAsync(request: PaymentNoticeDto): PaymentResultDto

### Relationships

- CheckoutController --association--> ICheckoutService (holds reference)
- CheckoutController --association--> ICheckoutService (service)
- CheckoutService --realization--> ICheckoutService (implements)
- ICheckoutService --dependency--> CheckoutInputDto (uses DTO)
- ICheckoutService --dependency--> CheckoutSummaryDto (uses DTO)
- ICheckoutService --dependency--> OrderConfirmationDto (uses DTO)
- ICheckoutService --dependency--> PaymentNoticeDto (uses DTO)
- ICheckoutService --dependency--> PaymentQrDto (uses DTO)
- ICheckoutService --dependency--> PaymentQrRequestDto (uses DTO)
- ICheckoutService --dependency--> PaymentResultDto (uses DTO)
- ICheckoutService --dependency--> PlaceOrderDto (uses DTO)
- PaymentNoticeHandler --association--> ICheckoutService (holds reference)

## CheckoutService

Ownership: FreshFood-API.Services.Implements. Role: service.

Basis: UC-C06; VOPC and analysis sequence scenario pages

### Attributes

- - checkoutRepository: ICheckoutRepository
- - currentCustomer: ICurrentCustomer
- - unitOfWork: IUnitOfWork
- - distanceCalculator: IDistanceCalculator
- - paymentGateway: IPaymentGateway
- - notificationGateway: INotificationGateway
- - orderStateMachine: IOrderStateMachine
- - pricing: IBatchPricingPolicy
- - deliveryFeePolicy: IDeliveryFeePolicy

### Operations

- + CheckoutService(checkoutRepository: ICheckoutRepository, currentCustomer: ICurrentCustomer, unitOfWork: IUnitOfWork, distanceCalculator: IDistanceCalculator, paymentGateway: IPaymentGateway, notificationGateway: INotificationGateway, orderStateMachine: IOrderStateMachine, pricing: IBatchPricingPolicy, deliveryFeePolicy: IDeliveryFeePolicy)
- + PrepareCheckoutAsync(request: CheckoutInputDto): CheckoutSummaryDto
- + RequestHash(request: PlaceOrderDto): Text
- + PlaceOrderAsync(request: PlaceOrderDto): OrderConfirmationDto
- + CreatePaymentQrAsync(request: PaymentQrRequestDto): PaymentQrDto
- + HandleVerifiedPaymentAsync(request: PaymentNoticeDto): PaymentResultDto

### Relationships

- CheckoutService --association--> IBatchPricingPolicy (pricing)
- CheckoutService --association--> ICheckoutRepository (holds reference)
- CheckoutService --association--> ICurrentCustomer (holds reference)
- CheckoutService --association--> IDeliveryFeePolicy (deliveryFeePolicy)
- CheckoutService --association--> IDistanceCalculator (distanceCalculator)
- CheckoutService --association--> INotificationGateway (holds reference)
- CheckoutService --association--> IOrderStateMachine (holds reference)
- CheckoutService --association--> IPaymentGateway (holds reference)
- CheckoutService --association--> IUnitOfWork (holds reference)
- CheckoutService --dependency--> BatchInventory (uses entity)
- CheckoutService --dependency--> Cart (uses entity)
- CheckoutService --dependency--> CartItem (uses entity)
- CheckoutService --dependency--> CheckoutInputDto (uses DTO)
- CheckoutService --dependency--> CheckoutSummaryDto (uses DTO)
- CheckoutService --dependency--> Customer (uses entity)
- CheckoutService --dependency--> CustomerAddress (uses entity)
- CheckoutService --dependency--> Order (uses entity)
- CheckoutService --dependency--> OrderConfirmationDto (uses DTO)
- CheckoutService --dependency--> OrderDetail (uses entity)
- CheckoutService --dependency--> PaymentNoticeDto (uses DTO)
- CheckoutService --dependency--> PaymentQrDto (uses DTO)
- CheckoutService --dependency--> PaymentQrRequestDto (uses DTO)
- CheckoutService --dependency--> PaymentResultDto (uses DTO)
- CheckoutService --dependency--> PlaceOrderDto (uses DTO)
- CheckoutService --dependency--> Product (uses entity)
- CheckoutService --realization--> ICheckoutService (implements)

## CheckoutController

Ownership: FreshFood-API.Controllers. Role: controller.

Basis: UC-C06; VOPC and analysis sequence scenario pages

### Attributes

- - service: ICheckoutService

### Operations

- + CheckoutController(service: ICheckoutService)
- + PrepareCheckoutAsync(request: CheckoutInputDto): CheckoutSummaryDto
- + PlaceOrderAsync(request: PlaceOrderDto): OrderConfirmationDto
- + CreatePaymentQrAsync(request: PaymentQrRequestDto): PaymentQrDto

### Relationships

- CheckoutApiClient --remote--> CheckoutController (HTTPS / JSON)
- CheckoutApiModel --remote--> CheckoutController (HTTPS / JSON)
- CheckoutController --association--> ICheckoutService (holds reference)
- CheckoutController --association--> ICheckoutService (service)
- CheckoutController --dependency--> CheckoutInputDto (uses DTO)
- CheckoutController --dependency--> CheckoutSummaryDto (uses DTO)
- CheckoutController --dependency--> OrderConfirmationDto (uses DTO)
- CheckoutController --dependency--> PaymentQrDto (uses DTO)
- CheckoutController --dependency--> PaymentQrRequestDto (uses DTO)
- CheckoutController --dependency--> PlaceOrderDto (uses DTO)

## ICheckoutRepository

Ownership: FreshFood.Reposistory.Repository. Role: interface.

Basis: UC-C06; VOPC and analysis sequence scenario pages

### Attributes


### Operations

- + GetCheckoutCartAsync(customerId: Text): Cart
- + GetOwnedAddressAsync(customerId: Text, addressId: Text): CustomerAddress
- + LockFefoBatchesAsync(productIds: Sequence<Text>): Sequence<BatchInventory>
- + SaveOrderAsync(order: Order): Void
- + SavePaymentOnceAsync(payment: OrderPayment): Boolean
- + ClearCartAsync(cartId: Text): Void
- + ClaimCheckoutAsync(customerId: Text, reference: Text, key: Text, requestHash: Text): Value
- + CompleteCheckoutAsync(customerId: Text, reference: Text, key: Text, response: Value): Void

### Relationships

- CheckoutRepository --realization--> ICheckoutRepository (implements)
- CheckoutService --association--> ICheckoutRepository (holds reference)
- ICheckoutRepository --dependency--> BatchInventory (uses entity)
- ICheckoutRepository --dependency--> Cart (uses entity)
- ICheckoutRepository --dependency--> CustomerAddress (uses entity)
- ICheckoutRepository --dependency--> Order (uses entity)

## CheckoutRepository

Ownership: FreshFood.Reposistory.Repository.Implements. Role: repository.

Basis: UC-C06; VOPC and analysis sequence scenario pages

### Attributes

- - session: IRepositorySession
- - fefo: IFefoBatchSpecification

### Operations

- + CheckoutRepository(session: IRepositorySession, fefo: IFefoBatchSpecification)
- + GetCheckoutCartAsync(customerId: Text): Cart
- + GetOwnedAddressAsync(customerId: Text, addressId: Text): CustomerAddress
- + LockFefoBatchesAsync(productIds: Sequence<Text>): Sequence<BatchInventory>
- + SaveOrderAsync(order: Order): Void
- + SavePaymentOnceAsync(payment: OrderPayment): Boolean
- + ClearCartAsync(cartId: Text): Void
- + ClaimCheckoutAsync(customerId: Text, reference: Text, key: Text, requestHash: Text): Value
- + CompleteCheckoutAsync(customerId: Text, reference: Text, key: Text, response: Value): Void

### Relationships

- CheckoutRepository --association--> IFefoBatchSpecification (fefo)
- CheckoutRepository --dependency--> BatchInventory (uses entity)
- CheckoutRepository --dependency--> Cart (uses entity)
- CheckoutRepository --dependency--> CartItem (uses entity)
- CheckoutRepository --dependency--> Customer (uses entity)
- CheckoutRepository --dependency--> CustomerAddress (uses entity)
- CheckoutRepository --dependency--> Order (uses entity)
- CheckoutRepository --dependency--> OrderDetail (uses entity)
- CheckoutRepository --dependency--> Product (uses entity)
- CheckoutRepository --realization--> ICheckoutRepository (implements)

## CheckoutInputDto

Ownership: FreshFood-API.DTOs. Role: DTO.

Basis: UC-C06; VOPC and analysis sequence scenario pages

### Attributes

- + AddressId: Text

### Operations


### Relationships

- CheckoutApiClient --dependency--> CheckoutInputDto (uses wire DTO)
- CheckoutApiModel --dependency--> CheckoutInputDto (uses wire DTO)
- CheckoutController --dependency--> CheckoutInputDto (uses DTO)
- CheckoutPage --dependency--> CheckoutInputDto (uses wire DTO)
- CheckoutService --dependency--> CheckoutInputDto (uses DTO)
- CheckoutView --dependency--> CheckoutInputDto (uses wire DTO)
- CheckoutViewModel --dependency--> CheckoutInputDto (uses wire DTO)
- ICheckoutService --dependency--> CheckoutInputDto (uses DTO)

## CheckoutSummaryDto

Ownership: FreshFood-API.DTOs. Role: DTO.

Basis: UC-C06; VOPC and analysis sequence scenario pages

### Attributes

- + SubTotal: VndAmount
- + ShippingFee: VndAmount
- + DistanceKm: Decimal
- + Total: VndAmount
- + Lines: Sequence<CheckoutLineDto>

### Operations


### Relationships

- CheckoutApiClient --dependency--> CheckoutSummaryDto (uses wire DTO)
- CheckoutApiModel --dependency--> CheckoutSummaryDto (uses wire DTO)
- CheckoutController --dependency--> CheckoutSummaryDto (uses DTO)
- CheckoutPage --dependency--> CheckoutSummaryDto (uses wire DTO)
- CheckoutService --dependency--> CheckoutSummaryDto (uses DTO)
- CheckoutSummaryDto --association--> CheckoutLineDto (contains DTO)
- CheckoutViewModel --dependency--> CheckoutSummaryDto (uses wire DTO)
- ICheckoutService --dependency--> CheckoutSummaryDto (uses DTO)

## CheckoutLineDto

Ownership: FreshFood-API.DTOs. Role: DTO.

Basis: UC-C06; VOPC and analysis sequence scenario pages

### Attributes

- + ProductId: Text
- + BatchId: Text
- + Quantity: Integer
- + UnitPrice: VndAmount
- + Discount: VndAmount

### Operations


### Relationships

- CheckoutSummaryDto --association--> CheckoutLineDto (contains DTO)

## PlaceOrderDto

Ownership: FreshFood-API.DTOs. Role: DTO.

Basis: UC-C06; VOPC and analysis sequence scenario pages

### Attributes

- + AddressId: Text
- + PaymentMethod: PaymentMethod
- + CheckoutReference: Text
- + IdempotencyKey: Text

### Operations


### Relationships

- CheckoutApiClient --dependency--> PlaceOrderDto (uses wire DTO)
- CheckoutApiModel --dependency--> PlaceOrderDto (uses wire DTO)
- CheckoutController --dependency--> PlaceOrderDto (uses DTO)
- CheckoutPage --dependency--> PlaceOrderDto (uses wire DTO)
- CheckoutService --dependency--> PlaceOrderDto (uses DTO)
- CheckoutView --dependency--> PlaceOrderDto (uses wire DTO)
- CheckoutViewModel --dependency--> PlaceOrderDto (uses wire DTO)
- ICheckoutService --dependency--> PlaceOrderDto (uses DTO)

## OrderConfirmationDto

Ownership: FreshFood-API.DTOs. Role: DTO.

Basis: UC-C06; VOPC and analysis sequence scenario pages

### Attributes

- + OrderId: Text
- + OrderNumber: Text
- + Status: OrderStatus
- + PaymentStatus: PaymentStatus
- + Total: VndAmount

### Operations


### Relationships

- CheckoutApiClient --dependency--> OrderConfirmationDto (uses wire DTO)
- CheckoutApiModel --dependency--> OrderConfirmationDto (uses wire DTO)
- CheckoutController --dependency--> OrderConfirmationDto (uses DTO)
- CheckoutService --dependency--> OrderConfirmationDto (uses DTO)
- CheckoutViewModel --dependency--> OrderConfirmationDto (uses wire DTO)
- ICheckoutService --dependency--> OrderConfirmationDto (uses DTO)

## PaymentQrRequestDto

Ownership: FreshFood-API.DTOs. Role: DTO.

Basis: UC-C06; VOPC and analysis sequence scenario pages

### Attributes

- + CheckoutReference: Text

### Operations


### Relationships

- CheckoutApiClient --dependency--> PaymentQrRequestDto (uses wire DTO)
- CheckoutApiModel --dependency--> PaymentQrRequestDto (uses wire DTO)
- CheckoutController --dependency--> PaymentQrRequestDto (uses DTO)
- CheckoutPage --dependency--> PaymentQrRequestDto (uses wire DTO)
- CheckoutService --dependency--> PaymentQrRequestDto (uses DTO)
- CheckoutView --dependency--> PaymentQrRequestDto (uses wire DTO)
- CheckoutViewModel --dependency--> PaymentQrRequestDto (uses wire DTO)
- ICheckoutService --dependency--> PaymentQrRequestDto (uses DTO)

## PaymentQrDto

Ownership: FreshFood-API.DTOs. Role: DTO.

Basis: UC-C06; VOPC and analysis sequence scenario pages

### Attributes

- + QrPayload: Text
- + ExpiresAt: DateTime

### Operations


### Relationships

- CheckoutApiClient --dependency--> PaymentQrDto (uses wire DTO)
- CheckoutApiModel --dependency--> PaymentQrDto (uses wire DTO)
- CheckoutController --dependency--> PaymentQrDto (uses DTO)
- CheckoutService --dependency--> PaymentQrDto (uses DTO)
- CheckoutViewModel --dependency--> PaymentQrDto (uses wire DTO)
- ICheckoutService --dependency--> PaymentQrDto (uses DTO)
- IPaymentGateway --dependency--> PaymentQrDto (uses DTO)
- SePayPaymentAdapter --dependency--> PaymentQrDto (uses DTO)

## PaymentNoticeDto

Ownership: FreshFood-API.DTOs. Role: DTO.

Basis: UC-C06; VOPC and analysis sequence scenario pages

### Attributes

- + RawBody: Text
- + Signature: Text
- + ProviderReference: Text

### Operations


### Relationships

- CheckoutService --dependency--> PaymentNoticeDto (uses DTO)
- ICheckoutService --dependency--> PaymentNoticeDto (uses DTO)
- IPaymentGateway --dependency--> PaymentNoticeDto (uses DTO)
- PaymentNoticeHandler --dependency--> PaymentNoticeDto (uses DTO)
- SePayPaymentAdapter --dependency--> PaymentNoticeDto (uses DTO)

## PaymentResultDto

Ownership: FreshFood-API.DTOs. Role: DTO.

Basis: UC-C06; VOPC and analysis sequence scenario pages

### Attributes

- + Accepted: Boolean
- + Duplicate: Boolean
- + PaymentStatus: PaymentStatus

### Operations


### Relationships

- CheckoutPage --dependency--> PaymentResultDto (uses wire DTO)
- CheckoutService --dependency--> PaymentResultDto (uses DTO)
- CheckoutView --dependency--> PaymentResultDto (uses wire DTO)
- ICheckoutService --dependency--> PaymentResultDto (uses DTO)
- PaymentNoticeHandler --dependency--> PaymentResultDto (uses DTO)

## CheckoutPage

Ownership: FreshFood-Customer-Web.Pages. Role: boundary.

Basis: CheckoutView Web rendering/events; ordinary reference to concrete CallService class; no DI

### Attributes

- - api: CheckoutApiClient
- - state: CheckoutSummaryDto?
- - isBusy: Boolean
- - errorCode: Text?

### Operations

- + Render(): View
- + OnPrepareCheckoutAsync(request: CheckoutInputDto): Void
- + OnPlaceOrderAsync(request: PlaceOrderDto): Void
- + OnCreatePaymentQrAsync(request: PaymentQrRequestDto): Void
- + OnPaymentStateChanged(result: PaymentResultDto): Void

### Relationships

- CheckoutPage --association--> CheckoutApiClient (api)
- CheckoutPage --dependency--> CheckoutInputDto (uses wire DTO)
- CheckoutPage --dependency--> CheckoutSummaryDto (uses wire DTO)
- CheckoutPage --dependency--> PaymentQrRequestDto (uses wire DTO)
- CheckoutPage --dependency--> PaymentResultDto (uses wire DTO)
- CheckoutPage --dependency--> PlaceOrderDto (uses wire DTO)

## CheckoutApiClient

Ownership: FreshFood-Customer-Web.CallService. Role: adapter.

Basis: Authenticated HTTPS/JSON and boundary serialization; ordinary frontend object/module lifecycle, no DI

### Attributes

- - http: HttpTransport

### Operations

- + PrepareCheckoutAsync(request: CheckoutInputDto): CheckoutSummaryDto
- + PlaceOrderAsync(request: PlaceOrderDto): OrderConfirmationDto
- + CreatePaymentQrAsync(request: PaymentQrRequestDto): PaymentQrDto

### Relationships

- CheckoutApiClient --dependency--> CheckoutInputDto (uses wire DTO)
- CheckoutApiClient --dependency--> CheckoutSummaryDto (uses wire DTO)
- CheckoutApiClient --dependency--> OrderConfirmationDto (uses wire DTO)
- CheckoutApiClient --dependency--> PaymentQrDto (uses wire DTO)
- CheckoutApiClient --dependency--> PaymentQrRequestDto (uses wire DTO)
- CheckoutApiClient --dependency--> PlaceOrderDto (uses wire DTO)
- CheckoutApiClient --remote--> CheckoutController (HTTPS / JSON)
- CheckoutPage --association--> CheckoutApiClient (api)

## CheckoutView

Ownership: FreshFood-App.Views. Role: boundary.

Basis: CheckoutView Mobile rendering/events through ordinary ViewModel association; no DI

### Attributes

- - model: CheckoutViewModel

### Operations

- + Build(): View
- + OnPrepareCheckout(request: CheckoutInputDto): Void
- + OnPlaceOrder(request: PlaceOrderDto): Void
- + OnCreatePaymentQr(request: PaymentQrRequestDto): Void
- + OnPaymentStateChanged(result: PaymentResultDto): Void

### Relationships

- CheckoutView --association--> CheckoutViewModel (model)
- CheckoutView --dependency--> CheckoutInputDto (uses wire DTO)
- CheckoutView --dependency--> PaymentQrRequestDto (uses wire DTO)
- CheckoutView --dependency--> PaymentResultDto (uses wire DTO)
- CheckoutView --dependency--> PlaceOrderDto (uses wire DTO)

## CheckoutViewModel

Ownership: FreshFood-App.ViewModels. Role: viewmodel.

Basis: MVVM state and orchestration; ordinary association to concrete API model; no DI

### Attributes

- - api: CheckoutApiModel
- - state: CheckoutSummaryDto?
- - isBusy: Boolean
- - errorCode: Text?

### Operations

- + PrepareCheckoutAsync(request: CheckoutInputDto): CheckoutSummaryDto
- + PlaceOrderAsync(request: PlaceOrderDto): OrderConfirmationDto
- + CreatePaymentQrAsync(request: PaymentQrRequestDto): PaymentQrDto

### Relationships

- CheckoutView --association--> CheckoutViewModel (model)
- CheckoutViewModel --association--> CheckoutApiModel (api)
- CheckoutViewModel --dependency--> CheckoutInputDto (uses wire DTO)
- CheckoutViewModel --dependency--> CheckoutSummaryDto (uses wire DTO)
- CheckoutViewModel --dependency--> OrderConfirmationDto (uses wire DTO)
- CheckoutViewModel --dependency--> PaymentQrDto (uses wire DTO)
- CheckoutViewModel --dependency--> PaymentQrRequestDto (uses wire DTO)
- CheckoutViewModel --dependency--> PlaceOrderDto (uses wire DTO)

## CheckoutApiModel

Ownership: FreshFood-App.Models. Role: adapter.

Basis: Authenticated HTTPS/JSON; ordinary frontend lifecycle; no DI or backend type imports

### Attributes

- - http: HttpTransport

### Operations

- + PrepareCheckoutAsync(request: CheckoutInputDto): CheckoutSummaryDto
- + PlaceOrderAsync(request: PlaceOrderDto): OrderConfirmationDto
- + CreatePaymentQrAsync(request: PaymentQrRequestDto): PaymentQrDto

### Relationships

- CheckoutApiModel --dependency--> CheckoutInputDto (uses wire DTO)
- CheckoutApiModel --dependency--> CheckoutSummaryDto (uses wire DTO)
- CheckoutApiModel --dependency--> OrderConfirmationDto (uses wire DTO)
- CheckoutApiModel --dependency--> PaymentQrDto (uses wire DTO)
- CheckoutApiModel --dependency--> PaymentQrRequestDto (uses wire DTO)
- CheckoutApiModel --dependency--> PlaceOrderDto (uses wire DTO)
- CheckoutApiModel --remote--> CheckoutController (HTTPS / JSON)
- CheckoutViewModel --association--> CheckoutApiModel (api)

## IMyOrdersService

Ownership: FreshFood-API.Services. Role: interface.

Basis: UC-C07; VOPC and analysis sequence scenario pages

### Attributes


### Operations

- + GetOrdersAsync(): OrderListDto
- + GetOrderDetailsAsync(orderId: Text): OrderDetailsDto
- + CancelOrderAsync(request: CancelOrderDto): OperationResultDto
- + ReorderAsync(orderId: Text): CartResultDto
- + SubmitReviewAsync(request: OrderReviewDto): OperationResultDto

### Relationships

- IMyOrdersService --dependency--> CancelOrderDto (uses DTO)
- IMyOrdersService --dependency--> CartResultDto (uses DTO)
- IMyOrdersService --dependency--> OperationResultDto (uses DTO)
- IMyOrdersService --dependency--> OrderDetailsDto (uses DTO)
- IMyOrdersService --dependency--> OrderListDto (uses DTO)
- IMyOrdersService --dependency--> OrderReviewDto (uses DTO)
- MyOrdersController --association--> IMyOrdersService (holds reference)
- MyOrdersController --association--> IMyOrdersService (service)
- MyOrdersService --realization--> IMyOrdersService (implements)

## MyOrdersService

Ownership: FreshFood-API.Services.Implements. Role: service.

Basis: UC-C07; VOPC and analysis sequence scenario pages

### Attributes

- - myOrdersRepository: IMyOrdersRepository
- - currentCustomer: ICurrentCustomer
- - unitOfWork: IUnitOfWork
- - notificationGateway: INotificationGateway
- - orderStateMachine: IOrderStateMachine
- - pricing: IBatchPricingPolicy

### Operations

- + MyOrdersService(myOrdersRepository: IMyOrdersRepository, currentCustomer: ICurrentCustomer, unitOfWork: IUnitOfWork, notificationGateway: INotificationGateway, orderStateMachine: IOrderStateMachine, pricing: IBatchPricingPolicy)
- + GetOrdersAsync(): OrderListDto
- + GetOrderDetailsAsync(orderId: Text): OrderDetailsDto
- + CancelOrderAsync(request: CancelOrderDto): OperationResultDto
- + ReorderAsync(orderId: Text): CartResultDto
- + SubmitReviewAsync(request: OrderReviewDto): OperationResultDto

### Relationships

- MyOrdersService --association--> IBatchPricingPolicy (pricing)
- MyOrdersService --association--> ICurrentCustomer (holds reference)
- MyOrdersService --association--> IMyOrdersRepository (holds reference)
- MyOrdersService --association--> INotificationGateway (holds reference)
- MyOrdersService --association--> IOrderStateMachine (holds reference)
- MyOrdersService --association--> IUnitOfWork (holds reference)
- MyOrdersService --dependency--> AuditLog (uses entity)
- MyOrdersService --dependency--> BatchInventory (uses entity)
- MyOrdersService --dependency--> CancelOrderDto (uses DTO)
- MyOrdersService --dependency--> Cart (uses entity)
- MyOrdersService --dependency--> CartItem (uses entity)
- MyOrdersService --dependency--> CartResultDto (uses DTO)
- MyOrdersService --dependency--> Customer (uses entity)
- MyOrdersService --dependency--> CustomerAddress (uses entity)
- MyOrdersService --dependency--> OperationResultDto (uses DTO)
- MyOrdersService --dependency--> Order (uses entity)
- MyOrdersService --dependency--> OrderDetail (uses entity)
- MyOrdersService --dependency--> OrderDetailsDto (uses DTO)
- MyOrdersService --dependency--> OrderListDto (uses DTO)
- MyOrdersService --dependency--> OrderReview (uses entity)
- MyOrdersService --dependency--> OrderReviewDto (uses DTO)
- MyOrdersService --dependency--> Product (uses entity)
- MyOrdersService --realization--> IMyOrdersService (implements)

## MyOrdersController

Ownership: FreshFood-API.Controllers. Role: controller.

Basis: UC-C07; VOPC and analysis sequence scenario pages

### Attributes

- - service: IMyOrdersService

### Operations

- + MyOrdersController(service: IMyOrdersService)
- + GetOrdersAsync(): OrderListDto
- + GetOrderDetailsAsync(orderId: Text): OrderDetailsDto
- + CancelOrderAsync(request: CancelOrderDto): OperationResultDto
- + ReorderAsync(orderId: Text): CartResultDto
- + SubmitReviewAsync(request: OrderReviewDto): OperationResultDto

### Relationships

- MyOrdersApiClient --remote--> MyOrdersController (HTTPS / JSON)
- MyOrdersApiModel --remote--> MyOrdersController (HTTPS / JSON)
- MyOrdersController --association--> IMyOrdersService (holds reference)
- MyOrdersController --association--> IMyOrdersService (service)
- MyOrdersController --dependency--> CancelOrderDto (uses DTO)
- MyOrdersController --dependency--> CartResultDto (uses DTO)
- MyOrdersController --dependency--> OperationResultDto (uses DTO)
- MyOrdersController --dependency--> OrderDetailsDto (uses DTO)
- MyOrdersController --dependency--> OrderListDto (uses DTO)
- MyOrdersController --dependency--> OrderReviewDto (uses DTO)

## IMyOrdersRepository

Ownership: FreshFood.Reposistory.Repository. Role: interface.

Basis: UC-C07; VOPC and analysis sequence scenario pages

### Attributes


### Operations

- + FindOwnedAsync(customerId: Text): Sequence<Order>
- + LockOwnedAsync(customerId: Text, orderId: Text): Order
- + GetCurrentBatchesAsync(productIds: Sequence<Text>): Sequence<BatchInventory>
- + SaveCartAsync(cart: Cart): Void
- + SaveReviewOnceAsync(review: OrderReview): Boolean
- + GetReturnReceiptAsync(orderId: Text): ReturnReceipt?
- + GetRefundAsync(orderId: Text): Refund?

### Relationships

- IMyOrdersRepository --dependency--> BatchInventory (uses entity)
- IMyOrdersRepository --dependency--> Cart (uses entity)
- IMyOrdersRepository --dependency--> Order (uses entity)
- IMyOrdersRepository --dependency--> OrderReview (uses entity)
- MyOrdersRepository --realization--> IMyOrdersRepository (implements)
- MyOrdersService --association--> IMyOrdersRepository (holds reference)

## MyOrdersRepository

Ownership: FreshFood.Reposistory.Repository.Implements. Role: repository.

Basis: UC-C07; VOPC and analysis sequence scenario pages

### Attributes

- - session: IRepositorySession

### Operations

- + MyOrdersRepository(session: IRepositorySession)
- + FindOwnedAsync(customerId: Text): Sequence<Order>
- + LockOwnedAsync(customerId: Text, orderId: Text): Order
- + GetCurrentBatchesAsync(productIds: Sequence<Text>): Sequence<BatchInventory>
- + SaveCartAsync(cart: Cart): Void
- + SaveReviewOnceAsync(review: OrderReview): Boolean
- + GetReturnReceiptAsync(orderId: Text): ReturnReceipt?
- + GetRefundAsync(orderId: Text): Refund?

### Relationships

- MyOrdersRepository --dependency--> AuditLog (uses entity)
- MyOrdersRepository --dependency--> BatchInventory (uses entity)
- MyOrdersRepository --dependency--> Cart (uses entity)
- MyOrdersRepository --dependency--> CartItem (uses entity)
- MyOrdersRepository --dependency--> Customer (uses entity)
- MyOrdersRepository --dependency--> CustomerAddress (uses entity)
- MyOrdersRepository --dependency--> Order (uses entity)
- MyOrdersRepository --dependency--> OrderDetail (uses entity)
- MyOrdersRepository --dependency--> OrderReview (uses entity)
- MyOrdersRepository --dependency--> Product (uses entity)
- MyOrdersRepository --realization--> IMyOrdersRepository (implements)

## OrderListDto

Ownership: FreshFood-API.DTOs. Role: DTO.

Basis: UC-C07; VOPC and analysis sequence scenario pages

### Attributes

- + Orders: Sequence<OrderSummaryDto>

### Operations


### Relationships

- IMyOrdersService --dependency--> OrderListDto (uses DTO)
- MyOrdersApiClient --dependency--> OrderListDto (uses wire DTO)
- MyOrdersApiModel --dependency--> OrderListDto (uses wire DTO)
- MyOrdersController --dependency--> OrderListDto (uses DTO)
- MyOrdersPage --dependency--> OrderListDto (uses wire DTO)
- MyOrdersService --dependency--> OrderListDto (uses DTO)
- MyOrdersViewModel --dependency--> OrderListDto (uses wire DTO)
- OrderListDto --association--> OrderSummaryDto (contains DTO)

## OrderSummaryDto

Ownership: FreshFood-API.DTOs. Role: DTO.

Basis: UC-C07; VOPC and analysis sequence scenario pages

### Attributes

- + OrderId: Text
- + OrderNumber: Text
- + OrderDate: DateTime
- + Status: OrderStatus
- + Total: VndAmount

### Operations


### Relationships

- OrderDetailsDto --association--> OrderSummaryDto (contains DTO)
- OrderListDto --association--> OrderSummaryDto (contains DTO)

## OrderDetailsDto

Ownership: FreshFood-API.DTOs. Role: DTO.

Basis: UC-C07; VOPC and analysis sequence scenario pages

### Attributes

- + Order: OrderSummaryDto
- + Address: AddressDto
- + PaymentStatus: PaymentStatus
- + Lines: Sequence<OrderLineDto>
- + Return: ReturnSummaryDto?

### Operations


### Relationships

- IMyOrdersService --dependency--> OrderDetailsDto (uses DTO)
- MyOrdersApiClient --dependency--> OrderDetailsDto (uses wire DTO)
- MyOrdersApiModel --dependency--> OrderDetailsDto (uses wire DTO)
- MyOrdersController --dependency--> OrderDetailsDto (uses DTO)
- MyOrdersService --dependency--> OrderDetailsDto (uses DTO)
- MyOrdersViewModel --dependency--> OrderDetailsDto (uses wire DTO)
- OrderDetailsDto --association--> AddressDto (contains DTO)
- OrderDetailsDto --association--> OrderLineDto (contains DTO)
- OrderDetailsDto --association--> OrderSummaryDto (contains DTO)
- OrderDetailsDto --association--> ReturnSummaryDto (contains DTO)
- OrderDetailsDto --dependency--> Order (uses entity)

## OrderLineDto

Ownership: FreshFood-API.DTOs. Role: DTO.

Basis: UC-C07; VOPC and analysis sequence scenario pages

### Attributes

- + ProductName: Text
- + Quantity: Integer
- + UnitPrice: VndAmount
- + LineTotal: VndAmount

### Operations


### Relationships

- OrderDetailsDto --association--> OrderLineDto (contains DTO)

## CancelOrderDto

Ownership: FreshFood-API.DTOs. Role: DTO.

Basis: UC-C07; VOPC and analysis sequence scenario pages

### Attributes

- + OrderId: Text
- + Reason: Text

### Operations


### Relationships

- IMyOrdersService --dependency--> CancelOrderDto (uses DTO)
- MyOrdersApiClient --dependency--> CancelOrderDto (uses wire DTO)
- MyOrdersApiModel --dependency--> CancelOrderDto (uses wire DTO)
- MyOrdersController --dependency--> CancelOrderDto (uses DTO)
- MyOrdersPage --dependency--> CancelOrderDto (uses wire DTO)
- MyOrdersService --dependency--> CancelOrderDto (uses DTO)
- MyOrdersView --dependency--> CancelOrderDto (uses wire DTO)
- MyOrdersViewModel --dependency--> CancelOrderDto (uses wire DTO)

## OrderReviewDto

Ownership: FreshFood-API.DTOs. Role: DTO.

Basis: UC-C07; VOPC and analysis sequence scenario pages

### Attributes

- + OrderId: Text
- + Rating: Integer
- + Comment: Text?

### Operations


### Relationships

- IMyOrdersService --dependency--> OrderReviewDto (uses DTO)
- MyOrdersApiClient --dependency--> OrderReviewDto (uses wire DTO)
- MyOrdersApiModel --dependency--> OrderReviewDto (uses wire DTO)
- MyOrdersController --dependency--> OrderReviewDto (uses DTO)
- MyOrdersPage --dependency--> OrderReviewDto (uses wire DTO)
- MyOrdersService --dependency--> OrderReviewDto (uses DTO)
- MyOrdersView --dependency--> OrderReviewDto (uses wire DTO)
- MyOrdersViewModel --dependency--> OrderReviewDto (uses wire DTO)

## ReturnSummaryDto

Ownership: FreshFood-API.DTOs. Role: DTO.

Basis: UC-C07; VOPC and analysis sequence scenario pages

### Attributes

- + FailureReason: Text?
- + ReceiptStatus: Text?
- + RefundStatus: Text?
- + GoodsRefunded: VndAmount
- + ShippingRefunded: VndAmount
- + InventoryDisposition: Text?

### Operations


### Relationships

- OrderDetailsDto --association--> ReturnSummaryDto (contains DTO)

## MyOrdersPage

Ownership: FreshFood-Customer-Web.Pages. Role: boundary.

Basis: MyOrdersView Web rendering/events; ordinary reference to concrete CallService class; no DI

### Attributes

- - api: MyOrdersApiClient
- - state: OrderListDto?
- - isBusy: Boolean
- - errorCode: Text?

### Operations

- + Render(): View
- + OnGetOrdersAsync(): Void
- + OnGetOrderDetailsAsync(orderId: EntityId): Void
- + OnCancelOrderAsync(request: CancelOrderDto): Void
- + OnReorderAsync(orderId: EntityId): Void
- + OnSubmitReviewAsync(request: OrderReviewDto): Void
- + ShowCancellationConfirmation(orderId: EntityId): Void

### Relationships

- MyOrdersPage --association--> MyOrdersApiClient (api)
- MyOrdersPage --dependency--> CancelOrderDto (uses wire DTO)
- MyOrdersPage --dependency--> OrderListDto (uses wire DTO)
- MyOrdersPage --dependency--> OrderReviewDto (uses wire DTO)

## MyOrdersApiClient

Ownership: FreshFood-Customer-Web.CallService. Role: adapter.

Basis: Authenticated HTTPS/JSON and boundary serialization; ordinary frontend object/module lifecycle, no DI

### Attributes

- - http: HttpTransport

### Operations

- + GetOrdersAsync(): OrderListDto
- + GetOrderDetailsAsync(orderId: EntityId): OrderDetailsDto
- + CancelOrderAsync(request: CancelOrderDto): OperationResultDto
- + ReorderAsync(orderId: EntityId): CartResultDto
- + SubmitReviewAsync(request: OrderReviewDto): OperationResultDto

### Relationships

- MyOrdersApiClient --dependency--> CancelOrderDto (uses wire DTO)
- MyOrdersApiClient --dependency--> CartResultDto (uses wire DTO)
- MyOrdersApiClient --dependency--> OperationResultDto (uses wire DTO)
- MyOrdersApiClient --dependency--> OrderDetailsDto (uses wire DTO)
- MyOrdersApiClient --dependency--> OrderListDto (uses wire DTO)
- MyOrdersApiClient --dependency--> OrderReviewDto (uses wire DTO)
- MyOrdersApiClient --remote--> MyOrdersController (HTTPS / JSON)
- MyOrdersPage --association--> MyOrdersApiClient (api)

## MyOrdersView

Ownership: FreshFood-App.Views. Role: boundary.

Basis: MyOrdersView Mobile rendering/events through ordinary ViewModel association; no DI

### Attributes

- - model: MyOrdersViewModel

### Operations

- + Build(): View
- + OnGetOrders(): Void
- + OnGetOrderDetails(orderId: EntityId): Void
- + OnCancelOrder(request: CancelOrderDto): Void
- + OnReorder(orderId: EntityId): Void
- + OnSubmitReview(request: OrderReviewDto): Void
- + ShowCancellationConfirmation(orderId: EntityId): Void

### Relationships

- MyOrdersView --association--> MyOrdersViewModel (model)
- MyOrdersView --dependency--> CancelOrderDto (uses wire DTO)
- MyOrdersView --dependency--> OrderReviewDto (uses wire DTO)

## MyOrdersViewModel

Ownership: FreshFood-App.ViewModels. Role: viewmodel.

Basis: MVVM state and orchestration; ordinary association to concrete API model; no DI

### Attributes

- - api: MyOrdersApiModel
- - state: OrderListDto?
- - isBusy: Boolean
- - errorCode: Text?

### Operations

- + GetOrdersAsync(): OrderListDto
- + GetOrderDetailsAsync(orderId: EntityId): OrderDetailsDto
- + CancelOrderAsync(request: CancelOrderDto): OperationResultDto
- + ReorderAsync(orderId: EntityId): CartResultDto
- + SubmitReviewAsync(request: OrderReviewDto): OperationResultDto

### Relationships

- MyOrdersView --association--> MyOrdersViewModel (model)
- MyOrdersViewModel --association--> MyOrdersApiModel (api)
- MyOrdersViewModel --dependency--> CancelOrderDto (uses wire DTO)
- MyOrdersViewModel --dependency--> CartResultDto (uses wire DTO)
- MyOrdersViewModel --dependency--> OperationResultDto (uses wire DTO)
- MyOrdersViewModel --dependency--> OrderDetailsDto (uses wire DTO)
- MyOrdersViewModel --dependency--> OrderListDto (uses wire DTO)
- MyOrdersViewModel --dependency--> OrderReviewDto (uses wire DTO)

## MyOrdersApiModel

Ownership: FreshFood-App.Models. Role: adapter.

Basis: Authenticated HTTPS/JSON; ordinary frontend lifecycle; no DI or backend type imports

### Attributes

- - http: HttpTransport

### Operations

- + GetOrdersAsync(): OrderListDto
- + GetOrderDetailsAsync(orderId: EntityId): OrderDetailsDto
- + CancelOrderAsync(request: CancelOrderDto): OperationResultDto
- + ReorderAsync(orderId: EntityId): CartResultDto
- + SubmitReviewAsync(request: OrderReviewDto): OperationResultDto

### Relationships

- MyOrdersApiModel --dependency--> CancelOrderDto (uses wire DTO)
- MyOrdersApiModel --dependency--> CartResultDto (uses wire DTO)
- MyOrdersApiModel --dependency--> OperationResultDto (uses wire DTO)
- MyOrdersApiModel --dependency--> OrderDetailsDto (uses wire DTO)
- MyOrdersApiModel --dependency--> OrderListDto (uses wire DTO)
- MyOrdersApiModel --dependency--> OrderReviewDto (uses wire DTO)
- MyOrdersApiModel --remote--> MyOrdersController (HTTPS / JSON)
- MyOrdersViewModel --association--> MyOrdersApiModel (api)

## StateMachineEvent

Ownership: FreshFood-API.DTOs. Role: DTO.

Basis: Stakeholder selection 2026-11-02: table-driven OrderStateMachine replaces individual transition classes

### Attributes

- + Event: Text
- + AggregateId: Text
- + EventId: Text
- + Reason: Text?

### Operations


### Relationships

- IOrderStateMachine --dependency--> StateMachineEvent (uses)
- IOrderStateMachine --dependency--> StateMachineEvent (uses DTO)
- OrderStateMachine --dependency--> StateMachineEvent (uses)
- OrderStateMachine --dependency--> StateMachineEvent (uses DTO)

## TransitionSnapshot

Ownership: FreshFood-API.DTOs. Role: DTO.

Basis: Built under lock from authoritative records; never client-bound

### Attributes

- + AggregateId: EntityId {readOnly}
- + CustomerId: EntityId {serverResolved}
- + ActorId: EntityId {serverResolved}
- + Order: Order {serverResolved}
- + Batches: Sequence<BatchInventory> {serverResolved}
- + GuardFacts: GuardFactsDto {serverResolved}

### Operations

- ~ TransitionSnapshot(order: Order, facts: GuardFactsDto)

### Relationships

- IOrderStateMachine --dependency--> TransitionSnapshot (uses)
- IOrderStateMachine --dependency--> TransitionSnapshot (uses DTO)
- OrderStateMachine --dependency--> TransitionSnapshot (uses)
- OrderStateMachine --dependency--> TransitionSnapshot (uses DTO)
- TransitionSnapshot --association--> GuardFactsDto (contains DTO)
- TransitionSnapshot --dependency--> BatchInventory (trusted context)
- TransitionSnapshot --dependency--> Order (trusted context)

## GuardFactsDto

Ownership: FreshFood-API.DTOs. Role: DTO.

Basis: Projection of existing authoritative facts

### Attributes

- + FirstOrder: Boolean
- + PhoneConfirmed: Boolean
- + VerifiedPayment: Boolean
- + CompleteReceipt: Boolean
- + ConfirmedCause: Text?
- + CapturedGoods: VndAmount
- + CapturedShipping: VndAmount
- + SettledRefund: VndAmount

### Operations


### Relationships

- TransitionSnapshot --association--> GuardFactsDto (contains DTO)

## StateMachineResult

Ownership: FreshFood-API.DTOs. Role: DTO.

Basis: Stakeholder selection 2026-11-02: table-driven OrderStateMachine replaces individual transition classes

### Attributes

- + Applied: Boolean
- + Duplicate: Boolean
- + TransitionIds: Sequence<Text>
- + State: OrderStateSnapshot
- + Actions: Sequence<Text>

### Operations


### Relationships

- IOrderStateMachine --dependency--> StateMachineResult (uses)
- IOrderStateMachine --dependency--> StateMachineResult (uses DTO)
- OrderStateMachine --dependency--> StateMachineResult (uses)
- OrderStateMachine --dependency--> StateMachineResult (uses DTO)
- StateMachineResult --association--> OrderStateSnapshot (State)

## OrderLifecycleRecords

Ownership: FreshFood.Reposistory.Repository. Role: record.

Basis: Repository-owned entity bundle, not API DTO

### Attributes

- + Order: Order
- + Failure: DeliveryFailure?
- + Receipt: ReturnReceipt?
- + Refund: Refund?
- + Payments: Sequence<OrderPayment>

### Operations


### Relationships


## IOrderLifecycleRepository

Ownership: FreshFood.Reposistory.Repository. Role: interface.

Basis: Existing order/payment/return/refund records

### Attributes


### Operations

- + LockOrderAsync(orderId: Text): Order
- + LoadLifecycleAsync(orderId: Text): OrderLifecycleRecords
- + SaveAsync(order: Order): Void
- + RecordEventOnceAsync(aggregateId: Text, eventId: Text, transitionId: Text): Boolean
- + SaveOrderLinesAsync(order: Order, lines: Sequence<OrderDetail>): Void
- + SavePaymentOnceAsync(payment: OrderPayment): Boolean
- + SaveFailureAsync(failure: DeliveryFailure): Void
- + SaveReceiptAsync(receipt: ReturnReceipt, items: Sequence<ReturnReceiptItem>): Void
- + SaveRefundOnceAsync(refund: Refund): Boolean
- + SaveShippingSettlementAsync(settlement: ShippingFeeSettlement): Void
- + LockReservedBatchesAsync(orderId: Text): Sequence<BatchInventory>
- + SaveBatchesAsync(batches: Sequence<BatchInventory>): Void
- + AppendAuditAsync(audit: AuditLog): Void

### Relationships

- OrderLifecycleRepository --realization--> IOrderLifecycleRepository (implements)
- OrderStateMachine --association--> IOrderLifecycleRepository (holds reference)
- OrderStateMachine --association--> IOrderLifecycleRepository (repository)

## OrderLifecycleRepository

Ownership: FreshFood.Reposistory.Repository.Implements. Role: repository.

Basis: Proposed persistence seam; event-dedup storage choice pending review

### Attributes

- - session: IRepositorySession

### Operations

- + OrderLifecycleRepository(session: IRepositorySession)
- + LockOrderAsync(orderId: Text): Order
- + LoadLifecycleAsync(orderId: Text): OrderLifecycleRecords
- + SaveAsync(order: Order): Void
- + RecordEventOnceAsync(aggregateId: Text, eventId: Text, transitionId: Text): Boolean
- + SaveOrderLinesAsync(order: Order, lines: Sequence<OrderDetail>): Void
- + SavePaymentOnceAsync(payment: OrderPayment): Boolean
- + SaveFailureAsync(failure: DeliveryFailure): Void
- + SaveReceiptAsync(receipt: ReturnReceipt, items: Sequence<ReturnReceiptItem>): Void
- + SaveRefundOnceAsync(refund: Refund): Boolean
- + SaveShippingSettlementAsync(settlement: ShippingFeeSettlement): Void
- + LockReservedBatchesAsync(orderId: Text): Sequence<BatchInventory>
- + SaveBatchesAsync(batches: Sequence<BatchInventory>): Void
- + AppendAuditAsync(audit: AuditLog): Void

### Relationships

- OrderLifecycleRepository --realization--> IOrderLifecycleRepository (implements)

## IPayoutPort

Ownership: FreshFood-API.Services. Role: interface.

Basis: Unresolved outbound provider. Fail closed when not configured.

### Attributes


### Operations

- + RequestAsync(refundId: Text): PayoutOutcomeDto

### Relationships

- IPayoutPort --dependency--> PayoutOutcomeDto (uses DTO)
- UnconfiguredPayoutAdapter --realization--> IPayoutPort (implements)

## PayoutOutcomeDto

Ownership: FreshFood-API.DTOs. Role: DTO.

Basis: Provider result does not imply settlement unless verified

### Attributes

- + Outcome: Text
- + ProviderReference: Text?
- + SettledAmount: Text?

### Operations


### Relationships

- IPayoutPort --dependency--> PayoutOutcomeDto (uses DTO)
- UnconfiguredPayoutAdapter --dependency--> PayoutOutcomeDto (uses DTO)

## PaymentNoticeHandler

Ownership: FreshFood-API.Services.Implements. Role: adapter.

Basis: PaymentBoundary callback to CheckoutService through injected interface; no CheckoutController relation

### Attributes

- - checkout: ICheckoutService

### Operations

- + PaymentNoticeHandler(checkout: ICheckoutService)
- + HandleAsync(notice: PaymentNoticeDto): PaymentResultDto

### Relationships

- PaymentNoticeHandler --association--> ICheckoutService (holds reference)
- PaymentNoticeHandler --dependency--> PaymentNoticeDto (uses DTO)
- PaymentNoticeHandler --dependency--> PaymentResultDto (uses DTO)

## TransactionWork

Ownership: FreshFood.Reposistory.Repository. Role: delegate.

Basis: Proposed async transaction callback; repository-owned type

### Attributes


### Operations

- + InvokeAsync(): Value

### Relationships


## ConfiguredNotificationPublisher

Ownership: FreshFood-API.Services.Implements. Role: adapter.

Basis: Configured notification channel; failures surfaced, no guarantee of delivery

### Attributes


### Operations

- + SendAsync(message: NotificationDto): Void

### Relationships

- ConfiguredNotificationPublisher --dependency--> NotificationDto (uses DTO)
- ConfiguredNotificationPublisher --realization--> INotificationPublisher (implements)

## UnconfiguredPayoutAdapter

Ownership: FreshFood-API.Services.Implements. Role: adapter.

Basis: Blocks outgoing payout while provider/contract remains TBD; never marks settlement succeeded

### Attributes


### Operations

- + RequestAsync(refundId: Text): PayoutOutcomeDto

### Relationships

- UnconfiguredPayoutAdapter --dependency--> PayoutOutcomeDto (uses DTO)
- UnconfiguredPayoutAdapter --realization--> IPayoutPort (implements)

## ApiCompositionRoot

Ownership: FreshFood-API. Role: composition root.

Basis: Application startup owns all concrete choices; scoped business/repository/UoW objects

### Attributes


### Operations

- + ConfigureServices(services: RegistrationMap, configuration: Configuration): Void

### Relationships


## IBatchPricingPolicy

Ownership: FreshFood.Reposistory.Entities. Role: interface.

Basis: BR-BAT-01/04; isolate current active batch price/discount logic

### Attributes


### Operations

- + Quote(batch: BatchInventory, asOf: DateTime): VndAmount

### Relationships

- BatchPricingPolicy --realization--> IBatchPricingPolicy (implements)
- CartService --association--> IBatchPricingPolicy (pricing)
- CatalogService --association--> IBatchPricingPolicy (pricing)
- CheckoutService --association--> IBatchPricingPolicy (pricing)
- IBatchPricingPolicy --dependency--> BatchInventory (uses entity)
- MyOrdersService --association--> IBatchPricingPolicy (pricing)

## BatchPricingPolicy

Ownership: FreshFood.Reposistory.Entities. Role: policy.

Basis: Pure integer-VND pricing responsibility refined from application logic; proposed implementation

### Attributes


### Operations

- + Quote(batch: BatchInventory, asOf: DateTime): VndAmount

### Relationships

- BatchPricingPolicy --dependency--> BatchInventory (uses entity)
- BatchPricingPolicy --realization--> IBatchPricingPolicy (implements)

## IDeliveryFeePolicy

Ownership: FreshFood.Reposistory.Entities. Role: interface.

Basis: BR-DEL-01/02; service radius and tiered fee

### Attributes


### Operations

- + Quote(distanceKm: Decimal): VndAmount

### Relationships

- CheckoutService --association--> IDeliveryFeePolicy (deliveryFeePolicy)
- DeliveryFeePolicy --realization--> IDeliveryFeePolicy (implements)

## DeliveryFeePolicy

Ownership: FreshFood.Reposistory.Entities. Role: policy.

Basis: Use existing 1/3/10 km boundaries and fees; reject invalid distance; no new policy

### Attributes


### Operations

- + Quote(distanceKm: Decimal): VndAmount

### Relationships

- DeliveryFeePolicy --realization--> IDeliveryFeePolicy (implements)

## IDistanceCalculator

Ownership: FreshFood-API.Services. Role: interface.

Basis: Architecture CON-01 DistanceCalculator; external distance boundary refinement

### Attributes


### Operations

- + CalculateAsync(addressId: Text): Decimal

### Relationships

- CheckoutService --association--> IDistanceCalculator (distanceCalculator)
- DistanceCalculator --realization--> IDistanceCalculator (implements)

## DistanceCalculator

Ownership: FreshFood-API.Services.Implements. Role: service.

Basis: Coordinate driving-distance adapter and <=10 km validation; provider fallback remains TBD

### Attributes

- - gateway: IDistanceGateway

### Operations

- + DistanceCalculator(gateway: IDistanceGateway)
- + CalculateAsync(addressId: Text): Decimal

### Relationships

- DistanceCalculator --association--> IDistanceGateway (gateway)
- DistanceCalculator --realization--> IDistanceCalculator (implements)

## IFefoBatchSpecification

Ownership: FreshFood.Reposistory.Repository. Role: interface.

Basis: Architecture CON-02 query specification; BR-BAT-02 / BR-ORD-01

### Attributes


### Operations

- + Criteria(asOf: DateTime): BatchCriteria

### Relationships

- CheckoutRepository --association--> IFefoBatchSpecification (fefo)
- FefoBatchSpecification --realization--> IFefoBatchSpecification (implements)

## FefoBatchSpecification

Ownership: FreshFood.Reposistory.Repository.Implements. Role: specification.

Basis: Translate eligible sellable batches and expiry ASC / deterministic batch tie-break into locked repository query; no in-memory substitute for DB locking

### Attributes


### Operations

- + Criteria(asOf: DateTime): BatchCriteria

### Relationships

- FefoBatchSpecification --realization--> IFefoBatchSpecification (implements)

## BatchCriteria

Ownership: FreshFood.Reposistory.Repository. Role: record.

Basis: Repository-owned closed query criteria; no API DTO dependency or chosen SQL/ORM framework

### Attributes

- + ActiveProductsOnly: Boolean
- + AsOf: DateTime
- + MinimumAvailable: Integer
- + SortKeys: Sequence<Text>
- + LockForUpdate: Boolean

### Operations


### Relationships


## VndAmount

Ownership: FreshFood.Reposistory.Entities. Role: value object.

Basis: CON-04 integer VND; exact 18-digit amounts, no JS binary floating-point money

### Attributes

- - units: Decimal

### Operations

- + FromUnits(units: Integer): VndAmount
- + Add(other: VndAmount): VndAmount
- + ToWire(): Text

### Relationships


## EntityId

Ownership: FreshFood.Reposistory.Entities. Role: datatype.

Basis: Safe SQL BIGINT / JSON identifier representation; not a new database entity

### Attributes

- = opaque VndAmount identifier string

### Operations


### Relationships


## LocalDate

Ownership: FreshFood.Reposistory.Entities. Role: datatype.

Basis: Preserve date-only expiry/manufacture values without choosing an instant/timezone policy

### Attributes

- = ISO calendar date string

### Operations


### Relationships


## VndAmountString

Ownership: FreshFood-API.DTOs. Role: datatype.

Basis: Wire projection of exact VND amounts; map to/from VndAmount explicitly

### Attributes

- = VndAmount integer string

### Operations


### Relationships


## IsoDateTime

Ownership: FreshFood-API.DTOs. Role: datatype.

Basis: Wire representation of existing timestamp evidence

### Attributes

- = ISO timestamp string

### Operations


### Relationships


## AuthenticatedPrincipal

Ownership: FreshFood-API.Services. Role: record.

Basis: Trusted server identity, never populated from customer request fields

### Attributes

- + CustomerId: Text?
- + SessionId: Text?
- + Roles: Sequence<Text>

### Operations


### Relationships


## DatabaseConnection

Ownership: FreshFood.Reposistory.Repository. Role: external protocol.

Basis: Provider-neutral ASP.NET Core 10 / C# database connection; PostgreSQL driver remains unselected

### Attributes


### Operations

- + QueryAsync(sql: Text, parameters: Sequence<Value>): Value

### Relationships


## DatabaseTransaction

Ownership: FreshFood.Reposistory.Repository. Role: external protocol.

Basis: Provider-neutral transaction protocol, not a selected ORM

### Attributes


### Operations

- + CommitAsync(): Void
- + RollbackAsync(): Void

### Relationships


## RegistrationMap

Ownership: FreshFood-API. Role: composition contract.

Basis: Framework-neutral ASP.NET Core 10 / C# bootstrap constructor bindings; no .NET IServiceCollection or chosen DI library

### Attributes


### Operations

- + Bind(token: Text, factory: ServiceFactory): Void
- + BindMany(token: Text, factories: Sequence<ServiceFactory>): Void

### Relationships


## HttpTransport

Ownership: FreshFood-API.Services. Role: external protocol.

Basis: Opaque platform HTTP transport; no provider/framework imposed or backend runtime imported into frontend

### Attributes


### Operations

- + SendAsync(url: Text, payload: Value): Value

### Relationships


## IOrderStateMachine

Ownership: FreshFood-API.Services. Role: interface.

Basis: Stakeholder selection 2026-11-02: table-driven OrderStateMachine replaces individual transition classes

### Attributes


### Operations

- + ProcessEventAsync(snapshot: TransitionSnapshot, event: StateMachineEvent): StateMachineResult
- + CurrentState(): OrderStateSnapshot?

### Relationships

- CheckoutService --association--> IOrderStateMachine (holds reference)
- IOrderStateMachine --dependency--> OrderStateSnapshot (uses)
- IOrderStateMachine --dependency--> StateMachineEvent (uses)
- IOrderStateMachine --dependency--> StateMachineEvent (uses DTO)
- IOrderStateMachine --dependency--> StateMachineResult (uses)
- IOrderStateMachine --dependency--> StateMachineResult (uses DTO)
- IOrderStateMachine --dependency--> TransitionSnapshot (uses)
- IOrderStateMachine --dependency--> TransitionSnapshot (uses DTO)
- MyOrdersService --association--> IOrderStateMachine (holds reference)
- OrderStateMachine --realization--> IOrderStateMachine
- OrderStateMachine --realization--> IOrderStateMachine (implements)

## OrderStateMachine

Ownership: FreshFood-API.Services.Implements. Role: state machine.

Basis: Stakeholder selection 2026-11-02: table-driven OrderStateMachine replaces individual transition classes

### Attributes

- - repository: IOrderLifecycleRepository
- - transitionTable: Sequence<Value> {private transition definitions}
- - snapshot: TransitionSnapshot?

### Operations

- + OrderStateMachine(repository: IOrderLifecycleRepository)
- + ProcessEventAsync(snapshot: TransitionSnapshot, event: StateMachineEvent): StateMachineResult
- + CurrentState(): OrderStateSnapshot?

### Relationships

- OrderStateMachine --association--> IOrderLifecycleRepository (holds reference)
- OrderStateMachine --association--> IOrderLifecycleRepository (repository)
- OrderStateMachine --dependency--> Order (uses)
- OrderStateMachine --dependency--> OrderStateSnapshot (uses)
- OrderStateMachine --dependency--> StateMachineEvent (uses)
- OrderStateMachine --dependency--> StateMachineEvent (uses DTO)
- OrderStateMachine --dependency--> StateMachineResult (uses)
- OrderStateMachine --dependency--> StateMachineResult (uses DTO)
- OrderStateMachine --dependency--> TransitionSnapshot (uses)
- OrderStateMachine --dependency--> TransitionSnapshot (uses DTO)
- OrderStateMachine --realization--> IOrderStateMachine
- OrderStateMachine --realization--> IOrderStateMachine (implements)

## OrderStateSnapshot

Ownership: FreshFood-API.DTOs. Role: DTO.

Basis: Stakeholder selection 2026-11-02: table-driven OrderStateMachine replaces individual transition classes

### Attributes

- + FulfillmentState: OrderStatus?
- + PaymentState: PaymentStatus?
- + RefundState: Text?
- + WorkflowNode: Text?
- + FulfillmentCompleted: Boolean

### Operations


### Relationships

- IOrderStateMachine --dependency--> OrderStateSnapshot (uses)
- OrderStateMachine --dependency--> OrderStateSnapshot (uses)
- StateMachineResult --association--> OrderStateSnapshot (State)
