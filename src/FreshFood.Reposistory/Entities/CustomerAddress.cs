namespace FreshFood.Reposistory.Entities;

public partial class CustomerAddress
{
    public string AddressId { get; set; } = string.Empty;
    public string CustomerId { get; set; } = string.Empty;
    public string RecipientName { get; set; } = string.Empty;
    public string RecipientPhone { get; set; } = string.Empty;
    public string StreetAddress { get; set; } = string.Empty;
    public decimal Latitude { get; set; }
    public decimal Longitude { get; set; }
    public bool IsDefault { get; set; }
}
