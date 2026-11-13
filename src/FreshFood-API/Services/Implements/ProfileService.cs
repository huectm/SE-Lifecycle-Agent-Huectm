using System.Text.RegularExpressions;

namespace FreshFood.Api.Services.Implements;

public sealed class ProfileService(IProfileRepository profileRepository, ICurrentCustomer currentCustomer, IUnitOfWork unitOfWork, IGeocodingGateway geocodingGateway) : IProfileService
{
    public async Task<ProfileResultDto> GetProfileAsync(CancellationToken signal)
    {
        var id = currentCustomer.RequireCustomerId(); var c = await profileRepository.GetCustomerAsync(id, signal);
        return new() { CustomerId = c.CustomerId, FullName = c.FullName, Phone = c.Phone, Email = c.Email, Addresses = (await profileRepository.GetAddressesAsync(id, signal)).Select(ServiceRules.Address).ToList() };
    }
    public async Task<ProfileResultDto> UpdateProfileAsync(ProfileUpdateDto request, CancellationToken signal)
    {
        var id = currentCustomer.RequireCustomerId(); var name = ServiceRules.Text(request.FullName);
        try
        {
            ServiceRules.Require(string.IsNullOrEmpty(request.Email) || Regex.IsMatch(request.Email, @"^[^\s@]+@[^\s@]+\.[^\s@]+$", RegexOptions.None, TimeSpan.FromMilliseconds(100)), "INVALID_EMAIL");
        }
        catch (RegexMatchTimeoutException)
        {
            throw new DomainException("INVALID_EMAIL");
        }
        await unitOfWork.ExecuteAsync(async ct => { var c = await profileRepository.GetCustomerAsync(id, ct); c.FullName = name; c.Email = string.IsNullOrEmpty(request.Email) ? null : request.Email; await profileRepository.SaveCustomerAsync(c, ct); }, signal);
        return await GetProfileAsync(signal);
    }
    public async Task<AddressDto> SaveAddressAsync(AddressInputDto request, CancellationToken signal)
    {
        var id = currentCustomer.RequireCustomerId(); var name = ServiceRules.Text(request.RecipientName); var phone = ServiceRules.Text(request.RecipientPhone); var street = ServiceRules.Text(request.StreetAddress);
        try
        {
            ServiceRules.Require(Regex.IsMatch(phone, @"^\+?[0-9]{9,15}$", RegexOptions.None, TimeSpan.FromMilliseconds(100)), "INVALID_PHONE");
        }
        catch (RegexMatchTimeoutException)
        {
            throw new DomainException("INVALID_PHONE");
        }
        var geo = await geocodingGateway.ResolveAsync(street, signal);
        ServiceRules.Require(Math.Abs(geo.Latitude) <= 90 && Math.Abs(geo.Longitude) <= 180, "INVALID_ADDRESS_COORDINATES", 422);
        return await unitOfWork.ExecuteAsync(async ct =>
        {
            if (!string.IsNullOrEmpty(request.AddressId) && !(await profileRepository.GetAddressesAsync(id, ct)).Any(a => a.AddressId == request.AddressId)) throw new DomainException("NOT_FOUND", 404);
            var entity = new CustomerAddress { AddressId = request.AddressId ?? "", CustomerId = id, RecipientName = name, RecipientPhone = phone, StreetAddress = street, Latitude = geo.Latitude, Longitude = geo.Longitude, IsDefault = request.IsDefault ?? false };
            await profileRepository.SaveAddressAsync(entity, ct); return ServiceRules.Address(entity);
        }, signal);
    }
    public async Task<ProfileResultDto> SetDefaultAddressAsync(string addressId, CancellationToken signal)
    {
        var id = currentCustomer.RequireCustomerId(); ServiceRules.Id(addressId);
        await unitOfWork.ExecuteAsync(async ct => { var a = (await profileRepository.GetAddressesAsync(id, ct)).SingleOrDefault(a => a.AddressId == addressId) ?? throw new DomainException("NOT_FOUND", 404); a.IsDefault = true; await profileRepository.SaveAddressAsync(a, ct); }, signal);
        return await GetProfileAsync(signal);
    }
    public async Task<OperationResultDto> DeleteAddressAsync(string addressId, CancellationToken signal)
    {
        var id = currentCustomer.RequireCustomerId(); ServiceRules.Id(addressId);
        await unitOfWork.ExecuteAsync(async ct =>
        {
            ServiceRules.Require((await profileRepository.GetAddressesAsync(id, ct)).Any(a => a.AddressId == addressId), "NOT_FOUND", 404);
            ServiceRules.Require(!await profileRepository.HasActiveOrderAsync(id, addressId, ct), "ADDRESS_USED_BY_ACTIVE_ORDER", 409);
            await profileRepository.DeleteAddressAsync(id, addressId, ct);
        }, signal);
        return new() { Success = true, MessageCode = "ADDRESS_DELETED" };
    }
}
