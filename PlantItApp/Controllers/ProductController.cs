using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PlantItApp.Modules.Products.Cqrs.Commands;
using PlantItApp.Modules.Products.Models.Request;
using PlantItApp.Modules.Products.Models.Response;

namespace PlantItApp.Controllers
{
    [Route("api/[Controller]")]
    [ApiExplorerSettings(GroupName = "v2")]

    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost("AddProducts")]
        public Task<BaseResponse> AddProducts(ProductRequest request)
        {
            var res = _mediator.Send(new AddProductsCommand(request));

            return res;

        }
        [HttpGet("idget")]
        public int getid()
        {
            return 1;
        }
    }
}
