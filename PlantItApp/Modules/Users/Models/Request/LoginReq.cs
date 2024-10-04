using System.ComponentModel.DataAnnotations;

namespace PlantItApp.Modules.Users.Models.Request
{
    public class LoginReq
    {
        [Required]
        public string NumberOrEmail {  get; set; }
        [Required]
        public string password { get; set; }    
    }
}
