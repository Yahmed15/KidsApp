using Microsoft.EntityFrameworkCore;
using KidsApp.Models;

namespace KidsApp.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<InquiryInfo> Inquiries { get; set; }
        public DbSet<CartItem> CartItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure table names
            modelBuilder.Entity<Product>().ToTable("Products");
            modelBuilder.Entity<Customer>().ToTable("Customers");
            modelBuilder.Entity<Order>().ToTable("Orders");
            modelBuilder.Entity<OrderItem>().ToTable("OrderItems");
            modelBuilder.Entity<InquiryInfo>().ToTable("Inquiries");
            modelBuilder.Entity<CartItem>().ToTable("CartItems");

            // Configure primary keys
            modelBuilder.Entity<InquiryInfo>().HasKey(e => e.Id);
            modelBuilder.Entity<Order>().HasKey(e => e.OrderId);
            modelBuilder.Entity<OrderItem>().HasKey(e => e.OrderItemId);

            // Define relationships
            modelBuilder.Entity<CartItem>()
                .HasOne(ci => ci.Product)
                .WithMany()
                .HasForeignKey(ci => ci.ProductId);
        }
    }
}
