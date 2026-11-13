namespace FreshFood.Api.DTOs;

public class OrderLineDto
{
    public string ProductName { get; set; } = string.Empty;
    public int Quantity { get; set; }
    public string UnitPrice { get; set; } = string.Empty;
    public string LineTotal { get; set; } = string.Empty;
}
