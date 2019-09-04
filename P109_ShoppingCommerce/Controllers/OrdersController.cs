using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using P109_ShoppingCommerce.Models;

namespace P109_ShoppingCommerce.Controllers
{
    public class OrdersController : Controller
    {
        private readonly ECommerceEntities _context;

        public OrdersController()
        {
            _context = new ECommerceEntities();
        }

        // GET: Orders
        public ActionResult AddToBasket(int? id)
        {
            if (id == null) return HttpNotFound();

            Product product = _context.Products.Find(id);

            if (product == null) return HttpNotFound();


            var basket = Session["basket"] as List<BasketProduct>;

            if (basket == null)
                basket = new List<BasketProduct>();

            basket.Add(new BasketProduct
            {
                Product = product,
                Count = 1
            });

            Session["basket"] = basket;

            return RedirectToAction("Details", "Products", new { id });
        }

        public ActionResult RemoveFromBasket(int? id)
        {
            if (id == null) return HttpNotFound();

            Product product = _context.Products.Find(id);

            if (product == null) return HttpNotFound();

            var basket = Session["basket"] as List<BasketProduct>;

            for (int i = 0; i < basket.Count; i++)
            {
                if(basket[i].Product.Id == id)
                {
                    basket.Remove(basket[i]);
                    break;
                }
            }

            Session["basket"] = basket;

            return RedirectToAction("Details", "Products", new { id });
        }

    }
}