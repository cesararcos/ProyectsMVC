using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectsMVC.Logica.BL
{
    public class NivelEducativo
    {
        public List<Models.DB.NivelEducativo> GetNivelEducativo()
        {
            DAL.Models.ProyectsMVCEntities _context = new DAL.Models.ProyectsMVCEntities();
            var listNivelEducativo = (from _Niveles in _context.tbNivelEducativo
                                      select new Models.DB.NivelEducativo
                                      {
                                          Codigo = _Niveles.niveduCodigo,
                                          Descripcion = _Niveles.niveduDescripcion
                                      }).ToList();

            return listNivelEducativo;
        }
    }
}
