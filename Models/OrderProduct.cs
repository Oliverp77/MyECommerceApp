using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyECommerceApp.Models
{
    public class OrderProduct
    {
    [Key]
    [Column(Order = 0)]
    public int OrderId { get; set; }

    [Key]
    [Column(Order = 1)]
    public int ProductId { get; set; }

    public Order Order { get; set; }
    public Product Product { get; set; }
    }
}
