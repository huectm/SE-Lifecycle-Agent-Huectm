/**
 * Design revision 2026-11-02: CategoryDto
 * Ownership: FreshFood-API.DTOs
 * + CategoryId: EntityId
 * + Name: string
 */
/** CategoryDto — FreshFood-API.DTOs; approved design source: detailed-class-model.json. */
export class CategoryDto {
  constructor(values = {}) {
    this.CategoryId = values.CategoryId;
    this.Name = values.Name;
  }
}
