using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectsMVC.Logica.BL
{
    public class Preguntas
    {
        public List<Models.DB.Preguntas> GetPreguntas()
        {
            //DAL.Models.ProyectsMVCEntities db = new DAL.Models.ProyectsMVCEntities();

            //var listPreguntasEF = (from _preguntas in db.tbPreguntas
            //                    join _pruebas in db.tbPrueba on _preguntas.prueCodigo equals _pruebas.prueCodigo
            //                    select new Models.DB.Preguntas
            //                    {
            //                        PregCodigo = _preguntas.pregCodigo,
            //                        PrueCodigo = _pruebas.prueCodigo,
            //                        Prueba = new Models.DB.Prueba
            //                        {
            //                            prueDescripcion = _pruebas.prueNombre
            //                        },
            //                        PregDescripcion = _preguntas.pregDescripcion
            //                    }).ToList();

            //if (prueCodigo != null)
            //    listPreguntasEF = listPreguntasEF.Where(x => x.PrueCodigo == prueCodigo).ToList();
            //if (pregCodigo != null)
            //    listPreguntasEF = listPreguntasEF.Where(x => x.PregCodigo == pregCodigo).ToList();

            //return listPreguntasEF;

            DAL.Models.ProyectsMVCEntities _context = new DAL.Models.ProyectsMVCEntities();
            var listPreguntas = (from _Preguntas in _context.tbPreguntas
                              //where _Preguntas. == true
                              select new Models.DB.Preguntas
                              {
                                  PregCodigo = _Preguntas.pregCodigo,
                                  PregDescripcion = _Preguntas.pregDescripcion,
                                  //PrueCodigo = _Preguntas.prueCodigo
                              }).ToList();

            return listPreguntas;
        }

        public void CreatePreguntas(int? preCodigo)
        {
            DAL.Models.ProyectsMVCEntities _context = new DAL.Models.ProyectsMVCEntities();

            _context.tbRespuestas.Add(new DAL.Models.tbRespuestas
            {
                respDescripcion = preCodigo.ToString()
            });

            _context.SaveChanges();
        }
    }
}
