using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectsMVC.Models.ViewModel
{
    public class InicioProyectViewModel

    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public string Details { get; set; }
        public double? PercentageAdvance { get; set; }
        public DateTime? ExpectedCompletionDate { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdateAt { get; set; }


    }
}