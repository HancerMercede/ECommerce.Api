using ECommerce.API.Contracts;
using Mapster;
using System.Linq.Expressions;

namespace ECommerce.API.Services;

public class NCFService : INCF
{
    private readonly ApplicationDbContext _context;
    private readonly IMapper _mapper;
    public NCFService(ApplicationDbContext contex, IMapper mapper)
    {
        _context = contex;
        _mapper = mapper;
    }


    public async Task<NCFDto> GetNCFById(int Id, bool trackchanges)
    {
        var dbEntity = !trackchanges?
                        await _context.NCFs.Include(x => x.NCF_Infos)
                        .FirstOrDefaultAsync(x => x.Id == Id):
                        await _context.NCFs.Include(x => x.NCF_Infos)
                        .FirstOrDefaultAsync(x => x.Id == Id);

        var dto = dbEntity.Adapt<NCFDto>();
       // var dto = _mapper.Map<NCFDto>(dbEntity);
        return dto;
    }
    public async Task<NCFDto> CreateNCF(NCFDto model)
    {
        var dbEntity = model.Adapt<NCF>();

        await _context.AddAsync(dbEntity);
        await _context.SaveChangesAsync();
        
        return dbEntity.Adapt<NCFDto>();
    }


}
