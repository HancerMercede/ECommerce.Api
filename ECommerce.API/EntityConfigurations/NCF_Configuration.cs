using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommerce.API.EntityConfigurations
{
    public class NCF_Configuration : IEntityTypeConfiguration<NCF>
    {
        public void Configure(EntityTypeBuilder<NCF> builder)
        {
            builder.ToTable("NCF");
            builder.HasKey(x => x.Id);
            builder.Property(x=>x.Description).HasMaxLength(50);
        }
    }
}
