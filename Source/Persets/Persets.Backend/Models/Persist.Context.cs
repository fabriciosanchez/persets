﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Persets.Backend.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class PersetsDBEntities : DbContext
    {
        public PersetsDBEntities()
            : base("name=PersetsDBEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Categories> Categories { get; set; }
        public virtual DbSet<Content> Content { get; set; }
        public virtual DbSet<ContentShareBetweenUsers> ContentShareBetweenUsers { get; set; }
        public virtual DbSet<Logs> Logs { get; set; }
        public virtual DbSet<Users> Users { get; set; }
    }
}
