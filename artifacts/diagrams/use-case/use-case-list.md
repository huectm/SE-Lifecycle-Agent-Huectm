# FreshFood System — Master Use Case List & Traceability Matrix

**Project:** FreshFood — E-Commerce Organic Food System  
**Document Version:** 1.0 (Baselined)  
**Status:** Baselined & Approved by Stakeholder / Product Owner  
**Approval Date:** 2026-10-06  
**Language Policy:** English Specification Identifiers with Bilingual Vietnamese Subtitles  

---

## 1. Traceability Source Paragraphs (Căn cứ nghiệp vụ nguồn)

| Source ID | Tóm tắt nội dung nghiệp vụ nguồn (`references/User requierement.docx`) |
|:---:|---|
| **P1** | Nhân viên kho (WH Staff) tạo mới, cập nhật, xóa **danh mục loại sản phẩm**. |
| **P2** | Nhân viên kho tạo mới, sửa, xóa **sản phẩm** (mỗi loại sản phẩm có nhiều sản phẩm). |
| **P3** | Nhân viên kho tạo mới, sửa, xóa **nhà cung cấp** (mỗi nhà cung cấp cung cấp nhiều sản phẩm). |
| **P4** | Nhân viên kho lập **phiếu nhập kho** (chọn NCC, nhập danh sách hàng, lô, NSX, HSD, giá nhập, tổng tiền); sửa/xóa phiếu nhập kho theo quy định. |
| **P5** | Quản lý tồn kho **theo từng lô nhập**; thiết lập giá bán **theo từng lô**; giảm giá lô hàng cũ; hoãn bán lô hàng mới; nhân viên kho áp dụng giảm giá. |
| **P6** | Khách hàng duyệt sản phẩm (theo nhóm: mới, bán chạy, khuyến mãi, danh mục), tìm kiếm theo tên, xem chi tiết, thêm giỏ hàng, đọc bài viết chia sẻ. |
| **P7** | Đặt hàng yêu cầu đăng nhập (Google / Facebook); lần đầu đăng nhập nhập Họ tên, SĐT, Email, Địa chỉ; xác thực SĐT; hỗ trợ nhiều địa chỉ (mặc định địa chỉ gần nhất); xem/sửa thông tin cá nhân. |
| **P8** | Khách hàng xem danh sách và chi tiết đơn hàng; hủy đơn hàng chưa giao; đơn hàng đã giao có thể đánh giá phản hồi và đặt hàng lại. |
| **P9** | Nhân viên bán hàng (Sale Staff) xem chi tiết đơn hàng; với đơn hàng đầu tiên: gọi điện xác nhận, in hóa đơn/phiếu đóng gói, đóng gói, điều phối giao hàng; cập nhật hoàn thành hoặc giao thất bại. |
| **P10** | Nhân viên tạo mới, sửa, xóa bài viết; ẩn bài viết cũ; hiển thị lại bài viết đã ẩn. |
| **P11** | Nhân viên kho lập thống kê (tồn kho, hàng hết hạn để hủy, doanh thu). |
| **P12** | Tất cả nhân viên phải đăng nhập; Chủ cửa hàng (Store Owner) có đầy đủ quyền hạn của nhân viên; tạo tài khoản nhân viên; thu hồi quyền khi nhân viên nghỉ việc. |
| **P13** | Mục tiêu kinh doanh: Đặt hàng thực phẩm sạch trực tuyến cho khách hàng trong khu vực lân cận. |

---

## 2. Master Table: General Use Cases (Bảng Use Case Tổng quát)

Toàn bộ các Use Case ở mức tổng quát xuất hiện trên biểu đồ Use Case tổng quát (`general-use-case-diagram.drawio`):

