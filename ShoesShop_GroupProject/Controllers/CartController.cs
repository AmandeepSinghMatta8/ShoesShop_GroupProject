using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http; // For session management
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ShoesShop_GroupProject.Data;
using ShoesShop_GroupProject.Models;
using System.Linq;
using Newtonsoft.Json; // For serializing and deserializing objects to and from JSON

namespace ShoesShop_GroupProject.Controllers
{
    [Authorize]
    public class CartController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public CartController(ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        private string GetCartSessionKey()
        {
            var userId = _userManager.GetUserId(User);
            return $"Cart_{userId}";
        }

        private List<CartItem> GetCartItems()
        {
            string cartSessionKey = GetCartSessionKey();
            var cartItemsJson = HttpContext.Session.GetString(cartSessionKey);
            return string.IsNullOrEmpty(cartItemsJson) ? new List<CartItem>() : JsonConvert.DeserializeObject<List<CartItem>>(cartItemsJson);
        }

        private void SaveCartItems(List<CartItem> cartItems)
        {
            string cartSessionKey = GetCartSessionKey();
            var cartItemsJson = JsonConvert.SerializeObject(cartItems);
            HttpContext.Session.SetString(cartSessionKey, cartItemsJson);
        }

        public IActionResult Index()
        {
            var cartItems = GetCartItems();
            return View(cartItems);
        }

        [HttpPost]
        public IActionResult AddToCart(int productId, int quantity, string size)
        {
            var product = _context.Products.Find(productId);
            if (product == null)
            {
                return NotFound();
            }

            var cartItems = GetCartItems();

            var existingItem = cartItems.FirstOrDefault(ci => ci.ProductId == productId && ci.Size == size);
            if (existingItem != null)
            {
                existingItem.Quantity += quantity;
            }
            else
            {
                cartItems.Add(new CartItem
                {
                    ProductId = productId,
                    Quantity = quantity,
                    Price = product.Price,
                    Size = size,
                    Product = product
                });
            }

            SaveCartItems(cartItems);

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult RemoveFromCart(int productId)
        {
            var cartItems = GetCartItems();
            var itemToRemove = cartItems.FirstOrDefault(c => c.Product.Id == productId);

            if (itemToRemove != null)
            {
                cartItems.Remove(itemToRemove);
                SaveCartItems(cartItems);
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult UpdateCart(int productId, int quantity, string size)
        {
            var cartItems = GetCartItems();

            var itemToUpdate = cartItems.FirstOrDefault(ci => ci.ProductId == productId && ci.Size == size);
            if (itemToUpdate != null)
            {
                if (quantity <= 0)
                {
                    cartItems.Remove(itemToUpdate);
                }
                else
                {
                    itemToUpdate.Quantity = quantity;
                }
                SaveCartItems(cartItems);
            }

            return RedirectToAction("Index");
        }

        public IActionResult DecreaseQuantity(int productId)
        {
            var cartItems = GetCartItems();
            var item = cartItems.FirstOrDefault(c => c.ProductId == productId);

            if (item != null && item.Quantity > 1)
            {
                item.Quantity--;
                SaveCartItems(cartItems);
            }
            else if (item != null)
            {
                cartItems.Remove(item);
                SaveCartItems(cartItems);
            }

            return RedirectToAction("Index");
        }

        public IActionResult IncreaseQuantity(int productId)
        {
            var cartItems = GetCartItems();
            var item = cartItems.FirstOrDefault(c => c.ProductId == productId);

            if (item != null)
            {
                item.Quantity++;
                SaveCartItems(cartItems);
            }

            return RedirectToAction("Index");
        }

    }
}
