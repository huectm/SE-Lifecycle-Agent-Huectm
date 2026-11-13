using FreshFood.Reposistory.Entities;
using FreshFood.Reposistory.Repository;

namespace FreshFood.Backend.UnitTests;

// Shared mock setup only. The repository call and all assertions stay in each test.
internal sealed class RepositorySessionFixture
{
    internal sealed record RecordedQuery(string Sql, object?[] Parameters, CancellationToken Token);
    internal List<RecordedQuery> Queries { get; } = [];
    internal IRepositorySession Session { get; }

    internal RepositorySessionFixture(bool emptyRows = false, Exception? queryError = null,
        string key = "Sample", string reference = "Sample", string? requestHash = null)
    {
        Session = (IRepositorySession)StrictProxy.Create(typeof(IRepositorySession), (method, arguments) =>
        {
            if (method.Name == "get_Active") return true;
            if (method.Name != "QueryAsync") throw new InvalidOperationException("Unexpected session call: " + method.Name);
            var sql = (string)arguments[0]!;
            Queries.Add(new(sql, (object?[])arguments[1]!, (CancellationToken)arguments[2]!));
            if (queryError is not null) throw queryError;

            var rowType = method.GetGenericArguments()[0];
            var rows = (System.Collections.IList)Activator.CreateInstance(typeof(List<>).MakeGenericType(rowType))!;
            var creation = sql.StartsWith("INSERT INTO carts", StringComparison.Ordinal) || sql.StartsWith("INSERT INTO orders", StringComparison.Ordinal);
            if (!emptyRows || creation)
            {
                var row = Fixture.Value(rowType)!;
                if (row is Cart cart) { cart.CartId = "1"; cart.CustomerId = "7"; }
                if (row is Order order) { order.OrderId = "1"; order.CustomerId = "7"; order.DeliveryAddressId = "2"; }
                if (rowType.Name == "ClaimRow")
                {
                    rowType.GetProperty("IdempotencyKey")!.SetValue(row, key);
                    rowType.GetProperty("CheckoutReference")!.SetValue(row, reference);
                    rowType.GetProperty("RequestHash")!.SetValue(row, requestHash ?? new string('a', 64));
                    rowType.GetProperty("Response")!.SetValue(row, null);
                }
                rows.Add(row);
            }
            return typeof(Task).GetMethod(nameof(Task.FromResult))!.MakeGenericMethod(rows.GetType()).Invoke(null, [rows]);
        });
    }
}
