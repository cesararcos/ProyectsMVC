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
    
    public partial class ProductPhotos
    {
        public int Id { get; set; }
        public Nullable<int> ProductId { get; set; }
        public string Guid { get; set; }
        public string Ext { get; set; }
    
        public virtual Products Products { get; set; }
    }
}
