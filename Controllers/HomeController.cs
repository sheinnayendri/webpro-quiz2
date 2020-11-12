﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace webpro_quiz2.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            if (Session["user_id"] != null)
            {
                return RedirectToAction("Dashboard", "User", new { area = "" });
            }
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}