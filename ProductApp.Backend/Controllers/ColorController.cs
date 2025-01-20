using Microsoft.AspNetCore.Mvc;
using ProductApp.Application.Services.Colors;
using ProductApp.Core;

namespace ProductApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ColorController : ControllerBase
    {
        protected IColorService colorService;

        public ColorController(IColorService _colorService)
        {
            colorService = _colorService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Color>>> Get() 
        {
            try
            {
                var response = await colorService.GetAllColorsAsync();
                return Ok(response);
            }
            catch (Exception)
            {
                return BadRequest("Server error...");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Color?>> Get(int id)
        {
            try
            {
                var response = await colorService.GetColorByIdAsync(id);

                if (response is null)
                    return NotFound($"No existe un color con el Id({id})");

                return Ok(response);
            }
            catch (Exception)
            {
                return BadRequest("Server error...");
            }
        }

        [HttpPost]
        public async Task<ActionResult<int>> Post(Color color)
        {
            try
            {
                var response = await colorService.AddColorAsync(color);
                return Ok(response);
            }
            catch (Exception)
            {
                return BadRequest("Server error...");
            }
        }

        [HttpPut]
        public async Task<ActionResult<int>> Put(Color color)
        {
            try
            {
                var response = await colorService.EditColorAsync(color);

                if (response < 0)
                    return NotFound($"No existe un color con el Id({color.Id})");

                return Ok(response);
            }
            catch (Exception)
            {
                return BadRequest("Server error...");
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<int>> Delete(int id)
        {
            try
            {
                var response = await colorService.RemoveColorAsync(id);

                if (response == -1)
                    return BadRequest(new {
                                        message = "¡No se puede eliminar este color!",
                                        description = "Este color esta siendo utilizado en un producto, por favor elimine todas las referencias antes de seguir..."
                                    });
                else if (response == -2)
                    return NotFound($"No existe un color con el Id({id})");

                return Ok(response);
            }
            catch (Exception)
            {
                return BadRequest("Server error...");
            }
        }
    }
}
