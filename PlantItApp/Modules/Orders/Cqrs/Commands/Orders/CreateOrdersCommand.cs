using MediatR;
using PlantItApp.Modules.Orders.Models.Request;
using PlantItApp.Modules.Orders.Models.Response;

namespace PlantItApp.Modules.Orders.Cqrs.Commands.Orders;

public sealed record CreateOrdersCommand(List<OrderRequest> request, string shippingAddress):IRequest<BaseResponse>;

