using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Admin.Domain.Models;

namespace Admin.Infrastructure.Data.Configuration;

public class RateConfiguration : IEntityTypeConfiguration<Rate>
{
    public void Configure(EntityTypeBuilder<Rate> builder)
    {
       
        builder.HasKey(r => r.Id);

        builder.ComplexProperty(r => r.Name, nameBuilder =>
        {
            nameBuilder.Property(n => n.Value) 
                .IsRequired()
                .HasMaxLength(100); 
        });

        builder.Property(r => r.BaseRate)
            .IsRequired()
            .HasColumnType("decimal(18,2)"); 

   
        builder.Property(r => r.ExtraPricePerKm)
            .IsRequired()
            .HasColumnType("decimal(18,2)");

      
        builder.Property(r => r.CoverageRadius)
            .IsRequired()
            .HasColumnType("decimal(18,2)");

        
        builder.ComplexProperty(r => r.Description, descriptionBuilder =>
        {
            descriptionBuilder.Property(d => d.Value) 
                .IsRequired()
                .HasMaxLength(255); 
        });
    }
}
