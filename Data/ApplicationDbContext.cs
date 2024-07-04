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

        public DbSet<Product> Product { get; set;}
        public DbSet<User> User { get; set;}
        public DbSet<Order> Order { get; set;}

         protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Product>(entity =>
            {
                entity.Property(e => e.Price).HasColumnType("decimal(10,2)");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.Property(e => e.Total).HasColumnType("decimal(10,2)");
            });

             modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.user_id);
            entity.Property(e => e.user_id).ValueGeneratedOnAdd(); // This ensures auto-increment
            entity.Property(e => e.name).IsRequired().HasMaxLength(50);
            entity.Property(e => e.email).IsRequired().HasMaxLength(100);
            entity.Property(e => e.password).IsRequired().HasMaxLength(100);
        });
        }
    }

}
