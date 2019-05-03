using System.ComponentModel.DataAnnotations;

namespace ProyectsMVC.Logica.Models.ViewModel
{
    public class IndexCertyHighIndexViewModel
    {
        [Display(Name = "Descripcion nivel")]
        public int PrueCodigo { get; set; }

        [Display(Name = "Descripcion nivel")]
        public string NivelDescripcion { get; set; }

        [Display(Name = "Descripcion prueba")]
        public string PruebaDescripcion { get; set; }
    }
}
