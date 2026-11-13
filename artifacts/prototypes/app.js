/* ==========================================================================
   FreshFood Organic E-Commerce Platform — UI Prototype Application Logic
   ========================================================================== */

const State = {
  activeScreen: 'screen-priority-overview',
  activeCategory: 'all',
  searchQuery: '',
  clearanceFilter: false,
  cart: [
    { productId: 2, quantity: 2 },
    { productId: 1, quantity: 1 }
  ],
  user: {
    name: 'Nguyễn Thị Lan',
    phone: '0912345678',
    email: 'lan.nguyen@example.com',
    tier: 'Gold Organic Member',
    joinedDate: '15/01/2026'
  },
  addresses: [
    {
      id: 1,
      recipient: 'Nguyễn Thị Lan',
      phone: '0912345678',
      street: 'Số 15 Liễu Giai',
      ward: 'Phường Liễu Giai',
      district: 'Quận Ba Đình',
      city: 'Hà Nội',
      distance: 1.8,
      isDefault: true,
      coords: '21.0335° N, 105.8152° E'
    },
    {
      id: 2,
      recipient: 'Nguyễn Thị Lan (Văn phòng)',
      phone: '0912345678',
      street: 'Tầng 6 Lotte Center, 54 Liễu Giai',
      ward: 'Phường Cống Vị',
      district: 'Quận Ba Đình',
      city: 'Hà Nội',
      distance: 2.1,
      isDefault: false,
      coords: '21.0322° N, 105.8130° E'
    },
    {
      id: 3,
      recipient: 'Nguyễn Văn Thành (Bố)',
      phone: '0987654321',
      street: '280 Lạc Long Quân',
      ward: 'Phường Bưởi',
      district: 'Quận Tây Hồ',
      city: 'Hà Nội',
      distance: 2.8,
      isDefault: false,
      coords: '21.0510° N, 105.8080° E'
    },
    {
      id: 4,
      recipient: 'Địa chỉ Ngoại thành (Test vi phạm > 10km)',
      phone: '0901234567',
      street: 'Khu Đô Thị Gamuda Gardens, Km 1.5 Pháp Vân',
      ward: 'Phường Trần Phú',
      district: 'Quận Hoàng Mai',
      city: 'Hà Nội',
      distance: 13.5,
      isDefault: false,
      coords: '20.9720° N, 105.8640° E'
    }
  ],
  products: [
    {
      id: 1,
      sku: 'FF-VEG-001',
      name: 'Rau Xà Lách Romaine Hữu Cơ',
      category: 'veg',
      categoryName: 'Rau lá hữu cơ',
      unit: '500g',
      price: 35000,
      originalPrice: 35000,
      stock: 15,
      isClearance: false,
      discountPct: 0,
      cert: 'USDA Organic',
      origin: 'Đà Lạt Farm (Lâm Đồng)',
      harvestDate: '22/10/2026',
      expDate: '27/10/2026',
      desc: 'Xà lách Romaine giòn ngọt tự nhiên, trồng theo phương pháp hữu cơ vi sinh tại Đà Lạt, giàu vitamin A, K và chất xơ.',
      img: 'https://images.unsplash.com/photo-1556801712-76c8eb07bbc9?auto=format&fit=crop&w=500&q=80'
    },
    {
      id: 2,
      sku: 'FF-VEG-002',
      name: 'Cà Chua Cherry Vàng Organic',
      category: 'veg',
      categoryName: 'Rau củ organic',
      unit: '500g',
      price: 45000,
      originalPrice: 56000,
      stock: 8,
      isClearance: true,
      discountPct: 20,
      cert: 'VietGAP',
      origin: 'Mộc Châu Organic Farm',
      harvestDate: '19/10/2026',
      expDate: '25/10/2026 (Còn 2 ngày)',
      desc: 'Cà chua cherry vàng ngọt đậm, mọng nước, nhiều lycopene. Lô cận hạn thanh lý giảm 20% theo quy định BR-BAT-04.',
      img: 'https://images.unsplash.com/photo-1592924357228-91a4daadcfea?auto=format&fit=crop&w=500&q=80'
    },
    {
      id: 3,
      sku: 'FF-VEG-003',
      name: 'Cải Bó Xôi Hữu Cơ (Spinach)',
      category: 'veg',
      categoryName: 'Rau lá hữu cơ',
      unit: '500g',
      price: 32000,
      originalPrice: 32000,
      stock: 12,
      isClearance: false,
      discountPct: 0,
      cert: 'GlobalGAP',
      origin: 'Đà Lạt Farm (Lâm Đồng)',
      harvestDate: '22/10/2026',
      expDate: '28/10/2026',
      desc: 'Rau bina giàu sắt, canxi và chất chống oxy hóa, thu hoạch lúc sáng sớm giữ trọn độ tươi non.',
      img: 'https://images.unsplash.com/photo-1576045057995-568f588f82fb?auto=format&fit=crop&w=500&q=80'
    },
    {
      id: 4,
      sku: 'FF-FRU-001',
      name: 'Dâu Tây Hữu Cơ Giống Nhật',
      category: 'fruit',
      categoryName: 'Trái cây nhiệt đới',
      unit: '500g',
      price: 120000,
      originalPrice: 170000,
      stock: 5,
      isClearance: true,
      discountPct: 30,
      cert: 'VietGAP',
      origin: 'Đà Lạt Bio Farm',
      harvestDate: '20/10/2026',
      expDate: '25/10/2026 (Còn 2 ngày)',
      desc: 'Dâu tây thơm ngát, vị ngọt dịu thanh, áp dụng chính sách ưu đãi giảm giá thanh lý BR-BAT-04.',
      img: 'https://images.unsplash.com/photo-1464965911861-746a04b4bca6?auto=format&fit=crop&w=500&q=80'
    },
    {
      id: 5,
      sku: 'FF-MUS-001',
      name: 'Nấm Đùi Gà Bio Ba Vì',
      category: 'mushroom',
      categoryName: 'Nấm sạch',
      unit: '300g',
      price: 42000,
      originalPrice: 42000,
      stock: 20,
      isClearance: false,
      discountPct: 0,
      cert: 'VietGAP',
      origin: 'Ba Vì Bio-Mushroom Hub',
      harvestDate: '22/10/2026',
      expDate: '30/10/2026',
      desc: 'Nấm đùi gà thịt dai giòn, ngọt tự nhiên, không hóa chất bảo quản hay kích thích tăng trưởng.',
      img: 'https://images.unsplash.com/photo-1509358271058-acd22cc93898?auto=format&fit=crop&w=500&q=80'
    },
    {
      id: 6,
      sku: 'FF-EGG-001',
      name: 'Trứng Gà Ta Thảo Dược Hữu Cơ',
      category: 'meat-egg',
      categoryName: 'Thịt & Trứng',
      unit: 'Hộp 10 quả',
      price: 48000,
      originalPrice: 48000,
      stock: 25,
      isClearance: false,
      discountPct: 0,
      cert: 'VietGAP',
      origin: 'Trang trại Sinh học Ba Vì',
      harvestDate: '21/10/2026',
      expDate: '15/11/2026',
      desc: 'Gà được nuôi thả đồi, cho ăn cám thảo dược tự nhiên, lòng đỏ vàng cam đậm vị béo ngậy.',
      img: 'https://images.unsplash.com/photo-1516467508483-a7212febe31a?auto=format&fit=crop&w=500&q=80'
    },
    {
      id: 7,
      sku: 'FF-FRU-002',
      name: 'Bơ Sáp 034 Đắk Lắk Hữu Cơ',
      category: 'fruit',
      categoryName: 'Trái cây nhiệt đới',
      unit: '1kg (3-4 quả)',
      price: 65000,
      originalPrice: 76500,
      stock: 10,
      isClearance: true,
      discountPct: 15,
      cert: 'GlobalGAP',
      origin: 'Cư M\'gar (Đắk Lắk)',
      harvestDate: '18/10/2026',
      expDate: '26/10/2026',
      desc: 'Bơ sáp dẻo ngậy vàng ươm, vỏ mỏng hạt tiêu, đang áp dụng giảm giá thanh lý 15% theo lô.',
      img: 'https://images.unsplash.com/photo-1523049673857-eb18f1d7b578?auto=format&fit=crop&w=500&q=80'
    },
    {
      id: 8,
      sku: 'FF-MEA-001',
      name: 'Thịt Ba Chỉ Heo Sinh Học Thảo Dược',
      category: 'meat-egg',
      categoryName: 'Thịt & Trứng',
      unit: '500g',
      price: 115000,
      originalPrice: 115000,
      stock: 7,
      isClearance: false,
      discountPct: 0,
      cert: 'VietGAP',
      origin: 'Hà Nam Eco-Farm',
      harvestDate: '23/10/2026 (Sáng nay)',
      expDate: '25/10/2026',
      desc: 'Thịt heo sinh học chăn nuôi theo quy trình vi sinh quế chi, nạc mỡ đan xen đều, thơm ngon tự nhiên.',
      img: 'https://images.unsplash.com/photo-1607623814075-e51df1bdc82f?auto=format&fit=crop&w=500&q=80'
    }
  ],
  orders: [
    {
      id: 'FF-20261023-089',
      date: '23/10/2026 09:15',
      status: 'pending',
      statusName: 'Chờ xác nhận',
      total: 145000,
      items: [
        { name: 'Cà Chua Cherry Vàng Organic', qty: 2, price: 45000, total: 90000 },
        { name: 'Rau Xà Lách Romaine Hữu Cơ', qty: 1, price: 35000, total: 35000 }
      ],
      shippingFee: 20000,
      paymentMethod: 'COD (Thanh toán khi nhận hàng)',
      paymentStatus: 'Chưa thanh toán',
      address: 'Số 15 Liễu Giai, P. Liễu Giai, Q. Ba Đình, Hà Nội',
      canCancel: true,
      canReview: false,
      isReviewed: false
    },
    {
      id: 'FF-20261022-045',
      date: '22/10/2026 14:30',
      status: 'confirmed',
      statusName: 'Đã xác nhận',
      total: 167000,
      items: [
        { name: 'Dâu Tây Hữu Cơ Giống Nhật', qty: 1, price: 120000, total: 120000 },
        { name: 'Cải Bó Xôi Hữu Cơ (Spinach)', qty: 1, price: 32000, total: 32000 }
      ],
      shippingFee: 15000,
      paymentMethod: 'VietQR Banking Transfer',
      paymentStatus: 'Đã thanh toán (SePay Webhook Verified)',
      address: 'Tầng 6 Lotte Center, 54 Liễu Giai, P. Cống Vị, Ba Đình, Hà Nội',
      canCancel: true,
      canReview: false,
      isReviewed: false
    },
    {
      id: 'FF-20261021-012',
      date: '21/10/2026 16:45',
      status: 'shipping',
      statusName: 'Đang giao hàng',
      total: 210000,
      items: [
        { name: 'Thịt Ba Chỉ Heo Sinh Học', qty: 1, price: 115000, total: 115000 },
        { name: 'Bơ Sáp 034 Đắk Lắk Hữu Cơ', qty: 1, price: 65000, total: 65000 },
        { name: 'Nấm Đùi Gà Bio Ba Vì', qty: 1, price: 42000, total: 42000 }
      ],
      shippingFee: 20000,
      paymentMethod: 'VietQR Banking Transfer',
      paymentStatus: 'Đã thanh toán',
      address: '280 Lạc Long Quân, P. Bưởi, Q. Tây Hồ, Hà Nội',
      canCancel: false,
      canReview: false,
      isReviewed: false
    },
    {
      id: 'FF-20261020-008',
      date: '20/10/2026 11:20',
      status: 'delivered',
      statusName: 'Giao thành công',
      total: 145000,
      items: [
        { name: 'Cà Chua Cherry Vàng Organic', qty: 2, price: 45000, total: 90000 },
        { name: 'Rau Xà Lách Romaine Hữu Cơ', qty: 1, price: 35000, total: 35000 }
      ],
      shippingFee: 20000,
      paymentMethod: 'COD',
      paymentStatus: 'Đã thanh toán cho Shipper',
      address: 'Số 15 Liễu Giai, P. Liễu Giai, Q. Ba Đình, Hà Nội',
      canCancel: false,
      canReview: true,
      isReviewed: true,
      reviewStars: 5,
      reviewComment: 'Rau củ rất tươi giòn, giao nhanh trong 1 tiếng. Rất hài lòng!'
    },
    {
      id: 'FF-20261019-093',
      date: '19/10/2026 10:05',
      status: 'delivered',
      statusName: 'Giao thành công',
      total: 280000,
      items: [
        { name: 'Dâu Tây Hữu Cơ Giống Nhật', qty: 2, price: 120000, total: 240000 },
        { name: 'Nấm Đùi Gà Bio Ba Vì', qty: 1, price: 42000, total: 42000 }
      ],
      shippingFee: 20000,
      paymentMethod: 'VietQR Banking Transfer',
      paymentStatus: 'Đã thanh toán',
      address: 'Số 15 Liễu Giai, P. Liễu Giai, Q. Ba Đình, Hà Nội',
      canCancel: false,
      canReview: true,
      isReviewed: false
    },
    {
      id: 'FF-20261018-051',
      date: '18/10/2026 15:10',
      status: 'cancelled',
      statusName: 'Đã hủy',
      total: 80000,
      items: [
        { name: 'Trứng Gà Ta Thảo Dược', qty: 1, price: 48000, total: 48000 }
      ],
      shippingFee: 20000,
      paymentMethod: 'COD',
      paymentStatus: 'Đã hủy - Đã hoàn trả kho lô',
      address: 'Số 15 Liễu Giai, P. Liễu Giai, Q. Ba Đình, Hà Nội',
      canCancel: false,
      canReview: false,
      isReviewed: false,
      cancelReason: 'Khách hàng bận đi công tác đột xuất.'
    }
  ],
  checkout: {
    selectedAddressId: 1,
    paymentMethod: 'cod',
    distanceKm: 1.8,
    shippingFee: 20000,
    isRadiusValid: true,
    vietqrTimer: null,
    vietqrSeconds: 900
  },
  goodsReceipts: [
    {
      id: 'GR-20261023-01',
      supplier: 'Hợp tác xã Rau sạch Đà Lạt',
      invoiceNo: 'INV-DL-8891',
      date: '23/10/2026',
      staff: 'Trần Văn Kho (Warehouse Staff)',
      total: 14250000,
      itemsCount: 3
    }
  ]
};

