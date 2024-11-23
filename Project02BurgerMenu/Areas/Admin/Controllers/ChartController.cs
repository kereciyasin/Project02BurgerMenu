using Project02BurgerMenu.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Project02BurgerMenu.Entities;

namespace Project02BurgerMenu.Areas.Admin.Controllers
{
    public class ChartController : Controller
    {
        BurgerMenu01Context db = new BurgerMenu01Context();
        public ActionResult ProductStockChart()
        {
            return View();
        }
        public ActionResult CategoryProductChart()
        {
            var data = db.Categories
                .Where(x => x.Products.Count > 0)
                .Select(x => new
                {
                    CategoryName = x.CategoryName,
                    ProductCount = x.Products.Count
                }).ToList();
            return Json(data, JsonRequestBehavior.AllowGet);
        }
        public ActionResult MessageDateChart()
        { return View(); }
        public ActionResult MessageChart()
        {
            var data = db.Messages
                .GroupBy(x => x.SenderEmail)
                .Select(x => new
                {
                    MessageDate = x.Key,
                    MessageCount = x.Count()
                }).ToList();
            return Json(data, JsonRequestBehavior.AllowGet);
        }
        public ActionResult ReservationChar()
        {
            var data = db.Reservations
                .GroupBy(x => x.ReservationDate)
                .Select(x => new
                {
                    ReservationDate = x.Key,
                    ReservationCount = x.Count()
                }).ToList();
            return Json(data, JsonRequestBehavior.AllowGet);
        }
        public ActionResult DealofTheDaysChart()
        {
            return View();  
        }

        public ActionResult DealofTheDaysCategory()
        {
            var data = db.Products
                .Where(y=> y.DealofTheDay == true).GroupBy(c=>c.Category.CategoryName)
                .Select(x => new
                {
                    DealName = x.Key,
                    DealCategory = x.Count()
                }).ToList();
            return Json(data, JsonRequestBehavior.AllowGet);
        }
    }
}