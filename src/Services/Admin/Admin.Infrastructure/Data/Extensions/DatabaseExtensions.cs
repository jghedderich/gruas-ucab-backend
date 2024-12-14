using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;

namespace Admin.Infrastructure.Data.Extensions
{
    public static class DatabaseExtensions
    {
        public static async Task InitializeDatabase(this WebApplication app)
        {
            using var scope = app.Services.CreateScope();

            var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

            await context.Database.MigrateAsync();

            await SeedAsync(context);
        }

        private static async Task SeedAsync(ApplicationDbContext context)
        {
            await SeedAdministratorAsync(context);
            await SeedDepartmentAsync(context);
            await SeedRateAsync(context);
            
        }

        private static async Task SeedAdministratorAsync(ApplicationDbContext context)
        {
            if (!await context.Administrators.AnyAsync())
            {
                
                await context.Administrators.AddRangeAsync(InitialData.Administrators());
                await context.SaveChangesAsync();
            }
        }

        private static async Task SeedDepartmentAsync(ApplicationDbContext context)
        {
            if (!await context.Departments.AnyAsync())
            {
               
                await context.Departments.AddRangeAsync(InitialData.Departments());
                await context.SaveChangesAsync();
            }
        }

        private static async Task SeedRateAsync(ApplicationDbContext context)
        {
            if (!await context.Rates.AnyAsync())
            {
                
                await context.Rates.AddRangeAsync(InitialData.Rates());
                await context.SaveChangesAsync();
            }
        }
    }
}
