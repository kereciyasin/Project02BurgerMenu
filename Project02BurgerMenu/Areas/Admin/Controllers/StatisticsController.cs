using Project02BurgerMenu.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Project02BurgerMenu.Entities; 
using Project02BurgerMenu.Content;

namespace Project02BurgerMenu.Areas.Admin.Controllers
{
    public class StatisticsController : Controller
    {
        BurgerMenu01Context context = new BurgerMenu01Context();
        public ActionResult Index()
        {
            ViewBag.products = context.Products.Count();
            ViewBag.reservations = context.Reservations.Count();
            ViewBag.admins = context.Admins.Count();
            ViewBag.testimonials = context.Contacts.Count();
            ViewBag.deals = context.Products.Where(x => x.DealofTheDay == true).Select(y => y.ProductName).Count();
            ViewBag.canceledReservations = context.Reservations.Where(x => x.ReservationStatus == "İptal Edildi").Count();
            ViewBag.categories = context.Categories.Count();
            ViewBag.mainDishes = context.Products.Where(x => x.CategoryId == 1).Count();
            ViewBag.subscribes = context.Subscribes.Count();
            ViewBag.avgPrice = context.Products.Select(x => x.ProductPrice).Average();
            ViewBag.maxPrice = context.Products.Select(x => x.ProductPrice).Max();
            ViewBag.lastReserve = context.Reservations.OrderByDescending(x => x.ReservationId).Select(x => x.Time).FirstOrDefault();
            return View();
        }
    }
}