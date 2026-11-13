using FreshFood.Api;
using FreshFood.Api.DTOs;
using FreshFood.Api.Services;
using FreshFood.Api.Services.Implements;
using FreshFood.Reposistory.Entities;
using FreshFood.Reposistory.Repository;
using FreshFood.Reposistory.Repository.Implements;
using Xunit;

namespace FreshFood.Api.Tests;

public sealed class ProfileEmailTests
{
    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("tester@example.com")]
    [InlineData("tester+tag@sub.example.com")]
    public async Task AcceptedEmailPreservesExistingProfileBehavior(string? email)
    {
        var customer = new Customer { CustomerId = "7", FullName = "Before" };
        var writes = 0;
        var repository = Proxy.For<IProfileRepository>((name, args) => name switch
        {
            "GetCustomerAsync" => Task.FromResult(customer),
            "GetAddressesAsync" => Task.FromResult(new List<CustomerAddress>()),
            "SaveCustomerAsync" => Save(),
            _ => throw new InvalidOperationException(name)
        });
        Task Save() { writes++; return Task.CompletedTask; }
        var work = new ImmediateWork();
        var result = await Service(repository, work).UpdateProfileAsync(new ProfileUpdateDto { FullName = "Tester", Email = email }, CancellationToken.None);

        Assert.Equal(string.IsNullOrEmpty(email) ? null : email, result.Email);
        Assert.Equal("Tester", result.FullName);
        Assert.Equal(1, writes);
        Assert.Equal(1, work.Executions);
    }

    [Theory]
    [InlineData("invalid")]
    [InlineData("tester@")]
    [InlineData("tester name@example.com")]
    public Task InvalidEmailDoesNotEnterTransaction(string email) => RejectWithoutWrite(email);

    [Fact]
    public Task AdversarialEmailReturnsDomainErrorWithoutWrite() =>
        RejectWithoutWrite("tester@" + new string('.', 65_000) + "@");

    private static async Task RejectWithoutWrite(string email)
    {
        var work = new ImmediateWork();
        var repository = Proxy.For<IProfileRepository>((name, args) => throw new InvalidOperationException("No repository access expected."));
        var error = await Assert.ThrowsAsync<DomainException>(() => Service(repository, work).UpdateProfileAsync(new ProfileUpdateDto { FullName = "Tester", Email = email }, CancellationToken.None));
        Assert.Equal("INVALID_EMAIL", error.Code);
        Assert.Equal(0, work.Executions);
    }

    private static ProfileService Service(IProfileRepository repository, ImmediateWork work) => new(
        repository,
        Proxy.For<ICurrentCustomer>((name, args) => name == "RequireCustomerId" ? "7" : throw new InvalidOperationException(name)),
        work,
        Proxy.For<IGeocodingGateway>((name, args) => throw new InvalidOperationException(name)));
}
