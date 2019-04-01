using System;

namespace ProyectsMVC.Logica.Models.DB
{
    public class Tasks
    {
        public Tasks()
        {
            Proyects = new Proyects();
            States = new States();
            Priorities = new Priorities();
            Activities = new Activities();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string Details { get; set; }
        public DateTime? ExpirationDate { get; set; }
        public bool? IsCompleted { get; set; }
        public int? Effort { get; set; }
        public int? RemainigWork { get; set; }

        public int? StateId { get; set; }
        public int? ActivityId { get; set; }
        public int? PriorityId { get; set; }
        public int? ProyectId { get; set; }

        public Proyects Proyects { get; set; }
        public States States { get; set; }
        public Priorities Priorities { get; set; }
        public Activities Activities { get; set; }
    }
}
