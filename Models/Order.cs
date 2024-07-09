using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyECommerceApp.Models
{
    public class Order
    {
        [Key]
        [Column("order_id")]
        public int OrderId { get; set; }

        [Column("user_id")]
        public int UserId { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; }

        [Required]
        [Column("total")]
        public decimal Total { get; set; }

        [Column("shipping_details")]
        public string? ShippingDetails { get; set; }

        public ICollection<OrderProduct> OrderProducts { get; set; }
        public Order() 
        {
            OrderProducts = new List<OrderProduct>();
        }

        public Order(int orderId, int userId, decimal total, string? shippingDetails, List<OrderProduct> orderProducts) {
            OrderId = orderId;
            UserId = userId;
            Total = total;
            ShippingDetails = shippingDetails;
            OrderProducts = orderProducts ?? new List<OrderProduct>();
        }
    }
}