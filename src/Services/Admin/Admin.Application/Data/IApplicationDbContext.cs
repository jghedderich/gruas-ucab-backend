
namespace Admin.Application.Data;

public interface IApplicationDbContext
{
    DbSet<Administrator> Administrators { get; }
    DbSet<Department> Departments { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
