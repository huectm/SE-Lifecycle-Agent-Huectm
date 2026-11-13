# FreshFood System — Master Business Rules Specification

**Project:** FreshFood — E-Commerce Organic Food System  
**Document Version:** 1.0 (Baselined)  
**Status:** Approved & Traceable  
**Governing Standard:** Karl Wiegers & Joy Beatty (*Software Requirements*, 3rd Edition — Chapter 9: Business Rules)  
**Language Policy:** English Specification Identifiers with Bilingual Vietnamese Subtitles  

---

## 1. Overview & Classification Schema

Business Rules (Quy tắc nghiệp vụ) định nghĩa các chính sách, ràng buộc, thuật toán tính toán và điều kiện kích hoạt hành động chi phối toàn bộ hoạt động của hệ thống FreshFood. Các quy tắc này độc lập với việc triển khai phần mềm và là nguồn gốc (Source of Truth) cho các Yêu cầu chức năng (Functional Requirements), Mô hình hóa hoạt động (Activity Diagrams) và Thiết kế cơ sở dữ liệu.

Theo chuẩn Karl Wiegers, các quy tắc nghiệp vụ của FreshFood được phân loại thành 5 nhóm:
1. **Facts (Định nghĩa sự thật):** Các định nghĩa thuật ngữ, cấu trúc cốt lõi của miền nghiệp vụ.
2. **Constraints (Ràng buộc):** Các hạn chế hành vi, điều kiện kiểm tra hợp lệ và điều kiện tiên quyết bắt buộc.
3. **Action Enablers (Kích hoạt hành động):** Điều kiện "Nếu... thì..." để kích hoạt một thao tác hoặc chuyển đổi trạng thái.
4. **Inferences (Quy tắc suy luận):** Kết luận mới được hệ thống tự động suy ra từ các sự kiện đã biết.
5. **Computations (Quy tắc tính toán):** Các công thức toán học, thuật toán tính tiền, tỷ lệ chiết khấu, hạn mức.

---

## 2. Master Business Rules Catalog

### 2.1 Nhóm Quản lý Danh mục, Sản phẩm & Nhà cung cấp (Catalog & Supplier Domain)

| Mã Rule | Tên Quy tắc (English / Tiếng Việt) | Loại (Type) | Mô tả chi tiết (Rule Description) | Mức cưỡng chế | Nguồn truy vết |
|:---:|---|:---:|---|:---:|:---:|
| **BR-CAT-01** | Category Deletion Dependency<br>*(Ràng buộc xóa danh mục loại SP)* | Constraint | Một loại sản phẩm chỉ được phép xóa khi **không còn bất kỳ sản phẩm nào** trực thuộc loại đó trong hệ thống. Nếu còn sản phẩm, hệ thống phải chặn thao tác xóa và hiển thị cảnh báo. | Strict (Hệ thống) | P1 &rarr; `UC-M05.4` |
| **BR-CAT-02** | Product SKU & Name Uniqueness<br>*(Định danh duy nhất sản phẩm)* | Constraint | Mỗi sản phẩm phải có mã định danh (SKU) duy nhất trên toàn hệ thống và tên sản phẩm không được trùng lặp trong cùng một danh mục loại sản phẩm. | Strict (Hệ thống) | P2 &rarr; `UC-M06.2` |
| **BR-SUP-01** | Supplier Business Association<br>*(Quan hệ cung ứng đa chiều)* | Fact | Mỗi nhà cung cấp có thể cung ứng nhiều sản phẩm khác nhau; và một sản phẩm có thể được cung ứng bởi nhiều nhà cung cấp khác nhau qua các đợt nhập hàng. | Fact (Miền nghiệp vụ) | P3 &rarr; `UC-M07` |
| **BR-SUP-02** | Supplier Deletion Constraint<br>*(Ràng buộc xóa nhà cung cấp)* | Constraint | Không được phép xóa nhà cung cấp nếu nhà cung cấp đó đã có ít nhất một Phiếu nhập kho trong lịch sử (để đảm bảo tính toàn vẹn kiểm toán dữ liệu kế toán và nguồn gốc thực phẩm). Chỉ cho phép chuyển trạng thái sang "Ngừng hợp tác" (Inactive). | Strict (Hệ thống) | P3 &rarr; `UC-M07.4` |

