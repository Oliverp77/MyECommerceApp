using System;
using System.Collections.Generic;

namespace MyECommerceApp.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public required string Productname { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public string? Category { get; set; }

        public Product() { }

        public Product(int productId, string productname, string description, decimal price, string category) {
            ProductId = productId;
            Productname = productname;
            Description = description;
            Price = price;
            Category = category;
        }
    }
}