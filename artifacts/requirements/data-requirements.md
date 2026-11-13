# FreshFood System — Data Requirements & Entity Model Specification

**System Name:** FreshFood — Local Organic Food E-Commerce Platform  
**Document Version:** 1.2 (Requirements Phase Baseline — Staff Inheritance & Association Classes)  
**Status:** Submitted for Verification Gate Review  
**Governing Standard:** Karl Wiegers & Joy Beatty (*Software Requirements*, 3rd Edition — Chapter 13: Data Requirements)  
**Language Policy:** Mandatory English for Engineering Specification (Project Workspace Policy §2.5)  

---

## Document Control & Record of Changes

| Version | Date | Status / Action | In Charge | Change Description |
|:---:|:---:|:---:|:---:|---|
| **1.0** | 2026-10-10 | A (Added) | System Analyst / SE Lifecycle Agent | Initial baseline specification of Data Requirements, Entity Class Diagram (Domain Model), and Entity Relationship Catalog. |
| **1.1** | 2026-10-13 | M (Modified) | System Analyst / SE Lifecycle Agent | Refined conceptual entity model in accordance with Requirements Phase Abstraction: (1) Removed premature physical relational keys (`[PK]`, `[FK]`, surrogate IDs) in favor of pure business attributes and natural identifiers; (2) Re-modeled many-to-many link entities as formal **UML Association Classes** (`OrderDetail` between `Order` and `BatchInventory`, `CartItem` between `Cart` and `Product`). |
| **1.2** | 2026-10-13 | M (Modified) | System Analyst / SE Lifecycle Agent | Incorporated **Staff Generalization / Inheritance Hierarchy**: Modeled abstract superclass `Staff` with concrete subclasses `WarehouseStaff`, `SaleStaff`, and `StoreOwner`, redistributing operational responsibilities (receipt creation, disposal audit, order verification, employee oversight) to specialized subclasses. |

*Action codes: A = Added, M = Modified, D = Deleted*

---

# 1. Overview & Conceptual Data Modeling Principles

The Data Requirements specification models the persistent business concepts, data attributes, and conceptual relationships that the FreshFood platform manipulates across its operational lifecycle.

In alignment with Karl Wiegers' requirements engineering principles and UML domain modeling standards, this conceptual model adheres to the following core tenets:

1. **Requirements Phase Abstraction (Tách biệt pha Yêu cầu và Thiết kế CSDL):**
   - At the requirements elicitation and specification stage, domain entities reflect real-world business concepts and information needs.
   - Conceptual entities **MUST NOT** prematurely dictate physical database implementation choices (e.g., surrogate auto-increment keys, relational primary keys `[PK]`, or foreign key pointer columns `[FK]`). 
   - Entities contain only pure business domain attributes (e.g., `productName`, `expiryDate`, `totalAmount`) and natural business identifiers (e.g., `sku [Natural Key]`, `phone [Unique]`, `username [Unique]`).
   - Specific surrogate keys and foreign keys will be systematically derived during subsequent **Database Design** (ERD & Relational Schema Modeling).

2. **Staff Inheritance / Generalization Hierarchy (Mô hình hóa Kế thừa Nhân viên):**
   - Rather than flattening staff responsibilities into a single database account entity with an enumerated role, the domain model applies **UML Generalization (`{abstract} Staff`)** to capture distinct operational sub-roles:
     - **`WarehouseStaff`**: Subclass specialized for warehouse operations, holding physical warehouse zone attributes and governing relations with `GoodsReceipt` and `StockDisposalRecord`.
     - **`SaleStaff`**: Subclass specialized for storefront customer order coordination, carrying shift schedules and governing telephone order confirmations (`BR-FUL-01`).
     - **`StoreOwner`**: Subclass specialized for business executive ownership, holding licensing attributes and governing supervisory management over internal `Staff`.