---

### 2.2 Nhóm Nhập kho & Tồn kho theo Lô (Goods Receipt & Batch Inventory Domain)

| Mã Rule | Tên Quy tắc (English / Tiếng Việt) | Loại (Type) | Mô tả chi tiết (Rule Description) | Mức cưỡng chế | Nguồn truy vết |
|:---:|---|:---:|---|:---:|:---:|
| **BR-GR-01** | Mandatory Batch Attributes<br>*(Thuộc tính bắt buộc của dòng nhập hàng)* | Constraint | Mỗi dòng mặt hàng trong Phiếu nhập kho bắt buộc phải có đầy đủ: **Số lô (Batch No)**, **Ngày sản xuất (MFG)**, **Hạn sử dụng (EXP)**, **Số lượng nhập (> 0)**, và **Đơn giá nhập (> 0)**. | Strict (Hệ thống) | P4 &rarr; `UC-M08.2`<br>BP-01 |
| **BR-GR-02** | Expiry Date Validity Constraint<br>*(Ràng buộc hợp lệ hạn sử dụng)* | Constraint | Hạn sử dụng (EXP) bắt buộc phải lớn hơn Ngày sản xuất (MFG): `EXP > MFG`. Đối với thực phẩm tươi sống nhập kho, HSD bắt buộc phải lớn hơn ngày nhập kho thực tế ít nhất **3 ngày** (`EXP >= Goods Receipt Date + 3`). | Strict (Hệ thống) | P4, P5 &rarr; `UC-M08.2`<br>BP-01 |
| **BR-GR-03** | Goods Receipt Total Computation<br>*(Công thức tính tổng tiền phiếu nhập)* | Computation | - **Thành tiền dòng** = `Số lượng nhập × Đơn giá nhập`.<br>- **Tổng tiền phiếu nhập** = `∑(Thành tiền dòng)`.<br>Hệ thống tự động tính toán, không cho phép chỉnh sửa thủ công trường tổng tiền. | Strict (Hệ thống) | P4 &rarr; `UC-M08.2`<br>BP-01 |
| **BR-GR-04** | Goods Receipt Immutability<br>*(Tính bất biến của phiếu nhập kho)* | Constraint | Phiếu nhập kho chỉ được phép chỉnh sửa hoặc hủy/xóa khi **chưa có bất kỳ sản phẩm nào thuộc các lô trong phiếu bị xuất bán, đặt giữ chỗ hoặc tiêu hủy**. Khi đã phát sinh giao dịch xuất, phiếu nhập bị khóa vĩnh viễn. | Strict (Hệ thống) | P4 &rarr; `UC-M08.3`, `UC-M08.4` |
| **BR-BAT-01** | Batch-Specific Retail Pricing<br>*(Định giá bán lẻ độc lập theo lô)* | Fact / Rule | Giá bán lẻ được cấu hình độc lập theo từng lô hàng (`Price by Batch`). Cùng một sản phẩm nhưng các lô nhập khác nhau có thể có giá bán khác nhau tùy thuộc vào giá vốn và thời hạn bảo quản. | Strict (Hệ thống) | P5 &rarr; `UC-M09.2`<br>BP-01 |
| **BR-BAT-02** | FEFO / FIFO Sales Priority<br>*(Nguyên tắc ưu tiên xuất bán theo hạn dùng)* | Action Enabler | Hệ thống ưu tiên xuất bán theo nguyên tắc cận hạn trước (First-Expired, First-Out). Các lô hàng có HSD gần hơn phải được ưu tiên gán đơn và xuất kho trước các lô mới nhập. | Strict (Hệ thống) | P5 &rarr; `UC-M09`<br>BP-01, BP-03 |
| **BR-BAT-03** | Delayed Selling for New Batches<br>*(Chính sách hoãn bán lô hàng mới)* | Action Enabler | Khi nhập lô mới mà trong kho vẫn còn lô cũ cùng mặt hàng còn hạn sử dụng, hệ thống mặc định đưa lô mới vào trạng thái "Hoãn bán" (Delayed/Hold). Lô mới chỉ được mở bán khi lô cũ đã bán hết hoặc khi Nhân viên kho chủ động kích hoạt mở bán song song. | Action Enabler (WH Staff) | P5 &rarr; `UC-M09.4`<br>BP-01 |
| **BR-BAT-04** | Clearance Discount for Old Batches<br>*(Chính sách giảm giá đẩy hàng lô cũ)* | Action Enabler | Đối với các lô hàng cũ có thời hạn sử dụng còn lại dưới ngưỡng quy định (ví dụ: còn ≤ 2 ngày đối với rau củ, ≤ 1 ngày đối với thịt/thủy sản tươi), Nhân viên kho có quyền áp dụng tỷ lệ chiết khấu giảm giá (Discount Rate từ 10% đến 50%) để kích cầu tiêu thụ nhanh. | Action Enabler (WH Staff) | P5 &rarr; `UC-M09.3`<br>BP-01 |

