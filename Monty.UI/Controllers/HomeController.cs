using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Monty.Model.DAL;

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

        public PartialViewResult Edit(string type, string id)
        {
            if (type == "credit")
            {
                return PartialView("Edit", new Credit("Test", "20-2-2", 20.00));
            }
            if (type == "debit")
            {
                return PartialView("Edit", new Debit("Test", "20-2-2", 22.00));
            }
            else
                return PartialView("Edit", new Account("hello"));
        }
    }
}
