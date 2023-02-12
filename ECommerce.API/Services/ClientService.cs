using AutoMapper;
using ECommerce.API.Contracts;
using ECommerce.API.Entities;
using ECommerce.API.Helpers;
using ECommerce.API.Persistance;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Collections.Concurrent;
using System.Linq;
using System.Runtime.CompilerServices;

namespace ECommerce.API.Services;

public class ClientService : IClientService
{
    private readonly ApplicationDbContext _context;
    private readonly IMapper _mapper;
    private static ConcurrentDictionary<Guid, Client>? _Cache;
    public ClientService(ApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;

        if (_Cache is null)
        { 
           _Cache = new ConcurrentDictionary<Guid, Client>(_context.Clients.ToDictionary(c=>c.ClientId));
        }
    }

    public async Task<IEnumerable<ClientDto>> GetAll(PaginationDto paginationDto)
    {
        var cacheEntities = _Cache.Values.AsQueryable();
        
        if (cacheEntities is null) 
             Enumerable.Empty<ClientDto>();

        var records = PagedList<Client>.ToPagedList(cacheEntities.OrderBy(c => c.Name),
                      paginationDto.PageNumber,
                      paginationDto.PageSize);

        MetaDataHelper.InsertingPaginationParams(records.TotalCount, records.PageSize, records.CurrentPage, records.TotalPages);
        return await Task.FromResult(_mapper.Map<IEnumerable<ClientDto>>(records));
    }

    public async Task<ClientDto> GetById(string Id)
    {
        if (string.IsNullOrWhiteSpace(Id))
             ArgumentNullException.ThrowIfNull(Id);

        if (_Cache is null) 
             return null;

        _Cache.TryGetValue(Guid.Parse(Id), out Client c);
        return await Task.FromResult(_mapper.Map<ClientDto>(c));
    }
    public async Task<ClientDto> Create(ClientCreateDto model)
    {
        try
        {
            if (model is null)
                ArgumentNullException.ThrowIfNull(nameof(model));

            var dbEntity = _mapper.Map<Client>(model);
            EntityEntry<Client> added = await _context.Clients.AddAsync(dbEntity);

            int affected = await _context.SaveChangesAsync();

            if (affected == 1)
            {
                _Cache.AddOrUpdate(dbEntity.ClientId, dbEntity, UpdateCache);
            }

            return _mapper.Map<ClientDto>(dbEntity);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
    public async Task<ClientDto> Update(ClientUpdateDto model, string Id)
    {
        if (string.IsNullOrWhiteSpace(Id))
            ArgumentNullException.ThrowIfNull(Id);

        if (model is null)
            ArgumentNullException.ThrowIfNull(model);

        var dbEntity = await _context.Clients.FirstOrDefaultAsync(c => c.ClientId == Guid.Parse(Id));

        dbEntity =  _mapper.Map(model, dbEntity);
        _context.Clients.Update(dbEntity);
        var affected = await _context.SaveChangesAsync();

        if (affected == 1)
            UpdateCache(dbEntity.ClientId, dbEntity);

        return _mapper.Map<ClientDto>(dbEntity);
    }
    public async Task Delete(string Id)
    {
        if (string.IsNullOrWhiteSpace(Id))
            ArgumentNullException.ThrowIfNull(Id);

        var dbEntity = await _context.Clients.FindAsync(Guid.Parse(Id));

        if (dbEntity is null)
             ArgumentNullException.ThrowIfNull(dbEntity);

        _context.Remove(dbEntity);
        var affected = await _context.SaveChangesAsync();

        if (affected == 1)
            _Cache.TryRemove(dbEntity.ClientId, out dbEntity);
    }


    private Client UpdateCache(Guid Id, Client c)
    {
        Client old;
        if (_Cache is not null)
        {
            if (_Cache.TryGetValue(Id, out old))
            {
                if (_Cache.TryUpdate(Id, c, old)) 
                {
                    return c;
                }
            }
        }
        return null;
    }
}
