namespace FreshFood.Api.Services.Implements;

// Integration transport contracts are intentionally fail-closed until configured and verified.
// No synthetic coordinates, captured payment, notification delivery, or refund success is returned.
public sealed class GoogleMapsGeocodingAdapter : IGeocodingGateway
{
    public Task<GeoPointDto> ResolveAsync(string address, CancellationToken signal) => Task.FromException<GeoPointDto>(new DomainException("GEOCODING_TRANSPORT_NOT_CONFIGURED", 503));
}
public sealed class GoogleMapsDistanceAdapter : IDistanceGateway
{
    public Task<decimal> DrivingDistanceAsync(string addressId, CancellationToken signal) => Task.FromException<decimal>(new DomainException("DISTANCE_TRANSPORT_NOT_CONFIGURED", 503));
}
public sealed class DistanceCalculator(IDistanceGateway gateway) : IDistanceCalculator
{
    public Task<decimal> CalculateAsync(string addressId, CancellationToken signal) => gateway.DrivingDistanceAsync(addressId, signal);
}
public sealed class SePayPaymentAdapter : IPaymentGateway
{
    public Task<PaymentQrDto> CreateQrAsync(string reference, VndAmount amount, CancellationToken signal) => Task.FromException<PaymentQrDto>(new DomainException("PRE_ACCEPTANCE_PAYMENT_CORRELATION_TBD", 503));
    public Task<VerifiedPaymentDto> VerifyNoticeAsync(PaymentNoticeDto notice, CancellationToken signal) => Task.FromException<VerifiedPaymentDto>(new DomainException("PAYMENT_VERIFIER_NOT_CONFIGURED", 503));
}
public sealed class ConfiguredNotificationPublisher : INotificationPublisher
{
    public Task SendAsync(NotificationDto message, CancellationToken signal) => Task.FromException(new DomainException("NOTIFICATION_TRANSPORT_NOT_CONFIGURED", 503));
}
public sealed class NotificationAdapter(INotificationPublisher publisher) : INotificationGateway
{
    public Task PublishAsync(NotificationDto message, CancellationToken signal) => publisher.SendAsync(message, signal);
}
public sealed class UnconfiguredPayoutAdapter : IPayoutPort
{
    public Task<PayoutOutcomeDto> RequestAsync(string refundId, CancellationToken signal) => Task.FromException<PayoutOutcomeDto>(new DomainException("PAYOUT_PROVIDER_TBD", 503));
}
public sealed class PaymentNoticeHandler(ICheckoutService checkout)
{
    public Task<PaymentResultDto> HandleAsync(PaymentNoticeDto notice, CancellationToken signal) => checkout.HandleVerifiedPaymentAsync(notice, signal);
}
