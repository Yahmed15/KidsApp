using System.ComponentModel.DataAnnotations;

namespace KidsApp.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [StringLength(255)]
        public string Description { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }
    }
}
