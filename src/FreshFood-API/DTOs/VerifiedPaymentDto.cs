namespace FreshFood.Api.DTOs;

public class VerifiedPaymentDto
{
    public string ProviderReference { get; set; } = string.Empty;
    public string CheckoutReference { get; set; } = string.Empty;
    public string GoodsAmount { get; set; } = string.Empty;
    public string ShippingAmount { get; set; } = string.Empty;
    public DateTimeOffset VerifiedAt { get; set; }
}
