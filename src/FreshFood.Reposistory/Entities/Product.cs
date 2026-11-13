namespace FreshFood.Reposistory.Entities;

public partial class Product
{
    public string ProductId { get; set; } = string.Empty;
    public int CategoryId { get; set; }
    public string Sku { get; set; } = string.Empty;
    public string ProductName { get; set; } = string.Empty;
    public string UnitOfMeasure { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string ImageUrl { get; set; } = string.Empty;
    public bool IsActive { get; set; }
    public DateTimeOffset CreatedAt { get; set; }
    public List<BatchInventory> Batches { get; set; } = [];
}
