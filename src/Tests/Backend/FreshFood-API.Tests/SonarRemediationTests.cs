using System.Net;
using System.Text;
using System.Text.Json;
using FreshFood.Api.DTOs;
using FreshFood.Api.Services;
using FreshFood.Api.Services.Implements;
using FreshFood.Reposistory.Entities;
using FreshFood.Reposistory.Repository;
using FreshFood.Reposistory.Repository.Implements;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace FreshFood.Api.Tests;

public sealed class SonarRemediationTests
{
    [Theory]
    [InlineData("{ \"amount\" : 100,\n \"description\": \"Thanh toán\" }\n")]
    [InlineData("not normalized JSON; retain this exact body")]
    public async Task WebhookModelBindingPreservesBodyAndVerificationHeaders(string raw)
    {
        PaymentNoticeDto? captured = null;
        var checkout = Proxy.For<ICheckoutService>((name, args) =>
        {
            Assert.Equal("HandleVerifiedPaymentAsync", name);
            captured = Assert.IsType<PaymentNoticeDto>(args[0]);
            return Task.FromResult(new PaymentResultDto());
        });
        using var factory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder =>
            builder.ConfigureServices(services => services.AddSingleton(checkout)));
        using var client = factory.CreateClient(new() { BaseAddress = new Uri("https://localhost") });
        using var request = new HttpRequestMessage(HttpMethod.Post, "/api/payments/sepay/webhook");
        request.Content = new StringContent(raw, Encoding.UTF8, "application/json");
        request.Headers.TryAddWithoutValidation("Authorization", "Apikey test-signature");
        request.Headers.Add("X-Provider-Reference", "provider-123");

        var response = await client.SendAsync(request);

        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        Assert.NotNull(captured);
        Assert.Equal(raw, captured.RawBody);
        Assert.Equal("Apikey test-signature", captured.Signature);
        Assert.Equal("provider-123", captured.ProviderReference);
    }

    [Theory]
    [InlineData(typeof(CartChangeDto))]
    [InlineData(typeof(OrderReviewDto))]
    public void MissingRequiredNumericInputsAreRejected(Type type) =>
        Assert.Throws<JsonException>(() => JsonSerializer.Deserialize("{}", type));

    [Fact]
    public void ExplicitZeroIsDistinctFromMissingNumericInput()
    {
        Assert.Equal(0, JsonSerializer.Deserialize<CartChangeDto>("{\"Quantity\":0}")!.Quantity);
        Assert.Equal(0, JsonSerializer.Deserialize<OrderReviewDto>("{\"Rating\":0}")!.Rating);
    }

    [Theory]
    [InlineData(null, false)]
    [InlineData(false, false)]
    [InlineData(true, true)]
    public async Task OptionalCatalogFilterRetainsFalseDefault(bool? input, bool expected)
    {
        bool? actual = null;
        var repository = Proxy.For<ICatalogRepository>((name, args) => name switch
        {
            "FindActiveAsync" => Find(args),
            "GetPopularAsync" => Task.FromResult(new List<Product>()),
            "GetSellableBatchesAsync" => Task.FromResult(new List<BatchInventory>()),
            "GetCategoriesAsync" => Task.FromResult(new List<ProductCategory>()),
            _ => throw new InvalidOperationException(name)
        });
        Task<List<Product>> Find(object?[] args) { actual = Assert.IsType<bool>(args[2]); return Task.FromResult(new List<Product>()); }
        await new CatalogService(repository, new BatchPricingPolicy()).GetCatalogAsync(new() { ClearanceOnly = input }, CancellationToken.None);
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData("123456789", null, true)]
    [InlineData("+123456789012345", true, true)]
    [InlineData("123456789012345", false, true)]
    [InlineData("12345678", null, false)]
    [InlineData("1234567890123456", null, false)]
    [InlineData("+12345abc9", null, false)]
    public async Task PhoneValidationPreservesBoundariesAndPreventsInvalidSideEffects(string phone, bool? isDefault, bool valid)
    {
        var geocodes = 0; CustomerAddress? saved = null;
        var repository = Proxy.For<IProfileRepository>((name, args) =>
        {
            Assert.Equal("SaveAddressAsync", name);
            saved = Assert.IsType<CustomerAddress>(args[0]);
            return Task.CompletedTask;
        });
        var geocoding = Proxy.For<IGeocodingGateway>((name, args) =>
        {
            geocodes++;
            return Task.FromResult(new GeoPointDto { Latitude = 10, Longitude = 105 });
        });
        var work = new ImmediateWork();
        var service = new ProfileService(repository, Proxy.For<ICurrentCustomer>((name, args) => "7"), work, geocoding);
        var input = new AddressInputDto { RecipientName = "Tester", RecipientPhone = phone, StreetAddress = "Test street", IsDefault = isDefault };
        if (valid)
        {
            var result = await service.SaveAddressAsync(input, CancellationToken.None);
            Assert.NotNull(saved);
            Assert.Equal(isDefault ?? false, saved.IsDefault);
            Assert.Equal(phone, result.RecipientPhone);
            Assert.Equal(1, geocodes);
            Assert.Equal(1, work.Executions);
        }
        else
        {
            var error = await Assert.ThrowsAsync<DomainException>(() => service.SaveAddressAsync(input, CancellationToken.None));
            Assert.Equal("INVALID_PHONE", error.Code);
            Assert.Null(saved);
            Assert.Equal(0, geocodes);
            Assert.Equal(0, work.Executions);
        }
    }
}
