# FreshFood System — Non-Functional Requirements (NFR) Specification

**Project:** FreshFood — E-Commerce Organic Food System  
**Document Version:** 1.0 (Baselined)  
**Status:** Approved & Quantified  
**Governing Standard:** ISO/IEC 25010 System and Software Quality Models & Karl Wiegers Requirements Standard  
**Language Policy:** English Specification Identifiers with Bilingual Vietnamese Subtitles  

---

## 1. Executive Summary & Workload Baseline

Tài liệu này đặc tả chi tiết và định lượng hóa các **Yêu cầu Phi chức năng (Non-Functional Requirements - NFRs / Quality Attributes)** cốt lõi của hệ thống **FreshFood**. Các yêu cầu này đóng vai trò là động lực kiến trúc (Architectural Drivers) quyết định trực tiếp việc lựa chọn công nghệ, cấu trúc cơ sở dữ liệu, chiến lược caching, bảo mật và hạ tầng triển khai.

### Thông số Tải trọng Hoạt động Cơ sở (Workload Parameters):
* **Tổng số người dùng đăng ký hoạt động (Total User Base):** `500 users` (Khách hàng địa phương và nhân viên).
* **Số lượng người dùng đồng thời tại giờ cao điểm (Peak Concurrent Users - CCU):** `100 CCU` (Truy cập, duyệt sản phẩm và thực hiện giao dịch cùng lúc trong khung giờ cao điểm 9h00–11h30 và 16h00–18h30).
* **Phạm vi địa lý phục vụ (Operational Radius):** Bán kính $\le 10\text{ km}$ tính từ cửa hàng FreshFood (Áp dụng `BR-DEL-01`).

---

## 2. Detailed Quality Attributes Specification (Bảng Đặc tả Định lượng Chi tiết)

### 2.1 Hiệu Năng & Tải Trọng (Performance Efficiency & Capacity)

| Mã NFR | Tiêu chí chất lượng (Quality Attribute) | Tham số đo lường (Metric / Threshold) | Phương pháp kiểm chứng | Ghi chú kỹ thuật |
|:---:|---|---|---|---|
| **NFR-PERF-01** | **Khả năng chịu tải đồng thời (Concurrency Capacity)** | - Hỗ trợ mượt mà **100 người dùng đồng thời (100 CCU)**.<br>- Tỷ lệ lỗi (Error Rate) dưới tải 100 CCU: **< 0.1%**.<br>- Tổng quy mô người dùng: **500 users**. | Load Testing với kịch bản duyệt hàng và đặt hàng đồng thời (JMeter / k6). | Kiến trúc tối ưu hóa kết nối DB Pool và Caching cho danh mục sản phẩm. |
| **NFR-PERF-02** | **Thời gian tải trang Web (Page Load Time)** | - **FCP (First Contentful Paint)**: $\le 1.5\text{ giây}$.<br>- **LCP (Largest Contentful Paint)**: $\le 2.0\text{ giây}$.<br>*(Đo trên mạng 4G tiêu chuẩn dưới tải 100 CCU)*. | Lighthouse Audit & Google PageSpeed Insights. | Nén ảnh WebP, lazy loading ảnh thực phẩm, tối ưu CSS/JS bundle. |
| **NFR-PERF-03** | **Độ trễ API tìm kiếm & Lọc (Search & Filter Latency)** | - Thời gian phản hồi 95th percentile ($p95$): $\le 500\text{ ms}$ cho các truy vấn tìm kiếm theo tên và lọc theo nhóm sản phẩm. | APM Monitoring / Benchmark test. | Đánh chỉ mục Index trên cột `ProductName`, `CategoryID`, `BatchExpiryDate`. |
| **NFR-PERF-04** | **Thời gian hoàn tất Đặt hàng (Checkout Latency)** | - Thời gian xử lý từ lúc bấm "Đặt hàng" đến khi nhận mã đơn hàng: $\le 1.0\text{ giây}$ (bao gồm cả ghi DB và khóa giữ kho theo lô). | API Latency Tracing. | Giao dịch Transaction tối ưu, tránh lock bảng diện rộng. |
| **NFR-PERF-05** | **Khớp thanh toán VietQR tự động (SePay Webhook Speed)** | - Thời gian từ khi khách quét mã chuyển khoản thành công đến khi màn hình tự động nhảy sang trạng thái `Paid`: **$\le 3.0\text{ giây}$**. | Đo đạc thời gian Webhook round-trip thực tế. | Sử dụng WebSocket hoặc Polling 1.5s để cập nhật trạng thái đơn hàng tức thì. |
| **NFR-PERF-06** | **Tốc độ đo khoảng cách & Tính phí ship (Distance Latency)** | - Thời gian gọi API bản đồ để đo km địa chỉ và hiển thị phí ship bậc thang (`BR-DEL-02`): **$\le 800\text{ ms}$**. | Client-side API call tracing. | Cache tọa độ của các địa chỉ quen thuộc của khách để tái sử dụng. |

