using Microsoft.EntityFrameworkCore;
using Orders.Domain.Models;

namespace Orders.Application.Data;

public interface IApplicationDbContext
{
    DbSet<Order> Orders { get; }
    DbSet<Operator> Operators { get; }
    DbSet<Policy> Policys { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
