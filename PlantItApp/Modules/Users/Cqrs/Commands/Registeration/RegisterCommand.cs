using MediatR;
using PlantItApp.Modules.Users.Models.Request;
using PlantItApp.Modules.Users.Models.Response;

namespace PlantItApp.Modules.Users.Cqrs.Commands.Registeration;
//{

//    public class RegisterCommand : IRequest<BaseResponse>
//    {
//        RegistrationReq request = new RegistrationReq();
//        public RegisterCommand(RegistrationReq req)
//        {
//            request.firstName = req.firstName;
//            request.lastName = req.lastName;
//            request.email = req.email;
//            request.password = req.password;
//            request.phoneNumber = req.phoneNumber;

//        }
//    }
//}


public sealed record RegisterCommand(RegistrationReq request) : IRequest<BaseResponse>;


