using Microsoft.EntityFrameworkCore;
using Shopping_App.Models;

namespace Shopping_App.EntityFramework
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Product> Products { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<Cart> Carts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasKey(p => p.Id);
            modelBuilder.Entity<CartItem>().HasKey(ci => new { ci.ProductId, ci.CartId });
            modelBuilder.Entity<Cart>().HasKey(c => c.Id);

            base.OnModelCreating(modelBuilder);
        }
    }
}
