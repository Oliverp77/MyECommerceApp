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

        public DbSet<Product> Products { get; set;}
        public DbSet<User> Users { get; set;}
        public DbSet<Order> Orders { get; set;}

    }

}
