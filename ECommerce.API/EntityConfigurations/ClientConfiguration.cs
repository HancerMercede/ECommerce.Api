using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommerce.API.EntityConfigurations;

public class ClientConfiguration:IEntityTypeConfiguration<Client>
{
    public void Configure(EntityTypeBuilder<Client> builder)
    {
        builder.ToTable("Clients");
        builder.HasKey(c => c.ClientId);
        builder.Property(c => c.Name).HasMaxLength(50);
        builder.Property(c => c.LastName).HasMaxLength(50);
        builder.Property(c => c.ClientId).HasDefaultValueSql("NEWID()");
        builder.Property(c => c.Address).HasMaxLength(250);
        builder.Property(c => c.Telephone).HasMaxLength(12);
        builder.Property(c => c.Email).HasMaxLength(50);
        builder.Property(c=>c.RNC).HasMaxLength(70);
        builder.Property(c=>c.DNI).HasMaxLength(50);

        builder.HasIndex(c=>c.DNI).IsUnique();
        builder.HasIndex(c=>c.RNC).IsUnique();


    }
}
