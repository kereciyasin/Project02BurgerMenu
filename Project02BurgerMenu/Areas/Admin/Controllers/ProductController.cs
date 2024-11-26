using Project02BurgerMenu.Content;
using Project02BurgerMenu.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;


namespace Project02BurgerMenu.Areas.Admin.Controllers
{
    [Authorize]
    public class ProductController : Controller
    {
        BurgerMenu01Context db = new BurgerMenu01Context();
        public ActionResult ProductList(int page = 1)
        {
            var productList = db.Products.ToList().ToPagedList(page, 10);
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
            var value = db.Products.Find(id);
            List<SelectListItem> values = (from x in db.Categories.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.CategoryName,
                                               Value = x.CategoryId.ToString()
                                           }).ToList();
            ViewBag.v1 = values;
            return View(value);
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

        //categoryproducts
        public ActionResult CategoryProduct(int id)
        {
            var values = db.Products.Where(x => x.CategoryId == id).ToList();
            return View(values);
        }
        public ActionResult DealofTheDayChangeToTrue(int id)
        {
            var values = db.Products.Where(x => x.ProductId == id).FirstOrDefault();
            values.DealofTheDay = true;
            db.SaveChanges();
            return RedirectToAction("ProductList");
        }
        public ActionResult DealofTheDayChangeToFalse(int id)
        {
            var values = db.Products.Where(x => x.ProductId == id).FirstOrDefault();
            values.DealofTheDay = false;
            db.SaveChanges();
            return RedirectToAction("ProductList");
        }

    }
}