using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectsMVC.Logica.BL
{
    public class DocumentTypes
    {
        public List<Models.DB.DocumentTypes> GetDocumentTypes()
        {
            DAL.Models.ProyectsMVCEntities _context = new DAL.Models.ProyectsMVCEntities();
            var listDocumentTypes = (from _DocumentTypes in _context.DocumentTypes
                              select new Models.DB.DocumentTypes
                              {
                                  Id = _DocumentTypes.Id,
                                  Name = _DocumentTypes.Name
                              }).ToList();

            return listDocumentTypes;
        }
    }
}
