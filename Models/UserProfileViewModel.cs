using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyECommerceApp.Models
{
    public class UserProfileViewModel
    {
        public int UserId { get; set; }
        public string CurrentName { get; set; }
        public string CurrentEmail { get; set; }

        [StringLength(50)]
        public string NewName { get; set; }
        [EmailAddress]
        public string NewEmail { get; set; }

        [StringLength(100, MinimumLength = 8)]
        [DataType(DataType.Password)]
        public string NewPassword { get; set; }
        
        [Required(ErrorMessage = "Current Password is required to change the password.")]
        [DataType(DataType.Password)]
        public string CurrentPassword { get; set; }
    }
}