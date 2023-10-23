using IdentitySample.Models;
using Microsoft.AspNet.Identity.Owin;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace ProyectsMVC.Controllers
{
    [Authorize]
    public class ProductsController : Controller
    {
        public ProductsController()
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
        public ProductsController(ApplicationUserManager userManager)
        {
            UserManager = userManager;
        }

        // GET: Products
        public async Task<ActionResult> Index()
        {   
            Logica.Services.SearchProducts search = new Logica.Services.SearchProducts();
            var listViewSearchProducts = search.GetSearchProductsAll();

            var listaTodosProductosEncontrados = listViewSearchProducts.Select(x => new Logica.Models.ViewModel.ViewProducts
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
            return View(listaTodosProductosEncontrados);
        }
    }
}