using Microsoft.EntityFrameworkCore;
using PlantItApp.Modules.Orders.Models.DbTable;

namespace PlantItApp.Modules.Orders.Data
{
    public class OrderDbContext : DbContext
    {
        public OrderDbContext(DbContextOptions<OrderDbContext> options) : base(options)
        {
        }
        public DbSet<Order> orders { get; set; }    
        public DbSet<OrderItem> orderItems { get; set; }    
    }
}
