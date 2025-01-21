using ProductApp.Application;
using ProductApp.DataAccess;

namespace ProductApp.Backend
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddDataAccessServices(builder.Configuration);
            builder.Services.AddApplicationServices();

            builder.Services.AddControllers();

            // Creacion y registro de policy para uso del Cross-Origin Resource Sharing (CORS)
            builder.Services.AddCors(options => {
                options.AddPolicy("all", builder => builder.WithOrigins("http://localhost:5173")
                                                            .AllowAnyHeader()
                                                            .AllowAnyMethod()
                                                            .AllowCredentials()
                );
            });

            builder.Services.AddOpenApi();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
            }

            app.UseHttpsRedirection();
            
            //Inclucion de un CORS middleware en el pipeline para utilizar la policy 'all' previamente configurada
            app.UseCors("all");

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