---

### 2.3 Nhóm Khách hàng & Xác thực Tài khoản (Customer Authentication Domain)

| Mã Rule | Tên Quy tắc (English / Tiếng Việt) | Loại (Type) | Mô tả chi tiết (Rule Description) | Mức cưỡng chế | Nguồn truy vết |
|:---:|---|:---:|---|:---:|:---:|
| **BR-AUTH-01** | Mandatory Checkout Authentication<br>*(Bắt buộc đăng nhập khi đặt hàng)* | Constraint | Khách vãng lai (Guest) được phép duyệt sản phẩm, đọc bài viết và thêm vào giỏ hàng. Tuy nhiên, hành động **Tiến hành Đặt hàng (Checkout)** bắt buộc phải đăng nhập thông qua Google OAuth 2.0 hoặc Facebook Login. | Strict (Hệ thống) | P6, P7 &rarr; `UC-C04`<br>BP-02 |
| **BR-AUTH-02** | First-Time Profile & Phone Verification<br>*(Bổ sung thông tin & xác thực SĐT lần đầu)* | Constraint | Khách hàng đăng nhập lần đầu tiên bắt buộc phải cung cấp: **Họ và tên**, **Số điện thoại**, **Email**, và **Địa chỉ nhận hàng**. Số điện thoại phải được xác thực thành công qua mã OTP 6 số gửi qua tin nhắn SMS trước khi được phép đặt đơn. | Strict (Hệ thống) | P7 &rarr; `UC-C04.3`, `UC-C04.4`<br>BP-02 |
| **BR-AUTH-03** | Most Recent Address Defaulting<br>*(Mặc định địa chỉ giao hàng gần nhất)* | Inference | Khách hàng có thể lưu trữ nhiều địa chỉ giao hàng trong sổ địa chỉ. Hệ thống tự động suy luận và chọn địa chỉ được sử dụng trong đơn hàng thành công gần nhất làm địa chỉ giao hàng mặc định cho lần đặt tiếp theo. | Inference (Tự động) | P7 &rarr; `UC-C05.3`<br>BP-02 |

---

### 2.4 Nhóm Đặt hàng & Thanh toán Trực tuyến (Ordering & Payment Domain)

