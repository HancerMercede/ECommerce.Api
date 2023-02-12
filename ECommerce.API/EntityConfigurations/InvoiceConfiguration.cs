using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Data;

namespace ECommerce.API.EntityConfigurations
{
    public class InvoiceConfiguration : IEntityTypeConfiguration<Invoice>
    {
        public void Configure(EntityTypeBuilder<Invoice> builder)
        {
            builder.Property(c => c.InvoiceId).HasDefaultValueSql("NEWID()");
            builder.ToTable(nameof(Invoice));
            builder.HasKey(i => i.InvoiceId);
            builder.Property(i => i.CreationDate).HasConversion<DateTime>().HasDefaultValueSql("GETDATE()");
        }
    }
}
