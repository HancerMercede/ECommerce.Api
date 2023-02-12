namespace ECommerce.API.Controllers;

[Route("api/v1/[controller]")]
[ApiController]
public class InvoiceController:ControllerBase
{
	private readonly ILogger<InvoiceController> _logger;
	private readonly IInvoiceService _invoiceService;
	public InvoiceController(ILogger<InvoiceController> logger, IInvoiceService service)
	{
		_logger = logger;
		_invoiceService = service;
	}

    [HttpGet("{Id}", Name = "GetInvoice")]
    public async Task<ActionResult<InvoiceDto>> Get(string Id)
    {
        var dto = await _invoiceService.Get(Id);

        if (dto is null)
            return NotFound();

        return Ok(dto);
    }

    [HttpPost("create")]
	public async Task<ActionResult<InvoiceDto>> Create([FromBody]InvoiceCreateDto model)
	{
		if (model is null)
			return BadRequest();

	    var dto =	await _invoiceService.Create(model);
		return new CreatedAtRouteResult("GetInvoice", new{ Id = dto.InvoiceId }, dto);
	}
}
