using System.Web.Mvc;
using Monty.Model.DAL;
using Monty.Repository;

namespace Monty.UI.Controllers
{
    public class CreditController : Controller
    {
        private readonly IRepository<Credit> _repo;

        public CreditController(IRepository<Credit> repo)
        {
            _repo = repo;
        }

        public ActionResult Index()
        {
            var credits = _repo.GetAll();
            return View(credits);
        }
    }
}