﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace barCode.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class barCodePruebaEntities : DbContext
    {
        public barCodePruebaEntities()
            : base("name=barCodePruebaEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Administradores> Administradores { get; set; }
        public virtual DbSet<Boleta> Boleta { get; set; }
        public virtual DbSet<Cliente> Cliente { get; set; }
        public virtual DbSet<Comuna> Comuna { get; set; }
        public virtual DbSet<Cuentas> Cuentas { get; set; }
        public virtual DbSet<Direccion> Direccion { get; set; }
        public virtual DbSet<Distribuidor> Distribuidor { get; set; }
        public virtual DbSet<Producto> Producto { get; set; }
        public virtual DbSet<Region> Region { get; set; }
        public virtual DbSet<Detalle> Detalle { get; set; }
        public virtual DbSet<Historial> Historial { get; set; }
        public virtual DbSet<Categoria> Categoria { get; set; }
    }
}
