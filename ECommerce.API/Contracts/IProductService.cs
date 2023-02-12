using ECommerce.API.Dtos;

namespace ECommerce.API.Contracts;

public interface IProductService
{
    Task<IEnumerable<ProductDto>> GetAll(PaginationDto paginationDto);
    Task<ProductDto> GetById(string Id);
    Task<int> create(ProductCreateDto model);
    Task update (ProductUpdateDto model, string Id);
    Task Delete(string Id);
   
}
