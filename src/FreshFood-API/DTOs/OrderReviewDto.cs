namespace FreshFood.Api.DTOs;

public class OrderReviewDto
{
    public string OrderId { get; set; } = string.Empty;
    [System.Text.Json.Serialization.JsonRequired]
    public int Rating { get; set; }
    public string? Comment { get; set; }
}
