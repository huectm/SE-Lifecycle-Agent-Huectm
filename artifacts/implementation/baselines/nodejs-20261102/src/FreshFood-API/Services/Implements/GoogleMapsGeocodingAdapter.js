/**
 * Design revision 2026-11-02: GoogleMapsGeocodingAdapter
 * Ownership: FreshFood-API.Services.Implements
 * - http: HttpTransport
 * + GoogleMapsGeocodingAdapter(http: HttpTransport)
 * + ResolveAsync(address: string, signal: AbortSignal): Promise<GeoPointDto>
 */
export class GoogleMapsGeocodingAdapter {constructor(transport){this.transport=transport;}async ResolveAsync(address,signal){return this.transport.SendAsync('maps:geocode',{Address:address},signal);} }
