using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using IdentitySample.Models;
using Microsoft.AspNet.Identity.Owin;

namespace ProyectsMVC.Controllers
{
    public class ProductDetailController : Controller
    {
        public ProductDetailController()
        {

        }

        // GET: ProductDetail
        public async Task<ActionResult> Index()
        {
            Logica.BL.SaleDetails SaleDetails = new Logica.BL.SaleDetails();

            var listaDetails = SaleDetails.GetSaleDetails();

            return View(listaDetails);
        }
    }
}