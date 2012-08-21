using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Monty.Repository;

namespace Monty.UI.Controllers
{
    public class AccountDebitController : Controller
    {
        private readonly AccountDebitRepository _repository;
        //
        // GET: /AccountDebit/
        public AccountDebitController(AccountDebitRepository repository)
        {
            _repository = repository;
        }

        public ActionResult Index()
        {
            var accountCredits = _repository.GetAllAccountDebits();
            return View(accountCredits);
        }

    }
}