| STT | Mã Use Case | Tên Use Case (English / Tiếng Việt) | Tác nhân chính (Primary Actor) | Tác nhân hỗ trợ (Secondary Actor) | Phân hệ (Subsystem) | Nguồn (Source) | Trạng thái (Status) |
|:---:|:---:|---|---|---|---|:---:|:---:|
| 1 | **UC-C01** | Browse & Search Products<br>*(Tìm kiếm & Duyệt sản phẩm)* | Guest, Customer | — | Customer Storefront | P6 | SC |
| 2 | **UC-C02** | Read Articles & News<br>*(Đọc tin tức & bài viết)* | Guest, Customer | — | Customer Storefront | P6 | SC |
| 3 | **UC-C03** | Manage Shopping Cart<br>*(Quản lý giỏ hàng)* | Customer | — | Customer Storefront | P6 | SC / LD |
| 4 | **UC-C04** | Customer Authentication<br>*(Xác thực khách hàng)* | Customer | Google, Facebook, SMS Gateway | Customer Storefront | P7 | SC |
| 5 | **UC-C05** | Manage Profile & Addresses<br>*(Quản lý hồ sơ & sổ địa chỉ)* | Customer | — | Customer Storefront | P7 | SC |
| 6 | **UC-C06** | Checkout & Place Order<br>*(Đặt hàng & Thanh toán)* | Customer | SePay / Banking QR | Customer Storefront | P7 | SC / PR |
| 7 | **UC-C07** | Manage My Orders<br>*(Theo dõi & Quản lý đơn hàng)* | Customer | — | Customer Storefront | P8 | SC |
| 8 | **UC-M01** | Process Orders<br>*(Tiếp nhận & Xử lý đơn hàng)* | Sale Staff | — | Store Operations | P9 | SC |
| 9 | **UC-M02** | Print Invoices & Packing Slips<br>*(In hóa đơn & phiếu đóng gói)* | Sale Staff | Printer (Máy in) | Store Operations | P9 | SC |
| 10 | **UC-M03** | Dispatch & Deliver Orders<br>*(Điều phối & Cập nhật giao hàng)* | Sale Staff | — | Store Operations | P9 | SC |
| 11 | **UC-M04** | Publish Articles & News<br>*(Biên tập tin tức & bài viết)* | Sale Staff | — | Store Operations | P10 | SC |
| 12 | **UC-M05** | Manage Product Categories<br>*(Quản lý danh mục loại SP)* | WH Staff | — | Warehouse Management | P1 | SC |
| 13 | **UC-M06** | Manage Products<br>*(Quản lý thông tin sản phẩm)* | WH Staff | — | Warehouse Management | P2 | SC |
| 14 | **UC-M07** | Manage Suppliers<br>*(Quản lý nhà cung cấp)* | WH Staff | — | Warehouse Management | P3 | SC |
| 15 | **UC-M08** | Manage Goods Receipts<br>*(Quản lý phiếu nhập kho)* | WH Staff | — | Warehouse Management | P4 | SC |
| 16 | **UC-M09** | Manage Batch Inventory & Pricing<br>*(Quản lý tồn kho theo lô & giá bán)* | WH Staff | — | Warehouse Management | P5 | SC |
| 17 | **UC-M10** | Dispose Expired Stock<br>*(Xử lý & Lập phiếu hủy hàng hết hạn)* | WH Staff | — | Warehouse Management | P11 | LD |
| 18 | **UC-M11** | Generate Business Reports<br>*(Lập báo cáo & thống kê kho)* | WH Staff, Store Owner | — | Warehouse & Admin | P11 | SC |
| 19 | **UC-M12** | Staff Authentication<br>*(Đăng nhập nhân viên)* | Sale Staff, WH Staff, Store Owner | — | Common Subsystem | P12 | SC |
| 20 | **UC-M13** | Manage Staff Accounts<br>*(Quản lý tài khoản nhân viên)* | Store Owner | — | Store Administration | P12 | SC |

---

## 3. Detailed Tables: Decomposed Use Cases (Bảng Use Case Phân rã theo Tác nhân)

### 3.1 Nhân viên Quản lý Kho (Warehouse Staff)
*Bao gồm 18 Use Case nghiệp vụ hoàn chỉnh trong System Boundary phân hệ Kho hàng (đã loại bỏ các action vi mô: Select Category, Select Supplier, Enter Batch Details, Calculate Total).*

