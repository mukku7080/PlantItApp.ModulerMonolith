using MediatR;
using Microsoft.AspNetCore.Mvc;
using PlantItApp.Modules.Users.Cqrs.Commands.Login;
using PlantItApp.Modules.Users.Cqrs.Commands.Registeration;
using PlantItApp.Modules.Users.Models.Request;
using PlantItApp.Modules.Users.Models.Response;

namespace PlantItApp.Controllers
{
    [Route("api/[Controller]")]
    [ApiExplorerSettings(GroupName = "v1")]

    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;
        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("SignUp")]
        public Task<BaseResponse> Register(RegistrationReq req)
        {
            var res = _mediator.Send(new RegisterCommand(req));
            //var res=_userService.Register(req);
            return res;

        }
        [HttpPost("Login")]
        public Task<LoginResponse> Login(LoginReq req)
        {
            var res = _mediator.Send(new LoginCommand(req));
            return res;
        }
        [HttpGet("get")]
        public int getid()
        {
            return 1;
        }
    }
}
