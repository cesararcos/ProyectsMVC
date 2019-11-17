using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectsMVC.Logica.Models.BindingModel
{
    public class SearchCreateProducts
    {
        
        [Display(Name = "Category")]
        public int? CategoryId { get; set; }
        
        [Display(Name = "product name")]
        public string ProdName { get; set; }
    }
}
