using ECommerce.API.Helpers;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore.SqlServer.Storage.Internal;
using Microsoft.EntityFrameworkCore.Storage;
using System.Reflection.Metadata;

namespace ECommerce.API.Services;

public class InvoiceService : IInvoiceService
{
    private readonly ApplicationDbContext _context;
    private readonly IMapper _mapper;
    public InvoiceService(ApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<IEnumerable<InvoiceDto>> Get()
    {
       var dbEntities = await _context.Invoices.ToListAsync();
       var dtos = _mapper.Map<IEnumerable<InvoiceDto>>(dbEntities);

       return dtos;
    }

    public async Task<InvoiceDto> Get(string Id)
    {
        var dbEntity = await _context.Invoices.Include(i=>i.InvoiceDetails).FirstOrDefaultAsync(i => i.InvoiceId == Guid.Parse(Id));
        var dto = _mapper.Map<InvoiceDto>(dbEntity);

        return dto;
    }

    public async Task<InvoiceDto> Create(InvoiceCreateDto model)
    {
        if (model is null)
            ArgumentNullException.ThrowIfNull(model);

        // Header
        var db =  PrepareOrderHelper.PrepareHeader(model);

        var dbEntity = _mapper.Map<Invoice>(db);

        _context.Add(dbEntity);
        await _context.SaveChangesAsync();

        var dto = _mapper.Map<InvoiceDto>(dbEntity);
        return dto;
    }
    public Task<InvoiceDto> Update(InvoiceUpdateDto model, string Id)
    {
        throw new NotImplementedException();
    }

}
