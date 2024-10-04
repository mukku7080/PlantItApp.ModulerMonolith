using Microsoft.EntityFrameworkCore;
using PlantItApp.Modules.Products.Data;
using PlantItApp.Modules.Products.Repositories;
using PlantItApp.Modules.Products.Repositories.Interfaces;
using PlantItApp.Modules.Products.Servicces;
using PlantItApp.Modules.Products.Servicces.Interfaces;

namespace PlantItApp.Modules.Products
{
    public class ProductsModule
    {
        public static void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        
        {
           var x= services.AddDbContext<ProductDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("ProductDbConnection")));


            // add Services
            services.AddScoped<IProductService, ProductService>();
            //Add Repositories
            services.AddScoped<IProductRepo, ProductRepo>();
         

           
           
        }
    }
}
