﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CMIForAll.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class CMIModelContainer : DbContext
    {
        public CMIModelContainer()
            : base("name=CMIModelContainer")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<CMI> CMISet { get; set; }
        public virtual DbSet<Perspectiva> Perspectivas { get; set; }
        public virtual DbSet<Objetivo> Objetivos { get; set; }
        public virtual DbSet<Indicador> Indicadores { get; set; }
        public virtual DbSet<Indicador_Dato> Indicador_Datos { get; set; }
        public virtual DbSet<Tipo> Tipos { get; set; }
        public virtual DbSet<Meta> Metas { get; set; }
    }
}
