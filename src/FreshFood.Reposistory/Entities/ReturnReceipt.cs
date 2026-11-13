namespace FreshFood.Reposistory.Entities;

public partial class ReturnReceipt
{
    public string ReturnReceiptId { get; set; } = string.Empty;
    public string OrderId { get; set; } = string.Empty;
    public string ReceiptStatus { get; set; } = string.Empty;
    public int CreatedByStaffId { get; set; }
    public DateTimeOffset CreatedAt { get; set; }
    public int ConfirmedByStaffId { get; set; }
    public DateTimeOffset ConfirmedAt { get; set; }
    public List<ReturnReceiptItem> Items { get; set; } = [];
}
