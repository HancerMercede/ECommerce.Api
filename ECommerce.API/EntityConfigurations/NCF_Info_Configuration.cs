using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommerce.API.EntityConfigurations;

public class NCF_Info_Configuration : IEntityTypeConfiguration<NCF_Info>
{
    public void Configure(EntityTypeBuilder<NCF_Info> builder)
    {
        builder.ToTable("NCF_Details");
        builder.HasKey(x => new { x.NCF_Serie, x.NCF_Type, x.Secuence});
        builder.Property(x => x.NCF_Type).HasMaxLength(2);
        builder.Property(x => x.NCF_Serie).HasMaxLength(1);
        builder.Property(x => x.Secuence).HasMaxLength(8);
    }
}
