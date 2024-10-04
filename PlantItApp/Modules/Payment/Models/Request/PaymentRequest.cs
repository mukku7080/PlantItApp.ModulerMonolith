namespace PlantItApp.Modules.Payment.Models.Request
{
    public class PaymentRequest
    {
        public decimal Amount { get; set; }
        public string Token { get; set; } 
        public string Description { get; set; }
    }
}