function formatVND(num) {
  return new Intl.NumberFormat('vi-VN', { style: 'currency', currency: 'VND' }).format(num);
}

function showToast(message, type = 'success') {
  const container = document.getElementById('toastContainer');
  if (!container) return;
  const toast = document.createElement('div');
  toast.className = `toast toast-${type}`;
  let icon = '✓';
  if (type === 'error') icon = '✕';
  if (type === 'warning') icon = '⚠';
  toast.innerHTML = `<strong>${icon}</strong> <span>${message}</span>`;
  container.appendChild(toast);
  setTimeout(() => {
    toast.style.opacity = '0';
    toast.style.transform = 'translateY(10px)';
    setTimeout(() => toast.remove(), 300);
  }, 3500);
}

function switchScreen(screenId) {
  State.activeScreen = screenId;
  document.querySelectorAll('.prototype-screen').forEach(el => el.classList.remove('active'));
  const target = document.getElementById(screenId);
  if (target) target.classList.add('active');

  document.querySelectorAll('.prototype-meta-btn').forEach(btn => {
    btn.classList.toggle('active', btn.dataset.screen === screenId);
  });

  updateContextBanner(screenId);
  window.scrollTo({ top: 0, behavior: 'smooth' });

  if (screenId === 'screen-uc-c01') renderCatalog();
  if (screenId === 'screen-uc-c03') renderCartPage();
  if (screenId === 'screen-uc-c05') renderProfilePage();
  if (screenId === 'screen-uc-c06') renderCheckoutPage();
  if (screenId === 'screen-uc-c07') renderOrdersPage();
  if (screenId === 'screen-uc-m08') renderWarehousePage();
}

