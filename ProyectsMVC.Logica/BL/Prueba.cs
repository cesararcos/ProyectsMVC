using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectsMVC.Logica.BL
{
    public class Prueba
    {
        public List<Models.DB.Prueba> GetPrueba(int? prueCodigo,
            int? niveCodigo)
        {
            DAL.Models.ProyectsMVCEntities db = new DAL.Models.ProyectsMVCEntities();

            var listPruebaEF = (from _prueba in db.tbPrueba
                                join _niveles in db.tbNiveles on _prueba.niveCodigo equals _niveles.niveCodigo
                                select new Models.DB.Prueba
                                {
                                    prueCodigo = _prueba.prueCodigo,
                                    niveCodigo = _prueba.niveCodigo,
                                    Niveles = new Models.DB.Niveles
                                    {
                                        Descripcion = _niveles.niveDescripcion
                                    },
                                    prueDescripcion = _prueba.prueNombre
                                }).ToList();

            if (prueCodigo != null)
                listPruebaEF = listPruebaEF.Where(x => x.prueCodigo == prueCodigo).ToList();
            if (niveCodigo != null)
                listPruebaEF = listPruebaEF.Where(x => x.niveCodigo == niveCodigo).ToList();            

            return listPruebaEF;
        }
    }
}
