﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProyectsMVC.Controllers
{
    public class PreguntasController : Controller
    {
        // GET: Preguntas
        public ActionResult Create(int? pruebaId)
        {
            var preguntasBindingModel = new Logica.Models.ViewModel.PreguntasGetRespuestasViewModel
            {
                   PruebaId = pruebaId
            };
            Logica.BL.Preguntas preguntas = new Logica.BL.Preguntas();
            ViewBag.PreguntasGetRespuestasViewModel = preguntas.GetPreguntas(pruebaId);

            return View(preguntasBindingModel);
        }

        [HttpPost]
        public ActionResult Create(Logica.Models.ViewModel.PreguntasGetRespuestasViewModel model)
        {
            if (!ModelState.IsValid)
            {
                Logica.BL.Preguntas Preguntas = new Logica.BL.Preguntas();
                Preguntas.CreatePreguntas(model.Codigo
                   
                    );

                //return RedirectToAction("Index", new { proyectId = model.proyectId });
            }

            //Logica.BL.Preguntas preguntas = new Logica.BL.Preguntas();
            //ViewBag.Preguntas = preguntas.GetPreguntas();

            //Logica.BL.Preguntas preguntas = new Logica.BL.Preguntas();
            //ViewBag.PreguntasGetRespuestasViewModel = preguntas.GetPreguntas();


            return View(model);
        }
    }
}