# Database Design Specification — FreshFood Platform

**Document Version:** 2.0 - Requested order-lifecycle revision for review  
**Phase:** Software Design & Database Architecture (Chapter V)  
**Target RDBMS:** PostgreSQL 16+ / Amazon Aurora PostgreSQL  
**Primary Diagram Artifact:** [`artifacts/diagrams/database/physical-erd.drawio`](file:///d:/1.%20Giang%20Day/GenAI/SE-Lifecycle-Agent/artifacts/diagrams/database/physical-erd.drawio)  
**Rendered Static Image:** [`artifacts/diagrams/images/physical-erd.png`](file:///d:/1.%20Giang%20Day/GenAI/SE-Lifecycle-Agent/artifacts/diagrams/images/physical-erd.png)

---

## 1. Relational Mapping Strategy & Architecture Drivers

The physical database schema maps the existing conceptual domain and the order-lifecycle extensions defined in the Entity Class Diagram into a 3rd Normal Form (3NF) relational database, optimized for high transaction throughput, strict First-Expired, First-Out (FEFO) perishable inventory management, zero over-selling, and tamper-resistant auditability.

### 1.1 Architectural & Business Invariants Enforced in Schema
1. **Monetary Precision (`CON-04`):** All financial figures (`retail_price`, `import_price`, `sub_total`, `shipping_fee`, `total_amount`, `discount_amount`, `line_total`, `financial_loss`) are strictly defined as `DECIMAL(18, 0)` to store integer Vietnam Dong (VND) without floating-point inaccuracies.
2. **First-Expired, First-Out (FEFO) Inventory (`BR-GR-02`, `BR-ORD-02`):** `batch_inventory` tracks `manufacture_date`, `expiry_date`, `current_stock`, and `reserved_stock`. Check constraints enforce:
   - `CHECK (expiry_date >= manufacture_date + INTERVAL '3 days')`
   - `CHECK (reserved_stock <= current_stock AND reserved_stock >= 0)`
   - `CHECK (current_stock >= 0)`
3. **Traceability to Physical Batches:** `order_details` references `batch_id` directly to record exactly which physical batch fulfilled each order line, guaranteeing traceability for food safety, expiry tracking, and customer inquiries.
4. **Single-Table Inheritance for Staff Hierarchy (`BR-SEC-03`):** Staff accounts (`WarehouseStaff`, `SaleStaff`, `StoreOwner`) are mapped via Single Table Inheritance (TPH) into `staff_accounts` with a `role` discriminator. This allows unified FK referencing from `goods_receipts`, `stock_disposal_records`, `orders`, and `audit_logs`, as well as sub-second token revocation via `token_revoked_at`.
5. **Auditing & Compliance:** `audit_logs` records all sensitive staff operations, capturing snapshot state changes via `JSONB` with non-nullable timestamps and origin IP addresses.

---

## 2. Physical Entity-Relationship Diagram (Physical ERD)

The complete physical ERD displays the 16 existing core tables plus 8 new lifecycle tables across focused pages with explicit Primary Keys (PK), Foreign Keys (FK), Unique constraints (UQ), and Crow's Foot cardinality notations.

![Figure 5.2: Physical Entity-Relationship Diagram (Physical ERD) of FreshFood Platform](file:///d:/1.%20Giang%20Day/GenAI/SE-Lifecycle-Agent/artifacts/diagrams/images/physical-erd.png)

---

## 3. Physical Schema Catalog & Data Dictionary

### 3.1 Cluster 1: Catalog & Batch Inventory (Forest Green)

#### Table 5.1: `suppliers`
Master data of certified agricultural suppliers.
| Column Name | Physical Data Type | Constraints | Description |
|---|---|---|---|
| `supplier_id` | `SERIAL / INT` | `PRIMARY KEY` | Unique internal identifier for supplier |
| `supplier_code` | `VARCHAR(30)` | `NOT NULL, UNIQUE` | Human-readable business code (e.g. `SUP-DALAT-01`) |
| `supplier_name` | `VARCHAR(255)` | `NOT NULL` | Registered trading name |
| `phone` | `VARCHAR(20)` | `NOT NULL` | Business hotline / contact number |
| `email` | `VARCHAR(100)` | `NULL` | Business contact email |
| `address` | `VARCHAR(255)` | `NULL` | Office / farm physical location |
| `is_active` | `BOOLEAN` | `NOT NULL, DEFAULT TRUE` | Active partnership status |

#### Table 5.2: `product_categories`
Classification hierarchy for agricultural goods.
| Column Name | Physical Data Type | Constraints | Description |
|---|---|---|---|
| `category_id` | `SERIAL / INT` | `PRIMARY KEY` | Category identifier |
| `category_code` | `VARCHAR(30)` | `NOT NULL, UNIQUE` | Unique code (e.g. `VEG_LEAF`, `FRUIT_CITRUS`) |
| `category_name` | `VARCHAR(100)` | `NOT NULL` | Display name (e.g. "Rau lá hữu cơ") |
| `description` | `TEXT` | `NULL` | Category details and preservation guidelines |
| `is_active` | `BOOLEAN` | `NOT NULL, DEFAULT TRUE` | Category visibility flag |

#### Table 5.3: `products`
General catalog items independent of physical batch receipts.
| Column Name | Physical Data Type | Constraints | Description |
|---|---|---|---|
| `product_id` | `BIGSERIAL / BIGINT` | `PRIMARY KEY` | Catalog product identifier |
| `category_id` | `INT` | `NOT NULL, FK -> product_categories` | Owning category |
| `sku` | `VARCHAR(50)` | `NOT NULL, UNIQUE` | Stock Keeping Unit code |
| `product_name` | `VARCHAR(255)` | `NOT NULL` | Commercial product name |
| `unit_of_measure` | `VARCHAR(30)` | `NOT NULL` | Standard selling unit (`kg`, `pack_500g`, `bunch`) |
| `description` | `TEXT` | `NULL` | Nutritional benefits and sourcing description |
| `image_url` | `VARCHAR(500)` | `NULL` | High-resolution product image CDN URL |
| `is_active` | `BOOLEAN` | `NOT NULL, DEFAULT TRUE` | Commercial listing status |
| `created_at` | `TIMESTAMPTZ` | `NOT NULL, DEFAULT CURRENT_TIMESTAMP` | Initial listing timestamp |

#### Table 5.4: `goods_receipts`
Inward warehouse goods receipts from certified suppliers.
| Column Name | Physical Data Type | Constraints | Description |
|---|---|---|---|
| `receipt_id` | `BIGSERIAL / BIGINT` | `PRIMARY KEY` | Goods receipt identifier |
| `receipt_number` | `VARCHAR(50)` | `NOT NULL, UNIQUE` | Formal docket number (e.g. `GR-20261019-001`) |
| `supplier_id` | `INT` | `NOT NULL, FK -> suppliers` | Sourcing supplier |
| `created_by_staff_id` | `INT` | `NOT NULL, FK -> staff_accounts` | Receiving warehouse staff |
| `receipt_date` | `TIMESTAMPTZ` | `NOT NULL, DEFAULT CURRENT_TIMESTAMP` | Physical docking and inspection timestamp |
| `total_amount` | `DECIMAL(18,0)` | `NOT NULL, CHECK (total_amount >= 0)` | Total docket valuation in VND |
| `notes` | `TEXT` | `NULL` | Inspection observations / delivery temperature |

#### Table 5.5: `batch_inventory`
Physical batch tracking for First-Expired, First-Out (FEFO) perishable management.
| Column Name | Physical Data Type | Constraints | Description |
|---|---|---|---|
| `batch_id` | `BIGSERIAL / BIGINT` | `PRIMARY KEY` | Physical batch identifier |
| `product_id` | `BIGINT` | `NOT NULL, FK -> products` | Reference catalog product |
| `receipt_id` | `BIGINT` | `NOT NULL, FK -> goods_receipts` | Inbound goods receipt reference |
| `batch_number` | `VARCHAR(60)` | `NOT NULL, UNIQUE` | Traceable batch number (e.g. `BATCH-DALAT-261019-A`) |
| `manufacture_date` | `DATE` | `NOT NULL` | Harvest / packaging date |
| `expiry_date` | `DATE` | `NOT NULL, CHECK (expiry_date >= manufacture_date + 3)` | Expiry threshold date |
| `import_quantity` | `INT` | `NOT NULL, CHECK (import_quantity > 0)` | Received physical units |
| `current_stock` | `INT` | `NOT NULL, CHECK (current_stock >= 0)` | Unsold physical inventory balance |
| `reserved_stock` | `INT` | `NOT NULL, CHECK (reserved_stock <= current_stock AND reserved_stock >= 0)` | Locked units in pending checkout |
| `import_price` | `DECIMAL(18,0)` | `NOT NULL, CHECK (import_price >= 0)` | Inbound unit cost (VND) |
| `retail_price` | `DECIMAL(18,0)` | `NOT NULL, CHECK (retail_price >= 0)` | Selling retail price (VND) |
| `discount_rate` | `DECIMAL(5,2)` | `NOT NULL, DEFAULT 0.00, CHECK (discount_rate BETWEEN 0 AND 100)` | Near-expiry discount percentage |
| `sale_status` | `VARCHAR(20)` | `NOT NULL, DEFAULT 'ACTIVE'` | `ACTIVE`, `DISCOUNTED`, `EXPIRED`, `DISPOSED` |

#### Table 5.6: `stock_disposal_records`
Damaged, rotten, or expired produce disposal write-offs.
| Column Name | Physical Data Type | Constraints | Description |
|---|---|---|---|
| `disposal_id` | `BIGSERIAL / BIGINT` | `PRIMARY KEY` | Write-off log identifier |
| `batch_id` | `BIGINT` | `NOT NULL, FK -> batch_inventory` | Condemned inventory batch |
| `inspected_by_staff_id` | `INT` | `NOT NULL, FK -> staff_accounts` | Quality inspector staff |
| `approved_by_owner_id` | `INT` | `NULL, FK -> staff_accounts` | Store owner sign-off (required if loss > 5M VND) |
| `disposal_date` | `TIMESTAMPTZ` | `NOT NULL, DEFAULT CURRENT_TIMESTAMP` | Destruction / write-off timestamp |
| `disposal_quantity` | `INT` | `NOT NULL, CHECK (disposal_quantity > 0)` | Disposed physical unit count |
| `disposal_reason` | `VARCHAR(255)` | `NOT NULL` | Reason (`EXPIRED`, `ROTTEN`, `DAMAGED_IN_TRANSIT`) |
| `financial_loss` | `DECIMAL(18,0)` | `NOT NULL, CHECK (financial_loss >= 0)` | Cost valuation of discarded inventory (VND) |

---

### 3.2 Cluster 2: Customer & Shopping Cart (Teal)

#### Table 5.7: `customers`
Registered shoppers and guest user profiles.
| Column Name | Physical Data Type | Constraints | Description |
|---|---|---|---|
| `customer_id` | `BIGSERIAL / BIGINT` | `PRIMARY KEY` | Customer unique identifier |
| `full_name` | `VARCHAR(150)` | `NOT NULL` | Customer display name |
| `phone` | `VARCHAR(20)` | `NOT NULL, UNIQUE` | Registered mobile number (primary login ID) |
| `email` | `VARCHAR(150)` | `NULL` | Electronic invoice & notification email |
| `auth_provider` | `VARCHAR(20)` | `NOT NULL, DEFAULT 'LOCAL'` | `LOCAL`, `GOOGLE`, `FACEBOOK`, `ZALO` |
| `provider_user_id` | `VARCHAR(255)` | `NULL` | Third-party OAuth subject identifier |
| `is_phone_verified` | `BOOLEAN` | `NOT NULL, DEFAULT FALSE` | SMS OTP verification flag |
| `created_at` | `TIMESTAMPTZ` | `NOT NULL, DEFAULT CURRENT_TIMESTAMP` | Account registration timestamp |

#### Table 5.8: `customer_addresses`
Delivery locations per customer.
| Column Name | Physical Data Type | Constraints | Description |
|---|---|---|---|
| `address_id` | `BIGSERIAL / BIGINT` | `PRIMARY KEY` | Delivery address identifier |
| `customer_id` | `BIGINT` | `NOT NULL, FK -> customers ON DELETE CASCADE` | Owning customer |
| `recipient_name` | `VARCHAR(150)` | `NOT NULL` | Consignee contact name |
| `recipient_phone` | `VARCHAR(20)` | `NOT NULL` | Delivery contact phone |
| `street_address` | `VARCHAR(255)` | `NOT NULL` | Full address (House no, Ward, District, City) |
| `latitude` | `DECIMAL(10,6)` | `NULL` | Geocoded latitude for distance computation |
| `longitude` | `DECIMAL(10,6)` | `NULL` | Geocoded longitude for distance computation |
| `is_default` | `BOOLEAN` | `NOT NULL, DEFAULT FALSE` | Default selection flag |

#### Table 5.9: `carts`
Active shopping basket per customer or anonymous guest.
| Column Name | Physical Data Type | Constraints | Description |
|---|---|---|---|
| `cart_id` | `BIGSERIAL / BIGINT` | `PRIMARY KEY` | Shopping cart identifier |
| `customer_id` | `BIGINT` | `NULL, FK -> customers ON DELETE CASCADE` | Registered owner (NULL for anonymous guest) |
| `session_id` | `VARCHAR(100)` | `NULL, UNIQUE` | Anonymous visitor browser tracking token |
| `created_at` | `TIMESTAMPTZ` | `NOT NULL, DEFAULT CURRENT_TIMESTAMP` | Basket creation timestamp |
| `updated_at` | `TIMESTAMPTZ` | `NOT NULL, DEFAULT CURRENT_TIMESTAMP` | Last cart modification timestamp |

#### Table 5.10: `cart_items`
Line items in active shopping basket.
| Column Name | Physical Data Type | Constraints | Description |
|---|---|---|---|
| `cart_item_id` | `BIGSERIAL / BIGINT` | `PRIMARY KEY` | Basket item identifier |
| `cart_id` | `BIGINT` | `NOT NULL, FK -> carts ON DELETE CASCADE` | Containing cart |
| `product_id` | `BIGINT` | `NOT NULL, FK -> products` | Catalog product |
| `quantity` | `INT` | `NOT NULL, CHECK (quantity > 0)` | Selected item count |
| `added_at` | `TIMESTAMPTZ` | `NOT NULL, DEFAULT CURRENT_TIMESTAMP` | Addition timestamp |

---

### 3.3 Cluster 3: Order, Fulfillment & Reviews (Navy Blue)

#### Table 5.11: `orders`
Customer sales orders, fulfillment lifecycle, and financial settlements.
| Column Name | Physical Data Type | Constraints | Description |
|---|---|---|---|
| `order_id` | `BIGSERIAL / BIGINT` | `PRIMARY KEY` | Order identifier |
| `order_number` | `VARCHAR(50)` | `NOT NULL, UNIQUE` | Invoice code (e.g. `ORD-20261019-8921`) |
| `customer_id` | `BIGINT` | `NOT NULL, FK -> customers` | Purchasing customer |
| `delivery_address_id` | `BIGINT` | `NOT NULL, FK -> customer_addresses` | Snapshot delivery destination |
| `processed_by_staff_id` | `INT` | `NULL, FK -> staff_accounts` | Warehouse packing / dispatch staff |
| `order_date` | `TIMESTAMPTZ` | `NOT NULL, DEFAULT CURRENT_TIMESTAMP` | Order checkout submission timestamp |
| `sub_total` | `DECIMAL(18,0)` | `NOT NULL, CHECK (sub_total >= 0)` | Net items valuation before shipping (VND) |
| `delivery_distance` | `DECIMAL(5,2)` | `NOT NULL, CHECK (delivery_distance >= 0)` | Computed delivery distance in kilometers |
| `shipping_fee` | `DECIMAL(18,0)` | `NOT NULL, CHECK (shipping_fee >= 0)` | Calculated shipping charge (VND) |
| `total_amount` | `DECIMAL(18,0)` | `NOT NULL, CHECK (total_amount >= 0)` | Final payable grand total (VND) |
| `payment_method` | `VARCHAR(20)` | `NOT NULL` | `COD`, `VIETQR` |
| `payment_status` | `VARCHAR(20)` | `NOT NULL, DEFAULT 'UNPAID'` | `UNPAID`, `PAID`, `PARTIALLY_REFUNDED`, `REFUNDED` |
| `order_status` | `VARCHAR(30)` | `NOT NULL, DEFAULT 'PENDING_UNPAID'` | `PENDING_UNPAID`, `PENDING_PAID`, `CONFIRMED`, `PACKING`, `SHIPPING`, `DELIVERED`, `CANCELLED`, `DELIVERY_FAILED`, `RETURNED` |
| `is_first_order` | `BOOLEAN` | `NOT NULL, DEFAULT FALSE` | Snapshot of whether this is the first order; mandatory phone confirmation only while goods payment is unpaid |
| `delivery_agent_id` | `BIGINT` | REFERENCES delivery_agents(delivery_agent_id) | Assigned courier/payee |
| `phone_confirmation_status` | `VARCHAR(24)` | NOT NULL DEFAULT 'NOT_CONTACTED' | NOT_CONTACTED, CONFIRMED or UNCONFIRMED; mandatory only for first unpaid order |
| `phone_contacted_by_staff_id` | `INT` | REFERENCES staff_accounts(staff_id) | Store staff performing phone confirmation |
| `phone_contacted_at` | `TIMESTAMPTZ` | NULL | Actual contact/attempt timestamp |
| `phone_confirmation_note` | `TEXT` | NULL | Result/reason; no invented retry count or timeout |
| `cancellation_reason` | `TEXT` | NULL | Customer/staff cancellation reason |

#### Table 5.12: `order_details`
Line items of sales orders tied to specific physical inventory batches.
| Column Name | Physical Data Type | Constraints | Description |
|---|---|---|---|
| `order_detail_id` | `BIGSERIAL / BIGINT` | `PRIMARY KEY` | Line item identifier |
| `order_id` | `BIGINT` | `NOT NULL, FK -> orders ON DELETE CASCADE` | Parent order reference |
| `batch_id` | `BIGINT` | `NOT NULL, FK -> batch_inventory` | Exact physical batch fulfilling this line item |
| `quantity` | `INT` | `NOT NULL, CHECK (quantity > 0)` | Allocated item count |
| `unit_price` | `DECIMAL(18,0)` | `NOT NULL, CHECK (unit_price >= 0)` | Price at transaction time (VND) |
| `discount_amount` | `DECIMAL(18,0)` | `NOT NULL, DEFAULT 0, CHECK (discount_amount >= 0)` | Near-expiry / promotional discount (VND) |
| `line_total` | `DECIMAL(18,0)` | `NOT NULL, CHECK (line_total >= 0)` | Final line total `(quantity * unit_price) - discount_amount` |

#### Table 5.13: `order_reviews`
Customer rating and feedback for completed orders.
| Column Name | Physical Data Type | Constraints | Description |
|---|---|---|---|
| `review_id` | `BIGSERIAL / BIGINT` | `PRIMARY KEY` | Review identifier |
| `order_id` | `BIGINT` | `NOT NULL, UNIQUE, FK -> orders` | Evaluated order (1:1 constraint) |
| `customer_id` | `BIGINT` | `NOT NULL, FK -> customers` | Submitting customer |
| `rating` | `INT` | `NOT NULL, CHECK (rating BETWEEN 1 AND 5)` | Star score rating (1 to 5) |
| `comment` | `TEXT` | `NULL` | Customer feedback and comments |
| `created_at` | `TIMESTAMPTZ` | `NOT NULL, DEFAULT CURRENT_TIMESTAMP` | Submission timestamp |

---

### 3.4 Cluster 4: Staff Management, Articles & Audit Logs (Indigo)

#### Table 5.14: `staff_accounts`
Internal enterprise staff directory utilizing Single Table Inheritance.
| Column Name | Physical Data Type | Constraints | Description |
|---|---|---|---|
| `staff_id` | `SERIAL / INT` | `PRIMARY KEY` | Staff identifier |
| `username` | `VARCHAR(50)` | `NOT NULL, UNIQUE` | Login username |
| `password_hash` | `VARCHAR(255)` | `NOT NULL` | Argon2id / bcrypt hashed credential |
| `full_name` | `VARCHAR(150)` | `NOT NULL` | Employee full name |
| `phone` | `VARCHAR(20)` | `NOT NULL` | Contact mobile number |
| `email` | `VARCHAR(100)` | `NULL` | Enterprise email |
| `role` | `VARCHAR(30)` | `NOT NULL` | Discriminator: `WAREHOUSE_STAFF`, `SALE_STAFF`, `STORE_OWNER` |
| `is_active` | `BOOLEAN` | `NOT NULL, DEFAULT TRUE` | Active employment status |
| `token_revoked_at` | `TIMESTAMPTZ` | `NULL` | Invalidation cutoff for active JWT tokens (`BR-SEC-03`) |
| `warehouse_zone` | `VARCHAR(50)` | `NULL` | Assigned zone (WarehouseStaff only) |
| `shift_schedule` | `VARCHAR(100)` | `NULL` | Assigned shift (SaleStaff only) |
| `business_license` | `VARCHAR(100)` | `NULL` | Registered tax/business license (StoreOwner only) |
| `created_at` | `TIMESTAMPTZ` | `NOT NULL, DEFAULT CURRENT_TIMESTAMP` | Account onboarding timestamp |

#### Table 5.15: `articles`
Agricultural knowledge and culinary guides published on platform.
| Column Name | Physical Data Type | Constraints | Description |
|---|---|---|---|
| `article_id` | `BIGSERIAL / BIGINT` | `PRIMARY KEY` | Content article identifier |
| `author_staff_id` | `INT` | `NOT NULL, FK -> staff_accounts` | Author staff reference |
| `title` | `VARCHAR(255)` | `NOT NULL` | Editorial title |
| `content` | `TEXT` | `NOT NULL` | Full HTML/Markdown editorial content |
| `thumbnail_url` | `VARCHAR(500)` | `NULL` | Cover image CDN URL |
| `is_hidden` | `BOOLEAN` | `NOT NULL, DEFAULT FALSE` | Publication visibility flag |
| `created_at` | `TIMESTAMPTZ` | `NOT NULL, DEFAULT CURRENT_TIMESTAMP` | Publication timestamp |

#### Table 5.16: `audit_logs`
Tamper-resistant audit trails for enterprise security and traceability.
| Column Name | Physical Data Type | Constraints | Description |
|---|---|---|---|
| `log_id` | `BIGSERIAL / BIGINT` | `PRIMARY KEY` | Audit log entry identifier |
| `staff_id` | `INT` | `NULL, FK -> staff_accounts` | Responsible actor (`NULL` for automated system tasks) |
| `action_type` | `VARCHAR(20)` | `NOT NULL` | `INSERT`, `UPDATE`, `DELETE`, `LOGIN`, `REVOKE` |
| `entity_name` | `VARCHAR(100)` | `NOT NULL` | Target table (e.g. `batch_inventory`, `orders`) |
| `record_identifier` | `VARCHAR(100)` | `NOT NULL` | Business identifier or PK of mutated record |
| `old_values` | `JSONB` | `NULL` | Snapshot of attributes before mutation |
| `new_values` | `JSONB` | `NULL` | Snapshot of attributes after mutation |
| `ip_address` | `VARCHAR(45)` | `NULL` | Client IPv4 / IPv6 address |
| `timestamp` | `TIMESTAMPTZ` | `NOT NULL, DEFAULT CURRENT_TIMESTAMP` | Immutably captured transaction timestamp |

---

### 3.5 Order Payment, Return and Delivery-Fee Records

The new records support the confirmed stakeholder policies; surrogate keys and idempotency references are justified technical integrity choices. They do not assign unresolved cause-decision authority or invent a payout integration.

#### Table 5.17: `delivery_agents`
FR-DEL-01; customer instruction to pay the delivery agent

| Column Name | Physical Data Type | Constraints | Description |
|---|---|---|---|
| `delivery_agent_id` | `BIGINT` | GENERATED BY DEFAULT AS IDENTITY PRIMARY KEY | Technical surrogate identifier |
| `display_name` | `VARCHAR(120)` | NOT NULL | Assigned delivery agent identity |
| `contact_phone` | `VARCHAR(30)` | NULL | Operational contact; nullable until known |

Additional checks: See relationship constraints in the design SQL.

#### Table 5.18: `order_payments`
FR-PAY-03; verified payment and separate shipping-fee collection

| Column Name | Physical Data Type | Constraints | Description |
|---|---|---|---|
| `payment_id` | `BIGINT` | GENERATED BY DEFAULT AS IDENTITY PRIMARY KEY | Technical surrogate identifier |
| `order_id` | `BIGINT` | NOT NULL REFERENCES orders(order_id) | Order whose receipt is allocated |
| `payment_channel` | `VARCHAR(30)` | NOT NULL | VIETQR, COD or SHIPPING_FEE_CASH |
| `provider_transaction_id` | `VARCHAR(120)` | NOT NULL | Verified receipt/cash evidence reference; deduplicated per channel |
| `goods_amount` | `NUMERIC(18,0)` | NOT NULL CHECK (goods_amount >= 0) | Actual collected net goods amount in VND |
| `shipping_amount` | `NUMERIC(18,0)` | NOT NULL CHECK (shipping_amount >= 0) | Actual collected delivery fee in VND |
| `unallocated_amount` | `NUMERIC(18,0)` | NOT NULL DEFAULT 0 CHECK (unallocated_amount>=0) | Verified excess amount not assigned to goods/shipping; refund policy TBD |
| `captured_amount` | `NUMERIC(18,0)` | GENERATED ALWAYS AS (goods_amount + shipping_amount + unallocated_amount) STORED | Derived total captured receipt; must match verified original payment evidence |
| `received_at` | `TIMESTAMPTZ` | NOT NULL | Confirmed collection time |
| `recorded_by_staff_id` | `INT` | REFERENCES staff_accounts(staff_id) | Staff recording cash evidence; gateway receipts may have no staff |
| `collected_by_delivery_agent_id` | `BIGINT` | REFERENCES delivery_agents(delivery_agent_id) | Actual delivery agent collecting cash; not a store staff role |

Additional checks: goods_amount + shipping_amount > 0; payment_channel IN ('VIETQR','COD','SHIPPING_FEE_CASH'); payment_channel <> 'SHIPPING_FEE_CASH' OR (goods_amount=0 AND collected_by_delivery_agent_id IS NOT NULL)

#### Table 5.19: `delivery_failures`
FR-DEL-03/05; fault-based shipping policy

| Column Name | Physical Data Type | Constraints | Description |
|---|---|---|---|
| `failure_id` | `BIGINT` | GENERATED BY DEFAULT AS IDENTITY PRIMARY KEY | Technical surrogate identifier |
| `order_id` | `BIGINT` | NOT NULL UNIQUE REFERENCES orders(order_id) | One current failed-delivery record in the specified full-return scope |
| `failure_cause` | `VARCHAR(40)` | NOT NULL DEFAULT 'UNCLASSIFIED' | UNCLASSIFIED, PRODUCT_FAULT, CUSTOMER_INTENTIONAL_REFUSAL or OTHER |
| `reason` | `TEXT` | NOT NULL CHECK (length(trim(reason))>0) | Observed reason; no automatic inference of deliberate refusal |
| `reported_by_staff_id` | `INT` | NOT NULL REFERENCES staff_accounts(staff_id) | Sales Staff recording the delivery outcome |
| `reported_at` | `TIMESTAMPTZ` | NOT NULL DEFAULT CURRENT_TIMESTAMP | Failure recording time |
| `cause_confirmed_by_staff_id` | `INT` | REFERENCES staff_accounts(staff_id) | Final cause decision identity; authority policy TBD |
| `cause_confirmed_at` | `TIMESTAMPTZ` | NULL | Final cause decision time |
| `cause_evidence` | `TEXT` | NULL | Evidence for review; separate from warehouse quality decision |

Additional checks: failure_cause IN ('UNCLASSIFIED','PRODUCT_FAULT','CUSTOMER_INTENTIONAL_REFUSAL','OTHER'); (cause_confirmed_by_staff_id IS NULL) = (cause_confirmed_at IS NULL); cause_confirmed_at IS NULL OR failure_cause <> 'UNCLASSIFIED'

#### Table 5.20: `return_receipts`
FR-DEL-04; complete physical warehouse receipt before refund

| Column Name | Physical Data Type | Constraints | Description |
|---|---|---|---|
| `return_receipt_id` | `BIGINT` | GENERATED BY DEFAULT AS IDENTITY PRIMARY KEY | Technical surrogate identifier |
| `order_id` | `BIGINT` | NOT NULL UNIQUE REFERENCES orders(order_id) | One full-return receipt obligation per order; partial facts remain draft |
| `receipt_status` | `VARCHAR(16)` | NOT NULL DEFAULT 'DRAFT' | DRAFT or COMPLETE; only complete line matching unlocks the full-return path |
| `created_by_staff_id` | `INT` | NOT NULL REFERENCES staff_accounts(staff_id) | Warehouse receiving staff |
| `created_at` | `TIMESTAMPTZ` | NOT NULL DEFAULT CURRENT_TIMESTAMP | Receipt creation time |
| `confirmed_by_staff_id` | `INT` | REFERENCES staff_accounts(staff_id) | Warehouse Staff confirming all goods physically received |
| `confirmed_at` | `TIMESTAMPTZ` | NULL | Complete receipt confirmation time |

Additional checks: receipt_status IN ('DRAFT','COMPLETE'); receipt_status <> 'COMPLETE' OR (confirmed_by_staff_id IS NOT NULL AND confirmed_at IS NOT NULL)

#### Table 5.21: `return_receipt_items`
FR-DEL-04; match quantities to original batch-bearing order lines

| Column Name | Physical Data Type | Constraints | Description |
|---|---|---|---|
| `return_receipt_item_id` | `BIGINT` | GENERATED BY DEFAULT AS IDENTITY PRIMARY KEY | Technical surrogate identifier |
| `return_receipt_id` | `BIGINT` | NOT NULL | Receipt, with order ownership enforced by composite FK |
| `order_id` | `BIGINT` | NOT NULL | Order ownership key; technical integrity support |
| `order_detail_id` | `BIGINT` | NOT NULL | Original order line and original batch reference |
| `quantity_received` | `INT` | NOT NULL CHECK (quantity_received>0) | Physical quantity actually received; incomplete totals do not mean complete |

Additional checks: See relationship constraints in the design SQL.

#### Table 5.22: `return_inspections`
FR-DEL-07; staff-only quality and disposition decisions

| Column Name | Physical Data Type | Constraints | Description |
|---|---|---|---|
| `inspection_id` | `BIGINT` | GENERATED BY DEFAULT AS IDENTITY PRIMARY KEY | Technical surrogate identifier |
| `return_receipt_item_id` | `BIGINT` | NOT NULL REFERENCES return_receipt_items(return_receipt_item_id) | Physical returned line being assessed |
| `inspected_by_staff_id` | `INT` | NOT NULL REFERENCES staff_accounts(staff_id) | Actual staff assessor; no automated quality classification |
| `inspected_at` | `TIMESTAMPTZ` | NOT NULL | Staff assessment timestamp |
| `quantity` | `INT` | NOT NULL CHECK (quantity>0) | Quantity subject to this handling decision |
| `disposition` | `VARCHAR(16)` | NOT NULL | RESTOCK, HOLD or DISPOSE under existing warehouse authority |
| `condition_notes` | `TEXT` | NOT NULL | Observed condition and staff reasoning |
| `inventory_applied_at` | `TIMESTAMPTZ` | NULL | When authorized inventory movement was committed; not automatic at receipt |

Additional checks: disposition IN ('RESTOCK','HOLD','DISPOSE')

#### Table 5.23: `refunds`
FR-PAY-04/05; automatic refund once receipt/payment and cause policy permit

| Column Name | Physical Data Type | Constraints | Description |
|---|---|---|---|
| `refund_id` | `BIGINT` | GENERATED BY DEFAULT AS IDENTITY PRIMARY KEY | Technical surrogate identifier |
| `order_id` | `BIGINT` | NOT NULL UNIQUE REFERENCES orders(order_id) | One idempotent full failed-delivery return refund obligation in current scope |
| `return_receipt_id` | `BIGINT` | NOT NULL UNIQUE | Complete physical receipt, with matching order FK |
| `goods_amount` | `NUMERIC(18,0)` | NOT NULL CHECK (goods_amount>=0) | Actual collected goods amount refunded |
| `shipping_amount` | `NUMERIC(18,0)` | NOT NULL CHECK (shipping_amount>=0) | Refund paid shipping only for confirmed product fault |
| `refund_status` | `VARCHAR(16)` | NOT NULL DEFAULT 'PENDING' | PENDING, PROCESSING, SUCCEEDED, FAILED or UNKNOWN; technical workflow |
| `idempotency_key` | `VARCHAR(120)` | NOT NULL UNIQUE | Technical guard against duplicate provider payout |
| `requested_at` | `TIMESTAMPTZ` | NOT NULL DEFAULT CURRENT_TIMESTAMP | Automatic refund obligation creation time |
| `settled_at` | `TIMESTAMPTZ` | NULL | Verified outgoing settlement completion time |
| `provider_refund_reference` | `VARCHAR(160)` | UNIQUE | Actual verified payout reference; provider integration TBD |

Additional checks: goods_amount+shipping_amount>0; refund_status IN ('PENDING','PROCESSING','SUCCEEDED','FAILED','UNKNOWN'); refund_status <> 'SUCCEEDED' OR (settled_at IS NOT NULL AND provider_refund_reference IS NOT NULL)

#### Table 5.24: `shipping_fee_settlements`
FR-DEL-06; waived/retained/collected customer fee and agent compensation

| Column Name | Physical Data Type | Constraints | Description |
|---|---|---|---|
| `shipping_settlement_id` | `BIGINT` | GENERATED BY DEFAULT AS IDENTITY PRIMARY KEY | Technical surrogate identifier |
| `order_id` | `BIGINT` | NOT NULL UNIQUE REFERENCES orders(order_id) | Failed-delivery fee obligation |
| `delivery_agent_id` | `BIGINT` | NOT NULL REFERENCES delivery_agents(delivery_agent_id) | Assigned payee; no new staff-account role is assumed |
| `customer_fee_due` | `NUMERIC(18,0)` | CHECK (customer_fee_due>=0) | Zero for product fault; original fee for deliberate refusal; NULL if unresolved |
| `collection_payment_id` | `BIGINT` | REFERENCES order_payments(payment_id) | Actual cash fee receipt if collected directly by agent |
| `compensation_due_amount` | `NUMERIC(18,0)` | CHECK (compensation_due_amount>=0) | Agreed delivery-agent compensation; product-fault payer/rate is unspecified |
| `compensation_paid_amount` | `NUMERIC(18,0)` | NOT NULL DEFAULT 0 CHECK (compensation_paid_amount>=0) | Actual amount paid/retained as compensation, not presumed collected |
| `compensated_at` | `TIMESTAMPTZ` | NULL | Actual compensation completion time |
| `settlement_reference` | `VARCHAR(160)` | NULL | Payout or direct cash-retention evidence |

Additional checks: compensation_due_amount IS NULL OR compensation_paid_amount <= compensation_due_amount; compensation_paid_amount=0 OR (compensated_at IS NOT NULL AND settlement_reference IS NOT NULL)

## 4. Physical Indexing Strategy for High Performance

| Index Name | Target Table | Indexed Columns | Index Type | Purpose / Query Optimization |
|---|---|---|---|---|
| `idx_batch_fefo` | `batch_inventory` | `(product_id, sale_status, expiry_date ASC)` | B-Tree | Accelerates First-Expired, First-Out (FEFO) batch selection during cart reservation |
| `idx_products_cat_active` | `products` | `(category_id, is_active)` | B-Tree | Speeds up catalog browsing and category filtering |
| `idx_orders_cust_date` | `orders` | `(customer_id, order_date DESC)` | B-Tree | Optimizes mobile app order history lookups |
| `idx_orders_status` | `orders` | `(order_status, order_date ASC)` | B-Tree | Warehouse order dispatch and fulfillment queue indexing |
| `idx_cart_session` | `carts` | `(session_id)` | Hash / B-Tree | Sub-millisecond guest cart retrieval by cookie token |
| `idx_audit_entity_time` | `audit_logs` | `(entity_name, timestamp DESC)` | B-Tree | Compliance and forensic timeline auditing |


## 5. Order Transaction and Financial Integrity Protocols

The review-only PostgreSQL design delta is `database/order-lifecycle-extension.sql`. It assumes the modeled base tables and does not constitute an approved production migration. Existing constraints and legacy rows must be inspected first. Do not deploy it automatically.

### 5.1 Stock-backed acceptance and independent initial pending states

OrderStatus stores PENDING_UNPAID or PENDING_PAID as separate initial values. The order_pending_states view projects the stored value and never converts it from PaymentStatus. No PENDING parent or cross-pending-state transition is permitted. PaymentStatus remains available after confirmation, packing and dispatch. Shipping-only cash receipts do not meet the evidence needed for PAID.

Atomic acceptance: group requested quantities; lock eligible batch rows in a deterministic FEFO order with SELECT FOR UPDATE; recompute current_stock minus reserved_stock; validate all requested products before committing any order; update reservations; select PENDING_UNPAID or PENDING_PAID from verified checkout payment, then create the order and immutable original order lines; clear the cart; commit. Roll back all effects if any line is short. A previously rendered product/cart screen is not a reservation. Stock/perishability rules still exclude inactive/expired batches. First-order determination must be serialized with customer order creation so concurrent submissions cannot both bypass or falsely claim the first-order rule; its historical-count scope remains the existing requirement.

Before approving an unpaid first order, require a successful staff phone result and evidence. If contact is unconfirmed, staff may explicitly cancel, recording the reason and releasing original reservations exactly once. No call count or cancellation timeout is invented. Paid first orders and repeat orders are exempt from this mandatory call, not automatically approved.

### 5.2 Cause, receipt, inspection and refunds

1. Record delivery failure and evidence. Final cause confirmation is a separate authorization decision; the responsible role remains TBD. UNCLASSIFIED/OTHER is not automatically deliberate refusal.
2. Record a DRAFT return receipt and original line quantities. Confirm COMPLETE only when every original line is fully accounted for. In one transaction lock the order/receipt, confirm receiving, move fulfillment to RETURNED and evaluate the financial obligation. Partial receiving facts are retained but do not qualify for the full-return automatic path.
3. Product fault: customer delivery-fee liability is zero; refund actual captured goods and shipping allocations. Confirmed deliberate refusal: refund captured goods only, retain the captured delivery fee, or collect the shipping fee directly from the customer if goods were unpaid. Shipping-only collection is a separate ledger allocation.
4. Once goods payment, complete receipt and the applicable confirmed cause are available, `queue_failed_delivery_refund` creates one idempotent refund obligation; it does not perform an external transfer. No warehouse inspection record is required for the customer refund. Re-evaluation belongs to the application event handler for completed receipt/cause confirmation, subject to the unresolved late-payment policy.
5. Staff inspect goods and decide RESTOCK/HOLD/DISPOSE under existing warehouse rules. Lock the receipt item and affected batch when validating cumulative disposition quantities. Receipt alone never exposes goods as available. As stock was reserved, not permanently deducted until successful delivery, a good return generally releases the matching reservation rather than increasing current_stock twice. Unsellable goods require the authorized disposal/adjustment flow; the system does not infer quality automatically.
6. Preserve captured, refunded, retained, due and actually collected amounts. Mark PARTIALLY_REFUNDED only when a confirmed completed refund is less than the original captured amount, and REFUNDED only when the approved full amount has settled. PENDING/PROCESSING/FAILED/UNKNOWN refund requests do not prove completed payout. Lock original payment/refund records and verify cumulative refunds never exceed captured allocations. Direct database writes must not bypass application authorization, settlement verification or this cumulative check.

### 5.3 Shipping-fee compensation

`shipping_fee_settlements` records a liability snapshot and actual compensation, referencing the delivery agent and any direct cash payment evidence. For deliberate refusal the customer owes the original shipping charge; direct agent cash can satisfy that obligation and compensate the agent, but it is not presumed collected until recorded. For prepaid refusal retained fees fund the agent compensation, but retained customer cash is not itself proof the agent was paid. For product fault the customer owes zero. Who funds and how much compensation the agent receives in the product-fault case is TBD, not silently zero or automatically charged to the customer.

### 5.4 Cross-row constraints and normalization

Composite foreign keys ensure return lines belong to the original order; per-order unique obligations and provider/channel references prevent duplicates. Complete-return and phone/payment guards use triggers. Refund amount calculation locks the order. The database does not use a CHECK that queries other rows. Cumulative inspection quantities, authorization, event immutability, cause freezing after financial processing, provider settlement evidence and multi-session transaction orchestration also require the authorized application service and audit trail.

## 6. Migration, Review and Validation

- Review the new physical names and existing row types before deployment. The design uses PostgreSQL 16+; SRS conceptual identifiers/DateTime do not prescribe SQL Server INT/DATETIME2.
- Inventory the actual existing CHECK/FK/index names. Old constraints allowing COMPLETED but not DELIVERED/RETURNED must be replaced in a reviewed migration. Map legacy COMPLETED to DELIVERED only with verified source semantics; do not auto-map ambiguous historical Processing states, payment gateways or unresolved fault reasons.
- Existing records need evidence-based phone/payment/return backfill. Do not fabricate received-at dates, confirmation staff, cash receipts or fault confirmations. Legacy ambiguous rows remain for reconciliation.
- Financial evidence is retained; do not cascade-delete completed payments, returns or refunds. Follow existing security/retention policy, restricted service access and audit logging. Do not add payment credentials to schema files.
- Isolated validation uses local in-memory PGlite (PostgreSQL 17.4-compatible engine). It exercises design SQL and invariants, not a PostgreSQL 16 deployment, outgoing payout, final authorization policy or multi-session stock race. See `artifacts/analysis/order-lifecycle-db-verification.json`.
- The new schema is a reviewable requested revision. Outstanding: final cause-decision authority, outgoing refund provider, partial returns/payments, other/unreachable-customer cases, retries and product-fault courier compensation. These do not block storing facts; they block unsupported automatic financial decisions.

References: [PostgreSQL constraint documentation](https://www.postgresql.org/docs/16/ddl-constraints.html), [PGlite documentation](https://pglite.dev/docs/).

Verified overpayments are retained in unallocated_amount, not silently assigned to goods or lost. Their automatic refund treatment remains TBD; the full-return queue skips such unresolved captures.

Initial-state correction: no Pending parent and no transition between the two initial states. Later-payment handling for an accepted PENDING_UNPAID order remains TBD; retain financial evidence without silently changing its order state.
