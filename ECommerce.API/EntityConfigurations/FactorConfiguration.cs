using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommerce.API.EntityConfigurations
{
    public class FactorConfiguration : IEntityTypeConfiguration<Factor>
    {
        public void Configure(EntityTypeBuilder<Factor> builder)
        {
            builder.ToTable("Units");
            builder.HasKey(x => x.Id);
            builder.Property(x=>x.Description).HasMaxLength(50);
            builder.Property(x => x.Short_Description).HasMaxLength(10);
            builder.Property(x => x.Active).HasDefaultValue("S");
        }
    }
}
