using Microsoft.EntityFrameworkCore;
using PlantItApp.Modules.Users.Models.DbTable;

namespace PlantItApp.Modules.Users.Data
{
    public class UserDbContext : DbContext
    {
        public UserDbContext(DbContextOptions<UserDbContext> options) : base(options)
        {
        }
        public DbSet<User> users { get; set; }
    }
}
