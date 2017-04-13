using UniversityManagementSystem.Models;

namespace UniversityManagementSystem.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<UniversityManagementSystem.Models.UniversityManagementDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(UniversityManagementSystem.Models.UniversityManagementDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
            //context.Designations.AddOrUpdate(
            //    new Designation { Name = "Lecturer"},
            //    new Designation {Name = "Professor"},
            //    new Designation { Name = "Associate Professor"}
            //    );
            //context.Semisters.AddOrUpdate(
            //    new Semister{Name = "1st"},
            //    new Semister{Name = "2nd"},
            //    new Semister{Name = "3rd"},
            //    new Semister{Name = "4th"},
            //    new Semister{Name = "5th"},
            //    new Semister{Name = "6th"},
            //    new Semister{Name = "7th"},
            //    new Semister{Name = "8th"}
            //    );
        }
    }
}
