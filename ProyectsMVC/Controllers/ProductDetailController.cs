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

        private ApplicationUserManager _userManager;
        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            set { _userManager = value; }
        }
        public ProductDetailController(ApplicationUserManager userManager)
        {
            UserManager = userManager;
        }


        // GET: ProductDetail
        public ActionResult Create(int? productsId)
        {
            Logica.BL.Products products = new Logica.BL.Products();

            Logica.Services.SearchProducts search = new Logica.Services.SearchProducts();
            var listProductsDetails = search.GetProductsDetails(productsId);

            if (listProductsDetails == null)
            {
                return RedirectToAction("Index", "Products", null);
            }
            var DetailsProductsViewModel = listProductsDetails.Select(x => new Logica.Models.ViewModel.ProductsCreateDetailsViewModel
            {
                Category = x.CategoryName,
                Name = x.prodName,
                Price = x.Price,
                ShippingCost = x.ShippingCost,
                //Quantity = listaDetailsProducts.Quantity,
                Warranty = x.Warranty,
                States = x.StateName,
                Description = x.Description,
                Id = x.prodId,
                Guid = x.Guid
            }).FirstOrDefault();

            return View(DetailsProductsViewModel);
        }

        [HttpPost]
        public ActionResult Create(Logica.Models.ViewModel.ProductsCreateDetailsViewModel model)
        {
            if (ModelState.IsValid)
            {
                Logica.BL.SaleDetails saleDetails = new Logica.BL.SaleDetails();
                saleDetails.CreateSaleProducts(model.Id,
                    model.Quantity,
                    model.Price);

                return RedirectToAction("CreateMethodPayment");
            }

            Logica.Services.SearchProducts search = new Logica.Services.SearchProducts();
            var listProductsDetails = search.GetProductsDetails(model.Id);

            if (listProductsDetails == null)
            {
                return RedirectToAction("Index", "Products", null);
            }
            var DetailsProductsViewModel = listProductsDetails.Select(x => new Logica.Models.ViewModel.ProductsCreateDetailsViewModel
            {
                Category = x.CategoryName,
                Name = x.prodName,
                Price = x.Price,
                ShippingCost = x.ShippingCost,
                //Quantity = listaDetailsProducts.Quantity,
                Warranty = x.Warranty,
                States = x.StateName,
                Description = x.Description,
                Id = x.prodId,
                Guid = x.Guid
            }).FirstOrDefault();

            return View(DetailsProductsViewModel);
        }

        public ActionResult CreateMethodPayment()
        {
            Logica.BL.MethodPayment method = new Logica.BL.MethodPayment();
            ViewBag.MethodPayment = method.GetMethodPayment();

            return View();
        }

        [HttpPost]
        public async Task<ActionResult> CreateMethodPayment(Logica.Models.ViewModel.ShippingCreateCost model)
        {
            ApplicationUser user = await UserManager.FindByNameAsync(User.Identity.Name);

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
            if ((model.ShippingClient == false) && (model.ShippingSeller == false))
            {
                return RedirectToAction("CreateMethodPayment", "ProductDetail", null);
            }

            Logica.BL.Customer customer = new Logica.BL.Customer();
            var validaCustomer = customer.GetCustomer().Where(x => x.UserId == user.Id).FirstOrDefault();

            saleDetails.CreateShipping(model.ShippingClient,
                model.ShippingSeller,
                listaPaymentProducts.Quantity,
                listaPaymentProducts.SubtotalValue,
                costoproducto.ShippingCost,
                listaPaymentProducts.Id,
                model.MethodPayment,
                validaCustomer.Id);

            return RedirectToAction("ConfirmSale", new { SaleDetailsId = listaPaymentProducts.Id });
        }

        public ActionResult ConfirmSale(int SaleDetailsId)
        {
            Logica.Services.SearchProducts search = new Logica.Services.SearchProducts();
            var listSaleDetails = search.GetConfirmSale(SaleDetailsId);

            var DetailsSaleDetails = listSaleDetails.Select(x => new Logica.Models.ViewModel.ConfirmCreateSaleViewModel
            {
                productsName = x.ProductsName,
                description = x.Description,
                categoryName = x.CategoryName,
                quantity = x.Quantity,
                subtotal = x.Subtotal,
                metodoPago = x.MetodoPago,
                total = x.Total,
                guid = x.Guid
            }).FirstOrDefault();

            return View(DetailsSaleDetails);
        }

    }
}