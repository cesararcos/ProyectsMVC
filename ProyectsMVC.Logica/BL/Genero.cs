using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectsMVC.Logica.BL
{
   public class Genero
    {
        public List<Models.DB.Genero> GetGenero()
        {
            DAL.Models.ProyectsMVCEntities _context = new DAL.Models.ProyectsMVCEntities();
            var listGenero = (from _Genero in _context.tbGenero
                               select new Models.DB.Genero
                               {
                                   Codigo = _Genero.geneCodigo,
                                   Descripcion = _Genero.geneDescripcion
                               }).ToList();

            return listGenero;
        }
    }
}
