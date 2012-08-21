using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Monty.Repository;

namespace Monty.UI.Controllers
{
    public class DebitController : Controller
    {
        private readonly DebitRepository _repository;
        //
        // GET: /Debit/
        public DebitController(DebitRepository repository)
        {
            _repository = repository;
        }

        public ActionResult Index()
        {
            var credits = _repository.GetAllDebits();
            return View(credits);
        }

    }
}
