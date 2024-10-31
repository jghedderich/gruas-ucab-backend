using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Orders.Domain.Models;
using Orders.Domain.ValueObjects;

namespace Orders.Infrastructure.Data.Configuration;

public class OrderConfiguration : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.HasKey(o => o.Id);

        builder.ComplexProperty(o => o.Client, clientBuilder =>
        {
            clientBuilder.ComplexProperty(n => n.Name, nameBuilder =>
            {
                nameBuilder.Property(a => a.FirstName).HasMaxLength(50).IsRequired();
                nameBuilder.Property(a => a.LastName).HasMaxLength(50).IsRequired();
            });

            clientBuilder.ComplexProperty(n => n.Dni, dniBuilder =>
            {
                dniBuilder.Property(d => d.Number).HasMaxLength(8).IsRequired();
                dniBuilder.Property(d => d.Type).HasMaxLength(1).IsRequired();
                dniBuilder.Property(d => d.Type)
                    .HasConversion(t => t.ToString(),
                    dniType => (DniType)Enum.Parse(typeof(DniType), dniType));
            });

            clientBuilder.ComplexProperty(n => n.Phone, phoneBuilder =>
            {
                phoneBuilder.Property(d => d.Value).HasMaxLength(11).IsRequired();
            });

            clientBuilder.ComplexProperty(n => n.Email, emailBuilder =>
            {
                emailBuilder.Property(p => p.Value).HasMaxLength(255);
            });

            clientBuilder.ComplexProperty(n => n.ClientVehicle, vehicleBuilder =>
            {
                vehicleBuilder.Property( v => v.Brand).HasMaxLength(100).IsRequired();
                vehicleBuilder.Property( v => v.Model).HasMaxLength(100).IsRequired(); 
                vehicleBuilder.Property( v => v.Year).HasMaxLength(4);
                vehicleBuilder.Property( v => v.Type)
                    .HasConversion(t => t.ToString(),
                    vehicleType => (VehicleType)Enum.Parse(typeof(VehicleType), vehicleType));
            });
        });
    }
}
