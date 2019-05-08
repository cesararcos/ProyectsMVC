using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectsMVC.Logica.Models.DB
{
    public class PreguntasCertyHigh
    {
        public PreguntasCertyHigh()
        {
            Prueba = new Prueba();
        }

        public int PregCodigo { get; set; }
        public string PregDescripcion { get; set; }

        public int? PrueCodigo { get; set; }

        public Prueba Prueba { get; set; }
    }
}
