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
        public ActionResult Create(string id)
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

        [HttpPost]
        public ActionResult Create(Logica.Models.BindingModel.ClientesBindingModel model)
        {
            if (ModelState.IsValid)
            {
                Logica.BL.Clientes clientes = new Logica.BL.Clientes();
                clientes.CreateClientes(model.Cedula,
                    model.Nombre,
                    model.Apellido,
                    model.NiveduCodigo,
                    model.Telefonofijo,
                    model.Celular,
                    model.Email,
                    model.Edad,
                    model.GeneCodigo,
                    model.Fechanacimiento,
                    model.BarCodigo,
                    model.Foto,
                    model.Id);

                //return RedirectToAction("Index", new { id = model.Id });
            }

            Logica.BL.NivelEducativo nivelEducativo = new Logica.BL.NivelEducativo();
            ViewBag.NivelEducativo = nivelEducativo.GetNivelEducativo();

            Logica.BL.Genero genero = new Logica.BL.Genero();
            ViewBag.Genero = genero.GetGenero();

            Logica.BL.Barrio barrio = new Logica.BL.Barrio();
            ViewBag.Barrio = barrio.GetBarrio();

            return View(model);
        }
    }
}