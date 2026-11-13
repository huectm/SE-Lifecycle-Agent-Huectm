/**
 * Design revision 2026-11-02: PayoutOutcomeDto
 * Ownership: FreshFood-API.DTOs
 * + Outcome: string
 * + ProviderReference: string?
 * + SettledAmount: VndAmountString?
 */
/** PayoutOutcomeDto — FreshFood-API.DTOs; approved design source: detailed-class-model.json. */
export class PayoutOutcomeDto {
  constructor(values = {}) {
    this.Outcome = values.Outcome;
    this.ProviderReference = values.ProviderReference;
    this.SettledAmount = values.SettledAmount;
  }
}
