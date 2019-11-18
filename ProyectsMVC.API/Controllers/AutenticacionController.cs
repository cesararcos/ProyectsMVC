using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ProyectsMVC.API.Controllers
{
    public class AutenticacionController : ApiController
    {
        // GET: api/Autenticacion
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Autenticacion/5
        public string Get(int id)
        {
            return "value";
        }


        

        

        // POST: api/Autenticacion
        [HttpPost]
        public IHttpActionResult Post([FromBody]Models.Autenticacion v)
        {
            try
            {
                Logica.BL.Login login = new Logica.BL.Login();
                var user = login.Autenticacion(v.email, v.contrasena);
                //int a = 8;

                return Ok(user);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }

            
        }

        // PUT: api/Autenticacion/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Autenticacion/5
        public void Delete(int id)
        {
        }
    }
}
