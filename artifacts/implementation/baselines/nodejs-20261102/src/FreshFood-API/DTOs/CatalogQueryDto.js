/**
 * Design revision 2026-11-02: CatalogQueryDto
 * Ownership: FreshFood-API.DTOs
 * + Keyword: string?
 * + CategoryId: EntityId?
 * + ClearanceOnly: boolean
 */
/** CatalogQueryDto — FreshFood-API.DTOs; approved design source: detailed-class-model.json. */
export class CatalogQueryDto {
  constructor(values = {}) {
    this.Keyword = values.Keyword;
    this.CategoryId = values.CategoryId;
    this.ClearanceOnly = values.ClearanceOnly;
  }
}
