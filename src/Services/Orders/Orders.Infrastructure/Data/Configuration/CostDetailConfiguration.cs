using global::Orders.Domain.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Orders.Domain.ValueObjects;

namespace Orders.Infrastructure.Data.Configuration;
public class CostDetailConfiguration : IEntityTypeConfiguration<CostDetail>
{
    public void Configure(EntityTypeBuilder<CostDetail> builder)
    {
        builder.HasKey(o => o.Id);


        builder.Property(c => c.Description).IsRequired().HasMaxLength(300);

        builder.Property(c => c.Amount).HasColumnType("decimal(18,2)").IsRequired();

        builder.ComplexProperty(o => o.StatusC, costDetailStatusBuilder =>
        {
            costDetailStatusBuilder.Property(os => os.StatusCO)
                .HasConversion(os => os.ToString(),
                statusCO => (StatusCO)Enum.Parse(typeof(StatusCO), statusCO));
        });
    }
}