---

### 2.2 Toàn Vẹn & Nhất Quán Dữ Liệu (Data Integrity & Concurrency Control)

| Mã NFR | Tiêu chí chất lượng (Quality Attribute) | Tham số đo lường (Metric / Threshold) | Phương pháp kiểm chứng | Ghi chú kỹ thuật |
|:---:|---|---|---|---|
| **NFR-INT-01** | **Chống bán vượt tồn kho (Zero Over-Selling)** | - Tỷ lệ bán vượt tồn kho (Over-selling Rate): **Tuyệt đối 0%**.<br>- Khi nhiều người cùng mua những đơn vị sản phẩm cuối cùng của một lô hàng tại cùng một mili-giây, hệ thống phải đảm bảo tính tuần tự chính xác. | Concurrency Stress Test (100 threads mua cùng 1 sản phẩm còn tồn = 1). | Áp dụng Database Transaction với mức cô lập phù hợp (Pessimistic Locking `SELECT FOR UPDATE` hoặc Optimistic Locking). |
| **NFR-INT-02** | **Tính chuẩn xác hoàn kho khi hủy (Restock Accuracy)** | - **100%** các giao dịch Hủy đơn (`UC-C07.3`) hoặc Giao thất bại (`UC-M03.3`) phải hoàn trả chính xác đúng số lượng về đúng **Mã Lô (Batch ID)** ban đầu trong vòng **$\le 1.0\text{ giây}$**. | Automated Unit / Integration Tests. | Bắt buộc liên kết khóa ngoại giữa `Order_Details` và `Batch_Inventory`. |
| **NFR-INT-03** | **Toàn vẹn tính toán tài chính (Financial Precision)** | - Mọi phép tính tiền hàng, chiết khấu và phí giao hàng phải chính xác tuyệt đối theo đơn vị VNĐ, sai số: **0 VNĐ**. Không sử dụng kiểu dữ liệu số thực trôi nổi (Float) để tính tiền. | Static Analysis & Unit Tests. | CSDL và Mã nguồn bắt buộc dùng kiểu `decimal` (hoặc `bigint` số nguyên). |

---

### 2.3 Khả Năng Sử Dụng & Trải Nghiệm Di Động (Usability & Mobile-First)

| Mã NFR | Tiêu chí chất lượng (Quality Attribute) | Tham số đo lường (Metric / Threshold) | Phương pháp kiểm chứng | Ghi chú kỹ thuật |
|:---:|---|---|---|---|
| **NFR-USA-01** | **Tương thích hoàn hảo trên di động (Mobile Responsiveness)** | - **100%** giao diện Storefront hiển thị chuẩn xác, không bị tràn ngang trên màn hình từ **360px** (di động nhỏ) đến 1920px (desktop).<br>- Kích thước nút bấm cảm ứng tối thiểu: **$\ge 44 \times 44\text{ px}$**. | Kiểm thử thực tế trên iOS Safari, Android Chrome và Chrome DevTools. | Thiết kế Mobile-first, font chữ tối thiểu 14px để người lớn tuổi dễ đọc. |
| **NFR-USA-02** | **Tối giản thao tác đặt hàng (Checkout Simplicity)** | - Khách hàng quen (đã đăng nhập và có địa chỉ) có thể hoàn tất quy trình đặt hàng trong vòng **$\le 3\text{ thao tác chạm}$** (Chạm "Đặt hàng" &rarr; Chọn PTTT &rarr; Xác nhận). | User Journey Testing. | Tự động chọn địa chỉ gần nhất theo quy tắc `BR-AUTH-03`. |
| **NFR-USA-03** | **Chỉ dẫn lỗi thân thiện (Graceful Error Feedback)** | - Khi khách nhập địa chỉ ngoài bán kính 10 km (`BR-DEL-01`), hệ thống phải hiển thị thông báo lỗi tiếng Việt thân thiện, rõ ràng trong vòng **$\le 500\text{ ms}$**, chỉ rõ nguyên nhân và hướng dẫn đổi địa chỉ. | GUI Testing / Checklist Review. | Tránh các mã lỗi kỹ thuật khó hiểu (như 400, 500 hay ngoại lệ SQL). |

