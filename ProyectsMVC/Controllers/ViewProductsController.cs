using ProyectsMVC.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace ProyectsMVC.Controllers
{
    public class ViewProductsController : Controller
    {
        private ProyectsMVCEntities db = new ProyectsMVCEntities();
        // GET: ViewProducts
        public ActionResult Index()
        {
            //var ViewProducts = db.Products.Include(t => t.ProductPhotos);//Categories
            Logica.BL.Products products = new Logica.BL.Products();
            var ViewP = products.GetProducts().LastOrDefault();
            var ViewProducts = db.Products.Where(q => q.Id == ViewP.Id);
            
            return View(ViewProducts);
        }
    }
}