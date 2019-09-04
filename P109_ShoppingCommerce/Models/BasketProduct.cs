using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace P109_ShoppingCommerce.Models
{
    public class BasketProduct
    {
        public Product Product { get; set; }
        public int Count { get; set; }
    }
}