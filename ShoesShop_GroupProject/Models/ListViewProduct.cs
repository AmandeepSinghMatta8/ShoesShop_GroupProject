using System.Collections.Generic;

namespace ShoesShop_GroupProject.Models
{
    public class ListViewProduct
    {
        public IEnumerable<Product> Products { get; set; }
        public IEnumerable<Category> Categories { get; set; }
    }
}
