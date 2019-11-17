using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectsMVC.Logica.Models.BindingModel
{
    public class CustomerCreateBindingModel
    {
        [Required(ErrorMessage = "The Document Type is required")]
        [Display(Name = "Document Type")]
        public int? DocumentTypeId { get; set; }

        [Required(ErrorMessage = "The Document Number is required")]
        [Display(Name = "Document Number")]
        public string DocumentNumber { get; set; }

        [Required(ErrorMessage = "The First Name is required")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "The Second Name is required")]
        [Display(Name = "Second Name")]
        public string SecondName { get; set; }

        [Required(ErrorMessage = "The Surname is required")]
        [Display(Name = "Surname")]
        public string Surname { get; set; }

        [Required(ErrorMessage = "The SecondSurname is required")]
        [Display(Name = "SecondSurname")]
        public string SecondSurname { get; set; }

        [Required(ErrorMessage = "The Telephone is required")]
        [Display(Name = "Telephone")]
        public string Telephone { get; set; }

        [Required(ErrorMessage = "The Address is required")]
        [Display(Name = "Address")]
        public string Address { get; set; }

        [Required(ErrorMessage = "The City is required")]
        [Display(Name = "City")]
        public int? CityId { get; set; }
        public int Id { get; set; }


    }
}
