using FreshFood.Api;
using FreshFood.Api.DTOs;
using FreshFood.Api.Services;
using FreshFood.Api.Services.Implements;
using FreshFood.Reposistory.Entities;
using FreshFood.Reposistory.Repository;
using FreshFood.Reposistory.Repository.Implements;
using Microsoft.Extensions.Logging.Abstractions;
using Npgsql;
using Xunit;

namespace FreshFood.Api.Tests;

public class PostgreSqlTests
{
    // Explicitly opt-in: never create/drop tables in an existing application database.
    [PostgreSqlFact]
    [Trait("Category", "PostgreSQL")]
    public async Task IsolatedSchema_VerifiesFiveUseCasesAndAtomicCheckoutCancellation()
    {
        if (Environment.GetEnvironmentVariable("FRESHFOOD_TEST_DATABASE") is not { Length: > 0 } connection)
            throw new InvalidOperationException("Set FRESHFOOD_TEST_DATABASE to an explicitly disposable local database. See README.");
        var schema = "test_" + Guid.NewGuid().ToString("N");
        var options = new NpgsqlConnectionStringBuilder(connection) { Pooling = true, MaxPoolSize = 1, SearchPath = schema, NoResetOnClose = true };
        await using var admin = new NpgsqlConnection(connection); await admin.OpenAsync();
        await using (var create = new NpgsqlCommand("CREATE SCHEMA " + schema, admin)) await create.ExecuteNonQueryAsync();
        await admin.CloseAsync();
        await using var source = NpgsqlDataSource.Create(options.ConnectionString);
        try
        {
            await using (var setup = await source.OpenConnectionAsync())
            {
                await using (var path = new NpgsqlCommand("SET search_path TO " + schema, setup)) await path.ExecuteNonQueryAsync();
                var root = FindRoot();
                var sql = await File.ReadAllTextAsync(Path.Combine(root, "src/Tests/Backend/FreshFood-API.Tests/Fixtures/prerequisites.sql"));
                await using (var command = new NpgsqlCommand(sql, setup)) await command.ExecuteNonQueryAsync();
                var migration = await File.ReadAllTextAsync(Path.Combine(root, "src/FreshFood-DB/migrations/20261102_001_order_consistency.up.sql"));
                await using (var command = new NpgsqlCommand(migration, setup)) await command.ExecuteNonQueryAsync();
                const string extension = """
                    ALTER TABLE customers ADD email TEXT,ADD phone TEXT;
                    ALTER TABLE products ADD description TEXT,ADD category_id INT;
                    CREATE TABLE product_categories(category_id INT PRIMARY KEY,category_name TEXT,is_active BOOLEAN);
                    CREATE TABLE delivery_failures(failure_id BIGINT,order_id BIGINT,reason TEXT,failure_cause TEXT);
                    CREATE TABLE return_receipts(return_receipt_id BIGINT,order_id BIGINT,receipt_status TEXT);
                    CREATE TABLE refunds(refund_id BIGINT,order_id BIGINT,goods_amount NUMERIC,shipping_amount NUMERIC,refund_status TEXT);
                    CREATE TABLE order_reviews(review_id BIGSERIAL PRIMARY KEY,order_id BIGINT UNIQUE,customer_id BIGINT,rating INT,comment TEXT);
                    INSERT INTO product_categories VALUES(1,'Vegetables',TRUE);
                    UPDATE products SET category_id=1;
                    """;
                await using (var command = new NpgsqlCommand(extension, setup)) await command.ExecuteNonQueryAsync();
            }
            var ct = CancellationToken.None;
            await using var session = new PostgreSqlSession(source); var work = new UnitOfWork(session);
            var customer = Proxy.For<ICurrentCustomer>((n, a) => n == "RequireCustomerId" ? "7" : new CartIdentityDto { CustomerId = "7" });
            var notifications = 0;
            var notify = Proxy.For<INotificationGateway>((n, a) => { notifications++; return Task.CompletedTask; });
            var distance = Proxy.For<IDistanceCalculator>((n, a) => Task.FromResult(1.5m));
            var payment = Proxy.For<IPaymentGateway>((n, a) => throw new Exception("No payment provider expected for COD."));
            var pricing = new BatchPricingPolicy(); var lifecycle = new OrderLifecycleRepository(session);
            var catalog = new CatalogService(new CatalogRepository(session), pricing);
            Assert.Single((await catalog.GetCatalogAsync(new(), ct)).Items);
            var cart = new CartService(new CartRepository(session), customer, work, pricing);
            Assert.Equal("30000", (await cart.GetCartAsync(new(), ct)).SubTotal);
            var geo = Proxy.For<IGeocodingGateway>((n, a) => Task.FromResult(new GeoPointDto { Latitude = 10, Longitude = 106 }));
            var profile = new ProfileService(new ProfileRepository(session), customer, work, geo);
            Assert.Equal("Updated", (await profile.UpdateProfileAsync(new() { FullName = "Updated", Email = "tester@example.test" }, ct)).FullName);
            var checkoutRepository = new CheckoutRepository(session, new FefoBatchSpecification());
            var checkout = new CheckoutService(checkoutRepository, customer, work, distance, payment, notify, new OrderStateMachine(lifecycle), pricing, new DeliveryFeePolicy(), NullLogger<CheckoutService>.Instance);
            var request = new PlaceOrderDto { AddressId = "2", PaymentMethod = PaymentMethod.Cod, CheckoutReference = "test-reference", IdempotencyKey = "test-key" };
            var order = await checkout.PlaceOrderAsync(request, ct);
            Assert.Equal(OrderStatus.PendingUnpaid, order.Status); Assert.Equal("50000", order.Total);
            Assert.Empty((await cart.GetCartAsync(new(), ct)).Lines);
            var replay = await checkout.PlaceOrderAsync(request, ct); Assert.Equal(order.OrderId, replay.OrderId); Assert.Equal(1, notifications);
            var conflict = await Assert.ThrowsAsync<DomainException>(() => checkout.PlaceOrderAsync(new() { AddressId = "3", PaymentMethod = PaymentMethod.Cod, CheckoutReference = "test-reference", IdempotencyKey = "test-key" }, ct));
            Assert.Equal("IDEMPOTENCY_KEY_REUSED", conflict.Code);
            var mine = new MyOrdersService(new MyOrdersRepository(session), customer, work, notify, new OrderStateMachine(lifecycle), pricing, NullLogger<MyOrdersService>.Instance);
            Assert.Single((await mine.GetOrdersAsync(ct)).Orders);
            Assert.Equal(PaymentStatus.Unpaid, (await mine.GetOrderDetailsAsync(order.OrderId, ct)).PaymentStatus);
            await mine.CancelOrderAsync(new() { OrderId = order.OrderId, Reason = "Changed mind" }, ct);
            await mine.CancelOrderAsync(new() { OrderId = order.OrderId, Reason = "Retry" }, ct);
            Assert.Equal(2, notifications);
            await using (var inspect = await source.OpenConnectionAsync())
            {
                Assert.Equal(0L, await Scalar(inspect, "SELECT reserved_stock::bigint FROM batch_inventory WHERE batch_id=1"));
                Assert.Equal(5L, await Scalar(inspect, "SELECT count(*) FROM order_transition_events"));
                Assert.Equal(1L, await Scalar(inspect, "SELECT count(*) FROM audit_logs WHERE customer_id=7 AND actor_type='CUSTOMER'"));
                Assert.Equal(1L, await Scalar(inspect, "SELECT count(*) FROM checkout_idempotency WHERE completed_at IS NOT NULL"));
            }
            await Assert.ThrowsAsync<InvalidOperationException>(() => work.ExecuteAsync(async token =>
            {
                await checkoutRepository.ClaimCheckoutAsync("7", "rollback-ref", "rollback-key", new string('a', 64), token);
                await lifecycle.RecordEventOnceAsync("checkout:7:rollback-ref", "rollback-key", "I00", token);
                throw new InvalidOperationException("Simulated domain failure");
            }, ct));
            await using (var inspect = await source.OpenConnectionAsync())
            {
                Assert.Equal(0L, await Scalar(inspect, "SELECT count(*) FROM checkout_idempotency WHERE idempotency_key='rollback-key'"));
                Assert.Equal(0L, await Scalar(inspect, "SELECT count(*) FROM order_transition_events WHERE event_id='rollback-key'"));
            }
        }
        finally
        {
            await source.DisposeAsync();
            await admin.OpenAsync();
            await using var cleanup = new NpgsqlCommand("DROP SCHEMA " + schema + " CASCADE", admin); await cleanup.ExecuteNonQueryAsync();
        }
    }
    private static async Task<long> Scalar(NpgsqlConnection connection, string sql)
    { await using var command = new NpgsqlCommand(sql, connection); return (long)(await command.ExecuteScalarAsync())!; }
    private static string FindRoot()
    {
        var p = new DirectoryInfo(AppContext.BaseDirectory);
        while (p is not null && !File.Exists(Path.Combine(p.FullName, "AGENTS.md"))) p = p.Parent;
        return p?.FullName ?? throw new InvalidOperationException("Workspace not found.");
    }
}
public sealed class PostgreSqlFactAttribute : FactAttribute
{
    public PostgreSqlFactAttribute()
    {
        if (string.IsNullOrEmpty(Environment.GetEnvironmentVariable("FRESHFOOD_TEST_DATABASE")))
            Skip = "Disposable PostgreSQL connection not configured. Set FRESHFOOD_TEST_DATABASE to execute this integration test.";
    }
}
