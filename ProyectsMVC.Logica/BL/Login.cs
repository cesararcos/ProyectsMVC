using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectsMVC.Logica.BL
{
    public class Login
    {
        public Models.Custom.Response Autenticacion(string email, string contrasena)
        {
            try
            {
                DAL.Models.ProyectsMVCEntities _context = new DAL.Models.ProyectsMVCEntities();

                var user = (from q in _context.AspNetUsers
                            where q.Email.Equals(email)
                            select new Models.Custom.Autenticacion
                            {
                                email = q.Email,
                                contrasena = q.Password
                            }).First();
                if (user != null)
                {
                    if (user.contrasena.Equals(contrasena))
                    {
                        return new Logica.Models.Custom.Response
                        {
                            IsSuccess = true,
                            Message = "Usuario logeado correctamente",
                            Result = user
                        };
                    }
                    else
                    {
                        return new Logica.Models.Custom.Response
                        {
                            IsSuccess = false,
                            Message = "Contraseña incorrecta",
                            Result = null
                        };
                    }
                }
                else
                {
                    return new Logica.Models.Custom.Response
                    {
                        IsSuccess = false,
                        Message = "Email no registrado",
                        Result = null
                    };
                }
            }
            catch (Exception e)
            {
                return new Logica.Models.Custom.Response
                {
                    IsSuccess = false,
                    Message = "Email no registrado",
                    Result = null
                };
            }
        }
    }
}
