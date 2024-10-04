using PlantItApp.Modules.Products.Models.Request;
using PlantItApp.Modules.Products.Models.Response;
using PlantItApp.Modules.Products.Repositories.Interfaces;
using PlantItApp.Modules.Products.Servicces.Interfaces;

namespace PlantItApp.Modules.Products.Servicces
{
    public class ProductService : IProductService
    {
        private readonly IProductRepo _productReo;
        public ProductService(IProductRepo productRepo)
        {
            _productReo = productRepo;
        }

        public BaseResponse AddProduct(ProductRequest request)
        {
            var res =_productReo.AddProduct(request);
            return new BaseResponse
            {
                statusCode = StatusCodes.Status200OK,
                messege="Product Added Successfully",
                respone = res

            };

        }
    }
}
