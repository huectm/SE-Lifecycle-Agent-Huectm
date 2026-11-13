/**
 * Design revision 2026-11-02: ProfileController
 * Ownership: FreshFood-API.Controllers
 * - service: IProfileService
 * + ProfileController(service: IProfileService)
 * + GetProfileAsync(signal: AbortSignal): Promise<ProfileResultDto>
 * + UpdateProfileAsync(request: ProfileUpdateDto, signal: AbortSignal): Promise<ProfileResultDto>
 * + SaveAddressAsync(request: AddressInputDto, signal: AbortSignal): Promise<AddressDto>
 * + SetDefaultAddressAsync(addressId: EntityId, signal: AbortSignal): Promise<ProfileResultDto>
 * + DeleteAddressAsync(addressId: EntityId, signal: AbortSignal): Promise<OperationResultDto>
 */
/** UC-C05: injected service contract; transport/authentication belongs to HTTP composition. */
export class ProfileController {
  constructor(service) { this.service = service; }
  async GetProfileAsync(signal) { return this.service.GetProfileAsync(signal); }
  async UpdateProfileAsync(request, signal) { return this.service.UpdateProfileAsync(request, signal); }
  async SaveAddressAsync(request, signal) { return this.service.SaveAddressAsync(request, signal); }
  async SetDefaultAddressAsync(addressId, signal) { return this.service.SetDefaultAddressAsync(addressId, signal); }
  async DeleteAddressAsync(addressId, signal) { return this.service.DeleteAddressAsync(addressId, signal); }
}
