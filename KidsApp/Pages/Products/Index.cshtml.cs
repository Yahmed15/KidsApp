using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using KidsApp.Data;
using KidsApp.Models;
using System.Threading.Tasks;
using System.Collections.Generic;
using KidsApp.Extensions;
using Microsoft.EntityFrameworkCore;

namespace KidsApp.Pages.Products
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public IndexModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Product> Products { get; set; }

        public async Task OnGetAsync()
        {
            Products = await _context.Products.ToListAsync();
        }

        public async Task<IActionResult> OnPostAddToCartAsync(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            // Retrieve the cart from the session or create a new one
            var cart = HttpContext.Session.GetObjectFromJson<List<CartItem>>("Cart") ?? new List<CartItem>();

            // Check if the product already exists in the cart
            var cartItem = cart.Find(item => item.Product.Id == id);
            if (cartItem != null)
            {
                // Increase quantity if the product is already in the cart
                cartItem.Quantity++;
            }
            else
            {
                // Add new product to the cart
                cart.Add(new CartItem { Product = product, Quantity = 1 });
            }

            // Save the updated cart to the session
            HttpContext.Session.SetObjectAsJson("Cart", cart);

            return RedirectToPage("/Cart/Index");
        }
    }
}
