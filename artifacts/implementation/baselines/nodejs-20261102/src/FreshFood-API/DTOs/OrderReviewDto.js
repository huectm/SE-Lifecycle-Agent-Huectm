/**
 * Design revision 2026-11-02: OrderReviewDto
 * Ownership: FreshFood-API.DTOs
 * + OrderId: EntityId
 * + Rating: number
 * + Comment: string?
 */
/** OrderReviewDto — FreshFood-API.DTOs; approved design source: detailed-class-model.json. */
export class OrderReviewDto {
  constructor(values = {}) {
    this.OrderId = values.OrderId;
    this.Rating = values.Rating;
    this.Comment = values.Comment;
  }
}
