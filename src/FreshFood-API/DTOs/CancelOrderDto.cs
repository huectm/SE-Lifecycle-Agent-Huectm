namespace FreshFood.Api.DTOs;

public class CancelOrderDto
{
    public string OrderId { get; set; } = string.Empty;
    public string Reason { get; set; } = string.Empty;
}
