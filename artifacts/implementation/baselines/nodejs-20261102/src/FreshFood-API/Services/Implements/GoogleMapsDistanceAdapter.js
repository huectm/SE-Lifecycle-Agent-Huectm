/**
 * Design revision 2026-11-02: GoogleMapsDistanceAdapter
 * Ownership: FreshFood-API.Services.Implements
 * - http: HttpTransport
 * + GoogleMapsDistanceAdapter(http: HttpTransport)
 * + DrivingDistanceAsync(addressId: EntityId, signal: AbortSignal): Promise<number>
 */
export class GoogleMapsDistanceAdapter {constructor(transport){this.transport=transport;}async DrivingDistanceAsync(addressId,signal){return this.transport.SendAsync('maps:distance',{AddressId:addressId},signal);} }
