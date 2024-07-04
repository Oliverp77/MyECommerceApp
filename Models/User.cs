using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MyECommerceApp.Models
{
    public class User
    {
        [Key]
        public int user_id { get; set; }

        [Required]
        [StringLength(50)]
        public string name { get; set; }

        [Required]
        [EmailAddress]
        public string email { get; set; }
        
        [Required]
        [StringLength(100)]
        [DataType(DataType.Password)]
        public  string password { get; set; }

        public User() { }

        public User(int User_id, string Name, string Email, string Password) {
            user_id = User_id;
            name = Name;
            email = Email;
            password = Password;
        }
    }
}