using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Project02BurgerMenu.Content;
using Project02BurgerMenu.Entities;
using PagedList;
using PagedList.Mvc;

namespace Project02BurgerMenu.Areas.Admin.Controllers
{
    public class ReservationController : Controller
    {
        BurgerMenu01Context context = new BurgerMenu01Context();
        public ActionResult ReservationList(int page = 1)
        {
            var values = context.Reservations.ToList().ToPagedList(page, 5);   
            return View(values);
        }
        [HttpGet]
        public ActionResult DetailReservation(int id)
        {
            var values = context.Reservations.Where(x => x.ReservationId == id).FirstOrDefault();
            return View(values);
        }
        [HttpPost]
        public ActionResult DetailReservation(Reservation r)
        {
            var values = context.Reservations.Find(r.ReservationId);    
            values.ReservationId = r.ReservationId;
            values.Name = r.Name;
            values.Surname = r.Surname;
            values.Email = r.Email;
            values.Phone = r.Phone;
            values.ReservationDate = r.ReservationDate;
            values.Time = r.Time;
            values.PeopleCount = r.PeopleCount; 
            values.Message = r.Message;
            context.SaveChanges();
            return RedirectToAction("ReservationList");
        }
        public ActionResult DeleteReservation(int id)
        {
            var values = context.Reservations.Find(id);
            context.Reservations.Remove(values);
            context.SaveChanges();
            return RedirectToAction("ReservationList");
        }
        public ActionResult StatusChangeToConfirm(int id) 
        {
            var values = context.Reservations.Where(x => x.ReservationId == id).FirstOrDefault();
            values.ReservationStatus = "Onaylandi";
            context.SaveChanges();
            return RedirectToAction("ReservationList");

        }
        public ActionResult StatusChangeToCancel(int id)
        {
            var values = context.Reservations.Where(x => x.ReservationId == id).FirstOrDefault();
            values.ReservationStatus = "Iptal Edildi";
            context.SaveChanges();
            return RedirectToAction("ReservationList");
        }
        public ActionResult StatusChangeToWaiting(int id)
        {
            var values = context.Reservations.Where(x => x.ReservationId == id).FirstOrDefault();
            values.ReservationStatus = "Beklemede";
            context.SaveChanges();
            return RedirectToAction("ReservationList");
        }
        public ActionResult StatusChangeToCome(int id)
        {
            var values = context.Reservations.Where(x => x.ReservationId == id).FirstOrDefault();
            values.ReservationStatus = "Müsteri Gelmedi";
            context.SaveChanges();
            return RedirectToAction("ReservationList");
        }
    }
}