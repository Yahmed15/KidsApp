using KidsApp.Models;
using System.Collections.Generic;

namespace KidsApp.Services
{
    public interface ICartService
    {
        void AddToCart(Product product);
        List<CartItem> GetCartItems();  // Ensure this return type matches the CartService implementation
        void ClearCart();  // Add this method to the interface
    }
}
