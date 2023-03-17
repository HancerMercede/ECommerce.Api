using ECommerce.API.Persistance;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;

namespace ECommerce.API.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class NCFController:ControllerBase
{
    private readonly INCF _ncfService;
    private readonly ILogger<NCFController> _logger;
    public NCFController(INCF ncf,ILogger<NCFController> Logger)
    {
        _ncfService = ncf;
        _logger = Logger;
    }

    [HttpGet("{Id:int}",Name = "GetNcfById")]
    public async Task<ActionResult<NCFDto>> Get(int Id)
    {
        var result = await _ncfService.GetNCFById(Id, trackchanges:false);
        return Ok(result);
    }


    [HttpPost("CreateNCF")]
    public async Task<IActionResult> CreateNCF([FromBody] NCFDto model)
    {
        var NCFType = string.Empty;
        var NCFSecuence = string.Empty;

        if (model is not null)
        { 
          foreach (var item in model.NCF_Infos)
            {
                NCFType = item.NCF_Type.PadLeft(2, '0');
                NCFSecuence = item.Secuence.PadLeft(8, '0');

                item.NCF_Type = NCFType;
                item.Secuence = NCFSecuence;
            }
        }

        var dto = await _ncfService.CreateNCF(model);
        return new CreatedAtRouteResult("GetNcfById", new { Id = dto.Id }, dto);
    }
}
