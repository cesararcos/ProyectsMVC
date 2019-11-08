using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ProyectsMVC.API.Controllers
{
    [RoutePrefix("api/Login")]
    public class LoginController : ApiController
    {

        [Route("GetAspNetUsers")]
        public IHttpActionResult GetLogin()
        {

            try
            {
                Logica.Services.Login login = new Logica.Services.Login();
                var listLogin = login.GetAspNetUsers();

                return Ok(listLogin);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
    }
}