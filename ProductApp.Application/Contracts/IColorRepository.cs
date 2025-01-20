using ProductApp.Core;

namespace ProductApp.Application.Contracts
{
    public interface IColorRepository
    {
        Task<List<Color>> GetAllAsync();
        Task<Color?> GetByIdAsync(int id);
        Task<int> CreateAsync(Color entity);
        Task UpdateAsync(Color entity);
        Task DeleteAsync(Color entity);
        Task<bool> HasAnyReference(int colorId);
    }
}