function updateContextBanner(screenId) {
  const meta = {
    'screen-priority-overview': {
      title: '🎯 Tổng quan Danh mục Prototype theo Độ ưu tiên Karl Wiegers',
      desc: 'Bản đặc tả nguyên mẫu giao diện người dùng (UI Prototype) được cấu trúc và triển khai theo đúng thứ tự ưu tiên lượng hóa Karl Wiegers trong Software Requirements Specification.',
      rank: 'Toàn bộ 6 Use Cases',
      score: 'Prioritized Backlog',
      actor: 'Guest, Customer & Warehouse Staff',
      rules: 'AGENTS.md §2.6, §2.7 | requirements-rules.md §7, §14'
    },
    'screen-uc-c01': {
      title: 'Rank 1: UC-C01 — Browse & Search Products',
      desc: 'Giao diện khám phá nông sản hữu cơ, tìm kiếm thời gian thực (< 500ms), lọc danh mục và bộ lọc giảm giá thanh lý lô cận hạn.',
      rank: 'Rank 1',
      score: 'Priority: 0.890 (High)',
      actor: 'Guest, Customer',
      rules: 'BR-CAT-02, BR-BAT-01, BR-BAT-04, NFR-PERF-03'
    },
    'screen-uc-c05': {
      title: 'Rank 2: UC-C05 — Manage Profile & Addresses',
      desc: 'Giao diện quản lý hồ sơ cá nhân và sổ địa chỉ giao hàng với cơ chế tự động thiết lập địa chỉ mặc định theo đơn hàng gần nhất.',
      rank: 'Rank 2',
      score: 'Priority: 0.774 (High)',
      actor: 'Customer',
      rules: 'BR-AUTH-01, BR-AUTH-03 (Delivery Defaulting)'
    },
    'screen-uc-c03': {
      title: 'Rank 3: UC-C03 — Manage Shopping Cart',
      desc: 'Giao diện giỏ hàng thời gian thực với cơ chế kiểm tra và chốt chặn tồn kho vật lý khả dụng của từng lô theo quy tắc FEFO.',
      rank: 'Rank 3',
      score: 'Priority: 0.610 (High)',
      actor: 'Customer',
      rules: 'BR-BAT-01, BR-BAT-02, BR-ORD-01 (Zero Over-Selling)'
    },
    'screen-uc-c06': {
      title: 'Rank 4: UC-C06 — Checkout & Place Order',
      desc: 'Giao diện đặt hàng và thanh toán: kiểm tra nghiêm ngặt bán kính 10km, tính phí vận chuyển lũy tiến, hỗ trợ COD và VietQR tự động.',
      rank: 'Rank 4',
      score: 'Priority: 0.610 (High)',
      actor: 'Customer',
      rules: 'BR-DEL-01 (10km), BR-DEL-02 (Tiered Fee), BR-ORD-03 (VietQR)'
    },
    'screen-uc-c07': {
      title: 'Rank 5: UC-C07 — Manage My Orders',
      desc: 'Giao diện theo dõi đơn hàng trực quan theo vòng đời trạng thái, hủy đơn hoàn tồn kho tự động, đặt lại đơn cũ và đánh giá 1-5 sao.',
      rank: 'Rank 5',
      score: 'Priority: 0.542 (Medium)',
      actor: 'Customer',
      rules: 'BR-ORD-04, BR-ORD-05 (Cancellation Policy), BR-RE-01, BR-FB-01'
    },
    'screen-uc-m08': {
      title: 'Rank 6: UC-M08 — Manage Goods Receipts (Warehouse Staff)',
      desc: 'Giao diện nghiệp vụ nội bộ cho Nhân viên Kho tạo phiếu nhập kho, kiểm tra hạn sử dụng >= 3 ngày và gắn nhãn bán FEFO Delayed/Active.',
      rank: 'Rank 6',
      score: 'Priority: 0.624 (High Operations)',
      actor: 'Warehouse Staff',
      rules: 'BR-GR-01, BR-GR-02, BR-GR-03, BR-BAT-03'
    }
  };

  const curr = meta[screenId] || meta['screen-priority-overview'];
  document.getElementById('ucTitle').textContent = curr.title;
  document.getElementById('ucDesc').textContent = curr.desc;
  document.getElementById('ucRankBadge').textContent = curr.rank;
  document.getElementById('ucScoreBadge').textContent = curr.score;
  document.getElementById('ucActorBadge').textContent = curr.actor;
  document.getElementById('ucRulesBadge').textContent = curr.rules;
}

function updateCartCount() {
  const totalItems = State.cart.reduce((sum, item) => sum + item.quantity, 0);
  document.querySelectorAll('.cart-count-badge').forEach(b => b.textContent = totalItems);
}

// 1. UC-C01: Browse & Search Products
function renderCatalog() {
  const grid = document.getElementById('productGrid');
  if (!grid) return;

  let filtered = State.products.filter(p => {
    if (State.activeCategory !== 'all' && p.category !== State.activeCategory) return false;
    if (State.clearanceFilter && !p.isClearance) return false;
    if (State.searchQuery.trim() !== '') {
      const q = State.searchQuery.toLowerCase();
      const match = p.name.toLowerCase().includes(q) || p.origin.toLowerCase().includes(q) || p.cert.toLowerCase().includes(q);
      if (!match) return false;
    }
    return true;
  });

  const emptyState = document.getElementById('catalogEmptyState');
  if (filtered.length === 0) {
    grid.style.display = 'none';
    if (emptyState) emptyState.style.display = 'block';
    return;
  } else {
    grid.style.display = 'grid';
    if (emptyState) emptyState.style.display = 'none';
  }

  grid.innerHTML = filtered.map(p => `
    <div class="product-card" data-id="${p.id}">
      <div class="product-img-wrapper">
        <img src="${p.img}" alt="${p.name}" class="product-img" loading="lazy">
        <div class="product-badge-stack">
          <span class="cert-badge">${p.cert}</span>
          ${p.discountPct > 0 ? `<span class="discount-badge">-${p.discountPct}%</span>` : ''}
          ${p.isClearance ? `<span class="clearance-badge">Thanh lý BR-BAT-04</span>` : ''}
        </div>
        <span class="stock-status-tag">Còn: ${p.stock} ${p.unit}</span>
      </div>
      <div class="product-info">
        <span class="product-category-lbl">${p.categoryName}</span>
        <h4 class="product-title" onclick="openProductDetails(${p.id})">${p.name}</h4>
        <div class="product-meta-sub">
          <span>🌱 ${p.origin}</span>
        </div>
        <div class="product-pricing-row">
          <div>
            <span class="price-main">${formatVND(p.price)}</span>
            <span class="price-unit">/ ${p.unit}</span>
            ${p.originalPrice > p.price ? `<span class="price-original">${formatVND(p.originalPrice)}</span>` : ''}
          </div>
        </div>
        <div class="product-actions-row">
          <button class="btn-secondary" onclick="openProductDetails(${p.id})">Chi tiết</button>
          <button class="btn-primary" onclick="addToCart(${p.id}, 1)">+ Thêm giỏ</button>
        </div>
      </div>
    </div>
  `).join('');
}

