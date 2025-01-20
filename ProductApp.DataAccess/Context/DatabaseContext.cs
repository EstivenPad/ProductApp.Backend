using Microsoft.EntityFrameworkCore;
using ProductApp.Core;

namespace ProductApp.DataAccess.Context
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) 
        {
        }

        public DbSet<Color> Colors { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductPrice> ProductPrices { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductPrice>()
                .HasOne<Product>(pc => pc.Product)
                .WithMany(p => p.ProductPrices)
                .HasForeignKey(pc => pc.ProductId);

            modelBuilder.Entity<ProductPrice>()
                .HasOne<Color>(pc => pc.Color)
                .WithMany(c => c.ProductPrices)
                .HasForeignKey(pc => pc.ColorId);
        }
    }
}
