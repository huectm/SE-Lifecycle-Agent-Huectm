# Customer Storefront — Detailed Use Case Specifications

**System Name:** FreshFood Organic E-Commerce Platform  
**Document Version:** 2.1 (Requested order-lifecycle revision; affected flows under review)  
**Lifecycle Phase:** 05 — Use Case Specification  
**Governing Standard:** Karl Wiegers & Joy Beatty (*Software Requirements*, 3rd Edition) & Alistair Cockburn Goal-Driven Use Case Methodology  
**Packaging Rule Compliance:** `.agents/Rules/requirements-rules.md` §8.4 & `.agents/skills/usecase-modeling/SKILL.md` (Distinct UCs in separate descriptions; extended UCs in Alternative Flows; included UCs in Normal Flow).

---

## 1. Prioritization & Selection Rationale (Karl Wiegers Quantitative Model)

In accordance with the project's prioritized backlog (`artifacts/requirements/requirements-prioritization.csv`), the five highest-priority Use Cases for the **Customer** role that deliver the maximum business value relative to technical cost and risk are:

| Rank | UC ID | Use Case Name | Primary Actor | Associated Functional Requirements | Karl Wiegers Priority | Business Scope & Value Driver |
|:---:|:---:|---|:---:|---|:---:|---|
| **1** | **UC-C01** | **Browse & Search Products** | Guest, Customer | `FR-BRW-01`, `FR-BRW-02`, `FR-BRW-03` | **High (0.890)** | Public storefront discovery, category filtering, sub-500ms keyword search, organic certification display. |
| **2** | **UC-C05** | **Manage Profile & Addresses** | Customer | `FR-PRF-01`, `FR-PRF-02` | **High (0.774)** | Profile updates, personal address book, automated default address to most recent purchase (`BR-AUTH-03`). |
| **3** | **UC-C03** | **Manage Shopping Cart** | Customer | `FR-CRT-01`, `FR-CRT-02` | **High (0.610)** | Persistent cross-device shopping basket, item quantity adjustment, real-time batch inventory validation. |
| **4** | **UC-C06** | **Checkout & Place Order** | Customer | `FR-PAY-01`, `FR-ORD-01`, `FR-ORD-02`, `FR-ORD-03`, `FR-PAY-02` | **High (0.610)** | Core revenue transaction, 10km radius check, tiered delivery fees, FEFO batch locking, COD and VietQR payment. |
| **5** | **UC-C07** | **Manage My Orders** | Customer | `FR-MYO-01`, `FR-MYO-02`, `FR-MYO-04`, `FR-MYO-03` | **Medium (0.542)** | Real-time order tracking, pending order cancellation with stock release, 1-click re-order, post-delivery reviews. |

---

## 2. Detailed Use Case Specifications

---

### Use Case 1: UC-C01 — Browse & Search Products

**Table 3.10: Detailed Use Case Specification — UC-C01: Browse & Search Products**

