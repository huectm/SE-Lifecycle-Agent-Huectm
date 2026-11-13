namespace FreshFood.Api.Services;

public interface IGeocodingGateway
{
    Task<GeoPointDto> ResolveAsync(string address, CancellationToken signal);
}
