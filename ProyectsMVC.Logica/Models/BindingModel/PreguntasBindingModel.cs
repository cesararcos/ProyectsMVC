using System.ComponentModel.DataAnnotations;

namespace ProyectsMVC.Logica.Models.BindingModel
{
    public class PreguntasCreateBindingModel
    {
        [Required(ErrorMessage = "The field Descripcion is required")]
        [Display(Name = "Altura para necesitar certificado de alturas")]
        public string PregDescripcion { get; set; }

        [Required(ErrorMessage = "The field Descripcion is required")]
        [Display(Name = "Descripcion b")]
        public int? PregCodigo { get; set; }

        [Required(ErrorMessage = "The field Descripcion is required")]
        [Display(Name = "El casco es obligatorio con el arnes")]
        public int? PrueCodigo { get; set; }
    }
}
