using Project02BurgerMenu.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Project02BurgerMenu.Entities;


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

        public ActionResult DeleteCategory(int id)
        {
            var values = db.Categories.Find(id);
            db.Categories.Remove(values);
            db.SaveChanges();
            return RedirectToAction("CategoryList");
        }

        [HttpGet]
        public ActionResult AddCategory()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddCategory(Category category)
        {
            db.Categories.Add(category);
            db.SaveChanges();
            return RedirectToAction("CategoryList");
        }
    }
}