namespace FreshFood.Reposistory.Entities;

[JsonConverter(typeof(VndAmountConverter))]
public readonly record struct VndAmount
{
    public decimal Units { get; }
    public VndAmount(decimal units)
    {
        if (units < 0 || units > 999999999999999999m || decimal.Truncate(units) != units)
            throw new DomainException("INVALID_VND_AMOUNT");
        Units = units;
    }
    public static VndAmount FromUnits(decimal units) => new(units);
    public VndAmount Add(VndAmount other) => new(Units + other.Units);
    public string ToWire() => Units.ToString("0", CultureInfo.InvariantCulture);
    public override string ToString() => ToWire();
}
public sealed class VndAmountConverter : JsonConverter<VndAmount>
{
    public override VndAmount Read(ref Utf8JsonReader reader, Type type, JsonSerializerOptions options) =>
        new(reader.TokenType == JsonTokenType.String ? decimal.Parse(reader.GetString()!, CultureInfo.InvariantCulture) : reader.GetDecimal());
    public override void Write(Utf8JsonWriter writer, VndAmount value, JsonSerializerOptions options) => writer.WriteStringValue(value.ToWire());
}