function openProductDetails(productId) {
  const p = State.products.find(item => item.id === productId);
  if (!p) return;

  const modal = document.getElementById('productDetailModal');
  const body = document.getElementById('productDetailBody');
  body.innerHTML = `
    <div style="display: grid; grid-template-columns: 1fr 1.2fr; gap: 20px;">
      <div>
        <img src="${p.img}" style="width: 100%; height: 240px; object-fit: cover; border-radius: 12px;">
        <div style="margin-top: 10px; display: flex; gap: 6px; flex-wrap: wrap;">
          <span class="cert-badge">Chứng nhận: ${p.cert}</span>
          ${p.isClearance ? `<span class="clearance-badge">Lô thanh lý cận hạn (-${p.discountPct}%)</span>` : ''}
        </div>
      </div>
      <div>
        <span class="product-category-lbl">${p.categoryName} (Mã: ${p.sku})</span>
        <h3 style="font-size: 18px; font-weight: 800; color: #0f172a; margin-bottom: 8px;">${p.name}</h3>
        <p style="font-size: 13px; color: #475569; margin-bottom: 12px; line-height: 1.5;">${p.desc}</p>
        
        <div style="background: #f8fafc; border: 1px solid #e2e8f0; border-radius: 8px; padding: 10px 14px; font-size: 13px; margin-bottom: 14px;">
          <div>🏡 <strong>Vùng trồng / Nguồn gốc:</strong> ${p.origin}</div>
          <div>🌾 <strong>Ngày thu hoạch:</strong> ${p.harvestDate}</div>
          <div>⏳ <strong>Hạn sử dụng lô:</strong> ${p.expDate}</div>
          <div>📦 <strong>Tồn kho lô hiện hành:</strong> <span style="color: #059669; font-weight: 700;">${p.stock} ${p.unit}</span></div>
        </div>

        <div style="display: flex; align-items: baseline; gap: 8px; margin-bottom: 16px;">
          <span style="font-size: 22px; font-weight: 800; color: #059669;">${formatVND(p.price)}</span>
          <span style="font-size: 13px; color: #64748b;">/ ${p.unit}</span>
          ${p.originalPrice > p.price ? `<span class="price-original" style="font-size: 14px;">${formatVND(p.originalPrice)}</span>` : ''}
        </div>

        <div style="display: flex; align-items: center; gap: 12px;">
          <label style="font-size: 13px; font-weight: 600;">Số lượng:</label>
          <div class="cart-qty-ctrl">
            <button class="cart-qty-btn" onclick="adjustModalQty(-1)">-</button>
            <input type="text" id="modalQtyInput" value="1" readonly class="cart-qty-val">
            <button class="cart-qty-btn" onclick="adjustModalQty(1, ${p.stock})">+</button>
          </div>
          <button class="btn-primary" style="flex: 1; padding: 10px;" onclick="addToCartFromModal(${p.id})">Thêm vào giỏ hàng</button>
        </div>
      </div>
    </div>
  `;

  modal.classList.add('active');
}

function adjustModalQty(delta, maxStock = 99) {
  const input = document.getElementById('modalQtyInput');
  if (!input) return;
  let val = parseInt(input.value) || 1;
  val += delta;
  if (val < 1) val = 1;
  if (val > maxStock) {
    val = maxStock;
    showToast(`Rất tiếc, kho chỉ còn tối đa ${maxStock} sản phẩm! (BR-ORD-01)`, 'warning');
  }
  input.value = val;
}

function addToCartFromModal(productId) {
  const input = document.getElementById('modalQtyInput');
  const qty = parseInt(input.value) || 1;
  addToCart(productId, qty);
  closeModal('productDetailModal');
}

function addToCart(productId, quantity) {
  const p = State.products.find(item => item.id === productId);
  if (!p) return;

  const existing = State.cart.find(c => c.productId === productId);
  const currentInCart = existing ? existing.quantity : 0;
  const newTotal = currentInCart + quantity;

  if (newTotal > p.stock) {
    showToast(`Rất tiếc, tồn kho vật lý của ${p.name} chỉ còn ${p.stock} ${p.unit}. Không thể thêm vượt quá!`, 'warning');
    if (existing) existing.quantity = p.stock;
    updateCartCount();
    return;
  }

  if (existing) {
    existing.quantity = newTotal;
  } else {
    State.cart.push({ productId, quantity });
  }

  updateCartCount();
  showToast(`Đã thêm ${quantity} ${p.unit} "${p.name}" vào giỏ hàng thành công!`);
}

// 2. UC-C05: Manage Profile & Addresses
function renderProfilePage() {
  document.getElementById('profName').value = State.user.name;
  document.getElementById('profPhone').value = State.user.phone;
  document.getElementById('profEmail').value = State.user.email;
  document.getElementById('profTierDisplay').textContent = State.user.tier;

  const addrContainer = document.getElementById('addressGrid');
  if (!addrContainer) return;

  addrContainer.innerHTML = State.addresses.map(a => `
    <div class="address-card ${a.isDefault ? 'default-address' : ''}">
      <div class="address-recipient">
        ${a.recipient}
        ${a.isDefault ? `<span class="tag-badge rank-badge" style="font-size: 10px;">Mặc định BR-AUTH-03</span>` : ''}
      </div>
      <div class="address-phone">📞 ${a.phone}</div>
      <div class="address-text">
        📍 ${a.street}, ${a.ward}, ${a.district}, ${a.city}<br>
        <span style="font-size: 11px; color: #64748b;">Khoảng cách từ HUB: <strong>${a.distance} km</strong> | Tọa độ: ${a.coords}</span>
      </div>
      <div class="address-card-actions">
        ${!a.isDefault ? `<button class="btn-secondary" style="font-size: 11px; padding: 4px 8px;" onclick="setDefaultAddress(${a.id})">Đặt làm mặc định</button>` : ''}
        <button class="btn-secondary" style="font-size: 11px; padding: 4px 8px;" onclick="openEditAddressModal(${a.id})">Chỉnh sửa</button>
        ${!a.isDefault ? `<button class="btn-danger" style="font-size: 11px; padding: 4px 8px;" onclick="deleteAddress(${a.id})">Xóa</button>` : ''}
      </div>
    </div>
  `).join('');
}

function saveProfileInfo(e) {
  if (e) e.preventDefault();
  const name = document.getElementById('profName').value.trim();
  const email = document.getElementById('profEmail').value.trim();
  if (!name) {
    showToast('Họ và tên không được để trống!', 'error');
    return;
  }
  State.user.name = name;
  State.user.email = email;
  document.getElementById('headerUserName').textContent = name;
  showToast('Thông tin cá nhân đã được cập nhật thành công!');
}

function setDefaultAddress(id) {
  State.addresses.forEach(a => a.isDefault = (a.id === id));
  renderProfilePage();
  showToast('Đã đặt làm địa chỉ giao hàng mặc định cho các đơn hàng tiếp theo (BR-AUTH-03).');
}

function deleteAddress(id) {
  if (confirm('Bạn có chắc chắn muốn xóa địa chỉ này khỏi sổ địa chỉ?')) {
    State.addresses = State.addresses.filter(a => a.id !== id);
    renderProfilePage();
    showToast('Đã xóa địa chỉ thành công.');
  }
}

function openAddAddressModal() {
  document.getElementById('addrModalTitle').textContent = 'Thêm Địa Chỉ Giao Hàng Mới';
  document.getElementById('addrForm').reset();
  document.getElementById('addrIdInput').value = '';
  document.getElementById('addressModal').classList.add('active');
}

function openEditAddressModal(id) {
  const a = State.addresses.find(item => item.id === id);
  if (!a) return;
  document.getElementById('addrModalTitle').textContent = 'Chỉnh Sửa Địa Chỉ Giao Hàng';
  document.getElementById('addrIdInput').value = a.id;
  document.getElementById('addrRecipient').value = a.recipient;
  document.getElementById('addrPhone').value = a.phone;
  document.getElementById('addrStreet').value = a.street;
  document.getElementById('addrWard').value = a.ward;
  document.getElementById('addrDistrict').value = a.district;
  document.getElementById('addrCity').value = a.city;
  document.getElementById('addrIsDefault').checked = a.isDefault;
  document.getElementById('addressModal').classList.add('active');
}

function saveAddress(e) {
  if (e) e.preventDefault();
  const id = document.getElementById('addrIdInput').value;
  const recipient = document.getElementById('addrRecipient').value.trim();
  const phone = document.getElementById('addrPhone').value.trim();
  const street = document.getElementById('addrStreet').value.trim();
  const ward = document.getElementById('addrWard').value.trim();
  const district = document.getElementById('addrDistrict').value.trim();
  const city = document.getElementById('addrCity').value.trim();
  const isDefault = document.getElementById('addrIsDefault').checked;

  const phoneRegex = /^0\d{9}$/;
  if (!phoneRegex.test(phone)) {
    showToast('Số điện thoại không hợp lệ! Vui lòng nhập đúng định dạng 10 chữ số (VD: 0912345678).', 'error');
    return;
  }

  if (isDefault) {
    State.addresses.forEach(a => a.isDefault = false);
  }

  if (id) {
    const a = State.addresses.find(item => item.id === parseInt(id));
    if (a) {
      a.recipient = recipient;
      a.phone = phone;
      a.street = street;
      a.ward = ward;
      a.district = district;
      a.city = city;
      a.isDefault = isDefault;
    }
    showToast('Địa chỉ giao hàng đã được cập nhật.');
  } else {
    const newId = State.addresses.length + 1;
    const simDistance = Math.floor(Math.random() * 50 + 12) / 10;
    State.addresses.push({
      id: newId,
      recipient,
      phone,
      street,
      ward,
      district,
      city,
      distance: simDistance,
      isDefault: isDefault || State.addresses.length === 0,
      coords: '21.0335° N, 105.8152° E'
    });
    showToast('Đã thêm địa chỉ mới thành công với tọa độ Google Maps Geocoding!');
  }

  closeModal('addressModal');
  renderProfilePage();
}

