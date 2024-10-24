
namespace Providers.Application.Data;

public interface IApplicationDbContext
{
    DbSet<Provider> Providers { get; }
    DbSet<Vehicle> Vehicles { get; }
    DbSet<Driver> Drivers { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
