using KidsApp.Data;
using KidsApp.Models;
using KidsApp.Extensions; // Add this line
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KidsApp.Services
{
    public class CartService : ICartService
    {
        private readonly ApplicationDbContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CartService(ApplicationDbContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }

        public void AddToCart(Product product)
        {
            var session = _httpContextAccessor.HttpContext.Session;
            var cart = session.GetObjectFromJson<List<CartItem>>("Cart") ?? new List<CartItem>();

            var cartItem = cart.FirstOrDefault(ci => ci.Product.Id == product.Id);
            if (cartItem == null)
            {
                cartItem = new CartItem { Product = product, Quantity = 1 };
                cart.Add(cartItem);
            }
            else
            {
                cartItem.Quantity++;
            }

            session.SetObjectAsJson("Cart", cart); // Using our custom extension method
        }

        public List<CartItem> GetCartItems()
        {
            var session = _httpContextAccessor.HttpContext.Session;
            return session.GetObjectFromJson<List<CartItem>>("Cart") ?? new List<CartItem>();
        }

        public void ClearCart()
        {
            var session = _httpContextAccessor.HttpContext.Session;
            session.SetObjectAsJson("Cart", new List<CartItem>());
        }
    }
}
