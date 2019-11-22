using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectsMVC.Logica.Models.ViewModel
{
    public class ConfirmCreateSaleViewModel
    {   
        [Display(Name = "Products Name")]
        public string productsName { get; set; }

        [Display(Name = "Description")]
        public string description { get; set; }

        [Display(Name = "Category Name")]
        public string categoryName { get; set; }

        [Display(Name = "Quantity")]
        public int quantity { get; set; }

        [Display(Name = "Subtotal")]
        public double subtotal { get; set; }

        [Display(Name = "Metodo Pago")]
        public string metodoPago { get; set; }

        [Display(Name = "Total")]
        public double total { get; set; }

        public string guid { get; set; }

        public int id { get; set; }
    }
}
