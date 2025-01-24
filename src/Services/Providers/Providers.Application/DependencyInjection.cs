using BuildingBlocks.Behaviors;
using BuildingBlocks.Messaging.MassTransit;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Providers.Application.Settings;
using System.Reflection;

namespace Providers.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
            cfg.AddOpenBehavior(typeof(ValidationBehavior<,>));
            cfg.AddOpenBehavior(typeof(LoggingBehavior<,>));
        });

        services.AddMessageBroker(configuration, Assembly.GetExecutingAssembly());

        services.Configure<FirebaseMessagingSettings>(options =>
        {
            options.ChannelId = "default_channel";
            options.MessageSound = "default";
        });
        services.AddScoped<IFirebaseMessagingService, FirebaseMessagingService>();
        services.AddScoped<IFirebaseAppClient, FirebaseAppClient>();
        services.AddScoped<IFirebaseMessagingClient, FirebaseMessagingClient>();

        return services;
    }
}
