using ProductApp.Core;

namespace ProductApp.Application.Services.Products
{
    public interface IProductService
    {
        Task<List<Product>> GetAllProductsAsync();
        Task<Product?> GetProductByIdAsync(int id);
        Task<int> AddProductAsync(Product color);
        Task<int> EditProductAsync(Product color);
        Task<int> RemoveProductAsync(int id);
    }
}
