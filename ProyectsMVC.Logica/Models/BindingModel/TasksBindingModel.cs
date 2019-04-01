using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectsMVC.Logica.Models.BindingModel
{
   public class TasksCreateBindingModel
    {
        [Required(ErrorMessage = "The field Title is required")]
        [Display(Name = "Title")]
        public string Title { get; set; }

        [Required(ErrorMessage = "The field Details is required")]
        [Display(Name = "Details")]
        public string Details { get; set; }

        [Required(ErrorMessage = "The field Expiration Date is required")]
        [Display(Name = "Expiration Date")]
        public DateTime? ExpirationDate { get; set; }

        [Required(ErrorMessage = "The field IsCompleted is required")]
        [Display(Name = "IsCompleted")]
        public bool IsCompleted { get; set; }

        [Required(ErrorMessage = "The field Effort is required")]
        [Display(Name = "Effort")]
        public int? Effort { get; set; }

        [Required(ErrorMessage = "The field RemainigWork is required")]
        [Display(Name = "RemainigWork")]
        public int? RemainigWork { get; set; }

        [Required(ErrorMessage = "The field StateId is required")]
        [Display(Name = "StateId")]
        public int? StateId { get; set; }

        [Required(ErrorMessage = "The field Activity is required")]
        [Display(Name = "ActivityId")]
        public int? ActivityId { get; set; }

        [Required(ErrorMessage = "The field Priority is required")]
        [Display(Name = "PriorityId")]
        public int? PriorityId { get; set; }

        [Required(ErrorMessage = "The field proyect is required")]
        [Display(Name = "proyectId")]
        public int? proyectId { get; set; }
    }
}
