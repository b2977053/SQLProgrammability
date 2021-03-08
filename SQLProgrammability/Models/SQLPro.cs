namespace SQLProgrammability.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Data.Entity.ModelConfiguration.Conventions;

    public partial class SQLPro : DbContext
    {
        public SQLPro()
            : base("name=SQLPro")
        {
        }

        public virtual DbSet<ProStoredProcedure> ProStoredProcedure { get; set; }
        public virtual DbSet<ProFunction> ProFunction { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
