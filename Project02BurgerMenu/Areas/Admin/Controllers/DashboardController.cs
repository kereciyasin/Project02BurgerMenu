using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Project02BurgerMenu.Entities;
using Project02BurgerMenu.Content;

namespace Project02BurgerMenu.Areas.Admin.Controllers
{
    public class DashboardController : Controller
    {
        BurgerMenu01Context db = new BurgerMenu01Context();
        public ActionResult Index()
        {
            ViewBag.datetime = DateTime.Now.ToString("dd/MM/yyyy");
            ViewBag.products = db.Products.Count();
            ViewBag.reservations = db.Reservations.Count(); 
            ViewBag.admins = db.Admins.Count();
            ViewBag.testimonials = db.Testimonials.Count(); 
            ViewBag.productNames = db.Products.Select(x => x.ProductName).ToList();
            ViewBag.productPrices = db.Products.Select(x => x.ProductPrice).ToList();
            ViewBag.productCategories = db.Products.Select(x => x.Category.CategoryName).ToList();

            Random rnd = new Random();
            List<int> ints = new List<int>();
            for (int i = 0; i < ViewBag.productNames.Count; i++)
            {
                int randomProg = rnd.Next(0, 101);
                ints.Add(randomProg);
                
            }
            ViewBag.ints = ints;
            return View();
        }
    }
}