using PlantItApp.Modules.Orders.Models.Request;
using PlantItApp.Modules.Orders.Models.Response;
using PlantItApp.Modules.Orders.Repositories.Interface;

namespace PlantItApp.Modules.Orders.Servicces
{
    public class OrderServices : IOrderServices
    {
        private readonly IOrderRepo _orderRepo;

        public OrderServices(IOrderRepo orderRepo)
        {
            _orderRepo = orderRepo;
        }

        public BaseResponse CreateOrder(List<OrderRequest> request, string shippingAddress)
        {
            return new BaseResponse
            {
                Status = StatusCodes.Status200OK,
                Messege = "Order Created Successfully",
                response = _orderRepo.CreateOrder(request,shippingAddress)
            };

        }
    }
}
