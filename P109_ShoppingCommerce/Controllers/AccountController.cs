using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using P109_ShoppingCommerce.Models;
using System.Web.Helpers;
using System.Threading.Tasks;

namespace P109_ShoppingCommerce.Controllers
{
    public class AccountController : Controller
    {
        private readonly ECommerceEntities _context;

        public AccountController()
        {
            _context = new ECommerceEntities();
        }
        // GET: Account
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Register(ApplicationUser user)
        {
            if (!ModelState.IsValid) return View(user);

            if(_context.ApplicationUsers.Any(u => u.Email == user.Email))
            {
                ModelState.AddModelError("Email", "This email is duplicate");
                return View(user);
            }

            if (_context.ApplicationUsers.Any(u => u.Username == user.Username))
            {
                ModelState.AddModelError("Email", "This username is duplicate");
                return View(user);
            }

            user.Password = user.ConfirmPassword = Crypto.HashPassword(user.Password);

            _context.ApplicationUsers.Add(user);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Login));
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(UserLogin loginUser)
        {
            if (!ModelState.IsValid) return View(loginUser);

            ApplicationUser appUser = _context.ApplicationUsers.FirstOrDefault(u => u.Email == loginUser.Email);

            if(appUser == null)
            {
                ModelState.AddModelError("summary", "Email or password is invalid");
                return View(loginUser);
            }

            if(!Crypto.VerifyHashedPassword(appUser.Password, loginUser.Password))
            {
                ModelState.AddModelError("summary", "Email or password is invalid");
                return View(loginUser);
            }

            Session["user"] = appUser;

            return RedirectToAction("Index", "Home");
        }

        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Index", "Home");
        }
    }
}