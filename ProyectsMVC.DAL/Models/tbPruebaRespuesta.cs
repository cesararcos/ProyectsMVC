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
    
    public partial class tbPruebaRespuesta
    {
        public int prueresCodigo { get; set; }
        public Nullable<int> prueCodigo { get; set; }
        public Nullable<int> respCodigo { get; set; }
        public Nullable<int> regiCedula { get; set; }
    
        public virtual tbClientes tbClientes { get; set; }
        public virtual tbPrueba tbPrueba { get; set; }
        public virtual tbRespuestas tbRespuestas { get; set; }
    }
}
