using System.Reflection;
using NpgsqlTypes;

namespace FreshFood.Reposistory.Repository.Implements;

public sealed class PostgreSqlSession(NpgsqlDataSource dataSource) : IRepositorySession
{
    private NpgsqlConnection? connection;
    private NpgsqlTransaction? transaction;
    public bool Active => transaction is not null;
    public async Task BeginAsync(CancellationToken signal)
    {
        if (connection is not null) throw new InvalidOperationException("Nested transactions are not supported.");
        connection = await dataSource.OpenConnectionAsync(signal);
        try { transaction = await connection.BeginTransactionAsync(signal); }
        catch { await connection.DisposeAsync(); connection = null; throw; }
    }
    public async Task CommitAsync(CancellationToken signal)
    {
        if (transaction is null) throw new InvalidOperationException("No transaction.");
        await transaction.CommitAsync(signal);
        await DisposeAsync();
    }
    public async Task RollbackAsync(CancellationToken signal)
    {
        try { if (transaction is not null) await transaction.RollbackAsync(signal); }
        finally { await DisposeAsync(); }
    }
    public async ValueTask DisposeAsync()
    {
        if (transaction is not null) await transaction.DisposeAsync();
        if (connection is not null) await connection.DisposeAsync();
        transaction = null; connection = null;
    }
    public async Task<List<T>> QueryAsync<T>(string sql, object?[] parameters, CancellationToken signal) where T : new()
    {
        var leased = connection is null;
        var client = connection ?? await dataSource.OpenConnectionAsync(signal);
        try
        {
            await using var command = new NpgsqlCommand(sql, client, transaction);
            foreach (var value in parameters)
            {
                var p = new NpgsqlParameter { Value = value ?? DBNull.Value };
                if (value is null) p.NpgsqlDbType = NpgsqlDbType.Unknown;
                command.Parameters.Add(p);
            }
            await using var reader = await command.ExecuteReaderAsync(signal);
            var props = typeof(T).GetProperties(BindingFlags.Instance | BindingFlags.Public)
                .ToDictionary(p => p.Name.Replace("_", ""), StringComparer.OrdinalIgnoreCase);
            var result = new List<T>();
            while (await reader.ReadAsync(signal))
            {
                var item = new T();
                for (var i = 0; i < reader.FieldCount; i++)
                {
                    if (reader.IsDBNull(i) || !props.TryGetValue(reader.GetName(i).Replace("_", ""), out var prop) || !prop.CanWrite) continue;
                    var value = reader.GetValue(i);
                    var t = Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType;
                    object converted = t == typeof(string) ? Convert.ToString(value, CultureInfo.InvariantCulture)!
                        : t == typeof(VndAmount) ? new VndAmount(Convert.ToDecimal(value, CultureInfo.InvariantCulture))
                        : t == typeof(DateTimeOffset) && value is DateTime dt ? new DateTimeOffset(DateTime.SpecifyKind(dt, DateTimeKind.Utc))
                        : t == typeof(DateOnly) && value is DateOnly date ? date
                        : t.IsEnum ? Enum.Parse(t, value.ToString()!.Replace("_", ""), true)
                        : Convert.ChangeType(value, t, CultureInfo.InvariantCulture);
                    prop.SetValue(item, converted);
                }
                result.Add(item);
            }
            return result;
        }
        finally { if (leased) await client.DisposeAsync(); }
    }
}
