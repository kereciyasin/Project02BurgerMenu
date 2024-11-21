using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Project02BurgerMenu.Entities;
using Project02BurgerMenu.Content;

namespace Project02BurgerMenu.Controllers
{
    public class RegisterController : Controller
    {
        BurgerMenu01Context db = new BurgerMenu01Context();
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(Admin admin)
        {
            db.Admins.Add(admin);
            db.SaveChanges();
            return RedirectToAction("Index", "Login");
        }
    }
}