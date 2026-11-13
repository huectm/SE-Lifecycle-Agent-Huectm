/**
 * Design revision 2026-11-02: ProfileService
 * Ownership: FreshFood-API.Services.Implements
 * - profileRepository: IProfileRepository
 * - currentCustomer: ICurrentCustomer
 * - unitOfWork: IUnitOfWork
 * - geocodingGateway: IGeocodingGateway
 * + ProfileService(profileRepository: IProfileRepository, currentCustomer: ICurrentCustomer, unitOfWork: IUnitOfWork, geocodingGateway: IGeocodingGateway)
 * + GetProfileAsync(signal: AbortSignal): Promise<ProfileResultDto>
 * + UpdateProfileAsync(request: ProfileUpdateDto, signal: AbortSignal): Promise<ProfileResultDto>
 * + SaveAddressAsync(request: AddressInputDto, signal: AbortSignal): Promise<AddressDto>
 * + SetDefaultAddressAsync(addressId: EntityId, signal: AbortSignal): Promise<ProfileResultDto>
 * + DeleteAddressAsync(addressId: EntityId, signal: AbortSignal): Promise<OperationResultDto>
 */
import { id, owned, text, requireValue, addressDto } from './shared.js';
export class ProfileService {
  constructor(profileRepository,currentCustomer,unitOfWork,geocodingGateway) { Object.assign(this,{profileRepository,currentCustomer,unitOfWork,geocodingGateway}); }
  async GetProfileAsync(signal) { const customerId=this.currentCustomer.RequireCustomerId();const c=owned(await this.profileRepository.GetCustomerAsync(customerId,signal));return {CustomerId:c.CustomerId,FullName:c.FullName,Phone:c.Phone,Email:c.Email,Addresses:(await this.profileRepository.GetAddressesAsync(customerId,signal)).map(addressDto)}; }
  async UpdateProfileAsync(request,signal) {
    const customerId=this.currentCustomer.RequireCustomerId();const name=text(request.FullName);requireValue(request.Email==null||request.Email===''||/^[^\s@]+@[^\s@]+\.[^\s@]+$/.test(request.Email),'INVALID_EMAIL');
    await this.unitOfWork.ExecuteAsync(async()=>{const customer=owned(await this.profileRepository.GetCustomerAsync(customerId,signal));await this.profileRepository.SaveCustomerAsync({...customer,FullName:name,Email:request.Email||null},signal);},signal);return this.GetProfileAsync(signal);
  }
  async SaveAddressAsync(request,signal) {
    const customerId=this.currentCustomer.RequireCustomerId();const input={...request,CustomerId:customerId,RecipientName:text(request.RecipientName),RecipientPhone:text(request.RecipientPhone),StreetAddress:text(request.StreetAddress),IsDefault:request.IsDefault===true};
    requireValue(/^\+?[0-9]{9,15}$/.test(input.RecipientPhone),'INVALID_PHONE');
    const geo=await this.geocodingGateway.ResolveAsync(input.StreetAddress,signal);requireValue(Number.isFinite(geo?.Latitude)&&Math.abs(geo.Latitude)<=90&&Number.isFinite(geo?.Longitude)&&Math.abs(geo.Longitude)<=180,'INVALID_ADDRESS_COORDINATES',422);
    return this.unitOfWork.ExecuteAsync(async()=>{const addresses=await this.profileRepository.GetAddressesAsync(customerId,signal);if(input.AddressId)owned(addresses.find(a=>a.AddressId===id(input.AddressId)));const entity={...input,...geo};await this.profileRepository.SaveAddressAsync(entity,signal);return addressDto(entity);},signal);
  }
  async SetDefaultAddressAsync(addressId,signal) { const customerId=this.currentCustomer.RequireCustomerId();id(addressId);await this.unitOfWork.ExecuteAsync(async()=>{const a=owned((await this.profileRepository.GetAddressesAsync(customerId,signal)).find(a=>a.AddressId===addressId));await this.profileRepository.SaveAddressAsync({...a,IsDefault:true},signal);},signal);return this.GetProfileAsync(signal); }
  async DeleteAddressAsync(addressId,signal) { const customerId=this.currentCustomer.RequireCustomerId();id(addressId);await this.unitOfWork.ExecuteAsync(async()=>{owned((await this.profileRepository.GetAddressesAsync(customerId,signal)).find(a=>a.AddressId===addressId));requireValue(!await this.profileRepository.HasActiveOrderAsync(customerId,addressId,signal),'ADDRESS_USED_BY_ACTIVE_ORDER',409);await this.profileRepository.DeleteAddressAsync(customerId,addressId,signal);},signal);return {Success:true,MessageCode:'ADDRESS_DELETED'}; }
}
