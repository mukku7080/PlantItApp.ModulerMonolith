using PlantItApp.Modules.Products.Models.DbTable;

namespace PlantItApp.Modules.Products.Models.Request
{
    public class ProductResponse
    {
        public Guid ProductId { get; set; }

        public Guid? VenderId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Category { get; set; }

        public decimal Price { get; set; }

        public decimal? Discount { get; set; } // Optional field

        public int StockQuantity { get; set; }

        public int MinimumOrderQuantity { get; set; }

        public string ImageUrl { get; set; }

        public bool IsAvailable { get; set; }
    }
}
