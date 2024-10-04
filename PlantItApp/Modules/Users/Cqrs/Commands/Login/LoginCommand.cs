using MediatR;
using PlantItApp.Modules.Users.Models.Request;
using PlantItApp.Modules.Users.Models.Response;

namespace PlantItApp.Modules.Users.Cqrs.Commands.Login;
public sealed record LoginCommand(LoginReq request):IRequest<LoginResponse>;

