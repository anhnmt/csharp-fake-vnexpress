using DAL.Common;
using DAL.DataMapping;
using System;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;

namespace DAL.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
            ContextKey = "DAL.DataMapping.ApplicationDbContext";
        }

        protected override void Seed(ApplicationDbContext context)
        {
            context.Users.AddOrUpdate(x => x.ID,
                new User()
                {
                    ID = 1,
                    Name = "Admin",
                    Username = "admin",
                    Password = Utils.HashPassword("123456")
                }
            );
        }
    }
}