using BuildingBlocks.Caching;
using BuildingBlocks.Emails;
using BuildingBlocks.Hashing;
using BuildingBlocks.Jwt;
using Providers.Application.Data;
using Providers.Infrastructure.Data.Interceptors;

namespace Providers.Infrastructure;

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

        services.AddTransient<IPasswordHasher, PasswordHasher>();

        services.AddStackExchangeRedisCache(options =>
        {
            options.Configuration = configuration.GetConnectionString("Redis");
            options.InstanceName = "Codes_";
        });

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
