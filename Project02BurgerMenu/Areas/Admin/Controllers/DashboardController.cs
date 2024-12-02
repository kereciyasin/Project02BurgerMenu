using Project02BurgerMenu.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project02BurgerMenu.Areas.Admin.Controllers
{
    public class DashboardController : Controller
    {
        // Instance of the database context
        private BurgerMenu01Context context = new BurgerMenu01Context();

        // GET: Admin/Dashboard
        public ActionResult Index()
        {
            // ViewBag to pass data to the View
            SetDashboardData();

            return View();
        }

        // Method to set the dashboard data for the view
        private void SetDashboardData()
        {
            // Current date
            ViewBag.datetime = DateTime.Now.ToString("dd/MM/yyyy");

            // Counts of products, reservations, admins, and testimonials
            ViewBag.products = context.Products.Count();
            ViewBag.reservations = context.Reservations.Count();
            ViewBag.admins = context.Admins.Count();
            ViewBag.testimonials = context.Contacts.Count();

            // Product details: Names, Prices, and Categories
            ViewBag.productNames = context.Products.Select(p => p.ProductName).ToList();
            ViewBag.productPrices = context.Products.Select(p => p.ProductPrice).ToList();
            ViewBag.productCategory = context.Products.Select(p => p.Category.CategoryName).ToList();

            // Generate random progress values for each product
            ViewBag.productProgress = GenerateRandomProgress(ViewBag.productNames.Count);
        }

        // Method to generate random progress values
        private List<int> GenerateRandomProgress(int count)
        {
            Random random = new Random();
            List<int> progressValues = new List<int>();

            for (int i = 0; i < count; i++)
            {
                progressValues.Add(random.Next(0, 101)); // Random value between 0 and 100
            }

            return progressValues;
        }
    }
}
