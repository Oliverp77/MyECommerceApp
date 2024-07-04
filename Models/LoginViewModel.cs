using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MyECommerceApp.Models
{

    public class LoginViewModel
    {
        [Required]
        [EmailAddress]
        public required string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public required string Password { get; set; }
    }

}