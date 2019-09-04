using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using P109_ShoppingCommerce.Models;
using P109_ShoppingCommerce.ViewModels;

namespace P109_ShoppingCommerce.Controllers
{
    public class HomeController : Controller
    {
        private readonly ECommerceEntities _context;

        public HomeController()
        {
            _context = new ECommerceEntities();
        }

        public ActionResult Index(int? cid)
        {
            //var products = _context.Products.ToList();
            //if(cid != null)
            //{
            //    products = products.Where(p => p.CategoryId == (int)cid).ToList();
            //}

            var vm = new HomeIndexVM
            {
                Products = _context.Products.Where(c => c.CategoryId == (cid != null ? cid : c.CategoryId)),
                TopCategories = _context.Categories.OrderByDescending(c => c.Products.Count).Take(5).ToList()
            };

            return View(vm);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}