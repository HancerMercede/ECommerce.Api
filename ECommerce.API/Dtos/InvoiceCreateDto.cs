namespace ECommerce.API.Dtos;

public class InvoiceCreateDto
{
    public InvoiceCreateDto()
    {
        invoiceDetails = new List<InvoiceDetailCreateDto>();
    }

    public string? ClientId { get; set; }
    public List<InvoiceDetailCreateDto> invoiceDetails { get; set; }
    public decimal Iva { get; set; }
    public decimal SubTotal { get; set; }
    public decimal Total { get; set; }

    public string NCFSerie { get; set; }
    public string NCFType { get; set; }
    public string Secuence { get; set; }
}
