using IdentitySample.Models;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace ProyectsMVC.Controllers
{
    [Authorize]
    public class SearchProductsController : Controller
    {
        public SearchProductsController()
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
        public SearchProductsController(ApplicationUserManager userManager)
        {
            UserManager = userManager;
        }

        // GET: SearchProducts
        public ActionResult Create()
        {
            Logica.BL.Categories method = new Logica.BL.Categories();
            ViewBag.Categories = method.GetCategories();

            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Create(Logica.Models.BindingModel.SearchCreateProducts model)
        {
            ApplicationUser user = await UserManager.FindByNameAsync(User.Identity.Name);

            Logica.BL.Categories method = new Logica.BL.Categories();
            ViewBag.Categories = method.GetCategories();

            Logica.BL.Customer customer = new Logica.BL.Customer();
            var validaCustomer = customer.GetCustomer().Where(x => x.UserId == user.Id).FirstOrDefault();

            if (validaCustomer != null)
            {
                return RedirectToAction("Index", new { categoryId = model.CategoryId, prodName = model.ProdName });
            }
            ViewBag.Message = "Aun no estas registrado, debes hacerlo para empezar a comprar";

            return View("SuccessSearchProducts");
        }

        public ActionResult SuccessSearchProducts()
        {
            return View();
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