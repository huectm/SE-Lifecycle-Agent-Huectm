/**
 * Design revision 2026-11-02: OrderStateSnapshot
 * Ownership: FreshFood-API.DTOs
 * + FulfillmentState: OrderStatus?
 * + PaymentState: PaymentStatus?
 * + RefundState: string?
 * + WorkflowNode: string? {transient UML position}
 * + FulfillmentCompleted: boolean
 */
export class OrderStateSnapshot { constructor(values={}) { this.FulfillmentState=values.FulfillmentState;this.PaymentState=values.PaymentState;this.RefundState=values.RefundState;this.WorkflowNode=values.WorkflowNode;this.FulfillmentCompleted=values.FulfillmentCompleted; } }
