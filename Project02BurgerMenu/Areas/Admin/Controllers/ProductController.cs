using Project02BurgerMenu.Content;
using Project02BurgerMenu.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project02BurgerMenu.Areas.Admin.Controllers
{
    public class ProductController : Controller
    {
        BurgerMenu01Context db = new BurgerMenu01Context();
        public ActionResult ProductList()
        {
            var productList = db.Products.ToList();
            return View(productList);
        }
        [HttpGet]
        public ActionResult CreateProduct()
        {
            List<SelectListItem> values = (from x in db.Categories.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.CategoryName,
                                               Value = x.CategoryId.ToString()
                                           }).ToList();
            ViewBag.v1 = values;
            return View();
        }
        [HttpPost]
        public ActionResult CreateProduct(Product product)
        {
            db.Products.Add(product);
            db.SaveChanges();
            return RedirectToAction("ProductList");
        }

        public ActionResult DeleteProduct(int id)
        {
            var product = db.Products.Find(id);
            db.Products.Remove(product);
            db.SaveChanges();
            return RedirectToAction("ProductList");
        }

        [HttpGet]
        public ActionResult UpdateProduct(int id)
        {
            var product = db.Products.Find(id);
            List<SelectListItem> values = (from x in db.Categories.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.CategoryName,
                                               Value = x.CategoryId.ToString()
                                           }).ToList();
            ViewBag.v1 = values;
            return View("EditProduct", product);
        }
        [HttpPost]
        public ActionResult UpdateProduct(Product product)
        {
            var p = db.Products.Find(product.ProductId);
            p.ProductName = product.ProductName;
            p.ProductPrice = product.ProductPrice;
            p.ProductDescription = product.ProductDescription;
            p.ImageUrl = product.ImageUrl;
            p.CategoryId = product.CategoryId;
            db.SaveChanges();
            return RedirectToAction("ProductList");
        }

    }
}