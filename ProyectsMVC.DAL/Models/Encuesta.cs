//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ProyectsMVC.DAL.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Encuesta
    {
        public int enCodigo { get; set; }
        public string enDescripcion { get; set; }
        public Nullable<int> regiCedula { get; set; }
    
        public virtual tbClientes tbClientes { get; set; }
    }
}