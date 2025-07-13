using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ProductAPI.Dto;
using ProductAPI.IService;
using ProductAPI.Model;
using System.Runtime.InteropServices;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProductAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _service;
        private readonly IMapper _mapper;

        public ProductsController(IProductService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var products = await _service.GetAllAysnc();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var product = await _service.GetByIdAysnc(id);
            return product == null ? NotFound() : Ok(product);
        }

        [HttpPost]
        public async Task<IActionResult>Create(ProductDto dto)
        {
            var product = _mapper.Map<Product>(dto);
            var result = await _service.CreateAsync(product);
            return CreatedAtAction(nameof(GetById),new {id =  result.Id},result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, ProductDto dto)
        {
            var product = _mapper.Map<Product>(dto);
            var success =await  _service.UpdateAysnc(id, product);
            return success ? NoContent() : NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var  success =  await _service.DeleteAsync(id);
            return success ? NoContent() : NotFound();
        }

       
    }
}
