using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectsMVC.Logica.Models.DB
{
    public class Products
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public double? Price { get; set; }
        public double? ShippingCost { get; set; }
        public string Warranty { get; set; }
        public string Description { get; set; }
        public int? Quantity { get; set; }
        public int StateId { get; set; }
        public int CustomerId { get; set; }

        public Categories Categories { get; set; }
        public Customer Customer { get; set; }
        public States States { get; set; }

    }
}
