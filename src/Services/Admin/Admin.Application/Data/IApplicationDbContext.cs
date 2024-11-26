using Admin.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Admin.Application.Data;

public interface IApplicationDbContext
{
    DbSet<Administrator> Administrators { get; }
    DbSet<Department> Departments { get; }
    DbSet<Rate> Rates { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
