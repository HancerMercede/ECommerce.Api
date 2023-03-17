namespace ECommerce.API.Entities;

public class Invoice
{
    public Invoice()
    {
        InvoiceDetails = new HashSet<InvoiceDetail>();
    }
    public Guid InvoiceId { get; set; }
    public Guid ClientId { get; set; }
    public virtual Client Client { get; set; }
    public ICollection<InvoiceDetail> InvoiceDetails { get; set; }
    public decimal Iva { get; set; }
    public decimal SubTotal { get; set; }
    public decimal Total { get; set; }
    public DateTime CreationDate { get; set; }

}
