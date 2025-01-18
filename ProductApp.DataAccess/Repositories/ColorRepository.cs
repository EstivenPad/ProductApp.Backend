using ProductApp.Application.Contracts;
using ProductApp.Core;
using ProductApp.DataAccess.Context;

namespace ProductApp.DataAccess.Repositories
{
    public class ColorRepository : GenericRepository<Color>, IColorRepository
    {
        public ColorRepository(DatabaseContext _dbContext) : base(_dbContext)
        {
        }
    }
}
