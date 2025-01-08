using Orders.Infrastructure.Data.Interceptors;
using Orders.Infrastructure.Data;
using BuildingBlocks.Emails;
using BuildingBlocks.Caching;
using BuildingBlocks.Hashing;
using BuildingBlocks.Jwt;

namespace Orders.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructureServices
        (this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("Database");

        // Add services to the container.
        services.AddScoped<ISaveChangesInterceptor, AuditableEntityInterceptor>();
        services.AddScoped<ISaveChangesInterceptor, DispatchDomainEventsInterceptor>();

        services.AddTransient<IEmailSender, EmailSender>();

        services.AddStackExchangeRedisCache(options =>
        {
            options.Configuration = configuration.GetConnectionString("Redis");
            options.InstanceName = "Codes_";
        });

        services.AddTransient<IPasswordHasher, PasswordHasher>();

        services.AddScoped<IRedisCacheService, RedisCacheService>();

        services.AddSingleton<TokenProvider>();

        services.AddDbContext<ApplicationDbContext>((sp, options) =>
        {
            options.AddInterceptors(sp.GetServices<ISaveChangesInterceptor>());
            options.UseSqlServer(connectionString);
        });

        services.AddScoped<IApplicationDbContext, ApplicationDbContext>();

        return services;
    }
}
