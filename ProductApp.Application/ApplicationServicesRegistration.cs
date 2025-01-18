using Microsoft.Extensions.DependencyInjection;
using ProductApp.Application.Services.Colors;
using ProductApp.Application.Services.Products;

namespace ProductApp.Application
{
    public static class ApplicationServicesRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IColorService, ColorService>();
            services.AddScoped<IProductService, ProductService>();

            return services;
        }
    }
}
