using System.Web.Mvc;
using Monty.Model.DAL;
using Monty.Repository;

namespace Monty.UI.Controllers
{
    public class AccountController : Controller
    {
        private readonly IRepository<Account> _repository;
        //
        // GET: /Debit/
        public AccountController(IRepository<Account> repository)
        {
            _repository = repository;
        }

        public ActionResult Index()
        {
            var accounts = _repository.GetAll();
            return View(accounts);
        }

    }
}
