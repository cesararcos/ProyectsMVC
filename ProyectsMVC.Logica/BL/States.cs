using System.Collections.Generic;
using System.Linq;

namespace ProyectsMVC.Logica.BL
{
    public class States
    {
        /// <summary>
        /// GET STATES
        /// </summary>
        /// <returns></returns>
        public List<Models.DB.States> GetStates()
        {
            DAL.Models.ProyectsMVCEntities _context = new DAL.Models.ProyectsMVCEntities();
            var listStates = (from _States in _context.States
                              where _States.Active == true
                                  select new Models.DB.States
                                  {
                                      Id = _States.Id,
                                      Name = _States.Name,
                                      Active = _States.Active
                                  }).ToList();

            return listStates;
        }
    }
}
