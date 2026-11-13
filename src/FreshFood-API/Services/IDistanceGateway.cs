namespace FreshFood.Api.Services;

public interface IDistanceGateway
{
    Task<decimal> DrivingDistanceAsync(string addressId, CancellationToken signal);
}
