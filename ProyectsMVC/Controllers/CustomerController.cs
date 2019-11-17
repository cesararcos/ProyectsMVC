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
    public class CustomerController : Controller
    {
        public CustomerController()
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
        public CustomerController(ApplicationUserManager userManager)
        {
            UserManager = userManager;
        }

        // GET: Customer
        public ActionResult Create()
        {
            Logica.BL.Cities cities = new Logica.BL.Cities();
            ViewBag.Cities = cities.GetCities();

            Logica.BL.DocumentTypes documentTypes = new Logica.BL.DocumentTypes();
            ViewBag.DocumentTypes = documentTypes.GetDocumentTypes();

            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Create(Logica.Models.BindingModel.CustomerCreateBindingModel model)
        {
            Logica.BL.Cities cities = new Logica.BL.Cities();
            ViewBag.Cities = cities.GetCities();

            Logica.BL.DocumentTypes documentTypes = new Logica.BL.DocumentTypes();
            ViewBag.DocumentTypes = documentTypes.GetDocumentTypes();

            if (ModelState.IsValid)
            {
                ApplicationUser user = await UserManager.FindByNameAsync(User.Identity.Name);

                Logica.BL.Customer customer = new Logica.BL.Customer();
                customer.CustomerCreate(model.DocumentTypeId,
                    model.DocumentNumber,
                    model.FirstName,
                    model.SecondName,
                    model.SecondName,
                    model.SecondSurname,
                    model.Telephone,
                    model.Address,
                    model.CityId,
                    user.Id);

                ViewBag.Message = "Usted se ha registrado correctamente!";

                return View("SuccessCustomer");
            }

            return View(model);
        }
    }
}