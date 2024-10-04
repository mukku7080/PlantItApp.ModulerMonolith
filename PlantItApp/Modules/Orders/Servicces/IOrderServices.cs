using PlantItApp.Modules.Orders.Models.Request;
using PlantItApp.Modules.Orders.Models.Response;

namespace PlantItApp.Modules.Orders.Servicces
{
    public interface IOrderServices
    {
        public BaseResponse CreateOrder(List<OrderRequest> request ,string shippingAddress);
    }
}
