namespace FreshFood.Api.Services;

public interface IDistanceCalculator
{
    Task<decimal> CalculateAsync(string addressId, CancellationToken signal);
}
