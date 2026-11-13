using System.Net;
using FreshFood.Api;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;

namespace FreshFood.Api.Tests;

public sealed class HttpTests : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly HttpClient client;
    public HttpTests(WebApplicationFactory<Program> factory) => client = factory.CreateClient(new() { AllowAutoRedirect = false });
    [Fact]
    public async Task HealthStartsWithoutDatabaseConfiguration()
    {
        var response = await client.GetAsync("/health"); Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        Assert.Contains("ok", await response.Content.ReadAsStringAsync()); Assert.True(response.Headers.CacheControl?.NoStore);
    }
    [Theory]
    [InlineData("/api/profile")]
    [InlineData("/api/orders")]
    [InlineData("/api/checkout?AddressId=2")]
    public async Task PrivateEndpointsRequireVerifiedSession(string url)
    {
        using var request = new HttpRequestMessage(HttpMethod.Get, url); request.Headers.Add("X-Customer-Id", "7");
        Assert.Equal(HttpStatusCode.Unauthorized, (await client.SendAsync(request)).StatusCode);
    }
    [Fact]
    public async Task GuestMutationRequiresCsrfToken()
    {
        var response = await client.PutAsync("/api/cart/items/1", new StringContent("{\"Quantity\":2}", System.Text.Encoding.UTF8, "application/json"));
        Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode); Assert.Contains("INVALID_CSRF_TOKEN", await response.Content.ReadAsStringAsync());
    }
    [Fact]
    public async Task CsrfEndpointReturnsTokenAndCookie()
    {
        var response = await client.GetAsync("/api/security/csrf"); Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        Assert.Contains("Token", await response.Content.ReadAsStringAsync()); Assert.True(response.Headers.Contains("Set-Cookie"));
    }
}
