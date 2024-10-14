using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyECommerceApp.Models
{
    public class CartProduct
    {
    [Key]
    [Column(Order = 0)]
    public int CartId { get; set; }

    [Key]
    [Column(Order = 1)]
    public int ProductId { get; set; }

    public Cart Cart { get; set; }
    public Product Product { get; set; }

    public int Quantity { get; set; }
    }
}