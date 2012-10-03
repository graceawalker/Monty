using System.Web.Mvc;
using Monty.Model.DAL;
using Monty.Repository;

namespace Monty.UI.Controllers
{
    public class AccountController : Controller
    {
        private readonly RepositoryType<Account> _repository;
        //
        // GET: /Debit/
        public AccountController(RepositoryType<Account> repository)
        {
            _repository = repository;
        }

        public ActionResult Index()
        {
            var accounts = _repository.GetAll();
            return View(accounts);
        }

        [HttpGet]
        public PartialViewResult Edit(string id)
        {
            return PartialView("Edit", _repository.GetById(id));
        }

        [HttpPost]
        public ActionResult Edit(Account toEdit)
        {
            _repository.Update(toEdit);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public PartialViewResult AddNew()
        {
            var toCreate = new Account("");
            return PartialView("Edit", toCreate);
        }

        public ActionResult Delete(string id)
        {
            _repository.DeleteById(id);
            return RedirectToAction("Index");
        }
    }
}
