using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Project02BurgerMenu.Entities;
using Project02BurgerMenu.Content;

namespace Project02BurgerMenu.Areas.Admin.Controllers
{
    [Authorize]
    public class MessageController : Controller
    {
        BurgerMenu01Context db = new BurgerMenu01Context();
        public ActionResult InBox()
        {
            var userName = Session["x"];
            var email = db.Admins.Where(x => x.Username == userName).Select(x => x.Email).FirstOrDefault();
            var messages = db.Messages.Where(x => x.ReceiverEmail == email).ToList();
            return View(messages);
        }
        public ActionResult SendBox()
        {
            var userName = Session["x"];
            var email = db.Admins.Where(x => x.Username == userName).Select(x => x.Email).FirstOrDefault();
            var messages = db.Messages.Where(x => x.SenderEmail == email).ToList();
            return View(messages);
        }
        public PartialViewResult PartialMessageDetail(int id)
        {
            var message = db.Messages.Find(id);
            return PartialView(message);
        }
        [HttpGet]
        public ActionResult NewMessage()
        {
            return View();
        }
        [HttpPost]
        public ActionResult NewMessage(Message message)
        {
            var userName = Session["x"];
            var email = db.Admins.Where(x => x.Username == userName).Select(x => x.Email).FirstOrDefault();
            message.SenderEmail = email;
            message.IsRead = false;
            message.SendDate = DateTime.Now;
            db.Messages.Add(message);
            db.SaveChanges();
            return RedirectToAction("SendBox","Message", new { area = "Admin" });
        }
    }
}