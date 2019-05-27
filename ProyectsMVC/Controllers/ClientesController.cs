using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProyectsMVC.Controllers
{
    public class ClientesController : Controller
    {
        // GET: Clientes
        public ActionResult Create(int? id)
        {
            var ClientesBindingModel = new Logica.Models.BindingModel.ClientesBindingModel
            {
                Id = id
            };

            Logica.BL.NivelEducativo nivelEducativo = new Logica.BL.NivelEducativo();
            ViewBag.NivelEducativo = nivelEducativo.GetNivelEducativo();

            Logica.BL.Genero genero = new Logica.BL.Genero();
            ViewBag.Genero = genero.GetGenero();

            Logica.BL.Barrio barrio = new Logica.BL.Barrio();
            ViewBag.Barrio = barrio.GetBarrio();

            return View(ClientesBindingModel);
        }
    }
}