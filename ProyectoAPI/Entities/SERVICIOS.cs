//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ProyectoAPI.Entities
{
    using System;
    using System.Collections.Generic;
    
    public partial class SERVICIOS
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SERVICIOS()
        {
            this.EMPLEADOS = new HashSet<EMPLEADOS>();
            this.INVENTARIO_SERVICIOS = new HashSet<INVENTARIO_SERVICIOS>();
            this.REGISTROS_INVENTARIO = new HashSet<REGISTROS_INVENTARIO>();
            this.ROLES = new HashSet<ROLES>();
        }
    
        public int ID_SERVICIO { get; set; }
        public string NOMBRE_SERVICIO { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EMPLEADOS> EMPLEADOS { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<INVENTARIO_SERVICIOS> INVENTARIO_SERVICIOS { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<REGISTROS_INVENTARIO> REGISTROS_INVENTARIO { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ROLES> ROLES { get; set; }
    }
}
