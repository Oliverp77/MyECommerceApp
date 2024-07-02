using System;
using System.Collections.Generic;

namespace MyECommerceApp.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public string? UserId { get; set; }
        public decimal Total { get; set; }
        public string? Shipping_Details { get; set; }

        public Order() {}

        public Order(int orderId, string? userId, decimal total, string? shipping_Details) {
            OrderId = orderId;
            UserId = userId;
            Total = total;
            Shipping_Details = shipping_Details;
        }
    }
}