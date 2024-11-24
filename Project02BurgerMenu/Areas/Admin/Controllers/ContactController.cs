using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Project02BurgerMenu.Entities;
using Project02BurgerMenu.Content;

namespace Project02BurgerMenu.Areas.Admin.Controllers
{
    public class ContactController : Controller
    {
        BurgerMenu01Context context = new BurgerMenu01Context();    
        public ActionResult Inbox()
        {
            var values = context.Contacts.ToList(); 
            return View(values);
        }
    }
}