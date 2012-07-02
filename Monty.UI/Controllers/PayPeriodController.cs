using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
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
        }
        //
        // GET: /PayPeriod/

        public ActionResult New()
        {
            return View(new PayPeriodModel { PayPeriod = new PayPeriod()});
        }

        [HttpPost]
        public ActionResult Save(PayPeriodModel model)
        {
            _payPeriodRepository.AddNew(model.PayPeriod);
            return RedirectToAction("Existing", "PayPeriod");
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Existing()
        {
            var existing = _payPeriodRepository.GetAllPayPeriods();
            return View((new PayPeriodModel { ExistingPayPeriods = existing}));
        }
    }
}
