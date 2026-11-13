namespace FreshFood.Api.DTOs;

public class PaymentNoticeDto
{
    public string RawBody { get; set; } = string.Empty;
    public string Signature { get; set; } = string.Empty;
    public string ProviderReference { get; set; } = string.Empty;
}
