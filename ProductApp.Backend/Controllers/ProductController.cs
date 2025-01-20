using Microsoft.AspNetCore.Mvc;
using ProductApp.Application.Services.Products;
using ProductApp.Core;

namespace ProductApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        protected IProductService productService;

        public ProductController(IProductService _productService)
        {
            productService = _productService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Product>>> Get()
        {
            try
            {
                var response = await productService.GetAllProductsAsync();
                return Ok(response);
            }
            catch (Exception)
            {
                return BadRequest("Server error...");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product?>> Get(int id)
        {
            try
            {
                var response = await productService.GetProductByIdAsync(id);

                if (response is null)
                    return NotFound($"No existe un producto con el Id({id})");

                return Ok(response);
            }
            catch (Exception)
            {
                return BadRequest("Server error...");
            }
        }

        [HttpPost]
        public async Task<ActionResult<int>> Post(Product product)
        {
            try
            {
                var response = await productService.AddProductAsync(product);

                return Ok(response);
            }
            catch (Exception)
            {
                return BadRequest("Server error...");
            }
        }

        [HttpPut]
        public async Task<ActionResult<int>> Put(Product product)
        {
            try
            {
                var response = await productService.EditProductAsync(product);

                if (response < 0)
                    return NotFound($"No existe un producto con Id({product.Id})");

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
                var response = await productService.RemoveProductAsync(id);

                if (response < 0)
                    return NotFound($"No existe un producto con Id({id})");

                return Ok(response);
            }
            catch (Exception)
            {
                return BadRequest("Server error...");
            }
        }
    }
}
