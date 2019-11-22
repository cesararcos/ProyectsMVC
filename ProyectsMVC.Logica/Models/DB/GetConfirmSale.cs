using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectsMVC.Logica.Models.DB
{
    public class GetConfirmSale
    {
        public int Id { get; set; }
        public string ProductsName { get; set; }
        public string Description { get; set; }
        public string CategoryName { get; set; }
        public int Quantity { get; set; }
        public double Subtotal { get; set; }
        public string MetodoPago { get; set; }
        public double Total { get; set; }
        public string Guid { get; set; }
    }
}
