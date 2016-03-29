﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ModelValidation.Models;
using NLog;

namespace ModelValidation.Controllers
{
    public class HomeController : Controller
    {
        private readonly Logger _nLogger = LogManager.GetCurrentClassLogger();
        public ViewResult MakeBooking()
        {
            return View(new Appointment {Date = DateTime.Now});
        }
        [HttpPost]
        public ViewResult MakeBooking(Appointment appt)
        {
            if (ModelState.IsValid) //Server 端驗證
            {
                _nLogger.Debug($"ModelState.IsValid = {ModelState.IsValid}");
                return View("Completed", appt);
            }
            else
            {
                return View();
            }
            //return View("Completed", appt);
        }
        public ActionResult Index()
        {
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