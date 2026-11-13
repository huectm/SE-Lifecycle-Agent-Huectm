namespace FreshFood.Reposistory.Entities;

public partial class CartItem
{
    public string CartItemId { get; set; } = string.Empty;
    public string CartId { get; set; } = string.Empty;
    public string ProductId { get; set; } = string.Empty;
    public int Quantity { get; set; }
    public DateTimeOffset AddedAt { get; set; }
    public Product Product { get; set; } = default!;
}
