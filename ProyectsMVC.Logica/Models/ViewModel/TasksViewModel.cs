using System;
using System.ComponentModel.DataAnnotations;

namespace ProyectsMVC.Logica.Models.ViewModel
{
    #region TasksIndexViewModel
    public class TasksIndexViewModel
    {
        [Display(Name = "Id")]
        public int Id { get; set; }

        [Display(Name = "Title")]
        public string Title { get; set; }

        [Display(Name = "Details")]
        public string Details { get; set; }

        [Display(Name = "ExpirationDate")]
        public DateTime? ExpirationDate { get; set; }

        [Display(Name = "IsCompleted")]
        public bool? IsCompleted { get; set; }

        [Display(Name = "Effort")]
        public int? Effort { get; set; }

        [Display(Name = "RemainigWork")]
        public int? RemainigWork { get; set; }

        [Display(Name = "States")]
        public string States { get; set; }

        [Display(Name = "Activity")]
        public string Activity { get; set; }

        [Display(Name = "Priority")]
        public string Priority { get; set; }

        [Display(Name = "Proyect")]
        public string Proyect { get; set; }

    }
    #endregion

    #region TasksGetTasksCalendarViewModel
    public class TasksGetTasksCalendarViewModel
    {
        public int Id { get; set; }
        public string Start { get; set; }
        public string End { get; set; }
        public string Title { get; set; }
        public string Color { get; set; }
        public bool AllDay { get; set; }
        public string TextColor { get; set; }
    } 
    #endregion
}
