using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PlantItApp.Modules.Orders.Models.DbTable
{
    public class OrderItem
    {
        [Key]
        public Guid OrderItemId { get; set; } // or int if preferred

        [Required]
        public Guid OrderId { get; set; } // Foreign key to Order

        [Required]
        public Guid ProductId { get; set; } // Foreign key to Product

        [Required]
        [Column(TypeName = "int")]
        public int Quantity { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }

        //public Order Order { get; set; } // Navigation property
        //public Product Product { get; set; } // Navigation property
    }
}
