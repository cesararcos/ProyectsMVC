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
    
    public partial class tbRespuestas
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbRespuestas()
        {
            this.tbPruebaRespuesta = new HashSet<tbPruebaRespuesta>();
        }
    
        public int respCodigo { get; set; }
        public string respDescripcion { get; set; }
        public Nullable<int> pregCodigo { get; set; }
        public Nullable<bool> respCorrectas { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbPruebaRespuesta> tbPruebaRespuesta { get; set; }
        public virtual tbPreguntas tbPreguntas { get; set; }
    }
}