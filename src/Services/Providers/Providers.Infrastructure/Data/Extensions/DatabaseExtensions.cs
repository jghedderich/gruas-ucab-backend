
using Microsoft.AspNetCore.Builder;

namespace Providers.Infrastructure.Data.Extensions;

public static class DatabaseExtensions
{
    public static async Task InitializeDatabase(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();

        var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

        context.Database.MigrateAsync().GetAwaiter().GetResult();

        await SeedAsync(context);
    }

    private static async Task SeedAsync(ApplicationDbContext context)
    {
        await SeedProviderAsync(context);
        await SeedDriverAsync(context);
        await SeedVehicleAsync(context);
    }

    private static async Task SeedProviderAsync(ApplicationDbContext context)
    {
        if (!await context.Providers.AnyAsync())
        {
            await context.Providers.AddRangeAsync(InitialData.Providers());
            await context.SaveChangesAsync();
        }
    }
    private static async Task SeedVehicleAsync(ApplicationDbContext context)
    {
        if (!await context.Vehicles.AnyAsync())
        {
            await context.Vehicles.AddRangeAsync(InitialData.Vehicles());
            await context.SaveChangesAsync();
        }
    }
    private static async Task SeedDriverAsync(ApplicationDbContext context)
    {
        if (!await context.Drivers.AnyAsync())
        {
            await context.Drivers.AddRangeAsync(InitialData.Drivers());
            await context.SaveChangesAsync();
        }
    }
}
