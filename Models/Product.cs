using System;
using System.Collections.Generic;

namespace MyECommerceApp.Models
{
    public class Product
    {
        public int Product_Id { get; set; }
        public required string Productname { get; set; }
        public string? Description { get; set; }
        public float Price { get; set; }
        public string? Category { get; set; }

        public Product(int product_Id, string productname, string description, float price, string category) {
            Product_Id = product_Id;
            Productname = productname;
            Description = description;
            Price = price;
            Category = category;
        }
    }
}