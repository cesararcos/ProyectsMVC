using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectsMVC.Logica.BL
{
   public class Encuesta
    {
        public List<Models.DB.Encuesta> GetEncuesta()
        {
            DAL.Models.ProyectsMVCEntities _context = new DAL.Models.ProyectsMVCEntities();
            var listEncuesta = (from _Encuesta in _context.Encuesta
                                     //where _Preguntas. == true
                                 select new Models.DB.Encuesta
                                 {
                                     EnCodigo = _Encuesta.enCodigo,
                                     EnDescripcion = _Encuesta.enDescripcion,
                                     //PrueCodigo = _Preguntas.prueCodigo
                                 }).ToList();

            return listEncuesta;
        }

        public void CreateEncuesta(int? RegiCedula)
        {
            DAL.Models.ProyectsMVCEntities _context = new DAL.Models.ProyectsMVCEntities();

            _context.tbRespuestas.Add(new DAL.Models.tbRespuestas
            {
                respDescripcion = RegiCedula.ToString()
            });

            _context.SaveChanges();
        }
    }
}
