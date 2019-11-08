using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectsMVC.Logica.Interfaces
{
    public interface ILogin
    {

        //void GetActivity(int id);

        List<Models.DB.AspNetUsers> GetAspNetUsers();
    }
}
