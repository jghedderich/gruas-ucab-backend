using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Admin.Domain.Models;

namespace Admin.Infrastructure.Data.Configuration;

public class DepartmentConfiguration : IEntityTypeConfiguration<Department>
{
    public void Configure(EntityTypeBuilder<Department> builder)
    {
        
        builder.HasKey(d => d.Id);

        builder.ComplexProperty(d => d.Name, nameBuilder =>
        {
            nameBuilder.Property(n => n.Value) 
                .IsRequired()
                .HasMaxLength(100); 
        });

       
        builder.Property(d => d.Description)
            .IsRequired()
            .HasMaxLength(255);


        //builder.HasMany(d => d.Users)
        //    .WithOne()
        //    .HasForeignKey("DepartmentId");


    }
}