| Specification Field | Content Description |
|---|---|
| **Use Case ID & Name** | **UC-C01: Browse & Search Products** |
| **Primary Actor** | Guest, Customer |
| **Secondary Actors** | None (Internal Catalog Search Engine) |
| **Description** | Enables shoppers to discover organic agricultural goods by navigating curated categories (New Arrivals, Best Sellers, Promotions), executing keyword searches, filtering produce, and viewing batch certifications, active selling prices, and harvest origins. |
| **Preconditions** | 1. System is online and storefront web/mobile application is loaded.<br>2. Product catalog and active inventory batches are populated in the database. |
| **Postconditions** | 1. Filtered or searched product catalog is rendered to the user.<br>2. Selected product details (if requested) are displayed with active batch price and organic certification info. |
| **Normal Flow of Events** | 1. Shopper accesses the FreshFood storefront home screen or catalog page.<br>2. System displays product categories and curated sections: *New Arrivals*, *Best Sellers*, and *Promotions* (`FR-BRW-01`).<br>3. Shopper selects a specific category (e.g., "Rau lá hữu cơ") or enters a keyword into the search bar (`UC-C01.1` Search, `UC-C01.2` Browse).<br>4. System queries active catalog items, matches keywords using full-text search within $\le 500\text{ ms}$ (`NFR-PERF-03`, `FR-BRW-02`), and filters only products with active stock or status (`is_active = TRUE`).<br>5. System retrieves the current active batch selling price and applicable clearance discount tags (`FR-BRW-03`, `BR-BAT-04`).<br>6. System renders the responsive product grid displaying product image, title, unit of measure, active price, discount badge (if applicable), and "In Stock" indicator. |
| **Alternative Flows** | **A3.1: Shopper clicks on a product card to view detailed specifications (`<<extend>>` UC-C01.3: View Product Details)**<br>1. From the product listing, shopper clicks on a specific product card.<br>2. System loads the detailed product view, retrieving high-resolution imagery, detailed nutritional description, farm origin, organic certificate, and current batch harvest/expiry date (`FR-BRW-03`).<br>3. System renders the detailed product page and displays the "Add to Cart" control with quantity selector.<br>**A3.2: Shopper applies clearance / discount filter (`<<extend>>` UC-C01.3)**<br>1. Shopper selects the "Near-Expiry Clearance (Giảm giá thanh lý)" filter tag.<br>2. System filters and displays exclusively batches currently carrying automated clearance discount rates (10%–50%) pursuant to `BR-BAT-04`. |
| **Exception Flows** | **E4.1: No products match search criteria**<br>1. System detects zero active products matching the entered keyword or filter criteria.<br>2. System displays a friendly message: *"Không tìm thấy sản phẩm phù hợp. Vui lòng thử từ khóa khác hoặc khám phá các danh mục nổi bật."*<br>3. System presents the 6 most popular organic products as recommended alternatives. |
| **Business Rules** | `BR-CAT-02` (Product Classification), `BR-BAT-01` (Batch Selling Price), `BR-BAT-04` (Near-Expiry Clearance Discounts). |

---

### Use Case 2: UC-C03 — Manage Shopping Cart

**Table 3.11: Detailed Use Case Specification — UC-C03: Manage Shopping Cart**

| Specification Field | Content Description |
|---|---|
| **Use Case ID & Name** | **UC-C03: Manage Shopping Cart** |
| **Primary Actor** | Customer (Guest supported via persistent session) |
| **Secondary Actors** | None |
| **Description** | Allows shoppers to view, inspect, add, update, and remove organic produce items in their shopping basket, with real-time price calculation and physical inventory availability checks. |
| **Preconditions** | 1. Shopper is browsing the storefront on web or mobile application.<br>2. Products being added are active in the store catalog. |
| **Postconditions** | 1. Shopping cart database state updated (`carts` and `cart_items`).<br>2. Basket summary (item count, line totals, sub-total) recalculated and updated in real-time UI. |
| **Normal Flow of Events** | 1. Shopper clicks the shopping cart icon in the navigation bar (`UC-C03.1: View Cart` - `<<include>>`).<br>2. System retrieves all current line items in the shopper's cart from persistent storage (`carts` joined with `cart_items` and `products`).<br>3. System queries `batch_inventory` to evaluate live available stock for each line item (`current_stock - reserved_stock`).<br>4. System computes line totals (`quantity * active_batch_price`) and the aggregated cart sub-total (`FR-CRT-01`).<br>5. System displays the cart page showing thumbnail, product name, unit price, quantity controls, line total, and the "Proceed to Checkout" button. |
| **Alternative Flows** | **A1.1: Shopper adds a product to the cart (`<<extend>>` UC-C03.2: Add Product to Cart)**<br>1. From the catalog or product details page, shopper selects quantity $Q$ and clicks "Add to Cart".<br>2. System validates that available inventory balance $\ge Q$ (`FR-CRT-02`).<br>3. If the product already exists in the cart, system increments line quantity by $Q$; otherwise, system creates a new `cart_items` entry.<br>4. System displays a toast confirmation and updates the header cart badge count.<br>**A4.1: Shopper modifies item quantity (`<<extend>>` UC-C03.3: Update / Remove Cart Item)**<br>1. Shopper clicks "+" or "-" buttons or types a new quantity $Q_{\text{new}}$ on the cart page.<br>2. System verifies available physical inventory $\ge Q_{\text{new}}$.<br>3. System updates line quantity, recalculates line total and cart sub-total, and refreshes screen.<br>**A4.2: Shopper removes an item (`<<extend>>` UC-C03.3)**<br>1. Shopper clicks the "Remove (Xóa)" icon next to a line item.<br>2. System prompts for confirmation: *"Bạn có chắc chắn muốn bỏ sản phẩm này khỏi giỏ hàng?"*<br>3. Shopper confirms; system deletes record from `cart_items` and updates sub-total. |
| **Exception Flows** | **E2.1: Requested quantity exceeds available stock balance**<br>1. At step A1.2 or A4.2, shopper requests a quantity $Q > (\text{current\_stock} - \text{reserved\_stock})$.<br>2. System restricts quantity to the maximum available stock, displays a warning badge: *"Rất tiếc, số lượng sản phẩm trong kho chỉ còn [X] đơn vị"*, and updates cart item to $X$.<br>**E3.1: Cart contains a product that has been delisted or expired**<br>1. At step 3, system detects that an item's active batch has expired or stock has dropped to 0.<br>2. System highlights the line item in red with notice *"Tạm hết hàng"* and disables checkout until the item is removed or updated. |
| **Business Rules** | `BR-BAT-01` (Batch Selling Price), `BR-BAT-02` (FEFO Allocation), `BR-ORD-01` (Zero Over-Selling Validation). |

