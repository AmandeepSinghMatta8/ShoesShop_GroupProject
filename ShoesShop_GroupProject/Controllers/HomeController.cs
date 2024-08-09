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

        public IActionResult MansShoes(ListViewProduct model)
        {
            model.Products = _context.Products.Where(p => p.Gender == "Men").ToList();
            return View(model);
        }

        public IActionResult WomensShoes(ListViewProduct model)
        {
            model.Products = _context.Products.Where(p => p.Gender == "Women").ToList();
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
