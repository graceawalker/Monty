using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Monty.DAL;
using Monty.Repository;

namespace Monty.UI.Controllers
{
    public class PayPeriodController : Controller
    {
        IPayPeriodRepository _payPeriodRepository;

        public PayPeriodController(IPayPeriodRepository payPeriodRepos)
        {
            _payPeriodRepository = payPeriodRepos;
        }
        //
        // GET: /PayPeriod/

        public ActionResult New()
        {
            return View(new PayPeriod("","",""));
        }

        [HttpPost]
        public ActionResult Save()
        {
             _payPeriodRepository.AddNew(new PayPeriod("","",""));
            return RedirectToAction("New", "PayPeriod");
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Existing()
        {
            return View();
        }
    }
}
