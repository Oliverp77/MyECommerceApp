using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyECommerceApp.Models
{
    public class Product
    {
        [Key]
        [Column("product_id")]
        public int ProductId { get; set; }

        [Required]
        [StringLength(100)]
        [Column("name")]
        public string Name { get; set; }

        [StringLength(500)]
        [Column("description")]
        public string? Description { get; set; }

        [Required]
        [Column("price")]
        public decimal Price { get; set; }
        
        [StringLength(100)]
        [Column("category")]
        public string? Category { get; set; }

        public ICollection<OrderProduct> OrderProducts { get; set; }
        public ICollection<CartProduct> CartProducts { get; set; }

        public Product() 
        {
            OrderProducts = new List<OrderProduct>();
            CartProducts = new List<CartProduct>();
        }

        public Product(string productname, string description, decimal price, string category, List<OrderProduct> orderProducts, List<CartProduct> cartProducts) {
            Name = productname;
            Description = description;
            Price = price;
            Category = category;
            OrderProducts = orderProducts ?? new List<OrderProduct>();
            CartProducts = cartProducts ?? new List<CartProduct>();
        }
    }
}