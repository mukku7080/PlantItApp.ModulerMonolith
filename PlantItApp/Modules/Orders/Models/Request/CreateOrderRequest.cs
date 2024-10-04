namespace PlantItApp.Modules.Orders.Models.Request
{

    public class CreateOrderRequest
    {
        public List<OrderRequest> orderRequests { get; set; }
        public string ShippingAddress { get; set; }
    }


    public class OrderRequest
    {
        public Guid UserId { get; set; }
        public Guid ProductId { get; set; }
        public Decimal TotalAmount { get; set; }

    }
}
