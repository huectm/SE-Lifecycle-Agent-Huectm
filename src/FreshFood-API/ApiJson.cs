namespace FreshFood.Api;

public static class ApiJson
{
    public static readonly JsonSerializerOptions Options = Create();
    private static JsonSerializerOptions Create()
    { var options = new JsonSerializerOptions { PropertyNamingPolicy = null, PropertyNameCaseInsensitive = true }; options.Converters.Add(new JsonStringEnumConverter(allowIntegerValues: false)); return options; }
}
