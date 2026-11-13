namespace FreshFood.Reposistory.Entities;

public partial class Order
{
    public string OrderId { get; set; } = string.Empty;
    public string OrderNumber { get; set; } = string.Empty;
    public string CustomerId { get; set; } = string.Empty;
    public string DeliveryAddressId { get; set; } = string.Empty;
    public int ProcessedByStaffId { get; set; }
    public DateTimeOffset OrderDate { get; set; }
    public VndAmount SubTotal { get; set; } = default!;
    public decimal DeliveryDistance { get; set; }
    public VndAmount ShippingFee { get; set; } = default!;
    public VndAmount TotalAmount { get; set; } = default!;
    public PaymentMethod PaymentMethod { get; set; }
    public PaymentStatus PaymentStatus { get; set; }
    public OrderStatus OrderStatus { get; set; }
    public bool IsFirstOrder { get; set; }
    public string DeliveryAgentId { get; set; } = string.Empty;
    public string PhoneConfirmationStatus { get; set; } = string.Empty;
    public int PhoneContactedByStaffId { get; set; }
    public DateTimeOffset PhoneContactedAt { get; set; }
    public string PhoneConfirmationNote { get; set; } = string.Empty;
    public string CancellationReason { get; set; } = string.Empty;
    public List<OrderDetail> Details { get; set; } = [];
    public Customer Customer { get; set; } = default!;
    public CustomerAddress DeliveryAddress { get; set; } = default!;
    public List<OrderPayment> Payments { get; set; } = [];
    public DeliveryFailure? Failure { get; set; }
    public ReturnReceipt? Return { get; set; }
    public Refund? Refund { get; set; }
}
