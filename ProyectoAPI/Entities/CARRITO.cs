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
    
    public partial class CARRITO
    {
        public int ID_PROD { get; set; }
        public string DESCRIPCION { get; set; }
        public decimal PRECIO { get; set; }
        public int CANTIDAD { get; set; }
        public decimal TOTAL { get; set; }
        public int ID_PRODUCTO { get; set; }
    
        public virtual INVENTARIO_SERVICIOS INVENTARIO_SERVICIOS { get; set; }
    }
}
