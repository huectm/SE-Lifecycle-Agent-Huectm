using FreshFood.Api;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Antiforgery;

var builder = WebApplication.CreateBuilder(args);
builder.WebHost.ConfigureKestrel(o => o.Limits.MaxRequestBodySize = 65536);
builder.Services.AddControllers().AddJsonOptions(o =>
{
    o.JsonSerializerOptions.PropertyNamingPolicy = null;
    o.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter(allowIntegerValues: false));
});
builder.Services.ConfigureHttpJsonOptions(o =>
{
    o.SerializerOptions.PropertyNamingPolicy = null;
    o.SerializerOptions.Converters.Add(new JsonStringEnumConverter(allowIntegerValues: false));
});
// JWT issuance/revocation integration belongs to the existing authentication subsystem.
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(o =>
{
    o.Authority = builder.Configuration["Authentication:Authority"];
    o.Audience = builder.Configuration["Authentication:Audience"];
    o.RequireHttpsMetadata = true;
    o.MapInboundClaims = false;
});
builder.Services.AddAntiforgery(o => o.HeaderName = "X-CSRF-TOKEN");
builder.Services.AddAuthorization();
ApiCompositionRoot.ConfigureServices(builder.Services, builder.Configuration);
var app = builder.Build();
app.Use(async (context, next) =>
{
    context.Response.Headers.CacheControl = "no-store"; context.Response.Headers.XContentTypeOptions = "nosniff";
    try { await next(context); }
    catch (DomainException e) { context.Response.StatusCode = e.Status; await context.Response.WriteAsJsonAsync(new { e.Code }); }
    catch (OperationCanceledException) when (context.RequestAborted.IsCancellationRequested) { context.Response.StatusCode = 499; }
    catch (Exception e) { app.Logger.LogError(e, "Request failed"); context.Response.StatusCode = 500; await context.Response.WriteAsJsonAsync(new { Code = "INTERNAL_ERROR" }); }
});
app.UseAuthentication();
app.UseAuthorization();
app.Use(async (context, next) =>
{
    if (context.User.Identity?.IsAuthenticated != true && context.Request.Method is "POST" or "PUT" or "PATCH" or "DELETE" && !context.Request.Path.Equals("/api/payments/sepay/webhook", StringComparison.OrdinalIgnoreCase))
        try { await context.RequestServices.GetRequiredService<IAntiforgery>().ValidateRequestAsync(context); }
        catch (AntiforgeryValidationException) { context.Response.StatusCode = 400; await context.Response.WriteAsJsonAsync(new { Code = "INVALID_CSRF_TOKEN" }); return; }
    await next(context);
});
app.MapGet("/health", () => new { Status = "ok" });
app.MapGet("/api/security/csrf", (HttpContext context, IAntiforgery antiforgery) => new { Token = antiforgery.GetAndStoreTokens(context).RequestToken });
app.MapControllers();
await app.RunAsync();


