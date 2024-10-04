using MediatR;
using PlantItApp.Modules.Products.Models.Response;
using PlantItApp.Modules.Products.Servicces.Interfaces;

namespace PlantItApp.Modules.Products.Cqrs.Commands
{
    public class AddProductsCommandHandler : IRequestHandler<AddProductsCommand, BaseResponse>
    {
        private readonly IProductService _productService;
        public AddProductsCommandHandler(IProductService productService)
        {
            _productService = productService;
        }

        public Task<BaseResponse> Handle(AddProductsCommand request, CancellationToken cancellationToken)
        {
           var res= _productService.AddProduct(request.request);

           return Task.FromResult(res);
        }
    }
}
