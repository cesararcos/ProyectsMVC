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
    
    public partial class tbClientes
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbClientes()
        {
            this.tbPruebaRespuesta = new HashSet<tbPruebaRespuesta>();
            this.Encuesta = new HashSet<Encuesta>();
        }
    
        public int regiCedula { get; set; }
        public string regiNombre { get; set; }
        public string regiApellido { get; set; }
        public Nullable<int> niveduCodigo { get; set; }
        public string regiTelefonofijo { get; set; }
        public string regiCelular { get; set; }
        public string regiEmail { get; set; }
        public string regiEdad { get; set; }
        public Nullable<int> geneCodigo { get; set; }
        public string regiFechanacimiento { get; set; }
        public Nullable<int> usuaCodigo { get; set; }
        public Nullable<int> barCodigo { get; set; }
        public string regiFoto { get; set; }
        public string Id { get; set; }
    
        public virtual tbBarrio tbBarrio { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbPruebaRespuesta> tbPruebaRespuesta { get; set; }
        public virtual tbGenero tbGenero { get; set; }
        public virtual tbNivelEducativo tbNivelEducativo { get; set; }
        public virtual tbUsuarios tbUsuarios { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Encuesta> Encuesta { get; set; }
        public virtual AspNetUsers AspNetUsers { get; set; }
    }
}
