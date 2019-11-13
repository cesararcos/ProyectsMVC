using System.ComponentModel.DataAnnotations;

namespace ProyectsMVC.Logica.Models.ViewModel
{
    public class ProductsCreateDetailsViewModel
    {
        [Display(Name = "Category")]
        public string Category { get; set; }

        [Display(Name = "Name")]
        public string Name { get; set; }

        [Display(Name = "Price")]
        public double? Price { get; set; }

        [Display(Name = "Shipping Cost")]
        public double? ShippingCost { get; set; }

        [Display(Name = "Quantity")]
        public int? Quantity { get; set; }

        [Display(Name = "Warranty")]
        public string Warranty { get; set; }

        [Display(Name = "States")]
        public string States { get; set; }

        [Display(Name = "Description")]
        public string Description { get; set; }

        public int Id { get; set; }
    }
}
