//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DataLayer.Repository
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class PPMEntities : DbContext
    {
        public PPMEntities()
            : base("name=PPMEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<defect> defect { get; set; }
        public virtual DbSet<diary> diary { get; set; }
        public virtual DbSet<equipment_master> equipment_master { get; set; }
        public virtual DbSet<FinancialCases> FinancialCases { get; set; }
        public virtual DbSet<maintenance_master> maintenance_master { get; set; }
        public virtual DbSet<maintenance_schedule> maintenance_schedule { get; set; }
        public virtual DbSet<ship> ship { get; set; }
        public virtual DbSet<Task> Task { get; set; }
    
        public virtual int sp_eqpt_list()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_eqpt_list");
        }
    }
}
