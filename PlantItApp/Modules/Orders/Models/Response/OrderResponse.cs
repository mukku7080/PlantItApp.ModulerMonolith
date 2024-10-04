namespace PlantItApp.Modules.Orders.Models.Response
{
    public class OrderResponse
    {
        public Guid UserId { get; set; }
        public Guid VenderId { get; set; }
        public Decimal TotalAmount { get; set; }
        public string OrderStatus { get; set; }
        public string PaymentStatus { get; set; }
        public DateTime DeliveryDate {  get; set; }    
        public string ShippingAddress { get; set; }
    }
}
