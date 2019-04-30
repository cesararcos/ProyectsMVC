using System.ComponentModel.DataAnnotations;

namespace ProyectsMVC.Logica.Models.ViewModel
{
    public class PruebaDetailsViewModel
    {
        [Display(Name = "Descripcion nivel")]
        public string NivelDescripcion { get; set; }

        [Display(Name = "Descripcion prueba")]
        public string PruebaDescripcion { get; set; }

       
    }
}
