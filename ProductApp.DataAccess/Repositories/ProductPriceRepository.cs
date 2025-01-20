using Microsoft.EntityFrameworkCore;
using ProductApp.Application.Contracts;
using ProductApp.Core;
using ProductApp.DataAccess.Context;

namespace ProductApp.DataAccess.Repositories
{
    public class ProductPriceRepository : IProductPriceRepository
    {
        protected readonly DatabaseContext dbContext;
        public ProductPriceRepository(DatabaseContext _dbContext)
        {
            dbContext = _dbContext;
        }

        public async Task CreateAsync(List<ProductPrice> productPricesCollection, int productId)
        {
            try
            {
                var productPricesToSave = productPricesCollection.Select(pp => new ProductPrice
                {
                    Id = 0,
                    Price = pp.Price,
                    IsSelected = pp.IsSelected,
                    ProductId = productId,
                    ColorId = pp.ColorId,
                }).ToList();

                await dbContext.ProductPrices.AddRangeAsync(productPricesToSave);
                await dbContext.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Task DeleteAsync(ProductPrice entity)
        {
            throw new NotImplementedException();
        }

        public Task<List<ProductPrice>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Product?> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(ProductPrice entity)
        {
            throw new NotImplementedException();
        }
    }
}
