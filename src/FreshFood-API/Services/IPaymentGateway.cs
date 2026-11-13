namespace FreshFood.Api.Services;

public interface IPaymentGateway
{
    Task<PaymentQrDto> CreateQrAsync(string reference, VndAmount amount, CancellationToken signal);
    Task<VerifiedPaymentDto> VerifyNoticeAsync(PaymentNoticeDto notice, CancellationToken signal);
}
