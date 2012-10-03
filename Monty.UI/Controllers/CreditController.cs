using System.Web.Mvc;
using Monty.Model.DAL;
using Monty.Repository;

namespace Monty.UI.Controllers
{
    public class CreditController : Controller
    {
        private readonly RepositoryType<Credit> _repo;

        public CreditController(RepositoryType<Credit> repo)
        {
            _repo = repo;
        }

        public ActionResult Index()
        {
            var credits = _repo.GetAll();
            return View(credits);
        }

        [HttpGet]
        public PartialViewResult Edit(string id)
        {
            return PartialView("Edit", _repo.GetById(id));
        }

        [HttpPost]
        public ActionResult Edit(Credit toEdit)
        {
            _repo.Update(toEdit);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public PartialViewResult AddNew()
        {
            var toCreate = new Credit("","",0);
            return PartialView("Edit", toCreate);
        }

        public RedirectToRouteResult Delete(string id)
        {
            _repo.DeleteById(id);
            return RedirectToAction("Index");
        }
    }
}