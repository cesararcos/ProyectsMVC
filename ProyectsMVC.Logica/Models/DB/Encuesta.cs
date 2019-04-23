using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectsMVC.Logica.Models.DB
{
   public class Encuesta
    {
        public int EnCodigo { get; set; }
        public string EnDescripcion { get; set; }
        public int RegiCedula { get; set; }

        public Clientes Clientes { get; set; }
    }
}
