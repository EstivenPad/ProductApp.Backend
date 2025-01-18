using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ProductApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ColorController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get() 
        {
            return Ok("Testing!!!");
        }
    }
}
