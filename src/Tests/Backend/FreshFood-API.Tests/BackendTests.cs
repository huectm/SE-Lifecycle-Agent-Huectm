using System.Reflection;
using FreshFood.Api;
using FreshFood.Api.DTOs;
using FreshFood.Api.Services;
using FreshFood.Api.Services.Implements;
using FreshFood.Reposistory.Entities;
using FreshFood.Reposistory.Repository;
using FreshFood.Reposistory.Repository.Implements;
using Microsoft.Extensions.Logging.Abstractions;
using Xunit;

namespace FreshFood.Api.Tests;

public class Proxy : DispatchProxy
{
    public Func<string, object?[], object?> InvokeMethod { get; set; } = null!;
    protected override object? Invoke(MethodInfo? method, object?[]? args) => InvokeMethod(method!.Name, args ?? []);
    public static T For<T>(Func<string, object?[], object?> callback) where T : class
    { var result = Create<T, Proxy>(); ((Proxy)(object)result).InvokeMethod = callback; return result; }
}
public sealed class ImmediateWork : IUnitOfWork
{
    public int Executions { get; private set; }
    public Task ExecuteAsync(Func<CancellationToken, Task> work, CancellationToken signal) { Executions++; return work(signal); }
    public Task<T> ExecuteAsync<T>(Func<CancellationToken, Task<T>> work, CancellationToken signal) { Executions++; return work(signal); }
}
public class BackendTests
{
    private static readonly string[] InitialUnpaidTransitions = ["I00", "T01u", "P01"];
    [Fact]
    public void FingerprintsPreserveNodeJsonStringifyEscaping()
    {
        var root = new DirectoryInfo(AppContext.BaseDirectory);
        while (root is not null && !File.Exists(Path.Combine(root.FullName, "AGENTS.md"))) root = root.Parent;
        using var vectors = System.Text.Json.JsonDocument.Parse(File.ReadAllText(Path.Combine(root!.FullName, "src/Tests/Backend/FreshFood-API.Tests/Fixtures/checkout-hash-vectors.json")));
        foreach (var vector in vectors.RootElement.EnumerateArray())
            Assert.Equal(vector.GetProperty("Hash").GetString(), CheckoutService.RequestHash(new() { AddressId = "2", PaymentMethod = PaymentMethod.Cod, CheckoutReference = vector.GetProperty("Reference").GetString()! }));
    }
    [Fact]
    public void MissingPaymentMethodDoesNotSilentlySelectCod() =>
        Assert.Throws<System.Text.Json.JsonException>(() => System.Text.Json.JsonSerializer.Deserialize<PlaceOrderDto>("{\"AddressId\":\"2\",\"CheckoutReference\":\"r\",\"IdempotencyKey\":\"k\"}", ApiJson.Options));
    private static readonly CancellationToken Ct = CancellationToken.None;
    private static ICurrentCustomer Customer() => Proxy.For<ICurrentCustomer>((n, a) => n == "RequireCustomerId" ? "7" : new CartIdentityDto { CustomerId = "7" });
    private static BatchInventory Batch(int stock = 10, int reserved = 0) => new() { BatchId = "1", ProductId = "1", ExpiryDate = new(2099, 1, 1), CurrentStock = stock, ReservedStock = reserved, RetailPrice = new(10000), SaleStatus = "ACTIVE" };
    [Theory]
    [InlineData(0, 10000)]
    [InlineData(0.999, 10000)]
    [InlineData(1, 20000)]
    [InlineData(2.999, 20000)]
    [InlineData(3, 30000)]
    [InlineData(10, 30000)]
    public void ShippingBoundary(decimal distance, decimal expected) => Assert.Equal(expected, new DeliveryFeePolicy().Quote(distance).Units);
    [Theory]
    [InlineData(-0.001)]
    [InlineData(10.001)]
    public void ShippingOutsideArea(decimal distance) => Assert.Equal("OUTSIDE_DELIVERY_AREA", Assert.Throws<DomainException>(() => new DeliveryFeePolicy().Quote(distance)).Code);
    [Theory]
    [InlineData(0, 10000)]
    [InlineData(10, 9000)]
    [InlineData(50, 5000)]
    public void Discount(decimal rate, decimal expected) { var b = Batch(); b.DiscountRate = rate; Assert.Equal(expected, new BatchPricingPolicy().Quote(b, DateTimeOffset.UtcNow).Units); }
    [Theory]
    [InlineData(9.99)]
    [InlineData(50.01)]
    [InlineData(10.001)]
    public void InvalidDiscount(decimal rate) { var b = Batch(); b.DiscountRate = rate; Assert.Throws<DomainException>(() => new BatchPricingPolicy().Quote(b, DateTimeOffset.UtcNow)); }
    [Fact] public void FractionalMoneyDoesNotInventRounding() { var b = Batch(); b.RetailPrice = new(101); b.DiscountRate = 10; Assert.Equal("ROUNDING_POLICY_TBD", Assert.Throws<DomainException>(() => new BatchPricingPolicy().Quote(b, DateTimeOffset.UtcNow)).Code); }
    [Fact] public void MoneyPreservesLargeIntegerString() => Assert.Equal("999999999999999999", new VndAmount(999999999999999999m).ToWire());
    [Fact] public void ReserveReleaseInvariant() { var b = Batch(); b.Reserve(3); b.ReleaseReservation(3); Assert.Equal(0, b.ReservedStock); Assert.Throws<DomainException>(() => b.ReleaseReservation(1)); Assert.Throws<DomainException>(() => b.Reserve(11)); }
    [Fact] public void CartUsesAbsoluteQuantity() { var c = new Cart(); c.ChangeQuantity("1", 2); c.ChangeQuantity("1", 3); Assert.Equal(3, Assert.Single(c.Items).Quantity); c.RemoveItem("1"); Assert.Empty(c.Items); }
    [Fact]
    public void WireEnumsAreStringsAndRejectIntegers()
    { Assert.Contains("\"PendingUnpaid\"", System.Text.Json.JsonSerializer.Serialize(new OrderConfirmationDto { Status = OrderStatus.PendingUnpaid }, ApiJson.Options)); Assert.Throws<System.Text.Json.JsonException>(() => System.Text.Json.JsonSerializer.Deserialize<PlaceOrderDto>("{\"PaymentMethod\":0}", ApiJson.Options)); }
    [Fact]
    public async Task CatalogFiltersInactiveAndTotalsAvailableStock()
    {
        var repo = Proxy.For<ICatalogRepository>((n, a) => n switch
        {
            "FindActiveAsync" => Task.FromResult(new List<Product> { new() { ProductId = "1", ProductName = "Greens", IsActive = true }, new() { ProductId = "2", IsActive = false } }),
            "GetSellableBatchesAsync" => Task.FromResult(new List<BatchInventory> { Batch(10, 3) }),
            "GetCategoriesAsync" => Task.FromResult(new List<ProductCategory>()),
            _ => throw new Exception(n)
        });
        var result = await new CatalogService(repo, new BatchPricingPolicy()).SearchAsync(new(), Ct);
        Assert.Equal(7, Assert.Single(result.Items).AvailableQuantity); Assert.Equal("10000", result.Items[0].CurrentPrice);
    }
    [Fact]
    public async Task CartClampsToAvailableAndIgnoresClientIdentity()
    {
        var c = new Cart { CartId = "1", CustomerId = "7" };
        var repo = Proxy.For<ICartRepository>((n, a) => n switch
        {
            "GetAsync" => a[0]?.ToString() == "7" ? Task.FromResult(c) : throw new Exception("Wrong owner"),
            "GetProductsAsync" => Task.FromResult(new List<Product> { new() { ProductId = "1", IsActive = true } }),
            "GetSellableBatchesAsync" => Task.FromResult(new List<BatchInventory> { Batch(5, 2) }),
            "SaveAsync" => Task.CompletedTask,
            _ => throw new Exception(n)
        });
        var service = new CartService(repo, Customer(), new ImmediateWork(), new BatchPricingPolicy());
        var result = await service.ChangeQuantityAsync(new() { ProductId = "1", Quantity = 4 }, Ct);
        Assert.Equal(3, Assert.Single(result.Lines).Quantity); Assert.Contains("QUANTITY_CLAMPED:1", result.Warnings);
        Assert.Equal("30000", (await service.GetCartAsync(new() { CustomerId = "8" }, Ct)).SubTotal);
    }
    [Fact]
    public async Task ProfileRejectsInvalidEmailWithoutWrite()
    {
        var work = new ImmediateWork(); var repo = Proxy.For<IProfileRepository>((n, a) => throw new Exception("Repository should not be called"));
        var service = new ProfileService(repo, Customer(), work, Proxy.For<IGeocodingGateway>((n, a) => throw new Exception(n)));
        Assert.Equal("INVALID_EMAIL", (await Assert.ThrowsAsync<DomainException>(() => service.UpdateProfileAsync(new() { FullName = "Tester", Email = "invalid" }, Ct))).Code); Assert.Equal(0, work.Executions);
    }
    [Theory]
    [InlineData(OrderStatus.PendingUnpaid, PaymentStatus.Unpaid)]
    [InlineData(OrderStatus.PendingPaid, PaymentStatus.Paid)]
    [InlineData(OrderStatus.Confirmed, PaymentStatus.Paid)]
    public async Task CancelReleasesOnceAndPreservesPayment(OrderStatus state, PaymentStatus payment)
    {
        var b = Batch(10, 3); var order = new Order { OrderId = "1", CustomerId = "7", OrderStatus = state, PaymentStatus = payment, Details = [new() { BatchId = "1", Quantity = 3 }] };
        var evidence = new List<string>(); var audits = 0;
        var repo = Proxy.For<IOrderLifecycleRepository>((n, a) => n switch
        {
            "RecordEventOnceAsync" => Task.FromResult(evidence.AddUnique((string)a[2]!)),
            "LockReservedBatchesAsync" => Task.FromResult(new List<BatchInventory> { b }),
            "SaveBatchesAsync" or "SaveAsync" => Task.CompletedTask,
            "AppendAuditAsync" => CountAudit(),
            _ => throw new Exception(n)
        });
        Task CountAudit() { audits++; return Task.CompletedTask; }
        var mine = Proxy.For<IMyOrdersRepository>((n, a) => n == "LockOwnedAsync" ? Task.FromResult(order) : throw new Exception(n));
        var notify = Proxy.For<INotificationGateway>((n, a) => Task.CompletedTask);
        var service = new MyOrdersService(mine, Customer(), new ImmediateWork(), notify, new OrderStateMachine(repo), new BatchPricingPolicy(), NullLogger<MyOrdersService>.Instance);
        Assert.Equal("ORDER_CANCELLED", (await service.CancelOrderAsync(new() { OrderId = "1", Reason = "Changed mind" }, Ct)).MessageCode);
        Assert.Equal("ORDER_ALREADY_CANCELLED", (await service.CancelOrderAsync(new() { OrderId = "1", Reason = "Retry" }, Ct)).MessageCode);
        Assert.Equal(payment, order.PaymentStatus); Assert.Equal(0, b.ReservedStock); Assert.Equal(1, audits); Assert.Equal("Changed mind", order.CancellationReason); Assert.Equal(2, evidence.Count);
    }
    [Fact]
    public async Task AcceptOrderTraversesOneInitialBranchAndInitialPayment()
    {
        var rows = new List<string>(); var repo = Proxy.For<IOrderLifecycleRepository>((n, a) => n == "RecordEventOnceAsync" ? Task.FromResult(rows.AddUnique((string)a[2]!)) : throw new Exception(n));
        var order = new Order { CustomerId = "7", Details = [new() { BatchId = "1", Quantity = 3 }] }; var machine = new OrderStateMachine(repo);
        Assert.Null(machine.CurrentState());
        var result = await machine.ProcessEventAsync(new("checkout:7:x", "7", order, [Batch()], true), new() { Event = "acceptOrder", AggregateId = "checkout:7:x", EventId = "x" }, Ct);
        Assert.Equal(InitialUnpaidTransitions, result.TransitionIds); Assert.Equal(OrderStatus.PendingUnpaid, order.OrderStatus); Assert.False(result.State.FulfillmentCompleted);
    }
    [Theory]
    [InlineData(OrderStatus.Packing)]
    [InlineData(OrderStatus.Shipping)]
    [InlineData(OrderStatus.Delivered)]
    public async Task CancelOutsideAllowedStatesFails(OrderStatus state)
    {
        var repo = Proxy.For<IOrderLifecycleRepository>((n, a) => throw new Exception("No persistence expected"));
        var order = new Order { OrderId = "1", CustomerId = "7", OrderStatus = state };
        Assert.Equal("STATE_EVENT_NOT_ALLOWED", (await Assert.ThrowsAsync<DomainException>(() => new OrderStateMachine(repo).ProcessEventAsync(new("1", "7", order), new() { Event = "cancelOrder", AggregateId = "1", EventId = "x", Reason = "reason" }, Ct))).Code);
    }
    [Fact]
    public async Task StateMachineRejectsAggregateMismatch()
    {
        var repo = Proxy.For<IOrderLifecycleRepository>((n, a) => throw new Exception(n));
        Assert.Equal("AGGREGATE_MISMATCH", (await Assert.ThrowsAsync<DomainException>(() => new OrderStateMachine(repo).ProcessEventAsync(new("1", "7", new()), new() { Event = "cancelOrder", AggregateId = "2" }, Ct))).Code);
    }
}
internal static class ListExtensions
{
    internal static bool AddUnique(this List<string> list, string value) { if (list.Contains(value)) return false; list.Add(value); return true; }
}
