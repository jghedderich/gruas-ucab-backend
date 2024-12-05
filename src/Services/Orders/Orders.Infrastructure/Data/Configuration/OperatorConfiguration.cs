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
        // builder.HasMany(a => a.Orders)
            // .WithOne()
            // .HasForeignKey(a => a.OperatorId);

        builder.ComplexProperty(o => o.OperatorName, nameBuilder =>
        {
            nameBuilder.Property(n => n.FirstName).HasMaxLength(50).IsRequired();
            nameBuilder.Property(n => n.LastName).HasMaxLength(50).IsRequired();
        });

        builder.ComplexProperty(o => o.Email, emailBuilder =>
        {
            emailBuilder.Property(o => o.Value).HasMaxLength(255).IsRequired();
        });

        builder.ComplexProperty(o => o.Phone, phoneBuilder =>
        {
            phoneBuilder.Property(p => p.Value).HasMaxLength(11).IsRequired();
        });

        builder.ComplexProperty(o => o.Dni, dniBuilder =>
        {
            dniBuilder.Property(d => d.Number).HasMaxLength(8).IsRequired();
            dniBuilder.Property(d => d.Type).HasMaxLength(1).IsRequired();
            dniBuilder.Property(d => d.Type)
                .HasConversion(t => t.ToString(),
                dniType => (DniType)Enum.Parse(typeof(DniType), dniType));
        });

        builder.ComplexProperty(o => o.Password, passwordBuilder =>
        {
            passwordBuilder.Property(p => p.Value).HasMaxLength(255);
        });
    }
}
