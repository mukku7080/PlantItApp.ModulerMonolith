using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;

namespace PlantItApp.Modules.Users.Models.Response
{
    public class LoginResponse
    {
        public Guid UserId { get; set; }    
        public string Name { get; set; }
        public string Number { get; set; }  
        public string email {  get; set; }
        public string address {  get; set; }
        public string Token {  get; set; }  
    }
}
