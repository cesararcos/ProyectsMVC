using System.Collections.Generic;

namespace ProyectsMVC.Logica.Models.ViewModel
{
    public class PreguntasGetRespuestasViewModel
    {
        public int Codigo { get; set; }
        public string Descripcion { get; set; }
        public List<Respuestas> Respuestas { get; set; }
    }

    public class Respuestas
    {
        public int Codigo { get; set; }
        public string Descripcion { get; set; }
    }
}
