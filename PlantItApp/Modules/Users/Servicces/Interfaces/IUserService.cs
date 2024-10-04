using PlantItApp.Modules.Users.Models.Request;
using PlantItApp.Modules.Users.Models.Response;

namespace PlantItApp.Modules.Users.Servicces.Interfaces
{
    public interface IUserService
    {
        public BaseResponse Register(RegistrationReq req);
        public LoginResponse Login(LoginReq req);

    }
}
