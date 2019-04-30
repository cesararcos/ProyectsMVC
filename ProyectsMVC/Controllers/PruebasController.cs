using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProyectsMVC.Controllers
{
    public class PruebasController : Controller
    {
        // GET: Pruebas
        public ActionResult Details(int? prueCodigo)
        {
            Logica.BL.Prueba pruebas = new Logica.BL.Prueba();
            var prueba = pruebas.GetPrueba(prueCodigo, null).FirstOrDefault();

            var pruebaDetailsViewModel = new Logica.Models.ViewModel.PruebaDetailsViewModel
            {
                NivelDescripcion = prueba.Niveles.niveDescripcion,
                PruebaDescripcion = prueba.prueDescripcion
            };

          

            return View(pruebaDetailsViewModel);
        }
    }
}