| STT | Mã Use Case | Tên Use Case (English / Tiếng Việt) | Loại quan hệ | Use Case cha / Điều kiện | Nguồn gốc | Bản chất nghiệp vụ |
|:---:|:---:|---|:---:|---|:---:|---|
| 1 | **UC-M05.1** | View Category List<br>*(Xem danh sách loại SP)* | `<<include>>` | Base: `UC-M05` | P1 (LD) | Tải dữ liệu danh mục khi vào màn hình quản lý. |
| 2 | **UC-M05.2** | Add Product Category<br>*(Thêm loại SP mới)* | `<<extend>>` | Base: `UC-M05` `[Add]` | P1 (SC) | Nhập tên, mô tả và lưu loại sản phẩm mới. |
| 3 | **UC-M05.3** | Update Category<br>*(Cập nhật thông tin loại SP)* | `<<extend>>` | Base: `UC-M05` `[Edit]` | P1 (SC) | Chỉnh sửa tên, thông tin hiển thị của danh mục. |
| 4 | **UC-M05.4** | Delete Category<br>*(Xóa loại sản phẩm)* | `<<extend>>` | Base: `UC-M05` `[Delete]` | P1 (SC) | Xóa danh mục khi không còn sản phẩm trực thuộc. |
| 5 | **UC-M06.1** | View Product List<br>*(Xem danh sách sản phẩm)* | `<<include>>` | Base: `UC-M06` | P2 (LD) | Tải danh sách sản phẩm theo bộ lọc/tìm kiếm. |
| 6 | **UC-M06.2** | Add Product<br>*(Thêm sản phẩm mới)* | `<<extend>>` | Base: `UC-M06` `[Add]` | P2 (SC) | Nhập tên SP, đơn vị tính, chọn danh mục, mô tả. |
| 7 | **UC-M06.3** | Update Product<br>*(Cập nhật thông tin SP)* | `<<extend>>` | Base: `UC-M06` `[Edit]` | P2 (SC) | Cập nhật hình ảnh, mô tả, thông số sản phẩm. |
| 8 | **UC-M06.4** | Delete Product<br>*(Xóa sản phẩm)* | `<<extend>>` | Base: `UC-M06` `[Delete]` | P2 (SC) | Xóa/ngừng kinh doanh sản phẩm. |
| 9 | **UC-M07.1** | View Supplier List<br>*(Xem danh sách NCC)* | `<<include>>` | Base: `UC-M07` | P3 (LD) | Tải danh sách nhà cung cấp hợp tác. |
| 10 | **UC-M07.2** | Add Supplier<br>*(Thêm nhà cung cấp)* | `<<extend>>` | Base: `UC-M07` `[Add]` | P3 (SC) | Lưu thông tin NCC, SĐT, địa chỉ, người liên hệ. |
| 11 | **UC-M07.3** | Update Supplier<br>*(Cập nhật nhà cung cấp)* | `<<extend>>` | Base: `UC-M07` `[Edit]` | P3 (SC) | Chỉnh sửa thông tin liên hệ nhà cung cấp. |
| 12 | **UC-M07.4** | Delete Supplier<br>*(Xóa nhà cung cấp)* | `<<extend>>` | Base: `UC-M07` `[Delete]` | P3 (SC) | Xóa NCC khi ngừng nhập hàng. |
| 13 | **UC-M08.1** | View Receipts List<br>*(Xem danh sách phiếu nhập)* | `<<include>>` | Base: `UC-M08` | P4 (LD) | Hiển thị lịch sử các hóa đơn/phiếu nhập kho. |
| 14 | **UC-M08.2** | Record Receipt<br>*(Lập phiếu nhập kho)* | `<<extend>>` | Base: `UC-M08` `[Create]` | P4 (SC) | Tạo phiếu nhập (chọn NCC, nhập lô, NSX, HSD, giá, tự tính tổng). |
| 15 | **UC-M08.3** | Update Receipt<br>*(Chỉnh sửa phiếu nhập kho)* | `<<extend>>` | Base: `UC-M08` `[Edit]` | P4 (SC) | Điều chỉnh số liệu phiếu nhập theo quy định. |
| 16 | **UC-M08.4** | Delete Receipt<br>*(Xóa/Hủy phiếu nhập kho)* | `<<extend>>` | Base: `UC-M08` `[Delete]` | P4 (SC) | Hủy phiếu nhập kho có sai sót trước khi duyệt. |
| 17 | **UC-M09.1** | View Stock by Batch<br>*(Xem tồn kho theo lô)* | `<<include>>` | Base: `UC-M09` | P5 (SC) | Theo dõi số lượng tồn, NSX, HSD của từng lô hàng. |
| 18 | **UC-M09.2** | Set Price by Batch<br>*(Thiết lập giá bán theo lô)* | `<<extend>>` | Base: `UC-M09` `[Price]` | P5 (SC) | Cấu hình giá bán cụ thể cho từng lô nhập. |
| 19 | **UC-M09.3** | Apply Batch Discount<br>*(Áp dụng giảm giá lô cũ)* | `<<extend>>` | Base: `UC-M09` `[Sale]` | P5 (SC) | Giảm giá đẩy hàng cho lô sắp hết hạn. |
| 20 | **UC-M09.4** | Delay Selling New Batches<br>*(Hoãn bán lô hàng mới)* | `<<extend>>` | Base: `UC-M09` `[Hold]` | P5 (SC) | Giữ lại lô mới để ưu tiên bán hết lô cũ (FIFO). |
| 21 | **UC-M10.1** | Identify Expired Products<br>*(Xác định danh sách hàng hết hạn)* | `<<include>>` | Base: `UC-M10` | P11 (LD) | Hệ thống lọc các lô quá hạn sử dụng cần tiêu hủy. |
| 22 | **UC-M10.2** | Deduct Stock Quantity<br>*(Trừ kho hàng tiêu hủy)* | `<<include>>` | Base: `UC-M10` | P11 (LD) | Xuất kho tiêu hủy, ghi giảm số lượng tồn kho. |
| 23 | **UC-M11.1** | Generate Revenue Report<br>*(Báo cáo doanh thu)* | `Generalization` | General: `UC-M11` | P11 (SC) | Tổng hợp doanh thu bán hàng theo mốc thời gian. |
| 24 | **UC-M11.2** | Generate Stock Report<br>*(Báo cáo tồn kho hiện tại)* | `Generalization` | General: `UC-M11` | P11 (SC) | Thống kê số lượng hàng tồn theo từng mặt hàng/lô. |
| 25 | **UC-M11.3** | Generate Expired Stock Report<br>*(Báo cáo hàng hết hạn)* | `Generalization` | General: `UC-M11` | P11 (SC) | Thống kê lượng hàng hỏng, hết hạn đã tiêu hủy. |
| 26 | **UC-M11.4** | Out-of-Stock Alert<br>*(Cảnh báo sắp hết hàng)* | `Generalization` | General: `UC-M11` | P11 (PR) | Tự động cảnh báo mặt hàng chạm ngưỡng tồn an toàn. |
| 27 | **UC-M11.5** | Export Excel/PDF<br>*(Xuất file báo cáo)* | `<<extend>>` | Base: `UC-M11` `[Export]` | P11 (PR) | Kết xuất dữ liệu báo cáo ra file Excel hoặc PDF. |

