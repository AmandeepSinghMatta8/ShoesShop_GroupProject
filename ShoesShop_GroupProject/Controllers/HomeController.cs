using Microsoft.AspNetCore.Mvc;
using ShoesShop_GroupProject.Data;
using ShoesShop_GroupProject.Models;
using System.Diagnostics;

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
			// Fetch all products from the database
			var products = _context.Products.ToList();
			ViewBag.products = products;
			return View();
		}
	}
}
