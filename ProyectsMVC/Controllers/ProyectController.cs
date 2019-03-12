using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProyectsMVC.Controllers
{
    public class ProyectController : Controller
    {
        // GET: Proyect
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ActionName("Create")]
        public ActionResult Create(Models.BindingModel.InicioProyectBindingModel model)
        {
            if (ModelState.IsValid)
            {
                string Name = model.Name;
                string Title = model.Title;
                string Details = model.Details;
                double? PercentageAdvance = model.PercentageAdvance;
                DateTime? ExpectedCompletionDate = model.ExpectedCompletionDate;

                return RedirectToAction("Index");

            }

            return View(model);




        }



    }
}