// 3. UC-C03: Manage Shopping Cart
function renderCartPage() {
  const tbody = document.getElementById('cartTableBody');
  const emptyBox = document.getElementById('cartEmptyView');
  const cartLayout = document.getElementById('cartActiveView');

  if (State.cart.length === 0) {
    if (emptyBox) emptyBox.style.display = 'block';
    if (cartLayout) cartLayout.style.display = 'none';
    return;
  }

  if (emptyBox) emptyBox.style.display = 'none';
  if (cartLayout) cartLayout.style.display = 'block';

  let subtotal = 0;
  let totalDiscount = 0;

  tbody.innerHTML = State.cart.map(item => {
    const p = State.products.find(prod => prod.id === item.productId);
    if (!p) return '';
    const lineTotal = p.price * item.quantity;
    const originalLineTotal = p.originalPrice * item.quantity;
    subtotal += originalLineTotal;
    totalDiscount += (originalLineTotal - lineTotal);

    return `
      <tr>
        <td>
          <div class="cart-item-info">
            <img src="${p.img}" class="cart-item-img">
            <div>
              <div style="font-weight: 700; color: #0f172a;">${p.name}</div>
              <div style="font-size: 12px; color: #64748b;">Đơn vị: ${p.unit} | Lô tồn kho: ${p.stock}</div>
              ${p.isClearance ? `<span class="clearance-badge" style="font-size: 10px;">Thanh lý -${p.discountPct}%</span>` : ''}
            </div>
          </div>
        </td>
        <td>
          <div style="font-weight: 600;">${formatVND(p.price)}</div>
          ${p.originalPrice > p.price ? `<div class="price-original">${formatVND(p.originalPrice)}</div>` : ''}
        </td>
        <td>
          <div class="cart-qty-ctrl">
            <button class="cart-qty-btn" onclick="changeCartItemQty(${p.id}, -1)">-</button>
            <span class="cart-qty-val">${item.quantity}</span>
            <button class="cart-qty-btn" onclick="changeCartItemQty(${p.id}, 1)">+</button>
          </div>
        </td>
        <td style="font-weight: 800; color: #059669;">
          ${formatVND(lineTotal)}
        </td>
        <td>
          <button class="btn-danger" style="padding: 4px 10px; font-size: 12px;" onclick="removeCartItem(${p.id})">✕ Bỏ</button>
        </td>
      </tr>
    `;
  }).join('');

  const finalTotal = subtotal - totalDiscount;
  document.getElementById('cartSubtotal').textContent = formatVND(subtotal);
  document.getElementById('cartDiscount').textContent = `-${formatVND(totalDiscount)}`;
  document.getElementById('cartTotal').textContent = formatVND(finalTotal);
}

function changeCartItemQty(productId, delta) {
  const item = State.cart.find(c => c.productId === productId);
  const p = State.products.find(prod => prod.id === productId);
  if (!item || !p) return;

  const newQty = item.quantity + delta;
  if (newQty <= 0) {
    removeCartItem(productId);
    return;
  }

  if (newQty > p.stock) {
    showToast(`Kho chỉ còn ${p.stock} ${p.unit} cho sản phẩm này! Tự động giữ ở mức tối đa.`, 'warning');
    item.quantity = p.stock;
  } else {
    item.quantity = newQty;
  }

  updateCartCount();
  renderCartPage();
}

function removeCartItem(productId) {
  const p = State.products.find(prod => prod.id === productId);
  const name = p ? p.name : 'sản phẩm này';
  if (confirm(`Bạn có chắc chắn muốn bỏ "${name}" khỏi giỏ hàng?`)) {
    State.cart = State.cart.filter(c => c.productId !== productId);
    updateCartCount();
    renderCartPage();
    showToast('Đã xóa sản phẩm khỏi giỏ hàng.');
  }
}

function clearCart() {
  if (confirm('Bạn có chắc chắn muốn xóa toàn bộ sản phẩm trong giỏ hàng?')) {
    State.cart = [];
    updateCartCount();
    renderCartPage();
    showToast('Giỏ hàng đã được làm trống.');
  }
}

// 4. UC-C06: Checkout & Place Order
function renderCheckoutPage() {
  const defaultAddr = State.addresses.find(a => a.isDefault) || State.addresses[0];
  if (!defaultAddr) return;

  State.checkout.selectedAddressId = defaultAddr.id;
  updateCheckoutDistanceAndFee(defaultAddr);

  const addrSelect = document.getElementById('checkoutAddressSelect');
  if (addrSelect) {
    addrSelect.innerHTML = State.addresses.map(a => `
      <option value="${a.id}" ${a.id === defaultAddr.id ? 'selected' : ''}>
        ${a.recipient} — ${a.street}, ${a.ward} (${a.distance} km) ${a.isDefault ? '[Mặc định]' : ''}
      </option>
    `).join('');
  }

  renderCheckoutOrderReview();
}

function onCheckoutAddressChange(addrId) {
  const addr = State.addresses.find(a => a.id === parseInt(addrId));
  if (!addr) return;
  State.checkout.selectedAddressId = addr.id;
  updateCheckoutDistanceAndFee(addr);
}

function updateCheckoutDistanceAndFee(addr) {
  const dist = addr.distance;
  State.checkout.distanceKm = dist;

  const card = document.getElementById('radiusCheckCard');
  const msg = document.getElementById('radiusCheckMsg');
  const btn = document.getElementById('btnSubmitOrder');

  if (dist > 10.0) {
    State.checkout.isRadiusValid = false;
    card.className = 'radius-check-card radius-exceeded';
    msg.innerHTML = `⚠️ <strong>Vượt quá bán kính phục vụ:</strong> Khoảng cách từ FreshFood Hub đến địa chỉ của bạn là <strong>${dist} km</strong> (vượt hạn mức 10 km theo <code>BR-DEL-01</code>). Quý khách vui lòng chọn địa chỉ khác trong phạm vi 10km!`;
    if (btn) {
      btn.disabled = true;
      btn.style.opacity = '0.5';
      btn.style.cursor = 'not-allowed';
    }
  } else {
    State.checkout.isRadiusValid = true;
    card.className = 'radius-check-card';
    msg.innerHTML = `✓ <strong>Phù hợp bán kính giao hàng:</strong> Khoảng cách đo lường bởi Google Maps Distance Matrix là <strong>${dist} km</strong> (nằm trong phạm vi bán kính phục vụ $\\le 10\\text{ km}$ của cửa hàng).`;
    if (btn) {
      btn.disabled = false;
      btn.style.opacity = '1';
      btn.style.cursor = 'pointer';
    }
  }

  let fee = 20000;
  if (dist < 1.0) fee = 10000;
  else if (dist >= 1.0 && dist < 3.0) fee = 20000;
  else if (dist >= 3.0 && dist <= 10.0) fee = 30000;
  else fee = 0;

  State.checkout.shippingFee = fee;
  renderCheckoutOrderReview();
}

function selectPaymentMethod(method) {
  State.checkout.paymentMethod = method;
  document.querySelectorAll('.payment-option-card').forEach(c => {
    c.classList.toggle('selected', c.dataset.method === method);
  });

  const vietqrBox = document.getElementById('vietqrBox');
  if (method === 'vietqr') {
    vietqrBox.classList.add('active');
    startVietQRCountdown();
  } else {
    vietqrBox.classList.remove('active');
    clearInterval(State.checkout.vietqrTimer);
  }
}

function startVietQRCountdown() {
  clearInterval(State.checkout.vietqrTimer);
  State.checkout.vietqrSeconds = 900;
  const timerDisplay = document.getElementById('vietqrTimerTxt');

  State.checkout.vietqrTimer = setInterval(() => {
    State.checkout.vietqrSeconds--;
    if (State.checkout.vietqrSeconds <= 0) {
      clearInterval(State.checkout.vietqrTimer);
      timerDisplay.textContent = 'Mã QR đã hết hạn! Vui lòng tải lại.';
      return;
    }
    const mins = Math.floor(State.checkout.vietqrSeconds / 60);
    const secs = State.checkout.vietqrSeconds % 60;
    timerDisplay.textContent = `Hết hạn sau: ${mins.toString().padStart(2, '0')}:${secs.toString().padStart(2, '0')}`;
  }, 1000);
}

