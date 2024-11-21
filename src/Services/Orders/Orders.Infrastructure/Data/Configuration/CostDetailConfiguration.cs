using global::Orders.Domain.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Orders.Infrastructure.Data.Configuration;
public class CostDetailConfiguration : IEntityTypeConfiguration<CostDetail>
{
    public void Configure(EntityTypeBuilder<CostDetail> builder)
    {
        builder.HasKey(o => o.Id);


        builder.Property(c => c.Description).IsRequired().HasMaxLength(300);

        builder.Property(c => c.Amount).IsRequired().HasMaxLength(20);

        builder.Property(c => c.IsApproved).IsRequired().HasMaxLength(5);
    }
}
