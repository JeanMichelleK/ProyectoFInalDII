//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Sitio.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Aeropuerto
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Aeropuerto()
        {
            this.Vuelo = new HashSet<Vuelo>();
            this.Vuelo1 = new HashSet<Vuelo>();
        }
    
        public string CodigoA { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public decimal ImpuestoS { get; set; }
        public decimal ImpuestoL { get; set; }
        public string CodigoC { get; set; }
        public bool Activo { get; set; }
    
        public virtual Ciudad Ciudad { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Vuelo> Vuelo { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Vuelo> Vuelo1 { get; set; }
    }
}
