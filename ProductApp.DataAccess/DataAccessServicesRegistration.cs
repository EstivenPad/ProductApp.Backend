using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProductApp.Application.Contracts;
using ProductApp.DataAccess.Context;
using ProductApp.DataAccess.Repositories;

namespace ProductApp.DataAccess
{
    public static class DataAccessServicesRegistration
    {
        public static IServiceCollection AddDataAccessServicesRegistration(this IServiceCollection services, IConfiguration configuration)
        {
            //Registro el 'DatabaseContext' en el service container
            services.AddDbContext<DatabaseContext>(options => {
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnectionString"));
            });

            //Registro cualquier implementacion de 'IGenericRepository' que herede de 'GenericRepository', en el service container
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IColorRepository, ColorRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();

            return services;
        }
    }
}
