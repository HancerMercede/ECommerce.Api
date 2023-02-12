namespace ECommerce.API.Dtos;

public class InvoiceDto
{
    public string? InvoiceId { get; set; }
    public string ClientId { get; set; }

    public IEnumerable<InvoiceDetailDto> invoiceDetails { get; set; }
    public decimal Iva { get; set; }
    public decimal SubTotal { get; set; }
    public decimal Total { get; set; }
}
