namespace ECommerce.API.Dtos;

public class InvoiceUpdateDto
{
    public InvoiceUpdateDto()
    {
        Client = new();
        //invoiceDetails = new HashSet<InvoiceDetail>();
    }
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public string? InvoiceId { get; set; }
    public ClientDto Client { get; set; }

    //public IEnumerable<InvoiceDetail> invoiceDetails { get; set; }
    public decimal Iva { get; set; }
    public decimal SubTotal { get; set; }
    public decimal Total { get; set; }
}
