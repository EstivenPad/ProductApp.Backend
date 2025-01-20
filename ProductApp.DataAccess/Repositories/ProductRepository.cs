using Microsoft.EntityFrameworkCore;
using ProductApp.Application.Contracts;
using ProductApp.Core;
using ProductApp.DataAccess.Context;

namespace ProductApp.DataAccess.Repositories
{
    public class ProductRepository : IProductRepository
    {
        protected readonly DatabaseContext dbContext;

        public ProductRepository(DatabaseContext _dbContext)
        {
            dbContext = _dbContext;
        }

        public async Task<int> CreateAsync(Product entity)
        {
            await dbContext.AddAsync(entity);
            await dbContext.SaveChangesAsync();
            return entity.Id;
        }

        public async Task DeleteAsync(Product entity)
        {
            dbContext.Products.Remove(entity);
            await dbContext.SaveChangesAsync();
        }

        public async Task<List<Product>> GetAllAsync()
        {
            //Avoid the recursive object reference removing each 'Product' reference in each 'ProductPrice' object
            return await dbContext.Products
                                    .Select(p => new Product
                                    {
                                        Id = p.Id,
                                        Name = p.Name,
                                        ProductPrices = p.ProductPrices.Select(pp => new ProductPrice
                                        {
                                            Id = pp.Id,
                                            Price = pp.Price,
                                            IsSelected = pp.IsSelected,
                                            ColorId = pp.ColorId,
                                            Color = pp.Color,
                                            ProductId = pp.ProductId,
                                        }).ToList()
                                    })
                                    .AsNoTracking()
                                    .ToListAsync();
                }

        public async Task<Product?> GetByIdAsync(int id)
        {
            //Avoid the recursive object reference removing each 'Product' reference in each 'ProductPrice' object
            return await dbContext.Products
                                    .Where(p => p.Id == id)
                                    .Select(p => new Product
                                    {
                                        Id = p.Id,
                                        Name = p.Name,
                                        ProductPrices = p.ProductPrices.Select(pp => new ProductPrice
                                        {
                                            Id = pp.Id,
                                            Price = pp.Price,
                                            IsSelected = pp.IsSelected,
                                            ColorId = pp.ColorId,
                                            Color = pp.Color,
                                            ProductId = pp.ProductId,
                                        }).ToList()
                                    })
                                    .AsNoTracking()
                                    .FirstOrDefaultAsync();
        }

        public Task UpdateAsync(Product entity)
        {
            throw new NotImplementedException();
        }
    }
}
