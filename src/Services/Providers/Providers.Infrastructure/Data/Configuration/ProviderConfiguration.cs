using System.Diagnostics.CodeAnalysis;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Providers.Domain.Models;
using Providers.Domain.ValueObjects;

namespace Providers.Infrastructure.Data.Configuration;

[ExcludeFromCodeCoverage]
public class ProviderConfiguration : IEntityTypeConfiguration<Provider>
{
    public void Configure(EntityTypeBuilder<Provider> builder)
    {
        builder.HasKey(p => p.Id);
   
        // provider has many drivers
        builder.HasMany(d => d.Drivers)
            .WithOne()
            .HasForeignKey(d => d.ProviderId);

        // provider has many vehicles
        builder.HasMany(v => v.Vehicles)
            .WithOne()
            .HasForeignKey(v => v.ProviderId);

        builder.ComplexProperty(p => p.ProviderName, nameBuilder =>
        {
            nameBuilder.Property(n => n.FirstName).HasMaxLength(50).IsRequired();
            nameBuilder.Property(n => n.LastName).HasMaxLength(50).IsRequired();
        });

        builder.ComplexProperty(p => p.Email, emailBuilder =>
        {
            emailBuilder.Property(p => p.Value).HasMaxLength(255);
        });

        builder.ComplexProperty(p => p.Password, passwordBuilder =>
        {
            passwordBuilder.Property(p => p.Value).HasMaxLength(255);
        });

        builder.ComplexProperty(p => p.Dni, dniBuilder =>
        {
            dniBuilder.Property(d => d.Number).HasMaxLength(8).IsRequired();
            dniBuilder.Property(d => d.Type).HasMaxLength(1).IsRequired();
            dniBuilder.Property(d => d.Type)
                .HasConversion(t => t.ToString(),
                dniType => (DniType)Enum.Parse(typeof(DniType), dniType));
        });

        builder.ComplexProperty(p => p.Phone, phoneBuilder =>
        {
            phoneBuilder.Property(d => d.Value).HasMaxLength(11).IsRequired();
        });

            builder.ComplexProperty(p => p.Company, companyBuilder =>
        {
            companyBuilder.Property(p => p.Name).HasMaxLength(50).IsRequired();
            companyBuilder.Property(p => p.Description).HasMaxLength(50).IsRequired();
            companyBuilder.Property(p => p.State).HasMaxLength(50).IsRequired();
            companyBuilder.Property(p => p.City).HasMaxLength(50).IsRequired();
            companyBuilder.Property(p => p.Rif).HasMaxLength(10).IsRequired();
        });
    }
}
