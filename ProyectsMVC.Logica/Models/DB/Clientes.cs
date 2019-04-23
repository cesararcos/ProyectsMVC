using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectsMVC.Logica.Models.DB
{
   public class Clientes
    {
        public int RegiCedula { get; set; }
        public string RegiNombre { get; set; }
        public string RegiApellido { get; set; }
        public int NiveduCodigo { get; set; }
        public string RegiTelefonofijo { get; set; }
        public string RegiCelular { get; set; }
        public string RegiEmail { get; set; }
        public string RegiEdad { get; set; }
        public int GeneCodigo { get; set; }
        public string RegiFechanacimiento { get; set; }
        public int UsuaCodigo { get; set; }
        public int BarCodigo { get; set; }
        public string RegiFoto { get; set; }
    }
}
