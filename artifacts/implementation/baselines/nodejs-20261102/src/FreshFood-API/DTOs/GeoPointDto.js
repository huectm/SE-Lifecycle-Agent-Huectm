/**
 * Design revision 2026-11-02: GeoPointDto
 * Ownership: FreshFood-API.DTOs
 * + Latitude: number
 * + Longitude: number
 */
/** GeoPointDto — FreshFood-API.DTOs; approved design source: detailed-class-model.json. */
export class GeoPointDto {
  constructor(values = {}) {
    this.Latitude = values.Latitude;
    this.Longitude = values.Longitude;
  }
}
