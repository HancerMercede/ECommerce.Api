using ECommerce.API.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Server.IIS;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System.Text.Json;

namespace ECommerce.API.Controllers;

[Route("api/v1/[controller]")]
[ApiController]
public class ClientController : ControllerBase
{
    private readonly ILogger<ClientController> _logger;
    private readonly IClientService _service;
    //  private readonly ApplicationDbContext _context;
    public ClientController(ILogger<ClientController> logger, IClientService service, ApplicationDbContext context)
    {
        _logger = logger;
        _service = service;
        //  _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ClientDto>>> Get([FromQuery]PaginationDto model)
    {
        var dtos = await _service.GetAll(model);
        MetaDataHelper.ResponseHeaders(HttpContext);
        return Ok(dtos);
    }

    [HttpGet("{Id}", Name = "GetClientById")]
    public async Task<ActionResult<ClientDto>> Get(string Id)
    {
        if (string.IsNullOrWhiteSpace(Id))
            return BadRequest();

        return await _service.GetById(Id);
    }

    [HttpPost("Create")]
    public async Task<IActionResult> Post([FromForm] ClientCreateDto model)
    {
        if (model is null)
            return BadRequest();

        var dto = await _service.Create(model);

        return new CreatedAtRouteResult("GetClientById", new { Id = dto.ClientId }, dto);
    }

    [HttpPut("update/{Id}")]
    public async Task<IActionResult> Put([FromForm] ClientUpdateDto model, string Id)
    {
        if (string.IsNullOrWhiteSpace(Id))
            return BadRequest();

        if (model is null)
            return BadRequest();

        var dto = await _service.Update(model, Id);

        return Ok(dto);
    }


    [HttpDelete("{Id}")]
    public async Task<IActionResult> Delete(string Id)
    {
        if (string.IsNullOrWhiteSpace(Id))
            return BadRequest();

        await _service.Delete(Id);
        return NoContent();
    }

}
