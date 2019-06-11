using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectsMVC.Logica.Models.ViewModel
{
   public class TablaRespuestasViewModel
    {
        public int Codigo { get; set; }
        public string Prueba { get; set; }
        public string Respuesta { get; set; }
        public string Pregunta { get; set; }
        public string Estado { get; set; }
    }
}
