/**
 * Design revision 2026-11-02: OrderLifecycleRecords
 * Ownership: FreshFood.Reposistory.Repository
 * + Order: Order
 * + Failure: DeliveryFailure?
 * + Receipt: ReturnReceipt?
 * + Refund: Refund?
 * + Payments: ReadonlyArray<OrderPayment>
 */
/** OrderLifecycleRecords — FreshFood.Reposistory.Repository; approved design source: detailed-class-model.json. */
export class OrderLifecycleRecords {
  constructor(values = {}) {
    this.Order = values.Order;
    this.Failure = values.Failure;
    this.Receipt = values.Receipt;
    this.Refund = values.Refund;
    this.Payments = values.Payments;
  }
}
