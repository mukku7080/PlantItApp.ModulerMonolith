using Microsoft.EntityFrameworkCore;
using PlantItApp.Modules.Products.Models.DbTable;


namespace PlantItApp.Modules.Products.Data
{
    public class ProductDbContext : DbContext
    {
        public ProductDbContext(DbContextOptions<ProductDbContext> options) : base(options)
        {
        }
        public DbSet<Product> products { get; set; }
    }
}
