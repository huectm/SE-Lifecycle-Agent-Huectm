using FreshFood.Api.Services.Implements;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Http;
using Microsoft.Net.Http.Headers;
using Xunit;

namespace FreshFood.Api.Tests;

public sealed class CurrentCustomerTests
{
    [Theory]
    [InlineData("http")]
    [InlineData("https")]
    public void NewGuestCookieAlwaysRequiresHttps(string scheme)
    {
        var context = new DefaultHttpContext();
        context.Request.Scheme = scheme;
        var customer = new CurrentCustomer(new HttpContextAccessor { HttpContext = context }, new EphemeralDataProtectionProvider());

        var identity = customer.GetCartIdentity();
        var cookie = SetCookieHeaderValue.Parse(context.Response.Headers.SetCookie.ToString());

        Assert.Equal("FreshFood.GuestCart", cookie.Name.ToString());
        Assert.True(cookie.Secure);
        Assert.True(cookie.HttpOnly);
        Assert.Equal(Microsoft.Net.Http.Headers.SameSiteMode.Strict, cookie.SameSite);
        Assert.False(string.IsNullOrEmpty(identity.SessionId));
        Assert.Null(identity.CustomerId);
    }

    [Theory]
    [InlineData(false)]
    [InlineData(true)]
    public void GuestIdentityIsReusedOnlyWhenCookieIsValid(bool tampered)
    {
        var protection = new EphemeralDataProtectionProvider();
        var first = new DefaultHttpContext();
        first.Request.Scheme = "https";
        var original = new CurrentCustomer(new HttpContextAccessor { HttpContext = first }, protection).GetCartIdentity();
        var cookie = SetCookieHeaderValue.Parse(first.Response.Headers.SetCookie.ToString());
        var next = new DefaultHttpContext();
        next.Request.Scheme = "https";
        next.Request.Headers.Cookie = "FreshFood.GuestCart=" + (tampered ? "invalid-token" : cookie.Value.ToString());

        var identity = new CurrentCustomer(new HttpContextAccessor { HttpContext = next }, protection).GetCartIdentity();

        if (tampered)
        {
            Assert.NotEqual(original.SessionId, identity.SessionId);
            Assert.True(SetCookieHeaderValue.Parse(next.Response.Headers.SetCookie.ToString()).Secure);
        }
        else
        {
            Assert.Equal(original.SessionId, identity.SessionId);
            Assert.False(next.Response.Headers.ContainsKey(HeaderNames.SetCookie));
        }
    }
}
