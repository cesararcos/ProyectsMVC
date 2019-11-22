using ProyectsMVC.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using IdentitySample.Models;
using Microsoft.AspNet.Identity.Owin;
using System.Threading.Tasks;

namespace ProyectsMVC.Controllers
{
    [Authorize]
    public class SaleProductsController : Controller
    {
        private ProyectsMVCEntities db = new ProyectsMVCEntities();

        public SaleProductsController()
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
        public SaleProductsController(ApplicationUserManager userManager)
        {
            UserManager = userManager;
        }
        // GET: SaleProducts
        public ActionResult Create()
        {
            Logica.BL.Categories categories = new Logica.BL.Categories();
            ViewBag.Categories = categories.GetCategories();

            Logica.BL.States states = new Logica.BL.States();
            ViewBag.States = states.GetStates();

            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Create(Logica.Models.BindingModel.SaleProductsCreateBindingModel model)
        {
            ApplicationUser user = await UserManager.FindByNameAsync(User.Identity.Name);

            Logica.BL.Categories categories = new Logica.BL.Categories();
            ViewBag.Categories = categories.GetCategories();

            Logica.BL.States states = new Logica.BL.States();
            ViewBag.States = states.GetStates();

            if (ModelState.IsValid)
            {
                //PARTE DEL FOR ES PARA CAPTURAR EL GUID DE LA IMAGEN A CARGAR
                for (int i = 0; i < Request.Files.Count; i++)
                {
                    HttpPostedFileBase file = Request.Files[i];
                    //int fileSize = file.ContentLength;
                    //string fileName = file.FileName;
                    string mimeType = file.ContentType;
                    //System.IO.Stream fileContent = file.InputStream;

                    var guid = Guid.NewGuid();
                    var ext = mimeType.Split('/').LastOrDefault();
                    
                    //model.Photo = string.Format("{0}.{1}", guid, ext);
                    model.Photo = string.Format("{0}", guid);
                    model.Guid = string.Format(".{0}", ext);
                    file.SaveAs(Server.MapPath("~/Images/Products/") +
                    string.Format("{0}.{1}", guid, ext));
                }

                Logica.BL.Customer customer = new Logica.BL.Customer();
                var validaCustomer = customer.GetCustomer().Where(x => x.UserId == user.Id).FirstOrDefault();

                if (validaCustomer != null)
                {
                    Logica.BL.SellProducts saleDetails = new Logica.BL.SellProducts();
                    saleDetails.CreateSaleProducts(model.Name,
                        model.Category,
                        model.Description,
                        model.Photo,
                        model.Guid,
                        model.States,
                        model.Quantity,
                        model.Price,
                        model.ShippingCost,
                        model.Warranty,
                        validaCustomer.Id);

                    ViewBag.Message = "Tu producto se guardo de manera satisfactoria!";

                    return View("SuccessMessage");
                }
                ViewBag.Message = "Aun no estas registrado, debes hacerlo para empezar a vender";

                return View("SuccessSaleProducts");
            }

            return View(model);
        }
        
        public ActionResult SuccessMessage()
        {
            return RedirectToAction("Create");
        }
    }


}