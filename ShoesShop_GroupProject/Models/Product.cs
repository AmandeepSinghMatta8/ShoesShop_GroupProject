using System.ComponentModel.DataAnnotations;

namespace ShoesShop_GroupProject.Models
{
	public class Product
	{
		public int Id { get; set; }

		[Required]
		public string Name { get; set; }

		public string Description { get; set; }

		[Required]
		public decimal Price { get; set; }

		public int Stock { get; set; }

		public string Brand { get; set; }

		public string Category { get; set; }

		public string ImagePath { get; set; } // Store the image URL

		public string Gender { get; set; } // New field for gender added by your co-worker
	}
}