| Mã Rule | Tên Quy tắc (English / Tiếng Việt) | Loại (Type) | Mô tả chi tiết (Rule Description) | Mức cưỡng chế | Nguồn truy vết |
|:---:|---|:---:|---|:---:|:---:|
| **BR-ORD-01** | Real-time Inventory Reservation<br>*(Khóa giữ tồn kho theo lô tức thời)* | Action Enabler | Only accept an order when every requested line has sufficient sellable on-hand stock less existing reservations. Reserve FEFO batches atomically with order creation; do not accept backorders. | Strict (Hệ thống) | P7 &rarr; `UC-C06`<br>BP-02 |
| **BR-DEL-01** | Delivery Radius & Order Acceptance Constraint<br>*(Ràng buộc bán kính & từ chối đơn theo khoảng cách)* | Constraint | - Hệ thống **chỉ chấp nhận đơn hàng** có khoảng cách giao hàng từ cửa hàng đến địa chỉ nhận $d \le \text{MaxDeliveryDistance}$ (mặc định $\text{MaxDeliveryDistance} = 10\text{ km}$, tham số này có thể cấu hình được bởi Quản trị viên).<br>- Nếu khoảng cách $d > \text{MaxDeliveryDistance}$ (> 10 km): Hệ thống **tự động từ chối đặt hàng** và thông báo cho khách hàng: *"Địa chỉ giao hàng nằm ngoài phạm vi phục vụ của FreshFood"*. | Strict (Hệ thống) | P13 &rarr; `UC-C06`<br>Stakeholder Rule |
| **BR-DEL-02** | Tiered Shipping Fee Computation<br>*(Bảng biểu tính phí giao hàng theo bậc thang khoảng cách)* | Computation | Phí giao hàng (`Shipping Fee`) được tính tự động dựa trên khoảng cách địa lý ($d$) từ cửa hàng đến địa chỉ nhận của khách hàng:<br>1. **Dưới 1 km ($d < 1\text{ km}$):** Phí giao hàng = **10.000 VNĐ** (10k/đơn).<br>2. **Từ 1 km đến dưới 3 km ($1\text{ km} \le d < 3\text{ km}$):** Phí giao hàng = **20.000 VNĐ** (20k/đơn).<br>3. **Từ 3 km đến 10 km ($3\text{ km} \le d \le 10\text{ km}$):** Phí giao hàng = **30.000 VNĐ** (30k/đơn).<br>*(Khoảng cách được xác định qua dịch vụ bản đồ/tọa độ số địa chỉ)*. | Strict (Hệ thống) | P13 &rarr; `UC-C06`<br>Stakeholder Rule |
| **BR-ORD-02** | Order Total Price Computation<br>*(Công thức tính tổng tiền đơn hàng)* | Computation | - **Thành tiền món** = `Số lượng × Đơn giá lô`.<br>- **Tiền giảm giá món** = `Thành tiền món × Tỷ lệ chiết khấu lô` (nếu có).<br>- **Phí vận chuyển** = Áp dụng công thức bậc thang khoảng cách tại **BR-DEL-02**.<br>- **Tổng tiền đơn hàng** = `∑(Thành tiền món - Tiền giảm giá món) + Phí vận chuyển`. | Strict (Hệ thống) | P6, P7 &rarr; `UC-C06`<br>BP-02 |
| **BR-ORD-03** | VietQR Automated Payment Matching<br>*(Khớp thanh toán chuyển khoản VietQR)* | Action Enabler | VietQR Automated Payment Matching: A verified SePay notification matching the order identifier and transferred amount >= order total changes PaymentStatus to Paid. Payment confirmation does not replace the independent fulfillment OrderStatus. | Strict (Hệ thống) | P7 &rarr; `UC-C06.4`<br>BP-02 |
| **BR-ORD-04** | Order Cancellation Timeframe Constraint<br>*(Ràng buộc thời điểm hủy đơn hàng)* | Constraint | Order Cancellation Timeframe Constraint: Customers may cancel only Pending Unpaid, Pending Paid or Confirmed orders. Customer cancellation is blocked once Packing or Shipping begins. Other states do not grant customer cancellation eligibility. | Strict (Hệ thống) | P8 &rarr; `UC-C07.3`<br>BP-04 |
| **BR-ORD-05** | Order Cancellation Restocking<br>*(Tự động hoàn trả tồn kho khi hủy đơn)* | Action Enabler | Khi đơn hàng bị hủy hợp lệ (bởi khách hàng hoặc do hệ thống hủy), hệ thống phải **ngay lập tức giải phóng số lượng giữ chỗ và hoàn trả chính xác về các lô hàng ban đầu**. | Strict (Hệ thống) | P8 &rarr; `UC-C07.3`<br>BP-04 |

