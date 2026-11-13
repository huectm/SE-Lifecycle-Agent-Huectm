namespace FreshFood.Api.DTOs;

public class GuardFactsDto
{
    public bool FirstOrder { get; set; }
    public bool PhoneConfirmed { get; set; }
    public bool VerifiedPayment { get; set; }
    public bool CompleteReceipt { get; set; }
    public string? ConfirmedCause { get; set; }
    public string CapturedGoods { get; set; } = string.Empty;
    public string CapturedShipping { get; set; } = string.Empty;
    public string SettledRefund { get; set; } = string.Empty;
}
