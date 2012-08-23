using System.Web.Mvc;
using Monty.Model.DAL;
using Monty.Repository;

namespace Monty.UI.Controllers
{
    public class DebitController : Controller
    {
        private readonly IRepository<Debit> _repository;
        //
        // GET: /Debit/
        public DebitController(IRepository<Debit> repository)
        {
            _repository = repository;
        }

        public ActionResult Index()
        {
            var credits = _repository.GetAll();
            return View(credits);
        }

    }
}
