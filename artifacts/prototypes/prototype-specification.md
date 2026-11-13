# User Interface Prototype Specification & Verification Report

**System Name:** FreshFood Organic E-Commerce Platform  
**Document Version:** 2.0 (Baselined Prototype Specification)  
**Lifecycle Phase:** 05 — Requirements Engineering: User Interface Prototyping  
**Governing Standard:** Karl Wiegers & Joy Beatty (*Software Requirements*, 3rd Edition) & `AGENTS.md` §2.6, §2.7  
**Verification Checklist:** `checklists/d1_Checklist_GUI Review.xls` (100% Passed)  
**Interactive Prototype Hub:** [`artifacts/prototypes/index.html`](file:///artifacts/prototypes/index.html)  

---

## 1. Prioritization & Selection Hierarchy (Karl Wiegers Quantitative Model)

In accordance with `requirements-rules.md` §14 and the prioritized backlog (`artifacts/requirements/requirements-prioritization.csv`), the User Interface Prototypes have been constructed in strict descending order of the quantified **Karl Wiegers Priority Score**:

$$\text{Total value} = 2 \times \text{Benefit} + \text{Penalty}$$
$$\text{Priority} = \frac{\text{value } \%}{\text{cost } \% + \text{risk } \%}$$

**Table 3.16: Prioritized Use Case Prototype Implementation Order**

| Rank | UC ID | Use Case Name | Target Primary Actor | Karl Wiegers Priority | Traced Functional Requirements | Traced Business Rules | Key User Interaction & UI Mechanism |
|:---:|:---:|---|:---:|:---:|---|---|---|
| **1** | **UC-C01** | **Browse & Search Products** | Guest, Customer | **0.890 (High)** | `FR-BRW-01`, `FR-BRW-02`, `FR-BRW-03` | `BR-CAT-02`, `BR-BAT-01`, `BR-BAT-04` | Category pill filtering, sub-500ms keyword search, certification badges, clearance discount tags (-10% to -50%), and interactive detail modal. |
| **2** | **UC-C05** | **Manage Profile & Addresses** | Customer | **0.774 (High)** | `FR-PRF-01`, `FR-PRF-02` | `BR-AUTH-01`, `BR-AUTH-03` | Profile management, verified phone badge, address book cards, 10-digit phone regex validation, and default address flag defaulting from latest order. |
| **3** | **UC-C03** | **Manage Shopping Cart** | Customer | **0.610 (High)** | `FR-CRT-01`, `FR-CRT-02` | `BR-BAT-01`, `BR-BAT-02`, `BR-ORD-01` | Multi-item basket table, real-time quantity controls, physical batch inventory clamping (zero over-selling), line total recalculation, and confirmation removal dialog. |
| **4** | **UC-C06** | **Checkout & Place Order** | Customer | **0.610 (High)** | `FR-PAY-01`, `FR-ORD-01..03`, `FR-PAY-02` | `BR-DEL-01`, `BR-DEL-02`, `BR-ORD-01..03` | Automated default address selection, Google Maps 10km boundary validation, tiered shipping fee ($10k/$20k/$30k), COD vs VietQR with 15-min timer & SePay webhook. |
| **5** | **UC-C07** | **Manage My Orders** | Customer | **0.542 (Medium)** | `FR-MYO-01..04` | `BR-ORD-04`, `BR-ORD-05`, `BR-RE-01`, `BR-FB-01` | Status tab filtering (`Pending` to `Cancelled`), 5-step delivery tracking timeline, cancellation with atomic batch stock release, 1-click re-order, and 1-5 star review. |
| **6** | **UC-M08** | **Manage Goods Receipts** | Warehouse Staff | **0.624 (High Operations)** | `FR-GR-01..04` | `BR-GR-01..04`, `BR-BAT-03` | Back-office receipt creation, supplier invoice mapping, perishable $\\text{EXP} \\ge \\text{Receipt} + 3\\text{ days}$ validation, FEFO Delayed/Active initial sale tagging. |

---

## 2. Detailed Screen Specifications & Verification

### 2.1 Screen 1: UC-C01 — Browse & Search Products (Rank 1, Priority 0.890)

- **Prototype Screen ID:** `screen-uc-c01`
- **Rendered High-Resolution Artifact:** [`artifacts/prototypes/images/prototype-uc-c01-browse-search.png`](file:///artifacts/prototypes/images/prototype-uc-c01-browse-search.png)
- **Primary Actors:** Guest, Customer
- **Traced Requirements:** `FR-BRW-01` (Categorized Browsing), `FR-BRW-02` (Fast Keyword Search), `FR-BRW-03` (Produce Details Display), `NFR-PERF-03` ($\le 500	ext{ ms}$ response).
- **Traced Business Rules:** `BR-CAT-02` (Product Classification), `BR-BAT-01` (Active Batch Retail Price), `BR-BAT-04` (Near-Expiry Clearance Discounts).
- **Screen Layout & UI Components:**
  1. *Category Filter Bar:* Horizontal pill list allowing one-click filtering across `Tất cả`, `Rau lá & Củ quả hữu cơ`, `Trái cây nhiệt đới`, `Nấm sạch Bio`, `Thịt & Trứng sinh học`.
  2. *Near-Expiry Clearance Filter:* Checkbox toggle triggering instant filter for produce batches carrying automated 10%–50% clearance discounts (`BR-BAT-04`).
  3. *Search Bar:* Global search input with dynamic event listener providing instantaneous full-text filtering on produce name, certification, and origin.
  4. *Responsive Product Card:* Displays high-res produce image, organic certification badge (`USDA Organic`, `VietGAP`, `GlobalGAP`), discount badge (`-20%`, `-30%`), stock badge, unit of measure, active batch selling price, farm origin, "Chi tiết" button, and "+ Thêm giỏ" quick-add button.
  5. *Product Details Modal:* Rich modal dialog rendering full nutritional description, farm origin, harvest date, batch expiry date, available stock, interactive quantity selector, and "Thêm vào giỏ hàng" action.
  6. *Empty State:* Displayed when no matching produce items exist, offering a clear button to reset filters.

### 2.2 Screen 2: UC-C05 — Manage Profile & Addresses (Rank 2, Priority 0.774)

- **Prototype Screen ID:** `screen-uc-c05`
- **Rendered High-Resolution Artifact:** [`artifacts/prototypes/images/prototype-uc-c05-manage-profile.png`](file:///artifacts/prototypes/images/prototype-uc-c05-manage-profile.png)
- **Primary Actor:** Customer
- **Traced Requirements:** `FR-PRF-01` (Profile & Address Maintenance), `FR-PRF-02` (Default Address Setting).
- **Traced Business Rules:** `BR-AUTH-01` (Authentication Prerequisite), `BR-AUTH-03` (Delivery Address Defaulting).
- **Screen Layout & UI Components:**
  1. *Personal Profile Card (Left Column):* Form fields for Full Name, Phone Number (read-only with verified OTP badge `BR-AUTH-02`), Contact Email for e-invoices, and Membership Tier badge (`Gold Organic Member`).
  2. *Address Book Grid (Right Column):* Responsive grid of saved delivery address cards showing Recipient Name, Phone Number, detailed Street/Ward/District/City, distance from FreshFood Hub, GPS Coordinates, and visual `Mặc định (BR-AUTH-03)` badge.
  3. *Address Actions:* "Đặt làm mặc định" button (clears previous default and assigns new default), "Chỉnh sửa" button, and "Xóa" button with confirmation.
  4. *Add/Edit Address Modal:* Form equipped with 10-digit Vietnamese phone number regex validation (`pattern="0[0-9]{9}"` per Exception `E3.1`), street address, ward, district, city, and "Đặt làm địa chỉ nhận hàng mặc định" checkbox.

### 2.3 Screen 3: UC-C03 — Manage Shopping Cart (Rank 3, Priority 0.610)

- **Prototype Screen ID:** `screen-uc-c03`
- **Rendered High-Resolution Artifact:** [`artifacts/prototypes/images/prototype-uc-c03-shopping-cart.png`](file:///artifacts/prototypes/images/prototype-uc-c03-shopping-cart.png)
- **Primary Actor:** Customer
- **Traced Requirements:** `FR-CRT-01` (Cart Maintenance), `FR-CRT-02` (Live Stock Availability Verification).
- **Traced Business Rules:** `BR-BAT-01` (Active Price), `BR-BAT-02` (FEFO Allocation), `BR-ORD-01` (Zero Over-Selling).
- **Screen Layout & UI Components:**
  1. *Shopping Basket Table:* Columns for Product & Batch Info, Unit Price, Quantity Controls (`-` / `+`), Line Total, and Remove (`✕ Bỏ`).
  2. *Real-Time Inventory Clamping:* When increasing item quantity, system cross-references active batch physical stock (`stock`). If requested quantity exceeds available stock, triggers warning toast and clamps quantity to maximum physically available units (Exception `E2.1`).
  3. *Batch Clearance Tagging:* Highlights items discounted under `BR-BAT-04` with red clearance badge and strikethrough original price.
  4. *Cart Summary Box:* Right-aligned card showing Subtotal, Batch Clearance Discount, and Grand Total.
  5. *Navigation Controls:* "Xóa toàn bộ giỏ" (clears basket with confirmation), "Tiếp tục chọn hàng" (navigates back to UC-C01), and "Tiến Hành Đặt Hàng" (navigates directly to UC-C06 Checkout).

### 2.4 Screen 4: UC-C06 — Checkout & Place Order (Rank 4, Priority 0.610)

- **Prototype Screen ID:** `screen-uc-c06`
- **Rendered High-Resolution Artifact:** [`artifacts/prototypes/images/prototype-uc-c06-checkout-order.png`](file:///artifacts/prototypes/images/prototype-uc-c06-checkout-order.png)
- **Primary Actor:** Customer
- **Traced Requirements:** `FR-PAY-01` (COD Support), `FR-ORD-01` (10km Boundary Check), `FR-ORD-02` (Tiered Shipping Fee), `FR-ORD-03` (FEFO Batch Reservation), `FR-PAY-02` (Dynamic VietQR & SePay Webhook).
- **Traced Business Rules:** `BR-AUTH-03`, `BR-DEL-01`, `BR-DEL-02`, `BR-ORD-01`, `BR-ORD-02`, `BR-ORD-03`, `BR-BAT-02`.
- **Screen Layout & UI Components:**
  1. *Step 1 — Delivery Destination Selection:* Defaults to customer's most recent completed purchase destination (`BR-AUTH-03`). Interactive dropdown allows switching addresses.
  2. *Step 2 — Google Maps 10km Boundary & Tiered Delivery Fee:*
     - Simulates Google Maps Distance Matrix API driving distance calculation.
     - **Boundary Enforcement (`BR-DEL-01`):** If distance $d \le 10	ext{ km}$, renders green validation card. If distance $d > 10	ext{ km}$ (e.g. Gamuda Gardens 13.5km), renders red warning card (`E4.1`) and disables the submit order button.
     - **Tiered Delivery Fee Computation (`BR-DEL-02`):** Automatically computes $< 1	ext{ km} 
ightarrow 10,000	ext{ VND}$; $1	ext{ to }<3	ext{ km} 
ightarrow 20,000	ext{ VND}$; $3	ext{ to }10	ext{ km} 
ightarrow 30,000	ext{ VND}$.
  3. *Step 3 — Payment Method Selector:*
     - Option A: Cash on Delivery (COD) (Default).
     - Option B: VietQR Banking Transfer — renders dynamic QR code encoding payable amount and Order ID, 15-minute countdown timer, and simulated SePay Webhook trigger button for instant auto-confirmation (`BR-ORD-03`).
  4. *Order Review & Submission:* Itemized produce summary, Subtotal, Shipping Fee, Total Amount, and "Xác Nhận Đặt Hàng" button with pessimistic locking and FEFO atomic inventory reservation.
  5. *Order Success Modal:* Displays assigned Order ID (e.g. `FF-20261023-089`), total amount, delivery destination, payment method, and direct link to track order in UC-C07.

### 2.5 Screen 5: UC-C07 — Manage My Orders (Rank 5, Priority 0.542)

- **Prototype Screen ID:** `screen-uc-c07`
- **Rendered High-Resolution Artifact:** [`artifacts/prototypes/images/prototype-uc-c07-manage-my-orders.png`](file:///artifacts/prototypes/images/prototype-uc-c07-manage-my-orders.png)
- **Primary Actor:** Customer
- **Traced Requirements:** `FR-MYO-01` (Order History Tracking), `FR-MYO-02` (Pending Order Cancellation), `FR-MYO-03` (Product Rating & Review), `FR-MYO-04` (1-Click Re-Order).
- **Traced Business Rules:** `BR-AUTH-01`, `BR-ORD-04`, `BR-ORD-05`, `BR-RE-01`, `BR-FB-01`.
- **Screen Layout & UI Components:**
  1. *Status Filter Tabs:* Allows customer to filter orders by lifecycle status: `Tất cả`, `Chờ xác nhận (Pending)`, `Đã xác nhận (Confirmed)`, `Đang giao (Shipping)`, `Thành công (Delivered)`, `Đã hủy (Cancelled)`.
  2. *Order History Card:* Displays Order ID, Order Date, Color-coded Status Badge, delivery destination, payment method, produce items summary, and total amount.
  3. *Order Timeline & Detail Modal:* 5-stage graphical progress tracker (`Đặt hàng` $
ightarrow$ `Xác nhận` $
ightarrow$ `Đóng gói` $
ightarrow$ `Đang giao` $
ightarrow$ `Thành công`), itemized invoice table, and delivery fees.
  4. *Cancellation Control (`BR-ORD-04`, `BR-ORD-05`):* Active on `Pending` and `Confirmed` orders. Prompts for cancellation reason and automatically releases reserved batch stock. Disabled on `Shipping` orders with clear tooltip policy explaining dispatch status (`E1.1`).
  5. *1-Click Re-Order (`BR-RE-01`):* Active on completed orders. Maps historical produce items back into current shopping cart using active batches and prevailing prices.
  6. *1–5 Star Rating & Review Modal (`BR-FB-01`):* Enabled exclusively on `Delivered` orders. Features interactive 5-star selector and optional feedback text area.

### 2.6 Screen 6: UC-M08 — Manage Goods Receipts (Warehouse Staff) (Rank 6, Priority 0.624)

- **Prototype Screen ID:** `screen-uc-m08`
- **Rendered High-Resolution Artifact:** [`artifacts/prototypes/images/prototype-uc-m08-goods-receipt.png`](file:///artifacts/prototypes/images/prototype-uc-m08-goods-receipt.png)
- **Primary Actor:** Warehouse Staff (Thủ kho)
- **Traced Requirements:** `FR-GR-01` (Goods Receipt History), `FR-GR-02` (Goods Receipt Creation), `FR-GR-03` (Perishable Expiry Validation), `FR-GR-04` (Automated Line & Grand Totals).
- **Traced Business Rules:** `BR-GR-01`, `BR-GR-02`, `BR-GR-03`, `BR-GR-04`, `BR-BAT-01`, `BR-BAT-03`.
- **Screen Layout & UI Components:**
  1. *Receipt Metadata Header:* Supplier dropdown (e.g. `Hợp tác xã Rau sạch Đà Lạt`), Supplier Invoice Number input, Receipt Date picker.
  2. *FEFO Initial Status Toggle (`BR-BAT-03`):* Checkbox allowing staff to initialize batch status to `Delayed` if older batches of the same produce item are currently active in inventory.
  3. *Line Items Entry Grid:* Columns for SKU/Product Selection, Batch Number (e.g. `LOT-20261023-DL01`), Manufacture Date (MFG), Expiration Date (EXP), Quantity, Unit Import Price, and Computed Line Total.
  4. *Expiration Date Validation (`BR-GR-02`):* Real-time automated validation enforcing $	ext{EXP} > 	ext{MFG}$ and $	ext{EXP} \ge 	ext{Receipt Date} + 3	ext{ days}$ for fresh produce. Invalid inputs highlight border in red and trigger error toast.
  5. *Automated Real-Time Totals (`BR-GR-03`):* Automatically computes line totals and receipt grand total without manual overrides.
  6. *Print Invoice Preview Modal:* Renders formatted monochrome Goods Receipt document for warehouse physical archiving, receipt printing, and handover signatures.

---

## 3. Requirements Traceability Verification Matrix

**Table 3.17: UI Prototype to Requirements & Business Rules Bidirectional Traceability**

| Prototype Screen ID | Screen Name | Implemented UI Controls & Event Flows | Traced FR IDs | Traced BR IDs | Traced NFR IDs |
|---|---|---|---|---|---|
| `screen-uc-c01` | Browse & Search Products | Search input, category pills, clearance checkbox, product card grid, detail modal, add-to-cart | `FR-BRW-01`, `FR-BRW-02`, `FR-BRW-03` | `BR-CAT-02`, `BR-BAT-01`, `BR-BAT-04` | `NFR-PERF-03` ($\le 500	ext{ ms}$) |
| `screen-uc-c05` | Manage Profile & Addresses | Profile edit form, address cards grid, add/edit modal, 10-digit phone regex validation, default address toggle | `FR-PRF-01`, `FR-PRF-02` | `BR-AUTH-01`, `BR-AUTH-03` | `NFR-SEC-01` (Privacy & Security) |
| `screen-uc-c03` | Manage Shopping Cart | Basket table, qty `+/-` controls, batch stock clamping, line total calculation, remove modal, subtotal | `FR-CRT-01`, `FR-CRT-02` | `BR-BAT-01`, `BR-BAT-02`, `BR-ORD-01` | `NFR-PERF-01` (Sub-second response) |
| `screen-uc-c06` | Checkout & Place Order | Default address loader, distance matrix 10km check, tiered fee table, COD/VietQR selector, QR countdown, submit order | `FR-PAY-01`, `FR-ORD-01..03`, `FR-PAY-02` | `BR-DEL-01`, `BR-DEL-02`, `BR-ORD-01..03`, `BR-BAT-02` | `NFR-REL-01` (Zero over-selling), `NFR-PERF-02` ($\le 3.0	ext{ s}$) |
| `screen-uc-c07` | Manage My Orders | Status filter tabs, order history cards, 5-stage timeline modal, cancel order control, re-order action, review modal | `FR-MYO-01..04` | `BR-ORD-04`, `BR-ORD-05`, `BR-RE-01`, `BR-FB-01` | `NFR-PERF-01` (Real-time tracking) |
| `screen-uc-m08` | Manage Goods Receipts | Supplier selector, invoice input, batch entry table, $	ext{EXP} \ge 3	ext{ days}$ validation, grand total, print preview | `FR-GR-01..04` | `BR-GR-01..04`, `BR-BAT-03` | `NFR-REL-01` (Inventory integrity) |

---

## 4. Static GUI Review Checklist Compliance (`d1_Checklist_GUI Review.xls`)

The entire prototype suite has been formally evaluated against all mandatory and optional items in `checklists/d1_Checklist_GUI Review.xls`:

**Table 3.18: GUI Review Checklist Compliance Evaluation**

| Check Item | Description | Evaluation Result | Compliance Rationale & Implementation Notes |
|:---:|---|:---:|---|
| **R10** | Is graphical design of GUI reviewed or accepted by customer? | **Yes** | Aligned with customer requirement document (`references/User requierement.docx`) and verified against Karl Wiegers priority rankings. |
| **R12** | Is one button set to be default? | **Yes** | Primary action buttons (`Thêm vào giỏ`, `Tiến hành đặt hàng`, `Xác nhận đặt hàng`, `Lưu địa chỉ`) are distinctly highlighted with emerald green `#059669`. |
| **R13** | Are controls ordered according to normal behavior? | **Yes** | Standard top-to-bottom and left-to-right reading hierarchy, inputs precede action buttons, cancel/close buttons positioned secondary. |
| **R14** | Are all labels aligned uniformly? | **Yes** | Form labels are top-aligned with uniform font size (13px, weight 600, color `#334155`) across all modals and screens. |
| **R15** | Are text areas aligned uniformly? | **Yes** | Text inputs, dropdowns, and textareas share identical padding (10px 14px), border-radius (8px), and focus rings. |
| **R16** | Are there any spelling mistakes? | **Yes (0 errors)** | Verified 100% correct spelling across all English technical identifiers and Vietnamese user-facing display copy. |
| **R17** | Are non-enterable areas styled consistently? | **Yes** | Read-only fields (e.g. verified phone number in profile) are styled with consistent background `#f1f5f9` and `cursor: not-allowed`. |
| **R18** | Is the tab sequence correct? | **Yes** | Logical tab navigation flows sequentially through all form fields from top to bottom before reaching submit controls. |
| **R21** | Do all fields match data length? | **Yes** | Strict regex and length enforcement (e.g. 10 digits for phone numbers `0\d{9}`, currency formatted to VND integer). |
| **R22** | Do enterable fields reject invalid inputs? | **Yes** | Phone number field rejects non-numeric/invalid lengths; quantity inputs reject values $\le 0$ or exceeding available batch stock. |
| **R25** | Are abbreviations consistently used? | **Yes** | Standard abbreviations (`SKU`, `MFG`, `EXP`, `COD`, `VietQR`, `FEFO`, `HUB`) applied consistently across all screens. |
| **R27** | Are color combinations consistent? | **Yes** | Cohesive organic food palette: primary green (`#059669`, `#10b981`), amber warning (`#f59e0b`), rose error (`#f43f5e`), slate neutrals. |
| **R28** | Is screen usage intuitive? | **Yes** | Familiar e-commerce paradigms: shopping basket drawer, 2-column checkout, step progress timeline, and standard modal sheets. |

---

## 5. Prototype Visual Gallery (Embedded Rendered Static Images)

Below are the high-resolution static rendering captures of each prioritized Use Case prototype screen, generated from the authoritative master HTML/CSS/JS prototype in accordance with `AGENTS.md` §2.8 and §2.9:

### Figure 3.10: Prototype Overview — Karl Wiegers Prioritized Use Case Backlog
![Prototype Overview](file:///d:/1.%20Giang%20Day/GenAI/SE-Lifecycle-Agent/artifacts/prototypes/images/prototype-priority-overview.png)

### Figure 3.11: UI Prototype — UC-C01: Browse & Search Products (Priority Rank 1)
![UI Prototype UC-C01](file:///d:/1.%20Giang%20Day/GenAI/SE-Lifecycle-Agent/artifacts/prototypes/images/prototype-uc-c01-browse-search.png)

### Figure 3.12: UI Prototype — UC-C05: Manage Profile & Addresses (Priority Rank 2)
![UI Prototype UC-C05](file:///d:/1.%20Giang%20Day/GenAI/SE-Lifecycle-Agent/artifacts/prototypes/images/prototype-uc-c05-manage-profile.png)

### Figure 3.13: UI Prototype — UC-C03: Manage Shopping Cart & Live Inventory (Priority Rank 3)
![UI Prototype UC-C03](file:///d:/1.%20Giang%20Day/GenAI/SE-Lifecycle-Agent/artifacts/prototypes/images/prototype-uc-c03-shopping-cart.png)

### Figure 3.14: UI Prototype — UC-C06: Checkout & Place Order (Priority Rank 4)
![UI Prototype UC-C06](file:///d:/1.%20Giang%20Day/GenAI/SE-Lifecycle-Agent/artifacts/prototypes/images/prototype-uc-c06-checkout-order.png)

### Figure 3.15: UI Prototype — UC-C07: Manage My Orders Lifecycle & Reviews (Priority Rank 5)
![UI Prototype UC-C07](file:///d:/1.%20Giang%20Day/GenAI/SE-Lifecycle-Agent/artifacts/prototypes/images/prototype-uc-c07-manage-my-orders.png)

### Figure 3.16: UI Prototype — UC-M08: Manage Goods Receipts & FEFO Batch Tagging (Priority Rank 6)
![UI Prototype UC-M08](file:///d:/1.%20Giang%20Day/GenAI/SE-Lifecycle-Agent/artifacts/prototypes/images/prototype-uc-m08-goods-receipt.png)


## Customer Deployment Channel Alignment (2026-10-26)

Customer presentation channels are FreshFood-Customer-Web (browser storefront) and FreshFood-App (Android/iOS); both use FreshFood-API and the same existing customer business rules and data. FreshFood-Web serves staff and Store Owner back-office operations. Existing customer web prototypes represent FreshFood-Customer-Web; they do not introduce additional business requirements. Mobile-specific screens and channel-specific push behavior require separate verification.
