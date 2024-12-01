﻿using Project02BurgerMenu.Content;
using Project02BurgerMenu.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project02BurgerMenu.Controllers
{
    public class DefaultController : Controller
    {
        BurgerMenu01Context context = new BurgerMenu01Context();
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(Contact contact)
        {
            contact.SendDate = DateTime.Now;
            contact.IsRead = false;
            context.Contacts.Add(contact);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public PartialViewResult PartialHead()
        {
            return PartialView();
        }
        public PartialViewResult PartialNavbar()
        {
            return PartialView();
        }
        public PartialViewResult PartialAbout()
        {
            var values = context.Abouts.ToList();
            return PartialView(values);
        }
        public PartialViewResult PartialContact()
        {
            var values = context.Abouts.ToList();
            return PartialView(values);
        }
        public PartialViewResult PartialLocation()
        {
            ViewBag.mapLocation = context.Abouts.Select(x => x.MapLocation).FirstOrDefault();
            return PartialView();
        }
        public PartialViewResult PartialTodaysOffer()
        {
            var values = context.Products.Where(x => x.DealofTheDay == true).ToList();
            return PartialView(values);
        }
        public PartialViewResult PartialMenu()
        {
            var values = context.Products.ToList();
            return PartialView("PartialMenu", values);
        }
        public PartialViewResult PartialCategory()
        {
            var values = context.Categories.Take(6).ToList();
            return PartialView("PartialCategory", values);
        }
        public PartialViewResult PartialGallery()
        {
            var values = context.Products.Take(6).ToList(); 
            return PartialView(values); 
        }
        public PartialViewResult PartialFooter()
        {
            return PartialView();
        }   
    }
}