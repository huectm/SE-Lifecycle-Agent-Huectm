namespace FreshFood.Api.Services;

public interface INotificationPublisher
{
    Task SendAsync(NotificationDto message, CancellationToken signal);
}
