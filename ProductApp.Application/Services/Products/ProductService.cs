using ProductApp.Application.Contracts;
using ProductApp.Core;

namespace ProductApp.Application.Services.Products
{
    public class ProductService : IProductService
    {
        protected readonly IProductRepository productRepository;
        protected readonly IColorRepository colorRepository;

        public ProductService(IProductRepository _productRepository, IColorRepository _colorRepository)
        {
            productRepository = _productRepository;
            colorRepository = _colorRepository;
        }
        public async Task<int> AddProductAsync(Product product)
        {
            try
            {
                var color = await colorRepository.GetByIdAsync(product.ColorId);
                
                if (color is null)
                    return -2;

                return await productRepository.CreateAsync(product);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<int> EditProductAsync(Product productToUpdate)
        {
            try
            {
                //Si el color del producto no existe en la BD se retorna -2
                var color = await colorRepository.GetByIdAsync(productToUpdate.ColorId);
                if (color is null)
                    return -2;

                //Por el contrario si el producto no existe en la BD se retorna -1
                var product = await productRepository.GetByIdAsync(productToUpdate.Id);
                if (product is null)
                    return -1;

                await productRepository.UpdateAsync(productToUpdate);
                return productToUpdate.Id;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<List<Product>> GetAllProductsAsync()
        {
            try
            {
                return await productRepository.GetAllAsync();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<Product> GetProductByIdAsync(int id)
        {
            try
            {
                return await productRepository.GetByIdAsync(id);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<int> RemoveProductAsync(int id)
        {
            try
            {
                var product = await productRepository.GetByIdAsync(id);

                if (product is null)
                    return -1;

                await productRepository.DeleteAsync(product);
                return id;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
