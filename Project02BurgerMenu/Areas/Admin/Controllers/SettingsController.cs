﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project02BurgerMenu.Areas.Admin.Controllers
{
    public class SettingsController : Controller
    {
        // GET: Admin/Settings
        public ActionResult Index()
        {
            return View();
        }
    }
}