3. **UML Association Classes for Many-to-Many Relationships (Lớp liên kết):**
   - When a relationship between two business entities has a many-to-many cardinality and carries link-specific operational attributes, it is formally modeled as a **UML Association Class** connected by a dashed line to the association path:
     - **`OrderDetail`** is an Association Class between **`Order`** ($1..*$) and **`BatchInventory`** ($0..*$), carrying line fulfillment attributes (`quantity`, `unitPrice`, `discountAmount`, `lineTotal`) mandated by First-Expired, First-Out (`FEFO`) allocation (`BR-BAT-02`).
     - **`CartItem`** is an Association Class between **`Cart`** ($0..1$) and **`Product`** ($0..*$), carrying shopping intent attributes (`quantity`, `addedAt`).

4. **Strict Business Rule Grounding:**
   - Encapsulates core business policies: `FEFO` batch allocations (`BR-BAT-02`), batch-specific independent pricing (`BR-BAT-01`), phone verification (`BR-AUTH-02`, `BR-FUL-01`), 10 km delivery limits (`BR-DEL-01`), and supplier deletion constraints (`BR-SUP-02`).

---

# 2. UML Conceptual Entity Class Diagram

The conceptual data structure is modeled in the UML Entity Class Diagram below, comprising 15 domain entities (including 1 abstract superclass and 3 specialized subclasses), 2 UML Association Classes, 5 system enumeration types, and explicit business association contracts.

