using MediatR;
using PlantItApp.Modules.Users.Models.Response;
using PlantItApp.Modules.Users.Servicces.Interfaces;

namespace PlantItApp.Modules.Users.Cqrs.Commands.Login
{
    public class LoginCommandHandler : IRequestHandler<LoginCommand, LoginResponse>
    {
        private readonly IUserService _userService;
        public LoginCommandHandler(IUserService userService)
        {
            _userService = userService;
        }

        public Task<LoginResponse> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            LoginResponse response = _userService.Login(request.request);
            return Task.FromResult(response);
        }
    }
}
