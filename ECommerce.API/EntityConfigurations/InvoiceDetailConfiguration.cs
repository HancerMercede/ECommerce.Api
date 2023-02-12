using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommerce.API.EntityConfigurations
{
    public class InvoiceDetailConfiguration : IEntityTypeConfiguration<InvoiceDetail>
    {
        public void Configure(EntityTypeBuilder<InvoiceDetail> builder)
        {
            builder.ToTable(nameof(InvoiceDetail));
            builder.HasKey(x => new { x.ProductId, x.InvoiceId});
            builder.HasOne(id => id.InvoiceNavigation).WithMany(id=>id.InvoiceDetails).HasForeignKey(id => id.InvoiceId);
        }
    }
}
