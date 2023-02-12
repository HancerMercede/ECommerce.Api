using ECommerce.API.ConsultasArbitrarias;
using ECommerce.API.Entities;
using ECommerce.API.Helpers;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using System.Reflection.Emit;

namespace ECommerce.API.Persistance
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):
            base(options)
        {

        }

        public ApplicationDbContext()
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            builder.Entity<SelesDetails>().HasNoKey().ToView("SalesDetails");
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Fruit> Fruits { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<InvoiceDetail> InvoiceDetails { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Factor> Factors  { get; set; }
        public DbSet<NCF> NCFs { get; set; }
    }   
}
