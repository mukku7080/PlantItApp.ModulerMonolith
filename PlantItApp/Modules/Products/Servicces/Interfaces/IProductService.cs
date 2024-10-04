using PlantItApp.Modules.Products.Models.Request;
using PlantItApp.Modules.Products.Models.Response;

namespace PlantItApp.Modules.Products.Servicces.Interfaces
{
    public interface IProductService
    {
        public BaseResponse AddProduct(ProductRequest request);

    }
}
