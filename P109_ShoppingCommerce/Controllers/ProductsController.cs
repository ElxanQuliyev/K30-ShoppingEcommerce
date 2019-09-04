using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using P109_ShoppingCommerce.Models;
using P109_ShoppingCommerce.ViewModels;

namespace P109_ShoppingCommerce.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ECommerceEntities _context;

        public ProductsController()
        {
            _context = new ECommerceEntities();
        }
        // GET: Products
        public ActionResult Details(int? id)
        {
            if (id == null) return HttpNotFound();

            Product product = _context.Products.Find(id);

            if(product == null) return HttpNotFound();

            var vm = new ProductDetailVM
            {
                Product = product,
                RelatedProducts = _context.Products.Where(c => c.CategoryId == product.CategoryId)
            };

            return View(vm);
        }
    }
}