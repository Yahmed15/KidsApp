using Microsoft.AspNetCore.Mvc;
using KidsApp.Services;
using KidsApp.Data;

namespace KidsApp.Controllers
{
    public class CartController : Controller
    {
        private readonly ICartService _cartService;
        private readonly ApplicationDbContext _context;

        public CartController(ICartService cartService, ApplicationDbContext context)
        {
            _cartService = cartService;
            _context = context;
        }

        [HttpPost]
        public IActionResult AddToCart(int productId)
        {
            var product = _context.Products.Find(productId);
            if (product == null)
            {
                return NotFound();
            }

            _cartService.AddToCart(product);
            return RedirectToAction("Index", "Products");
        }

        public IActionResult Index()
        {
            var cartItems = _cartService.GetCartItems();
            return View(cartItems);
        }
    }
}
