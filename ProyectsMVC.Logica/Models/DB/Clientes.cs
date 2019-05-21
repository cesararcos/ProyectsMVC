using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectsMVC.Logica.Models.DB
{
   public class Clientes
    {
        public int Cedula { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int? NiveduCodigo { get; set; }
        public string Telefonofijo { get; set; }
        public string Celular { get; set; }
        public string Email { get; set; }
        public string Edad { get; set; }
        public int? GeneCodigo { get; set; }
        public string Fechanacimiento { get; set; }
        public int? UsuaCodigo { get; set; }
        public int? BarCodigo { get; set; }
        public string Foto { get; set; }
        public int? Id { get; set; }
    }
}
