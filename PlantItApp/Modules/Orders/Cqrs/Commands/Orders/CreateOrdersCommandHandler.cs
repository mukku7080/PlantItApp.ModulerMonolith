using MediatR;
using PlantItApp.Modules.Orders.Models.Response;
using PlantItApp.Modules.Orders.Servicces;

namespace PlantItApp.Modules.Orders.Cqrs.Commands.Orders
{
    public class CreateOrdersCommandHandler : IRequestHandler<CreateOrdersCommand, BaseResponse>
    {

        private readonly IOrderServices _orderServices;

        public CreateOrdersCommandHandler(IOrderServices orderServices)
        {
            _orderServices = orderServices;
        }

        public Task<BaseResponse> Handle(CreateOrdersCommand request ,CancellationToken cancellationToken)
        {
           return Task.FromResult( _orderServices.CreateOrder(request.request,request.shippingAddress));
           
        }
    }
}
