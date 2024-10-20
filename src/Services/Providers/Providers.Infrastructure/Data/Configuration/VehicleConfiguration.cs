using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Providers.Domain.Models;
using Providers.Domain.ValueObjects;

namespace Providers.Infrastructure.Data.Configuration;

public class VehicleConfiguration : IEntityTypeConfiguration<Vehicle>
{
    public void Configure(EntityTypeBuilder<Vehicle> builder)
    {
        builder.HasKey(p => p.Id);

        builder.ComplexProperty(v => v.Brand, brandBuilder =>
        {
            brandBuilder.Property(b => b.Value).HasMaxLength(100).IsRequired();
        });

        builder.ComplexProperty(v => v.Model, modelBuilder =>
        {
            modelBuilder.Property(m => m.Value).HasMaxLength(100).IsRequired();
        });

        builder.Property(p => p.Year).HasMaxLength(4);

        builder.Property(v => v.Type)
            .HasConversion(t => t.ToString(),
            vehicleType => (VehicleType)Enum.Parse(typeof(VehicleType), vehicleType));
    }
}
