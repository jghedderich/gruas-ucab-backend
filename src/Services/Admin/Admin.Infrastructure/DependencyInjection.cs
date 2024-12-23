using Admin.Application.Data;
using Admin.Infrastructure.Data;
using Admin.Infrastructure.Data.Interceptors;
using Admin.Infrastructure.Settings;
using BuildingBlocks.Caching;
using BuildingBlocks.Hashing;
using BuildingBlocks.Emails;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Admin.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructureServices
        (this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("Database");

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

        services.Configure<FirebaseMessagingSettings>(options =>
        {
            options.ChannelId = "default_channel";
            options.MessageSound = "default";
        });
        services.AddScoped<IFirebaseMessagingService, FirebaseMessagingService>();
        services.AddScoped<IFirebaseAppClient, FirebaseAppClient>();
        services.AddScoped<IFirebaseMessagingClient, FirebaseMessagingClient>();

        services.AddDbContext<ApplicationDbContext>((sp, options) =>
        {
            options.AddInterceptors(sp.GetServices<ISaveChangesInterceptor>());
            options.UseSqlServer(connectionString);
        });

        services.AddScoped<IApplicationDbContext, ApplicationDbContext>();

        return services;
    }
}
