using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectsMVC.Logica.BL
{
    public class States
    {
        public List<Models.DB.States> GetStates()
        {
            DAL.Models.ProyectsMVCEntities _context = new DAL.Models.ProyectsMVCEntities();
            var listStates = (from _States in _context.States
                                  select new Models.DB.States
                                  {
                                      Id = _States.Id,
                                      Name = _States.Name
                                  }).ToList();

            return listStates;
        }
    }
}
