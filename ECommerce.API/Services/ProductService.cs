using ECommerce.API.Helpers;
using System.Collections.Concurrent;

namespace ECommerce.API.Services;

public class ProductService : IProductService
{
    private readonly ApplicationDbContext _context;
    private readonly IMapper _mapper;
    public ProductService(ApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task<int> create(ProductCreateDto model)
    {
        try
        {
            if (model is null)
                ArgumentNullException.ThrowIfNull(nameof(model));

            var rowAffect = await _context.Database
                .ExecuteSqlAsync($"dbo.SP_INSERT_PROD {model.Description}, {model.Price},{model.Cuantity},{model.FactorId},{model.FruitId}");

            if (rowAffect == 1)
                return await Task.FromResult(rowAffect);

            return rowAffect;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
       
    }

    public async Task<IEnumerable<ProductDto>> GetAll(PaginationDto paginationDto)
    {
        var dbEntities = _context.Products.AsQueryable();

        var records = PagedList<Product>.ToPagedList(dbEntities.OrderBy(p=>p.Description),
            paginationDto.PageNumber,
            paginationDto.PageSize);

        MetaDataHelper.InsertingPaginationParams(records.TotalCount, records.PageSize, records.CurrentPage, records.TotalPages);
        
        return await Task.FromResult(_mapper.Map<IEnumerable<ProductDto>>(records));
    }

    public async Task<ProductDto> GetById(string Id)
    {
       if(Id is null || string.IsNullOrWhiteSpace(Id))
            ArgumentNullException.ThrowIfNull(nameof(Id));

        var dbEntity = await _context.Products.FirstOrDefaultAsync(p => p.Id == Guid.Parse(Id));
        
        return _mapper.Map<ProductDto>(dbEntity);
    }

    public async Task update(ProductUpdateDto model, string Id)
    {
        try
        {
            if(string.IsNullOrWhiteSpace(Id))
                ArgumentNullException.ThrowIfNull(nameof(Id));

            if (model is null)
                ArgumentNullException.ThrowIfNull(nameof(model));

            var rowAffect = await _context.Database.ExecuteSqlAsync($"dbo.SP_UPDATE_PROD {Id},{model?.Description},{model.Price},{model.Cuantity}");

            if (rowAffect == 1)
                await Task.FromResult(rowAffect);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
    public async Task Delete(string Id)
    {
        var dbEntity = await _context.Products.FindAsync(Guid.Parse(Id));
        
        if (dbEntity is not null)
        {
            _context.Products.Remove(dbEntity);
            await _context.SaveChangesAsync();
        }  
    }
}
