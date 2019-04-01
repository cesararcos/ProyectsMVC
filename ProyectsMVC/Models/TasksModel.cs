using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectsMVC.Models
{
    public class TasksModel
    {
        public int Codigo { get; set; }
        public string Titulo { get; set; }
        public string Asunto { get; set; }
        public string FechaVencimiento { get; set; }
        public string Estado { get; set; }
        public string Prioridad { get; set; }
        public string Descripcion { get; set; }
    }
}