---

### 2.5 Nhóm Tiếp nhận, Xử lý & Giao hàng (Order Fulfillment & Delivery Domain)

| Mã Rule | Tên Quy tắc (English / Tiếng Việt) | Loại (Type) | Mô tả chi tiết (Rule Description) | Mức cưỡng chế | Nguồn truy vết |
|:---:|---|:---:|---|:---:|:---:|
| **BR-FUL-01** | First-Order Mandatory Telephone Verification<br>*(Bắt buộc gọi điện xác nhận đơn đầu)* | Constraint | Telephone confirmation is mandatory only for a first order whose goods payment is Unpaid. Store staff must obtain customer confirmation before approving that order; if confirmation cannot be obtained, staff may decide to cancel and release reservations. No automatic cancellation deadline or retry count is defined. | Manual + System Audit | P9 &rarr; `UC-M01.3`<br>BP-03 |
| **BR-FUL-02** | Mandatory Documentation Printing<br>*(Bắt buộc in chứng từ trước khi bàn giao)* | Constraint | Mỗi đơn hàng được xác nhận bắt buộc phải in ra **Hóa đơn bán hàng** (Invoice) và **Phiếu đóng gói** (Packing Slip) từ máy in để dán lên kiện hàng thực phẩm trước khi bàn giao cho nhân viên giao hàng (Shipper). | Strict (Vận hành) | P9 &rarr; `UC-M02`<br>BP-03 |
| **BR-FUL-03** | Delivery Completion Stock & Revenue Finalization<br>*(Ghi nhận doanh thu & trừ dứt điểm tồn kho)* | Action Enabler | Khi đơn hàng được xác nhận giao thành công (`Delivered`):<br>1. Ghi nhận doanh thu chính thức cho hệ thống.<br>2. Chuyển số lượng từ trạng thái "Khóa giữ chỗ" (Reserved) sang "Đã xuất kho thực tế" (Deducted). | Strict (Hệ thống) | P9 &rarr; `UC-M03.2`<br>BP-03 |
| **BR-FUL-04** | Failed Delivery Restocking Policy<br>*(Xử lý hoàn kho khi giao hàng thất bại)* | Action Enabler | Record Delivery Failed separately from warehouse receipt. Warehouse Staff confirm all returned goods before Returned and the full-return refund path. Staff inspect goods and decide inventory disposition; the system records their decision. Inspection must not delay an otherwise eligible refund. Goods do not automatically become sellable on receipt. | Manual + System | P9 &rarr; `UC-M03.3`<br>BP-03 |
| **BR-FUL-05** | Failed Delivery Fee / Refund Policy | Constraint | For customer refusal due to product fault, the customer bears no delivery fee: refund captured goods and shipping amounts, or collect neither when unpaid. For confirmed deliberate refusal unrelated to product fault, refund captured goods only and retain the captured delivery fee for delivery-agent compensation; if goods were unpaid, the customer owes the delivery fee directly to the delivery agent. Record actual collection and compensation separately. Do not classify an unreachable customer as deliberate refusal automatically. | System with confirmed cause | Stakeholder 2026-10-29; BP-03 |
| **BR-FUL-06** | Failed Delivery Fee / Refund Policy | Constraint | Automatic refund requires verified goods payment, confirmed complete physical return and a confirmed failure-cause category determining fee liability. Do not wait for warehouse quality inspection. Refund actual original collected allocations, not current prices. Provider request acceptance is not proof of completed refund. Unclassified/other causes remain unresolved; final cause-decision authority and payout integration are TBD. | System with confirmed cause | Stakeholder 2026-10-29; BP-03 |

---

### 2.6 Nhóm Hậu mãi, Đánh giá & Mua lại (Post-Purchase & Feedback Domain)

