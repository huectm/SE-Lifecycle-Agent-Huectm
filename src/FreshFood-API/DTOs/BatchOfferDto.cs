namespace FreshFood.Api.DTOs;

public class BatchOfferDto
{
    public string BatchId { get; set; } = string.Empty;
    public DateOnly ExpiryDate { get; set; }
    public string Price { get; set; } = string.Empty;
    public bool Clearance { get; set; }
}
