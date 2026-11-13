/**
 * Design revision 2026-11-02: NotificationAdapter
 * Ownership: FreshFood-API.Services.Implements
 * - publisher: INotificationPublisher
 * + NotificationAdapter(publisher: INotificationPublisher)
 * + PublishAsync(message: NotificationDto, signal: AbortSignal): Promise<void>
 */
export class NotificationAdapter { constructor(publisher) {this.publisher=publisher;} async PublishAsync(message,signal) {return this.publisher.SendAsync(message,signal);} }
