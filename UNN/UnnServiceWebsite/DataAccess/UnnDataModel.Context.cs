﻿//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DataAccess
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class UNNEntities : DbContext
    {
        public UNNEntities()
            : base("name=UNNEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<building> buildings { get; set; }
        public DbSet<class_assignments> class_assignments { get; set; }
        public DbSet<department> departments { get; set; }
        public DbSet<direction> directions { get; set; }
        public DbSet<group_assignments> group_assignments { get; set; }
        public DbSet<group> groups { get; set; }
        public DbSet<room> rooms { get; set; }
        public DbSet<start_times> start_times { get; set; }
        public DbSet<teacher> teachers { get; set; }
        public DbSet<weekday> weekdays { get; set; }
    }
}
