using IdentitySample.Models;
using Microsoft.AspNet.Identity.Owin;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace ProyectsMVC.Controllers
{
    public class PreguntasController : Controller
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

        public PreguntasController(ApplicationUserManager userManager)
        {
            UserManager = userManager;
        }
        
        // GET: Preguntas
        public async Task<ActionResult> Create(int? pruebaId)
        {
            ApplicationUser user = await UserManager.FindByNameAsync(User.Identity.Name);

            var preguntasBindingModel = new Logica.Models.ViewModel.PreguntasGetRespuestasViewModel
            {
                PruebaId = pruebaId
            };

            Logica.BL.Preguntas preguntas = new Logica.BL.Preguntas();
            Logica.BL.PruebaRespuesta pruebaRespuestas = new Logica.BL.PruebaRespuesta();

            var preguntasConRespuestas = preguntas.GetPreguntas(pruebaId);
            var preguntasRespondidas = pruebaRespuestas.GetPruebaRespuestas(0);

            preguntasConRespuestas = (from q in preguntasConRespuestas
                                      where !preguntasRespondidas.Select(x => x.PreguntaCodigo).Contains(q.Codigo)
                                      select q).ToList();

            ViewBag.PreguntasGetRespuestasViewModel = preguntasConRespuestas.FirstOrDefault();
            ViewBag.PruebaId = pruebaId;

            return View(preguntasBindingModel);
        }

        [HttpPost]
        public async Task<ActionResult> Create(Logica.Models.ViewModel.PreguntasGetRespuestasViewModel model)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser user = await UserManager.FindByNameAsync(User.Identity.Name);



                Logica.BL.Preguntas Preguntas = new Logica.BL.Preguntas();
                Preguntas.CreatePreguntas(model.Codigo

                    );

                return RedirectToAction("Create", new { pruebaId = model.PruebaId });
            }

            //Logica.BL.Preguntas preguntas = new Logica.BL.Preguntas();
            //ViewBag.Preguntas = preguntas.GetPreguntas();

            //Logica.BL.Preguntas preguntas = new Logica.BL.Preguntas();
            //ViewBag.PreguntasGetRespuestasViewModel = preguntas.GetPreguntas();


            return View(model);
        }
    }
}