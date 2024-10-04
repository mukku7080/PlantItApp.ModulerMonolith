using PlantItApp.Modules.Orders.Data;
using PlantItApp.Modules.Orders.Models.DbTable;
using PlantItApp.Modules.Orders.Models.Request;
using PlantItApp.Modules.Orders.Models.Response;
using PlantItApp.Modules.Orders.Repositories.Interface;
using PlantItApp.Modules.Products.Data;
using PlantItApp.Modules.Users.Data;

namespace PlantItApp.Modules.Orders.Repositories
{
    public class OrderRepo : IOrderRepo
    {
        private readonly OrderDbContext _orderContext;
        private readonly ProductDbContext _productContext;
        private readonly UserDbContext _userContext;

        public OrderRepo( OrderDbContext orderDbContext , UserDbContext userDbContext , ProductDbContext productDbContext)
        {
            _orderContext = orderDbContext;
             _userContext = userDbContext;
            _productContext = productDbContext;
            
        }

        public Order CreateOrder(List<OrderRequest> request ,string shippingAddress)
        {
            var OrderId = Guid.NewGuid();
            var data = new Order();

            foreach (var orderRequest in request)
            {
                var vId = _productContext.products.Where(x => x.ProductId == orderRequest.ProductId).Select(x => x.VenderId).FirstOrDefault();
                 data = new Order
                {
                    OrderId = OrderId,
                    UserId = orderRequest.UserId,
                    VenderId = vId,
                    ProductId = orderRequest.ProductId,
                    OrderDate = DateTime.UtcNow,
                    TotalAmount =+ orderRequest.TotalAmount,
                    OrderStatus = OrderStatus.Confirmed,
                    PaymentStatus = PaymentStatus.Paid,
                    DeliveryDate = DateTime.UtcNow.AddDays(3),
                    ShippingAddress = shippingAddress

                };



                _orderContext.orders.Add(data);
                _orderContext.SaveChanges();
            }

            var userId = request.Select(x => x.UserId).FirstOrDefault();
            

                var userDetail = _userContext.users.FirstOrDefault(x => x.UserId == userId);
                if (userDetail != null)
                {

                    userDetail.Address = shippingAddress;

                }
                _userContext.SaveChanges();
            



            return data;

        }
    }
}