---

### Use Case 3: UC-C05 — Manage Profile & Addresses

**Table 3.12: Detailed Use Case Specification — UC-C05: Manage Profile & Addresses**

| Specification Field | Content Description |
|---|---|
| **Use Case ID & Name** | **UC-C05: Manage Profile & Addresses** |
| **Primary Actor** | Customer |
| **Secondary Actors** | Google Maps Geocoding API |
| **Description** | Allows registered customers to inspect and update their personal account information (Full Name, Contact Email) and manage a delivery address book (add, edit, delete, set default), ensuring accurate routing and streamlined checkout. |
| **Preconditions** | 1. Customer is logged in to the application (`BR-AUTH-01`). |
| **Postconditions** | 1. Customer profile and/or delivery address records are updated in `customers` and `customer_addresses` tables.<br>2. Default delivery address is updated for subsequent checkouts (`BR-AUTH-03`). |
| **Normal Flow of Events** | 1. Customer navigates to "Account Settings" or "Profile & Address Book" (`UC-C05.1: View Profile` - `<<include>>`).<br>2. System queries customer profile (`customers`) and associated address records (`customer_addresses`).<br>3. System displays customer profile information (Full Name, Phone Number [verified badge], Email) and lists all saved delivery addresses with a clear indicator for the default address (`is_default = TRUE`). |
| **Alternative Flows** | **A2.1: Customer updates personal information (`<<extend>>` UC-C05.2: Update Profile)**<br>1. Customer edits Full Name or Contact Email and clicks "Save Changes".<br>2. System validates email format (if provided) and updates `customers` record.<br>3. System displays confirmation message: *"Thông tin cá nhân đã được cập nhật thành công."*<br>**A3.1: Customer adds a new delivery address (`<<extend>>` UC-C05.3: Manage Delivery Addresses)**<br>1. Customer clicks "Add New Address (Thêm địa chỉ mới)".<br>2. Customer inputs Recipient Name, Recipient Phone Number, Street Address, Ward, and District.<br>3. System invokes Google Maps Geocoding API to validate address syntax and obtain latitude and longitude coordinates.<br>4. Customer optionally checks "Set as default delivery address".<br>5. System inserts new record into `customer_addresses`; if marked default, clears `is_default` on previous addresses.<br>6. System returns to address list showing newly created address.<br>**A3.2: Customer edits an existing delivery address (`<<extend>>` UC-C05.3)**<br>1. Customer clicks "Edit" next to an existing address entry.<br>2. System populates form with current values; customer modifies contact or address fields.<br>3. System re-geocodes address and updates database record.<br>**A3.3: Customer deletes an address (`<<extend>>` UC-C05.3)**<br>1. Customer clicks "Delete" on an address entry that is not currently tied to an active pending order.<br>2. System confirms deletion and removes record from `customer_addresses`. |
| **Exception Flows** | **E3.1: Phone number format invalid**<br>1. In step A3.2, recipient phone number does not conform to 10-digit Vietnamese telecom format.<br>2. System displays validation error: *"Số điện thoại không hợp lệ. Vui lòng nhập số điện thoại gồm 10 chữ số."*<br>**E3.2: Address cannot be geocoded by Google Maps**<br>1. In step A3.3, Google Maps API fails to resolve street address to valid geographic coordinates.<br>2. System prompts customer: *"Không thể xác định tọa độ chính xác cho địa chỉ này. Vui lòng kiểm tra lại số nhà, tên đường, phường/xã."* |
| **Business Rules** | `BR-AUTH-01` (Authentication Prerequisite), `BR-AUTH-03` (Delivery Address Defaulting). |

