using System.ComponentModel.DataAnnotations;

namespace ProyectsMVC.Logica.Models.BindingModel
{
    public class EncuestaCreateBindingModel
    {
        [Required(ErrorMessage = "The field Descripcion is required")]
        [Display(Name = "Como le parecieron las preguntas presentadas?")]
        public string EnDescripcion { get; set; }

        [Required(ErrorMessage = "The field Descripcion is required")]
        [Display(Name = "Descripcion b")]
        public int? EnCodigo { get; set; }

        [Required(ErrorMessage = "The field Descripcion is required")]
        [Display(Name = "Le a sido util la plataforma web?")]
        public int? RegiCedula { get; set; }
    }
}
