namespace FreshFood.Reposistory.Entities;

public partial class ReturnReceiptItem
{
    public string ReturnReceiptItemId { get; set; } = string.Empty;
    public string ReturnReceiptId { get; set; } = string.Empty;
    public string OrderId { get; set; } = string.Empty;
    public string OrderDetailId { get; set; } = string.Empty;
    public int QuantityReceived { get; set; }
    public List<ReturnInspection> Inspections { get; set; } = [];
}
