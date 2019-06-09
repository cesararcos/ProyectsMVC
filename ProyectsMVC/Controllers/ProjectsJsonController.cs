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
    public class ProjectsJsonController : Controller
    {
        private ApplicationUserManager _userManager;

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            set { _userManager = value; }
        }

        public ProjectsJsonController(ApplicationUserManager userManager)
        {
            UserManager = userManager;
        }

        public ProjectsJsonController()
        {

        }

        public ActionResult Index()
        {
            return View();
        }


        // GET: Proyect
        public async Task<ActionResult> GetProyects()
        {

            try
            {
                ApplicationUser user = await UserManager.FindByNameAsync(User.Identity.Name);
                Logica.BL.Tenants tenants = new Logica.BL.Tenants();
                var tenant = tenants.GetTenants(user.Id).FirstOrDefault();

                Logica.BL.Proyects proyects = new Logica.BL.Proyects();

                var result = await UserManager.IsInRoleAsync(user.Id, "Admin") ?
                    proyects.GetProyects(null, tenant.Id) : // Si es Admin consulta todos los proyectos de la organizacion
                     proyects.GetProyects(null, tenant.Id, user.Id); // Si es miembro consulta los proyectos de la organizacion que le pertenezcan

                var listProyects = result.Select(x => new Logica.Models.ViewModel.ProyectsIndexViewModel
                {
                    Id = x.Id,
                    Title = x.Title,
                    Details = x.Details,
                    ExpectedCompletionDateString = x.ExpectedCompletionDate.Value.ToString("yyyy-MM-dd HH:mm:ss"),
                    CreatedAtString = x.CreatedAt.Value.ToString("yyyy-MM-dd HH:mm:ss"),
                    UpdatedAtString = x.UpdatedAt.Value.ToString("yyyy-MM-dd HH:mm:ss")
                }).ToList();

                listProyects = tenant.Plan.Equals("Premium") ?
                    listProyects :
                    listProyects.Take(1).ToList();

                return Json(new
                {
                    IsSuccessful = true,
                    Data = listProyects
                }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new Logica.Models.ViewModel.ResponseViewModel
                {
                    IsSuccessful = false,
                    Errors = new List<string> { ex.Message }
                }, JsonRequestBehavior.AllowGet); ;
            }


        }

        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ActionName("Create")]
        public async Task<ActionResult> Create(Logica.Models.BindingModel.ProyectCreateBindingModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    ApplicationUser user = await UserManager.FindByNameAsync(User.Identity.Name);

                    Logica.BL.Tenants tenants = new Logica.BL.Tenants();
                    var tenant = tenants.GetTenants(user.Id).FirstOrDefault();

                    Logica.BL.Proyects proyects = new Logica.BL.Proyects();
                    proyects.CreateProyects(model.Title,
                        model.Details,
                        model.ExpectedCompletionDate,
                        tenant.Id);

                }
                else
                {
                    return Json(new Logica.Models.ViewModel.ResponseViewModel
                    {
                        IsSuccessful = false,
                        Errors = ModelState.Values.SelectMany(m => m.Errors).Select(e => e.ErrorMessage).ToList()
                    }, JsonRequestBehavior.AllowGet);
                }
                return Json(new
                {
                    IsSuccessful = true
                }, JsonRequestBehavior.AllowGet);

            }
            catch (Exception ex)
            {
                return Json(new Logica.Models.ViewModel.ResponseViewModel
                {
                    IsSuccessful = false,
                    Errors = new List<string> { ex.Message }
                }, JsonRequestBehavior.AllowGet);
            }

        }

        public ActionResult Edit(int? id)
        {
            Logica.BL.Proyects proyects = new Logica.BL.Proyects();
            var proyect = proyects.GetProyects(id, null).FirstOrDefault();

            var proyectBindingModel = new Logica.Models.BindingModel.ProyectEditBindingModel
            {
                Id = proyect.Id,
                Details = proyect.Details,
                ExpectedCompletionDate = proyect.ExpectedCompletionDate,
                Title = proyect.Title
            };

            return View(proyectBindingModel);
        }

        [HttpPost]
        public ActionResult Edit(Logica.Models.BindingModel.ProyectEditBindingModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Logica.BL.Proyects proyects = new Logica.BL.Proyects();
                    proyects.UpdateProyects(model.Id,
                        model.Title,
                        model.Details,
                        model.ExpectedCompletionDate);

                    //return RedirectToAction("Index");
                    return Json(new
                    {
                        IsSuccessful = true
                    }, JsonRequestBehavior.AllowGet);
                }

                return View(model);
            }
            catch (Exception ex)
            {
                return Json(new Logica.Models.ViewModel.ResponseViewModel
                {
                    IsSuccessful = false,
                    Errors = new List<string> { ex.Message }
                }, JsonRequestBehavior.AllowGet);
            }
        }



        public ActionResult Details(int? id)
        {
            Logica.BL.Proyects proyects = new Logica.BL.Proyects();
            var proyect = proyects.GetProyects(id, null).FirstOrDefault();

            var proyectDetailsViewModel = new Logica.Models.ViewModel.ProyectsDetailsViewModel
            {
                Details = proyect.Details,
                ExpectedCompletionDate = proyect.ExpectedCompletionDate,
                Title = proyect.Title,
                CreatedAt = proyect.CreatedAt,
                UpdatedAt = proyect.UpdatedAt
            };

            return View(proyectDetailsViewModel);
        }


        public ActionResult Delete(int? id)
        {
            Logica.BL.Proyects proyects = new Logica.BL.Proyects();
            proyects.DeleteProyects(id);

            return RedirectToAction("Index");
        }
    }
}