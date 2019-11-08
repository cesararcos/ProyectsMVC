using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectsMVC.Logica.Models.DB
{
   public class AspNetUsers
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public bool EmailConfirmar { get; set; }
        public string password { get; set; }
        public string Security { get; set; }
        public string NumTelefono { get; set; }
        public bool ConfirmarNumTelefono { get; set; }
        public bool ThowFactorEnable { get; set; }
        public DateTime LockoutEndDateUtc { get; set; }
        public bool LockoutEnabled { get; set; }
        public int AccessFailedCount { get; set; }
        public string UserName { get; set; }
        
    }
}
