using Microsoft.AspNetCore.DataProtection;

namespace FreshFood.Api.Services.Implements;

public sealed class CurrentCustomer(IHttpContextAccessor accessor, IDataProtectionProvider protection) : ICurrentCustomer
{
    public string RequireCustomerId()
    {
        var user = accessor.HttpContext?.User;
        var id = user?.Identity?.IsAuthenticated == true ? user.FindFirstValue("customer_id") : null;
        if (id is null) throw new DomainException("AUTHENTICATION_REQUIRED", 401);
        return ServiceRules.Id(id);
    }
    public CartIdentityDto GetCartIdentity()
    {
        var context = accessor.HttpContext ?? throw new InvalidOperationException("No request.");
        if (context.User.Identity?.IsAuthenticated == true) return new() { CustomerId = RequireCustomerId() };
        var protector = protection.CreateProtector("FreshFood.GuestCart.v1");
        string? session = null;
        if (context.Request.Cookies.TryGetValue("FreshFood.GuestCart", out var cookie))
            try { session = protector.Unprotect(cookie); } catch (System.Security.Cryptography.CryptographicException) { /* Invalid cookies never become cart identities. */ }
        if (session is null)
        {
            session = Guid.NewGuid().ToString("N");
            context.Response.Cookies.Append("FreshFood.GuestCart", protector.Protect(session), new() { HttpOnly = true, Secure = true, SameSite = SameSiteMode.Strict, IsEssential = true });
        }
        return new() { SessionId = session };
    }
}