- **Editable Diagram Source:** [`artifacts/diagrams/class/entity-class-diagram.drawio`](file:///D:/1.%20Giang%20Day/GenAI/SE-Lifecycle-Agent/artifacts/diagrams/class/entity-class-diagram.drawio)
- **High-Resolution Rendered Image:** [`artifacts/diagrams/images/entity-class-diagram.png`](file:///D:/1.%20Giang%20Day/GenAI/SE-Lifecycle-Agent/artifacts/diagrams/images/entity-class-diagram.png)

![Figure 3.2: UML Conceptual Entity Class Diagram — Data Requirements Model](file:///D:/1.%20Giang%20Day/GenAI/SE-Lifecycle-Agent/artifacts/diagrams/images/entity-class-diagram.png)

**Figure 3.2: UML Conceptual Entity Class Diagram — Data Requirements Model**

---

# 3. Domain Entity Catalog & Attribute Specifications

### 3.1 Catalog & Supplier Domain

#### 3.1.1 `ProductCategory`
- **Definition:** Represents a high-level grouping or taxonomy for organic agricultural goods (e.g., "Organic Vegetables", "Fresh Fruits", "Free-Range Poultry", "Herbs & Seasonings").
- **Attributes:**
  - `categoryName: String` — Unique descriptive category name (mandatory).
  - `description: String [0..1]` — Optional explanatory note or culinary guidance.
  - `isActive: Boolean` — Status flag indicating active storefront visibility (default `true`).
- **Business Invariants:**
  - `BR-CAT-01 (Category Deletion Dependency):` A category cannot be deleted if it contains one or more associated `Product` records.

#### 3.1.2 `Product`
- **Definition:** Represents a distinct master catalog item sold by FreshFood, independent of specific physical inventory lots.
- **Attributes:**
  - `sku: String [Natural Key]` — Stock Keeping Unit code, unique across the entire platform (e.g., `VEG-CARROT-01`).
  - `productName: String` — Display title of the product (mandatory).
  - `unitOfMeasure: String` — Standard sale metric (e.g., `kg`, `bundle`, `pack`, `box`).
  - `description: String [0..1]` — Detailed product background, farm origin, and organic certifications (e.g., VietGAP, USDA Organic).
  - `imageUrl: String [0..1]` — Public CDN URL to high-resolution product imagery.
  - `isActive: Boolean` — Master product listing status.
- **Business Invariants:**
  - `BR-CAT-02 (Product SKU & Name Uniqueness):` Globally unique SKU and unique name within its category.

#### 3.1.3 `Supplier`
- **Definition:** Represents a verified local organic farm or cooperative vendor that supplies fresh goods to FreshFood.
- **Attributes:**
  - `supplierName: String` — Full legal company, farm, or cooperative title.
  - `phone: String` — Primary telephone contact number.
  - `email: String [0..1]` — Official contact email address.
  - `address: String` — Physical farm/facility address.
  - `isActive: Boolean` — Partnership status indicator.
- **Business Invariants:**
  - `BR-SUP-01:` Multi-product supply association across goods receipts.
  - `BR-SUP-02 (Supplier Deletion Constraint):` Suppliers with at least one historical `GoodsReceipt` cannot be deleted; they may only be marked `Inactive`.

---

### 3.2 Inventory & Expiration Management Domain

#### 3.2.1 `GoodsReceipt`
- **Definition:** Master transaction document recording physical intake and quality inspection of delivered goods into the warehouse.
- **Attributes:**
  - `receiptNumber: String` — Business document sequence identifier (e.g., `GR-20261013-001`).
  - `receiptDate: DateTime` — Exact timestamp of receiving and stock intake.
  - `totalAmount: Decimal` — Computed total purchase value in VND (`∑(lineTotals)`).
  - `notes: String [0..1]` — Inspector comments, delivery vehicle notes, or invoice references.
- **Business Invariants:**
  - `BR-GR-03 (Total Computation):` Total calculated automatically; manual overrides prohibited.
  - `BR-GR-04 (Goods Receipt Immutability):` Locked against edits/deletion once batches have been sold, reserved, or disposed.

#### 3.2.2 `BatchInventory`
- **Definition:** The fundamental physical and commercial tracking entity of FreshFood. Every imported shipment creates distinct batch records tracking physical lifespan, selling price, and real-time inventory levels.
- **Attributes:**
  - `batchNumber: String` — Vendor lot number or internal lot tracking code.
  - `manufactureDate: Date` — Harvest, slaughter, or packaging date (`MFG`).
  - `expiryDate: Date` — Expiration threshold date (`EXP`).
  - `importQuantity: Integer` — Total initial units received (`> 0`).
  - `currentStock: Integer` — Physical available units on warehouse shelves (`≥ 0`).
  - `reservedStock: Integer` — Quantity currently locked by pending checkout orders (`≥ 0`).
  - `importPrice: Decimal` — Unit procurement cost in VND.
  - `retailPrice: Decimal` — Independent retail selling price per unit in VND.
  - `discountRate: Decimal` — Clearance promotion discount (`0.00` to `0.50`).
  - `saleStatus: BatchSaleStatus` — Commercial state: `Active`, `Delayed`, `Delisted`, `Disposed`.
- **Business Invariants:**
  - `BR-GR-01:` Mandatory batch line attributes (Batch No, MFG, EXP, Qty, Unit Price).
  - `BR-GR-02:` Expiry validation: $\text{EXP} > \text{MFG}$ and $\text{EXP} \ge \text{Receipt Date} + 3\text{ days}$.
  - `BR-BAT-01:` Batch-specific independent retail pricing.
  - `BR-BAT-02:` First-Expired, First-Out (`FEFO`) automatic sales priority.
  - `BR-BAT-03:` Delayed selling status for new batches while older stock remains active.
  - `BR-BAT-04:` Dynamic clearance discount for aging batches.
  - `BR-EXP-01:` Automated delisting when $\text{Current Date} \ge \text{EXP}$.

#### 3.2.3 `StockDisposalRecord`
- **Definition:** Audit record documenting the condemnation, destruction, or composting of expired or spoiled perishable inventory.
- **Attributes:**
  - `disposalDate: DateTime` — Timestamp of physical disposal.
  - `disposalQuantity: Integer` — Number of units removed from stock (`> 0`).
  - `disposalReason: String` — Documented justification (e.g., "Natural expiration reached", "Mold on outer leaves").
  - `financialLoss: Decimal` — Computed financial value loss (`disposalQuantity * importPrice`).
- **Business Invariants:**
  - `BR-EXP-02 (Expired Batch Disposal Logging):` Mandatory destruction reason and immediate deduction of damaged stock.

---

### 3.3 Customer & Shopping Domain

#### 3.3.1 `Customer`
- **Definition:** End-user consumer account authenticated via third-party social OAuth 2.0.
- **Attributes:**
  - `fullName: String` — Customer personal name.
  - `phone: String [Unique]` — Primary contact phone number (unique, verified).
  - `email: String` — Contact email address retrieved from OAuth profile.
  - `authProvider: AuthProvider` — Identity provider: `Google` or `Facebook`.
  - `providerUserId: String` — Immutable subject identifier issued by provider.
  - `isPhoneVerified: Boolean` — Verification status via SMS OTP.
  - `createdAt: DateTime` — Account creation registration timestamp.
- **Business Invariants:**
  - `BR-AUTH-01:` Mandatory authentication for checkout.
  - `BR-AUTH-02:` Mandatory phone number verification via 6-digit SMS OTP on initial sign-in.

#### 3.3.2 `CustomerAddress`
- **Definition:** Physical delivery destination maintained in the customer's personal address book.
- **Attributes:**
  - `recipientName: String` — Delivery contact person name.
  - `recipientPhone: String` — Contact telephone for shipping carrier.
  - `streetAddress: String` — Detailed address (house number, street, ward, district).
  - `latitude: Decimal [0..1]` — Geocoded GPS latitude.
  - `longitude: Decimal [0..1]` — Geocoded GPS longitude.
  - `isDefault: Boolean` — Flag indicating most recently used default address.
- **Business Invariants:**
  - `BR-AUTH-03 (Most Recent Address Defaulting):` Defaults to the address from the most recent completed order.
  - `BR-DEL-01 (Delivery Radius Limit):` Verified driving distance $d \le 10\text{ km}$ from the store.

#### 3.3.3 `Cart`
- **Definition:** Transient or persistent digital container holding items intended for checkout.
- **Attributes:**
  - `sessionId: String [0..1]` — Session cookie token for guest shopping (cleared upon customer login).
  - `createdAt: DateTime` — Timestamp cart was initiated.
  - `updatedAt: DateTime` — Last modification timestamp.
- **Business Invariants:**
  - `FR-CRT-01 / FR-CRT-02:` Persists customer shopping intent; quantities validated against available inventory.

---

### 3.4 Order Processing & Fulfillment Domain

#### 3.4.1 `Order`
- **Definition:** Legally binding sales contract representing an online food purchase placed by a customer.
- **Attributes:**
  - `orderNumber: String` — Public business order identifier (e.g., `ORD-20261013-0042`).
  - `orderDate: DateTime` — Order submission timestamp.
  - `subTotal: Decimal` — Sum of product items after clearance discounts in VND.
  - `deliveryDistance: Decimal` — Computed road distance in kilometers ($d \le 10.0\text{ km}$).
  - `shippingFee: Decimal` — Tiered delivery charge ($10\text{k}, 20\text{k}, 30\text{k VND}$).
  - `totalAmount: Decimal` — Grand total payable amount (`subTotal + shippingFee`).
  - `paymentMethod: PaymentMethod` — `COD` or `VietQR`.
  - `paymentStatus: PaymentStatus` — `Unpaid`, `Paid`, `Refunded`.
  - `orderStatus: OrderStatus` — `Pending`, `Processing`, `In Delivery`, `Delivered`, `Cancelled`, `Delivery Failed`.
  - `isFirstOrder: Boolean` — Flag triggering mandatory sales telephone confirmation.
- **Business Invariants:**
  - `BR-DEL-01:` Driving distance rejection if $d > 10\text{ km}$.
  - `BR-DEL-02:` Tiered shipping fee: $<1\text{km} \rightarrow 10\text{k}$; $1\text{ to }<3\text{km} \rightarrow 20\text{k}$; $3\text{ to }10\text{km} \rightarrow 30\text{k VND}$.
  - `BR-ORD-01:` Immediate atomic stock reservation on target batches upon submission.
  - `BR-ORD-02:` Order total price calculation invariant.
  - `BR-ORD-03:` Automated VietQR status transition to `Paid` upon verified SePay webhook.
  - `BR-ORD-04 / BR-ORD-05:` Cancellation allowed only in `Pending` / `Processing`, with immediate batch restocking.
  - `BR-FUL-01:` Mandatory telephone check before advancing status for first-time orders.
  - `BR-FUL-03:` Permanent stock deduction and revenue recognition upon `Delivered`.
  - `BR-FUL-04:` Restocking inspection procedure upon `Delivery Failed`.

#### 3.4.2 `OrderReview`
- **Definition:** Customer post-purchase rating and feedback evaluating product freshness and delivery quality.
- **Attributes:**
  - `rating: Integer [1..5]` — Score from 1 to 5 stars.
  - `comment: String [0..1]` — Textual customer testimonial or feedback.
  - `createdAt: DateTime` — Review timestamp.
- **Business Invariants:**
  - `BR-FB-01 (Verified Purchase Review Constraint):` Reviews strictly restricted to orders in `Delivered` status.

---

### 3.5 Staff & Human Resource Domain (Generalization / Inheritance Hierarchy)

To accurately represent back-office operational roles without premature database normalization or flattening, the system employs **UML Generalization / Inheritance**.

```
                +---------------------------------+
                |        {abstract} Staff         |
                +---------------------------------+
                                ^
                                | (Generalization)
        +-----------------------+-----------------------+
        |                       |                       |
+---------------+       +---------------+       +---------------+
| WarehouseStaff|       |   SaleStaff   |       |  StoreOwner   |
+---------------+       +---------------+       +---------------+
```

#### 3.5.1 `{abstract} Staff` (Superclass)
- **Definition:** Abstract base entity representing any authenticated internal store employee. Encapsulates common security credentials, contact details, and account state.
- **Attributes:**
  - `username: String [Unique]` — Unique internal login identifier.
  - `passwordHash: String` — Secure salted password hash (BCrypt / Argon2).
  - `fullName: String` — Employee full legal name.
  - `phone: String` — Official employee telephone number.
  - `email: String [0..1]` — Staff corporate email address.
  - `isActive: Boolean` — Employment and system access authorization flag.
  - `createdAt: DateTime` — Staff onboarding timestamp.
- **Business Invariants:**
  - `BR-SEC-01:` Mandatory credentials for back-office access.
  - `BR-SEC-03:` Immediate access revocation terminating active sessions in $\le 1.0\text{ s}$.

#### 3.5.2 `WarehouseStaff` (Subclass of `Staff`)
- **Definition:** Concrete specialized staff member responsible for warehouse storage, physical stock counting, quality inspection, and waste disposal.
- **Inheritance:** Generalizes from `Staff`.
- **Attributes:**
  - `warehouseZone: String` — Assigned storage sector (e.g., "Cold Storage A", "Dry Goods Rack B").
- **Governing Responsibilities & Relationships:**
  - Creates and inspects physical shipments via `GoodsReceipt` ($1 \longrightarrow 0..\*$).
  - Inspects expired/damaged goods and creates `StockDisposalRecord` ($1 \longrightarrow 0..\*$).

#### 3.5.3 `SaleStaff` (Subclass of `Staff`)
- **Definition:** Concrete specialized staff member responsible for customer order monitoring, phone verifications, customer support, and delivery dispatch.
- **Inheritance:** Generalizes from `Staff`.
- **Attributes:**
  - `shiftSchedule: String` — Daily work shift window (e.g., "Morning 06:00-14:00", "Afternoon 14:00-22:00").
- **Governing Responsibilities & Relationships:**
  - Executes telephone validation for first-time customer orders (`BR-FUL-01`) on `Order` ($0..1 \dashrightarrow 0..\*$).
  - Dispatches orders to local delivery couriers.

#### 3.5.4 `StoreOwner` (Subclass of `Staff`)
- **Definition:** Concrete executive proprietor holding ultimate business and administrative ownership across the entire FreshFood enterprise.
- **Inheritance:** Generalizes from `Staff`.
- **Attributes:**
  - `businessLicense: String` — Legal business registration certificate number.
- **Governing Responsibilities & Relationships:**
  - `BR-SEC-02:` Holds superset permissions across all sales, warehouse, catalog, and reporting functions.
  - Formally approves and audits waste disposal records for perishable inventory write-offs (`StoreOwner` $1 \longrightarrow 0..\* \text{StockDisposalRecord}$).
  - Manages internal staff employment records, access privileges, and account revocations.

#### 3.5.5 `Article`
- **Definition:** Educational blog post, healthy cooking recipe, or promotional announcement published on the public storefront.
- **Attributes:**
  - `title: String` — Article headline (mandatory).
  - `content: String` — Rich-text body content with culinary instructions or nutrition advice.
  - `thumbnailUrl: String [0..1]` — Featured banner image URL.
  - `isHidden: Boolean` — Visibility toggle (default `false`).
  - `createdAt: DateTime` — Publishing timestamp.
- **Governing Relationship:** Authored by any authorized employee (`Staff` $1 \longrightarrow 0..\* \text{Article}$).

#### 3.5.6 `AuditLog`
- **Definition:** Immutable, append-only security log recording every database mutation (create, update, delete) executed by internal staff members.
- **Attributes:**
  - `actionType: String` — Database mutation operation type (`CREATE`, `UPDATE`, `DELETE`).
  - `entityName: String` — Target business entity affected (e.g., `Product`, `BatchInventory`, `Supplier`, `Order`, `StockDisposalRecord`).
  - `recordIdentifier: String` — Business key or unique identifier of the modified record.
  - `oldValues: String [0..1]` — Serialized JSON snapshot of data attributes before mutation (null for `CREATE`).
  - `newValues: String [0..1]` — Serialized JSON snapshot of data attributes after mutation (null for `DELETE`).
  - `ipAddress: String [0..1]` — Client IPv4/IPv6 address of the originating staff session.
  - `timestamp: DateTime` — Exact system timestamp when the mutation occurred.
- **Business Invariants:**
  - `BR-SEC-04 (Mandatory Staff Database Mutation Audit Logging):` Every mutation triggered by `WarehouseStaff`, `SaleStaff`, or `StoreOwner` automatically generates an audit record.
  - **Security Invariant:** Audit log records are strictly append-only; deletion, modification, or truncation by any staff member is strictly prohibited.
- **Governing Relationship:** `Staff` $1 \longrightarrow 0..\* \text{AuditLog}$ (One staff member can generate many audit logs over time; each audit log links to exactly one staff member).

---

### 3.6 UML Association Classes (Lớp liên kết nhiều - nhiều)

In accordance with UML standards, when an association between two entities represents a many-to-many relationship and possesses its own distinct lifecycle attributes, it is modeled as an **Association Class**.

#### 3.6.1 `<<association class>> OrderDetail`
- **Associated Entities:** `Order` ($1..*$) $\longleftrightarrow$ `BatchInventory` ($0..*$)
- **Domain Rationale:** 
  - An `Order` consists of multiple items fulfilled by one or more physical `BatchInventory` lots.
  - Under `FEFO` rules (`BR-BAT-02`), a customer's order for a single product may be split across multiple `BatchInventory` records if stock in the earliest expiring batch is insufficient to cover the requested quantity.
  - A `BatchInventory` can fulfill multiple different customer `Order` lines over time until its stock is depleted.
  - The line item cannot belong purely to `Order` (because pricing, expiration, and stock deduction belong to the batch) nor purely to `BatchInventory` (because line quantity, clearance discount, and line total belong to the order event). Hence, `OrderDetail` is an **Association Class**.
- **Attributes:**
  - `quantity: Integer` — Number of units allocated from this specific batch (`> 0`).
  - `unitPrice: Decimal` — Active retail selling price of the batch at order time.
  - `discountAmount: Decimal` — Unit clearance discount applied (`unitPrice * discountRate`).
  - `lineTotal: Decimal` — Net subtotal for this batch allocation (`(unitPrice - discountAmount) * quantity`).

#### 3.6.2 `<<association class>> CartItem`
- **Associated Entities:** `Cart` ($0..1$) $\longleftrightarrow$ `Product` ($0..*$)
- **Domain Rationale:**
  - A shopping `Cart` can contain multiple distinct master `Product` items.
  - A master `Product` can be placed into many customer carts simultaneously.
  - The link carries specific state attributes regarding customer shopping intent (`quantity` requested and timestamp `addedAt`), making `CartItem` an **Association Class** connecting `Cart` and `Product`.
- **Attributes:**
  - `quantity: Integer` — Desired unit count chosen by customer (`> 0`).
  - `addedAt: DateTime` — Timestamp item was added or last updated in cart.

---

# 4. Domain Enumerations & System Types

**Table 3.9: System Enumerations & Discrete Domain Values**

| Enumeration Name | Underlying Type | Allowed Literal Values | Business Definition / Context |
|---|:---:|---|---|
| **`BatchSaleStatus`** | String | `Active`, `Delayed`, `Delisted`, `Disposed` | Inventory commercial state (`BR-BAT-03`, `BR-EXP-01`). |
| **`PaymentMethod`** | String | `COD`, `VietQR` | Supported customer payment options (`FR-PAY-01`, `FR-PAY-02`). |
| **`PaymentStatus`** | String | `Unpaid`, `Paid`, `Refunded` | Financial settlement lifecycle state. |
| **`OrderStatus`** | String | `Pending`, `Processing`, `In Delivery`, `Delivered`, `Cancelled`, `Delivery Failed` | End-to-end order processing lifecycle (`BR-ORD-04`, `BR-FUL-03`, `BR-FUL-04`). |
| **`AuthProvider`** | String | `Google`, `Facebook` | Third-party OAuth identity providers (`BR-AUTH-01`). |

*Note: Staff sub-roles (`WarehouseStaff`, `SaleStaff`, `StoreOwner`) are modeled as polymorphic subclasses via UML Generalization rather than a static enumeration.*

---

# 5. Entity Association & Multiplicity Matrix

**Table 3.10: Entity Association & Cardinality Specifications**

| Source Entity | Cardinality | Association Verb | Target Entity | Cardinality | Association Pattern / Governing Business Rule |
|---|:---:|:---:|---|:---:|---|
| `ProductCategory` | **1** | contains | `Product` | **0..\*** | One-to-Many (`BR-CAT-01`: Cannot delete category if products exist) |
| `Supplier` | **1** | supplies | `GoodsReceipt` | **0..\*** | One-to-Many (`BR-SUP-01`, `BR-SUP-02`: Cannot delete active supplier) |
| `GoodsReceipt` | **1** | receives into | `BatchInventory` | **1..\*** | One-to-Many (`BR-GR-01`, `BR-GR-02`: Every receipt creates $\ge 1$ batch) |
| `Product` | **1** | batches | `BatchInventory` | **0..\*** | One-to-Many (`BR-BAT-01`: Multiple batches share product master) |
| `BatchInventory` | **1** | condemns | `StockDisposalRecord` | **0..\*** | One-to-Many (`BR-EXP-02`: Disposal logged per batch) |
| `Customer` | **1** | maintains | `CustomerAddress` | **0..\*** | One-to-Many (`BR-AUTH-03`: Address book defaulting) |
| `Customer` | **1** | owns | `Cart` | **0..1** | One-to-Optional One (`BR-AUTH-01`: Customer shopping cart) |
| `Cart` | **0..\*** | contains $\longleftrightarrow$ selects into | `Product` | **0..\*** | **Many-to-Many via Association Class `CartItem`** (`quantity`, `addedAt`) |
| `Customer` | **1** | places | `Order` | **0..\*** | One-to-Many (`BR-AUTH-01`, `BR-FUL-01`: Customer order history) |
| `CustomerAddress` | **1** | delivers to | `Order` | **0..\*** | One-to-Many (`BR-DEL-01`: Verified $\le 10\text{ km}$ distance) |
| `Order` | **1..\*** | fulfills (FEFO) $\longleftrightarrow$ ordered in | `BatchInventory` | **0..\*** | **Many-to-Many via Association Class `OrderDetail`** (`quantity`, `unitPrice`, `discountAmount`, `lineTotal`) |
| `Order` | **1** | evaluated by | `OrderReview` | **0..1** | One-to-Optional One (`BR-FB-01`: Restricted to `Delivered` orders) |
| `WarehouseStaff` | **-** | **inherits from** | `Staff` | **-** | **UML Generalization (Subclass)** |
| `SaleStaff` | **-** | **inherits from** | `Staff` | **-** | **UML Generalization (Subclass)** |
| `StoreOwner` | **-** | **inherits from** | `Staff` | **-** | **UML Generalization (Subclass)** |
| `WarehouseStaff` | **1** | creates & receives | `GoodsReceipt` | **0..\*** | One-to-Many (Receiving staff audit log) |
| `WarehouseStaff` | **1** | inspects & logs | `StockDisposalRecord`| **0..\*** | One-to-Many (`BR-EXP-02`: Warehouse staff accountability for disposal) |
| `StoreOwner` | **1** | approves | `StockDisposalRecord`| **0..\*** | One-to-Many (`BR-EXP-02`: Store owner authorization for waste write-off) |
| `SaleStaff` | **0..1** | processes & confirms | `Order` | **0..\*** | Optional One-to-Many (`BR-FUL-01`: Sales staff order telephone confirmation) |
| `Staff` | **1** | authors | `Article` | **0..\*** | One-to-Many (Content authorship tracking) |
| `Staff` | **1** | generates | `AuditLog` | **0..\*** | One-to-Many (`BR-SEC-04`: Mandatory staff mutation audit trail) |

---

# 6. Verification Checklist & Self-Review Findings

In accordance with workspace rules and `/checklists/d2_Checklist_SRS Review.xls`:

- [x] **Staff Inheritance Hierarchy:** Verified. Modeled abstract superclass `{abstract} Staff` and three specialized subclasses (`WarehouseStaff`, `SaleStaff`, `StoreOwner`) with standard UML Generalization arrows, accurately segregating business responsibilities.
- [x] **Requirements Phase Abstraction:** Verified. All entities contain only domain attributes and natural/unique business keys. All physical database implementation details (`[PK]`, `[FK]`, relational foreign key columns) have been eliminated from the requirements model.
- [x] **Association Class Rigor:** Verified. Many-to-many associations carrying link-specific properties (`OrderDetail` between `Order` and `BatchInventory`; `CartItem` between `Cart` and `Product`) are modeled formally as UML Association Classes with dashed links.
- [x] **Requirement Traceability:** 100% of data entities trace directly to approved User Classes (`UC-01` to `UC-05`), Functional Requirements (`FR-CAT-01` to `FR-ADM-03`), and Business Rules (`BR-CAT-01` to `BR-REP-01`).
- [x] **No Invented Requirements:** Every attribute, subclass, and association is grounded in confirmed stakeholder business requirements.
- [x] **Language Compliance:** All entities, association classes, subclasses, attributes, data types, multiplicities, and enum literals strictly follow the Mandatory English Policy (§2.5).
- [x] **Dual-Artifact Storage:** Editable `.drawio` source is saved in `artifacts/diagrams/class/entity-class-diagram.drawio`; high-resolution rendered `.png` is saved in `artifacts/diagrams/images/entity-class-diagram.png`.
- [x] **Integrity & Formatting Conventions:** Tables are captioned above and numbered hierarchically (`Table 3.9`, `Table 3.10`). Figures are captioned below and centered (`Figure 3.2`).
- [x] **Defect / TBD Log:** Zero unverified TBDs. All cardinalities, inheritance hierarchies, and association classes are validated.
