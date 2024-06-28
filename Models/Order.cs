using System;
using System.Collections.Generic;

namespace MyECommerceApp.Models
{
    public class Order
    {
        public int Order_Id { get; set; }
        public string? User_Id { get; set; }
        public float Total { get; set; }
        public string? Shipping_Details { get; set; }

        public Order(int order_Id, string? user_Id, float total, string? shipping_Details) {
            Order_Id = order_Id;
            User_Id = user_Id;
            Total = total;
            Shipping_Details = shipping_Details;
        }
    }
}