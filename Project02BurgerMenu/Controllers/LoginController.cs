using Project02BurgerMenu.Content;
using Project02BurgerMenu.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Project02BurgerMenu.Controllers
{
    public class LoginController : Controller
    {
        BurgerMenu01Context db = new BurgerMenu01Context();
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(Admin user)
        {
            var userInfo = db.Admins.FirstOrDefault(x => x.Username == user.Username && x.Password == user.Password);
            if (userInfo != null)
            {
                FormsAuthentication.SetAuthCookie(userInfo.Username, false);
                Session["x"] = userInfo.Username.ToString();
                return RedirectToAction("ProductList", "Product", "Admin");
            }
            else
            {
                return View();
            }
        }
    }
}