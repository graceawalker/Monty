using System.Web.Mvc;
using Monty.Model.DAL;
using Monty.Repository;

namespace Monty.UI.Controllers
{
    public class DebitController : Controller
    {
        private readonly RepositoryType<Debit> _repository;
        //
        // GET: /Debit/
        public DebitController(RepositoryType<Debit> repository)
        {
            _repository = repository;
        }

        public ActionResult Index()
        {
            var credits = _repository.GetAll();
            return View(credits);
        }

        [HttpGet]
        public PartialViewResult Edit(string id)
        {
            return PartialView("Edit", _repository.GetById(id));
        }

        [HttpPost]
        public ActionResult Edit(Debit toEdit)
        {
            _repository.Update(toEdit);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public PartialViewResult AddNew()
        {
            var toCreate = new Debit("", "", 0);
            return PartialView("Edit", toCreate);
        }
    }
}
