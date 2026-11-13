namespace FreshFood.Api.DTOs;

public class ProfileResultDto
{
    public string CustomerId { get; set; } = string.Empty;
    public string FullName { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public string? Email { get; set; }
    public List<AddressDto> Addresses { get; set; } = [];
}