---

### Use Case 4: UC-C06 — Checkout & Place Order

**Table 3.13: Detailed Use Case Specification — UC-C06: Checkout & Place Order**

| Specification Field | Content Description |
|---|---|
| **Use Case ID & Name** | **UC-C06: Checkout & Place Order** |
| **Primary Actor** | Customer |
| **Secondary Actors** | SePay / Banking Gateway (VietQR), Google Maps Distance Matrix API, SMS/Notification Service |
| **Description** | The primary revenue transaction use case: Customer reviews cart items, confirms delivery address within a strict 10 km store radius, reviews tiered shipping fees, chooses payment method (COD or VietQR), and places order with immediate atomic FEFO batch stock reservation. |
| **Preconditions** | 1. Customer is authenticated (`BR-AUTH-01`).<br>2. Shopping cart contains at least one active produce item.<br>3. Delivery address is located within the store's 10 km operating radius (`BR-DEL-01`). |
| **Postconditions** | 1. Order committed with fulfillment status `Pending Unpaid`, `Pending Paid`; payment is tracked independently as `Unpaid` for COD or `Paid` after verified VietQR confirmation.<br>2. Physical batch inventory is atomically reserved (`reserved_stock` incremented) following strict FEFO order (`BR-BAT-02`, `BR-ORD-01`).<br>3. Shopping cart is cleared.<br>4. Order confirmation notification dispatched to customer and pushed to Sales Staff incoming queue. |
| **Normal Flow of Events** | 1. Customer reviews active items in shopping cart and clicks "Proceed to Checkout".<br>2. System loads the Checkout Screen and defaults shipping address to the customer's most recently completed purchase destination (`UC-C06.1: Select Delivery Address` - `<<include>>`, `BR-AUTH-03`).<br>3. System calls Google Maps Distance Matrix API to calculate actual driving distance $d$ from FreshFood store to the selected delivery address.<br>4. System validates $d \le 10\text{ km}$ (`BR-DEL-01`) and computes the tiered delivery fee: $10,000\text{ VND}$ ($d < 1\text{ km}$), $20,000\text{ VND}$ ($1\text{ to }<3\text{ km}$), or $30,000\text{ VND}$ ($3\text{ to }10\text{ km}$) (`BR-DEL-02`).<br>5. System allocates order line items to specific batches using First-Expired, First-Out (FEFO) priority (`BR-BAT-02`), computing line totals, batch discounts, and the grand total: $\text{Total} = \text{SubTotal} + \text{ShippingFee}$.<br>6. System displays payment options; customer selects Cash on Delivery (COD) as default (`UC-C06.2: Process Payment` - `<<include>>`).<br>7. Customer reviews summary and clicks "Place Order (Xác nhận đặt hàng)".<br>8. System begins an ACID database transaction: executes row-level pessimistic locking (`SELECT ... FOR UPDATE`), atomically reserves required quantities in `batch_inventory` (`BR-ORD-01`), inserts `orders` record (status `Pending`), inserts `order_details` tied to batch IDs, and clears `cart_items`.<br>9. System displays Order Confirmation screen with Order Number, detailed breakdown, and estimated delivery window. |
| **Alternative Flows** | **A2.1: Customer selects a different delivery address (`<<extend>>` UC-C06.1)**<br>1. Customer clicks "Change Address" and selects an alternate saved address from address book or inputs a new one.<br>2. System recalculates distance $d$ via Google Maps API, recalculates shipping fee per `BR-DEL-02`, and returns to Step 4.<br>**A6.1: Customer selects VietQR payment method (`<<extend>>` UC-C06.4: Pay by Banking QR)**<br>1. Customer selects "Chuyển khoản VietQR (Tự động xác nhận)".<br>2. Customer clicks "Confirm Order". System prepares the VietQR payment reference and exact amount. At accepted checkout, select Pending Paid only when payment is verified; otherwise select Pending Unpaid. The pre-acceptance reference/persistence mechanism requires design review.<br>3. System renders the QR code with a 15-minute countdown timer and establishes a WebSocket listener.<br>4. Customer scans QR code using mobile banking app and executes transfer.<br>5. SePay webhook transmits payment notification payload to FreshFood API (`BR-ORD-03`).<br>6. System verifies transaction authenticity, records independent goods PaymentStatus as `Paid`; if verified at accepted checkout, the order enters Pending Paid directly. For an already accepted Pending Unpaid order, later-payment fulfillment handling is TBD and must not imply a transition to Pending Paid, updates checkout screen in real-time ($\le 3.0\text{ s}$), and directs customer to success screen. |
| **Exception Flows** | **E4.1: Delivery address exceeds 10 km service boundary**<br>1. In step 4, system determines driving distance $d > 10\text{ km}$.<br>2. System blocks order placement, marks address in red, and displays: *"Rất tiếc, địa chỉ giao hàng vượt quá bán kính phục vụ 10km của cửa hàng ([d] km). Quý khách vui lòng chọn địa chỉ khác trong phạm vi 10km."* (`BR-DEL-01`).<br>**E8.1: Inventory race condition during final submission**<br>1. In step 8, during transaction execution, the system finds that available batch stock was depleted by a concurrent checkout.<br>2. System rolls back transaction, alerts customer of inventory change, adjusts cart quantities, and prompts customer to re-confirm. |
| **Business Rules** | `BR-AUTH-01`, `BR-AUTH-03`, `BR-DEL-01`, `BR-DEL-02`, `BR-ORD-01`, `BR-ORD-02`, `BR-ORD-03`, `BR-BAT-02`. |

