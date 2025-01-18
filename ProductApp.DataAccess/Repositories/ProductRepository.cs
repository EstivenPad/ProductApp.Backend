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
    }
}