---

### 2.4 An Toàn & Phân Quyền Bảo Mật (Security & Access Control)

| Mã NFR | Tiêu chí chất lượng (Quality Attribute) | Tham số đo lường (Metric / Threshold) | Phương pháp kiểm chứng | Ghi chú kỹ thuật |
|:---:|---|---|---|---|
| **NFR-SEC-01** | **Mã hóa truyền thông & Lưu trữ (Data Encryption)** | - **100%** lưu lượng mạng truyền qua HTTPS (TLS 1.2 / TLS 1.3).<br>- Mật khẩu tài khoản nhân viên được băm bằng thuật toán an toàn (`BCrypt` với Work Factor $\ge 11$ hoặc `Argon2`). | Security Audit & SSL Labs Test. | Cấm lưu trữ mật khẩu dạng văn bản thô (Plaintext). |
| **NFR-SEC-02** | **Phân quyền theo vai trò (RBAC Enforcement)** | - Ngăn chặn **100%** các hành vi truy cập trái phép chéo quyền giữa Sale Staff, WH Staff và Khách hàng.<br>- Các request vi phạm quyền hạn phải bị từ chối với mã lỗi `403 Forbidden` và không làm rò rỉ dữ liệu. | Pen-testing / Security Test Cases. | Triển khai Middleware kiểm tra Role Claims trên từng API endpoint. |
| **NFR-SEC-03** | **Thời hạn phiên & Thu hồi quyền tức thì (Session & Token Revocation)** | - Thời hạn Access Token tối đa: **60 phút**.<br>- Khi Store Owner thu hồi quyền (`BR-SEC-03`), tài khoản bị vô hiệu hóa và chặn truy cập ngay lập tức trong vòng **$\le 1.0\text{ giây}$**. | Integration Test kịch bản vô hiệu hóa nhân viên. | Sử dụng cơ chế Token Blacklist (Redis/DB) hoặc kiểm tra trạng thái `IsActive` của nhân viên. |
| **NFR-SEC-04** | **Chống lạm dụng gửi SMS OTP (SMS Rate Limiting)** | - Giới hạn tối đa **3 lần gửi OTP / 1 số điện thoại trong 15 phút**.<br>- Thời hạn hiệu lực của mã OTP: **3 phút**.<br>- Nhập sai OTP quá 5 lần liên tiếp: Khóa tạm thời 30 phút. | Security API Abuse Testing. | Chống cạn kiệt ngân sách dịch vụ SMS Brandname của cửa hàng. |

---

### 2.5 Khả Năng Chịu Lỗi Dịch Vụ Tích Hợp (Third-Party Resilience)

| Mã NFR | Tiêu chí chất lượng (Quality Attribute) | Tham số đo lường (Metric / Threshold) | Phương pháp kiểm chứng | Ghi chú kỹ thuật |
|:---:|---|---|---|---|
| **NFR-RES-01** | **Thời gian chờ dịch vụ ngoài (External API Timeout)** | - Giới hạn thời gian chờ tối đa (Timeout) khi gọi API ngoài (Google Maps, SePay, SMS Gateway): **$\le 3.0\text{ giây}$**. Nếu quá 3 giây, hệ thống tự động ngắt kết nối để không làm treo ứng dụng. | Mock Network Delay Test. | Áp dụng Timeout & Retry Pattern (Polly / Axios Timeout). |
| **NFR-RES-02** | **Cơ chế dự phòng khi lỗi Maps (Maps Fallback Mechanism)** | - Nếu dịch vụ Google Maps API gặp sự cố hoặc vượt quota: Hệ thống chuyển sang chế độ dự phòng (cho phép khách chọn Phường/Xã trong danh sách với mức phí ship mặc định 20.000 VNĐ) để đơn hàng vẫn được tạo thành công. | Chaos / Failure Injection Testing. | Tránh mất đơn hàng khi dịch vụ bên thứ ba gián đoạn. |

---

### 2.6 Độ Sẵn Sàng & Vận Hành Tin Cậy (Availability & Operational Reliability)

