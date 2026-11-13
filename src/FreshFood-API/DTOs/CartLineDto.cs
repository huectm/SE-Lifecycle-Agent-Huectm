namespace FreshFood.Api.DTOs;

public class CartLineDto
{
    public string ProductId { get; set; } = string.Empty;
    public int Quantity { get; set; }
    public int AvailableQuantity { get; set; }
    public string CurrentPrice { get; set; } = string.Empty;
    public string LineTotal { get; set; } = string.Empty;
}