| Mã Rule | Tên Quy tắc (English / Tiếng Việt) | Loại (Type) | Mô tả chi tiết (Rule Description) | Mức cưỡng chế | Nguồn truy vết |
|:---:|---|:---:|---|:---:|:---:|
| **BR-FB-01** | Verified Purchase Review Constraint<br>*(Chỉ đánh giá khi đã nhận hàng thành công)* | Constraint | Khách hàng chỉ được phép gửi Đánh giá sao (1 - 5 sao) và Phản hồi nhận xét chất lượng thực phẩm đối với các đơn hàng đã ở trạng thái **Giao thành công (`Delivered`)**. Các đơn chưa giao hoặc đã hủy không thể đánh giá. | Strict (Hệ thống) | P8 &rarr; `UC-C07.4`<br>BP-04 |
| **BR-RE-01** | Re-order Real-time Availability Mapping<br>*(Tự động ánh xạ tồn kho khi đặt lại đơn cũ)* | Inference | Khi khách hàng chọn "Đặt lại đơn hàng cũ" (`Re-order`), hệ thống lấy lại danh mục sản phẩm từ đơn cũ và nạp vào Giỏ hàng hiện tại với **đơn giá và số lượng khả dụng của các Lô hàng đang mở bán tại thời điểm hiện tại**. Nếu có sản phẩm đã hết hàng, hệ thống phải thông báo rõ ràng cho khách. | Inference (Tự động) | P8 &rarr; `UC-C07.5`<br>BP-04 |

---

### 2.7 Nhóm Kiểm soát Hạn sử dụng & Tiêu hủy (Expiry Control & Disposal Domain)

| Mã Rule | Tên Quy tắc (English / Tiếng Việt) | Loại (Type) | Mô tả chi tiết (Rule Description) | Mức cưỡng chế | Nguồn truy vết |
|:---:|---|:---:|---|:---:|:---:|
| **BR-EXP-01** | Automated Delisting Upon Expiry<br>*(Tự động ngừng bán khi chạm hạn dùng)* | Action Enabler | Khi ngày hệ thống hiện tại chạm hoặc vượt quá Hạn sử dụng của lô hàng (`Current Date >= EXP`), hệ thống **tự động gỡ bỏ lô hàng đó khỏi danh sách hiển thị bán hàng** trên website ngay lập tức mà không cần nhân viên thao tác thủ công. | Strict (Hệ thống) | P5, P11 &rarr; `UC-M09`<br>BP-05 |
| **BR-EXP-02** | Zero Tolerance for Expired Food Sale<br>*(Tuyệt đối cấm bán thực phẩm quá hạn)* | Constraint | Thực phẩm thuộc lô đã quá hạn sử dụng bị nghiêm cấm hoàn toàn mọi hành vi xuất bán. Lô hàng bắt buộc phải được lập "Phiếu tiêu hủy hàng hết hạn" (`Dispose Expired Stock`) và ghi nhận vào chi phí hao hụt hàng hỏng của cửa hàng. | Strict (Chính sách) | P11 &rarr; `UC-M10`<br>BP-05 |

---

### 2.8 Nhóm Quản trị Nhân sự & Phân quyền Truy cập (Security & RBAC Domain)

