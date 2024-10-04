using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PlantItApp.Modules.Products.Models.DbTable
{
    [Table("Products")]
    public class Product
    {
        [Key]
        public Guid ProductId { get; set; }
       
        public Guid? VenderId { get; set; }

        
        [Column(TypeName = "nvarchar(100)")]
        public string Name { get; set; }

        [Column(TypeName = "nvarchar(500)")]
        public string? Description { get; set; }

        
        [Column(TypeName = "nvarchar(100)")]
        public string Category { get; set; }

        
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal? Discount { get; set; } // Optional field

        
        [Column(TypeName = "int")]
        public int StockQuantity { get; set; }

       
        [Column(TypeName = "int")]
        public int MinimumOrderQuantity { get; set; }

        [Column(TypeName = "nvarchar(255)")]
        public string? ImageUrl { get; set; }

        
        [Column(TypeName = "bit")]
        public bool IsAvailable { get; set; }
    }


}

 

