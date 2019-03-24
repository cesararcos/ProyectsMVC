using IdentitySample.Models;
using Microsoft.AspNet.Identity.Owin;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace ProyectsMVC.Controllers
{
    [Authorize]
    public class ProyectController : Controller
    {
        private ApplicationUserManager _userManager;
       
        public ApplicationUserManager UserManager
        {
            get {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            set { _userManager = value; }
        }

        public ProyectController(ApplicationUserManager userManager)
        {
            UserManager = userManager;
        }

        public ProyectController()
        {

        }

        
        // GET: Proyect
        public async Task<ActionResult> Index()
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
                ExpectedCompletionDate = x.ExpectedCompletionDate,
                CreatedAt = x.CreatedAt,
                UpdatedAt = x.UpdatedAt
            }).ToList();

            listProyects = tenant.Plan.Equals("Premium") ?
                listProyects :
                listProyects.Take(1).ToList();

            return View(listProyects); // Devuelve una vista que tenga el nombre de la accion
        }

        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ActionName("Create")]
        public async Task<ActionResult> Create(Logica.Models.BindingModel.ProyectCreateBindingModel model)
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

                return RedirectToAction("Index");

            }

            return View(model);

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



    }
}