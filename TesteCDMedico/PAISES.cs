//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TesteCDMedico
{
    using System;
    using System.Collections.Generic;
    
    public partial class PAISES
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PAISES()
        {
            this.ESTADOS = new HashSet<ESTADOS>();
        }
    
        public short IDPais { get; set; }
        public string Pais { get; set; }
        public string Sigla { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ESTADOS> ESTADOS { get; set; }
    }
}
