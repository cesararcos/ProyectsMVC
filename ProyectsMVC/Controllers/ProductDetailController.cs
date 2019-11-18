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

        // GET: ProductDetail
        public ActionResult Create(int? productsId)
        {
            Logica.BL.Products products = new Logica.BL.Products();

            var listaDetailsProducts = products.GetProducts().Where(x => x.Id == productsId).FirstOrDefault();

            if (listaDetailsProducts == null)
            {
                return RedirectToAction("Index", "Products", null);
            }
            var DetailsProductsViewModel = new Logica.Models.ViewModel.ProductsCreateDetailsViewModel
            {
                Category = listaDetailsProducts.Categories.Name,
                Name = listaDetailsProducts.Name,
                Price = listaDetailsProducts.Price,
                ShippingCost = listaDetailsProducts.ShippingCost,
                //Quantity = listaDetailsProducts.Quantity,
                Warranty = listaDetailsProducts.Warranty,
                States = listaDetailsProducts.States.Name,
                Description = listaDetailsProducts.Description,
                Id = listaDetailsProducts.Id
            };

            return View(DetailsProductsViewModel);
        }

        [HttpPost]
        public ActionResult Create(Logica.Models.ViewModel.ProductsCreateDetailsViewModel model)
        {
            Logica.BL.SaleDetails saleDetails = new Logica.BL.SaleDetails();
            saleDetails.CreateSaleProducts(model.Id,
                model.Quantity,
                model.Price);

            return RedirectToAction("CreateMethodPayment");
        }

        public ActionResult CreateMethodPayment()
        {
            Logica.BL.MethodPayment method = new Logica.BL.MethodPayment();
            ViewBag.MethodPayment = method.GetMethodPayment();

            return View();
        }

        [HttpPost]
        public ActionResult CreateMethodPayment(Logica.Models.ViewModel.ShippingCreateCost model)
        {
            Logica.BL.MethodPayment method = new Logica.BL.MethodPayment();
            ViewBag.MethodPayment = method.GetMethodPayment();

            Logica.BL.SaleDetails saleDetails = new Logica.BL.SaleDetails();
            var listaPaymentProducts = saleDetails.GetSaleDetails().LastOrDefault();

            Logica.BL.Products products = new Logica.BL.Products();
            var costoproducto = products.GetProducts().Where(q => q.Id == listaPaymentProducts.ProductId).FirstOrDefault();

            if (model.ShippingClient && model.ShippingSeller)
            {
                return RedirectToAction("CreateMethodPayment", "ProductDetail", null);
            }
            if ((model.ShippingClient==false) && (model.ShippingSeller==false))
            {
                return RedirectToAction("CreateMethodPayment", "ProductDetail", null);
            }

            saleDetails.CreateShipping(model.ShippingClient,
                model.ShippingSeller,
                listaPaymentProducts.Quantity,
                listaPaymentProducts.SubtotalValue,
                costoproducto.ShippingCost,
                listaPaymentProducts.Id,
                model.MethodPayment);

            return RedirectToAction("CreateMethodPayment");
        }

    }
}