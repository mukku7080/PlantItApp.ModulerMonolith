using MediatR;
using PlantItApp.Modules.Users.Models.Response;
using PlantItApp.Modules.Users.Servicces.Interfaces;

namespace PlantItApp.Modules.Users.Cqrs.Commands.Registeration
{
    public class RegisterCommandHandler : IRequestHandler<RegisterCommand, BaseResponse>
    {
        private readonly IUserService _userService;
        public RegisterCommandHandler(IUserService userService)
        {
            _userService = userService;
        }

        public Task<BaseResponse> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            BaseResponse res = _userService.Register(request.request);
            return Task.FromResult(res);
        }
    }
}
