using Microsoft.AspNetCore.Mvc;
using PRN232.Lab1.CoffeeStore.Service.Interfaces;
using PRN232.Lab1.CoffeeStore.Service.Models;

namespace PRN232.Lab1.CoffeeStore.API.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _service;

        public ProductController(IProductService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _service.GetAllProductsAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            try
            {
                var product = await _service.GetProductByIdAsync(id);
                return Ok(product);
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ProductRequestModel request)
        {
            try
            {
                await _service.CreatProductAsync(request);
                return Ok("Create Successfully");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, [FromBody] ProductRequestModel request)
        {
            try
            {
                await _service.UpdateProductAsync(id, request);
                return Ok("Update successfully");
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            try
            {
                await _service.DeleteProductAsync(id);
                return Ok("Delete Successfully");
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }
    }
}
