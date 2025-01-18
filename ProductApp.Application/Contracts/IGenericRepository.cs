using ProductApp.Core;

namespace ProductApp.Application.Contracts
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        public Task<List<T>> GetAllAsync();
        public Task<T> GetByIdAsync(int id);
        public Task<int> CreateAsync(T entity);
        public Task UpdateAsync(T entity);
        public Task DeleteAsync(T entity);
    }
}
