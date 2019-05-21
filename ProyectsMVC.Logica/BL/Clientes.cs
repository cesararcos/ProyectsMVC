using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectsMVC.Logica.BL
{
   public class Clientes
    {
        public List<Models.DB.Clientes> GetClientes()
        {
            DAL.Models.ProyectsMVCEntities _context = new DAL.Models.ProyectsMVCEntities();
            var listClientes = (from _Clientes in _context.tbClientes
                                    //where _Preguntas. == true
                                select new Models.DB.Clientes
                                {
                                    Cedula = _Clientes.regiCedula,
                                    Nombre = _Clientes.regiNombre,
                                    Apellido = _Clientes.regiApellido,
                                    NiveduCodigo = _Clientes.niveduCodigo,
                                    Telefonofijo = _Clientes.regiTelefonofijo,
                                    Celular = _Clientes.regiCelular,
                                    Email = _Clientes.regiEmail,
                                    Edad = _Clientes.regiEmail,
                                    GeneCodigo = _Clientes.geneCodigo,
                                    Fechanacimiento = _Clientes.regiFechanacimiento,
                                    UsuaCodigo = _Clientes.usuaCodigo,
                                    BarCodigo = _Clientes.barCodigo,
                                    Foto = _Clientes.regiFoto
                                    //PrueCodigo = _Preguntas.prueCodigo
                                }).ToList();

            return listClientes;
        }

        public void CreateClientes(int Cedula,
            string Nombre,
            string Apellido,
            int? NiveduCodigo,
            string TelefonoFijo,
            string Celular,
            string Email,
            string Edad,
            int? GeneCodigo,
            string FechaNacimiento,
            int? UsuaCodigo,
            int? BarCodigo,
            string Foto)
        {
            DAL.Models.ProyectsMVCEntities _context = new DAL.Models.ProyectsMVCEntities();

            _context.tbClientes.Add(new DAL.Models.tbClientes
            {
                regiCedula = Cedula,
                regiNombre = Nombre
            });

            _context.SaveChanges();
        }
    }
}
