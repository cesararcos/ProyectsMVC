using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectsMVC.Logica.BL
{
    public class Cities
    {
        public List<Models.DB.Cities> GetCities()
        {
            DAL.Models.ProyectsMVCEntities _context = new DAL.Models.ProyectsMVCEntities();
            var listCities = (from _Cities in _context.Cities
                                  select new Models.DB.Cities
                                  {
                                      Id = _Cities.Id,
                                      Name = _Cities.Name
                                  }).ToList();

            return listCities;
        }
    }
}
