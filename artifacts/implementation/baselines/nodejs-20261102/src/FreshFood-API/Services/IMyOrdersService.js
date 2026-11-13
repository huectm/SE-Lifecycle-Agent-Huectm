/**
 * Design revision 2026-11-02: IMyOrdersService
 * Ownership: FreshFood-API.Services
 * + GetOrdersAsync(signal: AbortSignal): Promise<OrderListDto>
 * + GetOrderDetailsAsync(orderId: EntityId, signal: AbortSignal): Promise<OrderDetailsDto>
 * + CancelOrderAsync(request: CancelOrderDto, signal: AbortSignal): Promise<OperationResultDto>
 * + ReorderAsync(orderId: EntityId, signal: AbortSignal): Promise<CartResultDto>
 * + SubmitReviewAsync(request: OrderReviewDto, signal: AbortSignal): Promise<OperationResultDto>
 */
/** IMyOrdersService — FreshFood-API.Services; approved design source: detailed-class-model.json. */
export class IMyOrdersService {
  async GetOrdersAsync(signal) { throw Object.assign(new Error("IMyOrdersService.GetOrdersAsync: implementation or external port required"), { code: "DESIGN_PORT_UNCONFIGURED", status: 503 }); }
  async GetOrderDetailsAsync(orderId, signal) { throw Object.assign(new Error("IMyOrdersService.GetOrderDetailsAsync: implementation or external port required"), { code: "DESIGN_PORT_UNCONFIGURED", status: 503 }); }
  async CancelOrderAsync(request, signal) { throw Object.assign(new Error("IMyOrdersService.CancelOrderAsync: implementation or external port required"), { code: "DESIGN_PORT_UNCONFIGURED", status: 503 }); }
  async ReorderAsync(orderId, signal) { throw Object.assign(new Error("IMyOrdersService.ReorderAsync: implementation or external port required"), { code: "DESIGN_PORT_UNCONFIGURED", status: 503 }); }
  async SubmitReviewAsync(request, signal) { throw Object.assign(new Error("IMyOrdersService.SubmitReviewAsync: implementation or external port required"), { code: "DESIGN_PORT_UNCONFIGURED", status: 503 }); }
}
