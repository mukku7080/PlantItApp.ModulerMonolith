using PlantItApp.Modules.Users.Models.DbTable;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PlantItApp.Modules.Orders.Models.DbTable
{
    public class Order
    {
        
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid OrderId { get; set; } // or int if preferred

        [Required]
        public Guid UserId { get; set; }
        [Required]
        public Guid? VenderId { get; set; }

        [Required]
        public Guid ProductId { get; set; }

        [Required]
        [Column(TypeName = "datetime2")]
        public DateTime OrderDate { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal TotalAmount { get; set; }

        [Required]
        [Column(TypeName = "int")]
        public OrderStatus OrderStatus { get; set; }

        [Required]
        [Column(TypeName = "int")]
        public PaymentStatus PaymentStatus { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? DeliveryDate { get; set; } // Nullable

        [Required]
        [Column(TypeName = "nvarchar(255)")]
        public string ShippingAddress { get; set; }

    }

    public enum OrderStatus
    {
        Pending = 1,
        Confirmed = 2,
        Shipped = 3,
        Delivered = 4,
        Canceled = 5
    }

    public enum PaymentStatus
    {
        Pending = 1,
        Paid = 2,
        Failed = 3
    }
}
