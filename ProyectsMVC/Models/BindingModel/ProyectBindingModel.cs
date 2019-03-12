using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ProyectsMVC.Models.BindingModel
{
    public class InicioProyectBindingModel
    {
        [Required(ErrorMessage = "The field Name is required")]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "The field Name is required")]
        [Display(Name = "Title")]
        public string Title { get; set; }

        [Required(ErrorMessage = "The field Name is required")]
        [Display(Name = "Details")]
        public string Details { get; set; }

        [Required(ErrorMessage = "The field Name is required")]
        [Display(Name = "PercentageAdvance")]
        public double? PercentageAdvance { get; set; }

        [Required(ErrorMessage = "The field Name is required")]
        [Display(Name = "ExpectedCompletionDate")]
        public DateTime? ExpectedCompletionDate { get; set; }

    }
}