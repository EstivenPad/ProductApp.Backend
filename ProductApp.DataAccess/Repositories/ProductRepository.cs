using Microsoft.EntityFrameworkCore;
using ProductApp.Application.Contracts;
using ProductApp.Core;
using ProductApp.DataAccess.Context;

namespace ProductApp.DataAccess.Repositories
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(DatabaseContext _dbContext) : base(_dbContext)
        {
        }

        public override async Task<List<Product>> GetAllAsync()
        {
            return await dbContext.Product
                            .Include(p => p.Color)
                            .AsNoTracking()
                            .ToListAsync();
        }

        public override async Task<Product> GetByIdAsync(int id)
        {
            return await dbContext.Product
                            .Include(p => p.Color)
                            .AsNoTracking()
                            .FirstOrDefaultAsync(p => p.Id == id);
        }
    }
}
