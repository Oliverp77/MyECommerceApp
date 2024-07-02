using System;
using System.Collections.Generic;

namespace MyECommerceApp.Models
{
    public class User
    {
        public int UserId { get; set; }
        public required string UserName { get; set; }
        public required string UserEmail { get; set; }
        public required string Password { get; set; }

        public User() { }

        public User(int user_Id, string userName, string userEmail, string password) {
            UserId = user_Id;
            UserName = userName;
            UserEmail = userEmail;
            Password = password;
        }
    }
}