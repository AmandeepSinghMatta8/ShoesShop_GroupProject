using System.ComponentModel.DataAnnotations;

namespace ShoesShop_GroupProject.Models
{
    public class CartItem
    {
        [Key]
        public int Id { get; set; } // Primary Key
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; } // Add this line to include Price
        public string Size { get; set; }
        public Product Product { get; set; } // Navigation property to Product
    }
}
