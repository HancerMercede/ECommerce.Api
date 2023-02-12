using ECommerce.API.Helpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommerce.API.EntityConfigurations
{
    public class NCFConfiguration : IEntityTypeConfiguration<NCF>
    {
        public void Configure(EntityTypeBuilder<NCF> builder)
        {
            builder.HasKey(x => new { x.Serie, x.Tcomprobante,x.Secuence});
            builder.Property(x => x.Serie).HasMaxLength(1).HasColumnType("char");
            builder.Property(x => x.Tcomprobante).HasMaxLength(2).HasColumnType("char");
            builder.Property(x=>x.Secuence).HasMaxLength(8).HasColumnType("char");
            builder.Property(x => x.Name).HasMaxLength(100);
        }
    }
}
