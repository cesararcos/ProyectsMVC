using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectsMVC.Logica.Models.ViewModel
{
    public class ShippingCreateCost
    {
        [Display(Name = "Retiro en domicilio del vendedor - Cali")]
        public bool ShippingSeller { get; set; }

        [Display(Name = "Normal a domicilio")]
        public bool ShippingClient { get; set; }

        [Display(Name = "MethodPayment")]
        public int? MethodPayment { get; set; }
    }
}
