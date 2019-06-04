using System.Collections.Generic;
using System.Linq;

namespace ProyectsMVC.Logica.BL
{
    public class TablaRespuestas
    {
        public List<Models.DB.TablaRespuestas> GetTablaRespuestas(int clienteCedula,
            int pruebaId)
        {
            DAL.Models.ProyectsMVCEntities _context = new DAL.Models.ProyectsMVCEntities();

            var listTabla = (from _tabla in _context.tbPruebaRespuesta
                             join _Preguntas in _context.tbPreguntas on _tabla.pregCodigo equals _Preguntas.pregCodigo
                             join _respuestas in _context.tbRespuestas on _tabla.respCodigo equals _respuestas.respCodigo
                             join _prueba in _context.tbPrueba on _tabla.prueCodigo equals _prueba.prueCodigo
                             join _Clientes in _context.tbClientes on _tabla.regiCedula equals _Clientes.regiCedula

                             where _Clientes.regiCedula.Equals(clienteCedula) && _prueba.prueCodigo.Equals(pruebaId)
                             
                             select new Models.DB.TablaRespuestas
                             {
                                 Codigo = _tabla.prueresCodigo,
                                 Prueba =_prueba.prueNombre,
                                 Respuesta=_respuestas.respDescripcion,
                                 Pregunta=_Preguntas.pregDescripcion,
                                 


                             }).ToList();

            return listTabla;
        }
    }
}
