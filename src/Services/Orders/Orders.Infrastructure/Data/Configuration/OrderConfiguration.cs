using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Orders.Domain.Models;
using Orders.Domain.ValueObjects;

namespace Orders.Infrastructure.Data.Configuration;

public class OrderConfiguration : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.HasKey(o => o.Id);

        builder.HasMany(a => a.CostDetails)
            .WithOne()
            .HasForeignKey(a => a.OrderId);

        builder.OwnsOne(o => o.Client, clientBuilder =>
        {
            clientBuilder.OwnsOne(n => n.Name, nameBuilder =>
            {
                nameBuilder.Property(a => a.FirstName).HasMaxLength(50).IsRequired();
                nameBuilder.Property(a => a.LastName).HasMaxLength(50).IsRequired();
            });

            clientBuilder.OwnsOne(n => n.Dni, dniBuilder =>
            {
                dniBuilder.Property(d => d.Number).HasMaxLength(8).IsRequired();
                dniBuilder.Property(d => d.Type).HasMaxLength(1).IsRequired();
                dniBuilder.Property(d => d.Type)
                    .HasConversion(t => t.ToString(),
                    dniType => (DniType)Enum.Parse(typeof(DniType), dniType));
            });

            clientBuilder.OwnsOne(n => n.Phone, phoneBuilder =>
            {
                phoneBuilder.Property(d => d.Value).HasMaxLength(11).IsRequired();
            });

            clientBuilder.OwnsOne(n => n.Email, emailBuilder =>
            {
                emailBuilder.Property(p => p.Value).HasMaxLength(255);
            });

            clientBuilder.OwnsOne(n => n.ClientVehicle, vehicleBuilder =>
            {
                vehicleBuilder.Property( v => v.Brand).HasMaxLength(100).IsRequired();
                vehicleBuilder.Property( v => v.Model).HasMaxLength(100).IsRequired(); 
                vehicleBuilder.Property( v => v.Year).HasMaxLength(4);
                vehicleBuilder.Property( v => v.TypeV)
                    .HasConversion(t => t.ToString(),
                    vehicleType => (VehicleType)Enum.Parse(typeof(VehicleType), vehicleType));
            });
        });

        builder.ComplexProperty(o => o.OrderStatus, orderStatusBuilder =>
        {
            orderStatusBuilder.Property(os => os.Status)
                .HasConversion(os => os.ToString(),
                status => (Status)Enum.Parse(typeof(Status), status));
        });

        builder.ComplexProperty(o => o.IncidentAddress, incidentAddressBuilder =>
        {
            incidentAddressBuilder.Property( ia => ia.AddressLine1).HasMaxLength(500).IsRequired();
            incidentAddressBuilder.Property( ia => ia.AddressLine2).HasMaxLength(500);
            incidentAddressBuilder.Property( ia => ia.City).HasMaxLength(50).IsRequired();
            incidentAddressBuilder.Property( ia => ia.State).HasMaxLength(50).IsRequired();
            incidentAddressBuilder.Property(ia => ia.Zip).HasMaxLength(4).IsRequired();
        });

        builder.ComplexProperty(o => o.DestinationAddress, destinationAddresBuilder =>
        {
            destinationAddresBuilder.Property(da => da.AddressLine1).HasMaxLength(500).IsRequired();
            destinationAddresBuilder.Property(da => da.AddressLine2).HasMaxLength(500);
            destinationAddresBuilder.Property(da => da.City).HasMaxLength(50).IsRequired();
            destinationAddresBuilder.Property(da => da.State).HasMaxLength(50).IsRequired();
            destinationAddresBuilder.Property(da => da.Zip).HasMaxLength(4).IsRequired();
        });

    }
}
