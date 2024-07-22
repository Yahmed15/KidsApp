using KidsApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KidsApp.Services
{
    public interface IProductService
    {
        Task<List<Product>> GetProductsAsync();
        Task<Product> GetProductByIdAsync(int productId);  // Add this line
    }
}
