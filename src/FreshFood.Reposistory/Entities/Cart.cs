namespace FreshFood.Reposistory.Entities;

public partial class Cart
{
    public string CartId { get; set; } = string.Empty;
    public string CustomerId { get; set; } = string.Empty;
    public string SessionId { get; set; } = string.Empty;
    public DateTimeOffset CreatedAt { get; set; }
    public DateTimeOffset UpdatedAt { get; set; }
    public List<CartItem> Items { get; set; } = [];
}
