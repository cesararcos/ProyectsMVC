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
    
    public partial class tbUsuarios
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbUsuarios()
        {
            this.tbClientes = new HashSet<tbClientes>();
        }
    
        public int usuaCodigo { get; set; }
        public string usuaDescripcion { get; set; }
        public string usuaLogin { get; set; }
        public string usuaPassword { get; set; }
        public Nullable<int> perfCodigo { get; set; }
        public string usuaImagen { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbClientes> tbClientes { get; set; }
        public virtual tbPerfiles tbPerfiles { get; set; }
    }
}