---

### Use Case 5: UC-C07 — Manage My Orders

**Table 3.14: Detailed Use Case Specification — UC-C07: Manage My Orders**

| Specification Field | Content Description |
|---|---|
| **Use Case ID & Name** | **UC-C07: Manage My Orders** |
| **Primary Actor** | Customer |
| **Secondary Actors** | None |
| **Description** | Allows customers to track order fulfillment lifecycle statuses (`Pending Unpaid`, `Pending Paid`, `Confirmed`, `Packing`, `Shipping`, `Delivered`, `Cancelled`, `Delivery Failed`, `Returned`), view complete historical receipts, cancel orders that are not yet dispatched, place instant re-orders, and submit quality reviews for delivered fresh produce. |
| **Preconditions** | 1. Customer is authenticated (`BR-AUTH-01`). |
| **Postconditions** | 1. Order tracking details rendered to customer.<br>2. Cancelled order status updated and batch inventory released (if cancelled).<br>3. Product items added to cart (if re-ordered).<br>4. Review record committed to `order_reviews` (if feedback submitted). |
| **Normal Flow of Events** | 1. Customer navigates to "My Orders (Đơn hàng của tôi)" (`UC-C07.1: View Order List` - `<<include>>`).<br>2. System queries database for orders matching `customer_id`, sorted in descending order of `order_date` (`FR-MYO-01`).<br>3. System renders order history list, displaying Order Number, Order Date, Item Count, Total Amount, and Color-Coded Status Badge (`Pending Unpaid`, `Pending Paid`, `Confirmed`, `Packing`, `Shipping`, `Delivered`, `Cancelled`, `Delivery Failed`, `Returned`).<br>4. Customer clicks on a specific order card to view full details (`UC-C07.2: View Order Details` - `<<include>>`).<br>5. System retrieves and displays delivery address, contact info, itemized produce list, unit prices, batch discounts, delivery fee, payment method/status, and tracking progress timeline. |
| **Alternative Flows** | **A3.1: Customer cancels an undelivered order (`<<extend>>` UC-C07.3: Cancel Undelivered Order)**<br>1. Customer clicks "Cancel Order (Hủy đơn hàng)" on an order currently in `Pending` or `Confirmed` status (`BR-ORD-04`, `BR-ORD-05`).<br>2. System prompts for confirmation and asks for cancellation reason.<br>3. Customer confirms cancellation.<br>4. System begins database transaction: updates order status to `Cancelled`, immediately releases reserved batch stock in `batch_inventory` (`reserved_stock = reserved_stock - quantity`), and logs cancellation in `audit_logs`.<br>5. System sends status update to customer and notifies Sales Staff queue.<br>**A5.1: Customer places a re-order (`<<extend>>` UC-C07.5: Re-order)**<br>1. On a completed (`Delivered`) order, customer clicks "Re-Order (Đặt lại đơn này)".<br>2. System maps items from historical order into customer's active cart (`FR-MYO-04`).<br>3. System verifies product availability against currently active batches and updates prices to prevailing retail rates (`BR-RE-01`).<br>4. System redirects customer directly to shopping cart view.<br>**A5.2: Customer submits order review and rating (`<<extend>>` UC-C07.4: Submit Order Feedback)**<br>1. On a delivered order (`Delivered`), customer clicks "Rate & Review (Đánh giá đơn hàng)" (`BR-FB-01`, `FR-MYO-03`).<br>2. System presents review modal with 1–5 star rating selector and optional text comment box.<br>3. Customer submits review; system validates 1–5 star constraint, inserts record into `order_reviews` (enforcing 1:1 relation with `orders`), and displays thank-you message. |
| **Exception Flows** | **E1.1: Customer attempts to cancel an order already in packing or transit**<br>1. In step A3.1, customer clicks cancel after Sales Staff has already advanced status to `Packing` or `Shipping`.<br>2. System disables automated cancellation and displays: *"Đơn hàng đang trong quá trình đóng gói hoặc đang giao hàng nên không thể tự hủy trên ứng dụng. Quý khách vui lòng liên hệ hotline cửa hàng để được hỗ trợ."* (`BR-ORD-04`).<br>**E2.1: Re-ordered items no longer available in stock**<br>1. In step A5.1, one or more produce items from the historical order are out of season or stock.<br>2. System adds available items to cart, alerts customer: *"Một số sản phẩm trong đơn cũ hiện đã hết hàng hoặc thay đổi giá bán"*, and highlights missing items. |
| **Business Rules** | `BR-AUTH-01`, `BR-ORD-04`, `BR-ORD-05`, `BR-RE-01`, `BR-FB-01`. |

