using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using P109_ShoppingCommerce.Models;

namespace P109_ShoppingCommerce.ViewModels
{
    public class HomeIndexVM
    {
        public IEnumerable<Product> Products { get; set; }
        public IEnumerable<Category> TopCategories { get; set; }
    }
}