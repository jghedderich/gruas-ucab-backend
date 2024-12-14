using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Admin.Domain.Models;
using Admin.Domain.ValueObjects;

namespace Admin.Infrastructure.Data.Configuration;

public class AdministratorConfiguration : IEntityTypeConfiguration<Administrator>
{
    public void Configure(EntityTypeBuilder<Administrator> builder)
    {
        builder.HasKey(a => a.Id);

        builder.Property(a => a.Name)
            .HasMaxLength(100)
            .IsRequired();

        builder.ComplexProperty(a => a.Email, emailBuilder =>
        {
            emailBuilder.Property(e => e.Value).HasMaxLength(255).IsRequired();
        });

        builder.ComplexProperty(a => a.Password, passwordBuilder =>
        {
            passwordBuilder.Property(p => p.Value).HasMaxLength(100).IsRequired();
        });
    }
}
