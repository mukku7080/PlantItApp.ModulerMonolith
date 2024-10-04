using PlantItApp.Modules.Users.Models.Request;
using PlantItApp.Modules.Users.Models.Response;

namespace PlantItApp.Modules.Users.Repositories.Interfaces
{
    public interface IUserRepo
    {
        public string Register(RegistrationReq req);
        public LoginResponse Login(LoginReq req);
    }
}
