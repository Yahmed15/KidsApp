using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using KidsApp.Models;

namespace KidsApp.Data
{
    public static class DbInitializer
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ApplicationDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>()))
            {
                // Look for any products.
                if (context.Products.Any())
                {
                    return;   // DB has been seeded
                }

                var products = new Product[]
                {
                    new Product { Name = "Educational Toy", Description = "A toy that teaches kids about numbers and letters.", Price = 19.99M },
                    new Product { Name = "Healthy Snacks", Description = "Delicious and nutritious snacks for kids.", Price = 9.99M },
                    new Product { Name = "Interactive Book", Description = "A book with interactive elements to make learning fun.", Price = 14.99M },
                };

                context.Products.AddRange(products);
                context.SaveChanges();
            }
        }
    }
}
