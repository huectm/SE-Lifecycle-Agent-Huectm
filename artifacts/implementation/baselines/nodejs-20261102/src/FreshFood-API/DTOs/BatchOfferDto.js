/**
 * Design revision 2026-11-02: BatchOfferDto
 * Ownership: FreshFood-API.DTOs
 * + BatchId: EntityId
 * + ExpiryDate: LocalDate
 * + Price: VndAmountString
 * + Clearance: boolean
 */
/** BatchOfferDto — FreshFood-API.DTOs; approved design source: detailed-class-model.json. */
export class BatchOfferDto {
  constructor(values = {}) {
    this.BatchId = values.BatchId;
    this.ExpiryDate = values.ExpiryDate;
    this.Price = values.Price;
    this.Clearance = values.Clearance;
  }
}
