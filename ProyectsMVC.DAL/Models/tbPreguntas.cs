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
    
    public partial class tbPreguntas
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbPreguntas()
        {
            this.tbRespuestas = new HashSet<tbRespuestas>();
        }
    
        public int pregCodigo { get; set; }
        public string pregDescripcion { get; set; }
        public Nullable<int> encuCodigo { get; set; }
    
        public virtual tbEncuesta tbEncuesta { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbRespuestas> tbRespuestas { get; set; }
    }
}
