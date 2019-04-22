using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProyectsMVC.Controllers
{
    public class PreguntasController : Controller
    {
        // GET: Preguntas
        public ActionResult Create(int? PrueCodigo)
        {
            var preguntasBindingModel = new Logica.Models.BindingModel.PreguntasCreateBindingModel
            {
                   PrueCodigo = PrueCodigo 
            };
            Logica.BL.Preguntas preguntas = new Logica.BL.Preguntas();
            ViewBag.Preguntas = preguntas.GetPreguntas();

            return View(preguntasBindingModel);
        }

        [HttpPost]
        public ActionResult Create(Logica.Models.BindingModel.PreguntasCreateBindingModel model)
        {
            if (!ModelState.IsValid)
            {
                Logica.BL.Preguntas Preguntas = new Logica.BL.Preguntas();
                Preguntas.CreatePreguntas(model.PregCodigo
                   
                    );

                //return RedirectToAction("Index", new { proyectId = model.proyectId });
            }

            Logica.BL.Preguntas preguntas = new Logica.BL.Preguntas();
            ViewBag.Preguntas = preguntas.GetPreguntas();

            

            return View(model);
        }
    }
}