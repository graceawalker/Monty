using System.Collections.Generic;
using System.Web.Mvc;
using Monty.DAL;
using Monty.UI.Models;
using Monty.Repository;

namespace Monty.UI.Controllers
{
    public class AccountCreditController : Controller
    {
        private readonly IAccountCreditRepository _accountCreditRepo;

        public AccountCreditController(IAccountCreditRepository accountCreditRepo)
        {
            _accountCreditRepo = accountCreditRepo;
        }

        public ActionResult Index()
        {
            var accountCredits = _accountCreditRepo.GetAllAccountCredits();
            var model = new AccountCreditModel();
            model.AccountCredits = new List<AccountCredit>(accountCredits);
            return View(model);
        }
    }
}