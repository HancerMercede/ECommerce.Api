using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ECommerce.API.Entities
{
    public class InvoiceDetail
    {
        public Guid ProductId { get; set; }
        public virtual Product Product { get; set; }
        public Guid InvoiceId { get; set; }
        public virtual Invoice InvoiceNavigation { get; set; }
        public int Cuantity { get; set; }
        public decimal Price { get; set; }
        public decimal Iva { get; set; }
        public decimal SubTotal { get; set; }
        public decimal Total { get; set; }
    }
}
