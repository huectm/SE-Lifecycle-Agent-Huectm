namespace FreshFood.Api.Services;

public interface IPayoutPort
{
    Task<PayoutOutcomeDto> RequestAsync(string refundId, CancellationToken signal);
}
