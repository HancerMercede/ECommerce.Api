namespace ECommerce.API.Contracts;

public interface IClientService
{
    Task<IEnumerable<ClientDto>> GetAll(PaginationDto paginationDto);

    Task<ClientDto> GetById(string Id);

    Task<ClientDto> Create(ClientCreateDto model);

    Task<ClientDto> Update(ClientUpdateDto model, string Id);

    Task Delete(string Id);


}
