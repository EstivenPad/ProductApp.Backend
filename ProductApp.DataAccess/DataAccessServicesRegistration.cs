using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProductApp.DataAccess.Context;

namespace ProductApp.DataAccess
{
    public static class DataAccessServicesRegistration
    {
        public static IServiceCollection AddDataAccessServicesRegistration(this IServiceCollection services, IConfiguration configuration)
        {
            //Registro el DatabaseContext a traves de un extension method
            services.AddDbContext<DatabaseContext>(options => {
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnectionString"));
            });

            return services;
        }
    }
}
