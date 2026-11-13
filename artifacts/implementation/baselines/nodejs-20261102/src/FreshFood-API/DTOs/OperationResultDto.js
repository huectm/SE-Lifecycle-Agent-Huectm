/**
 * Design revision 2026-11-02: OperationResultDto
 * Ownership: FreshFood-API.DTOs
 * + Success: boolean
 * + MessageCode: string
 */
/** OperationResultDto — FreshFood-API.DTOs; approved design source: detailed-class-model.json. */
export class OperationResultDto {
  constructor(values = {}) {
    this.Success = values.Success;
    this.MessageCode = values.MessageCode;
  }
}
