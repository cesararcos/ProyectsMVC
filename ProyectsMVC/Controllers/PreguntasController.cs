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
        public PreguntasController()
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

        public PreguntasController(ApplicationUserManager userManager)
        {
            UserManager = userManager;
        }

        // GET: Preguntas
        public async Task<ActionResult> Create(int? pruebaId)
        {
            ApplicationUser user = await UserManager.FindByNameAsync(User.Identity.Name);

            Logica.BL.Clientes Clientes = new Logica.BL.Clientes();

            var listaClientes = Clientes.GetClientes().Where(x => x.Id == user.Id).FirstOrDefault();

            Logica.BL.Preguntas preguntas = new Logica.BL.Preguntas();
            Logica.BL.PruebaRespuesta pruebaRespuestas = new Logica.BL.PruebaRespuesta();

            var preguntasConRespuestas = preguntas.GetPreguntas(pruebaId);
            var preguntasRespondidas = pruebaRespuestas.GetPruebaRespuestas(listaClientes.Cedula);

            var pregunta = (from q in preguntasConRespuestas
                            where !preguntasRespondidas.Select(x => x.PreguntaCodigo).Contains(q.Codigo)
                            select q).FirstOrDefault();
            //pruebaId = pruebaId + 1;
            if (pregunta == null)
            {
                return RedirectToAction("Index","tbPruebas", null);
            }
            var preguntasViewModel = new Logica.Models.ViewModel.PreguntasGetRespuestasViewModel
            {
                PruebaId = pruebaId,
                Codigo = pregunta.Codigo,
                Descripcion = pregunta.Descripcion,
                RespuestaId = pregunta.RespuestaId,
                Respuestas = pregunta.Respuestas
            };
            
            return View(preguntasViewModel);
            
        }

        [HttpPost]
        public async Task<ActionResult> Create(Logica.Models.ViewModel.PreguntasGetRespuestasViewModel model)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser user = await UserManager.FindByNameAsync(User.Identity.Name);

                Logica.BL.Clientes Clientes = new Logica.BL.Clientes();

                var listaClientes = Clientes.GetClientes().Where(x => x.Id == user.Id).FirstOrDefault();


                Logica.BL.Preguntas Preguntas = new Logica.BL.Preguntas();
                Preguntas.CreatePreguntas(model.PruebaId.Value,
                    model.RespuestaId.Value,
                    listaClientes.Cedula,
                    model.Codigo);

                return RedirectToAction("Create", new { pruebaId = model.PruebaId });
            }

            //Logica.BL.Preguntas preguntas = new Logica.BL.Preguntas();
            //ViewBag.Preguntas = preguntas.GetPreguntas();

            //Logica.BL.Preguntas preguntas = new Logica.BL.Preguntas();
            //ViewBag.PreguntasGetRespuestasViewModel = preguntas.GetPreguntas();


            return View(model);
        }

        // GET: Tasks
        public async Task<ActionResult> Index(int pruebaId)
        {
            ApplicationUser user = await UserManager.FindByNameAsync(User.Identity.Name);

            Logica.BL.Clientes Clientes = new Logica.BL.Clientes();

            var listaClientes = Clientes.GetClientes().Where(x => x.Id == user.Id).FirstOrDefault();

            Logica.BL.TablaRespuestas respuestas = new Logica.BL.TablaRespuestas();
            var listPreguntas = respuestas.GetTablaRespuestas(listaClientes.Cedula, pruebaId);

            var listTablaRespuestasViewModel = listPreguntas.Select(x => new Logica.Models.ViewModel.TablaRespuestasViewModel
            {
                Codigo = x.Codigo,
                Prueba = x.Prueba,
                Respuesta = x.Respuesta,
                Pregunta = x.Pregunta
            }).ToList();

           

            return View(listTablaRespuestasViewModel);
        }
    }
}