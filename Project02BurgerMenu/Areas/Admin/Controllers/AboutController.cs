using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Project02BurgerMenu.Entities;
using Project02BurgerMenu.Content;

namespace Project02BurgerMenu.Areas.Admin.Controllers
{
    public class AboutController : Controller
    {
        BurgerMenu01Context db = new BurgerMenu01Context();
        public ActionResult Index()
        {
            var values = db.Abouts.ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult AddAbout()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddAbout(About p)
        {
            db.Abouts.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DeleteAbout(int id)
        {
            var about = db.Abouts.Find(id);
            db.Abouts.Remove(about);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult UpdateAbout(int id)
        {
            var about = db.Abouts.Find(id);
            return View(about);
        }
        [HttpPost]
        public ActionResult UpdateAbout(About about)
        {
            var values = db.Abouts.Find(about.AboutId);
            values.AboutTitle = about.AboutTitle;
            values.AboutDescription = about.AboutDescription;
            values.Title = about.Title;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}