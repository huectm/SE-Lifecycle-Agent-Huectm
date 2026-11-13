/**
 * Design revision 2026-11-02: CheckoutSummaryDto
 * Ownership: FreshFood-API.DTOs
 * + SubTotal: VndAmountString
 * + ShippingFee: VndAmountString
 * + DistanceKm: number
 * + Total: VndAmountString
 * + Lines: ReadonlyArray<CheckoutLineDto>
 */
/** CheckoutSummaryDto — FreshFood-API.DTOs; approved design source: detailed-class-model.json. */
export class CheckoutSummaryDto {
  constructor(values = {}) {
    this.SubTotal = values.SubTotal;
    this.ShippingFee = values.ShippingFee;
    this.DistanceKm = values.DistanceKm;
    this.Total = values.Total;
    this.Lines = values.Lines;
  }
}
