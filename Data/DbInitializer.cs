using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using MyECommerceApp.Models;

namespace MyECommerceApp.Data
{
    public static class DbInitializer
    {
        public static void Initialize(ApplicationDbContext context)
        {
            context.Database.EnsureCreated();

            // Look for any products.
            if (context.Products.Any())
            {
                return;   // DB has been seeded
            }

            var products = new Product[]
            {
                new Product{Productname="Product1",Description="Description1",Price=9.99M},
                new Product{Productname="Product2",Description="Description2",Price=19.99M},
                new Product{Productname="Product3",Description="Description3",Price=29.99M}
            };

            foreach (var p in products)
            {
                context.Products.Add(p);
            }
            context.SaveChanges();
        }
    }
}
