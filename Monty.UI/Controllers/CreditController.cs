using System.Web.Mvc;
using Monty.Repository;

namespace Monty.UI.Controllers
{
    public class CreditController : Controller
    {
        private readonly ICreditRepository _creditRepo;

        public CreditController(ICreditRepository creditRepo)
        {
            _creditRepo = creditRepo;
        }

        public ActionResult Index()
        {
            var credits = _creditRepo.GetAllCredits();
            return View(credits);
        }
    }
}