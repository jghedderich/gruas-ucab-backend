using Microsoft.EntityFrameworkCore;
using Providers.Domain.Models;
using System.Reflection;
namespace Providers.Infrastructure.Data;

internal class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
{
    public DbSet<Provider> Providers => Set<Provider>();
    public DbSet<Vehicle> Vehicles => Set<Vehicle>();
    public DbSet<Driver> Drivers => Set<Driver>();

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(builder);
    }
}
