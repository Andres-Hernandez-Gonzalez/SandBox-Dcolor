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
    
    public partial class ProductoTerminado
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ProductoTerminado()
        {
            this.Materiales_Trabajo = new HashSet<Materiales_Trabajo>();
        }
    
        public int idProductoTerminado { get; set; }
        public Nullable<int> idEmpleado { get; set; }
        public Nullable<int> idEstadoTrabajo { get; set; }
        public string descripcion { get; set; }
        public Nullable<System.DateTime> fecha { get; set; }
        public string nombre { get; set; }
        public Nullable<int> idCliente { get; set; }
    
        public virtual Cliente Cliente { get; set; }
        public virtual Empleado Empleado { get; set; }
        public virtual Estado_Trabajo Estado_Trabajo { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Materiales_Trabajo> Materiales_Trabajo { get; set; }
    }
}
