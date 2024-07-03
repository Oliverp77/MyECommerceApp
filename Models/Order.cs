using System;
using System.Collections.Generic;

namespace MyECommerceApp.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public string? UserId { get; set; }
        public decimal Total { get; set; }
        public string? ShippingDetails { get; set; }
        public List<Product> Products { get; set; }

        public Order() 
        {
            Products = new List<Product>();
        }

        public Order(int orderId, string? userId, decimal total, string? shippingDetails, List<Product> products) {
            OrderId = orderId;
            UserId = userId;
            Total = total;
            ShippingDetails = shippingDetails;
            Products = products;
        }
    }
}