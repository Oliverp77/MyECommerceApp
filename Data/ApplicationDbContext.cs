using System.Net.Http.Headers;
using Microsoft.EntityFrameworkCore;
using MyECommerceApp.Models;

namespace MyECommerceApp.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderProduct> OrderProducts { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartProduct> CartProducts { get; set; }

         protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId);
            entity.Property(e => e.UserId).ValueGeneratedOnAdd();
            entity.Property(e => e.Name).IsRequired().HasMaxLength(100);
            entity.Property(e => e.Email).IsRequired().HasMaxLength(100);
            entity.Property(e => e.Password).IsRequired().HasMaxLength(100);
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.ProductId);
            entity.Property(e => e.ProductId).ValueGeneratedOnAdd();
            entity.Property(e => e.Name).IsRequired().HasMaxLength(100);
            entity.Property(e => e.Description).HasMaxLength(500);
            entity.Property(e => e.Price).IsRequired().HasColumnType("decimal(10,2)");
            entity.Property(e => e.Category).HasMaxLength(100);
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.OrderId);
            entity.Property(e => e.OrderId).ValueGeneratedOnAdd();
            entity.Property(e => e.Total).IsRequired().HasColumnType("decimal(10,2)");
            entity.Property(e => e.ShippingDetails).HasMaxLength(500);

            entity.HasOne(e => e.User)
                  .WithMany(u => u.Orders)
                  .HasForeignKey(e => e.UserId);

            entity.HasMany(e => e.OrderProducts)
                  .WithOne(op => op.Order)
                  .HasForeignKey(op => op.OrderId);
        });

        modelBuilder.Entity<OrderProduct>(entity =>
        {
            entity.HasKey(op => new { op.OrderId, op.ProductId });
            entity.HasOne(op => op.Order)
                  .WithMany(o => o.OrderProducts)
                  .HasForeignKey(op => op.OrderId);

            entity.HasOne(op => op.Product)
                  .WithMany(p => p.OrderProducts)
                  .HasForeignKey(op => op.ProductId);
        });

        modelBuilder.Entity<CartProduct>(entity =>
        {
            entity.HasKey(cp => new { cp.CartId, cp.ProductId });
            entity.HasOne(cp => cp.Cart)
                  .WithMany(c => c.CartProducts)
                  .HasForeignKey(cp => cp.CartId);

            entity.HasOne(cp => cp.Product)
                  .WithMany(p => p.CartProducts)
                  .HasForeignKey(cp => cp.ProductId);
        });
        }
    }

}
