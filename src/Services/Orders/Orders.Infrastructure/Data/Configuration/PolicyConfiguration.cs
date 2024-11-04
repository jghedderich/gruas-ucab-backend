using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Orders.Domain.Models;
using Orders.Domain.ValueObjects;

namespace Orders.Infrastructure.Data.Configuration;

public class PolicyConfiguration : IEntityTypeConfiguration<Policy>
{
    public void Configure(EntityTypeBuilder<Policy> builder)
    {
        builder.HasKey(o => o.Id);

        builder.Property(o => o.Name).HasMaxLength(55).IsRequired();

        builder.Property(o => o.AmountCovered).HasMaxLength(5).IsRequired();

        builder.ComplexProperty(o => o.Price, priceBuilder =>
        {
            priceBuilder.Property(p => p.AnnualPrice).HasMaxLength(5);
            priceBuilder.Property(p => p.MonthlyPrice).HasMaxLength(5);
        });

        builder.ComplexProperty(o => o.Fees, feeBuilder =>
        {
            feeBuilder.Property(f => f.BaseFee).HasMaxLength(5).IsRequired();
            feeBuilder.Property(f => f.PerKm).HasMaxLength(10).IsRequired();
        });
    }
}
