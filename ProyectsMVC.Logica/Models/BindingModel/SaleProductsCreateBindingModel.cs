using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectsMVC.Logica.Models.BindingModel
{
    public class SaleProductsCreateBindingModel
    {
        [Required(ErrorMessage = "The name is required")]
        [Display(Name = "Name product")]
        public string Name { get; set; }

        [Required(ErrorMessage = "The description is required")]
        [Display(Name = "Describe your product")]
        public string Description { get; set; }

        [Required(ErrorMessage = "The category is required")]
        [Display(Name = "Category")]
        public int? Category { get; set; }

        [Required(ErrorMessage = "The state is required")]
        [Display(Name = "product status")]
        public int? States { get; set; }

        [Required(ErrorMessage = "The quantity is required")]
        [Display(Name = "Quantity")]
        public int Quantity { get; set; }

        [Required(ErrorMessage = "The price is required")]
        [Display(Name = "Price")]
        public double Price { get; set; }

        [Required(ErrorMessage = "The shipping cost is required")]
        [Display(Name = "Shipping Cost")]
        public double ShippingCost { get; set; }

        [Required(ErrorMessage = "The warranty is required")]
        [Display(Name = "Warranty")]
        public string Warranty { get; set; }

        [Display(Name = "Load Product Image")]
        public string Photo { get; set; }
    }
}
