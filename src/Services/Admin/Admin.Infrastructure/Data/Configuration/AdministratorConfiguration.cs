using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Admin.Domain.Models;

namespace Admin.Infrastructure.Data.Configuration;

public class AdministratorConfiguration : IEntityTypeConfiguration<Administrator>
{
    public void Configure(EntityTypeBuilder<Administrator> builder)
    {
        builder.HasKey(a => a.Id);

        builder.ComplexProperty(a => a.Name, nameBuilder =>
        {
            nameBuilder.Property(n => n.FirstName).HasMaxLength(50).IsRequired();
            nameBuilder.Property(n => n.LastName).HasMaxLength(50).IsRequired();
        });

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
