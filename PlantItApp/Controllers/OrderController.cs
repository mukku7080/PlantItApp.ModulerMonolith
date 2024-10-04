using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PlantItApp.Modules.Orders.Cqrs.Commands.Orders;
using PlantItApp.Modules.Orders.Models.Request;
using PlantItApp.Modules.Orders.Models.Response;

namespace PlantItApp.Controllers
{
    [Route("api/[controller]")]
    [ApiExplorerSettings(GroupName = "v3")]

    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OrderController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public Task<BaseResponse> CreateOrder(CreateOrderRequest request)
        {
            return _mediator.Send(new CreateOrdersCommand(request.orderRequests,request.ShippingAddress));
        }
    }
}
