using Microsoft.EntityFrameworkCore;
using ProductApp.Application.Contracts;
using ProductApp.Core;
using ProductApp.DataAccess.Context;

namespace ProductApp.DataAccess.Repositories
{
    public class ColorRepository : IColorRepository
    {
        protected readonly DatabaseContext dbContext;
        public ColorRepository(DatabaseContext _dbContext)
        {
            dbContext = _dbContext;
        }

        public async Task<int> CreateAsync(Color entity)
        {
            await dbContext.AddAsync(entity);
            await dbContext.SaveChangesAsync();
            return entity.Id;
        }

        public async Task DeleteAsync(Color entity)
        {
            dbContext.Remove(entity);
            await dbContext.SaveChangesAsync();
        }

        public async Task<List<Color>> GetAllAsync()
        {
            return await dbContext.Colors.AsNoTracking().ToListAsync();
        }

        public async Task<Color?> GetByIdAsync(int id)
        {
            return await dbContext.Colors
                                  .AsNoTracking()
                                  .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<bool> HasAnyReference(int colorId)
        {
            return await dbContext.ProductPrices.AnyAsync(p => p.ColorId == colorId);
        }

        public async Task UpdateAsync(Color entity)
        {
            dbContext.Update(entity);
            await dbContext.SaveChangesAsync();
        }
    }
}
