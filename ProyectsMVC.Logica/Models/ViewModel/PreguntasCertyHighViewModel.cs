using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectsMVC.Logica.Models.ViewModel
{
   public class PreguntasCertyHighIndexViewModel
    {
        [Display(Name = "Id")]
        public int PregCodigo { get; set; }

        [Display(Name = "Title")]
        public string PregDecripcion { get; set; }

        [Display(Name = "Details")]
        public string Prueba { get; set; }
    }
}
