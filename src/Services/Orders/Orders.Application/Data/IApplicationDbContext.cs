using Microsoft.EntityFrameworkCore;
using Orders.Domain.Models;

namespace Orders.Application.Data;

public interface IApplicationDbContext
{
    DbSet<CostDetail> CostDetails { get; }
    DbSet<Order> Orders { get; }
    DbSet<Operator> Operators { get; }
    DbSet<Policy> Policies { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
