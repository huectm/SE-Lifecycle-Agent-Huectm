/**
 * Design revision 2026-11-02: CatalogResultDto
 * Ownership: FreshFood-API.DTOs
 * + Items: ReadonlyArray<ProductSummaryDto>
 * + Categories: ReadonlyArray<CategoryDto>
 * + Alternatives: ReadonlyArray<ProductSummaryDto>
 */
/** CatalogResultDto — FreshFood-API.DTOs; approved design source: detailed-class-model.json. */
export class CatalogResultDto {
  constructor(values = {}) {
    this.Items = values.Items;
    this.Categories = values.Categories;
    this.Alternatives = values.Alternatives;
  }
}
