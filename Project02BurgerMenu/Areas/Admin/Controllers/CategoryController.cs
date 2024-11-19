using Project02BurgerMenu.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project02BurgerMenu.Areas.Admin.Controllers
{
    public class CategoryController : Controller
    {
        BurgerMenu01Context db = new BurgerMenu01Context();
        public ActionResult CategoryList()
        {
            var categoryList = db.Categories.ToList();
            return View(categoryList);
        }
    }
}