---

## 3. Requirements Traceability Verification

Each of the five specified Customer Use Cases maintains complete, bidirectional traceability to the project's approved Functional Requirements (`FR`), Business Rules (`BR`), and Quality Attributes (`NFR`):

| Use Case ID | Use Case Name | Traced Functional Requirements (FR) | Traced Business Rules (BR) | Non-Functional Requirements (NFR) |
|---|---|---|---|---|
| **UC-C01** | Browse & Search Products | `FR-BRW-01`, `FR-BRW-02`, `FR-BRW-03` | `BR-CAT-02`, `BR-BAT-01`, `BR-BAT-04` | `NFR-PERF-03` ($\le 500\text{ ms}$ search response) |
| **UC-C03** | Manage Shopping Cart | `FR-CRT-01`, `FR-CRT-02` | `BR-BAT-01`, `BR-BAT-02`, `BR-ORD-01` | `NFR-PERF-01` (Sub-second UI response) |
| **UC-C05** | Manage Profile & Addresses | `FR-PRF-01`, `FR-PRF-02` | `BR-AUTH-01`, `BR-AUTH-03` | `NFR-SEC-01` (Data privacy & secure storage) |
| **UC-C06** | Checkout & Place Order | `FR-PAY-01`, `FR-ORD-01`, `FR-ORD-02`, `FR-ORD-03`, `FR-PAY-02` | `BR-AUTH-01`, `BR-AUTH-03`, `BR-DEL-01`, `BR-DEL-02`, `BR-ORD-01`, `BR-ORD-02`, `BR-ORD-03`, `BR-BAT-02` | `NFR-REL-01` (Zero over-selling, ACID transaction), `NFR-PERF-02` ($\le 3.0\text{ s}$ QR webhook) |
| **UC-C07** | Manage My Orders | `FR-MYO-01`, `FR-MYO-02`, `FR-MYO-04`, `FR-MYO-03` | `BR-AUTH-01`, `BR-ORD-04`, `BR-ORD-05`, `BR-RE-01`, `BR-FB-01` | `NFR-PERF-01` (Real-time order history tracking) |

