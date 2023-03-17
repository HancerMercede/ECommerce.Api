
namespace ECommerce.API.Contracts;

public interface INCF
{
    Task<NCFDto> GetNCFById(int Id, bool trackchanges);
    Task<NCFDto> CreateNCF(NCFDto model);
}
