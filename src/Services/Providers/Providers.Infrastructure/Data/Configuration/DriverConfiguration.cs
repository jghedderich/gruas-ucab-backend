using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Providers.Domain.Models;
using Providers.Domain.ValueObjects;

namespace Providers.Infrastructure.Data.Configuration;

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


        builder.ComplexProperty(d => d.Status, statusBuilder =>
        {
            statusBuilder.Property(s => s.Type)
                .HasConversion(n => n.ToString(),
                statusType => (StatusType)Enum.Parse(typeof(StatusType), statusType));
        });
    }
}