using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Monty.Model.DAL;
using Monty.Repository;

namespace Monty.UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly IRepository<Debit> _debitRepo;
        private readonly IRepository<Account> _accountRepo;
        public IRepository<Credit> _creditRepo;
        //
        // GET: /Home/
        public HomeController(IRepository<Credit> creditRepo, IRepository<Debit> debitRepo, IRepository<Account> accountRepo)
        {
            _debitRepo = debitRepo;
            _accountRepo = accountRepo;
            _creditRepo = creditRepo;
        }

        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult Edit(string type, string id)
        {
            if (type == "credit")
            {
                return PartialView("EditCredit", _creditRepo.GetById(id));
            }
            if (type == "debit")
            {
                return PartialView("EditDebit", _debitRepo.GetById(id));
            }
            else
                return PartialView("EditAccount", _accountRepo.GetById(id));
        }
    }
}
