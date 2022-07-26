﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class PROYECTO_PAEntities : DbContext
    {
        public PROYECTO_PAEntities()
            : base("name=PROYECTO_PAEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<CARRITO> CARRITO { get; set; }
        public virtual DbSet<CLIENTES_ATENDIDOS> CLIENTES_ATENDIDOS { get; set; }
        public virtual DbSet<EMPLEADOS> EMPLEADOS { get; set; }
        public virtual DbSet<INVENTARIO_SERVICIOS> INVENTARIO_SERVICIOS { get; set; }
        public virtual DbSet<REGISTRO_COMPRAS> REGISTRO_COMPRAS { get; set; }
        public virtual DbSet<REGISTROS_CARRITO> REGISTROS_CARRITO { get; set; }
        public virtual DbSet<REGISTROS_INVENTARIO> REGISTROS_INVENTARIO { get; set; }
        public virtual DbSet<ROLES> ROLES { get; set; }
        public virtual DbSet<SERVICIOS> SERVICIOS { get; set; }
        public virtual DbSet<METODOS_PAGO> METODOS_PAGO { get; set; }
    
        public virtual int añadeEmpleado(string pNOMBRE, string pAPELLIDO1, string pAPELLIDO2, string pUSERNAME, string pPASSWORD, Nullable<System.DateTime> pFECHAINGRESO, string pCORREO, Nullable<int> pIDROL)
        {
            var pNOMBREParameter = pNOMBRE != null ?
                new ObjectParameter("PNOMBRE", pNOMBRE) :
                new ObjectParameter("PNOMBRE", typeof(string));
    
            var pAPELLIDO1Parameter = pAPELLIDO1 != null ?
                new ObjectParameter("PAPELLIDO1", pAPELLIDO1) :
                new ObjectParameter("PAPELLIDO1", typeof(string));
    
            var pAPELLIDO2Parameter = pAPELLIDO2 != null ?
                new ObjectParameter("PAPELLIDO2", pAPELLIDO2) :
                new ObjectParameter("PAPELLIDO2", typeof(string));
    
            var pUSERNAMEParameter = pUSERNAME != null ?
                new ObjectParameter("PUSERNAME", pUSERNAME) :
                new ObjectParameter("PUSERNAME", typeof(string));
    
            var pPASSWORDParameter = pPASSWORD != null ?
                new ObjectParameter("PPASSWORD", pPASSWORD) :
                new ObjectParameter("PPASSWORD", typeof(string));
    
            var pFECHAINGRESOParameter = pFECHAINGRESO.HasValue ?
                new ObjectParameter("PFECHAINGRESO", pFECHAINGRESO) :
                new ObjectParameter("PFECHAINGRESO", typeof(System.DateTime));
    
            var pCORREOParameter = pCORREO != null ?
                new ObjectParameter("PCORREO", pCORREO) :
                new ObjectParameter("PCORREO", typeof(string));
    
            var pIDROLParameter = pIDROL.HasValue ?
                new ObjectParameter("PIDROL", pIDROL) :
                new ObjectParameter("PIDROL", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("añadeEmpleado", pNOMBREParameter, pAPELLIDO1Parameter, pAPELLIDO2Parameter, pUSERNAMEParameter, pPASSWORDParameter, pFECHAINGRESOParameter, pCORREOParameter, pIDROLParameter);
        }
    
        public virtual int añadeRol(string dESCRIPCION, Nullable<int> iDSERVICIO)
        {
            var dESCRIPCIONParameter = dESCRIPCION != null ?
                new ObjectParameter("DESCRIPCION", dESCRIPCION) :
                new ObjectParameter("DESCRIPCION", typeof(string));
    
            var iDSERVICIOParameter = iDSERVICIO.HasValue ?
                new ObjectParameter("IDSERVICIO", iDSERVICIO) :
                new ObjectParameter("IDSERVICIO", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("añadeRol", dESCRIPCIONParameter, iDSERVICIOParameter);
        }
    
        public virtual int vaciarCarrito()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("vaciarCarrito");
        }
    
        public virtual int vaciarInventario()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("vaciarInventario");
        }
    
        public virtual ObjectResult<validarUsuario_Result> validarUsuario(string pUSERNAME, string pPASSWORD)
        {
            var pUSERNAMEParameter = pUSERNAME != null ?
                new ObjectParameter("PUSERNAME", pUSERNAME) :
                new ObjectParameter("PUSERNAME", typeof(string));
    
            var pPASSWORDParameter = pPASSWORD != null ?
                new ObjectParameter("PPASSWORD", pPASSWORD) :
                new ObjectParameter("PPASSWORD", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<validarUsuario_Result>("validarUsuario", pUSERNAMEParameter, pPASSWORDParameter);
        }
    
        public virtual int cambiarContraseña(string pUSERNAME, string pPASSWORD)
        {
            var pUSERNAMEParameter = pUSERNAME != null ?
                new ObjectParameter("PUSERNAME", pUSERNAME) :
                new ObjectParameter("PUSERNAME", typeof(string));
    
            var pPASSWORDParameter = pPASSWORD != null ?
                new ObjectParameter("PPASSWORD", pPASSWORD) :
                new ObjectParameter("PPASSWORD", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("cambiarContraseña", pUSERNAMEParameter, pPASSWORDParameter);
        }
    }
}
