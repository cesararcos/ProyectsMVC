using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectsMVC.Logica.Models.BindingModel
{
   public class ClientesBindingModel
    {
        [Required(ErrorMessage = "The field Cedula is required")]
        [Display(Name = "Cedula")]
        public int Cedula { get; set; }

        [Required(ErrorMessage = "The field Nombre is required")]
        [Display(Name = "Nombre")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "The field Apellido is required")]
        [Display(Name = "Apellido")]
        public DateTime? Apellido { get; set; }

        [Required(ErrorMessage = "The field NiveduCodigo is required")]
        [Display(Name = "NiveduCodigo")]
        public int? NiveduCodigo { get; set; }

        [Required(ErrorMessage = "The field Telefonofijo is required")]
        [Display(Name = "Telefonofijo")]
        public string Telefonofijo { get; set; }

        [Required(ErrorMessage = "The field Celular is required")]
        [Display(Name = "Celular")]
        public string Celular { get; set; }

        [Required(ErrorMessage = "The field Email is required")]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "The field Edad is required")]
        [Display(Name = "Edad")]
        public string Edad { get; set; }

        [Required(ErrorMessage = "The field GeneCodigo is required")]
        [Display(Name = "GeneCodigo")]
        public int? GeneCodigo { get; set; }

        [Required(ErrorMessage = "The field Fechanacimiento is required")]
        [Display(Name = "Fechanacimiento")]
        public string Fechanacimiento { get; set; }

        [Required(ErrorMessage = "The field UsuaCodigo is required")]
        [Display(Name = "UsuaCodigo")]
        public int? UsuaCodigo { get; set; }

        [Required(ErrorMessage = "The field BarCodigo is required")]
        [Display(Name = "BarCodigo")]
        public int? BarCodigo { get; set; }

        [Required(ErrorMessage = "The field Foto is required")]
        [Display(Name = "Foto")]
        public string Foto { get; set; }

        [Required(ErrorMessage = "The field Id is required")]
        [Display(Name = "Id")]
        public int? Id { get; set; }
    }
}
