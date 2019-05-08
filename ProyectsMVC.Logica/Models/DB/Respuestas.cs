using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectsMVC.Logica.Models.DB
{
   public class Respuestas
    {
        public int RespCodigo { get; set; }
        public string RespDescripcion { get; set; }
        public int? PregCodigo { get; set; }
        public bool? RespCorrectas { get; set; }

        public Preguntas Preguntas { get; set; }
    }
}
