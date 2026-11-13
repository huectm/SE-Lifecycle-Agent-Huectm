using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace FreshFood.Api.Controllers;

[ApiController]
[Authorize]
public sealed class ProfileController(IProfileService service) : ControllerBase
{
    [HttpGet("/api/profile")]
    public Task<ProfileResultDto> GetProfileAsync(CancellationToken signal)
    {
        return service.GetProfileAsync(signal);
    }
    [HttpPatch("/api/profile")]
    public Task<ProfileResultDto> UpdateProfileAsync([FromBody] ProfileUpdateDto request, CancellationToken signal)
    {
        return service.UpdateProfileAsync(request, signal);
    }
    [HttpPost("/api/addresses")]
    public Task<AddressDto> SaveAddressAsync([FromBody] AddressInputDto request, CancellationToken signal)
    {
        return service.SaveAddressAsync(request, signal);
    }
    [HttpPut("/api/addresses/{addressId}")]
    public Task<AddressDto> UpdateAddressAsync(string addressId, [FromBody] AddressInputDto request, CancellationToken signal)
    {
        request.AddressId = addressId;
        return service.SaveAddressAsync(request, signal);
    }
    [HttpPut("/api/addresses/{addressId}/default")]
    public Task<ProfileResultDto> SetDefaultAddressAsync(string addressId, CancellationToken signal)
    {
        return service.SetDefaultAddressAsync(addressId, signal);
    }
    [HttpDelete("/api/addresses/{addressId}")]
    public Task<OperationResultDto> DeleteAddressAsync(string addressId, CancellationToken signal)
    {
        return service.DeleteAddressAsync(addressId, signal);
    }
}
