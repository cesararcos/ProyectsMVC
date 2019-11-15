using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectsMVC.Logica.BL
{
    public class MethodPayment
    {
        public List<Models.DB.MethodPayment> GetMethodPayment()
        {
            DAL.Models.ProyectsMVCEntities _context = new DAL.Models.ProyectsMVCEntities();
            var listMethodPayment = (from _MethodPayment in _context.MethodPayment
                                  select new Models.DB.MethodPayment
                                  {
                                      Id = _MethodPayment.Id,
                                      Name = _MethodPayment.Name
                                  }).ToList();

            return listMethodPayment;
        }
    }
}