function simulateSePayWebhook() {
  showToast('Đang kết nối SePay Webhook và kiểm tra giao dịch ngân hàng...', 'warning');
  setTimeout(() => {
    showToast('✓ Webhook SePay: Nhận tiền thành công! Đơn hàng đã chuyển trạng thái PAID.', 'success');
    submitOrderSuccess(true);
  }, 1200);
}

function renderCheckoutOrderReview() {
  const container = document.getElementById('checkoutReviewItems');
  if (!container) return;

  let subtotal = 0;
  container.innerHTML = State.cart.map(item => {
    const p = State.products.find(prod => prod.id === item.productId);
    if (!p) return '';
    const lineTotal = p.price * item.quantity;
    subtotal += lineTotal;
    return `
      <div style="display: flex; justify-content: space-between; margin-bottom: 8px; font-size: 13px;">
        <span>${p.name} × <strong>${item.quantity}</strong></span>
        <span>${formatVND(lineTotal)}</span>
      </div>
    `;
  }).join('');

  const shipping = State.checkout.shippingFee;
  const grandTotal = subtotal + shipping;

  document.getElementById('checkoutSubtotal').textContent = formatVND(subtotal);
  document.getElementById('checkoutShippingFee').textContent = formatVND(shipping);
  document.getElementById('checkoutGrandTotal').textContent = formatVND(grandTotal);
}

function submitOrder() {
  if (!State.checkout.isRadiusValid) {
    showToast('Không thể đặt hàng do địa chỉ vượt quá bán kính 10km! (BR-DEL-01)', 'error');
    return;
  }

  if (State.cart.length === 0) {
    showToast('Giỏ hàng trống! Vui lòng chọn sản phẩm trước khi thanh toán.', 'error');
    return;
  }

  if (State.checkout.paymentMethod === 'vietqr') {
    showToast('Vui lòng quét mã VietQR và xác nhận chuyển khoản để hoàn tất đơn hàng!', 'warning');
    return;
  }

  submitOrderSuccess(false);
}

function submitOrderSuccess(isPaidByQR) {
  const addr = State.addresses.find(a => a.id === State.checkout.selectedAddressId) || State.addresses[0];
  const newOrderId = `FF-20261023-${Math.floor(Math.random() * 800 + 100)}`;

  let subtotal = 0;
  const orderItems = State.cart.map(item => {
    const p = State.products.find(prod => prod.id === item.productId);
    const lineTotal = p.price * item.quantity;
    subtotal += lineTotal;
    p.stock -= item.quantity;
    return {
      name: p.name,
      qty: item.quantity,
      price: p.price,
      total: lineTotal
    };
  });

  const newOrder = {
    id: newOrderId,
    date: '23/10/2026 ' + new Date().toLocaleTimeString('vi-VN', { hour: '2-digit', minute: '2-digit' }),
    status: isPaidByQR ? 'confirmed' : 'pending',
    statusName: isPaidByQR ? 'Đã xác nhận' : 'Chờ xác nhận',
    total: subtotal + State.checkout.shippingFee,
    items: orderItems,
    shippingFee: State.checkout.shippingFee,
    paymentMethod: isPaidByQR ? 'VietQR Banking Transfer' : 'COD (Thanh toán khi nhận hàng)',
    paymentStatus: isPaidByQR ? 'Đã thanh toán (SePay Webhook Verified)' : 'Chưa thanh toán (Thu COD)',
    address: `${addr.street}, ${addr.ward}, ${addr.district}, ${addr.city}`,
    canCancel: true,
    canReview: false,
    isReviewed: false
  };

  State.orders.unshift(newOrder);
  State.cart = [];
  updateCartCount();

  document.getElementById('confirmOrderId').textContent = newOrderId;
  document.getElementById('confirmOrderTotal').textContent = formatVND(newOrder.total);
  document.getElementById('confirmOrderAddress').textContent = newOrder.address;
  document.getElementById('confirmOrderPayment').textContent = newOrder.paymentMethod;
  document.getElementById('orderConfirmationModal').classList.add('active');
}

// 5. UC-C07: Manage My Orders
let currentOrderTab = 'all';

function renderOrdersPage() {
  const container = document.getElementById('ordersListContainer');
  if (!container) return;

  const filtered = State.orders.filter(o => {
    if (currentOrderTab === 'all') return true;
    return o.status === currentOrderTab;
  });

  if (filtered.length === 0) {
    container.innerHTML = `
      <div style="text-align: center; padding: 40px; background: #ffffff; border-radius: 12px; border: 1px dashed #cbd5e1;">
        <div style="font-size: 36px; margin-bottom: 10px;">📦</div>
        <h4 style="font-size: 16px; color: #475569;">Không có đơn hàng nào trong mục này</h4>
      </div>
    `;
    return;
  }

  container.innerHTML = filtered.map(o => `
    <div class="order-history-card">
      <div class="order-card-header">
        <div>
          <span class="order-id-txt">#${o.id}</span>
          <span style="font-size: 12px; color: #64748b; margin-left: 10px;">🕒 ${o.date}</span>
        </div>
        <span class="status-badge status-${o.status}">${o.statusName}</span>
      </div>

      <div style="display: grid; grid-template-columns: 2fr 1fr; gap: 16px; margin-bottom: 14px;">
        <div>
          <div style="font-size: 13px; color: #334155; margin-bottom: 6px;">
            📍 <strong>Địa chỉ giao:</strong> ${o.address}
          </div>
          <div style="font-size: 13px; color: #334155;">
            💳 <strong>Thanh toán:</strong> ${o.paymentMethod} (${o.paymentStatus})
          </div>
          <div style="margin-top: 8px; font-size: 12px; color: #64748b;">
            Sản phẩm: ${o.items.map(i => `${i.name} (×${i.qty})`).join(', ')}
          </div>
        </div>
        <div style="text-align: right; display: flex; flex-direction: column; justify-content: center;">
          <div style="font-size: 12px; color: #64748b;">Tổng thanh toán</div>
          <div style="font-size: 18px; font-weight: 800; color: #059669;">${formatVND(o.total)}</div>
        </div>
      </div>

      <div style="display: flex; gap: 8px; justify-content: flex-end; border-top: 1px solid #f1f5f9; padding-top: 12px;">
        <button class="btn-secondary" onclick="openOrderTimeline('${o.id}')">Xem lộ trình & Chi tiết</button>
        ${o.canCancel ? `<button class="btn-danger" onclick="cancelOrder('${o.id}')">Hủy đơn hàng</button>` : ''}
        ${o.status === 'shipping' ? `<button class="btn-secondary" disabled style="opacity: 0.6; cursor: not-allowed;" title="Không thể hủy khi đang giao hàng (BR-ORD-04)">Đang giao (Không thể hủy)</button>` : ''}
        ${o.status === 'delivered' ? `<button class="btn-primary" onclick="reorderOrder('${o.id}')">Đặt lại đơn này (BR-RE-01)</button>` : ''}
        ${o.canReview && !o.isReviewed ? `<button class="btn-secondary" style="background: #fef3c7; border-color: #fde68a; color: #92400e;" onclick="openReviewModal('${o.id}')">⭐ Đánh giá 1-5 sao</button>` : ''}
        ${o.isReviewed ? `<span style="font-size: 12px; color: #059669; font-weight: 600; display: flex; align-items: center;">✓ Đã đánh giá ${o.reviewStars}★</span>` : ''}
      </div>
    </div>
  `).join('');
}

function filterOrderTab(tab) {
  currentOrderTab = tab;
  document.querySelectorAll('.order-tab-btn').forEach(btn => {
    btn.classList.toggle('active', btn.dataset.tab === tab);
  });
  renderOrdersPage();
}

