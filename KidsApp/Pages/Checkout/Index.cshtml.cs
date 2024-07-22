using Microsoft.AspNetCore.Mvc.RazorPages;
using KidsApp.Models;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using KidsApp.Extensions;

namespace KidsApp.Pages.Checkout
{
    public class IndexModel : PageModel
    {
        public List<CartItem> CartItems { get; set; }
        public decimal TotalPrice { get; set; }
        public decimal VatAmount { get; set; }
        public decimal GrandTotal { get; set; }

        public void OnGet()
        {
            // Retrieve cart items from session
            CartItems = HttpContext.Session.GetObjectFromJson<List<CartItem>>("Cart") ?? new List<CartItem>();

            TotalPrice = 0;
            foreach (var item in CartItems)
            {
                TotalPrice += item.Product.Price * item.Quantity;
            }
            VatAmount = TotalPrice * 0.20m; // 20% VAT
            GrandTotal = TotalPrice + VatAmount;
        }
    }
}
