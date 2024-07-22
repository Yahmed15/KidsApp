using KidsApp.Extensions; // Make sure this is at the top
using Microsoft.AspNetCore.Mvc.RazorPages;
using KidsApp.Models;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;

namespace KidsApp.Pages.Cart
{
    public class IndexModel : PageModel
    {
        public List<CartItem> CartItems { get; set; }
        public decimal TotalPrice { get; set; }
        public decimal VatAmount { get; set; }
        public decimal GrandTotal { get; set; }

        public void OnGet()
        {
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
