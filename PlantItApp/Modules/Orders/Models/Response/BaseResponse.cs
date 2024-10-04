using Microsoft.Identity.Client;

namespace PlantItApp.Modules.Orders.Models.Response
{
    public class BaseResponse
    {
        public int Status { get; set;   }
        public string Messege { get; set; }
        public dynamic response { get; set; }   
    }
}
