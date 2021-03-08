namespace SQLProgrammability.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<SQLProgrammability.Models.SQLPro>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "SQLProgrammability.Models.SQLPro";
        }

        protected override void Seed(SQLProgrammability.Models.SQLPro context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
        }
    }
}