---

### 3.2 Nhân viên Bán hàng (Sale Staff)

| STT | Mã Use Case | Tên Use Case (English / Tiếng Việt) | Loại quan hệ | Use Case cha / Điều kiện | Nguồn gốc | Bản chất nghiệp vụ |
|:---:|:---:|---|:---:|---|:---:|---|
| 1 | **UC-M01.1** | View Order List<br>*(Xem danh sách đơn hàng)* | `<<include>>` | Base: `UC-M01` | P9 (LD) | Tải danh sách đơn hàng cần xử lý. |
| 2 | **UC-M01.2** | View Order Details<br>*(Xem chi tiết đơn hàng)* | `<<include>>` | Base: `UC-M01` | P9 (SC) | Xem thông tin khách hàng, địa chỉ, món hàng, tổng tiền. |
| 3 | **UC-M01.3** | Call Customer to Confirm Order<br>*(Gọi xác nhận đơn hàng)* | `<<extend>>` | Base: `UC-M01` `[First-time order]` | P9 (SC) | Gọi điện xác minh đối với khách đặt hàng lần đầu. |
| 4 | **UC-M02** | Print Invoices & Packing Slips<br>*(In hóa đơn & phiếu đóng gói)* | `<<extend>>` | Base: `UC-M01` `[Confirmed]` | P9 (SC) | Kích hoạt lệnh in khi đơn hàng đã được xác nhận. |
| 5 | **UC-M02.1** | Print Order Documents<br>*(In ấn chứng từ đơn hàng)* | `<<include>>` | Base: `UC-M02` &rarr; `Printer` | P9 (SC) | Xuất lệnh in ra thiết bị ngoại vi Printer. |
| 6 | **UC-M03.1** | View Orders to Deliver<br>*(Xem danh sách đơn cần giao)* | `<<include>>` | Base: `UC-M03` | P9 (LD) | Lọc danh sách đơn đã đóng gói sẵn sàng giao. |
| 7 | **UC-M03.2** | Confirm Delivery Completed<br>*(Xác nhận giao hàng thành công)* | `<<extend>>` | Base: `UC-M03` `[Delivered]` | P9 (SC) | Cập nhật trạng thái đơn hàng đã hoàn tất giao. |
| 8 | **UC-M03.3** | Report Unsuccessful Delivery<br>*(Báo cáo giao không thành công)* | `<<extend>>` | Base: `UC-M03` `[Failed]` | P9 (SC) | Ghi nhận lý do giao thất bại (khách không nghe máy...). |
| 9 | **UC-M04.1** | View Article List<br>*(Xem danh sách bài viết)* | `<<include>>` | Base: `UC-M04` | P10 (LD) | Xem các bài viết tin tức, cẩm nang nấu ăn. |
| 10 | **UC-M04.2** | Add Article<br>*(Đăng bài viết mới)* | `<<extend>>` | Base: `UC-M04` `[Add]` | P10 (SC) | Soạn thảo tiêu đề, nội dung, hình ảnh bài viết. |
| 11 | **UC-M04.3** | Update Article<br>*(Cập nhật bài viết)* | `<<extend>>` | Base: `UC-M04` `[Edit]` | P10 (SC) | Chỉnh sửa nội dung bài đã đăng. |
| 12 | **UC-M04.4** | Delete Article<br>*(Xóa bài viết)* | `<<extend>>` | Base: `UC-M04` `[Delete]` | P10 (SC) | Xóa vĩnh viễn bài viết khỏi hệ thống. |
| 13 | **UC-M04.5** | Hide Outdated Article<br>*(Ẩn bài viết cũ)* | `<<extend>>` | Base: `UC-M04` `[Hide]` | P10 (SC) | Tạm ẩn bài viết không còn phù hợp. |
| 14 | **UC-M04.6** | Re-display Hidden Article<br>*(Hiển thị lại bài viết đã ẩn)* | `<<extend>>` | Base: `UC-M04` `[Show]` | P10 (SC) | Mở hiển thị lại bài viết đã tạm ẩn trước đó. |