| Mã Rule | Tên Quy tắc (English / Tiếng Việt) | Loại (Type) | Mô tả chi tiết (Rule Description) | Mức cưỡng chế | Nguồn truy vết |
|:---:|---|:---:|---|:---:|:---:|
| **BR-SEC-01** | Mandatory Internal Staff Authentication<br>*(Bắt buộc đăng nhập hệ thống nội bộ)* | Constraint | Tất cả nhân viên (Sale Staff, WH Staff, Store Owner) bắt buộc phải đăng nhập vào hệ thống quản trị thông qua tài khoản nội bộ được cấp phát riêng biệt. | Strict (Hệ thống) | P12 &rarr; `UC-M12.1`<br>BP-07 |
| **BR-SEC-02** | Role-Based Access Control (RBAC) Hierarchy<br>*(Phân cấp quyền hạn theo vai trò)* | Constraint | Phân quyền truy cập tuân thủ ma trận chức năng nghiêm ngặt:<br>- **Sale Staff:** Tiếp nhận, xử lý, in ấn chứng từ đơn hàng, điều phối giao hàng, biên tập bài viết.<br>- **WH Staff:** Danh mục, sản phẩm, nhà cung cấp, phiếu nhập kho, quản lý lô hàng, tiêu hủy hàng hỏng, báo cáo kho.<br>- **Store Owner:** Kế thừa toàn bộ quyền hạn của Sale Staff và WH Staff; độc quyền quản lý tài khoản nhân viên (tạo mới, thu hồi quyền). | Strict (Hệ thống) | P12 &rarr; `UC-M13`<br>Actor Hierarchy |
| **BR-SEC-03** | Immediate Access Revocation Invariant<br>*(Thu hồi quyền hạn tức thì khi nghỉ việc)* | Action Enabler | Khi Store Owner thực hiện thao tác "Thu hồi quyền truy cập" (`Revoke Staff Access`), hệ thống phải **ngay lập tức hủy phiên làm việc hiện tại (Invalidate JWT/Session tokens)** và chặn mọi yêu cầu truy cập tiếp theo của tài khoản đó. | Strict (Hệ thống) | P12 &rarr; `UC-M13.3`<br>BP-07 |
| **BR-SEC-04** | Mandatory Staff Database Mutation Audit Logging<br>*(Bắt buộc ghi vết kiểm toán mọi thao tác chỉnh sửa dữ liệu của nhân viên)* | Constraint | Mọi thao tác làm thay đổi cơ sở dữ liệu (tạo mới `INSERT`, cập nhật `UPDATE`, hủy/xóa `DELETE`) do nhân viên thực hiện (WarehouseStaff, SaleStaff, StoreOwner) bắt buộc phải được hệ thống tự động ghi nhật ký kiểm toán (Audit Log) không thể chỉnh sửa, bao gồm: Mã định danh nhân viên thao tác, loại thao tác, tên thực thể dữ liệu bị thay đổi, mã bản ghi, giá trị cũ (nếu có), giá trị mới (nếu có), địa chỉ IP và thời điểm thực hiện (Timestamp). | Strict (Hệ thống / Audit) | User Requirement &rarr; `UC-M12`<br>Security Invariant |

---

## 3. Ma Trận Tóm Tắt & Phân Bổ Quy Tắc Nghiệp Vụ

| Nhóm nghiệp vụ (Domain) | Số lượng Rule | Constraint | Action Enabler | Computation | Fact / Inference | Mức độ ảnh hưởng hệ thống |
|---|:---:|:---:|:---:|:---:|:---:|:---:|
| **Catalog & Supplier** | 4 | 3 | 0 | 0 | 1 | Quản lý dữ liệu danh mục |
| **Goods Receipt & Batch Inventory** | 8 | 3 | 3 | 1 | 1 | Tồn kho theo lô, giá vốn & FIFO |
| **Customer Authentication** | 3 | 2 | 0 | 0 | 1 | Bảo mật & Xác thực OTP |
| **Ordering, Delivery & Payment** | 7 | 2 | 3 | 2 | 0 | Bán kính ship, Bậc thang ship, VietQR, Hủy |
| **Order Fulfillment & Delivery** | 4 | 2 | 2 | 0 | 0 | Gọi đơn đầu, In ấn, Giao hàng |
| **Post-Purchase & Feedback** | 2 | 1 | 0 | 0 | 1 | Đánh giá & Đặt lại đơn cũ |
| **Expiry Control & Disposal** | 2 | 1 | 1 | 0 | 0 | An toàn thực phẩm & Tiêu hủy |
| **Security & Access Control** | 4 | 3 | 1 | 0 | 0 | Phân quyền RBAC, Thu hồi quyền & Ghi vết kiểm toán |
| **TỔNG CỘNG** | **34** | **17** | **10** | **3** | **4** | **Bao phủ 100% nghiệp vụ P1–P13 + Bảo mật Audit** |

