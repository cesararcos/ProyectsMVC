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
        [Display(Name = "Shipping Cost Seller")]
        public bool ShippingSeller { get; set; }

        [Display(Name = "Shipping Cost Client")]
        public bool ShippingClient { get; set; }
    }
}
