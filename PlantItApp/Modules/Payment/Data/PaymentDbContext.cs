using Microsoft.EntityFrameworkCore;

namespace PlantItApp.Modules.Payment.Data
{
    public class PaymentDbContext : DbContext
    {
        public PaymentDbContext(DbContextOptions<PaymentDbContext> options) : base(options)
        {
        }
    }
}
