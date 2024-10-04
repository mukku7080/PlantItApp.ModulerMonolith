using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PlantItApp.Modules.Users.Models.DbTable
{
    [Table("Users")]
    public class User
    {
        [Key]
        public Guid UserId { get; set; } // or change to int if you prefer

        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public string FirstName { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        [Column(TypeName = "nvarchar(100)")]
        public string Email { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(255)")]
        public string PasswordHash { get; set; }

        [Phone]
        [Column(TypeName = "nvarchar(20)")]
        public string PhoneNumber { get; set; }

        [Column(TypeName = "nvarchar(255)")]
        public string? Address { get; set; }

        [Required]
        [Column(TypeName = "int")]
        public Role Role { get; set; }

        [Required]
        [Column(TypeName = "datetime2")]
        public DateTime DateCreated { get; set; } = DateTime.UtcNow;

        [Required]
        [Column(TypeName = "bit")]
        public bool IsActive { get; set; } = true;
    }

    public enum Role
    {
        Customer = 1,
        Admin = 2
    }
}



