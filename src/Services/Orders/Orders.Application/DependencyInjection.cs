using BuildingBlocks.Behaviors;
using Microsoft.Extensions.DependencyInjection;
using Orders.Application.Maps;
using System.Reflection;

namespace Orders.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
            cfg.AddOpenBehavior(typeof(ValidationBehavior<,>));
            cfg.AddOpenBehavior(typeof(LoggingBehavior<,>));
        });

        services.AddHttpClient<GoogleMapsService>();

        return services;
    }
}