---

### 3.3 Chủ Cửa Hàng (Store Owner)
*Kế thừa toàn bộ quyền của Sale Staff và WH Staff qua Actor Generalization. Chỉ đặc tả các chức năng quản trị riêng biệt:*

| STT | Mã Use Case | Tên Use Case (English / Tiếng Việt) | Loại quan hệ | Use Case cha / Điều kiện | Nguồn gốc | Bản chất nghiệp vụ |
|:---:|:---:|---|:---:|---|:---:|---|
| 1 | **UC-M13.1** | View Staff Account List<br>*(Xem danh sách tài khoản NV)* | `<<include>>` | Base: `UC-M13` | P12 (LD) | Tải danh sách tài khoản nhân viên đang hoạt động. |
| 2 | **UC-M13.2** | Create Staff Account<br>*(Tạo tài khoản nhân viên)* | `<<extend>>` | Base: `UC-M13` `[Create]` | P12 (SC) | Cấp tài khoản mới cho nhân viên bán hàng/kho. |
| 3 | **UC-M13.3** | Revoke Staff Access<br>*(Thu hồi quyền / Khóa tài khoản)* | `<<extend>>` | Base: `UC-M13` `[Revoke]` | P12 (SC) | Khóa quyền truy cập khi nhân viên nghỉ việc. |
| 4 | **UC-M11** | Generate Business Reports<br>*(Xem báo cáo & thống kê doanh thu)* | `Association` | Direct to Owner | P11, P12 | Chủ cửa hàng giám sát toàn bộ số liệu tài chính, kho. |
| — | *(Inherited)* | *All operational UCs of Sale Staff & WH Staff* | `Actor Gen.` | `Store Owner` &rarr; `Sale/WH` | P12 | Kế thừa trực tiếp qua mô hình hóa vai trò UML. |

---

### 3.4 Khách Hàng & Khách Vãng Lai (Customer & Guest)

