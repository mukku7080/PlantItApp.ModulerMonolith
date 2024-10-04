using PlantItApp.Modules.Users.Models.Request;
using PlantItApp.Modules.Users.Models.Response;
using PlantItApp.Modules.Users.Repositories.Interfaces;
using PlantItApp.Modules.Users.Servicces.Interfaces;
using System.Net;

namespace PlantItApp.Modules.Users.Servicces
{
    public class UserService : IUserService
    {
        private readonly IUserRepo _userRepo;
        public UserService(IUserRepo userRepo)
        {
            _userRepo = userRepo;
        }

        public LoginResponse Login(LoginReq req)
        {
              
            return _userRepo.Login(req);
            //return new BaseResponse
            //{
            //    statusCode = StatusCodes.Status200OK,
            //    messege=res
            //};
        }

        public BaseResponse Register(RegistrationReq req)
        {
           var res= _userRepo.Register(req);
            return new BaseResponse
            {
                statusCode = StatusCodes.Status200OK,
                messege = res

            };
            
        }
    }
}
