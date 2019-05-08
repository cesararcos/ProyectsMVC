using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProyectsMVC.Controllers
{
    public class PreguntasCertyHighController : Controller
    {
        // GET: PreguntasCertyHigh
        public ActionResult Index(int? pruebaId)
        {
            Logica.BL.Preguntas preguntas = new Logica.BL.Preguntas();
            var listPreguntas = preguntas.GetPreguntas(pruebaId, null);

            var listPreguntasViewModel = listPreguntas.Select(x => new Logica.Models.ViewModel.TasksIndexViewModel
            {
                Id = x.Id,
                Title = x.Title,
                Details = x.Details,
                ExpirationDate = x.ExpirationDate,
                IsCompleted = x.IsCompleted,
                Effort = x.Effort,
                RemainigWork = x.RemainigWork,
                States = x.States.Name,
                Activity = x.Activities.Name,
                Priority = x.Priorities.Name
            }).ToList();

            Logica.BL.Proyects proyects = new Logica.BL.Proyects();
            var proyect = proyects.GetProyects(proyectId, null).FirstOrDefault();

            ViewBag.Proyect = proyect;
            return View();
        }
    }
}