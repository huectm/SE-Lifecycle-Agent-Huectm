/**
 * Design revision 2026-11-02: Order
 * Ownership: FreshFood.Reposistory.Entities
 * + OrderId: EntityId {private set}
 * + OrderNumber: string {private set}
 * + CustomerId: EntityId {private set}
 * + DeliveryAddressId: EntityId {private set}
 * + ProcessedByStaffId: number {private set}
 * + OrderDate: Date {private set}
 * + SubTotal: VndAmount {private set}
 * + DeliveryDistance: number {private set}
 * + ShippingFee: VndAmount {private set}
 * + TotalAmount: VndAmount {private set}
 * + PaymentMethod: PaymentMethod {private set}
 * + PaymentStatus: PaymentStatus {private set}
 * + OrderStatus: OrderStatus {private set}
 * + IsFirstOrder: boolean {private set}
 * + DeliveryAgentId: EntityId {private set}
 * + PhoneConfirmationStatus: string {private set}
 * + PhoneContactedByStaffId: number {private set}
 * + PhoneContactedAt: Date {private set}
 * + PhoneConfirmationNote: string {private set}
 * + CancellationReason: string {private set}
 * + Details: ReadonlyArray<OrderDetail> {read only; materialized navigation}
 * + Customer: Customer {read only; materialized navigation}
 * + DeliveryAddress: CustomerAddress {read only; materialized navigation}
 * + Payments: ReadonlyArray<OrderPayment> {read only; materialized navigation}
 * + Failure: DeliveryFailure? {read only; materialized navigation}
 * + Return: ReturnReceipt? {read only; materialized navigation}
 * + Refund: Refund? {read only; materialized navigation}
 * + ApplyFulfillment(expected: OrderStatus, target: OrderStatus): void
 * + RecordPayment(expected: PaymentStatus, target: PaymentStatus): void
 */
import { initializeEntity, patchEntity } from './EntityState.js';
export class Order {
  constructor(values={}){initializeEntity(this,values,["OrderId", "OrderNumber", "CustomerId", "DeliveryAddressId", "ProcessedByStaffId", "OrderDate", "SubTotal", "DeliveryDistance", "ShippingFee", "TotalAmount", "PaymentMethod", "PaymentStatus", "OrderStatus", "IsFirstOrder", "DeliveryAgentId", "PhoneConfirmationStatus", "PhoneContactedByStaffId", "PhoneContactedAt", "PhoneConfirmationNote", "CancellationReason", "Details", "Customer", "DeliveryAddress", "Payments", "Failure", "Return", "Refund"]);}
  ApplyFulfillment(expected,target){if(this.OrderStatus!==expected)throw new Error('STALE_ORDER_STATE');patchEntity(this,{OrderStatus:target});}
  RecordPayment(expected,target){if(this.PaymentStatus!==expected)throw new Error('STALE_PAYMENT_STATE');patchEntity(this,{PaymentStatus:target});}
  Cancel(expected,reason){if(this.OrderStatus!==expected)throw new Error('STALE_ORDER_STATE');if(typeof reason!=='string'||!reason.trim())throw new RangeError('CANCELLATION_REASON_REQUIRED');patchEntity(this,{OrderStatus:'Cancelled',CancellationReason:reason});}
}
