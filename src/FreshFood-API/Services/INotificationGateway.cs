namespace FreshFood.Api.Services;

public interface INotificationGateway
{
    Task PublishAsync(NotificationDto message, CancellationToken signal);
}
