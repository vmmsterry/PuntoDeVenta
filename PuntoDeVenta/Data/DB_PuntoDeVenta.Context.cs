﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PuntoDeVenta.Data
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class PuntoDeVentaEntities2 : DbContext
    {
        public PuntoDeVentaEntities2()
            : base("name=PuntoDeVentaEntities2")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<ARTICULOS> ARTICULOS { get; set; }
        public virtual DbSet<ARTICULOS_VENTA> ARTICULOS_VENTA { get; set; }
        public virtual DbSet<CLIENTES> CLIENTES { get; set; }
        public virtual DbSet<VENTAS> VENTAS { get; set; }
    }
}
