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
            DAL.Models.ProyectsMVCEntities db = new DAL.Models.ProyectsMVCEntities();
            var listClientes = (from _Clientes in db.tbClientes
                                join _Niveles in db.tbNiveles on _Clientes.niveduCodigo equals _Niveles.niveCodigo
                                join _Genero in db.tbGenero on _Clientes.geneCodigo equals _Genero.geneCodigo
                                join _Barrio in db.tbBarrio on _Clientes.barCodigo equals _Barrio.barCodigo
                                select new Models.DB.Clientes
                                {
                                    Cedula = _Clientes.regiCedula,
                                    Nombre = _Clientes.regiNombre,
                                    Apellido = _Clientes.regiApellido,
                                    NiveduCodigo = _Clientes.niveduCodigo,
                                    Niveles = new Models.DB.Niveles
                                    {
                                        niveDescripcion = _Niveles.niveDescripcion
                                    },
                                    Telefonofijo = _Clientes.regiTelefonofijo,
                                    Celular = _Clientes.regiCelular,
                                    Email = _Clientes.regiEmail,
                                    Edad = _Clientes.regiEmail,
                                    GeneCodigo = _Clientes.geneCodigo,
                                    Genero = new Models.DB.Genero
                                    {
                                        Descripcion = _Genero.geneDescripcion
                                    },
                                    Fechanacimiento = _Clientes.regiFechanacimiento,
                                    BarCodigo = _Clientes.barCodigo,
                                    Barrio = new Models.DB.Barrio
                                    {
                                        Descripcion = _Barrio.barDescripcion
                                    },
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
            int? BarCodigo,
            string Foto)
        {
            DAL.Models.ProyectsMVCEntities _context = new DAL.Models.ProyectsMVCEntities();

            _context.tbClientes.Add(new DAL.Models.tbClientes
            {
                regiCedula = Cedula,
                regiNombre = Nombre,
                regiApellido = Apellido,
                niveduCodigo = NiveduCodigo,
                regiTelefonofijo = TelefonoFijo,
                regiCelular = Celular,
                regiEmail = Email,
                regiEdad = Edad,
                geneCodigo = GeneCodigo,
                regiFechanacimiento = FechaNacimiento,
                barCodigo = BarCodigo,
                regiFoto = Foto
            });

            _context.SaveChanges();
        }
    }
}
