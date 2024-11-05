using Microsoft.AspNetCore.Builder;

namespace Orders.Infrastructure.Data.Extensions;

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
        await SeedOperatorAsync(context);
        await SeedPolicyAsync(context);
        await SeedOrderAsync(context);
    }

    private static async Task SeedPolicyAsync(ApplicationDbContext context)
    {
        if (!await context.Policies.AnyAsync())
        {
            await context.Policies.AddRangeAsync(InitialData.Policies());
            await context.SaveChangesAsync();
        }
    }

    private static async Task SeedOperatorAsync(ApplicationDbContext context)
    {
        if (!await context.Operators.AnyAsync())
        {
            await context.Operators.AddRangeAsync(InitialData.Operators());
            await context.SaveChangesAsync();
        }
    }

    private static async Task SeedOrderAsync(ApplicationDbContext context)
    {
        if (!await context.Orders.AnyAsync())
        {
            await context.Orders.AddRangeAsync(InitialData.Orders());
            await context.SaveChangesAsync();
        }
    }
}
