using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyECommerceApp.Models
{
    public class Cart
    {
        [Key]
        [Column("cart_id")]
        public int CartId { get; set; }

        [Column("user_id")]
        public int UserId { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; }
        public ICollection<CartProduct> CartProducts { get; set; }

        public Cart() 
        {
            CartProducts = new List<CartProduct>();
        }

        public Cart(int cartId, int userId, List<CartProduct> cartProducts) 
        {
            CartId = cartId;
            UserId = userId;
            CartProducts = cartProducts ?? new List<CartProduct>();

        }
    }
}