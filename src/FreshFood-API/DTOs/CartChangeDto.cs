namespace FreshFood.Api.DTOs;

public class CartChangeDto
{
    public string ProductId { get; set; } = string.Empty;
    [System.Text.Json.Serialization.JsonRequired]
    public int Quantity { get; set; }
}
