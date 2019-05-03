using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectsMVC.Logica.Models.DB
{
  public class IndexCertyHigh
    {
        public int prueCodigo { get; set; }
        public int? niveCodigo { get; set; }
        public string prueDescripcion { get; set; }

        public Niveles Niveles { get; set; }
    }
}
