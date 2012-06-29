﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Monty.UI.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Navigate(string navigate)
        {
            if (navigate == "Pay Periods")
                return RedirectToAction("Index","PayPeriod");
            return Index();
        }
    }
}