function openOrderTimeline(orderId) {
  const order = State.orders.find(o => o.id === orderId);
  if (!order) return;

  const modal = document.getElementById('orderDetailModal');
  const body = document.getElementById('orderDetailBody');

  const steps = [
    { key: 'pending', name: 'Đặt hàng' },
    { key: 'confirmed', name: 'Xác nhận' },
    { key: 'packing', name: 'Đóng gói' },
    { key: 'shipping', name: 'Đang giao' },
    { key: 'delivered', name: 'Thành công' }
  ];

  let currentStepIdx = 0;
  if (order.status === 'confirmed') currentStepIdx = 1;
  if (order.status === 'packing') currentStepIdx = 2;
  if (order.status === 'shipping') currentStepIdx = 3;
  if (order.status === 'delivered') currentStepIdx = 4;

  body.innerHTML = `
    <div style="margin-bottom: 20px;">
      <div style="display: flex; justify-content: space-between; margin-bottom: 10px;">
        <div><strong>Mã đơn hàng:</strong> #${order.id}</div>
        <span class="status-badge status-${order.status}">${order.statusName}</span>
      </div>
      <div style="font-size: 13px; color: #64748b;">Thời gian đặt: ${order.date}</div>
    </div>

    ${order.status !== 'cancelled' ? `
      <div class="order-timeline">
        ${steps.map((st, idx) => `
          <div class="timeline-step ${idx <= currentStepIdx ? 'completed' : ''} ${idx === currentStepIdx ? 'active' : ''}">
            <div class="timeline-dot">${idx < currentStepIdx ? '✓' : (idx + 1)}</div>
            <div class="timeline-lbl">${st.name}</div>
          </div>
        `).join('')}
      </div>
    ` : `
      <div style="background: #ffe4e6; border: 1px solid #fecdd3; padding: 12px; border-radius: 8px; color: #9f1239; font-size: 13px; margin-bottom: 16px;">
        ⚠️ <strong>Đơn hàng đã hủy:</strong> Toàn bộ tồn kho lô vật lý đã được hoàn trả lại hệ thống theo quy định BR-ORD-04.
        ${order.cancelReason ? `<div style="margin-top: 4px;">Lý do: ${order.cancelReason}</div>` : ''}
      </div>
    `}

    <h4 style="font-size: 14px; font-weight: 700; margin: 16px 0 8px 0;">Chi tiết nông sản trong đơn:</h4>
    <div style="border: 1px solid #e2e8f0; border-radius: 8px; overflow: hidden; margin-bottom: 16px;">
      <table style="width: 100%; border-collapse: collapse; font-size: 13px;">
        <thead style="background: #f8fafc;">
          <tr>
            <th style="padding: 8px 12px; text-align: left;">Sản phẩm</th>
            <th style="padding: 8px 12px; text-align: center;">SL</th>
            <th style="padding: 8px 12px; text-align: right;">Đơn giá</th>
            <th style="padding: 8px 12px; text-align: right;">Thành tiền</th>
          </tr>
        </thead>
        <tbody>
          ${order.items.map(i => `
            <tr style="border-top: 1px solid #e2e8f0;">
              <td style="padding: 8px 12px;">${i.name}</td>
              <td style="padding: 8px 12px; text-align: center;">${i.qty}</td>
              <td style="padding: 8px 12px; text-align: right;">${formatVND(i.price)}</td>
              <td style="padding: 8px 12px; text-align: right; font-weight: 600;">${formatVND(i.total)}</td>
            </tr>
          `).join('')}
        </tbody>
      </table>
    </div>

    <div style="background: #f8fafc; border-radius: 8px; padding: 12px; font-size: 13px;">
      <div style="display: flex; justify-content: space-between; margin-bottom: 4px;">
        <span>Phí vận chuyển giao hàng:</span>
        <span>${formatVND(order.shippingFee)}</span>
      </div>
      <div style="display: flex; justify-content: space-between; font-size: 15px; font-weight: 800; color: #059669; border-top: 1px dashed #cbd5e1; padding-top: 6px; margin-top: 6px;">
        <span>Tổng thanh toán:</span>
        <span>${formatVND(order.total)}</span>
      </div>
    </div>
  `;

  modal.classList.add('active');
}

function cancelOrder(orderId) {
  const order = State.orders.find(o => o.id === orderId);
  if (!order) return;

  if (order.status === 'packing' || order.status === 'shipping' || order.status === 'delivered') {
    showToast('Đơn hàng đang xử lý đóng gói hoặc đang vận chuyển nên không thể tự hủy trên ứng dụng! (BR-ORD-04)', 'error');
    return;
  }

  const reason = prompt('Vui lòng nhập lý do hủy đơn hàng:', 'Thay đổi kế hoạch mua sắm');
  if (reason !== null) {
    order.status = 'cancelled';
    order.statusName = 'Đã hủy';
    order.canCancel = false;
    order.cancelReason = reason;

    order.items.forEach(item => {
      const p = State.products.find(prod => prod.name === item.name);
      if (p) p.stock += item.qty;
    });

    renderOrdersPage();
    showToast(`Đã hủy đơn hàng #${orderId} và tự động hoàn trả số lượng tồn kho theo quy định BR-ORD-04.`, 'warning');
  }
}

function reorderOrder(orderId) {
  const order = State.orders.find(o => o.id === orderId);
  if (!order) return;

  let addedCount = 0;
  order.items.forEach(item => {
    const p = State.products.find(prod => prod.name === item.name);
    if (p && p.stock > 0) {
      const existing = State.cart.find(c => c.productId === p.id);
      const addQty = Math.min(item.qty, p.stock);
      if (existing) existing.quantity += addQty;
      else State.cart.push({ productId: p.id, quantity: addQty });
      addedCount++;
    }
  });

  updateCartCount();
  showToast(`Đã thêm ${addedCount} mặt hàng từ đơn #${orderId} vào giỏ theo giá và tồn kho hiện hành (BR-RE-01)!`);
  switchScreen('screen-uc-c03');
}

function openReviewModal(orderId) {
  document.getElementById('reviewOrderIdInput').value = orderId;
  document.getElementById('reviewStarsInput').value = '5';
  updateStarDisplay(5);
  document.getElementById('reviewComment').value = '';
  document.getElementById('reviewModal').classList.add('active');
}

function setRating(stars) {
  document.getElementById('reviewStarsInput').value = stars;
  updateStarDisplay(stars);
}

function updateStarDisplay(stars) {
  const btns = document.querySelectorAll('.star-rating-btn');
  btns.forEach((btn, idx) => {
    btn.style.color = (idx < stars) ? '#f59e0b' : '#cbd5e1';
  });
}

function submitReview() {
  const orderId = document.getElementById('reviewOrderIdInput').value;
  const stars = parseInt(document.getElementById('reviewStarsInput').value) || 5;
  const comment = document.getElementById('reviewComment').value.trim();

  const order = State.orders.find(o => o.id === orderId);
  if (order) {
    order.isReviewed = true;
    order.reviewStars = stars;
    order.reviewComment = comment;
  }

  closeModal('reviewModal');
  renderOrdersPage();
  showToast(`Cảm ơn quý khách đã gửi đánh giá ${stars} sao cho đơn hàng #${orderId} (BR-FB-01)!`);
}

// 6. UC-M08: Manage Goods Receipts (Warehouse Staff)
function renderWarehousePage() {
  const table = document.getElementById('whReceiptItemsBody');
  if (!table) return;

  const dateInput = document.getElementById('whReceiptDate');
  if (dateInput && !dateInput.value) {
    dateInput.value = '2026-10-23';
  }
}

function addWhItemRow() {
  const tbody = document.getElementById('whReceiptItemsBody');
  const rowCount = tbody.children.length + 1;
  const tr = document.createElement('tr');

  tr.innerHTML = `
    <td>
      <select class="form-control wh-prod-select" onchange="recalcWhTotal()">
        ${State.products.map(p => `<option value="${p.id}">${p.sku} - ${p.name}</option>`).join('')}
      </select>
    </td>
    <td>
      <input type="text" class="form-control" value="LOT-20261023-DL0${rowCount}">
    </td>
    <td>
      <input type="date" class="form-control wh-mfg" value="2026-10-22">
    </td>
    <td>
      <input type="date" class="form-control wh-exp" value="2026-10-28" onchange="validateWhDates(this)">
    </td>
    <td>
      <input type="number" class="form-control wh-qty" value="50" min="1" onchange="recalcWhTotal()">
    </td>
    <td>
      <input type="number" class="form-control wh-price" value="22000" min="1000" step="500" onchange="recalcWhTotal()">
    </td>
    <td class="wh-line-total" style="font-weight: 700; color: #059669; vertical-align: middle;">
      ${formatVND(1100000)}
    </td>
    <td>
      <button class="btn-danger" style="padding: 4px 8px; font-size: 12px;" onclick="this.closest('tr').remove(); recalcWhTotal();">✕</button>
    </td>
  `;

  tbody.appendChild(tr);
  recalcWhTotal();
}

