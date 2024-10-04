using PlantItApp.Modules.Products.Data;
using PlantItApp.Modules.Products.Models.DbTable;
using PlantItApp.Modules.Products.Models.Request;
using PlantItApp.Modules.Products.Repositories.Interfaces;

namespace PlantItApp.Modules.Products.Repositories
{
    public class ProductRepo : IProductRepo
    {
        private readonly ProductDbContext _productDbContext;

        public ProductRepo(ProductDbContext productDbContext)
        {
            _productDbContext = productDbContext;

        }

        public ProductResponse AddProduct(ProductRequest request)
        {
            var data = new Product
            {
                Name= request.Name,
                Description =request.Description,
                Category=request.Category,
                Price=request.Price,
                Discount=request.Discount,
                StockQuantity=request.StockQuantity,
                MinimumOrderQuantity=request.MinimumOrderQuantity,  
                ImageUrl=request.ImageUrl,
                IsAvailable=true

            };
            _productDbContext.products.Add(data);
            _productDbContext.SaveChanges();

            var res = _productDbContext.products.Where(x => x.ProductId == data.ProductId).Select(x => new ProductResponse
            {
                ProductId=x.ProductId,
                VenderId=x.VenderId,
                Name = x.Name,
                Description = x.Description,
                Category = x.Category,
                Price = x.Price,
                Discount = x.Discount,
                StockQuantity = x.StockQuantity,
                MinimumOrderQuantity = x.MinimumOrderQuantity,
                ImageUrl = x.ImageUrl,
                IsAvailable = x.IsAvailable

            }).FirstOrDefault();

            return res;
        }
    }
}
