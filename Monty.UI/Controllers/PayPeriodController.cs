using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MongoDB.Bson;
using Monty.DAL;
using Monty.Repository;
using Monty.UI.Models.PayPeriodModels;

namespace Monty.UI.Controllers
{
    public class PayPeriodController : Controller
    {
        IPayPeriodRepository _payPeriodRepository;

        public PayPeriodController(IPayPeriodRepository payPeriodRepos)
        {
            _payPeriodRepository = payPeriodRepos;
        }//
        // GET: /PayPeriod/

        public ActionResult New()
        {
            return View(new PayPeriodModel { PayPeriod = new PayPeriod() });
        }

        [HttpPost]
        public ActionResult Save(PayPeriodModel model)
        {
            _payPeriodRepository.AddNew(model.PayPeriod);
            return RedirectToAction("New", "PayPeriod");
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public void Existing(string value, string name, string id)
        {
            var payPeriod = _payPeriodRepository.GetPayPeriodById(id);
            if (name == "name")
                payPeriod.PayPeriodName = value;
            if (name == "startDate")
                payPeriod.StartDate = Convert.ToDateTime(value);
            if (name == "endDate")
                payPeriod.EndDate = Convert.ToDateTime(value);
            _payPeriodRepository.Update(payPeriod);
        }

        public ActionResult Existing()
        {
            var existing = _payPeriodRepository.GetAllPayPeriods();
            return View((new PayPeriodModel { ExistingPayPeriods = existing }));
        }
    }
}
