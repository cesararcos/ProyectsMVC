using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectsMVC.Logica.Models.ViewModel
{
   public class ResponseViewModel
    {
        public bool IsSuccessful { get; set; }
        public List<string> Errors { get; set; }
    }
}