| STT | Mã Use Case | Tên Use Case (English / Tiếng Việt) | Loại quan hệ | Use Case cha / Điều kiện | Nguồn gốc | Bản chất nghiệp vụ |
|:---:|:---:|---|:---:|---|:---:|---|
| 1 | **UC-C01.1** | Search Products by Name<br>*(Tìm kiếm sản phẩm theo tên)* | `Generalization` | General: `UC-C01` | P6 (SC) | Tìm nhanh mặt hàng qua từ khóa. |
| 2 | **UC-C01.2** | Browse by Group / Category<br>*(Duyệt theo nhóm / danh mục)* | `Generalization` | General: `UC-C01` | P6 (SC) | Lọc sản phẩm mới, bán chạy, khuyến mãi, loại SP. |
| 3 | **UC-C01.3** | View Product Details<br>*(Xem chi tiết sản phẩm)* | `<<extend>>` | Base: `UC-C01` | P6 (SC) | Xem ảnh, mô tả, giá, chứng nhận thực phẩm sạch. |
| 4 | **UC-C02.1** | View Article List<br>*(Xem danh sách bài viết)* | `<<include>>` | Base: `UC-C02` | P6 (LD) | Xem danh mục các bài cẩm nang, tin tức. |
| 5 | **UC-C02.2** | View Article Details<br>*(Đọc chi tiết bài viết)* | `<<extend>>` | Base: `UC-C02` | P6 (LD) | Đọc toàn văn nội dung bài viết. |
| 6 | **UC-C03.1** | View Cart<br>*(Xem giỏ hàng)* | `<<include>>` | Base: `UC-C03` | P6 (LD) | Kiểm tra danh sách mặt hàng đã chọn mua. |
| 7 | **UC-C03.2** | Add Product to Cart<br>*(Thêm vào giỏ hàng)* | `<<extend>>` | Base: `UC-C03` | P6 (SC) | Thêm sản phẩm kèm số lượng vào giỏ. |
| 8 | **UC-C03.3** | Update / Remove Cart Item<br>*(Cập nhật / Xóa món hàng)* | `<<extend>>` | Base: `UC-C03` | P6 (LD) | Thay đổi số lượng hoặc xóa mặt hàng khỏi giỏ. |
| 9 | **UC-C04.1** | Log In with Google<br>*(Đăng nhập Google)* | `Generalization` | General: `UC-C04` &rarr; `OAuth` | P7 (SC) | Đăng nhập một chạm qua Google OAuth 2.0. |
| 10 | **UC-C04.2** | Log In with Facebook<br>*(Đăng nhập Facebook)* | `Generalization` | General: `UC-C04` &rarr; `OAuth` | P7 (SC) | Đăng nhập một chạm qua Facebook Login. |
| 11 | **UC-C04.3** | Complete First-time Profile<br>*(Bổ sung thông tin lần đầu)* | `<<extend>>` | Base: `UC-C04` `[First login]` | P7 (SC) | Nhập Họ tên, SĐT, Email, Địa chỉ giao hàng. |
| 12 | **UC-C04.4** | Verify Phone Number<br>*(Xác thực SĐT qua OTP)* | `<<include>>` | Base: `UC-C04.3` &rarr; `SMS` | P7 (SC) | Nhập mã OTP gửi qua SMS để xác minh số điện thoại. |
| 13 | **UC-C05.1** | View Profile<br>*(Xem thông tin cá nhân)* | `<<include>>` | Base: `UC-C05` | P7 (SC) | Xem thông tin tài khoản và danh sách địa chỉ. |
| 14 | **UC-C05.2** | Update Profile<br>*(Cập nhật thông tin cá nhân)* | `<<extend>>` | Base: `UC-C05` | P7 (SC) | Chỉnh sửa tên, email liên hệ. |
| 15 | **UC-C05.3** | Manage Delivery Addresses<br>*(Quản lý sổ địa chỉ giao hàng)* | `<<extend>>` | Base: `UC-C05` | P7 (SC) | Thêm, sửa, xóa địa chỉ; tự nhận địa chỉ mới nhất. |
| 16 | **UC-C06.1** | Select Delivery Address<br>*(Chọn địa chỉ nhận hàng)* | `<<include>>` | Base: `UC-C06` | P7 (LD) | Chọn từ sổ địa chỉ hoặc nhập địa chỉ mới. |
| 17 | **UC-C06.2** | Process Payment<br>*(Thực hiện thanh toán)* | `<<include>>` | Base: `UC-C06` | P7 (PR) | Chọn phương thức thanh toán tiền hàng. |
| 18 | **UC-C06.3** | Pay by COD<br>*(Thanh toán khi nhận hàng)* | `Generalization` | General: `UC-C06.2` | P7 (PR) | Trả tiền mặt cho nhân viên giao hàng. |
| 19 | **UC-C06.4** | Pay by Banking QR<br>*(Chuyển khoản mã VietQR)* | `Generalization` | General: `UC-C06.2` &rarr; `SePay`| P7 (PR) | Quét mã QR chuyển khoản tự động xác nhận. |
| 20 | **UC-C07.1** | View Order List<br>*(Xem lịch sử đơn hàng)* | `<<include>>` | Base: `UC-C07` | P8 (SC) | Xem danh sách các đơn đã đặt và trạng thái. |
| 21 | **UC-C07.2** | View Order Details<br>*(Xem chi tiết đơn hàng)* | `<<include>>` | Base: `UC-C07` | P8 (SC) | Xem trạng thái vận chuyển, món hàng, tổng tiền. |
| 22 | **UC-C07.3** | Cancel Undelivered Order<br>*(Hủy đơn hàng chưa giao)* | `<<extend>>` | Base: `UC-C07` `[Not delivered]` | P8 (SC) | Hủy đơn hàng khi còn ở trạng thái chờ xác nhận. |
| 23 | **UC-C07.4** | Submit Order Feedback<br>*(Đánh giá & Phản hồi đơn)* | `<<extend>>` | Base: `UC-C07` `[Delivered]` | P8 (SC) | Đánh giá chất lượng thực phẩm và dịch vụ sau giao. |
| 24 | **UC-C07.5** | Re-order<br>*(Đặt lại đơn hàng)* | `<<extend>>` | Base: `UC-C07` `[Delivered]` | P8 (SC) | Thêm nhanh toàn bộ món của đơn cũ vào giỏ hàng. |

