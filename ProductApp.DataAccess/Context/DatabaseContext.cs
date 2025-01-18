using Microsoft.EntityFrameworkCore;
using ProductApp.Core;

namespace ProductApp.DataAccess.Context
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) 
        {
        }

        public DbSet<Color> Color { get; set; }
        public DbSet<Product> Product { get; set; }
    }
}
