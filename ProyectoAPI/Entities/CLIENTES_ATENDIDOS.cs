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
    
    public partial class CLIENTES_ATENDIDOS
    {
        public int ID_CLIENTE { get; set; }
        public string CEDULA_CLIENTE { get; set; }
        public string NOMBRE_CLIENTE { get; set; }
        public string CORREO { get; set; }
        public string TELEFONO { get; set; }
        public Nullable<System.DateTime> FECHA { get; set; }
        public int ID_COMPRA { get; set; }
    
        public virtual REGISTRO_COMPRAS REGISTRO_COMPRAS { get; set; }
    }
}
