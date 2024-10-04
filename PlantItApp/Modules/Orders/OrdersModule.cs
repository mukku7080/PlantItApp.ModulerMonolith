using Microsoft.EntityFrameworkCore;
using PlantItApp.Modules.Orders.Data;
using PlantItApp.Modules.Orders.Repositories;
using PlantItApp.Modules.Orders.Repositories.Interface;
using PlantItApp.Modules.Orders.Servicces;
using PlantItApp.Modules.Users.Data;

namespace PlantItApp.Modules.Orders
{
    public class OrdersModule
    {
        public static void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<OrderDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("OrderDbConnection")));

            services.AddScoped<IOrderServices, OrderServices>();
            services.AddScoped<IOrderRepo, OrderRepo>();


        }
    }
}
