namespace ProyectsMVC.Logica.Models.DB
{
    public class Preguntas
    {
        public int PregCodigo { get; set; }
        public string PregDescripcion { get; set; }
        public int PrueCodigo { get; set; }

        public Prueba Prueba { get; set; }
    }
}
