using PlantItApp.Modules.Products.Models.Request;
using PlantItApp.Modules.Products.Models.Response;

namespace PlantItApp.Modules.Products.Repositories.Interfaces
{
    public interface IProductRepo
    {
        public ProductResponse AddProduct(ProductRequest request);
    }
}
