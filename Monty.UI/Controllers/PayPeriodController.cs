using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Monty.DAL;

namespace Monty.UI.Controllers
{
    public class PayPeriodController : Controller
    {
        //
        // GET: /PayPeriod/

        public ActionResult New()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Navigate(string navigate)
        {
            if (navigate == "New Pay Period")
                return RedirectToAction("New", "PayPeriod");
            if (navigate == "Save")
            {
                return RedirectToAction("New", "PayPeriod");
            }
            return Index();
        }

        public ActionResult Index()
        {
            return View();
        }
    }
}
