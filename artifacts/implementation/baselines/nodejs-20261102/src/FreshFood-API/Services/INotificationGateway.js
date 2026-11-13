/**
 * Design revision 2026-11-02: INotificationGateway
 * Ownership: FreshFood-API.Services
 * + PublishAsync(message: NotificationDto, signal: AbortSignal): Promise<void>
 */
/** INotificationGateway — FreshFood-API.Services; approved design source: detailed-class-model.json. */
export class INotificationGateway {
  async PublishAsync(message, signal) { throw Object.assign(new Error("INotificationGateway.PublishAsync: implementation or external port required"), { code: "DESIGN_PORT_UNCONFIGURED", status: 503 }); }
}
