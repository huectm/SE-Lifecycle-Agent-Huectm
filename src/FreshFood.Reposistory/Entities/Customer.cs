namespace FreshFood.Reposistory.Entities;

public partial class Customer
{
    public string CustomerId { get; set; } = string.Empty;
    public string FullName { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public string? Email { get; set; }
    public string AuthProvider { get; set; } = string.Empty;
    public string ProviderUserId { get; set; } = string.Empty;
    public bool IsPhoneVerified { get; set; }
    public DateTimeOffset CreatedAt { get; set; }
    public List<CustomerAddress> Addresses { get; set; } = [];
}
