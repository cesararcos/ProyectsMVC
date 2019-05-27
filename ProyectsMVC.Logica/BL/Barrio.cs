using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectsMVC.Logica.BL
{
   public class Barrio
    {
        public List<Models.DB.Barrio> GetBarrio()
        {
            DAL.Models.ProyectsMVCEntities _context = new DAL.Models.ProyectsMVCEntities();
            var listBarrio = (from _Barrio in _context.tbBarrio
                              select new Models.DB.Barrio
                              {
                                  Codigo = _Barrio.barCodigo,
                                  Descripcion = _Barrio.barDescripcion
                              }).ToList();

            return listBarrio;
        }
    }
}
