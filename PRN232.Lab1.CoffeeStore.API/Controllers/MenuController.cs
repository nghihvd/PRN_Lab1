using Microsoft.AspNetCore.Mvc;
using PRN232.Lab1.CoffeeStore.Service.Interfaces;
using PRN232.Lab1.CoffeeStore.Service.RequestModels;

namespace PRN232.Lab1.CoffeeStore.API.Controllers
{
    [Route("api/menus")]
    [ApiController]
    public class MenuController : ControllerBase
    {
        private readonly IMenuService _service;
        public MenuController(IMenuService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var menus = await _service.GetAllMenusAsync();
            return Ok(menus);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            try
            {
                var menu = await _service.GetMenuByIdAsync(id);
                return Ok(menu);
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] MenuRequestModel request)
        {
            try
            {
                var menu = await _service.CreateMenuAsync(request);
                return CreatedAtAction(nameof(GetById), new { id = menu.MenuId }, menu);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, [FromBody] MenuRequestModel request)
        {
            try
            {
                var updated = await _service.UpdateMenuAsync(id, request);
                return Ok(updated);
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
                // Nếu xóa thành công trả NoContent
                var result = await _service.DeleteMenuAsync(id);
                if (result) return NoContent();
                return NotFound("Menu not found");
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }
    }
}
