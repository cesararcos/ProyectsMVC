using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectsMVC.Logica.BL
{
    public class Categories
    {
        public List<Models.DB.Categories> GetCategories()
        {
            DAL.Models.ProyectsMVCEntities _context = new DAL.Models.ProyectsMVCEntities();
            var listCategories = (from _Categories in _context.Categories
                                  select new Models.DB.Categories
                                  {
                                      Id = _Categories.Id,
                                      Name = _Categories.Name
                                  }).ToList();

            return listCategories;
        }
    }
}