---

## 4. Associated UML Activity Diagrams (Behavioral Flow Modeling)

Pursuant to `AGENTS.md` §2.8 (Mandatory Two-Step Diagram Generation) and §2.9 (Layout Anti-Overlap Invariant), each of the five Customer Use Cases is coupled with an authoritative UML Activity Diagram specifying operational flows, decision gateways, exception handling, and concurrent system actions across cross-functional swimlanes:

| Use Case ID | Use Case Name | Master Editable Diagram (`.drawio`) | Rendered High-Resolution Static Image (`.png`) | Swimlanes & Parties Involved |
|:---:|---|---|---|---|
| **UC-C01** | Browse & Search Products | [`uc-c01-browse-search-activity.drawio`](file:///artifacts/diagrams/activity/uc-c01-browse-search-activity.drawio) | [`uc-c01-browse-search-activity.png`](file:///artifacts/diagrams/images/uc-c01-browse-search-activity.png) | Shopper (Actor) \| Storefront Client (UI) \| Catalog Search Engine \| Product & Batch DB |
| **UC-C03** | Manage Shopping Cart | [`uc-c03-manage-cart-activity.drawio`](file:///artifacts/diagrams/activity/uc-c03-manage-cart-activity.drawio) | [`uc-c03-manage-cart-activity.png`](file:///artifacts/diagrams/images/uc-c03-manage-cart-activity.png) | Shopper (Actor) \| Storefront Client (UI) \| Cart Service & Pricing Engine \| Inventory & Cart DB |
| **UC-C05** | Manage Profile & Addresses | [`uc-c05-manage-profile-address-activity.drawio`](file:///artifacts/diagrams/activity/uc-c05-manage-profile-address-activity.drawio) | [`uc-c05-manage-profile-address-activity.png`](file:///artifacts/diagrams/images/uc-c05-manage-profile-address-activity.png) | Customer (Actor) \| Account Client UI \| Profile & Customer Service \| Google Maps Geocoding API \| Customer DB |
| **UC-C06** | Checkout & Place Order | [`checkout-activity-diagram.drawio`](file:///artifacts/diagrams/activity/checkout-activity-diagram.drawio) | [`checkout-activity-diagram.png`](file:///artifacts/diagrams/images/checkout-activity-diagram.png) | Customer (Actor) \| Storefront UI \| Order & Checkout Service \| Google Maps API \| SePay VietQR Gateway \| PostgreSQL DB |
| **UC-C07** | Manage My Orders | [`uc-c07-manage-my-orders-activity.drawio`](file:///artifacts/diagrams/activity/uc-c07-manage-my-orders-activity.drawio) | [`uc-c07-manage-my-orders-activity.png`](file:///artifacts/diagrams/images/uc-c07-manage-my-orders-activity.png) | Customer (Actor) \| Orders Client UI \| Order Lifecycle Service \| Order & Inventory DB |



## Order Lifecycle Revision Notes - 2026-10-29

UC-C06 accepts only stock-backed orders, reserving all lines atomically. Its initial state is independently Pending Unpaid or Pending Paid according to verified payment at accepted checkout; no transition connects these states. The mandatory first-order call belongs to staff approval (UC-M01.3) and applies only when the first order is still unpaid. Staff may cancel an unconfirmed first unpaid order; no automatic timeout or retry count is specified.

UC-C07 displays independent fulfillment, goods-payment/refund and shipping-fee information. Failed delivery does not mean returned goods received. Complete warehouse receipt enables the full-return path; staff quality inspection/disposition is separate from the customer refund.

For product fault, the customer owes no delivery fee and a paid order receives its captured goods and delivery fee back. For confirmed deliberate refusal unrelated to product fault, refund paid goods only and retain paid shipping for the delivery agent; if goods were unpaid, the customer owes shipping directly to the delivery agent. Record actual collection and compensation; do not mark goods Paid for shipping-only cash. Final cause authority and unclassified/other cases are TBD; no automated blame classification.

Existing UC identifiers are retained. Detailed receiving/refund goal identifiers and VOPC/sequence revisions require review; no new independent goal is silently assigned to an existing micro-action identifier.
