using Project02BurgerMenu.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project02BurgerMenu.Areas.Admin.Controllers
{
    public class DashboardController : Controller
    {
        BurgerMenu01Context context = new BurgerMenu01Context();
        public ActionResult Index()
        {
            ViewBag.datetime = DateTime.Now.ToString("dd/MM/yyyy");
            ViewBag.products = context.Products.Count();
            ViewBag.reservations = context.Reservations.Count();
            ViewBag.admins = context.Admins.Count();
            ViewBag.testimonials = context.Contacts.Count();
            ViewBag.productNames = context.Products.Select(p => p.ProductName).ToList();
            ViewBag.productPrices = context.Products.Select(p => p.ProductPrice).ToList();
            ViewBag.productCategory = context.Products.Select(p => p.Category.CategoryName).ToList();

            // Progress için rastgele değerler oluşturma
            Random random = new Random();
            List<int> progressValues = new List<int>();

            for (int i = 0; i < ViewBag.productNames.Count; i++)
            {
                int randomProgress = random.Next(0, 101); // 0 ile 100 arasında rastgele bir sayı oluştur
                progressValues.Add(randomProgress);
            }

            ViewBag.productProgress = progressValues;

            return View();
        }
    }
}