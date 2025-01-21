using ProductApp.Application.Contracts;
using ProductApp.Core;

namespace ProductApp.Application.Services.Products
{
    public class ProductService : IProductService
    {
        protected readonly IProductRepository productRepository;
        protected readonly IColorRepository colorRepository;
        protected readonly IProductPriceRepository productPriceRepository;

        public ProductService(IProductRepository _productRepository,
                              IColorRepository _colorRepository,
                              IProductPriceRepository _productPriceRepository)
        {
            productRepository = _productRepository;
            colorRepository = _colorRepository;
            productPriceRepository = _productPriceRepository;
        }

        public async Task<int> AddProductAsync(Product product)
        {
            try
            {
                //Create a new Product object without a ProductPrice collection
                //for saved into Product table database
                var productToAdd = new Product
                {
                    Name = product.Name
                };

                var productId = await productRepository.CreateAsync(productToAdd);

                //Save the collection of colors with their prices with the id of the prestored product
                await productPriceRepository.CreateAsync(product.ProductPrices, productId);

                return productId;
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
                var productFromDB = await productRepository.GetByIdAsync(productToUpdate.Id);
                
                if (productFromDB is null)
                    return -1;

                await productRepository.UpdateAsync(productToUpdate, productFromDB);

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

        public async Task<Product?> GetProductByIdAsync(int id)
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
