using System.Web.Mvc;
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
            return View(accountCredits);
        }
    }
}