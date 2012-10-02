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
        private readonly RepositoryType<Debit> _debitRepo;
        private readonly RepositoryType<Account> _accountRepo;
        public RepositoryType<Credit> _creditRepo;
        //
        // GET: /Home/
        public HomeController(RepositoryType<Credit> creditRepo, RepositoryType<Debit> debitRepo, RepositoryType<Account> accountRepo)
        {
            _debitRepo = debitRepo;
            _accountRepo = accountRepo;
            _creditRepo = creditRepo;
        }

        public ActionResult Index()
        {
            return View();
        }

    }
}