---

### 3.5 Phân hệ Chức năng Chung (Common Subsystem)

| STT | Mã Use Case | Tên Use Case (English / Tiếng Việt) | Loại quan hệ | Tác nhân áp dụng | Nguồn gốc | Bản chất nghiệp vụ |
|:---:|:---:|---|:---:|---|:---:|---|
| 1 | **UC-M12.1** | Staff Log In<br>*(Đăng nhập nhân viên)* | `<<include>>` | Sale Staff, WH Staff, Store Owner | P12 (SC) | Đăng nhập hệ thống quản trị bằng tài khoản nội bộ. |
| 2 | **UC-M12.2** | Change Password<br>*(Đổi mật khẩu)* | `<<extend>>` | Sale Staff, WH Staff, Store Owner | P12 (LD) | Nhân viên chủ động cập nhật mật khẩu định kỳ. |
| 3 | **UC-M12.3** | Staff Log Out<br>*(Đăng xuất nhân viên)* | `<<extend>>` | Sale Staff, WH Staff, Store Owner | P12 (LD) | Thoát phiên làm việc đảm bảo an toàn thông tin. |

---

## 4. Summary Statistics (Thống kê Tổng hợp)

- **Tổng số Use Case tổng quát (General Use Cases):** `20` Use Cases.
- **Tổng số Use Case phân rã chi tiết (Decomposed Use Cases):** `69` Use Cases.
  - Phân hệ Kho hàng (WH Staff): `27` Use Cases.
  - Phân hệ Bán hàng & Vận hành (Sale Staff): `14` Use Cases.
  - Phân hệ Quản trị (Store Owner): `4` Use Cases (+ kế thừa toàn bộ Sale & WH).
  - Phân hệ Trang người dùng (Customer & Guest): `24` Use Cases.
  - Phân hệ Chức năng chung (Common Functions): `3` Use Cases.
- **Tỷ lệ truy vết nghiệp vụ nguồn (Coverage):** `100%` các đoạn văn bản P1–P13 đều có Use Case tương ứng.
- **Độ mịn Use Case:** Đã lọc bỏ 100% các micro-actions (chọn dropdown, nhập chi tiết, tự tính toán).
- **Ranh giới hệ thống:** 100% các biểu đồ tuân thủ **Single System Boundary** góc vuông (`rounded=0`).
