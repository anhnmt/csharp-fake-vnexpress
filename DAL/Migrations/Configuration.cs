using System;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;

namespace DAL.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<DAL.DataMapping.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
            ContextKey = "DAL.DataMapping.ApplicationDbContext";
        }

        //protected override void Seed(DAL.DataMapping.ApplicationDbContext context)
        //{
        //
        //}
    }
}