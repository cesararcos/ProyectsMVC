using ProyectsMVC.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace ProyectsMVC.Controllers
{
    public class ProductsController : Controller
    {
        private ProyectsMVCEntities db = new ProyectsMVCEntities();

        // GET: Products
        public ActionResult Index()
        {



            var Products = db.Products.Include(t => t.ProductPhotos);//Categories
            return View(Products.ToList());

        }
    }
}