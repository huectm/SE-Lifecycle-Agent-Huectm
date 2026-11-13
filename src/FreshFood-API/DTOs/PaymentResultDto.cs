namespace FreshFood.Api.DTOs;

public class PaymentResultDto
{
    public bool Accepted { get; set; }
    public bool Duplicate { get; set; }
    public PaymentStatus PaymentStatus { get; set; }
}
