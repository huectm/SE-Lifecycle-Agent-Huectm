namespace FreshFood.Api.DTOs;

public class CheckoutLineDto
{
    public string ProductId { get; set; } = string.Empty;
    public string BatchId { get; set; } = string.Empty;
    public int Quantity { get; set; }
    public string UnitPrice { get; set; } = string.Empty;
    public string Discount { get; set; } = string.Empty;
}
