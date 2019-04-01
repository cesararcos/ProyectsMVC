using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectsMVC.Logica.BL
{
   public class Activities
    {
        /// <summary>
        /// GET ACTIVITIES
        /// </summary>
        /// <returns></returns>
        public List<Models.DB.Activities> GetActivities()
        {
            DAL.Models.ProyectsMVCEntities _context = new DAL.Models.ProyectsMVCEntities();
            var listActivities = (from _activities in _context.Activities
                                  where _activities.Active == true
                                  select new Models.DB.Activities
                                  {
                                      Id = _activities.Id,
                                      Name = _activities.Name,
                                      Active = _activities.Active
                                  }).ToList();

            return listActivities;
        }
    }
}
