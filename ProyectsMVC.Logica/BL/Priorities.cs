using System.Collections.Generic;
using System.Linq;

namespace ProyectsMVC.Logica.BL
{
    public class Priorities
    {
        /// <summary>
        /// GET PRIORITIES
        /// </summary>
        /// <returns></returns>
        public List<Models.DB.Priorities> GetPriorities()
        {
            DAL.Models.ProyectsMVCEntities _context = new DAL.Models.ProyectsMVCEntities();
            var listPriorities  = (from _Priorities in _context.Priorities
                                   where _Priorities.Active == true
                                  select new Models.DB.Priorities
                                  {
                                      Id = _Priorities.Id,
                                      Name = _Priorities.Name,
                                      Active = _Priorities.Active
                                  }).ToList();

            return listPriorities;
        }
    }
}
