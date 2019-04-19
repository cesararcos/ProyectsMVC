using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectsMVC.Logica.Models.BindingModel
{
    public class PreguntasCreateBindingModel
    {
        [Required(ErrorMessage = "The field Descripcion is required")]
        [Display(Name = "Descripcion a")]
        public string PregDescripcion { get; set; }

        [Required(ErrorMessage = "The field Descripcion is required")]
        [Display(Name = "Descripcion b")]
        public int? PregCodigo { get; set; }

        [Required(ErrorMessage = "The field Descripcion is required")]
        [Display(Name = "Descripcion c")]
        public int? PrueCodigo { get; set; }
    }
}
