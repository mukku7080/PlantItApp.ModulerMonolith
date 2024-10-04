using Microsoft.EntityFrameworkCore;
using PlantItApp.Modules.Users.Data;
using PlantItApp.Modules.Users.Repositories;
using PlantItApp.Modules.Users.Repositories.Interfaces;
using PlantItApp.Modules.Users.Servicces;
using PlantItApp.Modules.Users.Servicces.Interfaces;

namespace PlantItApp.Modules.Users
{
    public class UsersModule
    {
        

        public static void ConfigureServices(IServiceCollection services,IConfiguration configuration)
        {

            services.AddDbContext<UserDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("UserDbConnection")));


            //Add Repositories
            services.AddScoped<IUserRepo, UserRepo>();

            // add Services
            services.AddScoped<IUserService, UserService>();

            services.AddCors(options =>
            {
                options.AddPolicy("AllowAll",
                    builder => builder
                        .AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader());
            });

        } 
    }
}
