/**
 * Design revision 2026-11-02: IProfileService
 * Ownership: FreshFood-API.Services
 * + GetProfileAsync(signal: AbortSignal): Promise<ProfileResultDto>
 * + UpdateProfileAsync(request: ProfileUpdateDto, signal: AbortSignal): Promise<ProfileResultDto>
 * + SaveAddressAsync(request: AddressInputDto, signal: AbortSignal): Promise<AddressDto>
 * + SetDefaultAddressAsync(addressId: EntityId, signal: AbortSignal): Promise<ProfileResultDto>
 * + DeleteAddressAsync(addressId: EntityId, signal: AbortSignal): Promise<OperationResultDto>
 */
/** IProfileService — FreshFood-API.Services; approved design source: detailed-class-model.json. */
export class IProfileService {
  async GetProfileAsync(signal) { throw Object.assign(new Error("IProfileService.GetProfileAsync: implementation or external port required"), { code: "DESIGN_PORT_UNCONFIGURED", status: 503 }); }
  async UpdateProfileAsync(request, signal) { throw Object.assign(new Error("IProfileService.UpdateProfileAsync: implementation or external port required"), { code: "DESIGN_PORT_UNCONFIGURED", status: 503 }); }
  async SaveAddressAsync(request, signal) { throw Object.assign(new Error("IProfileService.SaveAddressAsync: implementation or external port required"), { code: "DESIGN_PORT_UNCONFIGURED", status: 503 }); }
  async SetDefaultAddressAsync(addressId, signal) { throw Object.assign(new Error("IProfileService.SetDefaultAddressAsync: implementation or external port required"), { code: "DESIGN_PORT_UNCONFIGURED", status: 503 }); }
  async DeleteAddressAsync(addressId, signal) { throw Object.assign(new Error("IProfileService.DeleteAddressAsync: implementation or external port required"), { code: "DESIGN_PORT_UNCONFIGURED", status: 503 }); }
}
