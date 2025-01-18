using Microsoft.EntityFrameworkCore;
using ProductApp.Application.Contracts;
using ProductApp.Core;
using ProductApp.DataAccess.Context;

namespace ProductApp.DataAccess.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        protected readonly DatabaseContext dbContext;

        public GenericRepository(DatabaseContext _dbContext) 
        {
            dbContext = _dbContext;
        }
        public async Task<int> CreateAsync(T entity)
        {
            await dbContext.AddAsync(entity);
            await dbContext.SaveChangesAsync();
            return entity.Id;
        }

        public async Task DeleteAsync(T entity)
        {
            dbContext.Remove(entity);
            await dbContext.SaveChangesAsync();
        }

        public virtual async Task<List<T>> GetAllAsync()
        {
            return await dbContext.Set<T>().AsNoTracking().ToListAsync();
        }

        public virtual async Task<T> GetByIdAsync(int id)
        {
            return await dbContext.Set<T>().AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task UpdateAsync(T entity)
        {
            dbContext.Update(entity);
            await dbContext.SaveChangesAsync();
        }
    }
}
