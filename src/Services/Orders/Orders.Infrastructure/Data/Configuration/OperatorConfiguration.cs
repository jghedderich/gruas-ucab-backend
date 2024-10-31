using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Orders.Domain.Models;
using Orders.Domain.ValueObjects;

namespace Orders.Infrastructure.Data.Configuration;

public class OperatorConfiguration : IEntityTypeConfiguration<Operator>
{
    public void Configure(EntityTypeBuilder<Operator> builder)
    {
        builder.HasKey(o => o.Id);

        // Operator has many orders
        builder.HasMany(a => a.Orders)
            .WithOne()
            .HasForeignKey(o => o.OperatorId);
    }
}
