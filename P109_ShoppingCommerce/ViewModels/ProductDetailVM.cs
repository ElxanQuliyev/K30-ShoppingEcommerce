using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using P109_ShoppingCommerce.Models;

namespace P109_ShoppingCommerce.ViewModels
{
    public class ProductDetailVM
    {
        public Product Product { get; set; }
        public IEnumerable<Product> RelatedProducts { get; set; }
    }
}