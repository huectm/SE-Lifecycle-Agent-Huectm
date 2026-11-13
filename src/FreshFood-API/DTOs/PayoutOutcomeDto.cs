namespace FreshFood.Api.DTOs;

public class PayoutOutcomeDto
{
    public string Outcome { get; set; } = string.Empty;
    public string? ProviderReference { get; set; }
    public string? SettledAmount { get; set; }
}
