//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DColor.DB
{
    using System;
    using System.Collections.Generic;
    
    public partial class Estado_Trabajo
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Estado_Trabajo()
        {
            this.ProductoTerminadoes = new HashSet<ProductoTerminado>();
        }
    
        public int idEstado { get; set; }
        public string estadoProductoTerminado { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProductoTerminado> ProductoTerminadoes { get; set; }
    }
}
