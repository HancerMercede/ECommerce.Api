using AutoMapper;
using ECommerce.API.Contracts;
using ECommerce.API.Dtos;
using ECommerce.API.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class ProductController:ControllerBase
    {
        private readonly IProductService _service;
        public ProductController(IProductService service)
        {
            _service = service;
        }

        [HttpGet]
        [ProducesResponseType(200)]
        public async Task<ActionResult<IEnumerable<ProductDto>>> Get([FromQuery]PaginationDto paginationDto)
        {
            var dtos = await _service.GetAll(paginationDto);
            MetaDataHelper.ResponseHeaders(HttpContext);
            return Ok(dtos);
        }

        [HttpGet("{Id}", Name ="GetProductById")]
        [ProducesResponseType(200)]
        public async Task<ActionResult<IEnumerable<ProductDto>>> Get(string Id)
        {
            var dto = await _service.GetById(Id);

            if(dto is not null)
               return Ok(dto);

            return NotFound($"The product with Id: {Id} does not exist in the database.");
        }

        [HttpPost("Create")]
        [ProducesResponseType(204)]
        public async Task<IActionResult> Post([FromForm]ProductCreateDto model)
        {
            if (model is null)
                return BadRequest();

            await _service.create(model);
            return NoContent();
        }

        [HttpPut("Update/{Id}")]
        [ProducesResponseType(204)]
        public async Task<IActionResult> Put([FromBody]ProductUpdateDto model, string Id)
        { 
              if(string.IsNullOrWhiteSpace(Id))
                    return BadRequest();

            if (model is null)
                return BadRequest();

            await _service.update(model, Id);
            return NoContent();
        }

        [HttpDelete("Delete/{Id}")]
        [ProducesResponseType(204)]
        public async Task<IActionResult> Delete(string Id)
        { 
            if(string.IsNullOrWhiteSpace(Id))
                return BadRequest();

           await _service.Delete(Id);
            return NoContent();
        }
    }
}
