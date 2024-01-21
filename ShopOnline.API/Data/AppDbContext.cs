using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ShopOnline.API.Entites;
using ShopOnline.API.Extensions;

namespace ShopOnline.API.Data
{
    public class AppDbContext : DbContext
    {
        
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }
        
        public DbSet<Cart> Carts{ get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<UserAddress> UserAddresses { get; set; }
        public DbSet<AppUser> Users { get; set; }
        public DbSet<Size>  Sizes { get; set; }
        public DbSet<FitType> FitTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Product>()
                .HasMany(p => p.Images)
                .WithOne(p => p.Product);

            modelBuilder.Entity<Product>()
                .HasMany(p => p.Categories)
                .WithMany(p => p.Products)
                .UsingEntity<ProductCategory>();

            modelBuilder.Entity<Product>()
                .HasMany(p => p.FitTypes)
                .WithMany(p => p.Products)
                .UsingEntity<ProductFitType>();

            modelBuilder.Entity<Product>()
                .HasMany(p => p.Sizes)
                .WithMany(p => p.Products)
                .UsingEntity<ProductSize>();
            
            modelBuilder.Seed();

        }
    }
}
