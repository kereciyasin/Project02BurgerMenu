using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Project02BurgerMenu.Content;
using Project02BurgerMenu.Entities;
using PagedList;
using PagedList.Mvc;

namespace Project02BurgerMenu.Areas.Admin.Controllers
{
    public class ReservationController : Controller
    {
        BurgerMenu01Context context = new BurgerMenu01Context();
        public ActionResult ReservationList(int page = 1)
        {
            var values = context.Reservations.ToList().ToPagedList(page, 5);   
            return View(values);
        }
    }
}