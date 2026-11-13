namespace FreshFood.Reposistory.Entities;

public partial class BatchInventory
{
    public string BatchId { get; set; } = string.Empty;
    public string ProductId { get; set; } = string.Empty;
    public string ReceiptId { get; set; } = string.Empty;
    public string BatchNumber { get; set; } = string.Empty;
    public DateOnly ManufactureDate { get; set; }
    public DateOnly ExpiryDate { get; set; }
    public int ImportQuantity { get; set; }
    public int CurrentStock { get; set; }
    public int ReservedStock { get; set; }
    public VndAmount ImportPrice { get; set; } = default!;
    public VndAmount RetailPrice { get; set; } = default!;
    public decimal DiscountRate { get; set; }
    public string SaleStatus { get; set; } = string.Empty;
}
