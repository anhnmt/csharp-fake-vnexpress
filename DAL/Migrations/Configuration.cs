
using System;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using DAL.Common;
using DAL.DataMapping;

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

        protected override void Seed(DAL.DataMapping.ApplicationDbContext context)
        {
            context.Users.AddOrUpdate(x => x.Id,
                new User()
                {
                    Id = 1,
                    Name = "Admin",
                    Username = "admin",
                    Password = Utils.HashPassword("123456")
                }
            );
        }
    } 
}