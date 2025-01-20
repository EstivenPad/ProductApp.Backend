using ProductApp.Core;

namespace ProductApp.Application.Contracts
{
    public interface IProductPriceRepository
    {
        Task<List<ProductPrice>> GetAllAsync();
        Task<Product?> GetByIdAsync(int id);
        Task CreateAsync(List<ProductPrice> productPricesCollection, int productId);
        Task UpdateAsync(ProductPrice entity);
        Task DeleteAsync(ProductPrice entity);
    }
}
