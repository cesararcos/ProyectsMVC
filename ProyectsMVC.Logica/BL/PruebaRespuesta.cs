using System.Collections.Generic;
using System.Linq;

namespace ProyectsMVC.Logica.BL
{
    public class PruebaRespuesta
    {
        public List<Models.DB.PruebaRespuesta> GetPruebaRespuestas(int clienteCedula)
        {
            var context = new DAL.Models.ProyectsMVCEntities();

            var pruebaRespuesta = context.tbPruebaRespuesta.Where(x => x.regiCedula == clienteCedula)
                .Select(x => new Models.DB.PruebaRespuesta
                {
                    Codigo = x.prueresCodigo,
                    ClienteCedula = x.regiCedula.Value,
                    PreguntaCodigo = x.pregCodigo.Value,
                    PruebaCodigo = x.prueCodigo.Value,
                    RespuestaCodigo = x.respCodigo.Value
                }).ToList();

            return pruebaRespuesta;
        }
    }
}
