namespace FreshFood.Api.Services;

public interface IProfileService
{
    Task<ProfileResultDto> GetProfileAsync(CancellationToken signal);
    Task<ProfileResultDto> UpdateProfileAsync(ProfileUpdateDto request, CancellationToken signal);
    Task<AddressDto> SaveAddressAsync(AddressInputDto request, CancellationToken signal);
    Task<ProfileResultDto> SetDefaultAddressAsync(string addressId, CancellationToken signal);
    Task<OperationResultDto> DeleteAddressAsync(string addressId, CancellationToken signal);
}
