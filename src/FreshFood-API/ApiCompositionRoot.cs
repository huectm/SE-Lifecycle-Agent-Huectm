using Npgsql;

namespace FreshFood.Api;

public static class ApiCompositionRoot
{
    public static void ConfigureServices(IServiceCollection services, IConfiguration configuration)
    {
        services.AddHttpContextAccessor(); services.AddDataProtection();
        services.AddSingleton(_ => NpgsqlDataSource.Create(configuration.GetConnectionString("FreshFood") ?? throw new DomainException("DATABASE_NOT_CONFIGURED", 503)));
        services.AddScoped<IRepositorySession, PostgreSqlSession>(); services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<ICurrentCustomer, CurrentCustomer>();
        services.AddScoped<ICatalogRepository, CatalogRepository>(); services.AddScoped<ICartRepository, CartRepository>();
        services.AddScoped<IProfileRepository, ProfileRepository>(); services.AddScoped<ICheckoutRepository, CheckoutRepository>();
        services.AddScoped<IMyOrdersRepository, MyOrdersRepository>(); services.AddScoped<IOrderLifecycleRepository, OrderLifecycleRepository>();
        services.AddScoped<ICatalogService, CatalogService>(); services.AddScoped<ICartService, CartService>(); services.AddScoped<IProfileService, ProfileService>();
        services.AddScoped<ICheckoutService, CheckoutService>(); services.AddScoped<IMyOrdersService, MyOrdersService>();
        services.AddScoped<IOrderStateMachine, OrderStateMachine>();
        services.AddSingleton<IBatchPricingPolicy, BatchPricingPolicy>(); services.AddSingleton<IDeliveryFeePolicy, DeliveryFeePolicy>(); services.AddSingleton<IFefoBatchSpecification, FefoBatchSpecification>();
        services.AddScoped<IGeocodingGateway, GoogleMapsGeocodingAdapter>(); services.AddScoped<IDistanceGateway, GoogleMapsDistanceAdapter>(); services.AddScoped<IDistanceCalculator, DistanceCalculator>();
        services.AddScoped<IPaymentGateway, SePayPaymentAdapter>(); services.AddScoped<INotificationPublisher, ConfiguredNotificationPublisher>(); services.AddScoped<INotificationGateway, NotificationAdapter>();
        services.AddScoped<IPayoutPort, UnconfiguredPayoutAdapter>(); services.AddScoped<PaymentNoticeHandler>();
    }
}
