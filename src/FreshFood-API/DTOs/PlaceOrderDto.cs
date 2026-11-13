namespace FreshFood.Api.DTOs;

public class PlaceOrderDto
{
    public string AddressId { get; set; } = string.Empty;
    [JsonRequired]
    public PaymentMethod PaymentMethod { get; set; }
    public string CheckoutReference { get; set; } = string.Empty;
    public string IdempotencyKey { get; set; } = string.Empty;
}
