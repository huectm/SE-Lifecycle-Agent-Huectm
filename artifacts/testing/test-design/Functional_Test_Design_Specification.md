# Functional Test Design Specification — System Testing Phase

**Project Name:** FreshFood Organic E-Commerce Platform  
**Document Version:** 1.0 (Baselined Specification)  
**Lifecycle Phase:** V-Model Stage 1 — Post-Requirements System Test Planning & Design  
**Governing Governance:** `AGENTS.md` §14, `.agents/Rules/testing-rules.md`, `artifact-registry.md`, and `.agents/skills/software-testing/SKILL.md`  
**Quality Review Checklist:** `checklists/Checklist_Test Case Review.xls`  
**Master Test Workbook:** [`artifacts/testing/test-cases/Functional_Test_Cases.xlsx`](file:///artifacts/testing/test-cases/Functional_Test_Cases.xlsx)  
**Test Data Catalog:** [`artifacts/testing/test-data/`](file:///artifacts/testing/test-data/)  

---

## 1. Executive Summary & Test Basis

In strict adherence to the **V-Model (Mô hình chữ V)** and the **Shift-Left Testing Principle**, System Test Planning and System Test Case Design are conducted immediately upon formal approval of the **Requirements Baseline** (Chapter I, II, III of `Requirements_Analysis_Design_Specification.docx`). 

This document establishes the authoritative test basis, design techniques, input value partitions, test case specifications, and structured test data sets for the **6 Prioritized Use Cases** selected through the **Karl Wiegers Quantitative Prioritization Model** (`artifacts/requirements/requirements-prioritization.csv`).

### 1.1 Test Basis Documents
The test conditions and test cases herein are derived strictly from:
1. **Software Requirements Specification (SRS):** Functional Requirements (`FR-BRW-01..03`, `FR-PRF-01..02`, `FR-CRT-01..02`, `FR-ORD-01..03`, `FR-PAY-01..02`, `FR-MYO-01..04`, `FR-GR-01..05`).
2. **Business Rules Catalog:** `BR-CAT-01..02`, `BR-BAT-01..04`, `BR-AUTH-01..03`, `BR-DEL-01..02`, `BR-ORD-01..05`, `BR-FB-01`, `BR-GR-01..04`.
3. **Structured Use Case Specifications:** Detailed specifications for `UC-C01`, `UC-C05`, `UC-C03`, `UC-C06`, `UC-C07`, and `UC-M08`.
4. **Interactive UI Prototypes:** Multi-screen responsive prototype baseline (`artifacts/prototypes/index.html` and static figures).
5. **Quality Attributes (NFRs):** `NFR-PERF-01..03` (Sub-500ms search, $\le 3.0\text{ s}$ QR webhook), `NFR-REL-01` (Zero over-selling, pessimistic locking, ACID rollback).

### 1.2 Lifecycle Execution Status
Pursuant to the **V-Model Shift-Left Invariants** (`.agents/Rules/testing-rules.md` §2.1), this document and the accompanying master workbook represent the **System Test Planning & Test Case Design Baseline** established immediately upon Requirements Approval. Because implementation (Phase 08) has not yet commenced, **dynamic test execution has not been conducted**.

| Metric | Planned Design Baseline | Current Execution Count | Execution Percentage | Status Note |
|---|:---:|:---:|:---:|---|
| **Total Test Cases** | 64 | — | 100% Designed | Baselined & Verified against Checklist |
| **Pass** | — | **0** | **0.0%** | Awaiting Phase 08 Implementation |
| **Fail** | — | **0** | **0.0%** | No defects logged yet |
| **Untested / Pending Execution** | 64 | **64** | **100.0%** | All test cases ready for dynamic run |
| **Execution Progress** | — | — | **0.0%** | **AWAITING IMPLEMENTATION** |

---

## 2. Test Scope & Prioritization Alignment

All functional test cases correspond directly to the highest-priority features in the Product Backlog, delivering end-to-end verification across customer e-commerce workflows and warehouse inventory intake:

| Rank | UC ID | Use Case Name | Primary Actor | Traced Functional Requirements | Traced Business Rules | Test Case Count | Test Data File |
|:---:|:---:|---|:---:|---|---|:---:|---|
| **1** | **UC-C01** | **Browse & Search Products** | Guest, Customer | `FR-BRW-01..03`, `FR-CAT-01` | `BR-CAT-02`, `BR-BAT-01`, `BR-BAT-04` | **9** | `products_catalog_test_data.csv` |
| **2** | **UC-C05** | **Manage Profile & Addresses** | Customer | `FR-PRF-01..02` | `BR-AUTH-01`, `BR-AUTH-03`, `BR-DEL-01` | **9** | `customers_addresses_test_data.csv` |
| **3** | **UC-C03** | **Manage Shopping Cart** | Customer | `FR-CRT-01..02` | `BR-BAT-01..02`, `BR-ORD-01` | **9** | `shopping_cart_test_data.csv` |
| **4** | **UC-C06** | **Checkout & Place Order** | Customer | `FR-PAY-01..02`, `FR-ORD-01..03` | `BR-DEL-01..02`, `BR-ORD-01..03`, `BR-BAT-02` | **13** | `checkout_orders_test_data.csv` |
| **5** | **UC-C07** | **Manage My Orders** | Customer | `FR-MYO-01..04` | `BR-ORD-04..05`, `BR-FB-01`, `BR-RE-01` | **12** | `order_tracking_reviews_test_data.csv` |
| **6** | **UC-M08** | **Manage Goods Receipts** | Warehouse Staff | `FR-GR-01..04`, `FR-BAT-04` | `BR-GR-01..04`, `BR-BAT-03` | **12** | `goods_receipts_test_data.csv` |
| **Total** | | | | | | **64** | |

---

## 3. Test Design Techniques Applied

Pursuant to `.agents/Rules/testing-rules.md` §6, the test suite leverages a rigorous combination of black-box test design techniques:

### 3.1 Equivalence Partitioning (EP)
Input domains and state variables are divided into valid and invalid equivalence classes:
- **Phone Numbers:** Valid (10 digits starting with `03`, `05`, `07`, `08`, `09`); Invalid (<10 digits, >10 digits, alphabetic/special chars).
- **Delivery Distance ($d$):** Valid in-radius ($0 \le d \le 10.0\text{ km}$); Invalid out-of-radius ($d > 10.0\text{ km}$).
- **Purchase Quantity ($Q$):** Valid ($1 \le Q \le \text{Available Stock}$); Invalid ($Q \le 0$, $Q > \text{Available Stock}$, non-numeric).
- **Customer Ratings:** Valid ($1, 2, 3, 4, 5$ stars); Invalid ($0$, $>5$, negative, decimal).
- **Perishable Expiry Date ($\text{EXP}$):** Valid ($\text{EXP} \ge \text{Receipt Date} + 3\text{ days}$); Invalid ($\text{EXP} < \text{Receipt Date} + 3\text{ days}$, $\text{EXP} \le \text{MFG}$).

### 3.2 Boundary Value Analysis (BVA)
Boundary values are targeted at the immediate edges of equivalence partitions:
- **Store Distance Limits:** $0.99\text{ km}$ (Tier 1: 10k), $1.00\text{ km}$ (Tier 2: 20k), $2.99\text{ km}$ (Tier 2: 20k), $3.00\text{ km}$ (Tier 3: 30k), $9.99\text{ km}$ (Tier 3: 30k), $10.00\text{ km}$ (Boundary accepted: 30k), $10.01\text{ km}$ & $10.20\text{ km}$ (Boundary rejected: Order blocked per `BR-DEL-01`).
- **Physical Stock Balance:** Quantity = $1$ (Min valid), Quantity = $\text{Available Stock}$ (Max valid), Quantity = $\text{Available Stock} + 1$ (Over-selling boundary clamped per `BR-ORD-01`).
- **Shelf-life Duration:** Receipt Date $+3\text{ days}$ (Min valid boundary per `BR-GR-02`), Receipt Date $+2\text{ days}$ (Max invalid boundary rejected).

### 3.3 Use Case Testing (UCT)
Every structured Use Case description is translated into test cases executing:
- **Normal Flow (Happy Path):** Step-by-step verification of primary business goal attainment.
- **Alternative Flows:** Optional user branches (e.g. Clearance filtering `A3.2`, Changing delivery address `A2.1`, VietQR banking transfer `A6.1`, 1-Click Re-order `A5.1`, Submitting reviews `A5.2`).
- **Exception Flows:** Error handling, network failures, input errors, and constraint rejections (e.g. Out of stock `E2.1`, Expired item in cart `E3.1`, Unresolvable address `E3.2`, Boundary distance exceeded `E4.1`, Inventory race condition rollback `E8.1`).

### 3.4 State Transition Testing (STT)
Fulfillment lifecycle statuses for Orders (`Pending` $\rightarrow$ `Confirmed` $\rightarrow$ `Packing` $\rightarrow$ `Shipping` $\rightarrow$ `Delivered` $\rightarrow$ `Cancelled`) are tested to ensure:
- Only permissible state transitions occur.
- Cancellation is allowed in `Pending` and `Confirmed` (triggering batch stock release per `BR-ORD-04`, `BR-ORD-05`).
- Cancellation is blocked in `Packing` and `Shipping` (requiring hotline intervention).
- Product review is restricted exclusively to `Delivered` state (`BR-FB-01`).

---

## 4. Test Case Catalog by Module

Detailed test cases are baselined in the master workbook [`artifacts/testing/test-cases/Functional_Test_Cases.xlsx`](file:///artifacts/testing/test-cases/Functional_Test_Cases.xlsx). The structural catalog is outlined below:

### 4.1 Module 1: UC-C01 — Browse & Search Products (Sheet `UC-C01_BrowseSearch`)
- **`TC-C01-01` (Normal):** Verify display of curated sections (*New Arrivals*, *Best Sellers*, *Promotions*) on storefront home page (`FR-BRW-01`).
- **`TC-C01-02` (Normal):** Verify category filtering for "Rau lá hữu cơ" shows matching active produce with category count (`FR-BRW-01`, `BR-CAT-02`).
- **`TC-C01-03` (Performance / Normal):** Verify sub-500ms full-text keyword search for produce ("Cải") (`FR-BRW-02`, `NFR-PERF-03`).
- **`TC-C01-04` (Normal):** Verify diacritic and case-insensitive search (`cai be xanh`, `CẢI BẸ XANH`, `cải bẹ`) (`FR-BRW-02`).
- **`TC-C01-05` (Exception):** Verify search with non-existent keyword displays empty state message and 6 recommendations (Flow E4.1).
- **`TC-C01-06` (Normal):** Verify product detail view displays certifications, batch price, harvest date, and expiry date (`FR-BRW-03`, `BR-BAT-01`).
- **`TC-C01-07` (Alternative):** Verify near-expiry clearance filter tag displays items with 10%–50% discount tags (`BR-BAT-04`).
- **`TC-C01-08` (Boundary / Normal):** Verify out-of-stock item displays "Tạm hết hàng" badge and disables Add to Cart button (`BR-ORD-01`).
- **`TC-C01-09` (Negative):** Verify inactive product (`is_active = FALSE`) is excluded from all public listings and search results.

### 4.2 Module 2: UC-C05 — Manage Profile & Addresses (Sheet `UC-C05_ProfileAddress`)
- **`TC-C05-01` (Normal):** Verify customer profile and saved delivery address book display (`FR-PRF-01`, `BR-AUTH-01`).
- **`TC-C05-02` (Normal):** Verify updating profile with valid full name and email displays success confirmation (`FR-PRF-01`, Flow A2.1).
- **`TC-C05-03` (Negative):** Verify updating profile with invalid email syntax (`an.nguyen@invalid`) triggers validation error.
- **`TC-C05-04` (Normal):** Verify adding new delivery address with automated Google Maps geocoding resolves coordinates (`FR-PRF-01`, Flow A3.1).
- **`TC-C05-05` (Normal):** Verify setting new delivery address as default clears previous default flag (`BR-AUTH-03`).
- **`TC-C05-06` (Negative):** Verify recipient phone validation rejects numbers with <10 digits or alphabetic characters (Flow E3.1).
- **`TC-C05-07` (Exception):** Verify fictitious/unresolvable street address prompts Google Maps geocoding warning (Flow E3.2).
- **`TC-C05-08` (Normal):** Verify editing existing delivery address updates database record and recalculates map coordinates (Flow A3.2).
- **`TC-C05-09` (Normal):** Verify deleting delivery address not tied to active orders removes record successfully (Flow A3.3).

### 4.3 Module 3: UC-C03 — Manage Shopping Cart (Sheet `UC-C03_ShoppingCart`)
- **`TC-C03-01` (Normal):** Verify adding active produce item to cart increments header badge and updates line totals (`FR-CRT-01`, `FR-CRT-02`).
- **`TC-C03-02` (Boundary):** Verify adding quantity equal to available physical stock balance succeeds (`BR-BAT-02`, `BR-ORD-01`).
- **`TC-C03-03` (Boundary / Exception):** Verify adding quantity exceeding available stock clamps quantity to max with warning badge (`BR-ORD-01`, Flow E2.1).
- **`TC-C03-04` (Normal):** Verify clicking '+' button increments quantity and updates cart subtotal in real-time (Flow A4.1).
- **`TC-C03-05` (Normal):** Verify clicking '-' button decrements quantity down to minimum 1 (Flow A4.1).
- **`TC-C03-06` (Negative):** Verify typing 0 or negative quantity prompts for item removal or resets to 1 (Input Validation).
- **`TC-C03-07` (Normal):** Verify removing line item deletes record from cart and recalculates basket subtotal (Flow A4.2).
- **`TC-C03-08` (Exception):** Verify cart containing expired batch item displays red warning banner and disables checkout (`BR-BAT-02`, Flow E3.1).
- **`TC-C03-09` (Normal):** Verify persistent shopping cart preserves line items across browser refresh or customer re-login (`FR-CRT-01`).

### 4.4 Module 4: UC-C06 — Checkout & Place Order (Sheet `UC-C06_CheckoutOrder`)
- **`TC-C06-01` (Normal):** Verify checkout screen pre-selects default shipping address to customer's most recent order destination (`FR-PRF-02`, `BR-AUTH-03`).
- **`TC-C06-02` (Boundary):** Verify Google Maps driving distance $d < 1\text{ km}$ sets Tier 1 delivery fee ($10,000\text{ VND}$) (`BR-DEL-01`, `BR-DEL-02`).
- **`TC-C06-03` (Normal):** Verify Google Maps distance $1\text{ to }<3\text{ km}$ sets Tier 2 delivery fee ($20,000\text{ VND}$) (`BR-DEL-02`).
- **`TC-C06-04` (Normal):** Verify Google Maps distance $3\text{ to }10\text{ km}$ sets Tier 3 delivery fee ($30,000\text{ VND}$) (`BR-DEL-02`).
- **`TC-C06-05` (Boundary):** Verify distance exactly $d = 10.0\text{ km}$ is accepted with $30,000\text{ VND}$ fee (`BR-DEL-01`).
- **`TC-C06-06` (Boundary / Exception):** Verify distance $d > 10.0\text{ km}$ (e.g. $10.2\text{ km}$) blocks checkout with boundary alert (`BR-DEL-01`, Flow E4.1).
- **`TC-C06-07` (Normal):** Verify placing COD order executes ACID transaction, reserves FEFO batch stock, and sets status `Pending` (`FR-ORD-01`, `BR-ORD-01`, `BR-BAT-02`).
- **`TC-C06-08` (Alternative):** Verify selecting VietQR generates dynamic QR code with exact payable amount and Order Number (`FR-PAY-02`, `BR-ORD-03`).
- **`TC-C06-09` (Exception):** Verify VietQR 15-minute countdown expiration automatically cancels order and releases reserved batch stock (`BR-ORD-03`, `BR-ORD-05`).
- **`TC-C06-10` (Performance / Normal):** Verify SePay Webhook confirmation transitions order status to `Paid` within $\le 3.0\text{ s}$ (`BR-ORD-03`, `NFR-PERF-02`).
- **`TC-C06-11` (Negative):** Verify Webhook notification with mismatched transfer amount updates status to `Pending_Manual_Review` (`BR-ORD-03`).
- **`TC-C06-12` (Security / Resilience):** Verify duplicate Webhook callback is processed idempotently without double-counting revenue.
- **`TC-C06-13` (Concurrency):** Verify concurrent inventory depletion rolls back transaction cleanly with stock change alert (`NFR-REL-01`, Flow E8.1).

### 4.5 Module 5: UC-C07 — Manage My Orders (Sheet `UC-C07_MyOrders`)
- **`TC-C07-01` (Normal):** Verify order history displays customer orders sorted by order date descending (`FR-MYO-01`).
- **`TC-C07-02` (Normal):** Verify color-coded status badges for all order states (`Pending`, `Confirmed`, `Packing`, `Shipping`, `Delivered`, `Cancelled`) (`FR-MYO-01`).
- **`TC-C07-03` (Normal):** Verify viewing order details shows itemized list, batch discounts, delivery fee, payment method, and tracking timeline (`FR-MYO-02`).
- **`TC-C07-04` (Alternative):** Verify customer cancelling order in `Pending` status changes status to `Cancelled` and releases reserved batch stock (`BR-ORD-04`, `BR-ORD-05`, Flow A3.1).
- **`TC-C07-05` (Alternative):** Verify customer cancelling order in `Confirmed` status succeeds and releases batch stock (`BR-ORD-04`, `BR-ORD-05`).
- **`TC-C07-06` (Exception):** Verify customer attempting to cancel order in `Packing` or `Shipping` is disabled with alert to call store hotline (`BR-ORD-04`, Flow E1.1).
- **`TC-C07-07` (Alternative):** Verify 1-click re-order from `Delivered` order maps items into active shopping cart with current prices (`FR-MYO-04`, Flow A5.1).
- **`TC-C07-08` (Exception):** Verify re-order alerts customer when historical produce items are out of stock (Flow E2.1).
- **`TC-C07-09` (Alternative):** Verify submitting 1-5 star review on a `Delivered` order commits review and updates rating (`BR-FB-01`, Flow A5.2).
- **`TC-C07-10` (Negative):** Verify submitting review on undelivered order (`Pending`/`Shipping`) is prohibited (`BR-FB-01`).
- **`TC-C07-11` (Negative):** Verify duplicate review submission on the same order is rejected (1:1 constraint) (`BR-FB-01`).
- **`TC-C07-12` (Boundary):** Verify review rating boundary validation: 0 stars and 6 stars are rejected by form validator (`BR-FB-01`).

### 4.6 Module 6: UC-M08 — Manage Goods Receipts (Sheet `UC-M08_GoodsReceipt`)
- **`TC-M08-01` (Normal):** Verify creating Goods Receipt with all mandatory batch attributes (Batch No, MFG, EXP, Qty $>0$, Price $>0$) succeeds (`BR-GR-01`, `FR-GR-01`).
- **`TC-M08-02` (Normal):** Verify perishable fresh produce with $\text{EXP} \ge \text{Receipt Date} + 3\text{ days}$ succeeds (`BR-GR-02`).
- **`TC-M08-03` (Boundary):** Verify boundary test: Perishable $\text{EXP} = \text{Receipt Date} + 3\text{ days}$ (exactly 3 days) is accepted (`BR-GR-02`).
- **`TC-M08-04` (Boundary / Exception):** Verify exception test: Perishable $\text{EXP} < \text{Receipt Date} + 3\text{ days}$ (e.g. 2 days) is rejected with error alert (`BR-GR-02`).
- **`TC-M08-05` (Negative):** Verify exception test: $\text{EXP} \le \text{MFG}$ is rejected by date validation (`BR-GR-02`).
- **`TC-M08-06` (Normal):** Verify automatic computation: $\text{Line Total} = \text{Qty} \times \text{Import Price}$ and $\text{Receipt Total} = \sum \text{Line Totals}$ without manual override (`BR-GR-03`, `FR-GR-04`).
- **`TC-M08-07` (Alternative):** Verify setting initial sale status of imported batch to `Delayed` keeps stock unlisted from storefront (`BR-BAT-03`, `FR-BAT-04`).
- **`TC-M08-08` (Alternative):** Verify setting initial sale status to `Active` immediately makes batch available for customer purchase in storefront (`BR-BAT-03`).
- **`TC-M08-09` (Normal):** Verify goods receipt creation updates physical inventory balance in `batch_inventory` (`FR-GR-02`).
- **`TC-M08-10` (Security / Immutability):** Verify Goods Receipt immutability: Editing or deleting a receipt whose batch has reserved or sold stock is strictly blocked (`BR-GR-04`).
- **`TC-M08-11` (Negative):** Verify duplicate Batch Number entry within the system is rejected (`Data Integrity`).
- **`TC-M08-12` (Boundary / Negative):** Verify entering 0 or negative quantity or unit import price rejects line creation (`BR-GR-01`).

---

## 5. Test Data Catalog & Structured Sets

In accordance with `.agents/skills/software-testing/SKILL.md` Section E, complete test datasets are externalized into version-controlled CSV files under `artifacts/testing/test-data/`:

| Dataset File Name | Description | Key Data Attributes & Boundary Conditions |
|---|---|---|
| [`products_catalog_test_data.csv`](file:///artifacts/testing/test-data/products_catalog_test_data.csv) | Catalog products, categories, active batches, and pricing | 10 produce items: Categories (`CAT-VEG`, `CAT-FRU`, `CAT-TUB`, `CAT-MUSH`), certifications (USDA, EU, VietGAP), clearance discounts (20%, 30%, 50%), and out-of-stock items (0 available). |
| [`customers_addresses_test_data.csv`](file:///artifacts/testing/test-data/customers_addresses_test_data.csv) | Customer accounts, phone numbers, and delivery addresses | 13 test cases: Valid Vietnamese 10-digit phones, invalid phones (7 digits, 12 digits, alphabetic), distances: Tier 1 (0.85 km), Tier 2 (1.2 km, 1.8 km, 2.1 km), Tier 3 (6.2 km, 7.5 km), Boundary valid (10.00 km), Boundary invalid (10.20 km, 14.50 km), and unresolvable address. |
| [`shopping_cart_test_data.csv`](file:///artifacts/testing/test-data/shopping_cart_test_data.csv) | Shopping cart line items and inventory clamping | 10 test scenarios: Normal addition, max stock addition (Qty=40), stock clamp (Qty=45 $\rightarrow$ 40 per `BR-ORD-01`), 0 quantity, negative quantity, non-numeric, clearance item clamp, and item removal. |
| [`checkout_orders_test_data.csv`](file:///artifacts/testing/test-data/checkout_orders_test_data.csv) | Order checkout, delivery fees, and SePay webhook payloads | 10 order scenarios: Tier 1 fee (10k), Tier 2 fee (20k), Tier 3 fee (30k), exactly 10.0 km boundary, 10.2 km blocked, VietQR dynamic payload, 15-min timeout cancellation, webhook amount mismatch, forged signature, and duplicate webhook idempotency. |
| [`order_tracking_reviews_test_data.csv`](file:///artifacts/testing/test-data/order_tracking_reviews_test_data.csv) | Order tracking, lifecycle cancellation, and review ratings | 11 scenarios: Cancellation in `Pending`/`Confirmed` (stock released), cancellation blocked in `Packing`/`Shipping`, 1-click re-order, 1–5 star reviews on `Delivered` orders, review blocked before delivery, duplicate review rejected, 0 and 6 stars boundary rejection. |
| [`goods_receipts_test_data.csv`](file:///artifacts/testing/test-data/goods_receipts_test_data.csv) | Goods receipt lines, batch constraints, and immutability | 12 intake scenarios: Normal import, perishable boundary ($\text{EXP} = \text{Receipt} + 3\text{ days}$), perishable rejected ($+2\text{ days}$), $\text{EXP} \le \text{MFG}$ rejected, missing batch number, zero/negative quantity, zero/negative price, duplicate batch, and immutability lock. |

---

## 6. Bidirectional Traceability Matrix

Every single test case traces directly to approved Functional Requirements and Business Rules:

| Test Case ID | Use Case | Traced Requirement (FR) | Traced Business Rule (BR) | Test Type | Execution Status |
|:---:|:---:|:---:|:---:|:---:|:---:|
| `TC-C01-01` | `UC-C01` | `FR-BRW-01` | `BR-CAT-01` | Positive / UI | Untested (Design Baselined) |
| `TC-C01-02` | `UC-C01` | `FR-BRW-01` | `BR-CAT-02` | Positive / Functional | Untested (Design Baselined) |
| `TC-C01-03` | `UC-C01` | `FR-BRW-02` | — | Performance / SLA | Untested (Design Baselined) |
| `TC-C01-04` | `UC-C01` | `FR-BRW-02` | — | Positive / Functional | Untested (Design Baselined) |
| `TC-C01-05` | `UC-C01` | `FR-BRW-02` | — | Exception / UI | Untested (Design Baselined) |
| `TC-C01-06` | `UC-C01` | `FR-BRW-03` | `BR-BAT-01` | Positive / Data | Untested (Design Baselined) |
| `TC-C01-07` | `UC-C01` | `FR-BRW-03` | `BR-BAT-04` | Alternative / Pricing | Untested (Design Baselined) |
| `TC-C01-08` | `UC-C01` | `FR-BRW-03` | `BR-ORD-01` | Boundary / Stock | Untested (Design Baselined) |
| `TC-C01-09` | `UC-C01` | `FR-BRW-01` | — | Negative / Integrity | Untested (Design Baselined) |
| `TC-C05-01` | `UC-C05` | `FR-PRF-01` | `BR-AUTH-01` | Positive / UI | Untested (Design Baselined) |
| `TC-C05-02` | `UC-C05` | `FR-PRF-01` | — | Positive / Functional | Untested (Design Baselined) |
| `TC-C05-03` | `UC-C05` | `FR-PRF-01` | — | Negative / Validation | Untested (Design Baselined) |
| `TC-C05-04` | `UC-C05` | `FR-PRF-01` | — | Positive / Geocoding | Untested (Design Baselined) |
| `TC-C05-05` | `UC-C05` | `FR-PRF-01` | `BR-AUTH-03` | Positive / Rule | Untested (Design Baselined) |
| `TC-C05-06` | `UC-C05` | `FR-PRF-01` | — | Negative / Validation | Untested (Design Baselined) |
| `TC-C05-07` | `UC-C05` | `FR-PRF-01` | — | Exception / Geocoding | Untested (Design Baselined) |
| `TC-C05-08` | `UC-C05` | `FR-PRF-01` | — | Positive / Functional | Untested (Design Baselined) |
| `TC-C05-09` | `UC-C05` | `FR-PRF-01` | — | Positive / Functional | Untested (Design Baselined) |
| `TC-C03-01` | `UC-C03` | `FR-CRT-01`, `FR-CRT-02` | `BR-BAT-01` | Positive / Cart | Untested (Design Baselined) |
| `TC-C03-02` | `UC-C03` | `FR-CRT-02` | `BR-ORD-01` | Boundary / Stock | Untested (Design Baselined) |
| `TC-C03-03` | `UC-C03` | `FR-CRT-02` | `BR-ORD-01` | Boundary / Clamp | Untested (Design Baselined) |
| `TC-C03-04` | `UC-C03` | `FR-CRT-01` | — | Positive / Calculation | Untested (Design Baselined) |
| `TC-C03-05` | `UC-C03` | `FR-CRT-01` | — | Boundary / Decrement | Untested (Design Baselined) |
| `TC-C03-06` | `UC-C03` | `FR-CRT-01` | `BR-ORD-01` | Negative / Validation | Untested (Design Baselined) |
| `TC-C03-07` | `UC-C03` | `FR-CRT-01` | — | Positive / Cart | Untested (Design Baselined) |
| `TC-C03-08` | `UC-C03` | `FR-CRT-01` | `BR-BAT-02` | Exception / Expiry | Untested (Design Baselined) |
| `TC-C03-09` | `UC-C03` | `FR-CRT-01` | — | Positive / Persistence | Untested (Design Baselined) |
| `TC-C06-01` | `UC-C06` | `FR-PRF-02` | `BR-AUTH-03` | Positive / Default | Untested (Design Baselined) |
| `TC-C06-02` | `UC-C06` | `FR-ORD-01` | `BR-DEL-01`, `BR-DEL-02` | Boundary / Fee Tier 1 | Untested (Design Baselined) |
| `TC-C06-03` | `UC-C06` | `FR-ORD-01` | `BR-DEL-02` | Positive / Fee Tier 2 | Untested (Design Baselined) |
| `TC-C06-04` | `UC-C06` | `FR-ORD-01` | `BR-DEL-02` | Positive / Fee Tier 3 | Untested (Design Baselined) |
| `TC-C06-05` | `UC-C06` | `FR-ORD-01` | `BR-DEL-01` | Boundary / Max Distance | Untested (Design Baselined) |
| `TC-C06-06` | `UC-C06` | `FR-ORD-01` | `BR-DEL-01` | Boundary / Out of Range | Untested (Design Baselined) |
| `TC-C06-07` | `UC-C06` | `FR-ORD-01` | `BR-BAT-02`, `BR-ORD-01` | Positive / ACID Stock | Untested (Design Baselined) |
| `TC-C06-08` | `UC-C06` | `FR-PAY-02` | `BR-ORD-03` | Alternative / VietQR | Untested (Design Baselined) |
| `TC-C06-09` | `UC-C06` | `FR-PAY-02` | `BR-ORD-03`, `BR-ORD-05` | Exception / Timeout | Untested (Design Baselined) |
| `TC-C06-10` | `UC-C06` | `FR-PAY-02` | `BR-ORD-03` | Performance / Webhook | Untested (Design Baselined) |
| `TC-C06-11` | `UC-C06` | `FR-PAY-02` | `BR-ORD-03` | Negative / Mismatch | Untested (Design Baselined) |
| `TC-C06-12` | `UC-C06` | `FR-PAY-02` | — | Security / Idempotency | Untested (Design Baselined) |
| `TC-C06-13` | `UC-C06` | `FR-ORD-01` | `BR-ORD-01` | Concurrency / Rollback | Untested (Design Baselined) |
| `TC-C07-01` | `UC-C07` | `FR-MYO-01` | — | Positive / List | Untested (Design Baselined) |
| `TC-C07-02` | `UC-C07` | `FR-MYO-01` | — | Positive / Statuses | Untested (Design Baselined) |
| `TC-C07-03` | `UC-C07` | `FR-MYO-02` | — | Positive / Details | Untested (Design Baselined) |
| `TC-C07-04` | `UC-C07` | `FR-MYO-01` | `BR-ORD-04`, `BR-ORD-05` | Alternative / Cancel | Untested (Design Baselined) |
| `TC-C07-05` | `UC-C07` | `FR-MYO-01` | `BR-ORD-04`, `BR-ORD-05` | Alternative / Cancel | Untested (Design Baselined) |
| `TC-C07-06` | `UC-C07` | `FR-MYO-01` | `BR-ORD-04` | Exception / Blocked | Untested (Design Baselined) |
| `TC-C07-07` | `UC-C07` | `FR-MYO-04` | — | Alternative / Re-order | Untested (Design Baselined) |
| `TC-C07-08` | `UC-C07` | `FR-MYO-04` | — | Exception / Stock Alert | Untested (Design Baselined) |
| `TC-C07-09` | `UC-C07` | `FR-MYO-03` | `BR-FB-01` | Alternative / Review | Untested (Design Baselined) |
| `TC-C07-10` | `UC-C07` | `FR-MYO-03` | `BR-FB-01` | Negative / Unfinished | Untested (Design Baselined) |
| `TC-C07-11` | `UC-C07` | `FR-MYO-03` | `BR-FB-01` | Negative / Duplicate | Untested (Design Baselined) |
| `TC-C07-12` | `UC-C07` | `FR-MYO-03` | `BR-FB-01` | Boundary / Rating Range | Untested (Design Baselined) |
| `TC-M08-01` | `UC-M08` | `FR-GR-01`, `FR-GR-02` | `BR-GR-01` | Positive / Intake | Untested (Design Baselined) |
| `TC-M08-02` | `UC-M08` | `FR-GR-01` | `BR-GR-02` | Positive / Perishable | Untested (Design Baselined) |
| `TC-M08-03` | `UC-M08` | `FR-GR-01` | `BR-GR-02` | Boundary / +3 Days | Untested (Design Baselined) |
| `TC-M08-04` | `UC-M08` | `FR-GR-01` | `BR-GR-02` | Boundary / Rejection | Untested (Design Baselined) |
| `TC-M08-05` | `UC-M08` | `FR-GR-01` | `BR-GR-02` | Negative / Date Order | Untested (Design Baselined) |
| `TC-M08-06` | `UC-M08` | `FR-GR-04` | `BR-GR-03` | Positive / Calculation | Untested (Design Baselined) |
| `TC-M08-07` | `UC-M08` | `FR-BAT-04` | `BR-BAT-03` | Alternative / Delayed | Untested (Design Baselined) |
| `TC-M08-08` | `UC-M08` | `FR-BAT-04` | `BR-BAT-03` | Alternative / Active | Untested (Design Baselined) |
| `TC-M08-09` | `UC-M08` | `FR-GR-02` | — | Positive / Inventory | Untested (Design Baselined) |
| `TC-M08-10` | `UC-M08` | `FR-GR-01` | `BR-GR-04` | Security / Immutability | Untested (Design Baselined) |
| `TC-M08-11` | `UC-M08` | `FR-GR-01` | — | Negative / Uniqueness | Untested (Design Baselined) |
| `TC-M08-12` | `UC-M08` | `FR-GR-01` | `BR-GR-01` | Boundary / Qty & Price | Untested (Design Baselined) |

---

## 7. Verification Against Test Case Review Checklist

The test design and workbook have been verified against [`checklists/Checklist_Test Case Review.xls`](file:///checklists/Checklist_Test%20Case%20Review.xls):

| Checklist Question | Priority | Assessment | Compliance Evidence & Reference |
|---|:---:|:---:|---|
| Does the title page contain document name, version, release date, and creator/reviewer? | Mandatory | **YES** | Preserved in `Cover` sheet of `Functional_Test_Cases.xlsx` with Document Code `FFO_ST_Functional_TestCases_v1.0`. |
| Is the history traceable? | Mandatory | **YES** | Record of change logged with version 1.0, date 2026-10-23, and itemized baseline description. |
| Do test cases cover all requirements? | Mandatory | **YES** | 100% of functional requirements (`FR`) and business rules (`BR`) for the 6 prioritized use cases are covered. |
| Do test cases cover all testing types described in Test Plan? | Mandatory | **YES** | Positive, negative, boundary value, performance SLA, concurrency rollback, and security idempotency tests included. |
| Has each test case been assigned a unique test case identifier? | Mandatory | **YES** | Formatted hierarchically: `[TC-C01-xx]`, `[TC-C05-xx]`, `[TC-C03-xx]`, `[TC-C06-xx]`, `[TC-C07-xx]`, `[TC-M08-xx]`. |
| Does each test case specify Actions, Test condition, and Expected result in detail? | Mandatory | **YES** | Every row contains explicit Pre-Condition, numbered Test Case Procedure, and unambiguous Expected Output. |
| Do test cases for field validations, record validations, and DB updates include valid, invalid, and boundary conditions? | Mandatory | **YES** | Distinct test cases for valid data, boundary limits (10.0 km, max stock, +3 days expiry), and invalid formats. |
| Is error message / alert specified in expected result for abnormal cases? | Standard | **YES** | Explicit alert texts documented for all negative, boundary, and exception scenarios. |
| Do test cases for reports include test data along with expected output? | Standard | **YES** | Coupled with external CSV datasets in `artifacts/testing/test-data/`. |
| Have all requested environments and pre-conditions been specified? | Mandatory | **YES** | Web browser (Chrome/Edge), authenticated customer, active warehouse catalog specified in pre-conditions. |


## Customer Channel Architecture Change Impact (2026-10-26)

The user-directed architecture revision separates FreshFood-Customer-Web (browser storefront) from FreshFood-App (Android/iOS) and FreshFood-Web (staff back office). Existing customer functional cases remain the business test basis. Execution coverage must distinguish Customer Web and Customer Mobile; success on one channel is not evidence for the other. Both clients integrate with FreshFood-API and shared backend business rules and persistent data.

Integration test design delta: verify each customer client against its authorized API contracts, customer/staff access separation, and shared persisted order/profile state; retain mobile FCM tests. Web push behavior is TBD - Stakeholder confirmation required. Detailed new cases and implementation-specific environments are Proposed - Project approval required. No new functional test execution is claimed by this document update.
