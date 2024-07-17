using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyECommerceApp.Models
{
    public class User
    {
        [Key]
        [Column("user_id")]
        public int UserId { get; set; }

        [Required]
        [StringLength(50)]
        [Column("name")]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        [Column("email")]
        public string Email { get; set; }
        
        [Required]
        [StringLength(100)]
        [DataType(DataType.Password)]
        [Column("password")]
        public  string Password { get; set; }

        public ICollection<Order> Orders { get; set; }
        public ICollection<Cart> Carts { get; set; }
        public User() { }

        public User(string name, string email, string password, List<Order> orders, List<Cart> carts) {
            Name = name;
            Email = email;
            Password = password;
            Orders = orders ?? new List<Order>();
            Carts = carts ?? new List<Cart>();
        }
    }
}