| Mã NFR | Tiêu chí chất lượng (Quality Attribute) | Tham số đo lường (Metric / Threshold) | Phương pháp kiểm chứng | Ghi chú kỹ thuật |
|:---:|---|---|---|---|
| **NFR-REL-01** | **Độ sẵn sàng hệ thống (System Uptime)** | - Đạt mức tối thiểu **99.5% Uptime** trong khung giờ bán hàng từ **06h00 đến 22h00** hàng ngày.<br>- Thời gian gián đoạn ngoài kế hoạch cho phép: $\le 2.4\text{ giờ/tháng}$. | Uptime Monitoring (UptimeRobot / Prometheus). | Bảo trì hệ thống và chạy cập nhật phiên bản chỉ thực hiện từ 0h00 đến 4h00 sáng. |
| **NFR-REL-02** | **Sao lưu cơ sở dữ liệu định kỳ (Automated Daily Backup)** | - Tự động sao lưu toàn bộ cơ sở dữ liệu **1 lần / ngày vào lúc 01h00 sáng**.<br>- Lưu trữ bản sao lưu an toàn tại máy chủ riêng biệt trong tối thiểu 30 ngày. | Cron job audit & Backup verification. | RPO (Mất mát dữ liệu tối đa): $\le 24\text{ giờ}$.<br>RTO (Thời gian phục hồi hệ thống): $\le 2\text{ giờ}$. |

---

### 2.7 Khả Năng Bảo Trì (Maintainability)

| Mã NFR | Tiêu chí chất lượng (Quality Attribute) | Tham số đo lường (Metric / Threshold) | Phương pháp kiểm chứng | Ghi chú kỹ thuật |
|:---:|---|---|---|---|
| **NFR-MNT-01** | **Kiến trúc phân tầng & Module hóa (Layered Architecture)** | - Mã nguồn tuân thủ kiến trúc phân tầng sạch (Clean / Layered Architecture): Controller (API) &rarr; Service (Nghiệp vụ) &rarr; Repository (Dữ liệu).<br>- Độ phụ thuộc lỏng (Loose Coupling): Các tầng giao tiếp qua Interface, hỗ trợ Dependency Injection (DI). | Code Review & Static Analysis (SonarQube). | Giảm thiểu tối đa tác động lan truyền khi sửa đổi một module nghiệp vụ. |
| **NFR-MNT-02** | **Khả năng thay đổi cấu hình không cần biên dịch lại (Configurability)** | - **100%** các tham số nghiệp vụ cốt lõi: Bán kính giao hàng tối đa (`MaxDeliveryDistance = 10 km`), Mốc biểu phí ship bậc thang (`10k / 20k / 30k`), Timeout API ngoài, Thời hạn OTP phải cấu hình được qua file `appsettings.json` / `.env` hoặc bảng `System_Config`.<br>- Thay đổi tham số có hiệu lực ngay lập tức trong vòng **$\le 5\text{ giây}$** mà không cần re-compile hoặc deploy lại code. | Inspection Test & Config Hot-reload Verification. | Đảm bảo chủ cửa hàng có thể linh hoạt điều chỉnh chính sách kinh doanh bất cứ lúc nào. |
| **NFR-MNT-03** | **Khả năng kiểm thử tự động (Testability & Code Coverage)** | - Độ phủ kiểm thử tự động (Unit Test Coverage) đạt tối thiểu **$\ge 75\%$** đối với các Service nghiệp vụ cốt lõi: Tính phí ship (`BR-DEL-02`), Quản lý lô FIFO (`BR-BAT-02`), Trừ/hoàn tồn kho theo lô, Khóa giữ chỗ đơn hàng.<br>- Thời gian chạy toàn bộ bộ Unit Test: **$\le 2\text{ phút}$** trong pipeline CI/CD. | Code Coverage Report (dotCover / Coverlet / Jest). | Đảm bảo tự tin khi bảo trì và refactor code mà không phát sinh lỗi hồi quy (Regression bugs). |
| **NFR-MNT-04** | **Nhật ký cấu trúc & Khả năng chẩn đoán sự cố (Structured Logging & Observability)** | - **100%** log lỗi hệ thống được ghi có cấu trúc (JSON / Serilog) kèm theo `CorrelationId / TraceId`, định danh User, thời gian chính xác.<br>- Thời gian trung bình để kỹ sư xác định nguyên nhân gốc rễ (MTTI - Mean Time to Identify): **$\le 15\text{ phút}$** dựa trên log hệ thống. | Log Audit & Incident Simulation. | Tích hợp hệ thống ghi log tập trung hoặc file log xoay vòng (Rolling File Log). |

---

### 2.8 Khả Năng Tái Sử Dụng (Reusability)

