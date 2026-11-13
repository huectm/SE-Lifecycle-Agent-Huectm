/**
 * Approved design classifier: TransitionResult
 * Ownership: FreshFood-API.DTOs
 * + TransitionId: string
 * + Target: string
 * + Applied: boolean
 * + Duplicate: boolean
 * + FailureCode: string?
 */
/** TransitionResult — FreshFood-API.DTOs; approved design source: detailed-class-model.json. */
export class TransitionResult {
  constructor(values = {}) {
    this.TransitionId = values.TransitionId;
    this.Target = values.Target;
    this.Applied = values.Applied;
    this.Duplicate = values.Duplicate;
    this.FailureCode = values.FailureCode;
  }
}
