namespace FreshFood.Reposistory.Entities;

public partial class OrderDetail
{
    public string OrderDetailId { get; set; } = string.Empty;
    public string OrderId { get; set; } = string.Empty;
    public string BatchId { get; set; } = string.Empty;
    public int Quantity { get; set; }
    public VndAmount UnitPrice { get; set; } = default!;
    public VndAmount DiscountAmount { get; set; } = default!;
    public VndAmount LineTotal { get; set; } = default!;
    public BatchInventory Batch { get; set; } = default!;
}
