using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MyECommerceApp.Models
{
    public class User
    {
        public int UserId { get; set; }
        [Required]
        [StringLength(50)]
        public string UserName { get; set; }
        [Required]
        [EmailAddress]
        public string UserEmail { get; set; }
        [Required]
        [StringLength(100)]
        [DataType(DataType.Password)]
        public  string Password { get; set; }

        public User() { }

        public User(int userId, string userName, string userEmail, string password) {
            UserId = userId;
            UserName = userName;
            UserEmail = userEmail;
            Password = password;
        }
    }
}