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
    
    public partial class Materiales_Trabajo
    {
        public int idMaterial { get; set; }
        public Nullable<int> idTrabajo { get; set; }
        public Nullable<int> idProducto { get; set; }
        public Nullable<int> cantidad { get; set; }
        public Nullable<int> precio { get; set; }
        public string nombreProducto { get; set; }
        public string nombreEmpleado { get; set; }
        public Nullable<System.DateTime> fecha { get; set; }
    
        public virtual Insumo Insumo { get; set; }
        public virtual ProductoTerminado ProductoTerminado { get; set; }
    }
}
