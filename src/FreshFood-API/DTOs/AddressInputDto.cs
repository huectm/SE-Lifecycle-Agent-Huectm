namespace FreshFood.Api.DTOs;

public class AddressInputDto
{
    public string? AddressId { get; set; }
    public string RecipientName { get; set; } = string.Empty;
    public string RecipientPhone { get; set; } = string.Empty;
    public string StreetAddress { get; set; } = string.Empty;
    public bool? IsDefault { get; set; }
}
