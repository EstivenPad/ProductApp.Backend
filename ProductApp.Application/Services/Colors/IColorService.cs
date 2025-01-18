using ProductApp.Core;

namespace ProductApp.Application.Services.Colors
{
    public interface IColorService
    {
        Task<List<Color>> GetAllColorsAsync();
        Task<Color?> GetColorByIdAsync(int id);
        Task<int> AddColorAsync(Color color);
        Task<int> EditColorAsync(Color color);
        Task<int> RemoveColorAsync(int id);
    }
}
