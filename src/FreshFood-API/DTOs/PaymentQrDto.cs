namespace FreshFood.Api.DTOs;

public class PaymentQrDto
{
    public string QrPayload { get; set; } = string.Empty;
    public DateTimeOffset ExpiresAt { get; set; }
}
