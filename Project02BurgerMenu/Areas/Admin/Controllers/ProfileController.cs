using Project02BurgerMenu.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Project02BurgerMenu.Entities;

namespace Project02BurgerMenu.Areas.Admin.Controllers
{
    [Authorize]
    public class ProfileController : Controller
    {
        BurgerMenu01Context context = new BurgerMenu01Context();
        [HttpGet]
        public ActionResult MyProfileList()
        {
            var userName = Session["x"];
            var values = context.Admins.Where(x => x.Username == userName).FirstOrDefault();
            return View(values);
        }
        [HttpPost]
        public ActionResult MyProfileList(Project02BurgerMenu.Entities.Admin admin)
        {
            var userName = Session["x"];
            var x = context.Admins.Where(y => y.Username == userName).FirstOrDefault();
            x.Name = admin.Name;
            x.Surname = admin.Surname;
            x.Password = admin.Password;
            x.Username = admin.Username;
            x.Email = admin.Email;
            context.SaveChanges();
            return RedirectToAction("Index", "Login");
        }
    }
}