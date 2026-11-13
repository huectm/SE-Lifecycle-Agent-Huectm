/**
 * Design revision 2026-11-02: INotificationPublisher
 * Ownership: FreshFood-API.Services
 * + SendAsync(message: NotificationDto, signal: AbortSignal): Promise<void>
 */
/** INotificationPublisher — FreshFood-API.Services; approved design source: detailed-class-model.json. */
export class INotificationPublisher {
  async SendAsync(message, signal) { throw Object.assign(new Error("INotificationPublisher.SendAsync: implementation or external port required"), { code: "DESIGN_PORT_UNCONFIGURED", status: 503 }); }
}
