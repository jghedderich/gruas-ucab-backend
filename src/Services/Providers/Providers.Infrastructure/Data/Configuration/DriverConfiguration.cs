using System.Diagnostics.CodeAnalysis;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Providers.Domain.Models;
using Providers.Domain.ValueObjects;

namespace Providers.Infrastructure.Data.Configuration;

[ExcludeFromCodeCoverage]
public class DriverConfiguration : IEntityTypeConfiguration<Driver>
{
    public void Configure(EntityTypeBuilder<Driver> builder)
    {
        builder.HasKey(d => d.Id);

        builder.ComplexProperty(d => d.DriverName, nameBuilder =>
        {
            nameBuilder.Property(n => n.FirstName).HasMaxLength(50).IsRequired();
            nameBuilder.Property(n => n.LastName).HasMaxLength(50).IsRequired();
        });

        builder.ComplexProperty(d => d.Email, emailBuilder =>
        {
            emailBuilder.Property(e => e.Value).HasMaxLength(255);
        });

        builder.ComplexProperty(p => p.Password, passwordBuilder =>
        {
            passwordBuilder.Property(p => p.Value).HasMaxLength(255);
        });

        builder.ComplexProperty(d => d.Dni, dniBuilder =>
        {
            dniBuilder.Property(d => d.Number).HasMaxLength(8).IsRequired();
            dniBuilder.Property(d => d.Type).HasMaxLength(1).IsRequired();
            dniBuilder.Property(d => d.Type)
                .HasConversion(t => t.ToString(),
                dniType => (DniType)Enum.Parse(typeof(DniType), dniType));
        });

        builder.ComplexProperty(d => d.Phone, phoneBuilder =>
        {
            phoneBuilder.Property(p => p.Value).HasMaxLength(11).IsRequired();
        });

        builder.Property(d => d.Status)
            .HasConversion(s => s.ToString(),
            status => (Status)Enum.Parse(typeof(Status), status));

        builder.OwnsOne(d => d.Location, locationBuilder =>
        {
            locationBuilder.Property(l => l.AddressLine1).HasMaxLength(50).IsRequired();
            locationBuilder.Property(l => l.AddressLine2).HasMaxLength(50).IsRequired(false);
            locationBuilder.Property(l => l.State).HasMaxLength(50).IsRequired();
            locationBuilder.Property(l => l.Zip).HasMaxLength(4).IsRequired();
            locationBuilder.Property(l => l.City).HasMaxLength(50).IsRequired();
            locationBuilder.OwnsOne(l => l.Coordinates, coordinatesBuilder =>
            {
                coordinatesBuilder.Property(c => c.Latitude).HasMaxLength(50).IsRequired(true);
                coordinatesBuilder.Property(c => c.Longitude).HasMaxLength(50).IsRequired(true);
            });
        });

        builder.Property(d => d.Token).HasMaxLength(250);
    }
}