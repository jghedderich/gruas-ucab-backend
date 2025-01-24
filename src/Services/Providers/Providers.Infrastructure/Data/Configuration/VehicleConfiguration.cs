using System.Diagnostics.CodeAnalysis;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Providers.Domain.Models;

namespace Providers.Infrastructure.Data.Configuration;

[ExcludeFromCodeCoverage]
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

        builder.Property(p => p.LicensePlate).HasMaxLength(7);

        builder.Property(p => p.Color).HasMaxLength(7);

        builder.Property(v => v.Type)
            .HasConversion(t => t.ToString(),
            vehicleType => (VehicleType)Enum.Parse(typeof(VehicleType), vehicleType));
    }
}
