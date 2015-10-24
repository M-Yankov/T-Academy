namespace EntityFrameWorkCodeFirst.Data.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using EntityFeameWorkCodeFirst.Models;

    public sealed class Configuration : DbMigrationsConfiguration<SchoolDbContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(SchoolDbContext context)
        {
            context.Courses.AddOrUpdate(
                c => c.Name,
                new Course { Name = "Java Script Applications" },
                new Course { Name = "Data structors and algorithms" },
                new Course { Name = "Java" },
                new Course { Name = "C++" });
        }
    }
}