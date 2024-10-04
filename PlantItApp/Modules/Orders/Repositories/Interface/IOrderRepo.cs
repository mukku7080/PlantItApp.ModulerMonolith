using PlantItApp.Modules.Orders.Models.DbTable;
using PlantItApp.Modules.Orders.Models.Request;

namespace PlantItApp.Modules.Orders.Repositories.Interface
{
    public interface IOrderRepo
    {
        public Order CreateOrder( List<OrderRequest> request , string ShippingAddress);
    }
}
