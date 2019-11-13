using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectsMVC.Logica.BL
{
    public class Sales
    {
        public List<Models.DB.Sales> GetSale()
        {
            DAL.Models.ProyectsMVCEntities db = new DAL.Models.ProyectsMVCEntities();
            var listSales = (from _Sales in db.Sales
                               select new Models.DB.Sales
                               {
                                   Id = _Sales.Id
                               }

                ).ToList();

            return listSales;
        }
    }
}