function validateWhDates(input) {
  const row = input.closest('tr');
  const mfg = new Date(row.querySelector('.wh-mfg').value);
  const exp = new Date(input.value);
  const today = new Date('2026-10-23');

  const minExp = new Date(today);
  minExp.setDate(minExp.getDate() + 3);

  if (exp <= mfg) {
    showToast('Lỗi: Hạn sử dụng (EXP) bắt buộc phải lớn hơn Ngày sản xuất (MFG)! (BR-GR-02)', 'error');
    input.style.borderColor = '#f43f5e';
    return false;
  }

  if (exp < minExp) {
    showToast('Lỗi: Nông sản tươi phải có hạn sử dụng tối thiểu 3 ngày kể từ ngày nhập kho! (BR-GR-02)', 'error');
    input.style.borderColor = '#f43f5e';
    return false;
  }

  input.style.borderColor = '#10b981';
  return true;
}

function recalcWhTotal() {
  const rows = document.querySelectorAll('#whReceiptItemsBody tr');
  let grand = 0;

  rows.forEach(r => {
    const qty = parseFloat(r.querySelector('.wh-qty')?.value) || 0;
    const price = parseFloat(r.querySelector('.wh-price')?.value) || 0;
    const line = qty * price;
    grand += line;
    const lineTd = r.querySelector('.wh-line-total');
    if (lineTd) lineTd.textContent = formatVND(line);
  });

  const totalDisplay = document.getElementById('whGrandTotal');
  if (totalDisplay) totalDisplay.textContent = formatVND(grand);
}

function submitGoodsReceipt() {
  const supplier = document.getElementById('whSupplierSelect').value;
  const invoice = document.getElementById('whInvoiceNo').value.trim();
  const date = document.getElementById('whReceiptDate').value;
  const isDelayed = document.getElementById('whDelayedToggle').checked;

  if (!invoice) {
    showToast('Vui lòng nhập số hóa đơn nhà cung cấp! (BR-GR-01)', 'error');
    return;
  }

  let allValid = true;
  document.querySelectorAll('#whReceiptItemsBody .wh-exp').forEach(expInput => {
    if (!validateWhDates(expInput)) allValid = false;
  });

  if (!allValid) {
    showToast('Vui lòng điều chỉnh hạn sử dụng tuân thủ quy tắc BR-GR-02!', 'error');
    return;
  }

  const receiptId = `GR-20261023-0${State.goodsReceipts.length + 1}`;
  const rows = document.querySelectorAll('#whReceiptItemsBody tr');

  const preview = document.getElementById('receiptInvoicePreview');
  preview.innerHTML = `
    <div style="text-align: center; border-bottom: 2px dashed #000; padding-bottom: 10px; margin-bottom: 12px;">
      <h3 style="font-size: 18px; margin: 0;">CỬA HÀNG NÔNG SẢN HỮU CƠ FRESHFOOD</h3>
      <div style="font-size: 12px;">120 Hoàng Hoa Thám, Ba Đình, Hà Nội | Hotline: 1900-6886</div>
      <h2 style="font-size: 16px; margin-top: 10px;">PHIẾU NHẬP KHO HÀNG HÓA & LÔ NÔNG SẢN</h2>
      <div style="font-size: 13px;">Mã phiếu: <strong>${receiptId}</strong> | Ngày nhập: ${date}</div>
    </div>
    
    <div style="font-size: 12px; margin-bottom: 10px;">
      <div>Nhà cung cấp: <strong>${supplier}</strong></div>
      <div>Hóa đơn đính kèm: <strong>${invoice}</strong></div>
      <div>Nhân viên phụ trách: <strong>Trần Văn Kho (Warehouse Staff)</strong></div>
      <div>Trạng thái bán khởi tạo: <strong>${isDelayed ? 'DELAYED (Chờ mở bán theo FEFO BR-BAT-03)' : 'ACTIVE (Đang mở bán)'}</strong></div>
    </div>

    <table style="width: 100%; border-collapse: collapse; font-size: 11px; margin-bottom: 12px;">
      <thead>
        <tr style="border-bottom: 1px solid #000;">
          <th style="text-align: left; padding: 4px;">Sản phẩm</th>
          <th style="text-align: left; padding: 4px;">Mã Lô</th>
          <th style="text-align: center; padding: 4px;">HSD</th>
          <th style="text-align: right; padding: 4px;">SL</th>
          <th style="text-align: right; padding: 4px;">Đơn giá</th>
          <th style="text-align: right; padding: 4px;">Thành tiền</th>
        </tr>
      </thead>
      <tbody>
        ${Array.from(rows).map(r => {
          const prodText = r.querySelector('.wh-prod-select option:checked')?.textContent || '';
          const batch = r.querySelector('input[type=text]')?.value || '';
          const exp = r.querySelector('.wh-exp')?.value || '';
          const qty = r.querySelector('.wh-qty')?.value || '';
          const price = parseFloat(r.querySelector('.wh-price')?.value) || 0;
          return `
            <tr style="border-bottom: 1px dashed #ccc;">
              <td style="padding: 4px;">${prodText.split('-')[1] || prodText}</td>
              <td style="padding: 4px;">${batch}</td>
              <td style="padding: 4px; text-align: center;">${exp}</td>
              <td style="padding: 4px; text-align: right;">${qty}</td>
              <td style="padding: 4px; text-align: right;">${formatVND(price)}</td>
              <td style="padding: 4px; text-align: right;">${formatVND(qty * price)}</td>
            </tr>
          `;
        }).join('')}
      </tbody>
    </table>

    <div style="text-align: right; font-size: 13px; font-weight: bold; border-top: 1px solid #000; padding-top: 6px;">
      TỔNG GIÁ TRỊ NHẬP KHO: ${document.getElementById('whGrandTotal').textContent}
    </div>

    <div style="display: grid; grid-template-columns: 1fr 1fr; margin-top: 24px; text-align: center; font-size: 12px;">
      <div>Người giao hàng (Ký tên)</div>
      <div>Thủ kho tiếp nhận (Đã ký)</div>
    </div>
  `;

  document.getElementById('goodsReceiptModal').classList.add('active');
  showToast(`Tạo phiếu nhập kho ${receiptId} thành công! Lô hàng đã được ghi nhận vào cơ sở dữ liệu.`, 'success');
}

function closeModal(modalId) {
  const modal = document.getElementById(modalId);
  if (modal) modal.classList.remove('active');
}

document.addEventListener('DOMContentLoaded', () => {
  document.querySelectorAll('.prototype-meta-btn').forEach(btn => {
    btn.addEventListener('click', () => {
      switchScreen(btn.dataset.screen);
    });
  });

  document.querySelectorAll('.cat-pill').forEach(pill => {
    pill.addEventListener('click', () => {
      document.querySelectorAll('.cat-pill').forEach(p => p.classList.remove('active'));
      pill.classList.add('active');
      State.activeCategory = pill.dataset.cat;
      renderCatalog();
    });
  });

  const clearanceCheck = document.getElementById('clearanceToggle');
  if (clearanceCheck) {
    clearanceCheck.addEventListener('change', (e) => {
      State.clearanceFilter = e.target.checked;
      renderCatalog();
    });
  }

  const searchInput = document.getElementById('storeSearchInput');
  if (searchInput) {
    searchInput.addEventListener('input', (e) => {
      State.searchQuery = e.target.value;
      if (State.activeScreen !== 'screen-uc-c01') {
        switchScreen('screen-uc-c01');
      } else {
        renderCatalog();
      }
    });
  }

  updateCartCount();
  const initialHash = window.location.hash ? window.location.hash.substring(1) : '';
  if (initialHash && document.getElementById(initialHash)) {
    switchScreen(initialHash);
  } else {
    switchScreen('screen-priority-overview');
  }
});
