namespace ECommerce.API.Contracts;

public interface IInvoiceService
{
    Task<IEnumerable<InvoiceDto>> Get();
    Task<InvoiceDto> Get(string Id);

    Task<InvoiceDto> Create(InvoiceCreateDto model);
    Task<InvoiceDto> Update(InvoiceUpdateDto model, string Id);
}
