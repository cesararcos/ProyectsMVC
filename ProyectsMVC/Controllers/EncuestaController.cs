using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProyectsMVC.Controllers
{
    public class EncuestaController : Controller
    {
        // GET: Encuesta
        public ActionResult Create(int? RegiCedula)
        {
            var encuestaBindingModel = new Logica.Models.BindingModel.EncuestaCreateBindingModel
            {
                RegiCedula = RegiCedula
            };
            Logica.BL.Encuesta encuesta = new Logica.BL.Encuesta();
            ViewBag.Encuesta = encuesta.GetEncuesta();

            return View(encuestaBindingModel);
        }

        [HttpPost]
        public ActionResult Create(Logica.Models.BindingModel.EncuestaCreateBindingModel model)
        {
            if (!ModelState.IsValid)
            {
                Logica.BL.Encuesta Encuesta = new Logica.BL.Encuesta();
                Encuesta.CreateEncuesta(model.EnCodigo

                    );

                //return RedirectToAction("Index", new { proyectId = model.proyectId });
            }

            Logica.BL.Encuesta encuesta = new Logica.BL.Encuesta();
            ViewBag.Encuesta = encuesta.GetEncuesta();



            return View(model);
        }
    }
}