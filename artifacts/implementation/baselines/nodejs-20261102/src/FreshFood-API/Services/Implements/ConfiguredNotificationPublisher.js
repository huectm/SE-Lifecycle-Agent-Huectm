/**
 * Design revision 2026-11-02: ConfiguredNotificationPublisher
 * Ownership: FreshFood-API.Services.Implements
 * - http: HttpTransport
 * + ConfiguredNotificationPublisher(http: HttpTransport)
 * + SendAsync(message: NotificationDto, signal: AbortSignal): Promise<void>
 */
export class ConfiguredNotificationPublisher { constructor(transport) {this.transport=transport;} async SendAsync(message,signal) {return this.transport.SendAsync('notifications:publish',message,signal);} }
