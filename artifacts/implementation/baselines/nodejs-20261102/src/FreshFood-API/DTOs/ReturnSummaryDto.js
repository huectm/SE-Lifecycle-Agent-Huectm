/**
 * Design revision 2026-11-02: ReturnSummaryDto
 * Ownership: FreshFood-API.DTOs
 * + FailureReason: string?
 * + ReceiptStatus: string?
 * + RefundStatus: string?
 * + GoodsRefunded: VndAmountString
 * + ShippingRefunded: VndAmountString
 * + InventoryDisposition: string?
 */
/** ReturnSummaryDto — FreshFood-API.DTOs; approved design source: detailed-class-model.json. */
export class ReturnSummaryDto {
  constructor(values = {}) {
    this.FailureReason = values.FailureReason;
    this.ReceiptStatus = values.ReceiptStatus;
    this.RefundStatus = values.RefundStatus;
    this.GoodsRefunded = values.GoodsRefunded;
    this.ShippingRefunded = values.ShippingRefunded;
    this.InventoryDisposition = values.InventoryDisposition;
  }
}
