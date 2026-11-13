/**
 * Design revision 2026-11-02: MyOrdersController
 * Ownership: FreshFood-API.Controllers
 * - service: IMyOrdersService
 * + MyOrdersController(service: IMyOrdersService)
 * + GetOrdersAsync(signal: AbortSignal): Promise<OrderListDto>
 * + GetOrderDetailsAsync(orderId: EntityId, signal: AbortSignal): Promise<OrderDetailsDto>
 * + CancelOrderAsync(request: CancelOrderDto, signal: AbortSignal): Promise<OperationResultDto>
 * + ReorderAsync(orderId: EntityId, signal: AbortSignal): Promise<CartResultDto>
 * + SubmitReviewAsync(request: OrderReviewDto, signal: AbortSignal): Promise<OperationResultDto>
 */
/** UC-C07: injected service contract; transport/authentication belongs to HTTP composition. */
export class MyOrdersController {
  constructor(service) { this.service = service; }
  async GetOrdersAsync(signal) { return this.service.GetOrdersAsync(signal); }
  async GetOrderDetailsAsync(orderId, signal) { return this.service.GetOrderDetailsAsync(orderId, signal); }
  async CancelOrderAsync(request, signal) { return this.service.CancelOrderAsync(request, signal); }
  async ReorderAsync(orderId, signal) { return this.service.ReorderAsync(orderId, signal); }
  async SubmitReviewAsync(request, signal) { return this.service.SubmitReviewAsync(request, signal); }
}
