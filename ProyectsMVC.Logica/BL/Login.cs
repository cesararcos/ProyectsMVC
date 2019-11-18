using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectsMVC.Logica.BL
{
    public class Login
    {
        public Models.Custom.Autenticacion Autenticacion(string usuario, string contrasena)
        {
            DAL.Models.ProyectsMVCEntities _context = new DAL.Models.ProyectsMVCEntities();

            var user = (from q in _context.AspNetUsers
                        where q.Email.Equals(usuario)
                        select new Models.Custom.Autenticacion
                        {
                            email = q.Email,
                            contrasena = q.Password
                            }).First();
                        //}).ToList();

            return new Models.Custom.Autenticacion
            {
                email = user.email,
                contrasena = user.contrasena
            };
            //return user;
        }
    }
}
