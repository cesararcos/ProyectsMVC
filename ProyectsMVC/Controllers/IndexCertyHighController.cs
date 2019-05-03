using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProyectsMVC.Controllers
{
    public class IndexCertyHighController : Controller
    {
        [Authorize]
        // GET: IndexCertyHigh
        public ActionResult Index(int? id)
        {
            Logica.BL.IndexCertyHigh pruebas = new Logica.BL.IndexCertyHigh();
            var prueba = pruebas.GetIndexCertyHigh(id, null).FirstOrDefault();

            var indexCertyHighIndexViewModel = new Logica.Models.ViewModel.IndexCertyHighIndexViewModel
            {
                NivelDescripcion = prueba.Niveles.niveDescripcion,
                PruebaDescripcion = prueba.prueDescripcion
            };

            

            return View(indexCertyHighIndexViewModel);
        }
    }
}