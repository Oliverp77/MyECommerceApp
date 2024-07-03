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
        }
    }

}
