using ProductApp.Core;

namespace ProductApp.Application.Contracts
{
    public interface IProductRepository
    {
        Task<List<Product>> GetAllAsync();
        Task<Product?> GetByIdAsync(int id);
        Task<int> CreateAsync(Product entity);
        Task UpdateAsync(Product productToUpdate, Product productFromDB);
        Task DeleteAsync(Product entity);
    }
}
