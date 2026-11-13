/**
 * Design revision 2026-11-02: CartResultDto
 * Ownership: FreshFood-API.DTOs
 * + Lines: ReadonlyArray<CartLineDto>
 * + SubTotal: VndAmountString
 * + CanCheckout: boolean
 * + Warnings: ReadonlyArray<string>
 */
/** CartResultDto — FreshFood-API.DTOs; approved design source: detailed-class-model.json. */
export class CartResultDto {
  constructor(values = {}) {
    this.Lines = values.Lines;
    this.SubTotal = values.SubTotal;
    this.CanCheckout = values.CanCheckout;
    this.Warnings = values.Warnings;
  }
}
