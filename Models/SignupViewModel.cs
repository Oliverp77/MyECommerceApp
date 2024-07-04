using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MyECommerceApp.Models
{

    public class SignupViewModel
    {
        [Required]
        [StringLength(50)]
        public required string name { get; set; }

        [Required]
        [EmailAddress]
        public required string email { get; set; }

        [Required]
        [StringLength(100)]
        [DataType(DataType.Password)]
        public required string password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Compare("password")]
        public required string ConfirmPassword { get; set; }
    }

}