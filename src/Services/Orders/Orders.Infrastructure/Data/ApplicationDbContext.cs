using Orders.Domain.Models;
using System.Reflection;

namespace Orders.Infrastructure.Data;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options), IApplicationDbContext
{
    public DbSet<CostDetail> CostDetails => Set<CostDetail>();
    public DbSet<Order> Orders => Set<Order>();
    public DbSet<Operator> Operators => Set<Operator>();
    public DbSet<Policy> Policies => Set<Policy>();

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(builder);
    }
}
