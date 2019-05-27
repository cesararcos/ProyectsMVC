using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectsMVC.Logica.BL
{
    public class Preguntas
    {
        public List<Models.ViewModel.PreguntasGetRespuestasViewModel> GetPreguntas(int? pruebaId)
        {


            DAL.Models.ProyectsMVCEntities _context = new DAL.Models.ProyectsMVCEntities();
            var listPreguntas = (from _Preguntas in _context.tbPreguntas
                                 where _Preguntas.pregCodigo == pruebaId
                                 select new Models.ViewModel.PreguntasGetRespuestasViewModel
                                 {
                                     Codigo = _Preguntas.pregCodigo,
                                     Descripcion = _Preguntas.pregDescripcion,
                                     //PrueCodigo = _Preguntas.prueCodigo
                                 }).ToList();

            foreach (var item in listPreguntas)
            {
                item.Respuestas = (from _Respuestas in _context.tbRespuestas
                                   where _Respuestas.pregCodigo == item.Codigo
                                   select new Models.ViewModel.Respuestas
                                   {
                                       Codigo = _Respuestas.respCodigo,
                                       Descripcion = _Respuestas.respDescripcion,
                                       //PrueCodigo = _Preguntas.prueCodigo
                                   }).ToList();
            }
            return listPreguntas;
        }

        public void CreatePreguntas(int PrueCodigo,
            int RespCodigo,
            int RegiCedula,
            int PregCodigo)
        {
            DAL.Models.ProyectsMVCEntities _context = new DAL.Models.ProyectsMVCEntities();

            _context.tbPruebaRespuesta.Add(new DAL.Models.tbPruebaRespuesta
            {
                prueCodigo = PrueCodigo,
                respCodigo = RespCodigo,
                regiCedula = RegiCedula,
                pregCodigo = PregCodigo
               
            });

            _context.SaveChanges();
        }
    }
}
