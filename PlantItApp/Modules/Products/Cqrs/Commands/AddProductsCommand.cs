using MediatR;
using PlantItApp.Modules.Products.Models.Request;
using PlantItApp.Modules.Products.Models.Response;

namespace PlantItApp.Modules.Products.Cqrs.Commands;
public sealed record AddProductsCommand(ProductRequest request):IRequest<BaseResponse>;

