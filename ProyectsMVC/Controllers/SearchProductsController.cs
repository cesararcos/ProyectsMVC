using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProyectsMVC.Controllers
{
    [Authorize]
    public class SearchProductsController : Controller
    {
        // GET: SearchProducts
        public ActionResult Create()
        {
            Logica.BL.Categories method = new Logica.BL.Categories();
            ViewBag.Categories = method.GetCategories();

            return View();
        }

        [HttpPost]
        public ActionResult Create(Logica.Models.BindingModel.SearchCreateProducts model)
        {
            Logica.BL.Categories method = new Logica.BL.Categories();
            ViewBag.Categories = method.GetCategories();

            return RedirectToAction("Index", new { categoryId = model.CategoryId, prodName=model.ProdName });
        }

        public ActionResult Index(int categoryId, string prodName)
        {
            Logica.Services.SearchProducts search = new Logica.Services.SearchProducts();
            var listViewSearchProducts = search.GetSearchProducts(categoryId, prodName);

            var listaProductosEncontrados = listViewSearchProducts.Select(x => new Logica.Models.ViewModel.ViewProducts
            {
                prodId = x.prodId,
                CategoryId = x.CategoryId,
                CategoryName = x.CategoryName,
                prodName = x.prodName,
                Price = x.Price,
                ShippingCost = x.ShippingCost,
                Warranty = x.Warranty,
                Description = x.Description,
                Quantity = x.Quantity,
                StateId = x.StateId,
                StateName = x.StateName,
                Guid = x.Guid
            }).ToList();
            return View(listaProductosEncontrados);
        }
    }
}