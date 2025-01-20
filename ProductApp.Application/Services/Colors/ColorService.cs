using ProductApp.Application.Contracts;
using ProductApp.Core;

namespace ProductApp.Application.Services.Colors
{
    public class ColorService : IColorService
    {
        protected readonly IColorRepository colorRepository;

        public ColorService(IColorRepository _colorRepository)
        {
            colorRepository = _colorRepository;
        }

        public async Task<int> AddColorAsync(Color color)
        {
            try
            {
                return await colorRepository.CreateAsync(color);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<int> EditColorAsync(Color color)
        {
            try
            {
                var colorToUpdate = await colorRepository.GetByIdAsync(color.Id);

                if (colorToUpdate is null)
                    return -1;

                await colorRepository.UpdateAsync(color);

                return color.Id;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<Color>> GetAllColorsAsync()
        {
            try
            {
                return await colorRepository.GetAllAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Color?> GetColorByIdAsync(int id)
        {
            try
            {
                return await colorRepository.GetByIdAsync(id);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<int> RemoveColorAsync(int id)
        {
            try
            {
                var isReference = await colorRepository.HasAnyReference(id);

                if (!isReference)
                {
                    var color = await colorRepository.GetByIdAsync(id);

                    if(color != null)
                    {
                        await colorRepository.DeleteAsync(color);
                        return id;
                    }

                    return -2;//Not Found
                }

                return -1;//Reference Error
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
