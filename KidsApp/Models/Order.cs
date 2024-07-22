using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace KidsApp.Models
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }
        public int CustomerId { get; set; }
        public List<OrderItem> OrderItems { get; set; }
    }
}
