using Microsoft.EntityFrameworkCore;
using Admin.Application.Data;
using Admin.Domain.Models;
using System.Reflection;
using static System.Net.Mime.MediaTypeNames;
namespace Admin.Infrastructure.Data;

public class ApplicationDbContext : DbContext, IApplicationDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options) { }

    public DbSet<Administrator> Administrators => Set<Administrator>();
    public DbSet<Department> Departments => Set<Department>();
    public DbSet<Rate> Rates => Set<Rate>();

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(builder);
    }
}