| Mã NFR | Tiêu chí chất lượng (Quality Attribute) | Tham số đo lường (Metric / Threshold) | Phương pháp kiểm chứng | Ghi chú kỹ thuật |
|:---:|---|---|---|---|
| **NFR-REU-01** | **Tái sử dụng Dịch vụ Tính toán Nghiệp vụ (Reusable Domain Services)** | - Các module tính toán cốt lõi: Tính khoảng cách bản đồ (`DistanceCalculator`), Tính phí ship bậc thang (`ShippingFeeCalculator`), Kiểm tra tồn kho theo lô (`BatchStockValidator`) được đóng gói thành các Service dùng chung độc lập.<br>- Có thể tái sử dụng trực tiếp trên cả: Web API Storefront, Ứng dụng quản trị Admin, và các tác vụ chạy ngầm (Background Jobs) mà không phải viết lại logic. | Architectural Review & Code Reuse Audit. | Đặt trong thư viện `FreshFood.Domain` / `FreshFood.Core`. |
| **NFR-REU-02** | **Thư viện Thành phần Giao diện Dùng chung (Reusable UI Components)** | - Xây dựng bộ thư viện UI Component dùng chung (Component Library / Design System): Thẻ sản phẩm (`ProductCard`), Nút điều chỉnh số lượng (`QuantitySelector`), Modal chọn địa chỉ giao hàng (`AddressPickerModal`), Badge trạng thái đơn hàng (`OrderStatusBadge`).<br>- Tỷ lệ tái sử dụng thành phần UI trên các màn hình Storefront: **$\ge 80\%$**. | Frontend Code Audit & Storybook / Component Showcase. | Tiết kiệm 40% thời gian phát triển giao diện và đảm bảo tính đồng nhất trải nghiệm. |
| **NFR-REU-03** | **Khả năng cắm rút & Tái sử dụng Cổng thanh toán / SMS (Pluggable Adapters)** | - Áp dụng mẫu thiết kế Adapter / Strategy Pattern cho các dịch vụ ngoại vi:<br>  + Giao diện `IPaymentGateway` &rarr; `SePayAdapter`, `CodPaymentAdapter` (sẵn sàng tái sử dụng hoặc mở rộng thêm MoMo, VNPay, ZaloPay trong tương lai mà không sửa mã nguồn xử lý đơn hàng).<br>  + Giao diện `ISmsService` &rarr; `SpeedSmsAdapter`, `TwilioAdapter`. | Architecture Conformance Test & Mock Gateway Implementation. | Mở rộng cổng thanh toán hoặc đổi nhà mạng SMS mới chỉ mất dưới 1 ngày làm việc. |
| **NFR-REU-04** | **Thư viện Tiện ích Chung (Shared Utilities Library)** | - Các hàm tiện ích dùng chung (Định dạng tiền tệ VNĐ `VndCurrencyFormatter`, chuẩn hóa số điện thoại Việt Nam `PhoneNumberHelper`, mã hóa mật khẩu, xử lý thời gian GMT+7) được đóng gói vào thư viện `Shared.Common`.<br>- Tái sử dụng 100% trên toàn bộ các project con trong giải pháp giải phóng việc lặp code (DRY - Don't Repeat Yourself). | Static Code Analysis (Kiểm tra trùng lặp code Duplication < 3%). | Giữ mã nguồn gọn gàng, chuẩn hóa định dạng số liệu trên toàn hệ thống. |

---

## 3. Ma Trận Đánh Giá Khả Năng Đáp Ứng Theo Tải Trọng (100 CCU / 500 Users)

| Thành phần hệ thống | Nhu cầu tài nguyên cho 100 CCU & 500 Users | Giải pháp kỹ thuật áp dụng |
|---|---|---|
| **Web Server / Backend (ASP.NET Core 10 / C#)** | ~0.5 – 1.0 vCPU, 1 GB – 2 GB RAM | Capacity estimate only; verify 100 concurrent users on the configured target environment. |
| **Database Server (PostgreSQL / SQL Server)** | Connection Pool: 50 – 100 active connections | Cấu hình Index thông minh, phân chia connection pool tối ưu. |
| **Dung lượng lưu trữ ảnh (Media Storage)** | ~500 sản phẩm × 3 ảnh × 300 KB = **~450 MB** | Lưu trữ trên Cloudflare R2 / S3 hoặc ổ đĩa máy chủ nội bộ. |
| **Mạng truyền tải (Bandwidth)** | Đỉnh điểm: 100 CCU × 50 KB/page = **~5 MB/s (~40 Mbps)** | Băng thông tiêu chuẩn của các gói Cloud VPS thông thường đáp ứng dư dả. |
