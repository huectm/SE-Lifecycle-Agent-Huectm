namespace FreshFood.Api.Services.Implements;

internal static class ServiceRules
{
    internal static void Require(bool test, string code, int status = 400) { if (!test) throw new DomainException(code, status); }
    internal static string Text(string? value, string code = "INVALID_TEXT") { Require(!string.IsNullOrWhiteSpace(value), code); return value!.Trim(); }
    internal static string Id(string value) { Require(long.TryParse(value, out var n) && n > 0, "INVALID_ID"); return value; }
    internal static string Key(string value) { Require(!string.IsNullOrWhiteSpace(value) && value.Length <= 128, "INVALID_REFERENCE"); return value; }
    internal static bool Sellable(BatchInventory b) => b.SaleStatus is "ACTIVE" or "DISCOUNTED" && b.ExpiryDate >= DateOnly.FromDateTime(DateTime.UtcNow) && b.CurrentStock > b.ReservedStock;
    internal static List<BatchInventory> Fefo(IEnumerable<BatchInventory> batches) => batches.Where(Sellable).OrderBy(b => b.ExpiryDate).ThenBy(b => long.Parse(b.BatchId, CultureInfo.InvariantCulture)).ToList();
    internal static string Money(decimal value) => new VndAmount(value).ToWire();
    internal static OrderSummaryDto Summary(Order o) => new() { OrderId = o.OrderId, OrderNumber = o.OrderNumber, OrderDate = o.OrderDate, Status = o.OrderStatus, Total = o.TotalAmount.ToWire() };
    internal static AddressDto Address(CustomerAddress a) => new() { AddressId = a.AddressId, RecipientName = a.RecipientName, RecipientPhone = a.RecipientPhone, StreetAddress = a.StreetAddress, Latitude = a.Latitude, Longitude = a.Longitude, IsDefault = a.IsDefault };
}
