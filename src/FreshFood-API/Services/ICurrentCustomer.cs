namespace FreshFood.Api.Services;

public interface ICurrentCustomer
{
    string RequireCustomerId();
    CartIdentityDto GetCartIdentity();
}
