using Microsoft.AspNetCore.Mvc;
using ShoesShop_GroupProject.Data;
using ShoesShop_GroupProject.Models;
using System.Linq;

namespace ShoesShop_GroupProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            ViewBag.products = _context.Products.ToList();
            return View();
        }

        public IActionResult MansShoes(string SortOrder, string ShoeType, ListViewProduct model)
        {
            var productsQuery = _context.Products.Where(p => p.Gender == "Men");

            if (!string.IsNullOrEmpty(ShoeType))
            {
                productsQuery = productsQuery.Where(p => p.Category == ShoeType);
            }

            switch (SortOrder)
            {
                case "PriceAsc":
                    productsQuery = productsQuery.OrderBy(p => p.Price);
                    break;
                case "PriceDesc":
                    productsQuery = productsQuery.OrderByDescending(p => p.Price);
                    break;
                default:
                    break;
            }

            model.Products = productsQuery.ToList();
            return View(model);
        }


        public IActionResult WomensShoes(string SortOrder, string ShoeType, ListViewProduct model)
        {
            var productsQuery = _context.Products.Where(p => p.Gender == "Women");

            if (!string.IsNullOrEmpty(ShoeType))
            {
                productsQuery = productsQuery.Where(p => p.Category == ShoeType);
            }

            switch (SortOrder)
            {
                case "PriceAsc":
                    productsQuery = productsQuery.OrderBy(p => p.Price);
                    break;
                case "PriceDesc":
                    productsQuery = productsQuery.OrderByDescending(p => p.Price);
                    break;
                default:
                    break;
            }

            model.Products = productsQuery.ToList();
            return View(model);
        }


        public IActionResult ProductDetails(int id)
        {
            var product = _context.Products.Find(id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }
    }
}
