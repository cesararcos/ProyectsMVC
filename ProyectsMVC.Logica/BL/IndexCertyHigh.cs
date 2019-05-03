using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectsMVC.Logica.BL
{
    public class IndexCertyHigh
    {
        public List<Models.DB.IndexCertyHigh> GetIndexCertyHigh(int? prueCodigo,
            int? niveCodigo)
        {
            DAL.Models.ProyectsMVCEntities db = new DAL.Models.ProyectsMVCEntities();


            var listPruebas = (from _pruebas in db.tbPrueba
                               select _pruebas);

            if (prueCodigo != null)
                listPruebas = listPruebas.Where(x => x.prueCodigo == prueCodigo);
            if (niveCodigo != null)
                listPruebas = listPruebas.Where(x => x.niveCodigo == niveCodigo);

            var listIndexCertyHigh = (from _proyects in listPruebas
                                      select new Models.DB.IndexCertyHigh
                                      {
                                          prueCodigo = _proyects.prueCodigo,
                                          niveCodigo = _proyects.niveCodigo,
                                          prueDescripcion = _proyects.prueNombre
                                      }).ToList();

            return listIndexCertyHigh;
        }
    }
}
